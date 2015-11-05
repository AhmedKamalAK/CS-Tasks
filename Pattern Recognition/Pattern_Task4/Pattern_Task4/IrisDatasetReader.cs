using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern_Task4
{
    static class IrisDatasetReader
    {
        public static IrisDataset ReadIrisDataset(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            
            int c = 1;

            IrisDataset dataset = new IrisDataset();
            for (int i = 1; i < lines.Length; i++)
            {    
                string[] irisDataArray = lines[i].Split(',');
                if (irisDataArray.Length != 5) continue;

                IrisData irisData = new IrisData();
                for (int j = 0; j < irisDataArray.Length - 1; j++)
                {
                    irisData.Features.Add(double.Parse(irisDataArray[j]));
                }

                irisData.Class = irisDataArray[irisDataArray.Length - 1];

                if (c == 1) dataset.TrainingSet[irisData.Class] = new List<IrisData>();

                if (c <= 20)
                {
                    dataset.TrainingSet[irisData.Class].Add(irisData);
                }
                else
                    dataset.TestSet.Add(irisData);
                    
                c++;
                if (c > 50) c = 1;
            }

            return dataset;
        }
    }
}
