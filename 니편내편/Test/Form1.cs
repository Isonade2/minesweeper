using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using System.Security.Cryptography.X509Certificates;

namespace Test
{
    public partial class Form1 : Form
    {
        private int BlockRange = 0;
        private int number = 2;
        private int y = -10;
        private int score = 0;
        private bool DontRunEvent = true;
        private int DontRunEventTime = 0;
        private int Count = 2;
        Bitmap redbitmap = Properties.Resources.red;
        Bitmap bluebitmap = Properties.Resources.blue;
        Bitmap whitebitmap = Properties.Resources.white;
        Bitmap greenbitmap = Properties.Resources.green;
        Bitmap purplebitmap = Properties.Resources.purple;
        Bitmap yellowbitmap = Properties.Resources.yellow;
        Random rnd = new Random();
        PictureBox[] BTN = new PictureBox[5];
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.Gray;
            

            // 초기 색상블럭 생성, 초기화

            for (int i = 0; i < 5; i++)
            {
                BTN[i] = new PictureBox();

                BTN[i].Location = new Point(280, y);
                BTN[i].Size = new Size(100, 100);
                BTN[i].SizeMode = PictureBoxSizeMode.StretchImage;

                BlockRange = rnd.Next(0, 3);
                if (BlockRange == 0)
                    BTN[i].Image = redbitmap;
                else
                    BTN[i].Image = bluebitmap;
                y += 90;
                if (BTN[i] == BTN[BTN.Length - 1])
                {
                    BTN[i].Size = new Size(120, 120);
                    BTN[i].Location = new Point(280, 380);
                    BTN[i].Left += -10;
                }
                this.Controls.Add(BTN[i]);
            }


        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (DontRunEvent == false)
            {
                if (e.KeyCode == Keys.Left)
                {
                    if ((BTN[4].Image == redbitmap) || (BTN[4].Image == whitebitmap) || (BTN[4].Image == purplebitmap))
                    {
                        Makeblock();
                        score++;
                        label1.Text = "SCORE: " + score;

                    }
                    else
                    {
                        DontRunEvent = true;
                        this.BackColor = Color.DarkGray;
                        timer2.Enabled = true;
                    }

                }
                if (e.KeyCode == Keys.Right)
                {
                    if (BTN[4].Image == bluebitmap || BTN[4].Image == greenbitmap || BTN[4].Image == yellowbitmap)
                    {
                        Makeblock();
                        score++;
                        label1.Text = "SCORE: " + score;

                    }
                    else
                    {
                        DontRunEvent = true;
                        this.BackColor = Color.DarkGray;
                        timer2.Enabled = true;
                    }
                }
            }
        }

        private void Makeblock()
        {
            if (score > 20)
                number = 4;
            if (score > 40)
                number = 6;
            BTN[4].Image = BTN[3].Image;
            BTN[3].Image = BTN[2].Image;
            BTN[2].Image = BTN[1].Image;
            BTN[1].Image = BTN[0].Image;
            BlockRange = rnd.Next(0, number);
            if (BlockRange == 0)
                BTN[0].Image = redbitmap;
            else if (BlockRange == 1)
                BTN[0].Image = bluebitmap;
            else if (BlockRange == 2)
                BTN[0].Image = whitebitmap;
            else if (BlockRange == 3)
                BTN[0].Image = greenbitmap;
            else if (BlockRange == 4)
                BTN[0].Image = yellowbitmap;
            else if (BlockRange == 5)
                BTN[0].Image = purplebitmap;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < progressBar1.Maximum)
            {
                progressBar1.Value++;
            }
            else
            {
                timer1.Enabled = false;
                DontRunEvent = true;
                Form2 form2 = new Form2(score);
                form2.Show();
            }



        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen p = new Pen(Color.Black);
            Point[] pts =
            {
                new Point(259,375), new Point(400,375),
                new Point(400,516), new Point(259,516), new Point(259,375)
            };
            g.DrawLines(new Pen(Color.Black), pts);
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            MessageBox.Show(e.X + "," + e.Y);
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            DontRunEventTime += 1;
            if(DontRunEventTime == 1)
            {
                DontRunEvent = false;
                timer2.Enabled = false;
                DontRunEventTime = 0;
                this.BackColor = Color.MediumSeaGreen;
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (Count == 0)
            {
                CountDown.Hide();
                timer1.Enabled = true;
                timer3.Enabled = false;
                DontRunEvent = false;
                this.BackColor = Color.MediumSeaGreen;
                
            }
            CountDown.Text = "" + Count;
            Count--;
            
        }
    }


}
