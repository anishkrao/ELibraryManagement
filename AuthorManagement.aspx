<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AuthorManagement.aspx.cs" Inherits="LibraryManagement.AuthorManagement" %>
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
                                <h3>Author Details</h3>
                                <img src="images/writer.png" width="100px" height="100px"/>
                            </div>
                        </div>
                        <hr />
                        <div class="row">
                            <div class="form-group col-4">
                                <asp:Label ID="Label4" runat="server" Text="Autor ID"></asp:Label>
                                <div class="input-group">
                                    <asp:TextBox ID="TextBox4" CssClass="form-control" runat="server" placeholder="Author ID"></asp:TextBox>
                                    <asp:Button ID="Button1" CssClass="btn btn-secondary" runat="server" Text="Go" OnClick="Button1_Click" />
                                </div>
                            </div>
                            <div class="col-8">
                                <asp:Label ID="Label1" runat="server" Text="Autor Name"></asp:Label>
                                <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server" placeholder="Author Name"></asp:TextBox>

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
                            <h3>Author List<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ElibraryDBConnectionString %>" ProviderName="<%$ ConnectionStrings:ElibraryDBConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [Author]"></asp:SqlDataSource>
                            </h3>
                        </div>
                    </div>

                    <hr />
                    <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="author_id" DataSourceID="SqlDataSource1">
                        <Columns>
                            <asp:BoundField DataField="author_id" HeaderText="author_id" ReadOnly="True" SortExpression="author_id" />
                            <asp:BoundField DataField="author_name" HeaderText="author_name" SortExpression="author_name" />
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
