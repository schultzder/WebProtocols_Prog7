<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SetRoles.aspx.cs" Inherits="schultzder_Prog6.SetRoles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table class="nav-justified">
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="height: 28px"></td>
            <td class="text-center" style="height: 28px">
                <asp:TextBox ID="TextBox1" runat="server" Height="16px" Width="173px"></asp:TextBox>
            </td>
            <td class="text-center" style="height: 28px">
                <asp:DropDownList ID="DropDownListUser" runat="server" Height="110px" Width="203px" DataSourceID="SqlDataSource1" DataTextField="UserName" DataValueField="UserName">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:UWPCS3870ConnectionString %>" SelectCommand="SELECT [UserName] FROM [Users]"></asp:SqlDataSource>
            </td>
            <td style="height: 28px"></td>
            <td style="height: 28px"></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="text-center">
                <asp:Button ID="Button1" runat="server" Height="27px" Text="Add Role" Width="143px" />
                <asp:Button ID="Button2" runat="server" Height="27px" Text="Remove Role" Width="143px" />
                <br />
                <br />
                <br />
                <asp:DropDownList ID="DropDownList1" runat="server" Height="110px" Width="203px" DataSourceID="SqlDataSource2" DataTextField="Role" DataValueField="Role">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:UWPCS3870ConnectionString %>" SelectCommand="SELECT [Role] FROM [Users]"></asp:SqlDataSource>
            </td>
            <td class="text-center">
                <asp:Button ID="Button3" runat="server" Height="27px" Text="Delete User" Width="143px" />
                <br />
                <asp:Button ID="Button4" runat="server" Height="27px" Text="Add User to Role" Width="143px" />
                <asp:Button ID="Button5" runat="server" Height="27px" Text="Remove User from Role" Width="157px" />
                <br />
                <asp:DropDownList ID="DropDownList3" runat="server" Height="110px" Width="203px" DataSourceID="SqlDataSource1" DataTextField="UserName" DataValueField="UserName">
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="text-center">
                <textarea id="TextArea1" cols="20" name="S1" rows="2"></textarea></td>
            <td>
                <asp:TextBox ID="txtErrorMessage" runat="server"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
