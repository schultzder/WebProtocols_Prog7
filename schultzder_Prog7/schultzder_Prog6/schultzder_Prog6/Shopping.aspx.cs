using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using schultzder_Prog6.App_Code;
using System.Data.SqlClient;
using System.Configuration;

namespace schultzder_Prog6
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SQLDataClass.getAllProducts();
            SQLDataClass.getAllCart();
            DisableText();
        }


        protected void DisableText()
        {
            TextBox2.Enabled = false;
            TextBox3.Enabled = false;
            TextBox4.Enabled = false;
            TextBox5.Enabled = false;
            TextBox6.Enabled = false;
            TextBox7.Enabled = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Button1.Text.Equals("Calculate"))
            {
                double qty = double.Parse(TextBox4.Text);
                Calculate(qty);
            }
            else
            {
                try
                {
                    Button1.Text = "Calculate";
                    TextBox1.Enabled = false;
                    for (int i = 0; i < SQLDataClass.tblProduct.Rows.Count; i++)
                    {
                        if (SQLDataClass.tblProduct.Rows[i][0].ToString().Equals(TextBox1.Text.ToString()))
                        {
                            TextBox2.Text = SQLDataClass.tblProduct.Rows[i][1].ToString();
                            TextBox3.Text = SQLDataClass.tblProduct.Rows[i][2].ToString();
                            
                        }
                    }
                    TextBox4.Enabled = true;
                }
                catch (Exception ex)
                {
                    TextArea1.InnerText = "Invalid ID " + ex.Message;
                    Button1.Text = "Submit";
                }
            }
        }

        protected void Calculate(double qty)
        {
            double unitPrice = double.Parse(TextBox3.Text.Replace("$", ""));

            double subTotal;
            double taxConst = 0.05;
            double taxTotal;
            double grandTotal;


            subTotal = qty * unitPrice;
            TextBox5.Text = string.Format("{0:C}", subTotal);
            taxTotal = subTotal * taxConst;
            TextBox6.Text = string.Format("{0:C}", taxTotal);
            grandTotal = taxTotal + subTotal;
            TextBox7.Text = string.Format("{0:C}", grandTotal);

            subTotal = 0;
            grandTotal = 0;
            taxTotal = 0;
        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            TextBox1.Enabled = true;
            TextBox2.Enabled = false;
            TextBox3.Enabled = false;
            TextBox4.Enabled = false;
            TextBox5.Enabled = false;
            TextBox6.Enabled = false;
            TextBox7.Enabled = false;

            Button1.Text = "Submit";

            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
            TextBox7.Text = "";
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < SQLDataClass.tblCart.Rows.Count; i++)
                {
                    if (SQLDataClass.tblCart.Rows[i][0].ToString().Equals(TextBox1.Text.ToString()))
                    {
                        try
                        {
                            string theID = TextBox1.Text;
                            string newName = TextBox2.Text;
                            double newPrice = double.Parse(TextBox3.Text.Replace("$", ""));
                            int newQty = int.Parse(TextBox4.Text);
                            double newTotal = double.Parse(TextBox7.Text.Replace("$", ""));


                            SQLDataClass.UpdateCart(theID, newName, newQty, newPrice, newTotal);
                            SQLDataClass.getAllCart();
                        }
                        catch (Exception ex)
                        {
                            TextArea1.InnerText = "Product Not Updated:" + ex.Message;
                        }
                    }
                }
                Guid newGuid = Guid.NewGuid();
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["UWPCS3870ConnectionString"].ConnectionString);
                conn.Open();
                String insertQuery = "Insert into Cart(CartProdID, CartProdName, CartProdQty, CartProdUnitPrice, CartProdCost) values(@CID, @CName, @CQty, @CUnitPrice, @CTotal)";
                SqlCommand comm = new SqlCommand(insertQuery, conn);
                comm.Parameters.AddWithValue("@CID", TextBox1.Text);
                comm.Parameters.AddWithValue("@CName", TextBox2.Text);
                comm.Parameters.AddWithValue("@CQty", TextBox4.Text);
                comm.Parameters.AddWithValue("@CUnitPrice", TextBox3.Text);
                comm.Parameters.AddWithValue("@CTotal", TextBox7.Text);
                comm.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                Response.Write("Error:" + ex.ToString());
            }
        }
    }
}