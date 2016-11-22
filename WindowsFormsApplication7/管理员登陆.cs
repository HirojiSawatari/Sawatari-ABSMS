using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication7
{
    public partial class 管理员登陆 : Form
    {
        SqlConnection my_conn;
        public 管理员登陆()
        {
            InitializeComponent();
        }
        private void 管理员登陆_Load(object sender, EventArgs e)
        {
            C_conn c1 = new C_conn();
            my_conn = c1.get_conn();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            string user,s_se,pass;
            if (my_conn.State == ConnectionState.Closed)
            {
                my_conn.Open();
            }
            user = textBox1.Text.Trim();
            pass = textBox2.Text.Trim();
            Program.b = user;
            s_se = "select password from users where userid='" + user + "'";
            SqlCommand cmd = new SqlCommand(s_se, my_conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            if (textBox1.Text == string.Empty || textBox2.Text == string.Empty)
            {
                MessageBox.Show(this, "输入信息不完整，请重新输入！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (rdr.Read())
                {
                    string a = rdr["password"].ToString();
                    if (a == pass)
                    {
                        Program.a = true;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(this, "用户名或密码错误，请重新输入！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show(this, "此用户不存在，请重新输入！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            rdr.Close();
            my_conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        private void 管理员登陆_FormClosed(object sender, FormClosedEventArgs e)
        {
            安庆市客运中心管理系统 f2 = new 安庆市客运中心管理系统();
            f2.Show();   
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            找回密码 f3 = new 找回密码();
            f3.Show();
        }

    }
}
