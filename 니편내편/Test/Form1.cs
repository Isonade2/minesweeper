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
        int a = 0;
        int number = 2;
        int y = 10;
        int score = 0;
        Bitmap redbitmap = Properties.Resources.red;
        Bitmap bluebitmap = Properties.Resources.blue;
        Bitmap pinkbitmap = Properties.Resources.pink;
        Bitmap greenbitmap = Properties.Resources.green;
        Bitmap purplebitmap = Properties.Resources.purple;
        Bitmap brownbitmap = Properties.Resources.brown;
        Random rnd = new Random();
        PictureBox[] BTN = new PictureBox[5];

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 초기 색상블럭 생성, 초기화
            
            for (int i = 0; i < 5; i++)
            {
                BTN[i] = new PictureBox();

                BTN[i].Location = new Point(180, y);
                BTN[i].Size = new Size(50, 50);
                a = rnd.Next(0, 3);
                if (a == 0)
                    BTN[i].Image = redbitmap;
                else 
                    BTN[i].Image = bluebitmap;
                y += 70;
                if (BTN[i] == BTN[BTN.Length-1])
                {
                    BTN[i].Size = new Size(70, 70);
                    BTN[i].Left += -10;
                }
                this.Controls.Add(BTN[i]);
            }


        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                if ((BTN[4].Image == redbitmap) || (BTN[4].Image == pinkbitmap) || (BTN[4].Image == purplebitmap))
                {
                    Makeblock();
                    score++;
                    label1.Text = "score: " + score;
                    
                }

                else
                    MessageBox.Show("실패");
            }
            if(e.KeyCode == Keys.Right)
            {
                if (BTN[4].Image == bluebitmap || BTN[4].Image == greenbitmap || BTN[4].Image == brownbitmap)
                {
                    Makeblock();
                    score++;
                    label1.Text = "score : " + score;
                    
                }
                else
                    MessageBox.Show("실패");
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
            a = rnd.Next(0, number);
            if (a == 0)
                BTN[0].Image = redbitmap;
            else if (a == 1)
                BTN[0].Image = bluebitmap;
            else if (a == 2)
                BTN[0].Image = pinkbitmap;
            else if (a == 3)
                BTN[0].Image = greenbitmap;
            else if (a == 4)
                BTN[0].Image = brownbitmap;
            else if (a == 5)
                BTN[0].Image = purplebitmap;

        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            if(progressBar1.Value == progressBar1.Maximum)
            {

            }
            progressBar1.Value++;
            
        }
    }


}
