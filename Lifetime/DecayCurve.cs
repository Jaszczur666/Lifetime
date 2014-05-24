using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        public void LoadFromFile(String filename){
            if( DataPoints !=null) DataPoints.Clear();
            double yv, tv;
            string[] lines = System.IO.File.ReadAllLines(@"G:dane\t30.csv");
            
            foreach (string line in lines)
            {
                string[] values=line.Split(',');
                tv = Double.Parse(values[0]);
                yv = Double.Parse(values[1]);
               Datapoint Point=new Datapoint();
               Point.t = tv;
               Point.y = yv;
                
                DataPoints.Add(Point);
            }

        }
    }
}
