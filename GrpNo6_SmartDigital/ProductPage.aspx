<%@ Page Title="Smart Digital | Products" Language="C#" MasterPageFile="~/AdminLayout.Master" AutoEventWireup="true" CodeBehind="ProductPage.aspx.cs" Inherits="GrpNo6_SmartDigital.ProductPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form runat="server">
        <div class="d-flex align-items-end justify-content-between">
            <asp:Label runat="server" Text="Prodcuts" Font-Bold="true" Font-Size="X-Large"></asp:Label>
            <asp:Button CssClass="primary-btn-orange plus-button" runat="server" Text="New Product" OnClick="ShowAddProductPanel" />
        </div>
        <asp:GridView
            ID="ProductCrudGridView"
            CssClass="table table-hover table-image mt-3 mb-3"
            runat="server"
            DataSourceID="ProductCrudSqlDataSource"
            AllowPaging="True"
            AllowSorting="True"
            AutoGenerateColumns="False"
            DataKeyNames="Id"
            OnRowUpdating="ProductCrudGridView_RowUpdating" PageSize="6">
            <Columns>
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                <asp:BoundField DataField="Category" HeaderText="Category" SortExpression="Category" />
                <asp:BoundField DataField="Price" HeaderText="Price ($)" SortExpression="Price" />
                <asp:TemplateField HeaderText="Image File">
                    <ItemTemplate>
                        <!-- Display the uploaded image, if it exists -->
                        <asp:Image ID="ProductImage" runat="server" ImageUrl='<%# Eval("ImagePath") %>' Height="50px" Width="50px" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:FileUpload ID="ProductImageFileUpload" runat="server" />
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:CommandField
                    CancelText="&lt;i class=&quot;fa-regular fa-xmark&quot;&gt;&lt;/i&gt;"
                    DeleteText="&lt;i class=&quot;fa-regular fa-trash-can&quot;&gt;&lt;/i&gt;"
                    EditText="&lt;i class=&quot;fa-regular fa-pen-to-square&quot;&gt;&lt;/i&gt;"
                    UpdateText="&lt;i class=&quot;fa-regular fa-check&quot;&gt;&lt;/i&gt;"
                    ShowEditButton="True"
                    ShowDeleteButton="true"
                    HeaderText="Actions">
                    <HeaderStyle CssClass="action-col-header"></HeaderStyle>
                    <ItemStyle CssClass="action-col"></ItemStyle>
                </asp:CommandField>
            </Columns>
            <PagerStyle CssClass="pager" HorizontalAlign="Center" VerticalAlign="Middle"></PagerStyle>
            <PagerSettings Mode="NumericFirstLast" FirstPageText="First" LastPageText="Last" PreviousPageText="Previous" NextPageText="Next" />
        </asp:GridView>

        <asp:SqlDataSource
            ID="ProductCrudSqlDataSource"
            runat="server"
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>"
            SelectCommand="SELECT * FROM [Product]"
            InsertCommand="INSERT INTO [Product] ([Id], [Name], [Description], [Category], [Price], [ImagePath]) VALUES (@Id, @Name, @Description, @Category, @Price, @ImagePath)"
            UpdateCommand="UPDATE [Product] SET [Name] = @Name, [Description] = @Description, [Category] = @Category, [Price] = @Price WHERE [Id] = @Id"
            DeleteCommand="DELETE FROM [Product] WHERE [Id] = @Id">
            <DeleteParameters>
                <asp:Parameter Name="Id" Type="Object"></asp:Parameter>
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="Id" Type="Object"></asp:Parameter>
                <asp:Parameter Name="Name" Type="String"></asp:Parameter>
                <asp:Parameter Name="Description" Type="String"></asp:Parameter>
                <asp:Parameter Name="Category" Type="String"></asp:Parameter>
                <asp:Parameter Name="Price" Type="Decimal"></asp:Parameter>
                <asp:Parameter Name="ImagePath" Type="String"></asp:Parameter>
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="Name" Type="String"></asp:Parameter>
                <asp:Parameter Name="Description" Type="String"></asp:Parameter>
                <asp:Parameter Name="Category" Type="String"></asp:Parameter>
                <asp:Parameter Name="Price" Type="Decimal"></asp:Parameter>
                <asp:Parameter Name="ImagePath" Type="String"></asp:Parameter>
                <asp:Parameter Name="Id" Type="Object"></asp:Parameter>
            </UpdateParameters>
        </asp:SqlDataSource>
        <asp:Panel ID="AddProductPanel" runat="server" Width="500px" Visible="false" BorderWidth="1px" BorderColor="#dee2e6" BorderStyle="Solid" CssClass="p-4 mt-3">
            <asp:Label runat="server" CssClass="mt-5 mb-2" Text="Add New Product" Font-Bold="true" Font-Size="Large"></asp:Label>
            <form>
                <div class="mb-3">
                    <label for="NameTxt" class="form-label">Name</label>
                    <asp:TextBox runat="server" ID="NameTxt" />
                    <asp:RequiredFieldValidator ValidationGroup="NewProduct" runat="server" ControlToValidate="NameTxt" Display="Dynamic" ErrorMessage="Name is required" ForeColor="Red" />
                </div>
                <div class="mb-3">
                    <label for="DescriptionTxt" class="form-label">Description</label>
                    <asp:TextBox runat="server" ID="DescriptionTxt" />
                    <asp:RequiredFieldValidator ValidationGroup="NewProduct" runat="server" ControlToValidate="DescriptionTxt" Display="Dynamic" ErrorMessage="DescriptionTxt is required" ForeColor="Red" />
                </div>
                <div class="mb-3">
                    <label for="CategoryTxt" class="form-label">Category</label>
                    <asp:TextBox runat="server" ID="CategoryTxt" />
                    <asp:RequiredFieldValidator ValidationGroup="NewProduct" runat="server" ControlToValidate="CategoryTxt" Display="Dynamic" ErrorMessage="Category is required" ForeColor="Red" />
                </div>
                <div class="mb-3">
                    <label for="PriceTxt" class="form-label">Price</label>
                    <asp:TextBox runat="server" ID="PriceTxt" />
                    <asp:RequiredFieldValidator ValidationGroup="NewProduct" runat="server" ControlToValidate="PriceTxt" Display="Dynamic" ErrorMessage="Price is required" ForeColor="Red" />
                    <asp:RegularExpressionValidator ValidationGroup="NewProduct" runat="server" ControlToValidate="PriceTxt" Display="Dynamic" ErrorMessage="Price must be numeric and greater than 1" ValidationExpression="^[2-9]\d*(\.\d+)?|[1-9]\d+(\.\d+)?$" ForeColor="Red" />
                </div>
                <div class="mb-3">
                    <label for="usernameTxt" class="form-label me-4">Image File</label>
                    <asp:FileUpload runat="server" CssClass="ms-4" ID="ImageFileUpload" />
                </div>
                <asp:Button Text="Add" CssClass="primary-btn mt-3" runat="server" OnClick="OnClickAddBtn" ValidationGroup="NewProduct" />
                <asp:Button Text="Clear" CssClass="secondary-btn ms-4" runat="server" OnClick="OnClickClearBtn" CausesValidation="false" />
            </form>
        </asp:Panel>
    </form>
</asp:Content>
