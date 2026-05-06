using System;
using System.Collections.Generic;

namespace new2026
{
    public class Symbol
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Line { get; set; }
        public int Column { get; set; }
    }

    public class SymbolTable
    {
        private Dictionary<string, Symbol> symbols = new Dictionary<string, Symbol>();

        public bool Declare(Symbol symbol)
        {
            if (symbols.ContainsKey(symbol.Name))
                return false;

            symbols[symbol.Name] = symbol;
            return true;
        }
        public Symbol Lookup(string name)
        {
            symbols.TryGetValue(name, out var symbol);
            return symbol;
        }
        public bool IsDeclared(string name)
        {
            return symbols.ContainsKey(name);
        }
        public void Clear()
        {
            symbols.Clear();
        }
    }
}