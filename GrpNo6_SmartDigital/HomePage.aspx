<%@ Page Title="Smart Digital | Home" Language="C#" MasterPageFile="~/CustomerLayout.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="GrpNo6_SmartDigital.HomePage" %>

<%@ MasterType VirtualPath="~/CustomerLayout.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content-wrapper">
        <h3>Our Products </h3>
        <div class="card-wrapper">
            <asp:Repeater
                ID="ProductRepeater"
                runat="server"
                OnItemCommand="ProductRepeater_ItemCommand"
            >
                <ItemTemplate>
                    <div class="card">
                        <div class="card-body">
                            <div class="image-content d-flex justify-content-center align-content-center">
                                <asp:Image runat="server" ImageUrl='<%# Eval("ImagePath") %>' AlternateText="Product Image" />
                            </div>

                            <div class="title-content">
                                <label class="title"><%# Eval("Name") %></label>
                                <label class="description"><%# Eval("Description") %></label>
                            </div>

                            <div class="price-content d-flex justify-content-center align-items-center gap-3">
                                <label class="price">$<%# Eval("Price", "{0:N2}") %></label>
                                <asp:LinkButton 
                                    runat="server" 
                                    CommandName="AddToCart" 
                                    CommandArgument='<%# Eval("Id") %>' 
                                 >
                                    <i class="fa-regular fa-cart-plus"></i>
                                </asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
