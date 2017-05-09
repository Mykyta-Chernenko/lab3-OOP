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
                    Form1.pictureBox.Image = tmp.Draw(Form1.pictureBox, new SolidBrush(Color.FromArgb(255, 255, 0, 0)), Form1.bmp, Form1.g);
                }                    
                else
                    Form1.pictureBox.Image = x.Draw(Form1.pictureBox, new Pen(Color.Red), Form1.bmp, Form1.g);
            }
        }

    }
}
