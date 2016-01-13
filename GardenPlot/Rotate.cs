using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GardenPlot
{
    public class Rotate//5
    {
        List<string> rotatedplots;
        int newrotate;
        Dictionary<string, List<int>> rotateddictionary;

        public Rotate()
        {
            rotatedplots = new List<string>();
            rotateddictionary = new Dictionary<string, List<int>>();
        }

        public Dictionary<string, List<int>> RotateAll(string rotate, Dictionary<string, List<int>> dictionaryplots)
        {
            newrotate = Convert.ToInt32(rotate);
            int counter = 0;
            foreach (KeyValuePair<string, List<int>> index in dictionaryplots)
            {
                List<int> eachrotate = RotateEach(index.Value[0], index.Value[1], index.Value[2], index.Value[3]);
                string counterstring = String.Format("{0}", counter);
                rotateddictionary.Add(counterstring, eachrotate);
                counter++;
            }
            return rotateddictionary;
        }

        public List<int> RotateEach(int x, int y, int w, int h)
        {
            int newx;
            int newy;
            int neww;
            int newh;

            List<int> eachrotate = new List<int>();
            if (newrotate == 90)
            {
                newx = x;
                newy = y - w;
                neww = h;
                newh = w;
                eachrotate.Add(newx);
                eachrotate.Add(newy);
                eachrotate.Add(neww);
                eachrotate.Add(newh);
                return eachrotate;
            }
            if (newrotate == 180)
            {
                newx = x - w;
                newy = y - h;
                neww = w;
                newh = h;
                eachrotate.Add(newx);
                eachrotate.Add(newy);
                eachrotate.Add(neww);
                eachrotate.Add(newh);
                return eachrotate;
            }
            if (newrotate == 270)
            {
                newx = x - w;
                newy = y;
                neww = h;
                newh = w;
                eachrotate.Add(newx);
                eachrotate.Add(newy);
                eachrotate.Add(neww);
                eachrotate.Add(newh);
                return eachrotate;
            }
            return eachrotate;
        }
        public void Writer(string output, Dictionary<string, List<int>> dictionaryplots)
        {
            using (StreamWriter sw = new StreamWriter(output))
            {
                foreach (KeyValuePair<string, List<int>> pair in dictionaryplots)
                {
                    string outputtext = String.Format("{0} ||| {1},{2} - {3},{4}", pair.Key, pair.Value[0], pair.Value[1], pair.Value[2], pair.Value[3]);
                    sw.WriteLine(outputtext);

                    if (pair.Value[0] < 0 || pair.Value[1] < 0)
                    {
                        sw.WriteLine("Plot {0} will be in an invalid place", pair.Key);
                    }
                }
            }
        }
    }
}
