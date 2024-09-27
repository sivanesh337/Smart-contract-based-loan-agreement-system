<%@ Page Language="C#" MasterPageFile="~/Adminmas.master" AutoEventWireup="true" CodeFile="Loanapproved.aspx.cs" Inherits="Loanapproved" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div align=center>
    <asp:Label ID="Label4" runat="server" Text="Approved Loan"></asp:Label>
    <br />
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
       
             <asp:DropDownList ID="DropDownList1" runat="server" Width="200px">
        <asp:ListItem>Approved</asp:ListItem>
        <asp:ListItem>Reject</asp:ListItem>
    </asp:DropDownList>
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

    <asp:Button ID="Button1" runat="server" Text="Approved" 
        onclick="Button1_Click" />
    <asp:Label ID="Label10" runat="server" Text="Label" Visible="False"></asp:Label>
    </td>
  
</tr>

    </table>
    <br />
    <asp:GridView ID="GridView2" runat="server" CellPadding="4" ForeColor="#333333" 
        GridLines="None" Width="700px">
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
</div>
</asp:Content>

