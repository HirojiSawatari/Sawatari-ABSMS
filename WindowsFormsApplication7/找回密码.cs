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
    public partial class 找回密码 : Form
    {
        SqlConnection my_conn;
        public 找回密码()
        {
            InitializeComponent();
        }

        private void 找回密码_Load(object sender, EventArgs e)
        {
            C_conn c1 = new C_conn();
            my_conn = c1.get_conn();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string s_name, s_num, s_select;
            if (my_conn.State == ConnectionState.Closed)
            {
                my_conn.Open();
            }
            s_name = textBox1.Text.Trim();
            s_num = textBox2.Text.Trim();
            s_select = "select jobnum,password from users where userid='" + s_name + "'";
            SqlCommand cmd = new SqlCommand(s_select, my_conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            if (textBox1.Text == string.Empty || textBox2.Text == string.Empty)
            {
                MessageBox.Show(this, "输入信息不完整，请重新输入！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (rdr.Read())
                {
                    string a = rdr["jobnum"].ToString();
                    if (a == s_num)
                    {
                        string b = rdr["password"].ToString();
                        this.textBox3.Text = b;
                    }
                    else
                    {
                        MessageBox.Show(this, "工号输入错误！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show(this, "此用户不存在！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            rdr.Close();
            my_conn.Close();
        }            
    }
}
