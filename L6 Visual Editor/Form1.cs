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

        public void UpdateFormModel(object sender, EventArgs e) // Обновление модели
        {
            draw();
        }

        public void draw() // Рисование объектов
        {
            Graphics g = CreateGraphics();
            g.Clear(BackColor);

            if (storage.first() == null)
                return;

            var it = storage.first();
            while (it != null)
            {
                SolidBrush cr = new SolidBrush(it.Color);
                Pen br = new Pen(it.Border, it.BorderSize);
                if (it.BorderSelection == true)
                    br = new Pen(it.Selection, it.BorderSize);

                if (it.Shape == "Square")
                {
                    CreateGraphics().FillRectangle(cr, new Rectangle(it.X - it.Radius,
                        it.Y - it.Radius, 2 * it.Radius, 2 * it.Radius));

                    CreateGraphics().DrawRectangle(br, new Rectangle(it.X - it.Radius - it.BorderSize / 2,
                        it.Y - it.Radius - it.BorderSize / 2, 2 * it.Radius + it.BorderSize / 2, 2 * it.Radius + it.BorderSize / 2));
                }
                if (it.Shape == "Circle")
                {
                    CreateGraphics().FillEllipse(cr, it.X - it.Radius,
                       it.Y - it.Radius, 2 * it.Radius, 2 * it.Radius);

                    CreateGraphics().DrawEllipse(br, it.X - it.Radius - it.BorderSize / 2,
                        it.Y - it.Radius - it.BorderSize / 2, 2 * it.Radius + it.BorderSize / 2, 2 * it.Radius + it.BorderSize / 2);
                }

                if (it.Shape == "Triangle")
                {
                    List<Point> line1 = new List<Point>();
                    List<Point> line2 = new List<Point>();
                    List<Point> line3 = new List<Point>();
                    line1.Add(new Point(it.X, it.Y - it.Radius - it.BorderSize));
                    line1.Add(new Point(it.X + it.Radius + it.BorderSize, it.Y + it.Radius / 2 + it.BorderSize / 2));
                    line2.Add(new Point(it.X, it.Y - it.Radius - it.BorderSize));
                    line2.Add(new Point(it.X - it.Radius - it.BorderSize, it.Y + it.Radius / 2 + it.BorderSize / 2));
                    line3.Add(new Point(it.X - it.Radius - it.BorderSize, it.Y + it.Radius / 2 + it.BorderSize / 2));
                    line3.Add(new Point(it.X + it.Radius + it.BorderSize, it.Y + it.Radius / 2 + it.BorderSize / 2));

                    GraphicsPath myPath = new GraphicsPath();
                    myPath.StartFigure();
                    myPath.AddLines(line1.ToArray());
                    myPath.AddLines(line2.ToArray());
                    myPath.AddLines(line3.ToArray());
                    myPath.CloseFigure();

                    CreateGraphics().FillPath(cr, myPath);
                    CreateGraphics().DrawPath(br, myPath);
                }
                it = storage.next(it);
            }
            
        }

        // Обработчик нажатия на клавишу мыши
        private void Form1_MouseDown(object sender, MouseEventArgs e) 
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    {
                        Figure figure = new Figure();
                        figure.X = e.X;
                        figure.Y = e.Y;
                        var size = (FWidth: ClientSize.Width, FHeight: ClientSize.Height, PHeight: panel.Height);
                        // Проверка на нахождение фигуры в пределах формы
                        if (storage.exception(e.X, e.Y, figure.Radius, size) == true) 
                        {
                            if (e.X - figure.Radius < 0) figure.X = figure.Radius;
                            if (e.X + figure.Radius > size.FWidth) figure.X = size.FWidth - figure.Radius;
                            if (e.Y - figure.Radius < size.PHeight) figure.Y = size.PHeight + figure.Radius;
                            if (e.Y + figure.Radius > size.FHeight) figure.Y = size.FHeight - figure.Radius;
                        }
                            
                        figure.Shape = storage.Status;
                        figure.Color = pbColor.BackColor;
                        figure.Border = Color.Black;
                        figure.Selection = pbSelection.BackColor;

                        // Проверка на попадание щелчка мыши в фигуру
                        if (storage.is_inside(e.X, e.Y) != null)
                        {
                            if (storage.is_inside(e.X, e.Y).BorderSelection == false)
                                storage.is_inside(e.X, e.Y).BorderSelection = true;
                            else storage.is_inside(e.X, e.Y).BorderSelection = false;
                            storage.observers.Invoke(this, null);
                        }
                        else storage.add(figure);
                        break;
                    }
            }
        }

        public class Storage // Класс-хранилище фигур
        {
            private LinkedList<Figure> storage = new LinkedList<Figure>();
            private string status;
            public string Status { set { status = value; } get { return status; } }
            // Добавление фигур в хранилище
            public void add(Figure figure)
            {
                storage.AddLast(figure);
                observers.Invoke(this, null);
            }
            // Удаление фигур из хранилища
            public void del(Color color) 
            {
                for (int i = 0; i < storage.Count; ++i)
                {
                    var item = storage.First;
                    while (item != null)
                    {
                        if (item.Value.BorderSelection == true)
                        {
                            storage.Remove(item);
                            i--;
                        }
                        item = item.Next;
                    }
                }
                observers.Invoke(this, null);
            }
            // Перемещение фигур
            public void move(int key, (int FWigth, int FHeight, int PHeight) size)
            {
                foreach(Figure figure in storage)
                {
                    if (figure.BorderSelection == true)
                    {
                        if (key == 87) figure.Y -= 5;
                        if (key == 83) figure.Y += 5;
                        if (key == 65) figure.X -= 5;
                        if (key == 68) figure.X += 5;
                    }
                    if(exception(figure.X, figure.Y, figure.Radius, size) == true)
                    {
                        if (key == 87) figure.Y += 5;
                        if (key == 83) figure.Y -= 5;
                        if (key == 65) figure.X += 5;
                        if (key == 68) figure.X -= 5;                        
                    }
                }
                observers.Invoke(this, null);
            }
            // Проверка на нахождение фигуры в пределах формы
            public bool exception(int x, int y, int rad, (int FWigth, int FHeight, int PHeight) size)
            {
                if (x - rad < 0 || y - rad < size.PHeight || x + rad > size.FWigth || y + rad > size.FHeight )
                    return true;
                return false;
            }
            // Изменение размера фигуры
            public void size(int state)
            {
                foreach (Figure figure in storage)
                {
                    if (figure.BorderSelection == true)
                    {
                        if (state == 187) figure.Radius += 3;
                        if (state == 189) figure.Radius -= 3;
                    }
                }
                observers.Invoke(this, null);
                 
            }
            // Получение первого элемента хранилища
            public Figure first()
            {
                if (storage.Count != 0)
                    return storage.First();
                return null;
            }
            // Получение следующего элемента хранилища
            public Figure next(Figure figure)
            {
                bool check = false;
                foreach (Figure fig in storage)
                {
                    if (check == true) return fig;
                    if (figure == fig)
                        check = true;
                }
                return null;
            }
            // Проверка на выделенность фигуры
            public bool is_selected()
            {
                foreach(Figure figure in storage)
                {
                    if (figure.BorderSelection == true)
                        return true;
                }
                return false;
            }
            // Проверка на попадание щелчка мыши в фигуру
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
                                    return figure;
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
                                    return figure;
                                break;
                            }
                        case "Circle":
                            {
                                int sum = Convert.ToInt32(Math.Pow(x0 - figure.X, 2) + Math.Pow(y0 - figure.Y, 2));
                                int rad = Convert.ToInt32(Math.Pow(figure.Radius, 2));
                                if (sum <= rad)
                                    return figure;
                                break;
                            }
                    }

                }
                return null;
            }
            // Изменение цвета фигур
            public void change_color(Color color)
            {
                foreach (Figure figure in storage)
                    figure.Color = color;
                observers.Invoke(this, null);
            }
            // Изменение цвета выделения фигур
            public void change_selection(Color color)
            {
                foreach (Figure figure in storage)
                    figure.Selection = color;
                observers.Invoke(this, null);
            }
            // Удаление всех объектов из хранилища
            public void remove_all() { storage.Clear(); }
            // Вызов обновления формы
            public EventHandler observers;
        }
        // Класс фигур
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

            protected Color selection;
            public Color Selection { set { selection = value; } get { return selection; } }

            protected int borderSize = 3;
            public int BorderSize { set { borderSize = value; } get { return borderSize; } }

            protected bool borderSelection = false;
            public bool BorderSelection { set { borderSelection = value; } get { return borderSelection; } }

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

        private void cmbxShape_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (cmbxShape.SelectedItem == cmbxShape.Items[0]) storage.Status = "Square";
            else if (cmbxShape.SelectedItem == cmbxShape.Items[1]) storage.Status = "Triangle";
            else if (cmbxShape.SelectedItem == cmbxShape.Items[2]) storage.Status = "Circle";
            panel.Focus();           
        }

        private void pbSelection_Click(object sender, EventArgs e)
        {
            if (colorDialog3.ShowDialog() == DialogResult.Cancel)
                return;
            pbSelection.BackColor = colorDialog3.Color;
            storage.change_selection(pbSelection.BackColor);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Graphics g = CreateGraphics();
            g.Clear(BackColor);
            storage.remove_all();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            storage.del(pbSelection.BackColor);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (storage.is_selected() == true && (e.KeyCode == Keys.W || e.KeyCode == Keys.S ||
                e.KeyCode == Keys.A || e.KeyCode == Keys.D))
            {              
                var size = (FWidth: ClientSize.Width, FHeight: ClientSize.Height, PHeight: panel.Height);               
                storage.move((int)e.KeyCode, size);
            }
            if (storage.is_selected() == true && e.KeyCode == Keys.Oemplus)
                storage.size((int)e.KeyCode);
            if (storage.is_selected() == true && e.KeyCode == Keys.OemMinus)
                storage.size((int)e.KeyCode);
        }
    }
}
