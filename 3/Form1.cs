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
        public static ColorDialog color;

        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bmp);
            images = new Image();
            pictureBox = pictureBox1;
            color = new ColorDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //images.Add(new Circle(200, 150, 20));
            //images.Add(new Point(100, 100));
            //images.Add(new FilledCircle(200, 150, 20, colorDialog1.Color));
            //images.Add(new Elipse(200, 150, 20, 30));
            //images.Add(new Cone(100, 100, 50, 50));
            //images.Add(new TruncatedCone(100, 100, 50, 80, 50));
            //images.Draw();
            //MessageBox.Show("" + images.Square());
            //MessageBox.Show("" + images.Perimeter());
            //MessageBox.Show("" + images.ToString());
        }
        private void DrawPoint(float x, float y)
        {
            Point p = new Point(x, y);
            pictureBox1.Image = p.Draw(pictureBox1, new Pen(Color.Red), bmp, g);
        }
        public void DrawCircle(float x, float y, float r)
        {
            Circle p = new Circle(x, y, r);
            pictureBox1.Image = p.Draw(pictureBox1, new Pen(Color.Red), bmp, g);
        }
        public void DrawFilledCircle(float x, float y, float r, Color color)
        {
            FilledCircle p = new FilledCircle(x, y, r, color);
            pictureBox1.Image = p.Draw(pictureBox1, bmp, g);
        }
        public void DrawElipse(float x, float y, float r1, float r2)
        {
            Elipse p = new Elipse(x, y, r1, r2);
            pictureBox1.Image = p.Draw(pictureBox1, new Pen(Color.Red), bmp, g);
        }
        public void DrawCone(float x, float y, float h, float r)
        {
            Cone p = new Cone(x, y, h, r);
            
            pictureBox1.Image = p.Draw(pictureBox1, new Pen(Color.Red), bmp, g);
        }
        public void DrawTruncatedCone(float x, float y, float h, float r, float rh)
        {
            TruncatedCone p = new TruncatedCone(x, y, h, r, rh);
            pictureBox1.Image = p.Draw(pictureBox1, new Pen(Color.Red), bmp, g);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!Check(new string[] { textBox1.Text, textBox2.Text }))
                MessageBox.Show("Ввод неправильный");
            else
            {
                g.Clear(pictureBox1.BackColor);
                DrawPoint(int.Parse(textBox1.Text), int.Parse(textBox1.Text));
            }
                
        }
        public bool Check(string[] str)
        {
            foreach (var x in str)
            {
                int res = 0;
                int.TryParse(x, out res);
                if (res == 0 || x.Trim().Length == 0)
                    return false;
            }
            return true;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (!Check(new string[] { textBox1.Text, textBox2.Text }))
                MessageBox.Show("Ввод неправильный");
            else
            {
                images.Add(new Point(int.Parse(textBox1.Text), int.Parse(textBox2.Text)));
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!Check(new string[] { textBox3.Text, textBox4.Text, textBox5.Text}))
                MessageBox.Show("Ввод неправильный");
            else
            {
                g.Clear(pictureBox.BackColor);
                DrawCircle(int.Parse(textBox3.Text),
                    int.Parse(textBox4.Text) ,
                    int.Parse(textBox5.Text) );
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!Check(new string[] { textBox3.Text, textBox4.Text, textBox5.Text }))
                MessageBox.Show("Ввод неправильный");
            else
            {
                images.Add(new Circle(int.Parse(textBox3.Text), int.Parse(textBox4.Text), int.Parse(textBox5.Text)));
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!Check(new string[] { textBox3.Text, textBox4.Text, textBox5.Text }))
                MessageBox.Show("Ввод неправильный");
            else
            {
                Circle c = new Circle(int.Parse(textBox3.Text), int.Parse(textBox4.Text), int.Parse(textBox5.Text));
                MessageBox.Show(c.ToString());
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (!Check(new string[] { textBox3.Text, textBox4.Text, textBox5.Text }))
                MessageBox.Show("Ввод неправильный");
            else
            {
                Circle c = new Circle(int.Parse(textBox3.Text), int.Parse(textBox4.Text), int.Parse(textBox5.Text));
                MessageBox.Show(""+c.Square());
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (!Check(new string[] { textBox3.Text, textBox4.Text, textBox5.Text }))
                MessageBox.Show("Ввод неправильный");
            else
            {
                Circle c = new Circle(int.Parse(textBox3.Text), int.Parse(textBox4.Text), int.Parse(textBox5.Text));
                MessageBox.Show("" + c.Perimeter());
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (!Check(new string[] { textBox3.Text, textBox4.Text, textBox5.Text, listBox1.Text }))
                MessageBox.Show("Ввод неправильный");
            else
            {
                g.Clear(pictureBox.BackColor);  
                DrawCircle(int.Parse(textBox3.Text),
                    int.Parse(textBox4.Text), 
                    int.Parse(textBox5.Text) * int.Parse(listBox1.Text)/100);              
            }
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (!Check(new string[] { textBox14.Text, textBox15.Text, textBox16.Text }))
                MessageBox.Show("Ввод неправильный");
            else
            {

                if (color.ShowDialog() == DialogResult.OK) {
                    g.Clear(pictureBox.BackColor);
                    DrawFilledCircle(int.Parse(textBox14.Text),
                        int.Parse(textBox15.Text),
                        int.Parse(textBox16.Text), color.Color);
                }
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (!Check(new string[] { textBox14.Text, textBox15.Text, textBox16.Text }))
                MessageBox.Show("Ввод неправильный");
            else
            {
                if (color.ShowDialog() == DialogResult.OK)
                {
                    images.Add(new FilledCircle(int.Parse(textBox14.Text), int.Parse(textBox15.Text), int.Parse(textBox16.Text), color.Color));
                }
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (!Check(new string[] { textBox14.Text, textBox15.Text, textBox16.Text }))
                MessageBox.Show("Ввод неправильный");
            else
            {
                if (color.ShowDialog() == DialogResult.OK)
                {
                    FilledCircle c = new FilledCircle(int.Parse(textBox14.Text), int.Parse(textBox15.Text), int.Parse(textBox16.Text), color.Color);
                    MessageBox.Show(c.ToString());
                    
                }
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (!Check(new string[] { textBox14.Text, textBox15.Text, textBox16.Text }))
                MessageBox.Show("Ввод неправильный");
            else
            {
                if (color.ShowDialog() == DialogResult.OK)
                {
                    FilledCircle c = new FilledCircle(int.Parse(textBox14.Text), int.Parse(textBox15.Text), int.Parse(textBox16.Text), color.Color);
                    MessageBox.Show(""+c.Square());

                }
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (!Check(new string[] { textBox14.Text, textBox15.Text, textBox16.Text }))
                MessageBox.Show("Ввод неправильный");
            else
            {
                if (color.ShowDialog() == DialogResult.OK)
                {
                    FilledCircle c = new FilledCircle(int.Parse(textBox14.Text), int.Parse(textBox15.Text), int.Parse(textBox16.Text), color.Color);
                    MessageBox.Show("" + c.Perimeter());

                }
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (!Check(new string[] { textBox14.Text, textBox15.Text, textBox16.Text, listBox2.Text }))
                MessageBox.Show("Ввод неправильный");
            else
            {

                if (color.ShowDialog() == DialogResult.OK)
                {
                    g.Clear(pictureBox.BackColor);
                    DrawFilledCircle(int.Parse(textBox14.Text),
                        int.Parse(textBox15.Text),
                        int.Parse(textBox16.Text)*int.Parse(listBox2.Text)/100, color.Color);
                }
            }
        }

        private void button29_Click(object sender, EventArgs e)
        {
            if (!Check(new string[] { textBox21.Text, textBox22.Text, textBox23.Text, textBox23.Text }))
                MessageBox.Show("Ввод неправильный");
            else
            { 
                g.Clear(pictureBox.BackColor);
                DrawElipse(int.Parse(textBox21.Text),
                    int.Parse(textBox22.Text),
                    int.Parse(textBox23.Text), int.Parse(textBox24.Text)) ;
                
            }
        }

        private void button28_Click(object sender, EventArgs e)
        {
            if (!Check(new string[] { textBox21.Text, textBox22.Text, textBox23.Text, textBox23.Text }))
                MessageBox.Show("Ввод неправильный");
            else
            {
                images.Add(new Elipse(int.Parse(textBox21.Text),
                    int.Parse(textBox22.Text),
                    int.Parse(textBox23.Text), int.Parse(textBox24.Text)));

            }
        }

        private void button27_Click(object sender, EventArgs e)
        {
            if (!Check(new string[] { textBox21.Text, textBox22.Text, textBox23.Text, textBox24.Text }))
                MessageBox.Show("Ввод неправильный");
            else
            {
                Elipse el = new Elipse(int.Parse(textBox21.Text), int.Parse(textBox22.Text), int.Parse(textBox23.Text), int.Parse(textBox24.Text));
                MessageBox.Show(el.ToString());                
            }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            if (!Check(new string[] { textBox21.Text, textBox22.Text, textBox23.Text, textBox24.Text }))
                MessageBox.Show("Ввод неправильный");
            else
            {
                Elipse el = new Elipse(int.Parse(textBox21.Text), int.Parse(textBox22.Text), int.Parse(textBox23.Text), int.Parse(textBox24.Text));
                MessageBox.Show(""+el.Square());
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            if (!Check(new string[] { textBox21.Text, textBox22.Text, textBox23.Text, textBox24.Text }))
                MessageBox.Show("Ввод неправильный");
            else
            {
                Elipse el = new Elipse(int.Parse(textBox21.Text), int.Parse(textBox22.Text), int.Parse(textBox23.Text), int.Parse(textBox24.Text));
                MessageBox.Show("" + el.Perimeter());
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (!Check(new string[] { textBox21.Text, textBox22.Text, textBox23.Text, textBox23.Text, listBox3.Text }))
                MessageBox.Show("Ввод неправильный");
            else
            {
                g.Clear(pictureBox.BackColor);
                DrawElipse(int.Parse(textBox21.Text),
                    int.Parse(textBox22.Text),
                    int.Parse(textBox23.Text) *int.Parse(listBox3.Text)/100, int.Parse(textBox24.Text)*int.Parse(listBox3.Text)/100);

            }
        }

        private void button38_Click(object sender, EventArgs e)
        {
            if (!Check(new string[] { textBox29.Text, textBox30.Text, textBox31.Text, textBox39.Text }))
                MessageBox.Show("Ввод неправильный");
            else
            {
                g.Clear(pictureBox.BackColor);
                DrawCone(int.Parse(textBox29.Text),
                    int.Parse(textBox30.Text),
                    int.Parse(textBox31.Text), int.Parse(textBox39.Text));

            }
        }

        private void button37_Click(object sender, EventArgs e)
        {
            if (!Check(new string[] { textBox29.Text, textBox30.Text, textBox31.Text, textBox39.Text }))
                MessageBox.Show("Ввод неправильный");
            else
            {
                images.Add( new Cone(int.Parse(textBox29.Text),
                    int.Parse(textBox30.Text),
                    int.Parse(textBox31.Text), int.Parse(textBox39.Text)));

            }
        }

        private void button36_Click(object sender, EventArgs e)
        {
            if (!Check(new string[] { textBox29.Text, textBox30.Text, textBox31.Text, textBox39.Text }))
                MessageBox.Show("Ввод неправильный");
            else
            {
               Cone c = new Cone(int.Parse(textBox29.Text),
                    int.Parse(textBox30.Text),
                    int.Parse(textBox31.Text), int.Parse(textBox39.Text));
                MessageBox.Show(c.ToString());

            }
        }

        private void button35_Click(object sender, EventArgs e)
        {
            if (!Check(new string[] { textBox29.Text, textBox30.Text, textBox31.Text, textBox39.Text }))
                MessageBox.Show("Ввод неправильный");
            else
            {
                Cone c = new Cone(int.Parse(textBox29.Text),
                     int.Parse(textBox30.Text),
                     int.Parse(textBox31.Text), int.Parse(textBox39.Text));
                MessageBox.Show(""+c.Square());

            }
        }

        private void button34_Click(object sender, EventArgs e)
        {
            if (!Check(new string[] { textBox29.Text, textBox30.Text, textBox31.Text, textBox39.Text }))
                MessageBox.Show("Ввод неправильный");
            else
            {
                Cone c = new Cone(int.Parse(textBox29.Text),
                     int.Parse(textBox30.Text),
                     int.Parse(textBox31.Text), int.Parse(textBox39.Text));
                MessageBox.Show("" + c.Perimeter());

            }
        }

        private void button30_Click(object sender, EventArgs e)
        {
            if (!Check(new string[] { textBox29.Text, textBox30.Text, textBox31.Text, textBox39.Text, listBox4.Text }))
                MessageBox.Show("Ввод неправильный");
            else
            {
                g.Clear(pictureBox.BackColor);
                DrawCone(int.Parse(textBox29.Text),
                    int.Parse(textBox30.Text),
                    int.Parse(textBox31.Text) * int.Parse(listBox4.Text)/100, int.Parse(textBox39.Text)*int.Parse(listBox4.Text)/100);

            }
        }

        private void button47_Click(object sender, EventArgs e)
        {
            if (!Check(new string[] { textBox36.Text, textBox37.Text, textBox38.Text, textBox40.Text, textBox41.Text }))
                MessageBox.Show("Ввод неправильный");
            else
            {
                g.Clear(pictureBox.BackColor);
                DrawTruncatedCone(int.Parse(textBox36.Text),
                    int.Parse(textBox37.Text),
                    int.Parse(textBox38.Text), int.Parse(textBox40.Text), int.Parse(textBox41.Text));

            }
        }

        private void button46_Click(object sender, EventArgs e)
        {
            if (!Check(new string[] { textBox36.Text, textBox37.Text, textBox38.Text, textBox40.Text, textBox41.Text }))
                MessageBox.Show("Ввод неправильный");
            else
            {
                images.Add( new TruncatedCone(int.Parse(textBox36.Text),
                    int.Parse(textBox37.Text),
                    int.Parse(textBox38.Text), int.Parse(textBox40.Text), int.Parse(textBox41.Text)));

            }
        }

        private void button45_Click(object sender, EventArgs e)
        {
            if (!Check(new string[] { textBox36.Text, textBox37.Text, textBox38.Text, textBox40.Text, textBox41.Text }))
                MessageBox.Show("Ввод неправильный");
            else
            {
                TruncatedCone c = new TruncatedCone(int.Parse(textBox36.Text),
                    int.Parse(textBox37.Text),
                    int.Parse(textBox38.Text), int.Parse(textBox40.Text), int.Parse(textBox41.Text));
                MessageBox.Show(c.ToString());

            }
        }

        private void button44_Click(object sender, EventArgs e)
        {
            if (!Check(new string[] { textBox36.Text, textBox37.Text, textBox38.Text, textBox40.Text, textBox41.Text }))
                MessageBox.Show("Ввод неправильный");
            else
            {
                TruncatedCone c = new TruncatedCone(int.Parse(textBox36.Text),
                    int.Parse(textBox37.Text),
                    int.Parse(textBox38.Text), int.Parse(textBox40.Text), int.Parse(textBox41.Text));
                MessageBox.Show(""+c.Square());

            }
        }

        private void button43_Click(object sender, EventArgs e)
        {
            if (!Check(new string[] { textBox36.Text, textBox37.Text, textBox38.Text, textBox40.Text, textBox41.Text }))
                MessageBox.Show("Ввод неправильный");
            else
            {
                TruncatedCone c = new TruncatedCone(int.Parse(textBox36.Text),
                    int.Parse(textBox37.Text),
                    int.Parse(textBox38.Text), int.Parse(textBox40.Text), int.Parse(textBox41.Text));
                MessageBox.Show("" + c.Perimeter());

            }
        }

        private void button39_Click(object sender, EventArgs e)
        {
            if (!Check(new string[] { textBox36.Text, textBox37.Text, textBox38.Text, textBox40.Text, textBox41.Text, listBox5.Text }))
                MessageBox.Show("Ввод неправильный");
            else
            {
                g.Clear(pictureBox.BackColor);
                DrawTruncatedCone(int.Parse(textBox36.Text),
                    int.Parse(textBox37.Text),
                    int.Parse(textBox38.Text) * int.Parse(listBox5.Text)/100, 
                    int.Parse(textBox40.Text) * int.Parse(listBox5.Text) / 100,
                    int.Parse(textBox41.Text) * int.Parse(listBox5.Text) / 100);

            }
        }

        private void listBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button22_Click(object sender, EventArgs e)
        {
            if (!Check(new string[] { textBox6.Text }))
                MessageBox.Show("Ввод неправильный");
            images.PlusWidth(float.Parse(textBox6.Text));
        }

        private void button23_Click(object sender, EventArgs e)
        {
            if (!Check(new string[] { textBox7.Text }))
                MessageBox.Show("Ввод неправильный");
            images.PlusHeight(float.Parse(textBox7.Text));
        }

        private void button24_Click(object sender, EventArgs e)
        {
            if (!Check(new string[] { textBox8.Text, textBox9.Text }))
                MessageBox.Show("Ввод неправильный");
            images.MoveTo(float.Parse(textBox8.Text), float.Parse(textBox9.Text));
        }

        private void button15_Click(object sender, EventArgs e)
        {
            g.Clear(pictureBox1.BackColor);
            images.Draw();
        }

        private void button14_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            MessageBox.Show(images.ToString());
        }

        private void button10_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Общая площадь: " +images.Square());
        }

        private void button9_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Общая площадь: " + images.Perimeter());
        }

        private void button8_Click(object sender, EventArgs e)
        {
            g.Clear(pictureBox1.BackColor);
            images.Scale(float.Parse(listBox6.Text)/100);
            images.Draw();
        }
    }
}
