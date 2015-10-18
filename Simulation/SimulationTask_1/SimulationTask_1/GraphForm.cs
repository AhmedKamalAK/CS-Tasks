using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
namespace SimulationTask_1
{
    public partial class GraphForm : Form
    {
        List<int> graphData;
        string dataName;
        public GraphForm(string dataName, List<int> data)
        {
            this.graphData = data;
            this.dataName = dataName;
            
            InitializeComponent();
        }

        private void CustomersQueueGraph_Load(object sender, EventArgs e)
        {
            this.Text = dataName;
            chart.Series.Add(dataName);

            //chart.Series[dataName].Points.AddXY(0, 1);
            for (int i = 0; i < graphData.Count; i++)
            {
                chart.Series[dataName].Points.AddXY(i, graphData[i]);
            }
        }

        private void chartCustomersQueue_Click(object sender, EventArgs e)
        {

        }
    }
}
