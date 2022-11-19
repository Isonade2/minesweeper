using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineSweeperFinal
{
    public partial class Form1 : Form
    {
        private int[,] field;
        public Button[,] buttons;
        public Form1()
        {
                InitializeComponent();

        }
        Label mine;
        Label time;
        Button btn_restart;
        Button btn_manu;
        private int time_ = 1;
        public void FieldInit(int x, int y, int bomb,int difficulty)
        {
            btn_restart = new Button();
            btn_manu = new Button();
            mine = new Label();
            time = new Label();
            btn_restart.Text = "난이도변경";
            btn_manu.Text = "메뉴";
            mine.Text = "지뢰 수: " + bomb;
            time.Text = "걸린 시간: " + time_;
            if (difficulty == 0)
            {
                btn_restart.Location = new Point(210, 10);
                btn_manu.Location = new Point(297, 10);
                mine.Location = new Point(210, 50);
                time.Location = new Point(210, 90);

            }
            else if (difficulty == 1)
            {
                btn_restart.Location = new Point(410, 10);
                btn_manu.Location = new Point(497, 10);
                mine.Location = new Point(410, 50);
                time.Location = new Point(410, 90);
            }
            else if (difficulty == 2)
            {
                btn_restart.Location = new Point(610, 10);
                btn_manu.Location = new Point(697, 10);
                mine.Location = new Point(610, 50);
                time.Location = new Point(610, 90);
            }
            this.Controls.Add(btn_restart);
            this.Controls.Add(btn_manu);
            this.Controls.Add(mine);
            this.Controls.Add(time);
            btn_restart.Click += restart;

            field = new int[x, y];
            Random rnd = new Random();
            while (bomb > 0)
            {
                int X = rnd.Next(x);
                int Y = rnd.Next(y);
                if (field[X, Y] == -1) continue;
                field[X, Y] = -1;
                for (int bx = -1; bx <= 1; bx++)
                {
                    for (int by = -1; by <= 1; by++)
                    {
                        if (X + bx < 0) continue;
                        if (Y + by < 0) continue;
                        if (X + bx >= field.GetLength(0)) continue;
                        if (Y + by >= field.GetLength(1)) continue;
                        if (field[X + bx, Y + by] != -1)
                            field[X + bx, Y + by]++;
                    }
                }
                bomb--;
            }



        }

        private void Form1_Load(object sender, EventArgs e)
        {
            buttons = new Button[field.GetLength(0), field.GetLength(1)];
            for (int x = 0; x < field.GetLength(0); x++)
            {
                for (int y = 0; y < field.GetLength(1); y++)
                {
                    buttons[x, y] = new Button();
                    buttons[x, y].Font = new Font("Arial", 20);
                    buttons[x, y].Left = x * 40;
                    buttons[x, y].Top = y * 40;
                    buttons[x, y].Size = new Size(40, 40);
                    Controls.Add(buttons[x, y]);
                    buttons[x, y].Click += BTN_Click;

                }
            }
        }

        private void restart(object sender, EventArgs e)
        {
            GameInit game = new GameInit();
            game.Show();
            this.Hide();
        }
        private void BTN_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int x = btn.Left / 40;
            int y = btn.Top / 40;

            if (field[x, y] == -1)
            {
                timer1.Enabled = false;
                
                for(int i = 0; i < field.GetLength(0); i++)
                {
                    for(int j=0; j < field.GetLength(1); j++)
                    {
                        if (field[i, j] == -1)
                        {
                            buttons[i, j].Text = "\u274C";


                        }
                    }
                }
                if(MessageBox.Show("게임 오버!\n재시작하시겠습니까?","GameOver",MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Application.Restart();
                }
                else
                {
                    
                }
            }
            else if (field[x, y] == 0)
            {
                buttons[x, y].Text = "";
                Recursive(x, y);
            }
            else
            {
                btn.Text = "" + field[x, y];
            }
            buttons[x, y].Enabled = false;

            CheckGameWin();

        }
        private void CheckGameWin()
        {
            int a = 0;
            for(int x = 0; x < field.GetLength(0); x++)
            {
                for(int y = 0; y<field.GetLength(1); y++)
                {
                    if (!(field[x,y] == -1) && buttons[x,y].Enabled==true)
                    {
                        a++;
                    }
                }
            }
            if (a == 0)
            { 
                MessageBox.Show("gameover");
                timer1.Enabled = false;
            }
        }
        private void Recursive(int x, int y)
        {
            if (x < 0 || y < 0) return; // 배열 범위 밖인가?
            if (x >= field.GetLength(0) || y >= field.GetLength(1)) return; // 배열 범위 밖인가?
            if (buttons[x, y].Enabled == false) return; // 이미 눌러진 버튼인가?
            if (field[x, y] != 0) // 폭탄의 범위에 있는 버튼일때
            {
                buttons[x, y].Text = "" + field[x, y];
                buttons[x, y].Enabled = false;
                return;
            }
            buttons[x, y].Enabled = false;

            Recursive(x + 1, y);
            Recursive(x - 1, y);
            Recursive(x, y + 1);
            Recursive(x, y - 1);
            return;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time.Text = "걸린 시간: " + time_;
            time_++;
        }



    }
}

