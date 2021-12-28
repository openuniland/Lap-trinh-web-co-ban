<%@ Page Title="" Language="C#" MasterPageFile="~/WebCommon.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="BtlWebForm.Views.Common.home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Trang chủ</title>
    <style>
        .edit_tit{
            color: white;
            text-decoration: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CommonBody" runat="server">
    <div class="container">
        <div class="banner">
            <img class="banner-img" src="/static/img/banner/slide_img_1.jpg" alt="">
        </div>

        <!-- Danh muc quan ao -->
        <div class="nav flex space_">
            <div class="nav_title">
                <a href="/QUAN_AO" class="edit_tit">Quần áo</a>
            </div>
            <div class="nav_list flex">
                <ul class="__ul flex">
                    <li><a href="/">Trang chủ</a></li>
                    <li><a href="/QUAN_AO">Sản phẩm</a></li>
                    <li><a href="/blog">Blog</a></li>
                    <li><a href="/about">Giới thiệu</a></li>
                    <li><a href="/contact">Liên hệ</a></li>
                </ul>
            </div>
        </div>
        <div class="form_category" id="quanao" runat="server">
            

            <!-- start list -->
            
            
        </div>
        <div class="clear"></div>
        <div class="banner flex" style="margin-top: 30px;">
            <div class="width49">
                <img class="img" src="/static/img/banner/banner_two_1.jpg" alt="">
            </div>
            <div class="width49">
                <img class="img" src="/static/img/banner/banner_two_22.jpg" alt="">
            </div>
        </div>

        <!-- start VAY_NU -->
        <div class="nav flex space_ margintop" style="background-color: #dd2b2b;">
            <div class="nav_title">
                <a href="/VAY_NU" class="edit_tit">Váy nữ</a>
            </div>
            <div class="nav_list flex">
                <ul class="__ul flex">
                    <li><a href="/">Trang chủ</a></li>
                    <li><a href="/VAY_NU">Sản phẩm</a></li>
                    <li><a href="/blog">Blog</a></li>
                    <li><a href="/about">Giới thiệu</a></li>
                    <li><a href="/contact">Liên hệ</a></li>
                </ul>
            </div>
        </div>
        <div class="form_category" id="vaynu" runat="server">
            
            
        </div>

        <div class="clear"></div>

        <div class="banner fullwidth" style="margin-top:30px">
            <img class="img" src="/static/img/banner/banner_full_width.png" alt="">
        </div>
    </div>


</asp:Content>
