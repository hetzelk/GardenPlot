using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GardenPlot
{
    public class MinFence
    {
        Dictionary<string, List<int>> fullPlotDictionary;
        List<int> finalMaxPlots;
        public MinFence()
        {
            fullPlotDictionary = new Dictionary<string, List<int>>();
            finalMaxPlots = new List<int>();
        }

        public int GetMinimumFence(Dictionary<string, List<int>> dictionaryPlots)
        {
            fullPlotDictionary = CreateFullPlotDictionary(dictionaryPlots);
            finalMaxPlots = GetParameters(fullPlotDictionary);
            int MinFence = CalculateMinimunFence(finalMaxPlots);
            return MinFence;
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

        public List<int> GetParameters(Dictionary<string, List<int>> fullPlotDictionary)
        {
            List<int> parameters = new List<int>();

            int smallX = GetSmallX(fullPlotDictionary);
            int smallY = GetSmallY(fullPlotDictionary);
            int largeX = GetLargeX(fullPlotDictionary);
            int largeY = GetLargeY(fullPlotDictionary);
            parameters.Add(smallX);
            parameters.Add(smallY);
            parameters.Add(largeX);
            parameters.Add(largeY);

            return parameters;
        }

        public int GetLargeX(Dictionary<string, List<int>> fullPlots)
        {
            int maxX = int.MinValue;
            foreach (KeyValuePair<string, List<int>> pair in fullPlots)
            {
                int what = pair.Value[2];
                if (pair.Value[2] > maxX)
                {
                    maxX = pair.Value[2];
                }
            }
            return maxX;
        }

        public int GetLargeY(Dictionary<string, List<int>> fullPlots)
        {
            int maxY = int.MinValue;
            foreach (KeyValuePair<string, List<int>> pair in fullPlots)
            {
                if (pair.Value[3] > maxY)
                {
                    maxY = pair.Value[3];
                }
            }
            return maxY;
        }

        public int GetSmallX(Dictionary<string, List<int>> fullPlots)
        {
        int smallX = int.MaxValue;
        foreach (KeyValuePair<string, List<int>> pair in fullPlots)
        {
            if (pair.Value[0] < smallX)
            {
                smallX = pair.Value[0];
            }
        }
        return smallX;
    }

        public int GetSmallY(Dictionary<string, List<int>> fullPlots)
        {
            int smallY = int.MaxValue;
            foreach (KeyValuePair<string, List<int>> pair in fullPlots)
            {
                if (pair.Value[1] < smallY)
                {
                    smallY = pair.Value[1];
                }
            }
            return smallY;
        }

        public int CalculateMinimunFence(List<int> boundaries)
        {
            int minFence = 0;
            int xFence = 2 * (boundaries[2] - boundaries[0]);
            int yFence = 2 * (boundaries[3] - boundaries[1]);

            minFence = xFence + yFence;

            return minFence;
        }

        public void Writer(string output, int total)
        {
            using (StreamWriter sw = new StreamWriter(output))
            {
                sw.WriteLine("minimum fencing = "+ total);
            }
        }
    }
}
