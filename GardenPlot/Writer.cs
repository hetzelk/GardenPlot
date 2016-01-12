using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GardenPlot
{
    public class Writer
    {
        public void writer()
        {
            string path2 = "C:/Users/Keith Hetzel/Desktop/4. dev code camp/C#/GardenPlot/total_fencing.txt";
            using (StreamWriter sw = new StreamWriter(path2))
            {
                sw.WriteLine("total_fencing");
            }
        }
    }
}
