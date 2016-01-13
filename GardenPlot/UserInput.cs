using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using GardenPlot;

namespace GardenPlot
{
    public class UserInput
    {
        Reader Reader;
        Dictionary<string, List<int>> plotsDictionary;
        PlotOverlap PlotOverlap;
        TotalFence TotalFence;
        MinFence MinFence;
        TotalFertilizer TotalFertilizer;
        Rotate Rotate;

        public UserInput()
        {
            Reader = new Reader();
            PlotOverlap = new PlotOverlap();
            TotalFence = new TotalFence();
            MinFence = new MinFence();
            TotalFertilizer = new TotalFertilizer();
            Rotate = new Rotate();
        }

        public void Input(string[] args)
        {
            plotsDictionary = Reader.reader(args[1]);
            if (args[0] == "1")
            {
                List<string> total = PlotOverlap.CheckAllOverlaps(plotsDictionary);
                PlotOverlap.Writer(args[2], total);
            }

            if (args[0] == "2")
            {
                int total = TotalFence.GetTotalFence(plotsDictionary);
                TotalFence.Writer(args[2], total);
            }

            if (args[0] == "3")
            {
                int total = MinFence.GetMinimumFence(plotsDictionary);
                MinFence.Writer(args[2], total);
            }

            if (args[0] == "4")
            {
                float totalFertilizer = TotalFertilizer.GetTotalFertilizer(plotsDictionary);
                TotalFertilizer.Writer(args[2], totalFertilizer);
            }

            if (args[0] == "5")
            {
                string rotate = args[2];
                int rotatenumber = Convert.ToInt32(rotate);
                Dictionary<string, List<int>> rotateit = Rotate.RotateAll(rotate, plotsDictionary);
                Rotate.Writer(args[3], rotateit);
            }
        }
    }
}
