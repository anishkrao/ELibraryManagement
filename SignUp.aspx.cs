using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryManagement
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        string strconnect = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (CheckMemberId())
            {
                Response.Write("<script>alert('Member ID already exists. Please change your ID')</script>");
            }
            else
            {
                SignUpUser();
            }
            
        }

        protected void SignUpUser()
        {
            try
            {
                SqlConnection sqlcon = new SqlConnection(strconnect);

                if (sqlcon.State == System.Data.ConnectionState.Closed)
                {
                    sqlcon.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO Member(full_name,dob,contact_no,email,state,city,pincode,full_address,member_id,password,account_status) VALUES(@full_name,@dob,@contact_no,@email,@state,@city,@pincode,@full_address,@member_id,@password,@account_status)", sqlcon);


                cmd.Parameters.AddWithValue("@full_name", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@dob", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@contact_no", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@email", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@state", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@city", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@pincode", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@full_address", TextBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@member_id", TextBox8.Text.Trim());
                cmd.Parameters.AddWithValue("@password", TextBox9.Text.Trim());
                cmd.Parameters.AddWithValue("@account_status", "pending");

                cmd.ExecuteNonQuery();
                sqlcon.Close();

                Response.Write("<script>alert('Sign Up Successful. Redirecting to Login Page')</script>");

                Response.Redirect("UserLogin.aspx");

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

        protected bool CheckMemberId()
        {

            try
            {
                SqlConnection sqlcon = new SqlConnection(strconnect);

                if (sqlcon.State == System.Data.ConnectionState.Closed)
                {
                    sqlcon.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM Member WHERE member_id='" + TextBox8.Text.Trim() + "'", sqlcon);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
                return false;
            }

            
        }
    }
}