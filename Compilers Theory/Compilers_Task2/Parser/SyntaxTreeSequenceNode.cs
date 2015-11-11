using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    class SyntaxTreeSequenceNode : SyntaxTreeNode
    {
        public List<SyntaxTreeNode> Sequence { get; set; }

        public SyntaxTreeSequenceNode()
        {
            Sequence = new List<SyntaxTreeNode>();
        }
    }
}
