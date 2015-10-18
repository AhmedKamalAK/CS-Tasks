using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationTask_1
{
    class TableResult
    {

        public int CustomerNumber { get; set; }
        public int IterarrivalTimeRandomNumber { get; set; }
        public int InterarrivalTime { get; set; }
        public int ArrivalTime { get; set; }
        public int ServiceTimeRandomNumber { get; set; }
        public int ServerID { get; set; }
        public int ServiceTimeBegin { get; set; }
        public int ServiceTimeEnd { get; set; }
        public int ServiceDuraiton { get; set; }
        public int ServiceDelay { get; set; }
        public TableResult() { }

        public  TableResult (ServiceResult results)
        {
          CustomerNumber = results.CustomerNumber ;
          InterarrivalTime =results.InterarrivalTime ;
          ArrivalTime = results.ArrivalTime ;
          IterarrivalTimeRandomNumber = results.IterarrivalTimeRandomNumber ;
          ServiceTimeRandomNumber =results.ServiceTimeRandomNumber ;
          ServerID =results.ServerService.ServerID;
          ServiceTimeBegin =results.ServerService.ServiceTimeBegin ;
          ServiceTimeEnd =results.ServerService.ServiceTimeEnd ;
          ServiceDuraiton = results.ServerService.ServiceDuraiton;
          ServiceDelay = results.ServerDelay;
        }

    }
}
