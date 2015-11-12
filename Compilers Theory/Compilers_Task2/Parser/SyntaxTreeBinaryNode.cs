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
        public override TreeView PrintParseTree(TreeNode parentNode)
        {
            SyntaxTreeBinaryNode curNode = (SyntaxTreeBinaryNode) this;
            //TreeView t = new TreeView();

            string nodeName = "If parts";
            if (curNode.Token != null) 
                nodeName = curNode.Token.TokenType.ToString();

            TreeNode node = new TreeNode(nodeName);
            parentNode.Nodes.Add(node);
            TreeView temp = new TreeView();
            if (curNode.Left != null)
            {
                temp = curNode.Left.PrintParseTree(node);
                //t.Nodes[0].Nodes.Add(temp.Nodes[0]); 
            }


            if (curNode.Right != null)
            {
                temp = curNode.Right.PrintParseTree(node);
                //t.Nodes[0].Nodes.Add(temp.Nodes[0]); 
            }

            return null;
        }

            
            
        
    }
}
