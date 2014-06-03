using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MathNet.Numerics.LinearAlgebra.Double;
namespace Lifetime
{
    
    public partial class Form1 : Form
    {
        static DecayCurve d;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String fake = @"g:\dane\t30.CSV";
            d = new DecayCurve();
            d.LoadFromFile(fake);
            d.Normalize();
            chart1.Series[0].Points.Clear();
            foreach (Datapoint point in d.DataPoints) {
                if ((point.y !=0) && (point.t>0))chart1.Series[0].Points.AddXY(1e6*point.t,Math.Log10(point.y));
            } 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double y0, A, tau;
            int i = 0;
            tau = Double.Parse(textBox1.Text);
            A = Double.Parse(textBox2.Text);
            y0 = Double.Parse(textBox3.Text);
            chart1.Series[1].Points.Clear();
            chart1.Series[2].Points.Clear();
            foreach (Datapoint point in d.DataPoints)
            {
                i++;
                if (i>1100) chart1.Series[1].Points.AddXY(1e6 * point.t,Math.Log10( y0 + A * Math.Exp(-1e6*point.t / tau)));
                if (i > 1100) chart1.Series[2].Points.AddXY(1e6 * point.t, Math.Log10(d.Residue(point.t, point.y, y0, tau, A)));
            }
            label1.Text = d.Chi2(y0, tau, A)+"";
        }
    }
}
