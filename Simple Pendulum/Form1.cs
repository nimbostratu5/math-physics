using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple_Pendulum
{
    
    public partial class Form1 : Form
    {

        private int _ticks;
        int width, height, length;
        double teta;
        double teta_max;
        double w;
        Rectangle circle;
        PointF point1;
        PointF point2; PointF point3; PointF point4;

        public Form1()
        {
            InitializeComponent();
            width = pictureBox1.Width;
            height = pictureBox1.Height;
            length = 200;
            w = Math.Sqrt(981 / length) / 100;
            point1 = new PointF(width / 2, 100);
            circle = new Rectangle(0, 0, 40, 40);

        }

        Pen red = new Pen(Color.Red);
        Pen blackPen = new Pen(Color.Black, 3);
        System.Drawing.SolidBrush fillRed = new System.Drawing.SolidBrush(Color.Red);

        private void button1_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == false)
            {
                timer1.Enabled = true;
                button1.Text = "PAUSE";
                button1.BackColor = Color.Yellow;
            }
            else 
            {
                timer1.Enabled = false;
                button1.Text = "START";
                button1.BackColor = Color.GreenYellow;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            
            if (numericUpDown1.Value > 0)
            {
                button1.Enabled = true ;
                button1.BackColor = Color.GreenYellow;
                length = Convert.ToInt32(numericUpDown1.Value)*10;
                w = Math.Sqrt(981 / length) / 100;

            }
            else
            {
                button1.BackColor = Color.Red;
                button1.Enabled = false;
            }
            
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            teta_max = Convert.ToDouble(numericUpDown2.Value) * Math.PI / 180;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _ticks++;

            teta = teta_max * (Math.Cos(w * _ticks));

            circle.X = Convert.ToInt32(     (width / 2) - 20+   (length * Math.Sin(teta))    );
            circle.Y = Convert.ToInt32(       80+  (length * Math.Cos(teta)        )           );

            point2.X = circle.X+20;
            point2.Y = circle.Y+20;
            //label7.Text = Math.Round(Math.Sqrt( Math.Pow((point2.Y - point1.Y), 2) + Math.Pow((point2.X - point1.X), 2))).ToString();
            label4.Text = point2.X.ToString();
            label5.Text = point2.Y.ToString();
            label10.Text = Convert.ToInt32(teta * 180 / Math.PI).ToString();
            label7.Text = _ticks.ToString();
            pictureBox1.Refresh();

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            point3 = new PointF(0, 100);
            point4 = new PointF(width, 100); ;
            if (timer1.Enabled) 
            { 
                Graphics g = e.Graphics;
                g.DrawEllipse(red, circle);

                e.Graphics.DrawLine(blackPen, point1, point2);

                e.Graphics.DrawLine(blackPen, point3, point4);

                Invalidate();
            }
        }
 
    }
}
