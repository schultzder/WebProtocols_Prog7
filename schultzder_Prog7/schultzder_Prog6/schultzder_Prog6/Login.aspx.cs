using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using schultzder_Prog6.App_Code;

namespace schultzder_Prog6
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SQLDataClass.getAllLogin();
            Label5.Visible = false;
            if (CheckBox1.Checked)
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < SQLDataClass.tblLogin.Rows.Count; i++)
                {
                    if (SQLDataClass.tblLogin.Rows[i][0].ToString().Equals(TextBox1.Text.ToString())
                        && SQLDataClass.tblLogin.Rows[i][1].ToString().Equals(TextBox2.Text.ToString()))
                    {
                        Label5.Visible = false;
                        Response.Redirect("Default.aspx");
                    }
                    else
                    {
                        Label5.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}