using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationTask_1
{
    public class ServerStatistics
    {
        public int ServerID { get; internal set; }
        public double ServerEffciency { get; internal set; }
        public double ServerAverageServerTime { get; internal set; }
        public double ServerProbabilityIdleTime { get; internal set; }
        public double ServerTotalIdleTime { get; internal set; }
        public double ServerTotalBusyTime { get; internal set; }
    }
}
