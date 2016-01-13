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
        List<int> listx;
        List<int> listy;
        List<int> listw;
        List<int> listh;

        public MinFence()
        {
            listx = new List<int>();
            listy = new List<int>();
            listw = new List<int>();
            listh = new List<int>();
        }

        public int GetTotalFence(Dictionary<string, List<int>> dictionaryplots)
        {
            /*int firsthalf = 1;// w * 2
            int secondhalf = 1;//h * 2
            int totalcurrentfence = firsthalf + secondhalf;
            Console.WriteLine(totalcurrentfence);
            return totalcurrentfence;*/
            GetIndividuals(dictionaryplots);
            return 10;
        }

        public void GetIndividuals(Dictionary<string, List<int>> dictionaryplots)
        {
            foreach(KeyValuePair<string, List<int>> pair in dictionaryplots)
            {
                listx.Add(pair.Value[0]);
                listy.Add(pair.Value[1]);
                listw.Add(pair.Value[2]);
                listh.Add(pair.Value[3]);
            }

            GetParameters();
            Console.Read();
        }

        public List<int> GetParameters()
        {
            List<int> parameters = new List<int>();

            Console.WriteLine(GetLargeX());
            Console.WriteLine(GetLargeY());
            Console.WriteLine(GetSmallX());
            Console.WriteLine(GetSmallY());
            return parameters;
        }

        public int GetLargeX()
        {
            int maxx = int.MinValue;
            foreach (int number in listx)
            {
                if (number > maxx)
                {
                    maxx = number;
                }
            }
            return maxx;
        }

        public int GetLargeY()
        {
            int maxy = int.MinValue;
            foreach (int number in listy)
            {
                if (number > maxy)
                {
                    maxy = number;
                }
            }
            return maxy;
        }

        public int GetSmallX()
        {
            int smallx = int.MaxValue;
            foreach (int number in listx)
            {
                if (number < smallx)
                {
                    smallx = number;
                }
            }
            return smallx;
        }

        public int GetSmallY()
        {
            int smally = int.MaxValue;
            foreach (int number in listy)
            {
                if (number < smally)
                {
                    smally = number;
                }
            }
            return smally;
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
