<%@ Page Language="C#" MasterPageFile="~/Homemas.master" AutoEventWireup="true" EnableEventValidation="false"  CodeFile="Adminlogin.aspx.cs" Inherits="Adminlogin" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div align=center>
<table cellpadding="5" cellspacing="5">
<tr>
<td>
    <asp:Label ID="Label1" runat="server" Text="Admin Login" Font-Bold="True" 
        Font-Size="Large" ForeColor="Black"></asp:Label>
</td>
</tr>
</table>
<table cellpadding="5" cellspacing="5" width="400" height="80">
<tr>
<td >
    <asp:Label ID="Label2" runat="server" Text="User Name" Font-Bold="True" 
        ForeColor="Black"></asp:Label>
</td>
<td>
    <asp:TextBox ID="TextBox1" runat="server" ForeColor="Black"></asp:TextBox>
</td>
</tr>
<tr>
<td>
    <asp:Label ID="Label3" runat="server" Text="Password" Font-Bold="True" 
        ForeColor="Black"></asp:Label>
</td>
<td>
    <asp:TextBox ID="TextBox2" runat="server" TextMode="Password" ForeColor="Black"></asp:TextBox>
</td>
</tr>
</table>
<table cellpadding="5" cellspacing="5">
<tr>
<td>
    <asp:Button ID="Button1" runat="server" Text="Login" onclick="Button1_Click" 
        ForeColor="Black" />
</td>
</tr>
</table>
<table>
<tr>
<td>
    
</td>
</tr>
</table>
</div>
</asp:Content>

