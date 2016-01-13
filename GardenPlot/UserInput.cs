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
        Reader reader;
        Dictionary<string, List<int>> plotsdictionary;
        PlotOverlap PlotOverlap;
        TotalFence TotalFence;
        MinFence MinFence;
        TotalFertilizer TotalFertilizer;
        Rotate Rotate;

        public UserInput()
        {
            reader = new Reader();
            PlotOverlap = new PlotOverlap();
            TotalFence = new TotalFence();
            MinFence = new MinFence();
            TotalFertilizer = new TotalFertilizer();
            Rotate = new Rotate();
        }

        public void Input(string[] args)
        {
            plotsdictionary = reader.reader(args[1]);
            if (args[0] == "1")
            {
                List<string> total = PlotOverlap.CheckAllOverlaps(plotsdictionary);
                PlotOverlap.Writer(args[2], total);
            }

            if (args[0] == "2")
            {
                int total = TotalFence.GetTotalFence(plotsdictionary);
                TotalFence.Writer(args[2], total);
            }

            if (args[0] == "3")
            {
                int total = MinFence.GetMinimumFence(plotsdictionary);
                MinFence.Writer(args[2], total);
            }

            if (args[0] == "4")
            {
                float totalfertilizer = TotalFertilizer.GetTotalFertilizer(plotsdictionary);
                TotalFertilizer.Writer(args[2], totalfertilizer);
            }

            if (args[0] == "5")
            {
                string rotate = args[2];
                int rotatenumber = Convert.ToInt32(rotate);
                Dictionary<string, List<int>> rotateit = Rotate.RotateAll(rotate, plotsdictionary);
                Rotate.Writer(args[3], rotateit);
            }
        }
    }
}
