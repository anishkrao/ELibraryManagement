<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="BookInventory.aspx.cs" Inherits="LibraryManagement.BookInventory" %>

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
            <div class="col-md-6">

                <div class="card ">
                    <div class="card-body">
                        <div class="row justify-content-center">
                            <div class="col-12 text-center">
                                <h3>Book Details</h3>
                                <img id="imgview" src="images/books.png" width="100px;" height="100px;" alt="Alternate Text" />
                            </div>
                        </div>


                        <hr />

                        <div class="row py-2">
                            <div class="col-12">
                                 <asp:FileUpload onchange="readURL(this);" CssClass="form-control" ID="FileUpload1" runat="server" />
                            </div>
                        </div>

                        <div class="row py-2">
                            <div class="col-md-5 form-group">
                                <asp:Label ID="Label1" runat="server" Text="Book ID"></asp:Label>
                                <div class="input-group">
                                    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" placeholder="Book ID"></asp:TextBox>
                                    <asp:Button ID="Button1" runat="server" CssClass="btn btn-secondary" Text="Go" OnClick="Button1_Click" />
                                </div>
                            </div>
                            <div class="col-md-7">
                                <asp:Label ID="Label2" runat="server" Text="Book Name"></asp:Label>
                                <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" placeholder="Book Name"></asp:TextBox>
                            </div>

                        </div>

                        <div class="row py-2">
                            <div class="col-md-4">
                                <asp:Label ID="Label4" runat="server" Text="Language"></asp:Label>
                                <asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server">
                                    <asp:ListItem Text="English" Value="English"></asp:ListItem>
                                    <asp:ListItem Text="Hindi" Value="Hindi"></asp:ListItem>
                                    <asp:ListItem Text="Kannada" Value="Kannada"></asp:ListItem>
                                    <asp:ListItem Text="French" Value="French"></asp:ListItem>
                                    <asp:ListItem Text="German" Value="German"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-4">
                                <asp:Label ID="Label3" runat="server" Text="Author Name"></asp:Label>
                                <asp:DropDownList ID="DropDownList2" CssClass="form-control" runat="server">
                                    <asp:ListItem Text="A1" Value="A1"></asp:ListItem>
                                    <asp:ListItem Text="A2" Value="A2"></asp:ListItem>
                                    <asp:ListItem Text="A3" Value="A3"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-4">
                                <asp:Label ID="Label5" runat="server" Text="Publisher Name"></asp:Label>
                                <asp:DropDownList ID="DropDownList3" CssClass="form-control" runat="server">
                                    <asp:ListItem Text="P1" Value="P1"></asp:ListItem>
                                    <asp:ListItem Text="P2" Value="P2"></asp:ListItem>
                                    <asp:ListItem Text="P3" Value="P3"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="row py-2">
                            <div class="col-md-4">
                                <asp:Label ID="Label7" runat="server" Text="Publish Date"></asp:Label>
                                <asp:TextBox ID="TextBox7" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                            </div>
                            <div class="col-md-4">
                                <asp:Label ID="Label8" runat="server" Text="Edition"></asp:Label>
                                <asp:TextBox ID="TextBox8" runat="server" CssClass="form-control" placeholder="Edition" TextMode="Number"></asp:TextBox>
                            </div>
                            <div class="col-md-4">
                                <asp:Label ID="Label9" runat="server" Text="Book Cost(per unit)"></asp:Label>
                                <asp:TextBox ID="TextBox9" runat="server" CssClass="form-control" placeholder="Book Cost(per unit)" TextMode="Number"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row py-2">
                            <div class="col-md-6">
                                <asp:Label ID="Label6" runat="server" Text="Pages"></asp:Label>
                                <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" placeholder="Pages" TextMode="Number"></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                <asp:Label ID="Label10" runat="server" Text="Actual Stock"></asp:Label>
                                <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control" placeholder="Actual Stock" TextMode="Number"></asp:TextBox>
                            </div>
                            
                        </div>

                        <div class="row py-2">
                            <div class="col-md-6">
                                <asp:Label ID="Label12" runat="server" Text="Issued Books"></asp:Label>
                                <asp:TextBox ID="TextBox6" runat="server" CssClass="form-control" placeholder="Issued Books" TextMode="Number" ReadOnly="true"></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                <asp:Label ID="Label11" runat="server" Text="Current Stock"></asp:Label>
                                <asp:TextBox ID="TextBox5" runat="server" CssClass="form-control" placeholder="Current Stock" TextMode="Number" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row py-2">
                            <div class="col-md-6">
                                <asp:Label ID="Label13" runat="server" Text="Book Description"></asp:Label>
                                <asp:TextBox ID="TextBox10" runat="server" CssClass="form-control" placeholder="Book Description" TextMode="MultiLine" Rows="4"></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                <asp:Label ID="Label14" runat="server" Text="Genre"></asp:Label>
                                <asp:ListBox ID="ListBox1" CssClass="form-control" runat="server" SelectionMode="Multiple" Rows="5">
                                    <asp:ListItem Text="Action" Value="Action"/>
                                    <asp:ListItem Text="Adventure" Value="Adventure"/>
                                    <asp:ListItem Text="Comic" Value="Comic"/>
                                    <asp:ListItem Text="Motivation" Value="Motivation"/>
                                    
                                    <asp:ListItem Text="Crime" Value="Crime"/>
                                    <asp:ListItem Text="Drama" Value="Drama"/>
                                    <asp:ListItem Text="Horror" Value="Horror"/>
                                    <asp:ListItem Text="Poetry" Value="Poetry"/>
                                    <asp:ListItem Text="Pseudoscience" Value="Pseudoscience"/>
                                    <asp:ListItem Text="Mystery" Value="Mystery"/>
                                </asp:ListBox>
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
                <div class="card">
                    <div class="card-body">
                        <div class="row justify-content-center">
                            <div class="col-md-12 text-center">
                                <div class="row">
                                    <div class="col-12 text-center">
                                        <h3>Book Inventory List<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ElibraryDBConnectionString4 %>" ProviderName="<%$ ConnectionStrings:ElibraryDBConnectionString4.ProviderName %>" SelectCommand="SELECT * FROM [Book]"></asp:SqlDataSource>
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
        </div>
        <div>
                <a style="text-decoration: none;" href="HomePage.aspx"><< Back to Home</a>
        </div>
    </div>
</asp:Content>
