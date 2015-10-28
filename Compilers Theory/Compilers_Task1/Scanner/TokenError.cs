using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scanner
{
    public class TokenError : Token
    {
        public int ErrorLineNumber { get; set; }

        public override string ToString()
        {
            return string.Format("Error in line {0} after character {1}.", ErrorLineNumber, Lexeme);
        }
    }
}
