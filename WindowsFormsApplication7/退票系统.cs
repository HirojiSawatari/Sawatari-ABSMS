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
    public partial class 退票系统 : Form
    {
        SqlConnection my_conn;
        SqlDataAdapter my_adapter;
        DataSet my_ds;
        public 退票系统()
        {
            InitializeComponent();
        }

        private void 退票系统_Load(object sender, EventArgs e)
        {
            C_conn c1 = new C_conn();
            my_conn = c1.get_conn();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dresult = MessageBox.Show("确定退票？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dresult == DialogResult.Yes)
            {
                if (textBox1.Text.Trim() == "")
                {
                    MessageBox.Show("输入信息不完整！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    string d_name, bn, s_select;
                    d_name = textBox1.Text.Trim();
                    string se = "select num from peo where name='" + d_name + "'";
                    SqlCommand cmd1 = new SqlCommand(se, my_conn);
                    SqlDataReader rdr1 = cmd1.ExecuteReader();
                    if (rdr1.Read())
                    {
                        bn = rdr1["num"].ToString();
                        rdr1.Close();
                        string sqlStrDel = "delete from peo where name='" + d_name + "'";
                        SqlCommand my_comm = new SqlCommand(sqlStrDel, my_conn);
                        if (my_conn.State == ConnectionState.Closed)
                        {
                            my_conn.Open();
                        }
                        my_comm.ExecuteNonQuery();
                        s_select = "select chair from bus where num='" + bn + "'";
                        SqlCommand cmd = new SqlCommand(s_select, my_conn);
                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.Read())
                        {
                            string a = rdr["chair"].ToString();
                            int b = int.Parse(a);
                            rdr.Close();
                            b = b + 1;
                            string ins = "update bus set chair='" + b + "'where num='" + bn + "'";
                            my_ds = new DataSet();
                            my_adapter = new SqlDataAdapter(ins, my_conn);
                            my_adapter.Fill(my_ds, "bus");
                        }
                        MessageBox.Show("已退票！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("此人未订票！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        rdr1.Close();
                    }
                }
            }
        }
    }
}
