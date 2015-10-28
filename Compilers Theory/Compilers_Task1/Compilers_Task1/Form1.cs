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

namespace Compilers_Task1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            Scanner.Scanner scanner = new Scanner.Scanner(txtInput.Text);

            try
            {
                List<Token> tokens = scanner.Scan();
                gridTokens.DataSource = ListToBindingSource<Token>(tokens);
                gridSymbolTable.DataSource = ListToBindingSource<SymbolData>(scanner.SymbolTable.ToList());

                lstComments.Items.Clear();
                foreach (var comment in scanner.CommentsList)
                {
                    lstComments.Items.Add(comment);
                }

                lstErrors.Items.Clear();
                foreach (var error in scanner.ErrorsList)
                {
                    lstErrors.Items.Add(error.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private BindingSource ListToBindingSource<T>(List<T> list)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = list;
            return bs;
        }
    }
}
