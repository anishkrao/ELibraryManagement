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
    public partial class WebForm2 : System.Web.UI.Page
    {
        string strconnect1 = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try { 
                SqlConnection sqlConnection = new SqlConnection(strconnect1);

                if (sqlConnection.State == System.Data.ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }
            
                SqlCommand cmd = new SqlCommand("select * from Member where member_id='"+TextBox1.Text.Trim()+"' and password='"+TextBox2.Text.Trim()+"'",sqlConnection);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Session["username"] = dr.GetValue(8).ToString();
                        Session["fullname"] = dr.GetValue(0).ToString();
                        Session["role"] = "user";
                        Session["status"] = dr.GetValue(10).ToString();
                    }
                    Response.Redirect("HomePage.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Invalid Credentials')</script>");
                }
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('"+ex.Message+"')</script>");
            }


        }
    }
}