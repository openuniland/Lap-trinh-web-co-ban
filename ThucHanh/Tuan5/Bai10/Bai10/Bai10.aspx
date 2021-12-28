<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Bai10.aspx.cs" Inherits="Bai10.Bai10" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #txtNoiDung {
            width: 387px;
            height: 123px;
        }
        #content {
            width: 469px;
            height: 125px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Nhập nội dung:</div>
        <p>
            <textarea runat="server" id="txtNoiDung" name="S1"></textarea></p>
        <p>
            Upload tại đây:</p>
        <p>
            <asp:FileUpLoad ID="txtFile" runat="server" />
        </p>
        <asp:Button ID="submit" runat="server" OnClick="submit_Click" Text="Save" />
    </form>
    <p>
        <textarea runat="server" id="content" name="S2"></textarea>
    </p>
</body>
</html>
