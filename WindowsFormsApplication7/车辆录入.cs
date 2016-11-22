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
    public partial class 车辆录入 : Form
    {
        SqlConnection my_conn;
        SqlDataAdapter my_adapter;
        DataSet my_ds;
        public 车辆录入()
        {
            InitializeComponent();
        }

        private void 车辆录入_Load(object sender, EventArgs e)
        {
            C_conn c1 = new C_conn();
            my_conn = c1.get_conn();
            my_ds = new DataSet();
            my_adapter = new SqlDataAdapter("select * from line", my_conn);
            my_adapter.Fill(my_ds, "type");
            comboBox1.DataSource = my_ds.Tables["type"];
            comboBox1.DisplayMember = my_ds.Tables["type"].Columns["busend"].ColumnName.ToString();
            comboBox1.ValueMember = my_ds.Tables["type"].Columns["busend"].ColumnName.ToString();
            my_conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dresult = MessageBox.Show("确定输入？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dresult == DialogResult.Yes)
            {
                if (textBox1.Text == string.Empty || textBox2.Text == string.Empty)
                {
                    MessageBox.Show(this, "输入信息不完整，请重新输入！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    try
                    {
                        string s_insert1, i_a, i_b, i_c, i_d, i_e;
                        i_a = textBox1.Text.Trim();
                        i_b = textBox2.Text.Trim();
                        i_c = comboBox1.Text.Trim();
                        i_d = textBox3.Text.Trim();
                        i_e = textBox4.Text.Trim();
                        s_insert1 = "insert into bus(num,drivername,busend,gotime,chair) values ('" + i_a + "','" + i_b + "','" + i_c + "','" + i_d + "','" + i_e + "')";
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

