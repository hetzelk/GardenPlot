using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GardenPlot
{
    public class TotalFence//2
    {
        public int GetTotalFence(Dictionary<string, List<int>> dictionaryplots)
        {
            int total = 0;
            foreach(KeyValuePair<string, List<int>> pair in dictionaryplots)
            {
                int eachtotal = GetEachFence(pair.Value[2], pair.Value[3]);
                total += eachtotal;
            }
            return total;
        }

        public int GetEachFence(int w, int h)
        {
            int firsthalf = w * 2;
            int secondhalf = h * 2;
            int totalcurrentfence = firsthalf + secondhalf;
            return totalcurrentfence;
        }

        public void Writer(string output, int total)
        {
            using (StreamWriter sw = new StreamWriter(output))
            {
                sw.WriteLine("total fencing = "+ total);
            }
        }
    }
}
