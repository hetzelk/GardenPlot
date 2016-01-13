using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GardenPlot
{
    public class PlotOverlap
    {
        Dictionary<string, List<int>> fullPlots;

        public PlotOverlap()
        {
            fullPlots = new Dictionary<string, List<int>>();
        }

        public List<string> CheckAllOverlaps(Dictionary<string, List<int>> dictionaryPlots)
        {
            List<string> plotOverlaps = new List<string>();
            fullPlots = CreateFullPlotDictionary(dictionaryPlots);
            plotOverlaps = CheckEachPlotOverlap(fullPlots);
            return plotOverlaps;
        }

        public Dictionary<string, List<int>> CreateFullPlotDictionary(Dictionary<string, List<int>> dictionaryPlots)
        {
            int xWidth = 0;
            int yHeight = 0;
            Dictionary<string, List<int>> plots = new Dictionary<string, List<int>>();
            foreach (KeyValuePair<string, List<int>> pair in dictionaryPlots)
            {
                List<int> plotList = new List<int>();
                xWidth = pair.Value[0] + pair.Value[2];
                yHeight = pair.Value[1] + pair.Value[3];
                plotList.Add(pair.Value[0]);
                plotList.Add(pair.Value[1]);
                plotList.Add(xWidth);
                plotList.Add(yHeight);
                plots.Add(pair.Key, plotList);
            }
            return plots;
        }

        public List<string> CheckEachPlotOverlap(Dictionary<string, List<int>> fullPlots)
        {
            List<string> overlapStrings = new List<string>();
            foreach (KeyValuePair<string, List<int>> pair in fullPlots)
            {
                string statement = CheckBoundaries(fullPlots, pair.Key, pair.Value[0], pair.Value[1], pair.Value[2], pair.Value[3]);
                overlapStrings.Add(statement);
            }
            return overlapStrings;
        }

        public string CheckBoundaries(Dictionary<string, List<int>> fullplots, string plot, int x, int y, int w, int h)
        {
            string statement = "";
            foreach (KeyValuePair<string, List<int>> secondPair in fullplots)
            {       
                if (!(h < secondPair.Value[1] || y > secondPair.Value[3] || w < secondPair.Value[0] || x > secondPair.Value[2]))
                {
                    if (plot == secondPair.Key)
                    {
                        statement = "";
                    }
                    else
                    {
                        statement = String.Format("plot {0} conflicts with plot {1}", plot, secondPair.Key);
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
