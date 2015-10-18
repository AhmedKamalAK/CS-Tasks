using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationTask_1
{
    class Distribution
    {
        public List<int> Times { get; set; }
        public List<double> Probabilities { get; set; }
        public List<double> CumulativeProbabilities { get; set; }
        public List<KeyValuePair<int, int>> Ranges { get; set; }

        public Distribution()
        {
            Times = new List<int>();
            Probabilities = new List<double>();
            CumulativeProbabilities = new List<double>();
            Ranges = new List<KeyValuePair<int, int>>();
        }
    }
}
