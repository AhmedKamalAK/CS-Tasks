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

        public override TreeView PrintParseTree(TreeNode parentNode)
        {
            SyntaxTreeSequenceNode curNode = (SyntaxTreeSequenceNode)this;
            TreeView t = new TreeView();


            for (int i = 0; i < curNode.Sequence.Count; i++)
            {
                TreeNode node = t.Nodes.Add("Statement" + (i+1));
                parentNode.Nodes.Add(node);
                TreeView temp = new TreeView();
                temp = (curNode.Sequence[i].PrintParseTree(node));
                //t.Nodes.Add(temp.Nodes[0]);
                
            }
            return t;
        }
    }
}
