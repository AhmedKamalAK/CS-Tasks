using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationTask_1
{
    interface IDistributionDataReader
    {
        Distribution ReadIterarrivalDistribution();
        List<Distribution> ReadServerTimeDistributions();
    }
}
