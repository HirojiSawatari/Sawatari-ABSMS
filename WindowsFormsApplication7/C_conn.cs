using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace WindowsFormsApplication7
{
    class C_conn
    {
        string s_conn;
        SqlConnection c_my_conn;

        public SqlConnection get_conn()
        {
            s_conn = global::WindowsFormsApplication7.Properties.Settings.Default.connString;
            c_my_conn = new SqlConnection(s_conn);
            c_my_conn.Open();
            return c_my_conn;
        }
    }
}
