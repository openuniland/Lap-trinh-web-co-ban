<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="bai9.aspx.cs" Inherits="Bai9.bai9" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bài 9</title>
    <style>
        *{
            padding: 0;
            box-sizing: border-box;
        }

        body{
            display: flex;
            height: 90vh;
        }
        form{
            margin: auto;
        }

        .content{
            border: 3px solid #000;
            float: right;
            padding: 20px;
            width: 400px;
            height: 200px;
        }

        .content div > label{
            display: inline-block;
            width: 100px;
            margin: 5px 0;
        }

        .content div > input{
            width: 150px;
            margin: 5px 0;
        }

        .box__button{
            float: right;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" method="post" action="xuly.aspx">
            <div class="content">
            <div class="name">
                <label for="">Tên VXL</label>
                <input runat="server" type="text" name="tenvxl" id="txtTenVXL">
            </div>
            <div class="manufacturer">
                <label for="">Hãng</label>
                <input runat="server" type="text" name="hang" id="txtHang">
            </div>
            <div class="release">
                <label for="">Ngày ra mắt</label>
                <input runat="server" type="text" name="ngay" id="txtNgayRaMat">
            </div>
            <div class="cost">
                <label for="">Giá</label>
                <input runat="server" type="text" name="gia" id="txtCost">
            </div>
            <div class="box__button">
                
                <asp:Button ID="post" runat="server" Height="20px" OnClick="post_Click" Text="post" Width="40px" />
                <asp:Button ID="get" runat="server" Height="20px" Text="get" Width="40px" OnClick="get_Click" />
                
            </div>
        </div>
    </form>
</body>
</html>
