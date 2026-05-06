using System;
using System.Collections.Generic;
using System.Linq;

namespace new2026
{
    public class Parser
    {
        public class SyntaxError
        {
            public string Fragment { get; set; }
            public int Line { get; set; }
            public int Position { get; set; }
            public string Description { get; set; }
        }

        private List<Lexer.Token> _tokens;
        private int _position;
        public List<SyntaxError> Errors { get; private set; }
        public AstNode Root { get; private set; }

        public Parser(List<Lexer.Token> tokens)
        {
            _tokens = tokens;
            _position = 0;
            Errors = new List<SyntaxError>();
            Root = null;
        }

        private Lexer.Token Current => _position < _tokens.Count ? _tokens[_position] : null;
        private Lexer.Token PeekNext => _position + 1 < _tokens.Count ? _tokens[_position + 1] : null;
        private bool IsAtEnd => Current == null;

        private void Advance()
        {
            if (Current != null)
                _position++;
        }

        private bool Check(Lexer.TokenType type, string value = null)
        {
            if (IsAtEnd) return false;
            if (Current.Type != type) return false;
            if (value != null && Current.Value != value) return false;
            return true;
        }

        private bool Match(Lexer.TokenType type, string value = null)
        {
            if (Check(type, value))
            {
                Advance();
                return true;
            }
            return false;
        }

        private void AddError(string message, Lexer.Token found)
        {
            if (Errors.Count > 0 && found != null)
            {
                var lastError = Errors.Last();
                if (lastError.Fragment == found.Value &&
                    lastError.Line == found.Line &&
                    lastError.Position == found.Column)
                {
                    return;
                }
            }

            Errors.Add(new SyntaxError
            {
                Fragment = found != null ? found.Value : "конец файла",
                Line = found != null ? found.Line : 1,
                Position = found != null ? found.Column : 1,
                Description = message
            });
        }

        private Lexer.Token _lastValidTokenBeforeSemicolon = null;

        private void UpdateLastValidToken(Lexer.Token token)
        {
            if (token != null && token.Type != Lexer.TokenType.Error)
            {
                _lastValidTokenBeforeSemicolon = token;
            }
        }

        private bool SkipErrorTokens()
        {
            bool skipped = false;
            string lastErrorChar = null;

            while (!IsAtEnd && Current.Type == Lexer.TokenType.Error)
            {
                string currentChar = Current.Value;

                if (lastErrorChar == null || currentChar != lastErrorChar)
                {
                    AddError($"Недопустимый символ '{currentChar}'", Current);
                    lastErrorChar = currentChar;
                }

                skipped = true;
                Advance();
            }

            return skipped;
        }

        private bool IsComparisonOperator(string op)
        {
            return op == ">" || op == "<" || op == ">=" || op == "<=" || op == "==" || op == "!=";
        }

        private bool IsLogicalOperator(string op)
        {
            return op == "and" || op == "or" || op == "&&" || op == "||";
        }

        private bool HandleInvalidOperators()
        {
            if (IsAtEnd) return false;

            if (Check(Lexer.TokenType.Operator) && PeekNext != null && PeekNext.Type == Lexer.TokenType.Operator)
            {
                string firstOp = Current.Value;
                string secondOp = PeekNext.Value;
                string combined = firstOp + secondOp;

                if (!IsComparisonOperator(combined) && !IsLogicalOperator(combined))
                {
                    AddError($"Недопустимый оператор '{combined}'", Current);
                    Advance();
                    Advance();
                    return true;
                }
            }

            return false;
        }

        private AstNode ParseOperand()
        {
            SkipErrorTokens();

            if (HandleInvalidOperators())
            {
                SkipErrorTokens();
                return null;
            }

            if (Check(Lexer.TokenType.Boolean))
            {
                var token = Current;
                Advance();
                UpdateLastValidToken(token);
                bool value = token.Value == "true";
                return new NumberNode
                {
                    Value = value ? 1 : 0,
                    RawValue = token.Value,
                    IsOverflow = false,
                    Line = token.Line,
                    Column = token.Column
                };
            }

            if (Match(Lexer.TokenType.Identifier))
            {
                var token = _tokens[_position - 1];
                UpdateLastValidToken(token);
                return new VariableNode
                {
                    Name = token.Value,
                    Line = token.Line,
                    Column = token.Column
                };
            }

            if (Match(Lexer.TokenType.Number))
            {
                var token = _tokens[_position - 1];
                UpdateLastValidToken(token);

                if (int.TryParse(token.Value, out int intValue))
                {
                    return new NumberNode
                    {
                        Value = intValue,
                        RawValue = token.Value,
                        IsOverflow = false,
                        Line = token.Line,
                        Column = token.Column
                    };
                }
                else
                {
                    return new NumberNode
                    {
                        Value = 0,
                        RawValue = token.Value,
                        IsOverflow = true,
                        Line = token.Line,
                        Column = token.Column
                    };
                }
            }

            if (Match(Lexer.TokenType.LeftParen))
            {
                var leftParen = _tokens[_position - 1];
                var expr = ParseLogicalExpression();
                if (expr == null)
                {
                    return null;
                }
                if (!Match(Lexer.TokenType.RightParen))
                {
                    AddError("Ожидалась закрывающая скобка ')'", Current);
                    return null;
                }
                UpdateLastValidToken(_tokens[_position - 1]);
                return expr;
            }

            return null;
        }

        private AstNode ParseRelation()
        {
            bool isNot = false;

            if (Check(Lexer.TokenType.Operator) && (Current.Value == "not" || Current.Value == "!"))
            {
                isNot = true;
                Advance();
                return ParseRelation();
            }

            SkipErrorTokens();
            HandleInvalidOperators();

            var left = ParseOperand();
            if (left == null)
            {
                return null;
            }

            if (Check(Lexer.TokenType.Operator))
            {
                string op = Current.Value;

                if (IsComparisonOperator(op))
                {
                    var opToken = Current;
                    Advance();

                    SkipErrorTokens();
                    HandleInvalidOperators();

                    var right = ParseOperand();
                    if (right == null)
                    {
                        AddError("Ожидался операнд после оператора сравнения", Current);
                        return null;
                    }

                    var binaryOp = new BinaryOpNode
                    {
                        Operator = op,
                        Left = left,
                        Right = right,
                        Line = opToken.Line,
                        Column = opToken.Column
                    };

                    if (isNot)
                    {
                        return new BinaryOpNode
                        {
                            Operator = "==",
                            Left = new NumberNode { Value = 0, RawValue = "false", IsOverflow = false, Line = opToken.Line, Column = opToken.Column },
                            Right = binaryOp,
                            Line = opToken.Line,
                            Column = opToken.Column
                        };
                    }

                    return binaryOp;
                }
                else if (!IsLogicalOperator(op))
                {
                    HandleInvalidOperators();
                    return left;
                }
            }

            return isNot ? null : left;
        }

        private AstNode ParseLogicalExpression()
        {
            var left = ParseRelation();
            if (left == null)
            {
                return null;
            }

            while (Check(Lexer.TokenType.Operator) && IsLogicalOperator(Current.Value))
            {
                string logicalOp = Current.Value;
                var opToken = Current;
                Advance();

                SkipErrorTokens();
                HandleInvalidOperators();

                var right = ParseRelation();
                if (right == null)
                {
                    AddError($"Ожидалось выражение после '{logicalOp}'", Current);
                    return null;
                }

                left = new BinaryOpNode
                {
                    Operator = logicalOp,
                    Left = left,
                    Right = right,
                    Line = opToken.Line,
                    Column = opToken.Column
                };
            }

            return left;
        }

        private Lexer.Token FindLastValidToken()
        {
            for (int i = _tokens.Count - 1; i >= 0; i--)
            {
                if (_tokens[i].Type != Lexer.TokenType.Error)
                {
                    return _tokens[i];
                }
            }
            return null;
        }

        public AstNode Parse()
        {
            if (IsAtEnd)
            {
                AddError("Выражение не может быть пустым", null);
                return null;
            }

            bool hasError = false;
            _lastValidTokenBeforeSemicolon = null;
            int lastPosition = -1;
            var statements = new List<AstNode>();

            while (!IsAtEnd)
            {
                if (_position == lastPosition)
                {
                    Advance();
                    continue;
                }
                lastPosition = _position;

                while (Match(Lexer.TokenType.Semicolon, ";"))
                {
                    lastPosition = _position;
                }

                if (IsAtEnd) break;

                SkipErrorTokens();

                if (IsAtEnd) break;

                if (!Check(Lexer.TokenType.Identifier))
                {
                    if (Check(Lexer.TokenType.Operator))
                    {
                        AddError($"Недопустимый оператор '{Current.Value}' в начале выражения", Current);
                        Advance();
                        hasError = true;
                        continue;
                    }
                    else if (!Check(Lexer.TokenType.Semicolon))
                    {
                        AddError($"Ожидался идентификатор, найдено '{Current?.Value ?? "конец"}'", Current);
                        if (Current != null) Advance();
                        hasError = true;
                        continue;
                    }
                }

                if (!Match(Lexer.TokenType.Identifier))
                {
                    Advance();
                    hasError = true;
                    continue;
                }

                var identifierToken = _tokens[_position - 1];
                _lastValidTokenBeforeSemicolon = identifierToken;

                if (!Match(Lexer.TokenType.Operator, "="))
                {
                    if (Check(Lexer.TokenType.Operator, "=="))
                    {
                        AddError("Ожидался оператор присваивания '=', найдено '=='", Current);
                        Advance();
                    }
                    else if (!Check(Lexer.TokenType.Semicolon))
                    {
                        AddError("Ожидался оператор присваивания '='", Current);
                    }
                    hasError = true;

                    while (!IsAtEnd && !Check(Lexer.TokenType.Semicolon))
                    {
                        Advance();
                    }
                    continue;
                }

                var trueValue = ParseOperand();
                if (trueValue == null)
                {
                    AddError("Ожидался операнд (значение при true)", Current ?? identifierToken);
                    hasError = true;
                }

                AstNode condition = null;
                AstNode falseValue = null;
                bool hasConditional = false;
                Lexer.Token ifToken = null;
                Lexer.Token elseToken = null;

                if (Check(Lexer.TokenType.If))
                {
                    ifToken = Current;
                    hasConditional = true;
                    Advance();

                    condition = ParseLogicalExpression();
                    if (condition == null)
                    {
                        AddError("Ожидалось условие после 'if'", ifToken);
                        hasError = true;
                        while (!IsAtEnd && !Check(Lexer.TokenType.Else) && !Check(Lexer.TokenType.Semicolon))
                        {
                            Advance();
                        }
                    }

                    if (Check(Lexer.TokenType.Else))
                    {
                        elseToken = Current;
                        Advance();

                        falseValue = ParseOperand();
                        if (falseValue == null)
                        {
                            AddError("Ожидался операнд (значение при false) после 'else'", elseToken);
                            hasError = true;
                        }
                    }
                    else if (!Check(Lexer.TokenType.Semicolon) && !IsAtEnd)
                    {
                        if (Check(Lexer.TokenType.Identifier) && Current.Value.StartsWith("el"))
                        {
                            AddError($"Ожидалось ключевое слово 'else', найдено '{Current.Value}' (опечатка)", Current);
                            Advance();
                            hasError = true;
                        }
                        else if (!IsAtEnd)
                        {
                            AddError("Ожидалось ключевое слово 'else'", Current);
                            hasError = true;
                        }
                    }
                }

                AstNode assignNode = null;

                if (hasConditional && condition != null && falseValue != null && trueValue != null)
                {
                    int condLine = ifToken?.Line ?? identifierToken.Line;
                    int condColumn = ifToken?.Column ?? identifierToken.Column;

                    var conditionalNode = new ConditionalNode
                    {
                        Condition = condition,
                        TrueValue = trueValue,
                        FalseValue = falseValue,
                        Line = condLine,
                        Column = condColumn
                    };

                    assignNode = new AssignNode
                    {
                        VariableName = identifierToken.Value,
                        Value = conditionalNode,
                        Line = identifierToken.Line,
                        Column = identifierToken.Column
                    };
                }
                else if (trueValue != null && !hasConditional)
                {
                    assignNode = new AssignNode
                    {
                        VariableName = identifierToken.Value,
                        Value = trueValue,
                        Line = identifierToken.Line,
                        Column = identifierToken.Column
                    };
                }

                if (assignNode != null && !hasError)
                {
                    statements.Add(assignNode);
                }

                while (!IsAtEnd && !Check(Lexer.TokenType.Semicolon))
                {
                    if (Check(Lexer.TokenType.Error))
                    {
                        SkipErrorTokens();
                    }
                    else if (Check(Lexer.TokenType.Operator))
                    {
                        if (!HandleInvalidOperators())
                        {
                            Advance();
                        }
                    }
                    else
                    {
                        Advance();
                    }
                }

                if (!Match(Lexer.TokenType.Semicolon, ";"))
                {
                    if (IsAtEnd)
                    {
                        Lexer.Token lastToken = _lastValidTokenBeforeSemicolon;
                        if (lastToken == null)
                        {
                            lastToken = FindLastValidToken();
                        }
                        AddError("Отсутствует точка с запятой ';' в конце выражения", lastToken);
                        hasError = true;
                    }
                }
                else
                {
                    _lastValidTokenBeforeSemicolon = _tokens[_position - 1];
                }
            }

            if (statements.Count > 0)
            {
                Root = new BlockNode
                {
                    Statements = statements
                };
                return Root;
            }

            return null;
        }
    }
}