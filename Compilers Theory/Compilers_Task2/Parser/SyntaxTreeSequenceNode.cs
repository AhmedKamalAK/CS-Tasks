using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Parser
{
    class SyntaxTreeSequenceNode : SyntaxTreeNode
    {
        public List<SyntaxTreeNode> Sequence { get; set; }

        public SyntaxTreeSequenceNode()
        {
            Sequence = new List<SyntaxTreeNode>();

        }

        public override void PrintParseTree(TreeNode parentNode)
        {
            SyntaxTreeSequenceNode curNode = (SyntaxTreeSequenceNode)this;
           
            for (int i = 0; i < curNode.Sequence.Count; i++)
            {
                TreeNode node = new TreeNode("Statement" + (i+1));
                curNode.Sequence[i].PrintParseTree(node);
                parentNode.Nodes.Add(node);
            }
        }
    }
}
