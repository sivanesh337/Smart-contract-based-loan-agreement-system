<%@ Page Language="C#" MasterPageFile="~/Usermas.master" AutoEventWireup="true" CodeFile="Uploadmaterial.aspx.cs" Inherits="Uploadmaterial" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div align=center>
    <table>
    <tr>
    <td>
        <asp:Label ID="Label4" runat="server" Text="Upload Document" Font-Bold="True"></asp:Label>
    </td>
    </tr>
    </table>
<table height="200" width="400">
<tr>
<td>
    <asp:Label ID="Label7" runat="server" Text="Application No"></asp:Label>
</td>
<td>
    <asp:TextBox ID="TextBox3" runat="server" Width="210px"></asp:TextBox>
</td>
</tr>
<tr>
<td>
    <asp:Label ID="Label5" runat="server" Text="Browse File"></asp:Label>
</td>
<td>
    <asp:FileUpload ID="FileUpload1" runat="server" />
</td>
</tr>

<tr>
<td>
    <asp:Label ID="Label2" runat="server" Text="Upload Date"></asp:Label>
</td>
<td>
    <asp:TextBox ID="TextBox2" runat="server" Width="210px"></asp:TextBox>
</td>
</tr>

</table>
<table>
    
<tr>
<td>
    <asp:Button ID="Button1" runat="server" Text="Add" onclick="Button1_Click" 
        style="height: 26px" />
</td>
</tr>
</table>
<asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" 
        GridLines="None" onrowdeleting="GridView1_RowDeleting" Width="500px">
    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
    <Columns>
        <asp:CommandField ShowDeleteButton="True" />
    </Columns>
    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
    <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
</div>
</asp:Content>

