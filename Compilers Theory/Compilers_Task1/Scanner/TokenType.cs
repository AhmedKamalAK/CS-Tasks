using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scanner
{
    public enum TokenType
    {
        Identifier,
        Number,
        Comment,
        Plus,
        Minus,
        Multiply,
        Division,
        Equal,
        LessThan,
        LessThanOrEqual,
        Greater,
        GreaterThanOrEqual,
        LeftParenthesis,
        RightParenthesis,
        Semicolon,
        Assignment,

        //Reserved Words
        If,
        Then,
        Else,
        End,
        Repeat,
        Until,
        Read,
        Write,

        Error,
        WhiteSpace,
        EndOfFile
    }
}
