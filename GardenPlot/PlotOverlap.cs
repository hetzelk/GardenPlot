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
        Dictionary<string, List<int>> fullplots;

        public PlotOverlap()
        {
            fullplots = new Dictionary<string, List<int>>();
        }

        public List<string> CheckAllOverlaps(Dictionary<string, List<int>> dictionaryplots)
        {
            List<string> plotoverlaps = new List<string>();
            fullplots = CreateFullPlotDictionary(dictionaryplots);
            plotoverlaps = CheckEachPlotOverlap(fullplots);
            return plotoverlaps;
        }

        public Dictionary<string, List<int>> CreateFullPlotDictionary(Dictionary<string, List<int>> dictionaryplots)
        {
            int xwidth = 0;
            int yheight = 0;
            Dictionary<string, List<int>> plots = new Dictionary<string, List<int>>();
            foreach (KeyValuePair<string, List<int>> pair in dictionaryplots)
            {
                List<int> plotlist = new List<int>();
                xwidth = pair.Value[0] + pair.Value[2];
                yheight = pair.Value[1] + pair.Value[3];
                plotlist.Add(pair.Value[0]);
                plotlist.Add(pair.Value[1]);
                plotlist.Add(xwidth);
                plotlist.Add(yheight);
                plots.Add(pair.Key, plotlist);
            }
            return plots;
        }

        public List<string> CheckEachPlotOverlap(Dictionary<string, List<int>> fullplots)
        {
            List<string> overlapStrings = new List<string>();
            foreach (KeyValuePair<string, List<int>> pair in fullplots)
            {
                string statement = ChecKBoundaries(fullplots, pair.Key, pair.Value[0], pair.Value[1], pair.Value[2], pair.Value[3]);
                overlapStrings.Add(statement);
            }
            return overlapStrings;
        }

        public string ChecKBoundaries(Dictionary<string, List<int>> fullplots, string plot, int x, int y, int w, int h)
        {
            string statement = "";
            foreach (KeyValuePair<string, List<int>> secondpair in fullplots)
            {       
                if (!(h < secondpair.Value[1] || y > secondpair.Value[3] || w < secondpair.Value[0] || x > secondpair.Value[2]))
                {
                    if (plot == secondpair.Key)
                    {
                        statement = "";
                    }
                    else
                    {
                        statement = String.Format("plot {0} conflicts with plot {1}", plot, secondpair.Key);
                    }
                }
            }
                return statement;
        }

        public void Writer(string output, List<string> plots)
        {
            using (StreamWriter sw = new StreamWriter(output))
            {
                foreach(string line in plots)
                {
                    sw.WriteLine(line);
                }
            }
        }
    }
}
