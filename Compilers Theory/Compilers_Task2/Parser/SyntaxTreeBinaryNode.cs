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
        public override void PrintParseTree(TreeNode parentNode)
        {
            SyntaxTreeBinaryNode curNode = (SyntaxTreeBinaryNode) this;
          
            string nodeName = "If parts";
            if (curNode.Token != null) 
                nodeName = curNode.Token.TokenType.ToString();

            TreeNode node = new TreeNode(nodeName);

            if (curNode.Left != null)
            {
                curNode.Left.PrintParseTree(node);
            }

            if (curNode.Right != null)
            {
                curNode.Right.PrintParseTree(node);
            }

            parentNode.Nodes.Add(node);
        }
    }
}
