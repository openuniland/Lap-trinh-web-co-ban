<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="loginPage.aspx.cs" Inherits="BTL_LapTrinhWeb_cb.loginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" method="post" action="loginPage_Succes.aspx">
        <div>
            Tài khoản:
            <asp:TextBox ID="user" runat="server" Width="200px"></asp:TextBox>
        </div>
        Mật khẩu:
        <asp:TextBox ID="password" runat="server" style="margin-left: 4px" Width="200px"></asp:TextBox>
        <p>
            <asp:Button ID="submit" runat="server" OnClick="submit_Click" Text="Đăng nhập" />
        </p>
    </form>
</body>
</html>
