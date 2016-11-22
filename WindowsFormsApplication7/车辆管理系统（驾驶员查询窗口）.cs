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
    public partial class 车辆管理系统_驾驶员查询窗口_ : Form
    {
        SqlConnection my_conn;
        SqlDataAdapter my_adapter;
        DataSet my_ds;
        BindingSource my_bind, my_bind2;
        public 车辆管理系统_驾驶员查询窗口_()
        {
            InitializeComponent();
        }

        private void 车辆管理系统_驾驶员查询窗口__Load(object sender, EventArgs e)
        {
            C_conn c1 = new C_conn();
            my_conn = c1.get_conn();
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            if (textBox1.Text.Trim() == "")
            {
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
            }
            my_ds = new DataSet();
            my_adapter = new SqlDataAdapter("select * from bus", my_conn);
            my_adapter.Fill(my_ds, "type");
            comboBox1.DataSource = my_ds.Tables["type"];
            comboBox1.DisplayMember = my_ds.Tables["type"].Columns["drivername"].ColumnName.ToString();
            comboBox1.ValueMember = my_ds.Tables["type"].Columns["drivername"].ColumnName.ToString();
            my_conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s_end;
            s_end = comboBox1.SelectedValue.ToString();
            if (my_conn.State == ConnectionState.Closed)
            {
                my_conn.Open();
            }
            //DataSet my_ds1 = new DataSet();
            string s_select;
            s_select = "select * from bus where drivername='" + s_end + "'";
            my_adapter = new SqlDataAdapter(s_select, my_conn);
            my_adapter.Fill(my_ds, "users");
            SqlCommandBuilder my_cb = new SqlCommandBuilder(my_adapter);
            my_bind = new BindingSource();
            my_bind.DataSource = my_ds;
            my_bind.DataMember = "users";
            dataGridView1.DataSource = my_bind;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Columns["num"].HeaderText = "车牌号";
            dataGridView1.Columns["num"].Width = 100;
            dataGridView1.Columns["busend"].HeaderText = "发到站";
            dataGridView1.Columns["busend"].Width = 80;
            dataGridView1.Columns["drivername"].HeaderText = "驾驶员";
            dataGridView1.Columns["drivername"].Width = 80;
            dataGridView1.Columns["gotime"].HeaderText = "发车时间";
            dataGridView1.Columns["gotime"].Width = 80;
            dataGridView1.Columns["chair"].HeaderText = "座位数";
            dataGridView1.Columns["chair"].Width = 80;
            textBox1.DataBindings.Clear();
            textBox2.DataBindings.Clear();
            textBox3.DataBindings.Clear();
            textBox6.DataBindings.Clear();
            textBox7.DataBindings.Clear();
            textBox1.DataBindings.Add("text", my_bind, "num");
            textBox2.DataBindings.Add("text", my_bind, "drivername");
            textBox3.DataBindings.Add("text", my_bind, "busend");
            textBox6.DataBindings.Add("text", my_bind, "gotime");
            textBox7.DataBindings.Add("text", my_bind, "chair");
            bindingNavigator1.DataBindings.Clear();
            bindingNavigator1.BindingSource = my_bind;
            button3.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            my_bind.AddNew();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (my_conn.State == ConnectionState.Closed)
            {
                my_conn.Open();
            }
            SqlCommandBuilder my_cb = new SqlCommandBuilder(my_adapter);
            string d_end;
            d_end = textBox3.Text.Trim();
            string sqlStrDel = "delete from bus where busend='" + d_end + "';delete from line where busend='" + d_end + "'";
            SqlCommand my_comm = new SqlCommand(sqlStrDel, my_conn);
            my_comm.ExecuteNonQuery();
            dataGridView1.DataBindings.Clear();
            MessageBox.Show("已删除！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlCommandBuilder my_cb = new SqlCommandBuilder(my_adapter);
            DialogResult dresult = MessageBox.Show("确定保存？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dresult == DialogResult.Yes)
            {
                try
                {
                    string s_insert1, s_insert2, i_a, i_b, i_c;
                    i_a = textBox1.Text.Trim();
                    i_b = textBox2.Text.Trim();
                    i_c = textBox3.Text.Trim();
                    s_insert1 = "insert into bus(num,drivername,busend) values ('" + i_a + "','" + i_b + "','" + i_c + "')";
                    my_adapter = new SqlDataAdapter(s_insert1, my_conn);
                    my_adapter.Fill(my_ds, "users");
                    s_insert2 = "insert into line(busend) values ('" + i_c + "')";
                    my_adapter = new SqlDataAdapter(s_insert2, my_conn);
                    my_adapter.Fill(my_ds, "users");
                    MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            string s_num, s_select;
            string a = textBox1.Text.Trim();
            if (a == "")
            {
                ;
            }
            else
            {
                s_num = dataGridView1.CurrentRow.Cells["num"].Value.ToString();
                if (my_conn.State == ConnectionState.Closed)
                {
                    my_conn.Open();
                }
                s_select = "select id,name from peo where num ='" + s_num + "'";
                my_adapter = new SqlDataAdapter(s_select, my_conn);
                DataSet my_ds2 = new DataSet();
                my_adapter.Fill(my_ds2, "peo");
                my_bind2 = new BindingSource();
                my_bind2.DataSource = my_ds2;
                my_bind2.DataMember = "peo";
                dataGridView2.DataSource = my_bind2;
                dataGridView2.AllowUserToAddRows = false;
                dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView2.Columns["id"].HeaderText = "编号";
                dataGridView2.Columns["id"].Width = 60;
                dataGridView2.Columns["name"].HeaderText = "姓名";
                dataGridView2.Columns["name"].Width = 80;
                this.textBox4.Text = "";
                this.textBox5.Text = "";
                this.pictureBox2.Image = null;
                textBox4.DataBindings.Clear();
                textBox5.DataBindings.Clear();
                textBox4.DataBindings.Add("text", my_bind2, "name");
                textBox5.DataBindings.Add("text", my_bind2, "id");
                this.ShowImage();
            }
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            this.ShowImage();
        }

        private void ShowImage()
        {
            if (my_conn.State == ConnectionState.Closed)
            {
                my_conn.Open();
            }
            string a = textBox5.Text.Trim();
            if (a == "")
            {
                ;
            }
            else
            {
                string s_id = textBox5.Text.Trim().ToString();
                SqlCommand cmd = new SqlCommand("select photo from peo where id='" + s_id + "'", my_conn);
                byte[] b = (byte[])cmd.ExecuteScalar();
                if (b.Length > 0)
                {
                    MemoryStream stream = new MemoryStream(b, true);
                    stream.Write(b, 0, b.Length);
                    pictureBox2.Image = new Bitmap(stream);
                    stream.Close();
                }
            }
            my_conn.Close();
        }
    }
}
