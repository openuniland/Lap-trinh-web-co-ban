<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/WebCommon.Master" CodeBehind="login.aspx.cs" Inherits="BtlWebForm.Views.Common.login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Đăng nhập</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CommonBody" runat="server">
    <div class="form-login">
        <h3>ĐĂNG NHẬP TÀI KHOẢN</h3>
        <form action="/login" method="post" id="__form">
            <span class="validate">Tên tài khoản và mật khẩu phải có ít nhất 5 chữ số</span>
            <p>
                 <% if ("false".Equals(Request.QueryString.Get("msg"))) { %>
                            <span id="msg" runat="server" class="validate">Tài khoản hoặc mật khẩu sai</span>
                         <%  } %>
                <input oninput="changeTypeButtonLogin()" type="text" placeholder="Tên đăng nhập" name="username" id="username">
            </p>
            <p><input oninput="changeTypeButtonLogin()" type="password" placeholder="Mật khẩu" name="password" id="password"></p>
            <p><a href="#"><span>Quên mật khẩu</span></a></p>
            <p><input type="button" value="Đăng nhập" id="btn-login" class="btn" onclick="validateLogin()"></p>
            <p><span style="display:inline">Chưa có tài khoản đăng ký </span><a href="/register" id="a_register">tại đây</a></p>
        </form>
        <div class="login-3rd">
            <h3>Đăng nhập bằng Facebook hoặc Google</h3>
            <div class="fb-gg">
                <img src="/static/img/icon/fb.png" alt="">
                <img src="/static/img/icon/gg.png" alt="">
            </div>
        </div>
    </div>
    <script src="/static/js/cart.js"></script>
</asp:Content>
