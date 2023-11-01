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
    public partial class MemberManagement : System.Web.UI.Page
    {
        string strconnect3 = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView3.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try { 

                
                SqlConnection sqlcon1 = new SqlConnection(strconnect3);
                if (sqlcon1.State == System.Data.ConnectionState.Closed)
                {
                    sqlcon1.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from Member where member_id = '"+TextBox1.Text.Trim()+"'",sqlcon1);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count != 0)
                {
                    TextBox2.Text = dt.Rows[0][0].ToString();
                    TextBox3.Text = dt.Rows[0][10].ToString();
                    TextBox4.Text = dt.Rows[0][1].ToString();
                    TextBox5.Text = dt.Rows[0][2].ToString();
                    TextBox6.Text = dt.Rows[0][3].ToString();
                    TextBox7.Text = dt.Rows[0][4].ToString();
                    TextBox8.Text = dt.Rows[0][5].ToString();
                    TextBox9.Text = dt.Rows[0][6].ToString();
                    TextBox10.Text = dt.Rows[0][7].ToString();
                    GridView3.DataBind();
                }
                else
                {
                    Response.Write("<script>alert('Member does not exist')</script>");
                }
            }
            catch(Exception ex)
            {

                Response.Write("<script>alert('"+ex.Message+"')</script>");

            }

        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (TextBox1.Text != "") { 
                    SqlConnection sqlcon2 = new SqlConnection(strconnect3);
                    if (sqlcon2.State == System.Data.ConnectionState.Closed)
                    {
                        sqlcon2.Open();
                    }
                    TextBox3.Text = "Active";
                    SqlCommand cmd = new SqlCommand("update Member set account_status=@account_status where member_id='" + TextBox1.Text.Trim() + "'", sqlcon2);
                    cmd.Parameters.AddWithValue("@account_status", TextBox3.Text.Trim());

                    cmd.ExecuteNonQuery();
                    sqlcon2.Close();

                    Response.Write("<script>alert('Account status updated successfully.')</script>");

                    GridView3.DataBind();
                }
                else
                {
                    Response.Write("<script>alert('Please enter Member ID')</script>");
                }
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            try { 
                if(TextBox1.Text != "") { 
                    SqlConnection sqlcon3 = new SqlConnection(strconnect3);
                    if (sqlcon3.State == System.Data.ConnectionState.Closed)
                    {
                        sqlcon3.Open();
                    }
                    TextBox3.Text = "Pending";
                    SqlCommand cmd = new SqlCommand("update Member set account_status=@account_status where member_id='" + TextBox1.Text.Trim() + "'", sqlcon3);
                    cmd.Parameters.AddWithValue("@account_status", TextBox3.Text.Trim());
                    cmd.ExecuteNonQuery();
                    sqlcon3.Close();

                    Response.Write("<script>alert('Account status updated successfully.')</script>");
                    GridView3.DataBind();
                }
                else
                {
                    Response.Write("<script>alert('Please enter Member ID')</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            try
            {
                if (TextBox1.Text != "") { 
                SqlConnection sqlcon4 = new SqlConnection(strconnect3);
                if (sqlcon4.State == System.Data.ConnectionState.Closed)
                {
                    sqlcon4.Open();
                }
                TextBox3.Text = "Inactive";
                SqlCommand cmd = new SqlCommand("update Member set account_status=@account_status where member_id='" + TextBox1.Text.Trim() + "'", sqlcon4);
                cmd.Parameters.AddWithValue("@account_status", TextBox3.Text.Trim());
                cmd.ExecuteNonQuery();
                sqlcon4.Close();

                Response.Write("<script>alert('Account status updated successfully.')</script>");
                GridView3.DataBind();
                }
                else
                {
                    Response.Write("<script>alert('Please enter Member ID')</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }

        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            if (CheckIfMemberExists())
            {
                try { 
                SqlConnection sqlcon5 = new SqlConnection(strconnect3);

                if (sqlcon5.State == System.Data.ConnectionState.Closed)
                {
                    sqlcon5.Open();
                }


                SqlCommand cmd = new SqlCommand("delete from Member where member_id='" + TextBox1.Text + "'", sqlcon5);
                cmd.ExecuteNonQuery();
                sqlcon5.Close();
                Response.Write("<script>alert('Member deleted successfully.')</script>");
                ClearForm();
                GridView3.DataBind();
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Member does not exist')</script>");
            }
            }

        protected bool CheckIfMemberExists()
        {
            try { 
                SqlConnection sqlcon6 = new SqlConnection(strconnect3);
                if(sqlcon6.State == System.Data.ConnectionState.Closed)
                {
                    sqlcon6.Open();
                }

                SqlCommand cmd = new SqlCommand("select * from Member where member_id='"+TextBox1.Text.Trim()+"' ",sqlcon6);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);

                if(dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex) 
            {
                Response.Write("<script>alert('"+ex.Message+"')</script>");
                return false;
            }


        }
        protected void ClearForm()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
            TextBox7.Text = "";
            TextBox8.Text = "";
            TextBox9.Text = "";
            TextBox10.Text = "";

        }
    }
}