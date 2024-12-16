<%@ Page Title="Smart Digital | Login" Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="GrpNo6_SmartDigital.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link rel="icon" type="image/x-icon" href="Images/favicon.ico" />
    <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/bundles/modernizr") %>
    </asp:PlaceHolder>

    <link href="../../Content/index.css" rel="stylesheet" />

    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.11.8/dist/umd/popper.min.js" integrity="sha384-I7E8VVD/ismYTF4hNIPjVp/Zjvgyol6VFvRkX/vR+Vc4jQkC+hVqc2pM8ODewa9r" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.min.js" integrity="sha384-0pUGZvbkm6XF6gxjEnlmuGrJXVbNuzT9qBBavbLwCsOGabYfZo0T0to5eqruptLy" crossorigin="anonymous"></script>
</head>
<body>
    <div class="main-wrapper logo-wrapper">
        <div class="col-4 col-lg-4 col-md-6 col-sm-8 d-flex align-content-center justify-content-center flex-column login-card">
            <div class="row logo-content">
                <img src="../../Images/logo.PNG" alt="" style="height: 80px; width: auto; margin: auto" class="mb-2" />
                <h2 class="text-center text-decoration-underline">Log In</h2>
            </div>
            <form runat="server" class="row mt-3">
                <div class="mb-3">
                    <label for="usernameTxt" class="form-label">Username</label>
                    <asp:TextBox runat="server" ID="usernameTxt" />
                    <asp:RequiredFieldValidator ID="UsernameRequiredFieldValidator" runat="server" ControlToValidate="usernameTxt" Display="Dynamic" ErrorMessage="RequiredFieldValidator" ForeColor="Red" SetFocusOnError="True">Username is required</asp:RequiredFieldValidator>
                </div>
                <div class="mb-1">
                    <label for="passwordTxt" class="form-label">Password</label>
                    <asp:TextBox runat="server" ID="passwordTxt"  Type="password" />
                    <label for="passwordTxt" class="form-label">
                        <asp:RequiredFieldValidator ID="PasswordRequiredFieldValidator" runat="server" ControlToValidate="passwordTxt" Display="Dynamic" ErrorMessage="RequiredFieldValidator" ForeColor="Red" SetFocusOnError="True">Password is required</asp:RequiredFieldValidator>
                    </label>
                </div>

                <div class="col d-flex align-items-center justify-content-center flex-column gap-4">
                    <asp:PlaceHolder ID="loginErrorMessage" runat="server">
                        <span id="ErrorMessageLabel" runat="server" style="color: red" visible="false">Incorrect Username/Password. Try Again!                    
                        </span>
                    </asp:PlaceHolder>

                    <asp:Button CssClass="row primary-btn" runat="server" Text="Log In" OnClick="OnLoginClick" />
                </div>
            </form>
        </div>
    </div>
    <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/bundles/MsAjaxJs") %>
        <%: Scripts.Render("~/bundles/jquery") %>
        <%: Scripts.Render("~/bundles/WebFormsJs") %>
    </asp:PlaceHolder>
</body>
</html>