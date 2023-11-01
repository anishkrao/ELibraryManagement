<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="UserLogin.aspx.cs" Inherits="LibraryManagement.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="userloginpage">
    <div class="container pt-5 pb-5">
        <div class="row justify-content-center">
            <div class="text-center col-md-6">
                <div class="card">
                    <div class="card-body">
                        <div class="form-group">
                            <img src="images/user (1).png" class="img-fluid" width="100px" height="100px" alt="Alternate Text" />
                            <h3>User Login</h3>
                            <hr />
                            <div class="form-group py-2">
                                <asp:TextBox CssClass="form-control col" ID="TextBox1" runat="server" placeholder="Enter User ID"></asp:TextBox>
                            </div>
                            <div class="form-group py-2">
                                <asp:TextBox CssClass="form-control col" ID="TextBox2" runat="server" placeholder="Enter Password" TextMode="Password"></asp:TextBox>
                            </div>
                        </div>
                        
                            <asp:Button ID="Button1" runat="server" CssClass="btn btn-success button-width my-1" Text="Login" OnClick="Button1_Click" />
                        
                            <a href="SignUp.aspx">
                                <button type="button" class="btn btn-primary button-width my-1">Sign Up</button>
                            </a>
                        
                    </div>
                </div>

                <div >
                    <a style="text-decoration: none;" href="HomePage.aspx"><< Back to Home</a>
                </div>

            </div>
        </div>
    </div> 

</div>
</asp:Content>
