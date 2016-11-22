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
    public partial class 旅客购票窗口 : Form
    {
        SqlConnection my_conn;
        SqlDataAdapter my_adapter;
        DataSet my_ds;
        public 旅客购票窗口()
        {
            InitializeComponent();
        }

        private void 旅客购票窗口_Load(object sender, EventArgs e)
        {
            C_conn c1 = new C_conn();
            my_conn = c1.get_conn();
            my_adapter = new SqlDataAdapter("select * from line", my_conn);
            my_ds = new DataSet();
            my_adapter.Fill(my_ds, "type");
            comboBox1.DataSource = my_ds.Tables["type"];
            comboBox1.DisplayMember = my_ds.Tables["type"].Columns["busend"].ColumnName.ToString();
            comboBox1.ValueMember = my_ds.Tables["type"].Columns["busend"].ColumnName.ToString();
            my_conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (my_conn.State == ConnectionState.Closed)
            {
                my_conn.Open();
            }
            string be;
            be = comboBox1.SelectedValue.ToString();
            my_adapter = new SqlDataAdapter("select num from bus where busend='" + be + "'", my_conn);
            my_ds = new DataSet();
            my_adapter.Fill(my_ds, "type");
            comboBox2.DataSource = my_ds.Tables["type"];
            comboBox2.DisplayMember = my_ds.Tables["type"].Columns["num"].ColumnName.ToString();
            comboBox2.ValueMember = my_ds.Tables["type"].Columns["num"].ColumnName.ToString();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string be, s_end, s_select1, s_select2;
            be = comboBox1.SelectedValue.ToString();
            s_end = comboBox2.SelectedValue.ToString();
            s_select1 = "select gotime,chair from bus where num='" + s_end + "'";
            SqlCommand cmd1 = new SqlCommand(s_select1, my_conn);
            SqlDataReader rdr1 = cmd1.ExecuteReader();
            while (rdr1.Read())
            {
                string a = rdr1["gotime"].ToString();
                string b = rdr1["chair"].ToString();
                this.textBox4.Text = a;
                this.textBox6.Text = b;
            }
            rdr1.Close();
            s_select2 = "select usetime,cost from line where busend='" + be + "'";
            SqlCommand cmd2 = new SqlCommand(s_select2, my_conn);
            SqlDataReader rdr2 = cmd2.ExecuteReader();
            while (rdr2.Read())
            {
                string c = rdr2["cost"].ToString();
                string d = rdr2["usetime"].ToString();
                this.textBox3.Text = c;
                this.textBox5.Text = d;
            }
            rdr2.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ofdImage.ShowDialog() == DialogResult.OK)
            {
                this.pictureBox2.Image = Image.FromFile(ofdImage.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (my_conn.State == ConnectionState.Closed)
            {
                my_conn.Open();
            }
            string s_select, bn;
            bn = comboBox2.SelectedValue.ToString();
            s_select = "select chair from bus where num='" + bn + "'";
            SqlCommand cmd = new SqlCommand(s_select, my_conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                string a = rdr["chair"].ToString();
                int b = int.Parse(a);
                rdr.Close();
                DialogResult dresult = MessageBox.Show("确定购票？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dresult == DialogResult.Yes)
                {
                    if (textBox1.Text == string.Empty || textBox2.Text == string.Empty)
                    {
                        MessageBox.Show(this, "输入信息不完整，请重新输入！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (b == 0)
                        {
                            MessageBox.Show(this, "此车票已售罄！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            string s_insert1, i_a, i_b, i_c;
                            try
                            {
                                i_a = textBox2.Text.Trim();
                                i_b = textBox1.Text.Trim();
                                i_c = comboBox2.Text.Trim();
                                if (ofdImage.FileName != "")
                                {
                                    FileStream fs = new FileStream(ofdImage.FileName, FileMode.Open, FileAccess.Read);
                                    BinaryReader br = new BinaryReader(fs);
                                    byte[] byteImage = br.ReadBytes((int)fs.Length);
                                    s_insert1 = string.Format("insert into peo(photo,id,name,num) values (@photo,@id,@name,@num)");
                                    SqlCommand command = new SqlCommand(s_insert1, my_conn);
                                    command.Parameters.Add("@photo", SqlDbType.Image).Value = byteImage;
                                    command.Parameters.Add("@id", SqlDbType.Int, 4).Value = i_a;
                                    command.Parameters.Add("@name", SqlDbType.VarChar, 20).Value = i_b;
                                    command.Parameters.Add("@num", SqlDbType.Char, 10).Value = i_c;
                                    if (my_conn.State == ConnectionState.Closed)
                                    {
                                        my_conn.Open();
                                    }
                                    command.ExecuteNonQuery();
                                }
                                b = b - 1;
                                string ins = "update bus set chair='" + b + "'where num='" + bn + "'";
                                my_adapter = new SqlDataAdapter(ins, my_conn);
                                my_adapter.Fill(my_ds, "bus");
                                MessageBox.Show("购票成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            catch (System.Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                    }
                }
            }
            my_conn.Close();
        }
    }
}
