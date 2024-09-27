<%@ Page Language="C#" MasterPageFile="~/Adminmas.master" AutoEventWireup="true" CodeFile="Addloan.aspx.cs" Inherits="AddStaff" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <script type="text/javascript">
var r={'special':/[\W\a-zA-Z]/g}
function valid(o,w)
{
  o.value = o.value.replace(r[w],'');
}

var r1={'special':/[\W\0-9]/g}
function valid1(o,w)
{
  o.value = o.value.replace(r1[w],'');
}
</script> 
    <div align=center>
<table>
<tr>
<td>
    <asp:Label ID="Label1" runat="server" Text="Add Loan" 
        Font-Bold="True" Font-Size="Medium"></asp:Label>
</td>
</tr>
</table>
<table cellpadding="10" cellspacing="5">
<tr>
<td style="text-align: right">
    <asp:Label ID="Label2" runat="server" Text="Loan Name"></asp:Label>
</td>
<td>
    <asp:TextBox ID="TextBox1" runat="server" Width="225px"></asp:TextBox>
</td>
<td>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ErrorMessage="*" ControlToValidate="TextBox1"></asp:RequiredFieldValidator>
</td>
</tr>


</table>
<table cellpadding="10" cellspacing="5">
<tr>
<td>
    <asp:Button ID="Button1" runat="server" Text="Add" 
        onclick="Button1_Click" />
</td>
<td>
    
</td>
<td>
   
</td>
</tr>
</table>
<br />
<table>
<tr>
<td>
    <asp:GridView ID="GridView1" runat="server" BackColor="White" 
        BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
        GridLines="Horizontal" onrowdeleting="GridView1_RowDeleting" 
        onselectedindexchanging="GridView1_SelectedIndexChanging">
        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
        <Columns>
            <asp:CommandField ShowDeleteButton="True" />
        </Columns>
        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
        <AlternatingRowStyle BackColor="#F7F7F7" />
    </asp:GridView>
</td>
</tr>
</table>
</div>
</asp:Content>

