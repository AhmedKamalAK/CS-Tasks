using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationTask_1
{
    class Simulator
    {

        int neededNumberOfCustomers;
        int timeToFinish;
        StoppingCondition stoppingCodition;
        private List<ServiceResult> simulationResults;

        public CustomersStatistics ResultStatistics { get; private set; }
        public List<Server> Servers { get; private set; }
        public List<int> CustomersQueueDistribution { get; private set; }
        public List<int> CustomersQueueHistogram { get; private set; }


        public Simulator()
        {
            neededNumberOfCustomers = 100;
            stoppingCodition = StoppingCondition.NumberOfCustomers;
            ResultStatistics = new CustomersStatistics();
        }
        public Simulator(int numberOfCustomersToFinish, int timeToFinish, StoppingCondition stoppingCodition)
        {
            this.neededNumberOfCustomers = numberOfCustomersToFinish;
            this.timeToFinish = timeToFinish;
            this.stoppingCodition = stoppingCodition;
            ResultStatistics = new CustomersStatistics();
        }
        private void CalculateCumlativeDistributionAndRange(Distribution dist)
        {
            dist.CumulativeProbabilities.Add(dist.Probabilities[0]);
            dist.Ranges.Add(new KeyValuePair<int, int>(0, (int)(dist.CumulativeProbabilities[0] * 1000)));

            for (int i = 1; i < dist.Times.Count; i++)
            {
                dist.CumulativeProbabilities.Add(dist.CumulativeProbabilities[i - 1] + dist.Probabilities[i]);
                dist.Ranges.Add(new KeyValuePair<int, int>(dist.Ranges[i - 1].Value + 1, (int)(dist.CumulativeProbabilities[i] * 1000)));
            }
        }

        private void FillServersData(List<Distribution> serviceTimeDistributions)
        {
            Servers = new List<Server>();

            for (int i = 0; i < serviceTimeDistributions.Count; i++)
            {
                Servers.Add(new Server()
                {
                    ServerID = i + 1,
                    ServiceTimeDistribution = serviceTimeDistributions[i],
                    Services = new List<Service>()
                });
            }
        }
        public List<ServiceResult> Simulate()
        {
            IDistributionDataReader distributionsReader = new FilesDistributionDataReader();
            Distribution interarrivalDistribution = distributionsReader.ReadIterarrivalDistribution();
            List<Distribution> serviceTimeDistributions = distributionsReader.ReadServerTimeDistributions();

            CalculateCumlativeDistributionAndRange(interarrivalDistribution);
            for (int i = 0; i < serviceTimeDistributions.Count; i++)
            {
                CalculateCumlativeDistributionAndRange(serviceTimeDistributions[i]);
            }

            FillServersData(serviceTimeDistributions);

            var results = new List<ServiceResult>();
            Random rand = new Random();

            int numberOfCustomers = 0;
            int time = 0;
            results.Add(new ServiceResult()
            {
                ArrivalTime = 0,
            });

            while (!IsFinished(numberOfCustomers, time))
            {
                int interarrivalTimeRandomNumber = rand.Next(0, 1001);
                int serviceTimeRandomNumber = rand.Next(0, 1001);

                int interarrivalTimeRangeIndex = PickRange(interarrivalTimeRandomNumber, interarrivalDistribution.Ranges);
                if (interarrivalTimeRangeIndex == -1) throw new Exception("Random interarrival time not in range");

                int interarrivalTime = interarrivalDistribution.Times[interarrivalTimeRangeIndex];

                int arrivalTime = results[results.Count - 1].ArrivalTime + interarrivalTime;

                if (arrivalTime > timeToFinish) 
                    break;

                numberOfCustomers++;
                time = Math.Max(time, arrivalTime);

                int serverIndex = PickServer(arrivalTime, Servers);
                int size = Servers[serverIndex].Services.Count;
                int delayTime = new int();
                if (size <= 0)
                {
                    delayTime = 0;
                }
                else
                {
                    delayTime = Math.Max(0, Servers[serverIndex].Services[size - 1].ServiceTimeEnd - arrivalTime);
                    Servers[serverIndex].Services[size - 1].ServiceDelay = delayTime;
                }
                //error


                Distribution serverDistribution = Servers[serverIndex].ServiceTimeDistribution;
                int serviceTimeRangeIndex = PickRange(serviceTimeRandomNumber, serverDistribution.Ranges);

                int serviceTime = serverDistribution.Times[serviceTimeRangeIndex];

                var serverServices = Servers[serverIndex].Services;

                int serviceStart = arrivalTime;

                if (serverServices.Count != 0)
                    serviceStart = Math.Max(arrivalTime, serverServices[serverServices.Count - 1].ServiceTimeEnd);

                int serviceEnd = serviceStart + serviceTime;

                Service service = new Service()
                {
                    ServerID = Servers[serverIndex].ServerID,
                    ServiceTimeBegin = serviceStart,
                    ServiceDuraiton = serviceTime,
                    ServiceTimeEnd = serviceEnd
                };

                Servers[serverIndex].Services.Add(service);

                ServiceResult serviceResult = new ServiceResult();
                serviceResult.CustomerNumber = numberOfCustomers;
                serviceResult.IterarrivalTimeRandomNumber = interarrivalTimeRandomNumber;
                serviceResult.ServiceTimeRandomNumber = serviceTimeRandomNumber;
                serviceResult.InterarrivalTime = interarrivalTime;
                serviceResult.ArrivalTime = arrivalTime;
                serviceResult.ServerService = service;
                serviceResult.ServerDelay = delayTime;
                
                results.Add(serviceResult);
            }
            results.RemoveAt(0);

            simulationResults = results;
            
            CalculateCustomersQueueDistribution(results[results.Count-1].ServerService.ServiceTimeEnd);
            CalculateQueueHistogram();
            
            int maximumQueueLength = CalculateMaximumQueueSize();
            double averageCustomerWait = SetAverageCustomerWait(results, numberOfCustomers);
            double probabilityCustomerWait = SetProbabilityCustomerWait(results, numberOfCustomers);

            ResultStatistics = new CustomersStatistics()
            {
                MaximumQueueLength = maximumQueueLength,
                AverageCustomerWait = averageCustomerWait,
                ProbabilityCustomerWait = probabilityCustomerWait
            };

            for (int i = 0; i < Servers.Count; i++)
            {
                Servers[i].CalculateServerStatistcs(results[results.Count - 1].ServerService.ServiceTimeEnd, numberOfCustomers);
            }

            return results;

        }

        private int PickServer(int arrivalTime, List<Server> servers)
        {
            int serverIndex = 0;
            int minEndTimeServerIndex = 0;
            int minEndTime = int.MaxValue;

            foreach (var server in servers)
            {
                var services = server.Services;
                if (services.Count == 0 || arrivalTime >= services[services.Count - 1].ServiceTimeEnd)
                    return serverIndex;

                if (services[services.Count - 1].ServiceTimeEnd < minEndTime)
                {
                    minEndTime = services[services.Count - 1].ServiceTimeEnd;
                    minEndTimeServerIndex = serverIndex;
                }
                serverIndex++;
            }
            return minEndTimeServerIndex;
        }
        public void CalculateQueueHistogram()
        {
            List<int> delayHistogram = new List<int>();
            int mxDelay = CalculateMaximumDelay();

            for (int i = 0; i <= mxDelay; i++)
            {
                delayHistogram.Add(0);
            }

            foreach (var service in simulationResults)
            {
                int delay = service.ServerDelay;
                delayHistogram[delay]++;
            }
            
            CustomersQueueHistogram = delayHistogram;
        }

        private int CalculateMaximumDelay()
        {
            int mxDelay = 0;

            foreach (var service in simulationResults)
            {
                mxDelay = Math.Max(mxDelay, service.ServerDelay);
            }

            return mxDelay;
        }

        private void CalculateCustomersQueueDistribution(int endTime)
        {
            List<int> customersQueue = new List<int>();
            for (int i = 0; i <= endTime; i++)
            {
                customersQueue.Add(0);
            }

            foreach (var service in simulationResults)
            {
                customersQueue[service.ServerService.ServiceTimeBegin]--;
                customersQueue[service.ArrivalTime]++;
            }
            for (int i = 1; i < endTime; i++)
            {
                customersQueue[i] += customersQueue[i - 1];
            }

            CustomersQueueDistribution = customersQueue;
        }

        public int CalculateMaximumQueueSize()
        {
            int mxQueueSize = 0;
            
            foreach (var size in CustomersQueueDistribution)
            {
                mxQueueSize = Math.Max(mxQueueSize, size);
            }

            return mxQueueSize;
        }

        //private void CalculateQueueHistogram()
        //{
        //    int mxQueueSize = CalculateMaximumQueueSize();
        //    var queueHistogram = new int[mxQueueSize + 1];

        //    foreach (var size in CustomersQueueDistribution)
        //    {
        //        queueHistogram[size]++;
        //    }

        //    CustomersQueueHistogram = queueHistogram.ToList();
        //}

        private int PickRange(int number, List<KeyValuePair<int, int>> ranges)
        {
            for (int i = 0; i < ranges.Count; i++)
            {
                if (number >= ranges[i].Key && number <= ranges[i].Value)
                    return i;
            }

            return -1;
        }
        //
        public double SetAverageCustomerWait(List<ServiceResult> wait, int size)
        {
            double AverageWait = 0;
            foreach (var item in wait)
            {
                AverageWait += item.ServerService.ServiceDelay;
            }
            return AverageWait / size;
        }

        public double SetProbabilityCustomerWait(List<ServiceResult> wait, int size)
        {
            double AverageWait = 0;
            foreach (var item in wait)
            {
                if (item.ServerService.ServiceDelay >=1 )
                AverageWait +=1 ;
            }
            return AverageWait / size;
        }

        private bool IsFinished(int currentNumberOfCustomers, int currentTime)
        {
            if (stoppingCodition == StoppingCondition.NumberOfCustomers)
            {
                if (currentNumberOfCustomers >= neededNumberOfCustomers)
                    return true;
            }
            else if (stoppingCodition == StoppingCondition.Time)
            {
                if (currentTime >= timeToFinish)
                    return true;
            }

            return false;
        }
    }
}
