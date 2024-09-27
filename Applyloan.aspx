<%@ Page Language="C#" MasterPageFile="~/Usermas.master" AutoEventWireup="true" CodeFile="Applyloan.aspx.cs" Inherits="Applyloan" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div align=center>
<br />
    <asp:Label ID="Label1" runat="server" Text="Apply Loan" Font-Bold="True"></asp:Label>
    <br />
    
    <table cellpadding="5" cellspacing="5" width="350" height="190">
    <tr>
    <td>
        <asp:Label ID="Label2" runat="server" Text="Loan Type" Font-Bold="True"></asp:Label>
    </td>
     <td>
         <asp:DropDownList ID="DropDownList1" runat="server" Font-Bold="True" 
             Width="200px">
         </asp:DropDownList>
    </td>
    </tr>
    <tr>
    <td>
        <asp:Label ID="Label3" runat="server" Text="Amount" Font-Bold="True"></asp:Label>
    </td>
     <td>
         <asp:TextBox ID="TextBox1" runat="server" Width="200px"></asp:TextBox>
    </td>
    </tr>
    <tr>
    <td>
        <asp:Label ID="Label4" runat="server" Text="Apply Date" Font-Bold="True"></asp:Label>
    </td>
     <td>
          <asp:TextBox ID="TextBox2" runat="server" Width="200px"></asp:TextBox>
    </td>
    </tr>
   
    <tr>
    <td>
        <asp:Label ID="Label5" runat="server" Text="Aadhar Card" Font-Bold="True"></asp:Label>
    </td>
     <td>
          <asp:TextBox ID="TextBox3" runat="server" Width="200px"></asp:TextBox>
    </td>
    </tr>
   
    <tr>
    <td>
        <asp:Label ID="Label6" runat="server" Text="Pan No" Font-Bold="True"></asp:Label>
    </td>
     <td>
          <asp:TextBox ID="TextBox4" runat="server" Width="200px"></asp:TextBox>
    </td>
    </tr>
   
    </table>
    
    <table>
    <tr>
    <td>
        <asp:Button ID="Button1" runat="server" Text="Apply" onclick="Button1_Click" />
    </td>
    </tr>
    </table>
    <br />
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" 
            GridLines="None" onrowdeleting="GridView1_RowDeleting" Width="900px">
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

