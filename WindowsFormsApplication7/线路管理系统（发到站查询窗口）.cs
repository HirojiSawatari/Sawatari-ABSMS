using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace WindowsFormsApplication7
{
    public partial class 线路管理系统_发到站查询窗口_ : Form
    {
        SqlConnection my_conn;
        SqlDataAdapter my_adapter;
        DataSet my_ds;
        BindingSource my_bind, my_bind2, my_bind3;
        public 线路管理系统_发到站查询窗口_()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 线路管理系统_发到站查询窗口__Load(object sender, EventArgs e)
        {
            C_conn c1 = new C_conn();
            my_conn = c1.get_conn();
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox8.Enabled = false;
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
            string s_end,s_select;
            s_end = comboBox1.SelectedValue.ToString();
            if (my_conn.State == ConnectionState.Closed)
            {
                my_conn.Open();
            }
            s_select = "select * from line where busend='" + s_end + "'";
            my_adapter = new SqlDataAdapter(s_select, my_conn);
            my_adapter.Fill(my_ds, "users");
            SqlCommandBuilder my_cb = new SqlCommandBuilder(my_adapter);
            my_bind = new BindingSource();
            my_bind.DataSource = my_ds;
            my_bind.DataMember = "users";
            dataGridView1.DataSource = my_bind;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Columns["busend"].HeaderText = "发到站";
            dataGridView1.Columns["busend"].Width = 80;
            dataGridView1.Columns["cost"].HeaderText = "票价";
            dataGridView1.Columns["cost"].Width = 80;
            dataGridView1.Columns["usetime"].HeaderText = "路程用时";
            dataGridView1.Columns["usetime"].Width = 80;
            textBox1.DataBindings.Clear();
            textBox2.DataBindings.Clear();
            textBox1.DataBindings.Add("text", my_bind, "usetime");
            textBox2.DataBindings.Add("text", my_bind, "cost");
            bindingNavigator1.DataBindings.Clear();
            bindingNavigator1.BindingSource = my_bind;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            string s_end, s_select;
            s_end = dataGridView1.CurrentRow.Cells["busend"].Value.ToString();
            if (my_conn.State == ConnectionState.Closed)
            {
                my_conn.Open();
            }
            s_select = "select num,drivername,gotime,chair from bus where busend='" + s_end + "'";
            my_adapter = new SqlDataAdapter(s_select, my_conn);
            DataSet my_ds2 = new DataSet();
            my_adapter.Fill(my_ds2, "bus");
            my_bind2 = new BindingSource();
            my_bind2.DataSource = my_ds2;
            my_bind2.DataMember = "bus";
            dataGridView2.DataSource = my_bind2;
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.Columns["num"].HeaderText = "车牌号";
            dataGridView2.Columns["num"].Width = 100;
            dataGridView2.Columns["drivername"].HeaderText = "驾驶员";
            dataGridView2.Columns["drivername"].Width = 80;
            dataGridView2.Columns["gotime"].HeaderText = "发车时间";
            dataGridView2.Columns["gotime"].Width = 80;
            dataGridView2.Columns["chair"].HeaderText = "座位数";
            dataGridView2.Columns["chair"].Width = 80;
            textBox3.DataBindings.Clear();
            textBox4.DataBindings.Clear();
            textBox7.DataBindings.Clear();
            textBox8.DataBindings.Clear();
            textBox3.DataBindings.Add("text", my_bind2, "num");
            textBox4.DataBindings.Add("text", my_bind2, "drivername");
            textBox7.DataBindings.Add("text", my_bind2, "gotime");
            textBox8.DataBindings.Add("text", my_bind2, "chair");
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            string s_num, s_select;
            s_num = dataGridView2.CurrentRow.Cells["num"].Value.ToString();
            if (my_conn.State == ConnectionState.Closed)
            {
                my_conn.Open();
            }
            s_select = "select id,name from peo where num='" + s_num + "'";
            my_adapter = new SqlDataAdapter(s_select, my_conn);
            DataSet my_ds3 = new DataSet();
            my_adapter.Fill(my_ds3, "name");
            my_bind3 = new BindingSource();
            my_bind3.DataSource = my_ds3;
            my_bind3.DataMember = "name";
            dataGridView3.DataSource = my_bind3;
            dataGridView3.AllowUserToAddRows = false;
            dataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView3.Columns["id"].HeaderText = "乘客编号";
            dataGridView3.Columns["id"].Width = 80;
            dataGridView3.Columns["name"].HeaderText = "乘客姓名";
            dataGridView3.Columns["name"].Width = 100;
            this.textBox5.Text = "";
            this.textBox6.Text = "";
            this.pictureBox2.Image = null;
            textBox5.DataBindings.Clear();
            textBox6.DataBindings.Clear();
            textBox5.DataBindings.Add("text", my_bind3, "name");
            textBox6.DataBindings.Add("text", my_bind3, "id");
            this.ShowImage();
        }

        private void dataGridView3_SelectionChanged(object sender, EventArgs e)
        {
            this.ShowImage();
        }

        private void ShowImage()
        {
            if (my_conn.State == ConnectionState.Closed)
            {
                my_conn.Open();
            }
            if (textBox6.Text == "")
            {
                ;
            }
            else
            {
                string s_id = textBox5.Text.Trim();
                if (s_id == "")
                {
                    ;
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("select photo from peo where name='" + s_id + "'", my_conn);
                    byte[] b = (byte[])cmd.ExecuteScalar();
                    if (b.Length > 0)
                    {
                        MemoryStream stream = new MemoryStream(b, true);
                        stream.Write(b, 0, b.Length);
                        pictureBox2.Image = new Bitmap(stream);
                        stream.Close();
                    }
                }
            }
            my_conn.Close();
        }

    }
}
