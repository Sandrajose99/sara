using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace project
{
    public class Class1
    {
        SqlConnection con;
        SqlCommand cmd;
        public Class1()
        {
            con = new SqlConnection(@"Data Source=DESKTOP-M95QN9I;Initial Catalog=db_nissy;Integrated Security=True");
        }
        public int exequery(string str)
        {
            if(con.State==ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            cmd = new SqlCommand(str, con);
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
        public SqlDataReader read(string str)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            cmd = new SqlCommand(str, con);
            SqlDataReader rdr = cmd.ExecuteReader();
            return rdr;
        }
        public DataSet select(string str)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            cmd = new SqlCommand(str, con);
            SqlDataAdapter adt = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adt.Fill(ds);
            con.Close();
            return ds;
        }
    }
}