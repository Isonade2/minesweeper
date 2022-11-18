using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineSweeper
{
    public partial class Form1 : Form
    {
        private int[,] feld;
        public Form1()
        {
            InitializeComponent();
        }

        private void init(int breite, int hohe, int bomben)
        {
            feld = new int[breite, hohe];
            Random zufall = new Random();
            while (bomben > 0)
            {
                int x = zufall.Next(breite);
                int y = zufall.Next(hohe);
                if (feld[x, y] == -1) continue;
                feld[x, y] = -1;
                for(int dx = -1; dx<=1; dx++)
                {
                    for (int dy = -1; dy <= 1; dy++)
                    {
                        if (x + dx < 0) continue;
                        if (y + dy < 0) continue;
                        if (x + dx >= breite) continue;
                        if (y + dy >= hohe) continue;

                        if (feld[x + dx, y + dy] != -1)
                            feld[x + dx, y + dy]++;
                    }
                }
                bomben--;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            init(5, 5, 4);
            for (int x = 0; x < feld.GetLength(0); x++)
            {
                for (int y = 0; y < feld.GetLength(1); y++)
                {
                    Button b = new Button();
                    b.Font = new Font("Arial", 20);
                    b.Left = x * 40;
                    b.Width = 40;
                    b.Top = y * 40;
                    b.Height = 40;
                    b.Text = "";
                    Controls.Add(b);
                    b.Click += B_Click;
                }
            }

        }
        private void B_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            int x = b.Left / 40;
            int y = b.Top / 40;
            if (feld[x, y] == -1)
                b.Text = "\U0001F4A3";
            else if ((feld[x, y] == 0))
                b.Text = "";
            else
                b.Text = "" + feld[x, y];
            b.Enabled = false;

        }
    }
}
