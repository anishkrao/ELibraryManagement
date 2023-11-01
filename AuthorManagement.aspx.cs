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
    public partial class AuthorManagement : System.Web.UI.Page
    {
        string strconnect = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (CheckIfAuthorExists())
            {
                Response.Write("<script>alert(' Author ID already in use. Please change your ID')</script>");
            }
            else
            {
                try
                {

                    SqlConnection sqlcon = new SqlConnection(strconnect);

                    if (sqlcon.State == System.Data.ConnectionState.Closed)
                    {
                        sqlcon.Open();
                    }

                    SqlCommand cmd = new SqlCommand("insert into Author(author_id,author_name) values(@author_id,@author_name)", sqlcon);

                    cmd.Parameters.AddWithValue("@author_id", TextBox4.Text.Trim());
                    cmd.Parameters.AddWithValue("@author_name", TextBox1.Text.Trim());

                    cmd.ExecuteNonQuery();
                    sqlcon.Close();

                    Response.Write("<script>alert('Author Added Successfully')</script>");
                    ClearForm();
                    GridView1.DataBind();

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "')</script>");
                }
            }
        }
        protected bool CheckIfAuthorExists()
        {
            try { 
                SqlConnection sqlcon1 = new SqlConnection(strconnect);

                if(sqlcon1.State == System.Data.ConnectionState.Closed)
                {
                    sqlcon1.Open();
                }

                SqlCommand cmd = new SqlCommand("select * from Author where author_id='" + TextBox4.Text.Trim() + "' ", sqlcon1);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count !=0)
                {
                    return true;
                }
                else{
                    return false;
                }
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('"+ex.Message+"')</script>");
                return false;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon2 = new SqlConnection(strconnect);

            if (sqlcon2.State == System.Data.ConnectionState.Closed)
            {
                sqlcon2.Open();
            }

            SqlCommand cmd = new SqlCommand("select * from Author where author_id='"+TextBox4.Text.Trim()+"'", sqlcon2);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count >= 1)
            {
                TextBox1.Text = dt.Rows[0][1].ToString();
            }
            else
            {
                Response.Write("<script>alert('Author does not Exist!')</script>");
                ClearForm();
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if(CheckIfAuthorExists())
            {

                try
                {
                    SqlConnection sqlcon3 = new SqlConnection(strconnect);

                    if (sqlcon3.State == System.Data.ConnectionState.Closed)
                    {
                        sqlcon3.Open();
                    }
                    SqlCommand cmd = new SqlCommand("update Author set author_name=@author_name where author_id='" + TextBox4.Text.Trim() + "' ", sqlcon3);

                    cmd.Parameters.AddWithValue("@author_name", TextBox1.Text.Trim());

                    cmd.ExecuteNonQuery();
                    sqlcon3.Close();
                    Response.Write("<script>alert('Author Updated Successfully')</script>");
                    ClearForm();
                    GridView1.DataBind();

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Author Does not Exist')</script>");
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (CheckIfAuthorExists())
            {

                try
                {
                    SqlConnection sqlcon4 = new SqlConnection(strconnect);

                    if (sqlcon4.State == System.Data.ConnectionState.Closed)
                    {
                        sqlcon4.Open();
                    }
                    SqlCommand cmd = new SqlCommand("delete from Author where author_id='" + TextBox4.Text.Trim() + "' ", sqlcon4);

                   

                    cmd.ExecuteNonQuery();
                    sqlcon4.Close();
                    Response.Write("<script>alert('Author Deleted Successfully')</script>");
                    ClearForm();
                    GridView1.DataBind();

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Author Does not Exist')</script>");
            }
        }

        protected void ClearForm()
        {
            TextBox1.Text = "";
            TextBox4.Text = "";
        }
    }
}