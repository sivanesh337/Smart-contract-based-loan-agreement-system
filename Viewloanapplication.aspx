<%@ Page Language="C#" MasterPageFile="~/Adminmas.master" AutoEventWireup="true" CodeFile="Viewloanapplication.aspx.cs" Inherits="Viewloanapplication" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div align=center>

    <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" 
        GridLines="None" Width="900px" 
        onselectedindexchanging="GridView1_SelectedIndexChanging">
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
        </Columns>
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
<br />
<table width="400">
<tr>
<td>

    <asp:Label ID="Label3" runat="server" Text="Application No" Font-Bold="True"></asp:Label>
   
    </td>
    <td>
        <asp:TextBox ID="TextBox2" runat="server"  Width="200px"></asp:TextBox>
    </td>
</tr>
<tr>
<td>

    <asp:Label ID="Label1" runat="server" Text="Status" Font-Bold="True"></asp:Label>
   
    </td>
    <td>
     <asp:DropDownList ID="DropDownList1" runat="server" Width="200px">
        <asp:ListItem>Uploaddocument</asp:ListItem>
        <asp:ListItem>Reject</asp:ListItem>
    </asp:DropDownList>
    </td>
</tr>
<tr>
<td>

    <asp:Label ID="Label2" runat="server" Text="Description" Font-Bold="True"></asp:Label>
   
    </td>
    <td>
        <asp:TextBox ID="TextBox1" runat="server" Height="100px" TextMode="MultiLine" 
            Width="200px"></asp:TextBox>
    </td>
</tr>
    </table>
    
    <table width="200">
<tr>
<td>

    <asp:Button ID="Button1" runat="server" Text="Update" onclick="Button1_Click" />
   
    </td>
  
</tr>

    </table>
</div>
</asp:Content>

