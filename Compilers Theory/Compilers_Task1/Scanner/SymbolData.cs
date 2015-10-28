using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scanner
{
    public class SymbolData
    {
        public string Symbol { get; internal set; }

        public override bool Equals(object obj)
        {
            SymbolData symbol = obj as SymbolData;
            return Symbol.Equals(symbol.Symbol);
        }

        public override int GetHashCode()
        {
            return Symbol.GetHashCode();
        }

        public override string ToString()
        {
            return Symbol;
        }
    }
}
