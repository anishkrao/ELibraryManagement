using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryManagement
{
    public partial class BookInventory : System.Web.UI.Page
    {
        string strconnect = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
        static string global_filepath;
        static int global_actual_stock, global_current_stock, global_issued_books;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView3.DataBind();
            if (!IsPostBack) { 
                AddPublisherandAuthor();
            }
        }

        protected void AddPublisherandAuthor()
        {
            try
            {
                SqlConnection sqlcon = new SqlConnection(strconnect);
                if(sqlcon.State == System.Data.ConnectionState.Closed)
                {
                    sqlcon.Open();
                }

                SqlCommand cmd = new SqlCommand("select author_name from Author", sqlcon);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);
                DropDownList2.DataSource = dt;
                DropDownList2.DataValueField = "author_name";
                DropDownList2.DataBind();
                cmd.ExecuteNonQuery();
                cmd = new SqlCommand("select publisher_name from Publisher", sqlcon);
                
                da = new SqlDataAdapter(cmd);

                dt = new DataTable();
                da.Fill(dt);
                DropDownList3.DataSource = dt;
                DropDownList3.DataValueField = "publisher_name";
                DropDownList3.DataBind();
                cmd.ExecuteNonQuery();
                sqlcon.Close();

            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('"+ex.Message+"')</script>");
            }

        }

        protected bool CheckIfBookExists()
        {
            try { 
                SqlConnection sqlcon2 = new SqlConnection(strconnect);
                if(sqlcon2.State == System.Data.ConnectionState.Closed)
                {
                    sqlcon2.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from Book where book_id='"+TextBox1.Text+ "' or book_name='"+TextBox2.Text+"' ", sqlcon2);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);
                if(dt.Rows.Count!= 0)
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

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (CheckIfBookExists())
            {
                Response.Write("<script>alert('Book already exists. Please enter new Book')</script>");
            }
            else
            {
                try
                {

                    SqlConnection sqlcon4 = new SqlConnection(strconnect);

                    if (sqlcon4.State == System.Data.ConnectionState.Closed)
                    {
                        sqlcon4.Open();
                    }

                    SqlCommand cmd = new SqlCommand("insert into Book(book_id,book_name,genre,author_name,publisher_name,publish_date,language,edition,book_cost,no_of_pages,book_description,actual_stock,current_stock,book_img_link) values(@book_id,@book_name,@genre,@author_name,@publisher_name,@publish_date,@language,@edition,@book_cost,@no_of_pages,@book_description,@actual_stock,@current_stock,@book_img_link)", sqlcon4);

                    string genre = "";

                    foreach (int i in ListBox1.GetSelectedIndices())
                    {
                        genre += ListBox1.Items[i] + ",";
                    }
                    genre = genre.Remove(genre.Length - 1);

                    string filepath = "";

                    string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    FileUpload1.SaveAs(Server.MapPath("bookInventory/" + filename));
                    filepath = "~/bookInventory/" + filename;
                    


                    cmd.Parameters.AddWithValue("@book_id", TextBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@book_name", TextBox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@genre", genre);
                    cmd.Parameters.AddWithValue("@author_name", DropDownList2.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@publisher_name", DropDownList3.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@publish_date",TextBox7.Text.Trim());
                    cmd.Parameters.AddWithValue("@language", DropDownList1.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@edition", TextBox8.Text.Trim());
                    cmd.Parameters.AddWithValue("@book_cost", TextBox9.Text.Trim());
                    cmd.Parameters.AddWithValue("@no_of_pages", TextBox3.Text.Trim());
                    cmd.Parameters.AddWithValue("@book_description", TextBox10.Text.Trim());
                    cmd.Parameters.AddWithValue("@actual_stock", TextBox4.Text.Trim());
                    cmd.Parameters.AddWithValue("@current_stock", TextBox4.Text.Trim());
                    cmd.Parameters.AddWithValue("@book_img_link",filepath);

                    cmd.ExecuteNonQuery();
                    sqlcon4.Close();

                    Response.Write("<script>alert('Book Added Successfully')</script>");
                    ClearForm();
                    GridView3.DataBind();

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "')</script>");
                }
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (CheckIfBookExists())
            {

                try
                {
                    SqlConnection sqlcon3 = new SqlConnection(strconnect);

                    if (sqlcon3.State == System.Data.ConnectionState.Closed)
                    {
                        sqlcon3.Open();
                    }
                    SqlCommand cmd = new SqlCommand("update Book set book_name=@book_name,genre=@genre,author_name=@author_name,publisher_name=@publisher_name,publish_date=@publish_date,language=@language,edition=@edition,book_cost=@book_cost,no_of_pages=@no_of_pages,book_description=@book_description,actual_stock=@actual_stock,current_stock=@current_stock,book_img_link=@book_img_link where book_id='" + TextBox1.Text.Trim() + "' ", sqlcon3);

                    string genre = "";

                    foreach (int i in ListBox1.GetSelectedIndices())
                    {
                        genre = genre+ ListBox1.Items[i] + ",";
                    }
                    genre = genre.Remove(genre.Length - 1);
                    
                    
                    string filepath = "";

                    string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);

                    if (filename == "" || filename == null)
                    {
                        filepath = global_filepath;
                    }
                    else
                    {
                        FileUpload1.SaveAs(Server.MapPath("bookInventory/" + filename));
                        filepath = "~/bookInventory/" + filename;
                    }

                    int actual_stock = Convert.ToInt32(TextBox4.Text.Trim());
                    int current_stock = Convert.ToInt32(TextBox5.Text.Trim());

                    if (global_actual_stock == actual_stock)
                    {

                    }
                    else
                    {
                        if (actual_stock < global_issued_books)
                        {
                            Response.Write("<script>alert('Actual stock of a book cannot be less tahn the issued ones')</script>");
                        }
                        else
                        {
                            current_stock = actual_stock - global_issued_books;
                            TextBox5.Text = "" + current_stock;
                        }
                    }
                    cmd.Parameters.AddWithValue("@book_name", TextBox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@genre", genre);
                    cmd.Parameters.AddWithValue("@author_name", DropDownList2.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@publisher_name", DropDownList3.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@publish_date", TextBox7.Text.Trim());
                    cmd.Parameters.AddWithValue("@language", DropDownList1.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@edition", TextBox8.Text.Trim());
                    cmd.Parameters.AddWithValue("@book_cost", TextBox9.Text.Trim());
                    cmd.Parameters.AddWithValue("@no_of_pages", TextBox3.Text.Trim());
                    cmd.Parameters.AddWithValue("@book_description", TextBox10.Text.Trim());
                    cmd.Parameters.AddWithValue("@actual_stock", actual_stock);
                    cmd.Parameters.AddWithValue("@current_stock", current_stock);
                    cmd.Parameters.AddWithValue("@book_img_link", filepath);

                    cmd.ExecuteNonQuery();
                    sqlcon3.Close();
                    Response.Write("<script>alert('Book Updated Successfully')</script>");
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
                Response.Write("<script>alert('Book Does not Exist')</script>");
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (CheckIfBookExists())
            {

                try
                {
                    SqlConnection sqlcon4 = new SqlConnection(strconnect);

                    if (sqlcon4.State == System.Data.ConnectionState.Closed)
                    {
                        sqlcon4.Open();
                    }
                    SqlCommand cmd = new SqlCommand("delete from Book where book_id='" + TextBox1.Text.Trim() + "' ", sqlcon4);



                    cmd.ExecuteNonQuery();
                    sqlcon4.Close();
                    Response.Write("<script>alert('Book Deleted Successfully')</script>");
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
                Response.Write("<script>alert('Book Does not Exist')</script>");
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

        protected void Button1_Click(object sender, EventArgs e)
        {
           
                try
                {
                    SqlConnection sqlcon6 = new SqlConnection(strconnect);
                    if (sqlcon6.State == System.Data.ConnectionState.Closed)
                    {
                        sqlcon6.Open();
                    }
                    SqlCommand cmd = new SqlCommand("select * from Book where book_id = '"+TextBox1.Text.Trim()+"'",sqlcon6);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    if (dt.Rows.Count>=1)
                    {
                    TextBox2.Text = dt.Rows[0]["book_name"].ToString().Trim();
                    DropDownList1.SelectedValue = dt.Rows[0]["language"].ToString().Trim();
                    DropDownList2.SelectedValue = dt.Rows[0]["author_name"].ToString().Trim();
                    DropDownList3.SelectedValue = dt.Rows[0]["publisher_name"].ToString().Trim();
                    TextBox7.Text = dt.Rows[0]["publish_date"].ToString().Trim();
                    TextBox8.Text = dt.Rows[0]["edition"].ToString().Trim();
                    TextBox9.Text = dt.Rows[0]["book_cost"].ToString().Trim();
                    TextBox3.Text = dt.Rows[0]["no_of_pages"].ToString().Trim();
                    TextBox4.Text = dt.Rows[0]["actual_stock"].ToString().Trim();
                    TextBox5.Text = dt.Rows[0]["current_stock"].ToString().Trim();
                    TextBox10.Text = dt.Rows[0]["book_description"].ToString().Trim();
                    TextBox6.Text = Convert.ToString(Convert.ToInt32(dt.Rows[0]["actual_stock"]) - Convert.ToInt32(dt.Rows[0]["current_stock"]));
                    ListBox1.ClearSelection();
                    string[] genre = dt.Rows[0]["genre"].ToString().Trim().Split(',');
                    for(int i = 0; i < genre.Length;i++)
                    {
                        for (int j=0;j<ListBox1.Items.Count;j++)
                        {
                            if (ListBox1.Items[j].ToString() == genre[i])
                            {
                                ListBox1.Items[j].Selected = true;
                            }
                            
                        }
                    }
                    global_actual_stock = Convert.ToInt32(dt.Rows[0]["actual_stock"].ToString().Trim());
                    global_current_stock = Convert.ToInt32(dt.Rows[0]["current_stock"].ToString().Trim());
                    global_issued_books = global_actual_stock - global_current_stock;
                    global_filepath = dt.Rows[0]["book_img_link"].ToString();


                    }
                    else
                    {
                        Response.Write("<script>alert('Invalid Book ID')</script>");
                    }
                }
            
                    
                
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "')</script>");
                }

            
        }
    }
}