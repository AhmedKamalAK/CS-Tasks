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
    public partial class Form1 : Form
    {
        IDistributionDataReader distributionsReader = new FilesDistributionDataReader();
        Simulator simulator;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            dict.Add("a", 12);
        }

        //public void BarExample()
        //{
        //    this.chartControl.Series.Clear();

        //    // Data arrays
        //    string[] seriesArray = { "Cat", "Dog", "Bird", "Monkey" };
        //    int[] pointsArray = { 2, 1, 7, 5 };

        //    // Set palette
        //    this.chartControl.Palette = ChartColorPalette.EarthTones;

        //    // Set title
        //    this.chartControl.Titles.Add("Animals");


        //    // Add series.
        //    for (int i = 0; i < seriesArray.Length; i++)
        //    {
        //        Series series = this.chartControl.Series.Add(seriesArray[i]);
        //        series.Points.Add(pointsArray[i]);
        //    }
        //}

        private void chartControl_Click(object sender, EventArgs e)
        {

        }

        private void radNumberOfCustomers_CheckedChanged(object sender, EventArgs e)
        {
            txtNumberOfCustomers.Enabled = true;
            txtStoppingTime.Enabled = false;
        }

        private void radStoppingTime_CheckedChanged(object sender, EventArgs e)
        {
            txtNumberOfCustomers.Enabled = false;
            txtStoppingTime.Enabled = true;
        }

        private void btnSimulate_Click(object sender, EventArgs e)
        {
            //try
            //{
                int numberOfCustomers = 0, stoppingTime = int.MaxValue;
                StoppingCondition stoppingCondition = StoppingCondition.NumberOfCustomers;
                if (radNumberOfCustomers.Checked)
                {
                    stoppingCondition = StoppingCondition.NumberOfCustomers;
                    numberOfCustomers = int.Parse(txtNumberOfCustomers.Text);
                }
                else if (radStoppingTime.Checked)
                {
                    stoppingCondition = StoppingCondition.Time;
                    stoppingTime = int.Parse(txtStoppingTime.Text);
                }

                simulator = new Simulator(numberOfCustomers, stoppingTime, stoppingCondition);

                List<ServiceResult> results = simulator.Simulate();

                List<TableResult> table = new List<TableResult>();

                foreach (var result in results)
                {
                    TableResult table_row = new TableResult(result);
                    table.Add(table_row);
                }

                var bs = new BindingSource();

                bs.DataSource = table;
                dataGridView1.DataSource = bs;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void btnCustomersQueueGraph_Click(object sender, EventArgs e)
        {
            GraphForm queueGraphForm = new GraphForm("Customers Queue", simulator.CustomersQueueDistribution);
            queueGraphForm.Show();
        }

        private void btnCustomersQueueHistogram_Click(object sender, EventArgs e)
        {
            GraphForm queueHistogramForm = new GraphForm("Queue Size Histogram", simulator.CustomersQueueHistogram);
            queueHistogramForm.Show();
        }

        private void btnServersBusyTimeGraph_Click(object sender, EventArgs e)
        {
            int ind = 1;
            foreach (var server in simulator.Servers)
            {
                GraphForm curServerBusyTime = new GraphForm(string.Format("Server {0} Busy Time", ind), server.ServerBusyTimeDistribution);
                curServerBusyTime.Show();
                ind++;
            }
        }

        private void btnStatistics_Click(object sender, EventArgs e)
        {
            var customersStatistics = simulator.ResultStatistics;
            var serversStatistics = new List<ServerStatistics>();

            foreach (var server in simulator.Servers)
            {
                serversStatistics.Add(server.ServerStatistics);
            }

            StatisticsForm statsForm = new StatisticsForm(customersStatistics, serversStatistics);
            statsForm.Show();
        }
    }
}
