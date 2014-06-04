using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using MathNet.Numerics.LinearAlgebra.Double;


namespace Lifetime
{
    class Datapoint
    {
        public double t;
        public double y;
    }
    class DecayCurve
    {
        public double Residue(double x, double y, double y0, double tau, double A) {
            return y-(y0+A*Math.Exp(-1e6*x/tau));
        }
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
            string[] lines = System.IO.File.ReadAllLines(filename);

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
            int i = 0;
            foreach (Datapoint point in DataPoints)
            {
                i++;
                if (min > point.y && (i>1100)) min = point.y;
                if ((max < point.y)&&(i>1100)) max = point.y;
            }
            Console.WriteLine(max+" "+min);
            double toffset;
            toffset = DataPoints[1100].t;
            foreach (Datapoint point in DataPoints)
            {
                point.t -= toffset;
                point.y =Math.Abs((point.y - min) / (max-min));
            }
        }
        public double Chi2(double y0,double tau, double A) {
            double value;
            value = 0;
            int i = 0;
            foreach (Datapoint point in DataPoints) {
                i++;
                if (i>1100) value += Math.Pow(Residue(point.t, point.y, y0, tau, A),2);
            }
            return value;
        
        }
        public DenseMatrix Hessian() { 
            DenseMatrix Value;
            Value = new DenseMatrix(3);
            return Value;
        }
    }
}
