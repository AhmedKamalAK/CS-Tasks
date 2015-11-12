using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scanner;
using System.Windows.Forms;

namespace Parser
{
    class SyntaxTreeBinaryNode : SyntaxTreeNode
    {
        public SyntaxTreeNode Left { get; set; }
        public SyntaxTreeNode Right { get; set; }
        public Token Token { get; set; }
        public override TreeView PrintParseTree( int nodeIndex)
        {
            
            
            SyntaxTreeBinaryNode curNode = (SyntaxTreeBinaryNode) this;
            TreeView t = new TreeView();
            t.Nodes.Add(curNode.Token.TokenType.ToString());
            TreeView temp = new TreeView();
            if (curNode.Left != null)
            {
                temp = curNode.Left.PrintParseTree(nodeIndex + 1);
                t = (TreeView)temp.Parent; 
            }


            if (curNode.Right != null)
            {
                temp = curNode.Right.PrintParseTree(nodeIndex + 1);
                t = (TreeView)temp.Parent; 
            }
            return t;
        }

            
            
        
    }
}
