<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="LibraryManagement.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="signup-page">
        <div class="container px-5 py-3">
            <div class="card ">
                <div class="card-body">
                    <div class="row justify-content-center">
                        <div class="col-md-4 text-center">
                            <img src="images/user%20(1).png" width="100px" height="100px"/>
                            <h3>Member Registration</h3>
                        </div>
                    </div>


                    <hr />


                    <div class="row">
                            <div class="col-md-6 form-group">
                                    <div class="py-1">
                                        <asp:Label ID="Label1" runat="server" Text="Full Name"></asp:Label>
                                        <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server" placeholder="Full Name"></asp:TextBox>
                                    </div>
                                <div class="py-1">
                                        <asp:Label ID="Label2" runat="server" Text="Contact Number"></asp:Label>
                                        <asp:TextBox ID="TextBox2" CssClass="form-control" runat="server" TextMode="Phone" placeholder="Contact Number"></asp:TextBox>
                                </div>
                            
                            </div>

                        
                            <div class="col-md-6 form-group">
                                <div class="py-1">
                                    <asp:Label ID="Label3" runat="server" Text="Date of Birth"></asp:Label>
                                    <asp:TextBox ID="TextBox3" CssClass="form-control" runat="server" TextMode="Date"></asp:TextBox>
                                </div>
                                <div class="py-1">
                                    <asp:Label ID="Label4" runat="server" Text="Email ID"></asp:Label>
                                    <asp:TextBox ID="TextBox4" CssClass="form-control" runat="server" TextMode="Email" placeholder="Email ID"></asp:TextBox>
                                </div>
                            </div>
                       </div>

                    <div class="row">
                        <div class="col-md-4 py-1">
                            <asp:Label ID="Label5" runat="server" Text="State"></asp:Label>
                            <asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server">
                                <asp:ListItem Text="Select" Value="Select"/>
                                <asp:ListItem Text="Karnataka" Value="Karnataka" />
                                <asp:ListItem Text="Kerala" Value="Kerala" />
                                <asp:ListItem Text="Tamil Nadu" Value="Tamil Nad" />
                                <asp:ListItem Text="Telangana" Value="Telangana" />
                                <asp:ListItem Text="Goa" Value="Goa" />
                            </asp:DropDownList>
                        </div>

                        <div class="col-md-4 py-1">
                            
                                    <asp:Label ID="Label6" runat="server" Text="City"></asp:Label>
                                    <asp:TextBox ID="TextBox5" CssClass="form-control" runat="server" placeholder="City"></asp:TextBox>
                               
                        </div>

                        <div class="col-md-4 py-1">
                            <asp:Label ID="Label7" runat="server" Text="Pincode"></asp:Label>
                            <asp:TextBox ID="TextBox6" CssClass="form-control" runat="server" placeholder="Pincode"></asp:TextBox>
                        </div>

                    </div>

                    <div class="row">
                        <div class="col-12 py-1">
                            <asp:Label ID="Label8" runat="server" Text="Full Address"></asp:Label>
                            <asp:TextBox ID="TextBox7" CssClass="form-control" runat="server" placeholder="Full Address" TextMode="MultiLine"></asp:TextBox>
                        </div>
                    </div>

                    <div class="row justify-content-center">
                        <div class="col-3 text-center py-1">
                            <span class="badge bg-success">Login Credentials</span>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-6 py-1">
                            <asp:Label ID="Label9" runat="server" Text="User ID"></asp:Label>
                            <asp:TextBox ID="TextBox8" CssClass="form-control" runat="server" placeholder="User ID"></asp:TextBox>
                        </div>
                        <div class="col-md-6 py-1">
                            <asp:Label ID="Label10" runat="server" Text="Password"></asp:Label>
                            <asp:TextBox ID="TextBox9" CssClass="form-control" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-12">
                            <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary button-width my-1" Text="Sign Up" OnClick="Button1_Click" />
                        </div>
                    </div>

                    

                 </div>
             </div> 
            <div>
                <a style="text-decoration: none;" href="HomePage.aspx"><< Back to Home</a>
            </div>
         </div>
    </div>
</asp:Content>
