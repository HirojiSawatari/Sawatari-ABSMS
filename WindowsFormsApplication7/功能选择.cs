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
    public partial class 功能选择 : Form
    {
        public 功能选择()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.c = true;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Program.d = true;
            this.Close();
        }

        //private void 功能选择_Load(object sender, EventArgs e)
        //{
        //    加载界面 f1 = new 加载界面();
        //    f1.Show();
        //    f1.Activate();
        //    Application.DoEvents();
        //    System.Threading.Thread.Sleep(3000);
        //    f1.Close();
        //    f1.Dispose();
        //    this.Focus();
        //}
    }
}
