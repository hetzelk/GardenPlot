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
        public List<string> CheckOverlap(Dictionary<string, List<int>> dictionaryplots)
        {
            List<string> plotoverlaps = new List<string>();
            plotoverlaps.Add("");
            return plotoverlaps;
        }

        public void Writer(string output, List<string> plots)
        {
            using (StreamWriter sw = new StreamWriter(output))
            {
                sw.WriteLine("overlap "+plots);
            }
        }
    }
}
