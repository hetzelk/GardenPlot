using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GardenPlot
{
    public class TotalFence
    {
        public int GetTotalFence(Dictionary<string, List<int>> dictionaryPlots)
        {
            int total = 0;
            foreach(KeyValuePair<string, List<int>> pair in dictionaryPlots)
            {
                int eachTotal = GetEachFence(pair.Value[2], pair.Value[3]);
                total += eachTotal;
            }
            return total;
        }

        public int GetEachFence(int w, int h)
        {
            int firstHalf = w * 2;
            int secondHalf = h * 2;
            int totalCurrentFence = firstHalf + secondHalf;
            return totalCurrentFence;
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
