using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryManagement
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["role"]!=null)
                {

                
                    if (Session["role"].Equals("user"))
                    {
                        LinkButton1.Visible = true;
                        LinkButton2.Visible = false;
                        LinkButton3.Visible = false;
                        LinkButton4.Visible = true;
                        LinkButton5.Visible = true;
                        LinkButton7.Visible = true;
                        LinkButton6.Visible = false;
                        LinkButton8.Visible = false;
                        LinkButton9.Visible = false;
                        LinkButton10.Visible = false;
                        LinkButton11.Visible = false;
                    }
                    else if (Session["role"].Equals("admin"))
                    {
                        LinkButton1.Visible = true;
                        LinkButton2.Visible = false;
                        LinkButton3.Visible = false;
                        LinkButton4.Visible = true;
                        LinkButton5.Text = "Hello Admin";
                        LinkButton7.Visible = false;
                        LinkButton6.Visible = true;
                        LinkButton8.Visible = true;
                        LinkButton9.Visible = true;
                        LinkButton10.Visible = true;
                        LinkButton11.Visible = true;
                    }
                }
                else
                {
                    LinkButton1.Visible = true;
                    LinkButton2.Visible = true;
                    LinkButton3.Visible = true;
                    LinkButton4.Visible = false;
                    LinkButton5.Visible = false;
                    LinkButton7.Visible = true;
                    LinkButton6.Visible = false;
                    LinkButton8.Visible = false;
                    LinkButton9.Visible = false;
                    LinkButton10.Visible = false;
                    LinkButton11.Visible = false;
                }

            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('"+ex.Message+"')</script>");
            }

        }

        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminLogin.aspx");
        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("AuthorManagement.aspx");
        }

        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            Response.Redirect("PublisherManagement.aspx");
        }

        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            Response.Redirect("BookInventory.aspx");
        }

        protected void LinkButton10_Click(object sender, EventArgs e)
        {
            Response.Redirect("BookIssuing.aspx");
        }

        protected void LinkButton11_Click(object sender, EventArgs e)
        {
            Response.Redirect("MemberManagement.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserLogin.aspx");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("SignUp.aspx");
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserProfile.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewBooks.aspx");
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Session["username"] = "";
            Session["fullname"] = "";
            Session["role"] = "";

            LinkButton1.Visible = true;
            LinkButton2.Visible = true;
            LinkButton3.Visible = true;
            LinkButton4.Visible = false;
            LinkButton5.Visible = false;
            LinkButton7.Visible = true;
            LinkButton6.Visible = false;
            LinkButton8.Visible = false;
            LinkButton9.Visible = false;
            LinkButton10.Visible = false;
            LinkButton11.Visible = false;

            Response.Redirect("HomePage.aspx"); 
        }
    }
}