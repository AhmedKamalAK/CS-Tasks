using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Scanner;
using Parser;

namespace Compilers_Task2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string inputText = textBox1.Text;
            Parser.Parser parser = new Parser.Parser(inputText);

            AbstractSyntaxTree tree = parser.Parse();

            TreeNode root = new TreeNode("Program");
            parseTree.Nodes.Add(root);
            
            tree.syntaxTreeRoot.PrintParseTree(root);
            

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
    }
}
