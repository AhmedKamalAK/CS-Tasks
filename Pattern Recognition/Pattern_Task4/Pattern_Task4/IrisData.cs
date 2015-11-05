using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern_Task4
{
    class IrisData
    {
        public List<double> Features { get; set; }
        public string Class { get; set; }

        public IrisData()
        {
            Features = new List<double>();
        }
    }
}
