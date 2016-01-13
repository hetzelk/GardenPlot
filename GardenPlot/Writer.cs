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
        public void writer(string path2)
        {
            using (StreamWriter sw = new StreamWriter(path2))
            {
                sw.WriteLine("total_fencing");
            }
        }
    }
}
