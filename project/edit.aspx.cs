using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace project
{
    public partial class edit : System.Web.UI.Page
    {
        Class1 cs = new Class1();
        string gid, na1;
        protected void Page_Load(object sender, EventArgs e)
        {
            gid = Request.Params["sid"].ToString();
            na1 = Session["uname"].ToString();
            if (!IsPostBack)
            {
                showed();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string s = "~/img/" + FileUpload1.FileName;
            FileUpload1.SaveAs(MapPath(s));
            int a = cs.exequery("update tb_ulog set username='" + TextBox1.Text + "',password='" + TextBox2.Text + "',emailid='" + TextBox3.Text + "',mobileno='" + TextBox4.Text + "',country='" + DropDownList1.SelectedValue + "',image='" + s + "'where id='"+gid+"' and username='"+na1+"'");
            if (a > 0)
            {
                Response.Redirect("grid.aspx");
            }
        }

        private void showed()
        {
            SqlDataReader dr = cs.read("select * from tb_ulog where id='" + gid + "'");
            if (dr.Read())
            {
                TextBox1.Text = dr["username"].ToString();
                TextBox2.Text = dr["password"].ToString();
                TextBox3.Text = dr["emailid"].ToString();
                TextBox4.Text = dr["mobileno"].ToString();
                DropDownList1.SelectedValue = dr["country"].ToString();
                Image1.ImageUrl = dr["image"].ToString();
            }

        }
    }
}