using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryManagement
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        string sqlconnection2 = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlcon = new SqlConnection(sqlconnection2);

                if(sqlcon.State == System.Data.ConnectionState.Closed)
                {
                    sqlcon.Open();
                }

                SqlCommand cmd = new SqlCommand("select * from Admin where username='"+TextBox1.Text.Trim()+"' and password='"+TextBox2.Text.Trim()+"'",sqlcon);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        
                         Session["username"] = dr.GetValue(0).ToString();
                         Session["fullname"] = dr.GetValue(2).ToString();
                         Session["role"] = "admin";
                        
                        Response.Redirect("HomePage.aspx");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Invalid Credentials')</script>");
                }
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");

            }
        }
    }
}