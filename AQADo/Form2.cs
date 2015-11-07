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
    public partial class Form2 : Form
    {
        public string p1In;
        public string p2In;
        public Form2()
        {
            InitializeComponent();
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            p1In = p1Input.Text;
            p2In = p2Input.Text;
            this.Close();
        }
    }
}
