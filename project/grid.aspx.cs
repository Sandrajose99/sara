using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace project
{
    public partial class grid : System.Web.UI.Page
    {
        Class1 cs = new Class1();
        string na1;
        protected void Page_Load(object sender, EventArgs e)
        {
            na1 = Session["uname"].ToString();
            if (!IsPostBack)
            {
                show();
            }
        }

        private void show()
        {
            DataSet sd = cs.select("select * from tb_ulog where username='" + na1 + "'");
            GridView1.DataSource = sd;
            GridView1.DataBind();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            LinkButton lntbn = sender as LinkButton;
            GridViewRow gvrow = lntbn.NamingContainer as GridViewRow;
            int gid = Convert.ToInt32(GridView1.DataKeys[gvrow.RowIndex].Value.ToString());
            int a = cs.exequery("delete from tb_ulog where id='" + gid + "'");
            show();
        }
    }
}