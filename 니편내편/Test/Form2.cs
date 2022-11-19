using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class Form2 : Form
    {
        private int score1;
        public Form2(int score)
        {
            InitializeComponent();
            score1 = score;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
            label1.Text = "SCORE: " + score1;
        }
    }
}
