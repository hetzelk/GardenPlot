using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GardenPlot
{
    public class Reader
    {
        public Dictionary<string, List<int>> reader(string input)
        {
            Dictionary<string, List<int>> plots = new Dictionary<string, List<int>>();
            int counter = 0;
            string line;
            string countKey;

            if (File.Exists(input))
            {
                using (StreamReader file = new StreamReader(input))
                {
                    while ((line = file.ReadLine()) != null)
                    {
                        List<int> coordinatesList = new List<int>();
                        string[] letters = line.Split(',');
                        foreach(string c in letters)
                        {
                            coordinatesList.Add(Convert.ToInt32(c));
                        }
                        countKey = String.Format("{0}", counter);
                        plots.Add(countKey, coordinatesList);
                        counter++;
                    }
                    file.Close();
                    return plots;
                }
            }
            else
            {
                return plots;
            }
        }
    }
}
