<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="PublisherManagement.aspx.cs" Inherits="LibraryManagement.PublisherManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        $(document).ready(function () {
            $('.table').prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container my-5 py-4">
        <div class="row">
            <div class="col-md-6">
                
                <div class="card ">
                    <div class="card-body">
                        <div class="row justify-content-center">
                            <div class="col-md-6 text-center">
                                <h3>Publisher Details</h3>
                                <img src="images/publishing.png" width="100px" height="100px"/>
                            </div>
                        </div>
                        <hr />
                        <div class="row">
                            <div class="form-group col-4">
                                <asp:Label ID="Label4" runat="server" Text="Publisher ID"></asp:Label>
                                <div class="input-group">
                                    <asp:TextBox ID="TextBox4" CssClass="form-control" runat="server" placeholder="Publisher ID"></asp:TextBox>
                                    <asp:Button ID="Button1" CssClass="btn btn-secondary" runat="server" Text="Go" OnClick="Button1_Click" />
                                </div>
                            </div>
                            <div class="col-8">
                                <asp:Label ID="Label1" runat="server" Text="Publisher Name"></asp:Label>
                                <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server" placeholder="Publisher Name"></asp:TextBox>

                            </div>
                        </div>

                        <div class="row py-2 justify-content-center">
                            <div class="text-start col-md-4">
                                <asp:Button ID="Button2" CssClass="btn btn-primary btn-lg button-width my-1" runat="server" Text="Add" OnClick="Button2_Click" />
                            </div>
                            <div class="text-center col-md-4" >
                                <asp:Button ID="Button3" CssClass="btn btn-success btn-lg button-width my-1" runat="server" Text="Update" OnClick="Button3_Click" />
                            </div>
                            <div class="text-end col-md-4">
                                <asp:Button ID="Button4" CssClass="btn btn-danger btn-lg button-width my-1" runat="server" Text="Delete" OnClick="Button4_Click" />
                            </div>
                        </div>
                     
                    </div> 
                </div>
            </div>
            <div class="col-md-6">
                <div class="card ">
                <div class="card-body">
                    <div class="row justify-content-center">
                        <div class="col-md-6 text-center">
                            <h3>Publisher List<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ElibraryDBConnectionString2 %>" ProviderName="<%$ ConnectionStrings:ElibraryDBConnectionString2.ProviderName %>" SelectCommand="SELECT * FROM [Publisher]"></asp:SqlDataSource>
                            </h3>
                        </div>
                    </div>

                    <hr />
                    <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="publisher_id" DataSourceID="SqlDataSource1">
                        <Columns>
                            <asp:BoundField DataField="publisher_id" HeaderText="publisher_id" ReadOnly="True" SortExpression="publisher_id" />
                            <asp:BoundField DataField="publisher_name" HeaderText="publisher_name" SortExpression="publisher_name" />
                        </Columns>
                    </asp:GridView>
                 </div>
               </div> 
            </div>
        </div>
        <div>
            <a style="text-decoration: none;" href="HomePage.aspx"><< Back to Home</a>
        </div>
    </div>
</asp:Content>
