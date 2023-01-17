using System.Security.Cryptography.X509Certificates;

namespace prGr_3_Nikolaev_Halle
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(bitmap);
            
            PointF PF = new PointF(bitmap.Width / 2, bitmap.Height / 2);

            int minX = -10, maxX = 10;

            float stepX = bitmap.Width / Math.Abs(maxX - minX);
            float stepY = bitmap.Height/ Math.Abs(maxX - minX);
            
            DrawAxis(g, Color.Black, PF, bitmap.Size,minX, maxX, stepX, stepY);

            List<PointF> parabolic = CreateParabolic(1, 0, -5, minX, maxX, 0.01f);
            List<PointF> sinus = CreateSinus(5, 5, minX, maxX, 0.001f);
            List<PointF> hyper = CreateHyper(5, minX, maxX, 0.001f);

            DrawCurve(g, Brushes.Magenta, parabolic, PF, stepX, stepY);
            DrawCurve(g, Brushes.Cyan, sinus, PF, stepX, stepY);
            DrawCurve(g, Brushes.CornflowerBlue, hyper, PF, stepX, stepY);

            pictureBox1.Image = bitmap;
        }
        private void DrawAxis(Graphics g, Color color, PointF pf, Size size, float min, float max, float stepX, float stepY)
        {
            Pen pen = new Pen(color, 2);
            g.DrawLine(pen, new PointF(0, size.Height / 2.0f), new PointF(size.Width, size.Height / 2.0f));
            g.DrawLine(pen, new PointF(size.Width / 2.0f, 0), new PointF(size.Width / 2.0f, size.Height));

            for (float x = min; x < max; x+=0.5f)
            {
                float gx = x * stepX + size.Width / 2.0f;
                float gy = x * stepY + size.Height / 2.0f;
                g.DrawLine(pen, new PointF(gx, (size.Height / 2.0f) + 2), new PointF(gx, (size.Height / 2.0f) - 2.0f));
                g.DrawLine(pen, new PointF(size.Width / 2.0f - 2.0f, gy), new PointF(size.Width / 2.0f + 2.0f, gy));

            }

        }
        private List<PointF> CreateParabolic(float a, float b, float c, float min, float max, float step)
        {
            return CalcFunc(new Func<float, float>((x) => { return (x * x) * a + (b * x) + c; }), min, max, step);
        }

        private List<PointF> CreateSinus(float a, float b, float min, float max, float step)
        {
            return CalcFunc(new Func<float, float>((x) => { return (float)(a * Math.Sin(b * x)); }), min, max, step);
        }

        private List<PointF> CreateHyper(float k, float min, float max, float step)
        {
            return CalcFunc(new Func<float, float>((x) => { return (float)(k/x); }), min, max, step);
        }
        private List<PointF> CalcFunc(Func<float,float> func, float min, float max, float step)
        {
            List<PointF> result = new List<PointF>();
            for(float i = min; i < max; i += step)
            {
                result.Add(new PointF(i, func(i)));
            }
            return result;
        }
        private void DrawCurve(Graphics g, Brush brush, List<PointF> pf, PointF center,  float stepX, float stepY)
        {
            pf.ForEach(new Action<PointF>((o) =>
            {
                g.FillEllipse(brush, new RectangleF(new PointF((o.X * stepX + center.X) - 1, (o.Y * stepY + center.Y) - 1), new SizeF(2, 2)));
            }));
        }


    }
}