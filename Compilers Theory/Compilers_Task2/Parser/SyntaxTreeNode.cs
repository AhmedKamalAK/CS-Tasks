using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Parser
{
    public abstract class SyntaxTreeNode
    {
        public virtual TreeView PrintParseTree( int nodeIndex)
        {
            TreeView t = new TreeView();
            return t;
        }
    }
}
