using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GardenPlot
{
    public class TotalFertilizer
    {
        public float GetTotalFertilizer(Dictionary<string, List<int>> dictionaryPlots)
        {
            float total = 0;
            foreach(KeyValuePair<string, List<int>> index in dictionaryPlots)
            {
                float eachAmount = GetFertilizerAmount(index.Value[2], index.Value[3]);
                total += eachAmount;
            }
            return total;
        }

        public float GetFertilizerAmount(int x, int y)
        {
            int sqft = x * y;
            int fertilizer = sqft / 2;
            return fertilizer;
        }

        public void Writer(string output, float totalFertilizer)
        {
            using (StreamWriter sw = new StreamWriter(output))
            {
                sw.WriteLine("total fertilizer needed = "+ totalFertilizer);
            }
        }
    }
}
