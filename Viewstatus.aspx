<%@ Page Language="C#" MasterPageFile="~/Usermas.master" AutoEventWireup="true" CodeFile="Viewstatus.aspx.cs" Inherits="Viewstatus" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div align=center>
<br />
    <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" 
        GridLines="None" Width="800px" 
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

<table width="400">
<tr>
<td>

    <asp:Label ID="Label4" runat="server" Text="Id" Font-Bold="True"></asp:Label>
   
    </td>
    <td>
        <asp:TextBox ID="TextBox9" runat="server"  Width="200px"></asp:TextBox>
    </td>
</tr>
<tr>
<td>

    <asp:Label ID="Label3" runat="server" Text="Application No" Font-Bold="True"></asp:Label>
   
    </td>
    <td>
        <asp:TextBox ID="TextBox1" runat="server"  Width="200px"></asp:TextBox>
    </td>
</tr>
<tr>
<td>

    <asp:Label ID="Label1" runat="server" Text="User Id" Font-Bold="True"></asp:Label>
   
    </td>
    <td>
     <asp:TextBox ID="TextBox2" runat="server"  Width="200px"></asp:TextBox>
    
    </td>
</tr>
<tr>
<td>

    <asp:Label ID="Label2" runat="server" Text="Loan Type" Font-Bold="True"></asp:Label>
   
    </td>
    <td>
        <asp:TextBox ID="TextBox3" runat="server" Height="22px" 
            Width="200px"></asp:TextBox>
    </td>
</tr>
<tr>
<td>

    <asp:Label ID="Label7" runat="server" Text="Amount" Font-Bold="True"></asp:Label>
   
    </td>
    <td>
        <asp:TextBox ID="TextBox4" runat="server" Height="22px" 
            Width="200px"></asp:TextBox>
    </td>
</tr>
<tr>
<td>

    <asp:Label ID="Label5" runat="server" Text="Apply Date" Font-Bold="True"></asp:Label>
   
    </td>
    <td>
        <asp:TextBox ID="TextBox5" runat="server" Height="22px" 
            Width="200px"></asp:TextBox>
    </td>
</tr>
<tr>
<td>

    <asp:Label ID="Label6" runat="server" Text="Status" Font-Bold="True"></asp:Label>
   
    </td>
    <td>
       
        <asp:TextBox ID="TextBox8" runat="server" Width="200px"></asp:TextBox>
    </td>
</tr>
<tr>
<td>

    <asp:Label ID="Label8" runat="server" Text="Interst" Font-Bold="True"></asp:Label>
   
    </td>
    <td>
       <asp:TextBox ID="TextBox6" runat="server" Height="22px" 
            Width="200px"></asp:TextBox>
    </td>
</tr>
<tr>
<td>

    <asp:Label ID="Label9" runat="server" Text="Total Year" Font-Bold="True"></asp:Label>
   
    </td>
    <td>
       <asp:TextBox ID="TextBox7" runat="server" Height="22px" 
            Width="200px"></asp:TextBox>
    </td>
</tr>
    </table>
    
      <table width="200">
<tr>
<td>

    <asp:Button ID="Button1" runat="server" Text="View" 
        onclick="Button1_Click" />
    <asp:Label ID="Label10" runat="server" Text="Label" Visible="False"></asp:Label>
    </td>
  
</tr>

    </table>
</div>
</asp:Content>

