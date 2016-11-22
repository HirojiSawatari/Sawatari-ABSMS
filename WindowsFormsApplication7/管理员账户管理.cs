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
    public partial class 管理员账户管理 : Form
    {
        SqlConnection my_conn;
        SqlDataAdapter my_adapter;
        DataSet my_ds;
        BindingSource my_bind;
        public 管理员账户管理()
        {
            InitializeComponent();
        }

        private void 管理员账户管理_Load(object sender, EventArgs e)
        {
            C_conn c1 = new C_conn();
            my_conn = c1.get_conn();
            my_adapter = new SqlDataAdapter("select * from users", my_conn);
            SqlCommandBuilder my_cb = new SqlCommandBuilder(my_adapter);
            my_ds = new DataSet();
            my_adapter.Fill(my_ds, "users");
            my_conn.Close();
            my_bind = new BindingSource();
            my_bind.DataSource = my_ds;
            my_bind.DataMember = "users";
            dataGridView1.DataSource = my_bind;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Columns["userid"].HeaderText = "用户名";
            dataGridView1.Columns["userid"].Width = 120;
            dataGridView1.Columns["password"].HeaderText = "密码";
            dataGridView1.Columns["password"].Width = 120;
            dataGridView1.Columns["jobnum"].HeaderText = "职工号";
            dataGridView1.Columns["jobnum"].Width = 120;
            textBox1.DataBindings.Clear();
            textBox2.DataBindings.Clear();
            textBox3.DataBindings.Clear();
            textBox1.DataBindings.Add("text", my_bind, "userid");
            textBox2.DataBindings.Add("text", my_bind, "password");
            textBox3.DataBindings.Add("text", my_bind, "jobnum");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            my_bind.AddNew();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string d_id;
            d_id = textBox1.Text.Trim();
            string sqlStrDel = "delete from users where userid='" + d_id + "'";
            SqlCommand my_comm = new SqlCommand(sqlStrDel, my_conn);
            my_conn.Open();
            my_comm.ExecuteNonQuery();
            dataGridView1.DataBindings.Clear();
            MessageBox.Show("已删除！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dresult = MessageBox.Show("确定保存？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dresult == DialogResult.Yes)
            {
                try
                {
                    this.Validate();
                    my_bind.EndEdit();
                    my_adapter.Update(my_ds, "users");
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
