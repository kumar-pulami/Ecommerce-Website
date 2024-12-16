<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerLayout.Master" AutoEventWireup="true" CodeBehind="CheckOutPage.aspx.cs" Inherits="GrpNo6_SmartDigital.CheckOutPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content-wrapper">
        <h3>Check Out</h3>
        <form class="row">
            <div class="col-10 col-l-4 col-md-6 col-sm-8">
                <label class="form-label">First Name</label>
                <asp:TextBox ID="FirstNameTxt" runat="server" />
                <asp:RequiredFieldValidator ForeColor="Red" runat="server" ErrorMessage="First Name is required" ControlToValidate="FirstNameTxt"></asp:RequiredFieldValidator>
            </div>

            <div class="col-10 col-l-4 col-md-6 col-sm-8">
                <label class="form-label">Last Name</label>
                <asp:TextBox ID="LastNameTxt" runat="server" />
                <asp:RequiredFieldValidator ForeColor="Red" runat="server" ErrorMessage="Last Name is required" ControlToValidate="LastNameTxt"></asp:RequiredFieldValidator>
            </div>

            <div class="col-10 col-l-4 col-md-6 col-sm-8">
                <label class="form-label">Email Address</label>
                <asp:TextBox ID="EmailAddressTxt" runat="server" />
                <asp:RequiredFieldValidator ForeColor="Red" runat="server" ErrorMessage="Email Address is required" ControlToValidate="EmailAddressTxt"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ForeColor="Red" runat="server" ErrorMessage="Invalid Email Address" ControlToValidate="EmailAddressTxt" ValidationExpression="^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"></asp:RegularExpressionValidator>
            </div>

            <div class="col-10 col-l-4 col-md-6 col-sm-8">
                <label class="form-label">Contact Number</label>
                <asp:TextBox ID="ContactNumberTxt" runat="server" />
                <asp:RequiredFieldValidator ForeColor="Red" runat="server" ErrorMessage="Contact Number is required" ControlToValidate="ContactNumberTxt"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ForeColor="Red" CssClass="d-block" runat="server" ErrorMessage="Invalid Contact Number" ControlToValidate="ContactNumberTxt" ValidationExpression="^\d{10,}$"></asp:RegularExpressionValidator>
            </div>

            <div class="col-10 col-l-4 col-md-6 col-sm-8">
                <label class="form-label">Shipping Address</label>
                <asp:TextBox ID="ShippingAddressTxt" runat="server" />
                <asp:RequiredFieldValidator ForeColor="Red" runat="server" CssClass="d-inline-block" ErrorMessage="Shipping Address is required" ControlToValidate="ShippingAddressTxt"></asp:RequiredFieldValidator>
            </div>

            <asp:Button ID="OrderButton" CssClass="primary-btn-orange mt-3" runat="server" Text="Order" OnClick="OrderButton_Click" />
        </form>
    </div>
</asp:Content>
