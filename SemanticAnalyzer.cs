using System;
using System.Collections.Generic;
using System.Linq;

namespace new2026
{
    public class SemanticAnalyzer
    {
        private SymbolTable symbolTable = new SymbolTable();
        private List<SemanticError> _errors;
        private HashSet<string> _errorVariables; 
        private HashSet<string> _errorPositions;

        public IReadOnlyList<SemanticError> Errors => _errors;

        public SemanticAnalyzer()
        {
            _errors = new List<SemanticError>();
            _errorVariables = new HashSet<string>();
            _errorPositions = new HashSet<string>();
        }

        public AstNode Analyze(AstNode root)
        {
            symbolTable.Clear();
            _errors.Clear();
            _errorVariables.Clear();
            _errorPositions.Clear();

            if (root != null)
                Visit(root);

            return root;
        }

        private void AddUniqueVariableError(string variableName, string message, int line, int column)
        {
            string key = $"{line}:{variableName}";
            if (!_errorVariables.Contains(key))
            {
                _errorVariables.Add(key);
                _errors.Add(new SemanticError(message, line, column));
            }
        }

        private void AddUniquePositionError(string message, int line, int column)
        {
            string key = $"{line}:{column}";
            if (!_errorPositions.Contains(key))
            {
                _errorPositions.Add(key);
                _errors.Add(new SemanticError(message, line, column));
            }
        }

        private void Visit(AstNode node)
        {
            if (node == null) return;

            if (node is BlockNode)
                VisitBlockNode((BlockNode)node);
            else if (node is AssignNode)
                VisitAssignNode((AssignNode)node);
            else if (node is ConditionalNode)
                VisitConditionalNode((ConditionalNode)node);
            else if (node is BinaryOpNode)
                VisitBinaryOpNode((BinaryOpNode)node);
            else if (node is VariableNode)
                VisitVariableNode((VariableNode)node);
            else if (node is NumberNode)
                VisitNumberNode((NumberNode)node);
        }

        private void VisitBlockNode(BlockNode node)
        {
            foreach (var stmt in node.Statements)
            {
                Visit(stmt);
            }
        }

        private void VisitAssignNode(AssignNode node)
        {
            if (!symbolTable.IsDeclared(node.VariableName))
            {
                symbolTable.Declare(new Symbol
                {
                    Name = node.VariableName,
                    Type = "int",
                    Line = node.Line,
                    Column = node.Column
                });
            }
            else
            {
                AddUniqueVariableError(
                    node.VariableName,
                    $"Ошибка: идентификатор \"{node.VariableName}\" уже объявлен",
                    node.Line, node.Column
                );
            }

            Visit(node.Value);
        }

        private void VisitConditionalNode(ConditionalNode node)
        {
            Visit(node.Condition);
            Visit(node.TrueValue);
            Visit(node.FalseValue);

            string conditionType = GetExpressionType(node.Condition);

            if (conditionType != "bool" && conditionType != "unknown")
            {
                AddUniquePositionError(
                    $"Ошибка: условие тернарного оператора должно иметь тип bool (получен {conditionType})",
                    node.Line, node.Column
                );
            }
        }

        private void VisitBinaryOpNode(BinaryOpNode node)
        {
            Visit(node.Left);
            Visit(node.Right);

            if (IsComparisonOperator(node.Operator))
            {
                string leftType = GetExpressionType(node.Left);
                string rightType = GetExpressionType(node.Right);

                if (leftType != "unknown" && rightType != "unknown" && leftType != rightType)
                {
                    AddUniquePositionError(
                        $"Ошибка: несовместимые типы в операции сравнения ({leftType} и {rightType})",
                        node.Line, node.Column
                    );
                }
            }
        }

        private void VisitVariableNode(VariableNode node)
        {
            if (!symbolTable.IsDeclared(node.Name))
            {
                AddUniqueVariableError(
                    node.Name,
                    $"Ошибка: идентификатор \"{node.Name}\" не объявлен",
                    node.Line, node.Column
                );
            }
        }

        private void VisitNumberNode(NumberNode node)
        {
            if (node.IsOverflow)
            {
                AddUniquePositionError(
                    $"Ошибка: числовой литерал {node.RawValue} выходит за допустимые пределы типа int",
                    node.Line, node.Column
                );
            }
        }

        private string GetExpressionType(AstNode node)
        {
            if (node is NumberNode)
                return "int";
            else if (node is VariableNode)
            {
                var varNode = (VariableNode)node;
                var symbol = symbolTable.Lookup(varNode.Name);
                return symbol?.Type ?? "unknown";
            }
            else if (node is BinaryOpNode)
            {
                var binaryNode = (BinaryOpNode)node;
                if (IsComparisonOperator(binaryNode.Operator))
                    return "bool";
                if (IsArithmeticOperator(binaryNode.Operator))
                    return "int";
                return "unknown";
            }
            else if (node is ConditionalNode)
            {
                return "int";
            }
            return "unknown";
        }

        private bool IsComparisonOperator(string op)
        {
            return op == ">" || op == "<" || op == ">=" || op == "<=" || op == "==" || op == "!=";
        }

        private bool IsArithmeticOperator(string op)
        {
            return op == "+" || op == "-" || op == "*" || op == "/" || op == "%";
        }
    }

    public class SemanticError
    {
        public string Message { get; }
        public int Line { get; }
        public int Column { get; }

        public SemanticError(string message, int line, int column)
        {
            Message = message;
            Line = line;
            Column = column;
        }

        public override string ToString()
        {
            return $"{Message} (строка {Line}, позиция {Column})";
        }
    }
}