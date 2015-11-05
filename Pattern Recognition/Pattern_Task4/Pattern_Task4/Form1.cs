using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pattern_Task4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            IrisDataset irisDataset = IrisDatasetReader.ReadIrisDataset("Iris Data.txt");
            var means = irisDataset.CalculateMeans();
            var covarianceMatrecies = irisDataset.CalculateCovarianceMatrecies();
        }
    }
}
