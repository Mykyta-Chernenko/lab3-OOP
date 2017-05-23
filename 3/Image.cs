using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3
{
   public class Image
    {
        public List<Figure> list;
        public Image()
        {
            list = new List<Figure>();
        }
        public void Add(Figure fg)
        {
            list.Add(fg);
        }
        public void DeleteAll()
        {
            list.Clear();
        }
        public float Square()
        {
            float sum = 0;
            foreach(var x in list){
                sum += x.Square();
            }
            return sum;
        }
        public float Perimeter()
        {
            float sum = 0;
            foreach (var x in list)
            {
                sum += x.Perimeter();
            }
            return sum;
        }
        public void PlusHeight(float y)
        {
            foreach (var x in list)
            {
                x.PlusHeight(y);
            }
        }
        public void PlusWidth(float x)
        {
            foreach (var y in list)
            {
                y.PlusWidth(x);
            }
        }
        public void MoveTo(float x, float y)
        {
            foreach( var k in list)
            {
                k.MoveTo(x, y);
            }
        }
        public void Scale (float size)
        {
            foreach (var x in list)
            {
                x.Scale(size);
            }
        }
        public override string ToString()
        {
            string str = "";
            foreach (var x in list)
            {
                str += x.ToString();
                str += "\n";
            }
            return str;
        }
        public void Unite (Image other)
        {
            foreach(var x in other.list)
            {
                list.Add(x);
            }
        }
        public void Draw()
        {
            foreach (var x in list)
            {
                if (x is FilledCircle) {
                    var tmp = (FilledCircle)x;
                    Form1.pictureBox.Image = tmp.Draw(Form1.pictureBox, Form1.bmp, Form1.g);
                }                    
                else
                    Form1.pictureBox.Image = x.Draw(Form1.pictureBox, new Pen(Color.Red), Form1.bmp, Form1.g);
                
            }
        }

        internal float IntersectedSquare()
        {
            List<Figure> temp = new List<Figure>();
            foreach(var fig in list)
            {
                if(fig is Circle)
                {
                    FilledCircle t = new FilledCircle(fig.X, fig.Y, fig.R, Color.Black);
                    temp.Add(t);
                }
                else if(fig is Elipse)
                {
                    Elipse figel = (Elipse)fig;
                    FilledElipse t = new FilledElipse(figel.X, figel.Y, figel.R, figel.R2,Color.Black);
                    temp.Add(t);
                }
                else if(fig is FilledCircle)
                {
                    FilledCircle filled = (FilledCircle)fig;
                    FilledCircle t = new FilledCircle(filled.X, filled.Y, filled.R, Color.Black);
                    temp.Add(t);
                }
                else
                {
                    temp.Add(fig);
                }

            }
            Form1.g.Clear(Form1.pictureBox.BackColor);
            foreach (var x in temp)
            {
                if (x is FilledCircle)
                {
                    var tmp = (FilledCircle)x;
                    Form1.pictureBox.Image = tmp.Draw(Form1.pictureBox, Form1.bmp, Form1.g);
                }
                else if(x is FilledElipse)
                {
                    var tmp = (FilledElipse)x;
                    Form1.pictureBox.Image = tmp.Draw(Form1.pictureBox, Form1.bmp, Form1.g);
                }
                else
                    Form1.pictureBox.Image = x.Draw(Form1.pictureBox, new Pen(Color.Red), Form1.bmp, Form1.g);
            }
            float square = 0;
            for (int x = 0; x < Form1.pictureBox.Image.Width; x++)
            {
                for (int y = 0; y < Form1.pictureBox.Image.Height; y++)
                {
                    var pix = ((Bitmap)Form1.pictureBox.Image).GetPixel(x, y);
                    if (pix.R == 0 || pix.G == 0 || pix.B == 0) square++;
                }
            }
            Form1.g.Clear(Form1.pictureBox.BackColor);
            this.Draw();
            return square;
        }
    }
}
