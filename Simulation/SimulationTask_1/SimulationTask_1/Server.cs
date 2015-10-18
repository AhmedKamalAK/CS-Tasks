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
        public double ServerEffciency { get; set; }
        public double ServerAverageServerTime { get; private set; }
        public double ServerProbabilityIdleTime { get; private set; }
        public double ServerTotalIdleTime { get; private set; }
        public double ServerTotalBusyTime { get; private set; }
        public List<int> ServerBusyTimeDistribution { get; private set; }

        public void CalculateStatistcs(int servicesEndTime, int numberOfCustomers)
        {
            ServerEffciency = 0;
            foreach (var service in Services)
            {
                ServerEffciency += service.ServiceDuraiton;
            }
            ServerAverageServerTime = ServerEffciency / numberOfCustomers;
            ServerTotalIdleTime = servicesEndTime - ServerEffciency;
            ServerTotalBusyTime = ServerEffciency;
            ServerEffciency /= servicesEndTime;
            ServerProbabilityIdleTime = ServerTotalIdleTime / servicesEndTime;

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
