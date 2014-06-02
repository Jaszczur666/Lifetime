using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace Lifetime
{
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String fake="";
            DecayCurve d = new DecayCurve();
            d.LoadFromFile(fake);
            d.Normalize();
            chart1.Series[0].Points.Clear();
            foreach (Datapoint point in d.DataPoints) {
                if (point.y !=0)chart1.Series[0].Points.AddXY(1e6*point.t,Math.Log10(point.y));
            } 
        }
    }
}
