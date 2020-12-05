using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace L6_Visual_Editor
{
    public partial class Form1 : Form
    {

        Storage storage;

        public Form1()
        {
            InitializeComponent();
            storage = new Storage();
            storage.observers += new EventHandler(UpdateFormModel);
        }

        public void UpdateFormModel(object sender, EventArgs e)
        {
            foreach (Figure figure in storage)
            {

            }
        }

        public void draw()
        {
            SolidBrush br = new SolidBrush(Color.Red);
            foreach (Figure figure in storage)
            {
                if (storage.Status == "Square")
                {
                    panel.CreateGraphics().FillRectangle(br, new Rectangle(figure.X - figure.Radius,
                        figure.Y - figure.Radius, 2 * figure.Radius, 2 * figure.Radius));
                }
                if (storage.Status == "Circle")
                {
                    panel.CreateGraphics().FillEllipse(br, figure.X - figure.Radius,
                       figure.Y - figure.Radius, 2 * figure.Radius, 2 * figure.Radius);
                }

                if (storage.Status == "Triangle")
                {
                    List<Point> line1 = new List<Point>();
                    List<Point> line2 = new List<Point>();
                    List<Point> line3 = new List<Point>();
                    line1.Add(new Point(figure.X, figure.Y - figure.Radius));
                    line1.Add(new Point(figure.X + figure.Radius, figure.Y + figure.Radius / 2));
                    line2.Add(new Point(figure.X, figure.Y - figure.Radius));
                    line2.Add(new Point(figure.X - figure.Radius, figure.Y + figure.Radius / 2));
                    line3.Add(new Point(figure.X - figure.Radius, figure.Y + figure.Radius / 2));
                    line3.Add(new Point(figure.X + figure.Radius, figure.Y + figure.Radius / 2));

                    GraphicsPath myPath = new GraphicsPath();
                    myPath.StartFigure();
                    myPath.AddLines(line1.ToArray());
                    myPath.AddLines(line2.ToArray());
                    myPath.AddLines(line3.ToArray());
                    myPath.CloseFigure();

                    panel.CreateGraphics().FillPath(br, myPath);
                }
            }
        }


        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    {
                        Figure figure = new Figure();
                        figure.X = e.X;
                        figure.Y = e.Y;
                        figure.Radius = 30;
                        figure.Shape = storage.Status;

                        if (storage.is_inside(e.X, e.Y) != null)
                        {
                            storage.is_inside(e.X, e.Y).Border = pbBorder.BackColor;
                        }
                        else storage.add(figure);
                        draw();
                        break;
                    }
            }
        }

        private void btnSquare_Click(object sender, EventArgs e)
        {
            storage.Status = "Square";
        }

        private void btnTriangle_Click(object sender, EventArgs e)
        {
            storage.Status = "Triangle";
        }

        private void btnCircle_Click(object sender, EventArgs e)
        {
            storage.Status = "Circle";
        }

        public class Storage
        {
            private LinkedList<Figure> storage = new LinkedList<Figure>();
            private string status;
            public string Status { set { status = value; } get { return status; } }

            public void add(Figure figure)
            {
                storage.AddLast(figure);
                observers.Invoke(this, null);
            }

            public Figure is_inside(int x0, int y0)
            {
                foreach (Figure figure in storage)
                {                  
                    switch (figure.Shape)
                    {
                        case "Square":
                            {
                                int x1 = figure.X - figure.Radius;
                                int y1 = figure.Y - figure.Radius;
                                int x3 = figure.X + figure.Radius;
                                int y3 = figure.Y + figure.Radius;
                                if (x0 > x1 && y0 > y1 && x0 > x3 && y0 > y3)
                                {
                   
                                    observers.Invoke(this, null);
                                    return figure;
                                }
                                break;
                            }
                        case "Triangle":
                            {
                                int x1 = figure.X - figure.Radius;
                                int y1 = figure.Y + figure.Radius / 2;
                                int x2 = figure.X;
                                int y2 = figure.Radius;
                                int x3 = figure.X + figure.Radius;
                                int y3 = figure.Y + figure.Radius / 2;
                                float alpha = ((y2 - y3) * (x0 - x3) + (x3 - x2) * (y0 - y3)) /
                                    ((y2 - y3) * (x1 - x3) + (x3 - x2) * (y1 - y3));
                                float beta = ((y3 - y1) * (x0 - x3) + (x1 - x3) * (y0 - y3)) /
                                    ((y2 - y3) * (x1 - x3) + (x3 - x2) * (y1 - y3));
                                float gamma = 1.0f - alpha - beta;
                                if (alpha > 0 && beta > 0 && gamma > 0)
                                {
                                    observers.Invoke(this, null);
                                    return figure;
                                }
                                break;
                            }
                        case "Circle":
                            {
                                int sum = Convert.ToInt32(Math.Pow(x0 - figure.X, 2) + Math.Pow(y0 - figure.Y, 2));
                                int rad = Convert.ToInt32(Math.Pow(figure.Radius, 2));
                                if (sum <= rad)
                                {
                                    observers.Invoke(this, null);
                                    return figure;
                                }
                                break;
                            }
                    }
                }
                return null;
            }



            public EventHandler observers;
        }



        public class Figure
        {
            protected int x, y;
            public int X { set { x = value; } get { return x; } }
            public int Y { set { y = value; } get { return y; } }

            private int radius;
            public int Radius { set { radius = value; } get { return radius; } }

            protected Color color;
            public Color Color { set { color = value; } get { return color; } }

            protected Color border;
            public Color Border { set { border = value; } get { return border; } }

            private string shape;
            public string Shape { set { shape = value; } get { return shape; } }
        }

        private void pbColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            pbColor.BackColor = colorDialog1.Color;
        }

        private void pbBorder_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            pbBorder.BackColor = colorDialog1.Color;
        }
    }
}
