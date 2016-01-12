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
            int newrotate = Convert.ToInt32(rotate);

            return rotateddictionary;
        }

        public List<int> RotateEach(int x, int y, int w, int h)
        {
            List<int> eachrotate = new List<int>();
            if (newrotate == 90)
            {
                w = -w;
                eachrotate.Add(changed);
                return eachrotate;
            }
            if (newrotate == 180)
            {
                w = -w;
                y = -y;
                eachrotate.Add(changed);
                return eachrotate;
            }
            if (newrotate == 270)
            {
                y = -y;
                eachrotate.Add(changed);
                return eachrotate;
            }
            
            return eachrotate;
        }
        public void writer(string output, List<string> rotate)
        {
            string path2 = output;
            using (StreamWriter sw = new StreamWriter(path2))
            {
                sw.WriteLine("rotate plots = "+ rotate);
            }
        }
    }
}
