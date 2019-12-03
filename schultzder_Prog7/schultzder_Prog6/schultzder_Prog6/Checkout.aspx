<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="schultzder_Prog6.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridView1" HorizontalAlign="Center" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="CartProdID" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:BoundField DataField="CartProdID" HeaderText="CartProdID" ReadOnly="True" SortExpression="CartProdID" />
            <asp:BoundField DataField="CartProdName" HeaderText="CartProdName" SortExpression="CartProdName" />
            <asp:BoundField DataField="CartProdQty" HeaderText="CartProdQty" SortExpression="CartProdQty" />
            <asp:BoundField DataField="CartProdUnitPrice" HeaderText="CartProdUnitPrice" SortExpression="CartProdUnitPrice" />
            <asp:BoundField DataField="CartProdCost" HeaderText="CartProdCost" SortExpression="CartProdCost" />
        </Columns>
</asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:UWPCS3870ConnectionString %>" SelectCommand="SELECT * FROM [Cart]"></asp:SqlDataSource>
</asp:Content>
