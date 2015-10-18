using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationTask_1
{
    class Server
    {
        public int ServerID { get; set; }
        public Distribution ServiceTimeDistribution { get; set; }
        public List<Service> Services { get; set; }
        public ServerStatistics ServerStatistics { get; set; }
        public List<int> ServerBusyTimeDistribution { get; private set; }

        public void CalculateServerStatistcs(int servicesEndTime, int numberOfCustomers)
        {
            double serverWorkTime = 0;
            foreach (var service in Services)
            {
                serverWorkTime += service.ServiceDuraiton;
            }

            double totalIdleTime = servicesEndTime - serverWorkTime;
            ServerStatistics = new ServerStatistics()
            {
                ServerID = this.ServerID,
                ServerAverageServerTime = serverWorkTime / numberOfCustomers,
                ServerTotalIdleTime = totalIdleTime,
                ServerTotalBusyTime = serverWorkTime,
                ServerEffciency = serverWorkTime / servicesEndTime,
                ServerProbabilityIdleTime = totalIdleTime / servicesEndTime,
            };

            CalculateBusyTimeDistribution(servicesEndTime);
        }

        private void CalculateBusyTimeDistribution(int servicesEndTime)
        {
            int[] busyTimeDistribution = new int[servicesEndTime+1];

            foreach (var service in this.Services)
            {
                busyTimeDistribution[service.ServiceTimeEnd]--;
                busyTimeDistribution[service.ServiceTimeBegin]++;
            }

            for (int i = 1; i <= servicesEndTime; i++)
            {
                busyTimeDistribution[i] += busyTimeDistribution[i - 1];
                busyTimeDistribution[i] = Math.Min(1, busyTimeDistribution[i]);
            }

            this.ServerBusyTimeDistribution = busyTimeDistribution.ToList();
        }
    }
}
