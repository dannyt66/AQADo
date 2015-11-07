using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AQADo
{
    public partial class Form1 : Form
    {
        public string p1Name;
        public string p2Name;
        public Form1()
        {
            InitializeComponent();
            button2.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 nameWindow = new Form2();
            nameWindow.ShowDialog();
            p1Name = nameWindow.p1In;
            p2Name = nameWindow.p2In;
            if (p1Name.Trim().Length == 0)
            {
                p1Name = "Player One";
            }
            if (p2Name.Trim().Length == 0)
            {
                p2Name = "Player Two";
            }
            button2.Enabled = true;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            gameWindow gameWindow = new gameWindow(this);
            gameWindow.Show();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
