using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationTask_1
{
    class ServiceResult
    {
        public int CustomerNumber { get; set; }
        public int InterarrivalTime { get; set; }
        public int ArrivalTime { get; set; }
        public int IterarrivalTimeRandomNumber { get; set; }
        public int ServiceTimeRandomNumber { get; set; }
        public Service ServerService { get; set; }
        public int ServerDelay { get; set; }
    }
}
