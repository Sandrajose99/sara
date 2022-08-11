using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace project
{
    public partial class login : System.Web.UI.Page
    {
        Class1 cs = new Class1();
        
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["uname"] = TextBox1.Text;
            SqlDataReader dr = cs.read("select * from tb_ulog where username='" + TextBox1.Text + "' and password='" + TextBox2.Text + "'");
            if (dr.Read())
            {
                Response.Redirect("grid.aspx");
            }
        }
    }
}