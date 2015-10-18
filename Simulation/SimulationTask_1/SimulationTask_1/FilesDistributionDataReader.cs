using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SimulationTask_1
{
    class FilesDistributionDataReader : IDistributionDataReader
    {
        private string distributionsDirectory = "Distributions";
        public Distribution ReadIterarrivalDistribution()
        {
            string fileName = "IterarrivalDistribution.txt";
            string interarrivalTimeFilePath = Path.Combine(distributionsDirectory, fileName);
            string[] entries = File.ReadAllLines(interarrivalTimeFilePath);

            var dist = new Distribution();

            foreach (var entry in entries)
            {
                int time = int.Parse(entry.Split(new char[] { ' ' })[0]);
                double probability = double.Parse(entry.Split(new char[] { ' ' })[1]);

                dist.Times.Add(time);
                dist.Probabilities.Add(probability);
            }

            return dist;
        }

        public List<Distribution> ReadServerTimeDistributions()
        {
            string serversDirectory = Path.Combine(distributionsDirectory, "Servers");
            string[] filesNames = Directory.GetFiles(serversDirectory);

            var distributions = new List<Distribution>();
            foreach (var filePath in filesNames)
            {
                string[] entries = File.ReadAllLines(filePath);

                var dist = new Distribution();

                foreach (var entry in entries)
                {
                    int time = int.Parse(entry.Split(new char[] { ' ' })[0]);
                    double probability = double.Parse(entry.Split(new char[] { ' ' })[1]);

                    dist.Times.Add(time);
                    dist.Probabilities.Add(probability);
                }

                distributions.Add(dist);
            }

            return distributions;
        }
    }
}
