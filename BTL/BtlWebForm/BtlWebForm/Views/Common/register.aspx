<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/WebCommon.Master" CodeBehind="register.aspx.cs" Inherits="BtlWebForm.Views.Common.register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Đăng ký</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CommonBody" runat="server">
      <div class="form-login">
        <h3>ĐĂNG KÝ TÀI KHOẢN</h3>
        <form action="/register" method="post" id="__form">
            
            <p>
                <span id="fullname_warn" runat="server"></span>
                <input type="text" placeholder="Họ tên" name="fullname" id="fullname" runat="server"  ClientIDMode="Static">
            </p>

            <p>
                <span id="username_warn" runat="server"></span>
                <input type="text" placeholder="Tên đăng nhập" name="username" id="username" runat="server" ClientIDMode="Static">
            </p>

            <p>
                 <span id="phonenumber_warn" runat="server"></span> 
                <input type="text" placeholder="Số điện thoại" name="phonenumber" id="phonenumber" runat="server" ClientIDMode="Static">
            </p>

            <p>
                <span id="password_warn" runat="server"></span>
                <input type="password" placeholder="Mật khẩu" name="password" id="password" runat="server"  ClientIDMode="Static">
            </p>

            <p>
                <span id="repassword_warn" runat="server"></span>
                <input type="password" placeholder="Nhập lại mật khẩu" name="repassword" id="repassword" runat="server"  ClientIDMode="Static">
            </p>

            <p>
                <a href="#"><span>Quên mật khẩu</span></a>
            </p>
            <p><input type="button" value="Đăng ký" class="btn" id="btn-register" onclick="validateRegister()"></p>
        </form>
        <p><span style="display:inline">Đã có tài khoản ? Đăng nhập </span><a href="/login" id="a_register">tại đây</a></p>
        <div class="login-3rd">
            <h3>Đăng nhập bằng Facebook hoặc Google</h3>
            <div class="fb-gg">
                <img src="/static/img/icon/fb.png" alt="">
                <img src="/static/img/icon/gg.png" alt="">
            </div>
        </div>
    </div>
    

</asp:Content>