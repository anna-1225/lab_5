using System;
using System.Collections.Generic;

namespace new2026
{
    public abstract class AstNode
    {
        public abstract string ToTree(int indent = 0);
        public int Line { get; set; }
        public int Column { get; set; }
    }

    public class BlockNode : AstNode
    {
        public List<AstNode> Statements { get; set; }

        public BlockNode()
        {
            Statements = new List<AstNode>();
        }

        public override string ToTree(int indent = 0)
        {
            string result = "";
            for (int i = 0; i < Statements.Count; i++)
            {
                result += Statements[i].ToTree(indent);
                if (i < Statements.Count - 1) result += "\n";
            }
            return result;
        }
    }

    public class AssignNode : AstNode
    {
        public string VariableName { get; set; }
        public AstNode Value { get; set; }

        public override string ToTree(int indent = 0)
        {
            string spaces = new string(' ', indent);
            string result = $"{spaces}AssignNode\n";
            result += $"{spaces}├── Variable: {VariableName}\n";
            result += $"{spaces}└── Value:\n";
            result += Value?.ToTree(indent + 2) ?? $"{new string(' ', indent + 2)}null\n";
            return result;
        }
    }

    public class ConditionalNode : AstNode
    {
        public AstNode Condition { get; set; }
        public AstNode TrueValue { get; set; }
        public AstNode FalseValue { get; set; }

        public override string ToTree(int indent = 0)
        {
            string spaces = new string(' ', indent);
            string result = $"{spaces}ConditionalNode\n";

            result += $"{spaces}├── Condition\n";
            result += Condition?.ToTree(indent + 2) ?? $"{new string(' ', indent + 2)}null\n";

            result += $"{spaces}├── TrueValue:\n";
            result += TrueValue?.ToTree(indent + 2) ?? $"{new string(' ', indent + 2)}null\n";

            result += $"{spaces}└── FalseValue:\n";
            result += FalseValue?.ToTree(indent + 2) ?? $"{new string(' ', indent + 2)}null\n";
            return result;
        }
    }

    public class BinaryOpNode : AstNode
    {
        public string Operator { get; set; }
        public AstNode Left { get; set; }
        public AstNode Right { get; set; }

        public override string ToTree(int indent = 0)
        {
            string spaces = new string(' ', indent);
            string result = $"{spaces}BinaryOpNode ({Operator})\n";
            result += $"{spaces}├── Left: ";

            if (Left is VariableNode varLeft)
                result += $"{varLeft.Name}\n";
            else if (Left is NumberNode numLeft)
                result += $"{numLeft.Value}\n";
            else
                result += "\n" + Left?.ToTree(indent + 2);

            result += $"{spaces}└── Right: ";

            if (Right is VariableNode varRight)
                result += $"{varRight.Name}\n";
            else if (Right is NumberNode numRight)
                result += $"{numRight.Value}\n";
            else
                result += "\n" + Right?.ToTree(indent + 2);

            return result;
        }
    }

    public class VariableNode : AstNode
    {
        public string Name { get; set; }

        public override string ToTree(int indent = 0)
        {
            string spaces = new string(' ', indent);
            return $"{spaces}VariableNode ({Name})\n";
        }
    }

    public class NumberNode : AstNode
    {
        public int Value { get; set; }
        public string RawValue { get; set; }
        public bool IsOverflow { get; set; }

        public override string ToTree(int indent = 0)
        {
            string spaces = new string(' ', indent);
            string displayValue = IsOverflow ? RawValue : Value.ToString();
            return $"{spaces}NumberNode\n{spaces}  └── Value: {displayValue}\n";
        }
    }
}