using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
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
            draw();
        }

        public void draw()
        {
            if (storage.first() == null)
                return;
            var it = storage.first();          
            while (it != null)
            {
                SolidBrush cr = new SolidBrush(it.Color);
                Pen br = new Pen(it.Border, it.BorderSize);
                if (it.BorderChange == false)
                    br = new Pen(Color.White, it.BorderSize);

                if (it.Shape == "Square")
                {
                    panel.CreateGraphics().FillRectangle(cr, new Rectangle(it.X - it.Radius,
                        it.Y - it.Radius, 2 * it.Radius, 2 * it.Radius));

                    if (it.BorderChange == true)
                    {
                        panel.CreateGraphics().DrawRectangle(br, new Rectangle(it.X - it.Radius - it.BorderSize / 2,
                            it.Y - it.Radius - it.BorderSize / 2, 2 * it.Radius + it.BorderSize / 2, 2 * it.Radius + it.BorderSize / 2));
                        it.BorderChange = false;
                    }
                }
                if (it.Shape == "Circle")
                {                 
                    panel.CreateGraphics().FillEllipse(cr, it.X - it.Radius,
                       it.Y - it.Radius, 2 * it.Radius, 2 * it.Radius);

                    if (it.BorderChange == true)
                        panel.CreateGraphics().DrawEllipse(br, it.X - it.Radius - it.BorderSize / 2,
                            it.Y - it.Radius - it.BorderSize / 2, 2 * it.Radius + it.BorderSize / 2, 2 * it.Radius + it.BorderSize / 2);
                }

                if (it.Shape == "Triangle")
                {
                    int border = 0;
                    if (it.BorderChange == true) border = it.BorderSize;

                    List<Point> line1 = new List<Point>();
                    List<Point> line2 = new List<Point>();
                    List<Point> line3 = new List<Point>();
                    line1.Add(new Point(it.X, it.Y - it.Radius - border));
                    line1.Add(new Point(it.X + it.Radius + border, it.Y + it.Radius / 2 + border / 2));
                    line2.Add(new Point(it.X, it.Y - it.Radius - border));
                    line2.Add(new Point(it.X - it.Radius - border, it.Y + it.Radius / 2 + border / 2));
                    line3.Add(new Point(it.X - it.Radius - border, it.Y + it.Radius / 2 + border / 2));
                    line3.Add(new Point(it.X + it.Radius + border, it.Y + it.Radius / 2 + border / 2));

                    GraphicsPath myPath = new GraphicsPath();
                    myPath.StartFigure();
                    myPath.AddLines(line1.ToArray());
                    myPath.AddLines(line2.ToArray());
                    myPath.AddLines(line3.ToArray());
                    myPath.CloseFigure();

                    panel.CreateGraphics().FillPath(cr, myPath);

                    if (it.BorderChange == true)
                        panel.CreateGraphics().DrawPath(br, myPath);
                    
                }                
                it = storage.next(it);
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
                        figure.Shape = storage.Status;
                        figure.Color = pbColor.BackColor;
                        figure.Border = pbBorder.BackColor;

                        if (storage.is_inside(e.X, e.Y) != null)
                        {
                            //if (storage.is_inside(e.X, e.Y).BorderChange == false)
                            storage.is_inside(e.X, e.Y).BorderChange = true;
                            //else storage.is_inside(e.X, e.Y).BorderChange = false;
                            storage.is_inside(e.X, e.Y).Border = pbBorder.BackColor;
                            storage.observers.Invoke(this, null);
                        }
                        else storage.add(figure);                    
                        break;
                    }
            }
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

            public Figure first()
            { 
                if (storage.Count != 0) 
                    return storage.First();
                return null;
            }
            
            public Figure next(Figure figure) 
            {
                bool check = false;
                foreach(Figure fig in storage)
                {
                    if (check == true) return fig;
                    if (figure == fig)
                        check = true;
                }
                return null; 
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
                                if (x0 > x1 && y0 > y1 && x0 < x3 && y0 < y3)
                                {        
                                    observers.Invoke(this, null);
                                    return figure;
                                }
                                break;
                            }
                        case "Triangle":
                            {
                                int x1 = figure.X;
                                int y1 = figure.Y - figure.Radius;
                                int x2 = figure.X + figure.Radius;
                                int y2 = figure.Y + figure.Radius / 2;
                                int x3 = figure.X - figure.Radius;
                                int y3 = figure.Y + figure.Radius / 2;
                                int alpha = (x1 - x0) * (y2 - y1) - (x2 - x1) * (y1 - y0);
                                int beta = (x2 - x0) * (y3 - y2) - (x3 - x2) * (y2 - y0);
                                int gamma = (x3 - x0) * (y1 - y3) - (x1 - x3) * (y3 - y0);
                                if (((alpha > 0) && (beta > 0) && (gamma > 0)) || ((alpha < 0) && (beta < 0) && (gamma < 0)))
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

            public void change_color(Color color)
            {
                foreach(Figure figure in storage)
                {
                    figure.Color = color;
                }
                observers.Invoke(this, null);
            }

            public EventHandler observers;
        }



        public class Figure
        {
            protected int x, y;
            public int X { set { x = value; } get { return x; } }
            public int Y { set { y = value; } get { return y; } }

            protected int radius = 30;
            public int Radius { set { radius = value; } get { return radius; } }

            protected Color color;
            public Color Color { set { color = value; } get { return color; } }

            protected Color border;
            public Color Border { set { border = value; } get { return border; } }

            protected int borderSize = 3;
            public int BorderSize { set { borderSize = value; } get { return borderSize; } }

            protected bool borderChange = false;
            public bool BorderChange { set { borderChange = value; } get { return borderChange; } }

            protected string shape;
            public string Shape { set { shape = value; } get { return shape; } }
        }

        private void pbColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            pbColor.BackColor = colorDialog1.Color;
            storage.change_color(pbColor.BackColor);
        }

        private void pbBorder_Click(object sender, EventArgs e)
        {
            if (colorDialog2.ShowDialog() == DialogResult.Cancel)
                return;
            pbBorder.BackColor = colorDialog2.Color;
        }

        private void cmbxShape_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbxShape.SelectedItem == cmbxShape.Items[0]) storage.Status = "Square";
            else if (cmbxShape.SelectedItem == cmbxShape.Items[1]) storage.Status = "Triangle";
            else if (cmbxShape.SelectedItem == cmbxShape.Items[2]) storage.Status = "Circle";
        }
    }
}
