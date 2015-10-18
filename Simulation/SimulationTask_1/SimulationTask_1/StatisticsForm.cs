using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimulationTask_1
{
    public partial class StatisticsForm : Form
    {
        CustomersStatistics customersStatistics;
        List<ServerStatistics> serversStatistics;

        public StatisticsForm()
        {
            InitializeComponent();
        }
        public StatisticsForm(CustomersStatistics customersStatistics, List<ServerStatistics> serversStatistics)
        {
            this.customersStatistics = customersStatistics;
            this.serversStatistics = serversStatistics;
            InitializeComponent();
        }

        private void StatisticsForm_Load(object sender, EventArgs e)
        {
            txtAverageWaiting.Text = customersStatistics.AverageCustomerWait.ToString();
            txtCustomerWaitingProbability.Text = customersStatistics.ProbabilityCustomerWait.ToString();
            txtMaxQueueLength.Text = customersStatistics.MaximumQueueLength.ToString();

            var bs = new BindingSource();
            bs.DataSource = serversStatistics;
            grdServersStatisticsTable.DataSource = bs;
        }
    }
}
