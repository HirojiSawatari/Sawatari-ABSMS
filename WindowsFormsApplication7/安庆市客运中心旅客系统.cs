using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication7
{
    public partial class 安庆市客运中心旅客系统 : Form
    {
        public 安庆市客运中心旅客系统()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Program.g = true;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.f = true;
            this.Close();
        }
    }
}
