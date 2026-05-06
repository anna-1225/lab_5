using System;
using System.Collections.Generic;

namespace new2026
{
    public class Lexer
    {
        public enum TokenType
        {
            Unknown = 0,
            Number = 1,
            Identifier = 2,
            Operator = 4,
            If = 5,
            Else = 6,
            Semicolon = 7,
            LeftParen = 8,
            RightParen = 9,
            Boolean = 10, 
            Error = 99
        }

        public class Token
        {
            public TokenType Type { get; set; }
            public string Value { get; set; }
            public int Line { get; set; }
            public int Column { get; set; }
            public bool IsError => Type == TokenType.Error;

            public Token(TokenType type, string value, int line, int column)
            {
                Type = type;
                Value = value;
                Line = line;
                Column = column;
            }

            public override string ToString()
            {
                return $"[{Type}] '{Value}' at {Line}:{Column}";
            }
        }

        private static readonly HashSet<string> ValidTwoCharOperators = new HashSet<string>
        {
            ">=", "<=", "==", "!=", "&&", "||"
        };

        private static readonly HashSet<char> ValidOneCharOperators = new HashSet<char>
        {
            '=', '>', '<', '!', '&', '|', '+', '-', '*', '/', '%'
        };

        private static readonly HashSet<string> Keywords = new HashSet<string>
        {
            "if", "else"
        };

        private static readonly HashSet<string> LogicalOps = new HashSet<string>
        {
            "and", "or", "not"
        };

        public static List<Token> Tokenize(string input)
        {
            var tokens = new List<Token>();
            int line = 1;
            int column = 1;
            int i = 0;

            while (i < input.Length)
            {
                char c = input[i];

                if (c == ' ' || c == '\t')
                {
                    column++;
                    i++;
                    continue;
                }

                if (c == '\n')
                {
                    line++;
                    column = 1;
                    i++;
                    continue;
                }

                if (c == '\r')
                {
                    i++;
                    continue;
                }

                if (char.IsLetter(c))
                {
                    int start = i;
                    while (i < input.Length && (char.IsLetterOrDigit(input[i]) || input[i] == '_'))
                    {
                        i++;
                    }
                    string word = input.Substring(start, i - start);

                    if (word == "if")
                        tokens.Add(new Token(TokenType.If, word, line, column));
                    else if (word == "else")
                        tokens.Add(new Token(TokenType.Else, word, line, column));
                    else if (word == "true" || word == "false")
                        tokens.Add(new Token(TokenType.Boolean, word, line, column)); 
                    else if (LogicalOps.Contains(word))
                        tokens.Add(new Token(TokenType.Operator, word, line, column));
                    else
                        tokens.Add(new Token(TokenType.Identifier, word, line, column));

                    column += word.Length;
                    continue;
                }

                if (char.IsDigit(c))
                {
                    int start = i;
                    while (i < input.Length && char.IsDigit(input[i]))
                    {
                        i++;
                    }
                    string number = input.Substring(start, i - start);
                    tokens.Add(new Token(TokenType.Number, number, line, column)); 
                    column += number.Length;
                    continue;
                }

                if (i + 1 < input.Length)
                {
                    string twoChar = input.Substring(i, 2);

                    if (ValidTwoCharOperators.Contains(twoChar))
                    {
                        tokens.Add(new Token(TokenType.Operator, twoChar, line, column));
                        column += 2;
                        i += 2;
                        continue;
                    }
                }

                if (ValidOneCharOperators.Contains(c))
                {
                    tokens.Add(new Token(TokenType.Operator, c.ToString(), line, column));
                    column++;
                    i++;
                    continue;
                }

                switch (c)
                {
                    case '(':
                        tokens.Add(new Token(TokenType.LeftParen, "(", line, column));
                        break;
                    case ')':
                        tokens.Add(new Token(TokenType.RightParen, ")", line, column));
                        break;
                    case ';':
                        tokens.Add(new Token(TokenType.Semicolon, ";", line, column));
                        break;
                    default:
                        tokens.Add(new Token(TokenType.Error, c.ToString(), line, column));
                        break;
                }
                column++;
                i++;
            }

            return tokens;
        }
    }
}