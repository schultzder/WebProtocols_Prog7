using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace schultzder_Prog6
{
    public partial class SetRoles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            if (!IsPostBack)
            {
                string role;
                
                role = "Admin";
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["UWPCS3870ConnectionString"].ConnectionString);
                conn.Open();
                string insertQuery = "Select UserName From Users where Role = '" + role + "'";
                SqlCommand com = new SqlCommand(insertQuery, conn);
                SqlDataAdapter sda = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                sda.Fill(dt);
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["UWPCS3870ConnectionString"].ConnectionString);
                conn.Open();
                string insertQuery = "delete from Users where Username = '" + DropDownListUser.SelectedValue.ToString() + "'";
                SqlCommand com = new SqlCommand(insertQuery, conn);
                com.ExecuteNonQuery();
                conn.Close();

            }
            catch (Exception ex)
            {
                Response.Write("Error:" + ex.ToString());
            }
        }

        protected void btnRemoveRoleUser_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["UWPCS3870ConnectionString"].ConnectionString);
                conn.Open();
                string insertQuery = "update Users set Role = null where Username = '" + DropDownListUser.SelectedValue.ToString() + "'";
                SqlCommand com = new SqlCommand(insertQuery, conn);
                com.ExecuteNonQuery();
                conn.Close();
                txtErrorMessage.Text = DropDownListUser.SelectedValue.ToString() + " removed from role: " + DropDownList1.SelectedValue.ToString();
            }
            catch (Exception ex)
            {
                Response.Write("Error:" + ex.ToString());
            }
        }

        protected void btnAddRoleUser_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["UWPCS3870ConnectionString"].ConnectionString);
                conn.Open();
                string insertQuery = "update Users set Role = '" + DropDownList1.SelectedValue.ToString() + "' where Username = '" + DropDownList3.SelectedValue.ToString() + "'";
                SqlCommand com = new SqlCommand(insertQuery, conn);
                com.ExecuteNonQuery();
                conn.Close();
                txtErrorMessage.Text = DropDownList3.SelectedValue.ToString() + " changed to role: " + DropDownList1.SelectedValue.ToString();
            }
            catch (Exception ex)
            {
                Response.Write("Error:" + ex.ToString());
            }
        }

        protected void DDLRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string role;
                role = DropDownList1.SelectedValue.ToString();
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["UWPCS3870ConnectionString"].ConnectionString);
                conn.Open();
                string insertQuery = "Select UserName From Users where Role = '" + role + "'";
                SqlCommand com = new SqlCommand(insertQuery, conn);
                SqlDataAdapter sda = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                DropDownList3.DataSource = dt;
                DropDownList3.DataBind();
                DropDownList3.DataTextField = "UserName";
                DropDownList3.DataValueField = "UserName";
                DropDownList3.DataBind();
                //com.ExecuteNonQuery();
                //conn.Close();
            }
            catch (Exception ex)
            {
                Response.Write("Error:" + ex.ToString());
            }
        }

        protected void btnAddRole_Click(object sender, EventArgs e)
        {
            try
            {
                ListItem item = new ListItem();
                item.Text = TextBox1.Text;
                DropDownList1.Items.Add(item);
            }
            catch (Exception ex)
            {
                Response.Write("Error:" + ex.ToString());
            }
        }

        protected void btnRemoveRole_Click(object sender, EventArgs e)
        {
            try
            {
                string role;
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["UWPCS3870ConnectionString"].ConnectionString);
                conn.Open();
                string insertQuery = "update Users set Role = null where Role = '" + DropDownList1.SelectedValue.ToString() + "'";
                SqlCommand com = new SqlCommand(insertQuery, conn);
                com.ExecuteNonQuery();
                conn.Close();
                role = DropDownList1.SelectedValue.ToString();
                DropDownList1.Items.RemoveAt(DropDownList1.SelectedIndex);
                txtErrorMessage.Text = role + " role removed";
            }
            catch (Exception ex)
            {
                Response.Write("Error:" + ex.ToString());
            }
        }
    }
}