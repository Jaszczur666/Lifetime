using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace Lifetime
{
    class Datapoint
    {
        public double t;
        public double y;
    }
    class DecayCurve
    {
        public List<Datapoint> DataPoints;
        public void LoadFromFile(String filename)
        {
            if (DataPoints != null)
            {
                DataPoints.Clear();
            }
            else
            {
                DataPoints = new List<Datapoint>();
            }
            double yv, tv;
            string[] lines = System.IO.File.ReadAllLines(@"d:\t35.CSV");

            foreach (string line in lines)
            {
                string[] values = line.Split(',');
                tv = Double.Parse(values[0], CultureInfo.InvariantCulture);
                yv = Double.Parse(values[1], CultureInfo.InvariantCulture);
                Datapoint Point = new Datapoint();
                Point.t = tv;
                Point.y = yv;

                DataPoints.Add(Point);
            }

        }
        public void Normalize()
        {
            double min, max;
            min = DataPoints[0].y;
            max = DataPoints[0].y;
            foreach (Datapoint point in DataPoints)
            {
                if (min > point.y) min = point.y;
                if (max < point.y) max = point.y;
            }
            Console.WriteLine(max+" "+min);
            foreach (Datapoint point in DataPoints)
            {
                point.y =Math.Abs((point.y - min) / (max-min));
            }
        }
    }
}
