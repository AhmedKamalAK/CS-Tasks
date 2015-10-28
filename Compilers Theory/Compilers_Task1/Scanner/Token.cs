using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scanner
{
    public class Token
    {
        public string Lexeme { get; internal set; }
        public TokenType TokenType { get; internal set; }

        public override bool Equals(object obj)
        {
            Token t = obj as Token;
            return Lexeme.Equals(t.Lexeme) && TokenType == t.TokenType;
        }

        public override int GetHashCode()
        {
            return Lexeme.GetHashCode() ^ TokenType.GetHashCode();
        }

        public override string ToString()
        {
            return Lexeme;
        }
    }
}
