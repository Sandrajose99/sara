using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace project
{
    public partial class reg : System.Web.UI.Page
    {
        Class1 cs = new Class1();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string s = "~/img/" + FileUpload1.FileName;
            FileUpload1.SaveAs(MapPath(s));
            int a = cs.exequery("insert into tb_ulog(username,password,emailid,mobileno,country,image)values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + DropDownList1.SelectedValue + "','" + s + "')");
            if (a > 0)
            {
                Response.Write("Inserted");
            }
            Response.Redirect("home.aspx");
        }
    }
}