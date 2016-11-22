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
    public partial class 线路录入 : Form
    {
        SqlConnection my_conn;
        SqlDataAdapter my_adapter;
        DataSet my_ds;
        public 线路录入()
        {
            InitializeComponent();
        }

        private void 线路录入_Load(object sender, EventArgs e)
        {
            C_conn c1 = new C_conn();
            my_conn = c1.get_conn();
            my_ds = new DataSet();
            my_adapter = new SqlDataAdapter("select * from line", my_conn);
            my_adapter.Fill(my_ds, "type");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dresult = MessageBox.Show("确定输入？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dresult == DialogResult.Yes)
            {
                if (textBox1.Text == string.Empty || textBox2.Text == string.Empty|| textBox3.Text == string.Empty)
                {
                    MessageBox.Show(this, "输入信息不完整，请重新输入！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    try
                    {
                        string s_insert1, i_a, i_b, i_c;
                        i_a = textBox1.Text.Trim();
                        i_b = textBox2.Text.Trim();
                        i_c = textBox3.Text.Trim();
                        s_insert1 = "insert into line(busend,usetime,cost) values ('" + i_a + "','" + i_b + "','" + i_c + "')";
                        my_adapter = new SqlDataAdapter(s_insert1, my_conn);
                        my_adapter.Fill(my_ds, "users");
                        MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
    }
}
