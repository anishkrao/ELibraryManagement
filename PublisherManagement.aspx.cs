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
    public partial class PublisherManagement : System.Web.UI.Page
    {
        string strconnect1 = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (CheckIfPublisherExists())
            {
                Response.Write("<script>alert(' Publisher ID already in use. Please change your ID')</script>");
            }
            else
            {
                try
                {

                    SqlConnection sqlcon = new SqlConnection(strconnect1);

                    if (sqlcon.State == System.Data.ConnectionState.Closed)
                    {
                        sqlcon.Open();
                    }

                    SqlCommand cmd = new SqlCommand("insert into Publisher(publisher_id,publisher_name) values(@publisher_id,@publisher_name)", sqlcon);

                    cmd.Parameters.AddWithValue("@publisher_id", TextBox4.Text.Trim());
                    cmd.Parameters.AddWithValue("@publisher_name", TextBox1.Text.Trim());

                    cmd.ExecuteNonQuery();
                    sqlcon.Close();

                    Response.Write("<script>alert('Publisher Added Successfully')</script>");
                    ClearForm();
                    GridView1.DataBind();

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "')</script>");
                }
            }
        }
        protected bool CheckIfPublisherExists()
        {
            try
            {
                SqlConnection sqlcon1 = new SqlConnection(strconnect1);

                if (sqlcon1.State == System.Data.ConnectionState.Closed)
                {
                    sqlcon1.Open();
                }

                SqlCommand cmd = new SqlCommand("select * from Publisher where Publisher_id='" + TextBox4.Text.Trim() + "' ", sqlcon1);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count != 0)
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

        protected void ClearForm()
        {
            TextBox4.Text = "";
            TextBox1.Text = "";
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (CheckIfPublisherExists())
            {

                try
                {
                    SqlConnection sqlcon3 = new SqlConnection(strconnect1);

                    if (sqlcon3.State == System.Data.ConnectionState.Closed)
                    {
                        sqlcon3.Open();
                    }
                    SqlCommand cmd = new SqlCommand("update Publisher set publisher_name=@publisher_name where publisher_id='" + TextBox4.Text.Trim() + "' ", sqlcon3);

                    cmd.Parameters.AddWithValue("@publisher_name", TextBox1.Text.Trim());

                    cmd.ExecuteNonQuery();
                    sqlcon3.Close();
                    Response.Write("<script>alert('Publisher Updated Successfully')</script>");
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
                Response.Write("<script>alert('Publisher Does not Exist')</script>");
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (CheckIfPublisherExists())
            {

                try
                {
                    SqlConnection sqlcon4 = new SqlConnection(strconnect1);

                    if (sqlcon4.State == System.Data.ConnectionState.Closed)
                    {
                        sqlcon4.Open();
                    }
                    SqlCommand cmd = new SqlCommand("delete from Publisher where publisher_id='" + TextBox4.Text.Trim() + "' ", sqlcon4);



                    cmd.ExecuteNonQuery();
                    sqlcon4.Close();
                    Response.Write("<script>alert('Publisher Deleted Successfully')</script>");
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
                Response.Write("<script>alert('Publisher Does not Exist')</script>");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon2 = new SqlConnection(strconnect1);

            if (sqlcon2.State == System.Data.ConnectionState.Closed)
            {
                sqlcon2.Open();
            }

            SqlCommand cmd = new SqlCommand("select * from Publisher where publisher_id='" + TextBox4.Text.Trim() + "'", sqlcon2);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count >= 1)
            {
                TextBox1.Text = dt.Rows[0][1].ToString();
            }
            else
            {
                Response.Write("<script>alert('Publisher does not Exist!')</script>");
                ClearForm();
            }
        }
    }
}