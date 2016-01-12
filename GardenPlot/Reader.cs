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
            string path1 = input;
            int counter = 0;
            string line;
            string countkey;

            if (File.Exists(path1))
            {
                using (StreamReader file = new StreamReader(path1))
                {
                    while ((line = file.ReadLine()) != null)
                    {
                        List<int> coordinateslist = new List<int>();
                        string[] letters = line.Split(',');
                        foreach(string c in letters)
                        {
                            coordinateslist.Add(Convert.ToInt32(c));
                        }
                        countkey = String.Format("{0}", counter);
                        plots.Add(countkey, coordinateslist);
                        counter++;
                    }
                    file.Close();
                    return plots;
                }
            }
            else
            {
                Console.WriteLine("This File doesn't exist.");
                return plots;
            }
        }
    }
}
