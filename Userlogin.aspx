<%@ Page Language="C#" MasterPageFile="~/Homemas.master" AutoEventWireup="true" CodeFile="Userlogin.aspx.cs" Inherits="studentlogin" Title="Untitled Page" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <div align=center>
    <br />
    <asp:Label ID="Label1" runat="server" Text="User Login" Font-Bold="True"></asp:Label>
    <br />
    <tr align=center>
    <td>
    <table cellpadding="2" cellspacing="4">
    <tr>
    <td class="style2">
        <span class="style1">User Id :</span>
    </td>
    <td>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    </td>
    </tr>
    <tr>
    <td class="style2">
        <span class="style1">Password :</span>
    </td>
    <td>
        <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
    </td>
    </tr>
    
    </table>
    <table>
    <tr>
    <td>
       
        <asp:Button ID="Button2" runat="server" Text="Login" onclick="Button2_Click" />
    </td>
    <td>
        
        <asp:Button ID="Button3" runat="server" Text="Cancel" onclick="Button3_Click" />
    </td>
    </tr>
    </table>
     <table>
    <tr>
    <td>
        
        <asp:Button ID="Button1" runat="server" Text="New User" 
            onclick="Button1_Click" />
    </td>
 
    </tr>
    </table>
    </td>
    </tr>
    </div>
</asp:Content>

