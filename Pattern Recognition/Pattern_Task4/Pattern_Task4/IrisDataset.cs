using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern_Task4
{
    class IrisDataset
    {
        public Dictionary<string, List<IrisData>> TrainingSet { get; set; }
        public List<IrisData> TestSet { get; set; }
      
        public Dictionary<string, double[]> Means { get; private set; }
        public Dictionary<string, double[,]> CovarianceMatrcies { get; private set; }

        public IrisDataset()
        {
            TrainingSet = new Dictionary<string, List<IrisData>>();
            TestSet = new List<IrisData>();
            Means = new Dictionary<string, double[]>();
            CovarianceMatrcies = new Dictionary<string, double[,]>();
        }

        public Dictionary<string, double[]> CalculateMeans()
        {
            foreach (var curClassData in TrainingSet)
            {
                string curClass = curClassData.Key;
                int featuresCount = curClassData.Value[0].Features.Count;
                double[] curClassMeans = new double[featuresCount];
                double[] featuresSum = new double[featuresCount];

                foreach (var irisData in curClassData.Value)
                {
                    for (int i = 0; i < irisData.Features.Count; i++)
                    {
                        featuresSum[i] += irisData.Features[i];
                    }
                }

                for (int i = 0; i < featuresSum.Length; i++)
                {
                    curClassMeans[i] = featuresSum[i] / curClassData.Value.Count;
                }

                Means.Add(curClass, curClassMeans);
            }

            return Means;
        }

        public Dictionary<string, double[,]> CalculateCovarianceMatrecies()
        {
            int featuresCount = Means.Count;
            foreach (var curClassData in Means)
            {
                string curClassName = curClassData.Key;
                double[,] covarianceMatrix = new double[featuresCount, featuresCount];
                int trainingSetCount = TrainingSet[curClassName].Count;

                for (int i = 0; i < featuresCount; i++)
                {
                    for (int j = 0; j < featuresCount; j++)
                    {
                        double sum = 0;
                        double muI = Means[curClassName][i];
                        double muj = Means[curClassName][j];

                        for (int k = 0; k < trainingSetCount; k++)
                        {
                            double featureI = TrainingSet[curClassName][k].Features[i];
                            double featureJ = TrainingSet[curClassName][k].Features[j];
                            
                            sum += ((featureI - muI) * (featureJ - muj));
                        }

                        double varianceIJ = sum / trainingSetCount;
                        covarianceMatrix[i, j] = varianceIJ;
                    }
                }

                CovarianceMatrcies.Add(curClassName, covarianceMatrix);
            }

            return CovarianceMatrcies;
        }
    }
}
