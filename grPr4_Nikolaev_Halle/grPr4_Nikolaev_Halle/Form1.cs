using System.Windows.Forms;

namespace grPr4_Nikolaev_Halle
{
        public partial class Form1 : Form
        {
            public Graphics g; //Графика
            public Bitmap map; //Битмап
            public Pen p; //Ручка
            public double angle = Math.PI / 2; //Угол поворота на 90 градусов
            public double ang1 = Math.PI / 4;  //Угол поворота на 45 градусов
            public double ang2 = Math.PI / 6;  //Угол поворота на 30 градусов


            public Form1()
            {
                InitializeComponent();
            }

            private void Form1_Load(object sender, EventArgs e)
            {
                map = new Bitmap(pictureBox2.Width, pictureBox2.Height);//Подключаем Битмап
                g = Graphics.FromImage(map); //Подключаем графику
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;//Включаем сглаживание
                p = new Pen(Color.Black);   //Зеленая ручка

                //Вызов рекурсивной функции отрисовки дерева
                DrawTree(300, 450, 200, angle);

            //Переносим картинку из битмапа на picturebox	
                pictureBox2.BackgroundImage = map;
            }

            //Рекурсивная функция отрисовки дерева
            //x и y - координаты родительской вершины
            //a - параметр, который фиксирует количество итераций в рекурсии
            //angle - угол поворота на каждой итерации
            public int DrawTree(double x, double y, double a, double angle)
            {

                if (a > 2)
                {
                    a *= 0.7; //Меняем параметр a

                    //Считаем координаты для вершины-ребенка
                    double xnew = Math.Round(x + a * Math.Cos(angle)),
                           ynew = Math.Round(y - a * Math.Sin(angle));

                    //рисуем линию между вершинами
                    g.DrawLine(p, (float)x, (float)y, (float)xnew, (float)ynew);

                    //Переприсваеваем координаты
                    x = xnew;
                    y = ynew;

                    //Вызываем рекурсивную функцию для левого и правого ребенка
                    DrawTree(x, y, a, angle + ang1);
                    DrawTree(x, y, a, angle - ang2);
                }
                return 0;
            }

        }
}