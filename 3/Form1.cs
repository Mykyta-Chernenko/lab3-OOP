using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3
{
    public partial class Form1 : Form
    {
        public static Bitmap bmp;
        public static Graphics g;
        public static Image images;
        public static PictureBox pictureBox;

        public Form1()
        {
            InitializeComponent();       
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bmp);
            images = new Image();
            pictureBox = pictureBox1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            images.Add(new Circle(200, 150, 20));
            images.Add(new Point(100, 100));
            images.Add(new FilledCircle(200, 150, 20));
            images.Add(new Elipse(200, 150, 20, 30));
            images.Add(new Cone(100, 100, 50, 50));
            images.Add(new TruncatedCone(100, 100, 50, 80, 50));
            images.Draw();
        }
        private void DrawPoint(float x, float y)
        {
            Point p = new Point(x,y);
            pictureBox1.Image = p.Draw(pictureBox1, new Pen(Color.Red), bmp, g);
        }
        public void DrawCircle(float x, float y, float r)
        {
            Circle p = new Circle(x, y, r);
            pictureBox1.Image = p.Draw(pictureBox1, new Pen(Color.Red), bmp, g);
        }
        public void DrawFilledCircle(float x, float y, float r)
        {
            FilledCircle p = new FilledCircle(x, y, r);
            pictureBox1.Image = p.Draw(pictureBox1, new SolidBrush(Color.FromArgb(255, 255, 0, 0)), bmp, g);
        }
        public void DrawElipse(float x, float y, float r1, float r2)
        {
            Elipse p = new Elipse(x, y, r1, r2);
            pictureBox1.Image = p.Draw(pictureBox1, new Pen(Color.Red), bmp, g);
        }
        public void DrawCone(float x, float y, float h, float r)
        {
            Cone p = new Cone(x,y,h,r);
            pictureBox1.Image = p.Draw(pictureBox1, new Pen(Color.Red), bmp, g);
        }
        public void DrawTruncatedCone(float x, float y, float h, float r, float rh)
        {
            TruncatedCone p = new TruncatedCone(x, y, h, r,rh);    
            pictureBox1.Image = p.Draw(pictureBox1, new Pen(Color.Red), bmp, g);
        }


    }
}
