<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ViewBooks.aspx.cs" Inherits="LibraryManagement.ViewBooks" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        $(document).ready(function () {
            $('.table').prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container text-center py-3">
        <div class="row">
            <div class="col-12">
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ElibraryDBConnectionString5 %>" SelectCommand="SELECT * FROM [Book]"></asp:SqlDataSource>
                
                <div class="card">
                    <div class="card-body">
                        <div class="row justify-content-center">
                            <div class="col-md-12 text-center">
                                <div class="row">
                                    <div class="col-12 text-center">
                                        <h3>Book Inventory List<asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ElibraryDBConnectionString4 %>" ProviderName="<%$ ConnectionStrings:ElibraryDBConnectionString4.ProviderName %>" SelectCommand="SELECT * FROM [Book]"></asp:SqlDataSource>
                                        </h3>
                                    </div>
                                </div>

                                <hr />

                                <asp:GridView ID="GridView3" class="table table-bordered table-striped" runat="server" AutoGenerateColumns="False" DataKeyNames="book_id" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="book_id" HeaderText="ID" ReadOnly="True" SortExpression="book_id" />
                                        
                                        <asp:TemplateField>

                                            <ItemTemplate>
                                                <div class="container-fluid">
                                                    <div class="row">
                                                        <div class="col-lg-10">
                                                            <div class="row text-start">
                                                                <div class="col-12 ">
                                                                    <asp:Label ID="Label15" runat="server" Text='<%# Eval("book_name") %>' Font-Bold="True" Font-Size="X-Large"></asp:Label>  
                                                                </div>
                                                                <div class="col-12">

                                                                    Author -
                                                                    <asp:Label ID="Label16" runat="server" Font-Bold="True" Text='<%# Eval("author_name") %>'></asp:Label>
                                                                    &nbsp;| Genre -
                                                                    <asp:Label ID="Label17" runat="server" Font-Bold="True" Text='<%# Eval("genre") %>'></asp:Label>
                                                                    &nbsp;| Language -
                                                                    <asp:Label ID="Label18" runat="server" Font-Bold="True" Text='<%# Eval("language") %>'></asp:Label>

                                                                </div>
                                                                <div class="col-12">

                                                                    Publisher -
                                                                    <asp:Label ID="Label19" runat="server" Font-Bold="True" Text='<%# Eval("publisher_name") %>'></asp:Label>
                                                                    &nbsp;| Publish date -
                                                                    <asp:Label ID="Label20" runat="server" Font-Bold="True" Text='<%# Eval("publish_date") %>'></asp:Label>
                                                                    &nbsp;| Pages -
                                                                    <asp:Label ID="Label21" runat="server" Font-Bold="True" Text='<%# Eval("no_of_pages") %>'></asp:Label>
                                                                    &nbsp;| Edition -
                                                                    <asp:Label ID="Label22" runat="server" Font-Bold="True" Text='<%# Eval("edition") %>'></asp:Label>

                                                                </div>
                                                                <div class="col-12">

                                                                    Cost -
                                                                    <asp:Label ID="Label23" runat="server" Font-Bold="True" Text='<%# Eval("book_cost") %>'></asp:Label>
                                                                    &nbsp;| Actual Stock -
                                                                    <asp:Label ID="Label24" runat="server" Font-Bold="True" Text='<%# Eval("actual_stock") %>'></asp:Label>
                                                                    &nbsp;| Current Stock -
                                                                    <asp:Label ID="Label25" runat="server" Font-Bold="True" Text='<%# Eval("current_stock") %>'></asp:Label>

                                                                </div>
                                                                <div class="col-12">

                                                                    Description -
                                                                    <asp:Label ID="Label26" runat="server" Font-Bold="True" Text='<%# Eval("book_description") %>' Font-Size="Small"></asp:Label>

                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-2">
                                                            <asp:Image CssClass="img-fluid" ID="Image1" runat="server" ImageUrl='<%# Eval("book_img_link") %>' />
                                                        </div>
                                                    </div>
                                                </div>
                                            </ItemTemplate>

                                        </asp:TemplateField>
                                        
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>


                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-12">
                    
                </div>
            </div>

            <div class="row">
                <div class="col-12 text-start">
                    <a href="HomePage.aspx" style="text-decoration:none;"><< Back to Home</a>
                </div>
            </div>


        </div>
    </div>
</asp:Content>
