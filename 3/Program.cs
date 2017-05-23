using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// «Фигура», «Точка», «Окружность» «Круг закрашенный», «Эллипс», «Конус», «Усеченный конус» 
        /// • перемещают фигуру по плоскости (на заданное расстояние или в нужную позицию);
        //• масштабируют фигуру;
        //• вычисляют и возвращают площадь фигуры, периметр;
        //• возвращают строку символов, отражающую имя класса и состояние объекта(его основные характеристики);
        //• рисуют фигуру в консоли или на форме(для объемных фигур достаточно проекции, например, изометрической или диметрической);
        //	Определите в ваших классах свойства и индексаторы (хотя бы в некоторых  классах ).
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            Form1 Frm = new Form1();
        }
    }

    public abstract class Figure
    {
        public virtual float X { get; set; }
        public virtual float Y { get; set; }
        public virtual float R { get; set; }
        public Figure(float x, float y, float r)
        {
            X = x;
            Y = y;
            R = r;
        }
        public virtual void PlusHeight(float h)
        {
            Y += h;
        }
        public virtual void PlusWidth(float w)
        {
            X += w;
        }
        public virtual void MoveTo(float x, float y)
        {
            X = x;
            Y = y;
        }
        public virtual void Scale(float size)
        {
            R *= size;
            X *= size;
            Y *= size;
        }
        public virtual float Square()
        {
            return R * R * (float)Math.PI;
        }
        public virtual float Perimeter()
        {
            return 2 * R * (float)Math.PI;
        }

        public override string ToString()
        {
            return $"Тип фигуры: {this.GetType()} Координаты: {X}, {Y}, Радиус: {R} ";
        }
        public abstract Bitmap Draw(PictureBox box, Pen pen, Bitmap btm, Graphics g);
        
    }
    public class Point : Figure
    {
        public Point(float x, float y) : base(x, y, 0)
        {
        }
        public override Bitmap Draw(PictureBox box, Pen pen, Bitmap btm, Graphics g)
        {
            g.DrawEllipse(pen, X, Y, 2, 2);
            return btm;
        }
        public override string ToString()
        {
            return $"Тип фигуры: {this.GetType()} Координаты: {X}, {Y}";
        }
    }
    public class Circle : Figure
    {
        public Circle(float x, float y, float r) : base(x, y, r)
        {
        }
        public override Bitmap Draw(PictureBox box, Pen pen, Bitmap btm, Graphics g)
        {
            g.DrawEllipse(pen, X - R, Y - R, R * 2, R*2);
            return btm;
        }

    }
    public class FilledCircle : Figure
    {
        public Color Col { get;set;}
        public FilledCircle(float x, float y, float r, Color c) : base(x, y, r)
        {
            Col = c;
        }

        public override Bitmap Draw(PictureBox box, Pen pen, Bitmap btm, Graphics g)
        {
            throw new NotImplementedException();
        }

        public Bitmap Draw(PictureBox box, Bitmap btm, Graphics g)
        {
            g.FillEllipse(new SolidBrush(Col), X - R, Y - R, R * 2, R * 2);
            return btm;
        }
        public override string ToString()
        {
            return base.ToString() + $"Цвет {Col}";
        }
    }
    public class Elipse : Figure
    {
        public float R2 { get; set; }
        public Elipse(float x, float y, float r, float r2) : base(x, y, r)
        {
            R2 = r2;
        }
        public override Bitmap Draw(PictureBox box, Pen pen, Bitmap btm, Graphics g)
        {

            g.DrawEllipse(pen, X - R, Y - R2, R * 2, R2 * 2);
            return btm;
        }
        public override void Scale(float size)
        {
            base.Scale(size);
            R2 *= size;
        }
        public override float Perimeter()
        {
            return 4 * (((float)Math.PI * R * R2 + (R - R2)*(R-R2)) / (R + R2));
        }
        public override float Square()
        {
            return (float)Math.PI * R * R2;
        }
        public override string ToString()
        {
            return $"Тип фигуры: {this.GetType()} ,Координаты: {X}, {Y}, Радиус ширины: {R}, Радиус высоты: {R2}";
        }

    }
    public class FilledElipse : Elipse
    {
        public Color Col { get; set; }
        public FilledElipse(float x, float y, float r, float r2, Color c) : base(x, y, r,r2)
        {
            Col = c;
        }
        public Bitmap Draw(PictureBox box, Bitmap btm, Graphics g)
        {
            g.FillEllipse(new SolidBrush(Col), X - R, Y - R2, R * 2, R2 * 2);
            return btm;
        }
    }
    public class Cone : Figure
    {
        public float H { get;set;}
        public Cone(float x, float y, float h, float r) : base(x, y, r)
        {
            H = h;
        }
        public override void Scale(float size)
        {
            base.Scale(size);
            H *= size;
        }
        public override float Perimeter()
        {
            return (float)Math.PI*R*(R + (float)Math.Sqrt(R * R + H * H));
        }
        public override float Square()
        {
            return ( (float)1 / 3) * (float)Math.PI * R * R * H;
        }
        public override string ToString()
        {
            return base.ToString() + $" Высота: {H}";
        }
        public override Bitmap Draw(PictureBox box, Pen pen, Bitmap btm, Graphics g)
        {
            g.DrawEllipse(pen, X - R, Y - (R / 2), R * 2, R);
            g.DrawLine(pen, X, Y - H, X - R, Y);
            g.DrawLine(pen, X, Y - H, X + R, Y);
            return btm;
        }
    }
    public class TruncatedCone : Cone
    {
        public float Rh {get;set;}

        public TruncatedCone(float x, float y, float h, float r, float rh) : base(x, y, h,r)
        {
            Rh = rh;
        }
        public override void Scale(float size)
        {
            base.Scale(size);
            Rh *= size;
        }
        public  override Bitmap Draw(PictureBox box, Pen pen, Bitmap btm , Graphics g)
        {
            g.DrawEllipse(pen, X - R, Y - (R / 2), R * 2, R);
            g.DrawEllipse(pen, X - Rh, Y - H - (Rh / 2), Rh * 2, Rh);
            g.DrawLine(pen, X-Rh, Y - H, X - R, Y);
            g.DrawLine(pen, X+Rh, Y - H, X + R, Y);
            return btm;
        }
        public override float Perimeter()
        {
           return (float)Math.PI*(float) Math.Sqrt(H * H + (R - Rh) * (R - Rh))*(R + Rh) + (float)Math.PI*R*R + (float)Math.PI*Rh*Rh;
        }
        public override float Square()
        {
            return (float)1 / 3 * (float)Math.PI * H * (Rh * Rh + Rh * R + R * R);
        }
        public override string ToString()
        {
            return base.ToString() + $" Радиус малый: {Rh}";
        }
    }
}
