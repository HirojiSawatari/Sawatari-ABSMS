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
    public partial class 旅客管理系统 : Form
    {
        SqlConnection my_conn;
        SqlDataAdapter my_adapter;
        DataSet my_ds;
        BindingSource my_bind;
        public 旅客管理系统()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            C_conn c1 = new C_conn();
            my_conn = c1.get_conn();
            if (textBox1.Text.Trim() == "")
            {

                this.pictureBox2.Image = null;
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = false;
                button8.Enabled = false;
                button9.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s_end, s_select;
            s_end = textBox4.Text.Trim();
            if (my_conn.State == ConnectionState.Closed)
            {
                my_conn.Open();
            }
            s_select = "select id,name,num from peo where id like'" + s_end + "%'";
            my_adapter = new SqlDataAdapter(s_select, my_conn);
            my_ds = new DataSet();
            SqlCommandBuilder my_cb = new SqlCommandBuilder(my_adapter);
            my_adapter.Fill(my_ds, "users");
            my_conn.Close();
            my_bind = new BindingSource();
            my_bind.DataSource = my_ds;
            my_bind.DataMember = "users";
            dataGridView1.DataSource = my_bind;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Columns["id"].HeaderText = "编号";
            dataGridView1.Columns["id"].Width = 80;
            dataGridView1.Columns["name"].HeaderText = "姓名";
            dataGridView1.Columns["name"].Width = 80;
            dataGridView1.Columns["num"].HeaderText = "所乘客车车牌号";
            dataGridView1.Columns["num"].Width = 120;
            textBox1.DataBindings.Clear();
            textBox2.DataBindings.Clear();
            textBox3.DataBindings.Clear();
            textBox1.DataBindings.Add("text", my_bind, "id");
            textBox2.DataBindings.Add("text", my_bind, "name");
            textBox3.DataBindings.Add("text", my_bind, "num");
            bindingNavigator1.DataBindings.Clear();
            bindingNavigator1.BindingSource = my_bind;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
            this.ShowImage();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            my_bind.MoveFirst();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            my_bind.MoveNext();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            my_bind.MovePrevious();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            my_bind.MoveLast();
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
            string s_select, bn;
            bn = textBox3.Text.Trim();
            s_select = "select chair from bus where num='" + bn + "'";
            SqlCommand cmd = new SqlCommand(s_select, my_conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                string a = rdr["chair"].ToString();
                int b = int.Parse(a);
                rdr.Close();
                DialogResult dresult = MessageBox.Show("确定保存？（此窗口无法导入照片）", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dresult == DialogResult.Yes)
                {
                    if (b == 0)
                    {
                        MessageBox.Show(this, "此车票已售罄！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
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
                        b = b - 1;
                        string ins = "update bus set chair='" + b + "'where num='" + bn + "'";
                        my_adapter = new SqlDataAdapter(ins, my_conn);
                        my_adapter.Fill(my_ds, "bus");
                        MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string d_id, bn, s_select;
            d_id = textBox1.Text.Trim();
            bn = textBox3.Text.Trim();
            string sqlStrDel = "delete from peo where id='" + d_id + "'";
            SqlCommand my_comm = new SqlCommand(sqlStrDel, my_conn);
            my_conn.Open();
            my_comm.ExecuteNonQuery();
            dataGridView1.DataBindings.Clear();
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
                my_adapter = new SqlDataAdapter(ins, my_conn);
                my_adapter.Fill(my_ds, "bus");
            }
            MessageBox.Show("已删除！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            this.ShowImage();
        }

        private void ShowImage()
        {
            if (my_conn.State == ConnectionState.Closed)
            {
                my_conn.Open();
            }
            string a = textBox1.Text.Trim();
            if (a == "")
            {
                ;
            }
            else
            {
                string s_id = textBox1.Text.Trim().ToString();
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
