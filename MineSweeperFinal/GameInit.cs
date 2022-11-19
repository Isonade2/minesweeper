using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineSweeperFinal
{
    public partial class GameInit : Form
    {
        public GameInit()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                Form1 form1 = new Form1();
                form1.FieldInit(5, 5, 3,0);
                form1.Height = 240;
                form1.Width = 400;
                form1.Show();
                this.Close();
            }
            else if(comboBox1.SelectedIndex == 1)
            {
                Form1 form1 = new Form1();
                form1.FieldInit(10, 10, 15,1);
                form1.Height = 440;
                form1.Width = 600;
                form1.Show();
            }
            else if(comboBox1.SelectedIndex == 2)
            {
                Form1 form1 = new Form1();
                form1.FieldInit(15, 15, 45,2);
                form1.Height = 640;
                form1.Width = 800;
                form1.Show();
            }
            else
            {
                MessageBox.Show("난이도를 설정해주세요.");
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("메인메뉴");
        }

        private void GameInit_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
