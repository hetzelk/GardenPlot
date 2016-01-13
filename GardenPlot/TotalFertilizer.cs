using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GardenPlot
{
    public class TotalFertilizer//4
    {
        public float GetTotalFertilizer(Dictionary<string, List<int>> dictionaryplots)
        {
            float total = 0;
            foreach(KeyValuePair<string, List<int>> index in dictionaryplots)
            {
                float eachamount = GetFertilizerAmount(index.Value[2], index.Value[3]);
                total += eachamount;
            }
            return total;
        }

        public float GetFertilizerAmount(int x, int y)
        {
            int sqft = x * y;
            int fertilizer = sqft / 2;
            return fertilizer;
        }

        public void Writer(string output, float totalfert)
        {
            using (StreamWriter sw = new StreamWriter(output))
            {
                sw.WriteLine("total fertilizer needed = "+ totalfert);
            }
        }
    }
}
