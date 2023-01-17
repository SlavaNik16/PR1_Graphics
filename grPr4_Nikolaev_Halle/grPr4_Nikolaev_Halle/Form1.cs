using System.Windows.Forms;

namespace grPr4_Nikolaev_Halle
{
        public partial class Form1 : Form
        {
            public Graphics g; //�������
            public Bitmap map; //������
            public Pen p; //�����
            public double angle = Math.PI / 2; //���� �������� �� 90 ��������
            public double ang1 = Math.PI / 4;  //���� �������� �� 45 ��������
            public double ang2 = Math.PI / 6;  //���� �������� �� 30 ��������


            public Form1()
            {
                InitializeComponent();
            }

            private void Form1_Load(object sender, EventArgs e)
            {
                map = new Bitmap(pictureBox2.Width, pictureBox2.Height);//���������� ������
                g = Graphics.FromImage(map); //���������� �������
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;//�������� �����������
                p = new Pen(Color.Black);   //������� �����

                //����� ����������� ������� ��������� ������
                DrawTree(300, 450, 200, angle);

            //��������� �������� �� ������� �� picturebox	
                pictureBox2.BackgroundImage = map;
            }

            //����������� ������� ��������� ������
            //x � y - ���������� ������������ �������
            //a - ��������, ������� ��������� ���������� �������� � ��������
            //angle - ���� �������� �� ������ ��������
            public int DrawTree(double x, double y, double a, double angle)
            {

                if (a > 2)
                {
                    a *= 0.7; //������ �������� a

                    //������� ���������� ��� �������-�������
                    double xnew = Math.Round(x + a * Math.Cos(angle)),
                           ynew = Math.Round(y - a * Math.Sin(angle));

                    //������ ����� ����� ���������
                    g.DrawLine(p, (float)x, (float)y, (float)xnew, (float)ynew);

                    //��������������� ����������
                    x = xnew;
                    y = ynew;

                    //�������� ����������� ������� ��� ������ � ������� �������
                    DrawTree(x, y, a, angle + ang1);
                    DrawTree(x, y, a, angle - ang2);
                }
                return 0;
            }

        }
}