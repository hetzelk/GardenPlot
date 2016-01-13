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
        Dictionary<string, List<int>> fullplotdictionary;
        List<int> FinalMaxPlots;
        public MinFence()
        {
            fullplotdictionary = new Dictionary<string, List<int>>();
            FinalMaxPlots = new List<int>();
        }

        public int GetMinimumFence(Dictionary<string, List<int>> dictionaryplots)
        {
            fullplotdictionary = CreateFullPlotDictionary(dictionaryplots);
            FinalMaxPlots = GetParameters(fullplotdictionary);
            int MinFence = CalculateMinimunFence(FinalMaxPlots);
            return MinFence;
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

        public List<int> GetParameters(Dictionary<string, List<int>> fullplotdictionary)
        {
            List<int> parameters = new List<int>();

            int smallx = GetSmallX(fullplotdictionary);
            int smally = GetSmallY(fullplotdictionary);
            int largex = GetLargeX(fullplotdictionary);
            int largey = GetLargeY(fullplotdictionary);
            parameters.Add(smallx);
            parameters.Add(smally);
            parameters.Add(largex);
            parameters.Add(largey);

            return parameters;
        }

        public int GetLargeX(Dictionary<string, List<int>> fullplots)
        {
            int maxx = int.MinValue;
            foreach (KeyValuePair<string, List<int>> pair in fullplots)
            {
                int what = pair.Value[2];
                if (pair.Value[2] > maxx)
                {
                    maxx = pair.Value[2];
                }
            }
            return maxx;
        }

        public int GetLargeY(Dictionary<string, List<int>> fullplots)
        {
            int maxy = int.MinValue;
            foreach (KeyValuePair<string, List<int>> pair in fullplots)
            {
                if (pair.Value[3] > maxy)
                {
                    maxy = pair.Value[3];
                }
            }
            return maxy;
        }

        public int GetSmallX(Dictionary<string, List<int>> fullplots)
        {
        int smallx = int.MaxValue;
        foreach (KeyValuePair<string, List<int>> pair in fullplots)
        {
            if (pair.Value[0] < smallx)
            {
                smallx = pair.Value[0];
            }
        }
        return smallx;
    }

        public int GetSmallY(Dictionary<string, List<int>> fullplots)
        {
            int smally = int.MaxValue;
            foreach (KeyValuePair<string, List<int>> pair in fullplots)
            {
                if (pair.Value[1] < smally)
                {
                    smally = pair.Value[1];
                }
            }
            return smally;
        }

        public int CalculateMinimunFence(List<int> boundaries)
        {
            int minfence = 0;
            int xfence = 2 * (boundaries[2] - boundaries[0]);
            int yfence = 2 * (boundaries[3] - boundaries[1]);

            minfence = xfence + yfence;

            return minfence;
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
