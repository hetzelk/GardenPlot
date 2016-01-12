using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GardenPlot
{
    public class MinFence//3
    {
        public int getTotalFence(Dictionary<string, List<int>> dictionaryplots)
        {
            int firsthalf = 1;// w * 2
            int secondhalf = 1;//h * 2
            int totalcurrentfence = firsthalf + secondhalf;
            Console.WriteLine(totalcurrentfence);
            return totalcurrentfence;
        }

        public void writer(string output, int total)
        {
            string path2 = output;
            using (StreamWriter sw = new StreamWriter(path2))
            {
                sw.WriteLine("minimum fencing = "+ total);
            }
        }
    }
}
