using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scanner;

namespace Parser
{
    class SyntaxTreeBinaryNode : SyntaxTreeNode
    {
        public SyntaxTreeNode Left { get; set; }
        public SyntaxTreeNode Right { get; set; }
        public Token Token { get; set; }
    }
}
