<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="guimail.aspx.cs" Inherits="QuanLyCongBoKhoaHoc.Admin.guimail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="Label1" runat="server" Text="email from"></asp:Label>
        <asp:TextBox ID="from" runat="server"></asp:TextBox>  <br />
         <asp:Label ID="Label2" runat="server" Text="pass"></asp:Label>
        <asp:TextBox ID="pass" runat="server"></asp:TextBox> <br />
         <asp:Label ID="Label3" runat="server" Text="email to"></asp:Label>
        <asp:TextBox ID="to" runat="server"></asp:TextBox> <br />
         <asp:Label ID="Label4" runat="server" Text="chu de"></asp:Label>
        <asp:TextBox ID="chude" runat="server"></asp:TextBox> <br />
         <asp:Label ID="Label5" runat="server" Text="dinh kem"></asp:Label>
        <asp:FileUpload ID="FileUpload1" runat="server" /> <br />
         <asp:Label ID="Label6" runat="server" Text="message"></asp:Label>
        <asp:TextBox ID="tinnhan" runat="server"></asp:TextBox> <br />
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" /> <br />
        <asp:Label ID="thongbao" runat="server" Text=""></asp:Label>
    </form>
</body>
</html>
