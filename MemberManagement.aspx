<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="MemberManagement.aspx.cs" Inherits="LibraryManagement.MemberManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        $(document).ready(function () {
            $('.table').prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid my-3">
        <div class="row">
            <div class="col-md-5">
                
                <div class="card ">
                    <div class="card-body">
                        <div class="row justify-content-center">
                            <div class="col-12 text-center">
                                <h3>Member Details</h3>
                                <img src="images/user (1).png" width="100px;" height="100px;" alt="Alternate Text" />
                            </div> 
                        </div>


                        <hr />


                        <div class="row py-2">
                                <div class="col-md-3 form-group">
                                <asp:Label ID="Label1" runat="server" Text="Member ID"></asp:Label>
                                <div class="input-group">
                                    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" placeholder="Member ID"></asp:TextBox>
                                    <asp:Button ID="Button1" runat="server" CssClass="btn btn-secondary" Text="Go" OnClick="Button1_Click" />
                                </div>
                            </div> 
                            <div class="col-md-3">
                                <asp:Label ID="Label2" runat="server" Text="Full Name"></asp:Label>
                                <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" placeholder="Full Name" ReadOnly="true"></asp:TextBox>
                            </div> 
                            <div class="col-md-6">
                                <asp:Label ID="Label3" runat="server" Text="Account Status"></asp:Label>
                                <div class="input-group">
                                    <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" placeholder="Account Status"></asp:TextBox>
                                    <asp:LinkButton ID="LinkButton1" CssClass="btn btn-success" runat="server" OnClick="LinkButton1_Click"><i class="fa-solid fa-circle-check" style="color: #ffffff;"></i></asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton2" CssClass="btn btn-warning" runat="server" OnClick="LinkButton2_Click"><i class="fa-solid fa-circle-pause" style="color: #ffffff;"></i></asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton3" CssClass="btn btn-danger" runat="server" OnClick="LinkButton3_Click"><i class="fa-solid fa-circle-xmark" style="color: #ffffff;"></i></asp:LinkButton>
                                </div>
                            </div> 
                           </div>

                        <div class="row py-2">
                            <div class="col-md-4">
                                <asp:Label ID="Label4" runat="server" Text="Date of Birth"></asp:Label>
                                <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control" placeholder="Date of Birth" ReadOnly="true"></asp:TextBox>
                            </div>
                            <div class="col-md-4">
                                <asp:Label ID="Label5" runat="server" Text="Contact Number"></asp:Label>
                                <asp:TextBox ID="TextBox5" runat="server" CssClass="form-control" placeholder="Contact Number" ReadOnly="true"></asp:TextBox>
                            </div>
                            <div class="col-md-4">
                                <asp:Label ID="Label6" runat="server" Text="Email ID"></asp:Label>
                                <asp:TextBox ID="TextBox6" runat="server" CssClass="form-control" placeholder="Email ID" ReadOnly="true"></asp:TextBox>
                            </div>

                        </div>

                        <div class="row py-2">
                            <div class="col-md-4">
                                <asp:Label ID="Label7" runat="server" Text="State"></asp:Label>
                                <asp:TextBox ID="TextBox7" runat="server" CssClass="form-control" placeholder="State" ReadOnly="true"></asp:TextBox>
                            </div>
                            <div class="col-md-4">
                                <asp:Label ID="Label8" runat="server" Text="City"></asp:Label>
                                <asp:TextBox ID="TextBox8" runat="server" CssClass="form-control" placeholder="City" ReadOnly="true"></asp:TextBox>
                            </div>
                            <div class="col-md-4">
                                <asp:Label ID="Label9" runat="server" Text="Pincode"></asp:Label>
                                <asp:TextBox ID="TextBox9" runat="server" CssClass="form-control" placeholder="Pincode" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row py-2">
                            <div class="col-12">
                                <asp:Label ID="Label10" runat="server" Text="Full Address"></asp:Label>
                                <asp:TextBox ID="TextBox10" runat="server" CssClass="form-control" TextMode="MultiLine" placeholder="Full Address" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row py-2">
                            <div class="col-12 text-center">
                                <asp:LinkButton ID="LinkButton4" CssClass="btn btn-danger" runat="server" OnClick="LinkButton4_Click">Delete User Permanently</asp:LinkButton>
                            </div>
                        </div>

                        

         
                     
             </div> 
            
                </div>
            </div>
            <div class="col-md-7">
                <div class="card">
                <div class="card-body">
                    <div class="row justify-content-center">
                        <div class="col-md-12 text-center">
                            <div class="row">
                            <div class="col-12 text-center">
                                <h3>Member List<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ElibraryDBConnectionString3 %>" SelectCommand="SELECT [full_name], [email], [state], [city], [member_id], [account_status] FROM [Member]"></asp:SqlDataSource>
                                </h3>
                            </div> 
                        </div>

                        <hr /> 
                        <div style="overflow: auto;">
                            <asp:GridView ID="GridView3" class="table table-bordered table-striped" runat="server" AutoGenerateColumns="False" DataKeyNames="member_id" DataSourceID="SqlDataSource1">
                                <Columns>
                                    <asp:BoundField DataField="full_name" HeaderText="Name" SortExpression="full_name" />
                                    <asp:BoundField DataField="email" HeaderText="Email" SortExpression="email" />
                                    <asp:BoundField DataField="state" HeaderText="State" SortExpression="state" />
                                    <asp:BoundField DataField="city" HeaderText="City" SortExpression="city" />
                                    <asp:BoundField DataField="member_id" HeaderText="Member ID" SortExpression="member_id" ReadOnly="True" />
                                    <asp:BoundField DataField="account_status" HeaderText="Account Status" SortExpression="account_status" />
                                </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>

                    
                 </div>
               </div> 
            </div>
        </div>
        <div>
                <a style="text-decoration: none;" href="HomePage.aspx"><< Back to Home</a>
        </div>
    </div>
</asp:Content>
