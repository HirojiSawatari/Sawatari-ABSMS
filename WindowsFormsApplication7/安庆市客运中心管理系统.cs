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
    public partial class 安庆市客运中心管理系统 : Form
    {
        public 安庆市客运中心管理系统()
        {
            InitializeComponent();
        }
        
        private void 关于本软件AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            关于本软件 f2 = new 关于本软件();
            f2.Show();
        }


        private void 通过编号查询IToolStripMenuItem_Click(object sender, EventArgs e)
        {
            旅客管理系统 MDIChild = new 旅客管理系统();
            MDIChild.MdiParent = this;
            MDIChild.Show();
        }

        private void 通过姓名查询NToolStripMenuItem_Click(object sender, EventArgs e)
        {
            旅客管理系统_姓名查询窗口_ MDIChild = new 旅客管理系统_姓名查询窗口_();
            MDIChild.MdiParent = this;
            MDIChild.Show();
        }

        private void 通过车辆查询BToolStripMenuItem_Click(object sender, EventArgs e)
        {
            旅客管理系统_车辆查询窗口_ MDIChild = new 旅客管理系统_车辆查询窗口_();
            MDIChild.MdiParent = this;
            MDIChild.Show();
        }

        private void 通过发到站查询EToolStripMenuItem_Click(object sender, EventArgs e)
        {
            车辆管理系统 MDIChild = new 车辆管理系统();
            MDIChild.MdiParent = this;
            MDIChild.Show();
        }

        private void 通过驾驶员查询DToolStripMenuItem_Click(object sender, EventArgs e)
        {
            车辆管理系统_驾驶员查询窗口_ MDIChild = new 车辆管理系统_驾驶员查询窗口_();
            MDIChild.MdiParent = this;
            MDIChild.Show();
        }

        private void 通过车牌号查询NToolStripMenuItem_Click(object sender, EventArgs e)
        {
            车辆管理系统_车牌号查询窗口_ MDIChild = new 车辆管理系统_车牌号查询窗口_();
            MDIChild.MdiParent = this;
            MDIChild.Show();
        }

        private void 乘客ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            乘客录入 MDIChild = new 乘客录入();
            MDIChild.MdiParent = this;
            MDIChild.Show();
        }

        private void 安庆市客运中心管理系统_Load(object sender, EventArgs e)
        {
            this.toolStripStatusLabel2.Text = "登录时间：" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            this.toolStripStatusLabel2.Text = "系统时间：" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            this.toolStripStatusLabel3.Text = "    登陆用户：" + Program.b.ToString();
            this.timer1.Interval = 1000;
            this.timer1.Start();
            MdiClient ctlMDI;
            foreach (Control ctl in this.Controls)
            {
                try
                {
                    ctlMDI = (MdiClient)ctl;
                    ctlMDI.BackColor = this.BackColor;
                }
                catch (InvalidCastException exc)
                {
                }
            }
        }

        private void 车辆BToolStripMenuItem_Click(object sender, EventArgs e)
        {
            车辆录入 MDIChild = new 车辆录入();
            MDIChild.MdiParent = this;
            MDIChild.Show();
        }

        private void 线路LToolStripMenuItem_Click(object sender, EventArgs e)
        {
            线路录入 MDIChild = new 线路录入();
            MDIChild.MdiParent = this;
            MDIChild.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.toolStripStatusLabel2.Text = "系统时间：" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
        }

        private void 通过发到站查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            线路管理系统_发到站查询窗口_ MDIChild = new 线路管理系统_发到站查询窗口_();
            MDIChild.MdiParent = this;
            MDIChild.Show();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            管理员账户管理 MDIChild = new 管理员账户管理();
            MDIChild.MdiParent = this;
            MDIChild.Show();
        }

        private void 管理员管理UToolStripMenuItem_Click(object sender, EventArgs e)
        {
            管理员账户管理 MDIChild = new 管理员账户管理();
            MDIChild.MdiParent = this;
            MDIChild.Show();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            线路管理系统_发到站查询窗口_ MDIChild = new 线路管理系统_发到站查询窗口_();
            MDIChild.MdiParent = this;
            MDIChild.Show();
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            关于本软件 f2 = new 关于本软件();
            f2.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            乘客录入 MDIChild = new 乘客录入();
            MDIChild.MdiParent = this;
            MDIChild.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            车辆录入 MDIChild = new 车辆录入();
            MDIChild.MdiParent = this;
            MDIChild.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            线路录入 MDIChild = new 线路录入();
            MDIChild.MdiParent = this;
            MDIChild.Show();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            旅客管理系统 MDIChild = new 旅客管理系统();
            MDIChild.MdiParent = this;
            MDIChild.Show();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            旅客管理系统_姓名查询窗口_ MDIChild = new 旅客管理系统_姓名查询窗口_();
            MDIChild.MdiParent = this;
            MDIChild.Show();
        }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            旅客管理系统_车辆查询窗口_ MDIChild = new 旅客管理系统_车辆查询窗口_();
            MDIChild.MdiParent = this;
            MDIChild.Show();
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            车辆管理系统 MDIChild = new 车辆管理系统();
            MDIChild.MdiParent = this;
            MDIChild.Show();
        }

        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            车辆管理系统_驾驶员查询窗口_ MDIChild = new 车辆管理系统_驾驶员查询窗口_();
            MDIChild.MdiParent = this;
            MDIChild.Show();
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            车辆管理系统_车牌号查询窗口_ MDIChild = new 车辆管理系统_车牌号查询窗口_();
            MDIChild.MdiParent = this;
            MDIChild.Show();
        }

        private void 帮助文档HToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = @"..\软件使用说明书.doc";
            System.Diagnostics.Process.Start(path);
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            string path = @"..\软件使用说明书.doc";
            System.Diagnostics.Process.Start(path);
        }

    }
}
