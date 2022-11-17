using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineSweeper2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int[,] feld;
        public void Init(int x, int y, int bomb)
        {
            feld = new int[x, y]; // 필드 생성
            int a, b;
            Random rnd = new Random(); // 지뢰 생성
            for (int i = 0; i < bomb; i++)
            {
                a = rnd.Next(x);
                b = rnd.Next(y);
                if (feld[a, b] == -1)
                    i--;
                feld[a, b] = -1;
            }

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    if (feld[i, j] < 0)
                    {
                        if (i == 0 && j == 0) // bomb 위치가 모서리 일때
                        {
                            feld[i + 1, j] += 1; feld[i, j +1] += 1; feld[i + 1, j + 1] += 1; continue;
                        }
                        if (i == x-1 && j == 0)
                        {
                            feld[i - 1, j] += 1; feld[i - 1, j + 1] += 1; feld[i, j + 1] += 1; continue;
                        }
                        if(i == 0 && j == y-1)
                        {
                            feld[i, j - 1] += 1; feld[i + 1, j - 1] += 1; feld[i + 1, j] += 1; continue;
                        }
                        if (i == x - 1 && j == y-1)
                        {
                            feld[i - 1, j] += 1; feld[i - 1, j - 1] += 1; feld[i, j - 1] += 1; continue;
                        }
                        if (i > 0 && j ==0 ) //bomb 위치가 위에 붙어 있을때
                        {
                            feld[i - 1, j] += 1; feld[i + 1, j] += 1; feld[i - 1, j + 1] += 1; feld[i + 1, j + 1] += 1; feld[i, j + 1] += 1;  continue;
                        }
                        if( i>0 && j == y -1) //bomb 위치가 아래에 붙어 있을때
                        {
                            feld[i - 1, j] += 1; feld[i - 1, j - 1] += 1; feld[i, j - 1] += 1; feld[i + 1, j - 1] += 1; feld[i + 1, j] += 1; continue;
                        }
                        if(i==0 && y>0) // bomb 위치가 왼쪽에 붙어 있을때
                        {
                            feld[i, j - 1] += 1; feld[i + 1, j - 1] += 1; feld[i + 1, j] += 1; feld[i + 1, j + 1] += 1; feld[i, j + 1] += 1; continue;
                        }
                        if (i == x - 1 && y>0) //bomb 위치가 오른쪽에 붙어있을때
                        {
                            feld[i, j - 1] += 1; feld[i - 1, j - 1] += 1; feld[i - 1, j] += 1; feld[i - 1, j + 1] += 1; feld[i, j + 1] += 1; continue;
                        }
                        else
                        {
                            feld[i - 1, j - 1] += 1; feld[i - 1, j] += 1; feld[i - 1, j + 1] += 1; feld[i, j - 1] += 1; feld[i, j + 1] += 1;
                            feld[i + 1, j - 1] += 1; feld[i + 1, j] += 1; feld[i + 1, j + 1] += 1; continue;
                        }
                    }
                }
            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //Init(5, 3, 4);
            Button[,] BTN = new Button[feld.GetLength(0), feld.GetLength(1)];
            for (int x = 0; x < feld.GetLength(0); x++)
            {
                for (int y = 0; y < feld.GetLength(1); y++)
                {
                    BTN[x, y] = new Button();
                    BTN[x, y].Size = new Size(50, 50);
                    BTN[x, y].Left = x * 50;
                    BTN[x, y].Top = y * 50;
                    Controls.Add(BTN[x, y]);
                    BTN[x, y].Click += BTN_Click;
                    BTN[x, y].TabStop = false;
                }
            }

        }
        private void BTN_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            int x = b.Left / 50;
            int y = b.Top / 50;
            if (feld[x, y] < 0)
            { 
                b.Text = "\u274C";
                //MessageBox.Show("gameover!");
                //Application.Restart();

            }
            else if (feld[x, y] == 0)
                b.Text = "";
            else
                b.Text = "" + feld[x, y];
            b.Enabled = false;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
