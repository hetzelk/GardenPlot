using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GardenPlot
{
    public class PlotOverlap//1
    {
        public List<string> checkOverlap(Dictionary<string, List<int>> dictionaryplots)
        {
            List<string> plotoverlaps = new List<string>();
            plotoverlaps.Add("");
            return plotoverlaps;
        }

        public void writer(string output, List<string> plots)
        {
            string path2 = output;
            using (StreamWriter sw = new StreamWriter(path2))
            {
                sw.WriteLine("overlap "+plots);
            }
        }
    }
}
