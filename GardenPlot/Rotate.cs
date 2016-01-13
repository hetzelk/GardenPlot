using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GardenPlot
{
    public class Rotate
    {
        List<string> rotatedPlots;
        int newRotate;
        Dictionary<string, List<int>> rotatedDictionary;

        public Rotate()
        {
            rotatedPlots = new List<string>();
            rotatedDictionary = new Dictionary<string, List<int>>();
        }

        public Dictionary<string, List<int>> RotateAll(string rotate, Dictionary<string, List<int>> dictionaryPlots)
        {
            newRotate = Convert.ToInt32(rotate);
            int counter = 0;
            foreach (KeyValuePair<string, List<int>> index in dictionaryPlots)
            {
                List<int> eachRotate = RotateEach(index.Value[0], index.Value[1], index.Value[2], index.Value[3]);
                string counterString = String.Format("{0}", counter);
                rotatedDictionary.Add(counterString, eachRotate);
                counter++;
            }
            return rotatedDictionary;
        }

        public List<int> RotateEach(int x, int y, int w, int h)
        {
            int newX;
            int newY;
            int newW;
            int newH;

            List<int> eachRotate = new List<int>();
            if (newRotate == 90)
            {
                newX = x;
                newY = y - w;
                newW = h;
                newH = w;
                eachRotate.Add(newX);
                eachRotate.Add(newY);
                eachRotate.Add(newW);
                eachRotate.Add(newH);
                return eachRotate;
            }
            if (newRotate == 180)
            {
                newX = x - w;
                newY = y - h;
                newW = w;
                newH = h;
                eachRotate.Add(newX);
                eachRotate.Add(newY);
                eachRotate.Add(newW);
                eachRotate.Add(newH);
                return eachRotate;
            }
            if (newRotate == 270)
            {
                newX = x - w;
                newY = y;
                newW = h;
                newH = w;
                eachRotate.Add(newX);
                eachRotate.Add(newY);
                eachRotate.Add(newW);
                eachRotate.Add(newH);
                return eachRotate;
            }
            return eachRotate;
        }
        public void Writer(string output, Dictionary<string, List<int>> dictionaryPlots)
        {
            using (StreamWriter sw = new StreamWriter(output))
            {
                foreach (KeyValuePair<string, List<int>> pair in dictionaryPlots)
                {
                    string outputText = String.Format("{0} ||| {1},{2} - {3},{4}", pair.Key, pair.Value[0], pair.Value[1], pair.Value[2], pair.Value[3]);
                    sw.WriteLine(outputText);

                    if (pair.Value[0] < 0 || pair.Value[1] < 0)
                    {
                        sw.WriteLine("Plot {0} will be in an invalid place", pair.Key);
                    }
                }
            }
        }
    }
}
