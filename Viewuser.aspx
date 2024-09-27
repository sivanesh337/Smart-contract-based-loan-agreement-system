<%@ Page Language="C#" MasterPageFile="~/Adminmas.master" AutoEventWireup="true" CodeFile="Viewuser.aspx.cs" Inherits="Viewuser" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div align=center>
    <asp:Label ID="Label1" runat="server" Text="User Details" Font-Bold="True"></asp:Label>
    <br />
    
    <asp:GridView ID="GridView1" runat="server" BackColor="White" 
        BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
        Width="700px">
        <RowStyle BackColor="White" ForeColor="#330099" />
        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
        <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
    </asp:GridView>
</div>
</asp:Content>

