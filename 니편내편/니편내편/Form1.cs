using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 니편내편
{
    public partial class Form1 : Form
    {
        Bitmap red = Properties.Resources.red;
        Bitmap blue = Properties.Resources.blue;
        Bitmap green = Properties.Resources.green;
        Bitmap pink = Properties.Resources.pink;
        Bitmap brown = Properties.Resources.brown;
        Bitmap purple = Properties.Resources.purple;
        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }
        Random rnd = new Random();
        int number = 2;
        private void Form1_Load(object sender, EventArgs e)
        {
            int[] arr = new int[10];
            for (int i = 0; i < 10; i++)
            {
                arr[i] = rnd.Next(number);
            }
            if (arr[0] == 0)
                pictureBox1.Image = red;
            else
                pictureBox1.Image = blue;
            if (arr[1] == 0)
                pictureBox2.Image = red;
            else
                pictureBox2.Image = imageList1.Images[1];
            if (arr[2] == 0)
                pictureBox3.Image = imageList1.Images[0];
            else
                pictureBox3.Image = imageList1.Images[1];
            if (arr[3] == 0)
                pictureBox4.Image = imageList1.Images[0];
            else
                pictureBox4.Image = imageList1.Images[1];
            if (arr[4] == 0)
                pictureBox5.Image = imageList1.Images[0];
            else
                pictureBox5.Image = imageList1.Images[1];
            
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                try
                {
                    Bitmap bitmap = new Bitmap(pictureBox1.Image);
                    Color color = bitmap.GetPixel(e.X, e.Y);
                    label1.Text = $"RED : {color.R} GREEN : {color.G} BLUE : {color.B}";
                }
                catch (Exception)
                {
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
          
            if (e.KeyCode == Keys.Left)
            {

                if (true)
                {
                    pictureBox1.Image = pictureBox2.Image;
                    pictureBox2.Image = pictureBox3.Image;
                    pictureBox3.Image = pictureBox4.Image;
                    pictureBox4.Image = pictureBox5.Image;

                    makebuttoncolor();


                }
                else
                {
                    Application.Restart();
                    MessageBox.Show("gameover");
                }
            }
            if (e.KeyCode == Keys.Right)
            {
                if (pictureBox1.Image.Size == imageList1.Images[0].Size)
                {
                    pictureBox1.Image = pictureBox2.Image;
                    pictureBox2.Image = pictureBox3.Image;
                    pictureBox3.Image = pictureBox4.Image;
                    pictureBox4.Image = pictureBox5.Image;

                    makebuttoncolor();
                }
                else
                {
                    Application.Restart();
                    MessageBox.Show("gameover");
                }
            }
            if (e.KeyCode == Keys.F1)
            {
                MessageBox.Show("Hi");
            }
        }
        private void makebuttoncolor()
        {

            int a = rnd.Next(number);
            pictureBox5.Image = imageList1.Images[a];
            pictureBox5.Image = imageList1.Images[a];

        }
    }
}
