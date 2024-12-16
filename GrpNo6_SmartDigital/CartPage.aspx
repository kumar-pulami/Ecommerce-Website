<%@ Page Title="Smart Digital | Cart" Language="C#" MasterPageFile="~/CustomerLayout.Master" AutoEventWireup="true" CodeBehind="CartPage.aspx.cs" Inherits="GrpNo6_SmartDigital.CartPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="cart-wrapper">
        <h3>Shopping Cart</h3>
        <table class="table table-responsive">
            <thead>
                <tr>
                    <th>ITEM</th>
                    <th>PRICE</th>
                    <th class="text-center">QUANTITY</th>
                    <th>SUB TOTAL</th>
                    <th class="text-center" style="max-width: 100px">Actions</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="CartItemRepeater" runat="server" OnItemCommand="CartItemRepeater_ItemCommand">
                    <ItemTemplate>
                        <tr>
                            <asp:HiddenField ID="Id" runat="server" Value='<%# Eval("Id") %>' />
                            <td style="vertical-align: middle">
                                <asp:Image CssClass="d-inline me-2" runat="server" ImageUrl='<%# Eval("ImagePath") %>' AlternateText="Product Image" Height="22px" />
                                <%# Eval("Name") %>
                            </td>
                            <td>$<%# Eval("Price") %></td>
                            <td class="text-center">
                                <asp:TextBox runat="server" ID="QuantityTxt" Text='<%# Eval("Quantity") %>' Style="width: 50px" TextMode="Number" OnDataBinding="QuantityTxt_DataBinding" OnTextChanged="QuantityTxt_TextChanged" AutoPostBack="true" />
                            </td>
                            <td>$<%# CalculateSubTotal(Eval("Quantity"), Eval("Price")) %></td>
                            <td class="text-center" style="max-width: 100px">
                                <asp:LinkButton
                                    runat="server"
                                    CommandName="RemoveItem"
                                    CommandArgument='<%# Eval("Id") %>'>
                                    <i class="fa-regular fa-circle-minus cursor-pointer"></i>
                                </asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr id="noDataRow" runat="server" visible="false">
                    <td colspan="5" class="text-center align-middle" style="height: 60px; font-weight: 500;">No Items in cart.</td>
                </tr>
                <tr id="totalDataRow" runat="server" visible="false">
                    <td colspan="3" class="text-end align-middle" style="font-weight: 500;">Total:</td>
                    <td class="align-middle" style="font-weight: 500;">$<%= totalPrice.ToString("N2") %></td>
                    <td class="text-center" style="max-width: 100px">
                        <asp:Button ID="CheckOutButton" CssClass="primary-btn" runat="server" Text="Check Out" OnClick="CheckOutButton_Click"/>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
</asp:Content>
