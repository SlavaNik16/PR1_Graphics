using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrGr2_Nikolaev_Halle_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private double Xmin, Xmax, Step;
        private double[] x, y1, y2;
        private void button1_Click(object sender, EventArgs e)
        {
            Xmin = double.Parse(XminBox.Text);
            Xmax = double.Parse(XmaxBox.Text);
            Step = double.Parse(StapeBox.Text);
            CalcFunction();

            chart1.ChartAreas[0].AxisX.Minimum = Xmin;
            chart1.ChartAreas[0].AxisX.Maximum = Xmax;

            chart1.ChartAreas[0].AxisX.MajorGrid.Interval= Step;

            chart1.Series[0].Points.DataBindXY(x, y1);
            chart1.Series[1].Points.DataBindXY(x, y2);
        }

        private void CalcFunction()
        {
            int count = (int)Math.Ceiling((Xmax - Xmin) / Step) + 1;
            x= new double[count];
            y1 = new double[count];
            y2 = new double[count];
            for(int i = 0; i < count; i++)
            {
                x[i] = Xmin + Step * i;
                y1[i] = Math.Sin(x[i]);
                y2[i] = Math.Cos(x[i]);
            }
        }
    }
}
