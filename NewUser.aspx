<%@ Page Language="C#" MasterPageFile="~/Homemas.master" AutoEventWireup="true" CodeFile="NewUser.aspx.cs" Inherits="NewUser" Title="User Search History" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
<div align=center>
<br />
 <span class="style2">Register Your Details</span>
 <br />
<table cellpadding="1" cellspacing="10">

<tr>
<td class="style1">
    <b>User id :
</b>
</td>
<td>
    <asp:TextBox ID="TextBox1" runat="server" Width="197px"></asp:TextBox>
</td>
</tr>

<tr>
<td class="style1">
    <b>Password :</b>
</td>
<td>
    <asp:TextBox ID="TextBox2" runat="server" Width="197px" TextMode="Password"></asp:TextBox>
</td>
</tr>

<tr>
<td class="style1">
    <b>Full Name :
</b>
</td>
<td>
    <asp:TextBox ID="TextBox3" runat="server" Width="197px"></asp:TextBox>
</td>
</tr>

<tr>
<td class="style1">
    <b>Address :
</b>
</td>
<td>
    <asp:TextBox ID="TextBox4" runat="server" Height="68px" TextMode="MultiLine" 
        Width="197px"></asp:TextBox>
</td>
</tr>

<tr>
<td class="style1">
    <b>Mobile :
</b>
</td>
<td>
    <asp:TextBox ID="TextBox5" runat="server" Height="22px" Width="197px"></asp:TextBox>
</td>
</tr>

<tr>
<td class="style1">
    <b>Email Id :
</b>
</td>
<td>
    <asp:TextBox ID="TextBox6" runat="server" Width="197px"></asp:TextBox>
</td>
</tr>


</table>

<table cellpadding="2" cellspacing="10">
<tr>
<td>
    
    <asp:Button ID="Button1" runat="server" Text="Register" 
        onclick="Button1_Click" />
</td>
<td>
    
    <asp:Button ID="Button2" runat="server" Text="Cancel" />
</td>
</tr>

</table>
<br />
<br />

</div>

</asp:Content>

