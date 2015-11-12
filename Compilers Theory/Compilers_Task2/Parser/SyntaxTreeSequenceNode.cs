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

        public override TreeView PrintParseTree( int nodeIndex)
        {
            SyntaxTreeSequenceNode curNode = (SyntaxTreeSequenceNode)this;
            TreeView t = new TreeView();
           
              t.Nodes.Add("Statement");
            
            for (int i = 0; i < curNode.Sequence.Count; i++)
            {

                TreeView temp = new TreeView();
                temp=(curNode.Sequence[i].PrintParseTree( nodeIndex + 1));
                t = (TreeView)temp.Parent ; 


            }
            return t;
        }
    }
}
