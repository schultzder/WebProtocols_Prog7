<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="schultzder_Prog6.Login" %>

<!DOCTYPE html>

<html lang="en">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title><%: Page.Title %> - My ASP.NET Application</title>

    <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/bundles/modernizr") %>
    </asp:PlaceHolder>

    <webopt:bundlereference runat="server" path="~/Content/css" />
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />

   
    </style>

</head>
<body>
    <form id="form1" runat="server">
    <div>
            <h1 class="auto-style2">Web Protocols, Technologies and Applications </h1>
    <h2 class="auto-style3">Derek Schultz</h2>

<div>
            <table class="nav-justified">
                <tr>
                    <td class="auto-style6">&nbsp;</td>
                    <td class="auto-style4">
                        <asp:Label ID="Label3" runat="server">Log In</asp:Label>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td class="auto-style7">
                        <asp:Label ID="Label1" runat="server" Text="User Name"></asp:Label>
                    </td>
                    <td class="auto-style4">
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    </td>
                    <td><em>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="User Name Is Required" ForeColor="Red"></asp:RequiredFieldValidator>
                        </em>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style7">
                        <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
                    </td>
                    <td class="auto-style4">
                        <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                    <td>
                        <em>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" ErrorMessage="Password is Required" ForeColor="Red"></asp:RequiredFieldValidator>
                        </em>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style8"></td>
                    <td class="auto-style9">
                        <asp:CheckBox ID="CheckBox1" runat="server" Text="Remember Me Next Time" />
                        <br />
                        <asp:Label ID="Label5" runat="server" Visible="False" ForeColor="Red" style="font-style: italic; font-size: x-small">Invalid Credentials, Try Again</asp:Label>
                        <br />
                    </td>
                    <td class="auto-style10"></td>
                </tr>
                <tr>
                    <td class="auto-style6">&nbsp;</td>
                    <td class="auto-style5">
                        <asp:Button ID="Button1" runat="server" Text="Log In" OnClick="Button1_Click" />
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink1" href="Register.aspx" runat="server" NavigateUrl="~/Register.aspx">Register New User</asp:HyperLink>
                    </td>
                </tr>
            </table>
            <footer>
                <p>&copy; <%: DateTime.Now.Year %> - My ASP.NET Application</p>
            </footer>
        </div>
    </div>
    </form>
</body>
</html>
