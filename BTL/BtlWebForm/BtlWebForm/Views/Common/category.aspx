<%@ Page Title="" Language="C#" MasterPageFile="~/WebCommon.Master" AutoEventWireup="true" CodeBehind="category.aspx.cs" Inherits="BtlWebForm.Views.Common.category" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title id="__title" runat="server"></title>
    <style>
        .cursor{
            cursor: pointer;
        }
        .cursor:hover{
            font-weight: bold;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CommonBody" runat="server">
    <section class="vitritrang">
        <div class="container">
            <ul>
                <li class="tenvitri"><a href="/"> Trang chủ</a></li>
                <li class="tenvitri"><a href="">></a></li>
                <li class="tenvitri"><a href="/QUAN_AO" id="url_server" runat="server"><span id="name_page" runat="server"></span></a></li>
            </ul>
        </div>
    </section>

    <section class="content">
        <div class="container">
            <div class="flex">
                <div class="left-container">
                    <div class="title-container">
                        <div class="left-title-container">
                            <h3>Laptop</h3>
                            <span id="quantity_result" runat="server">(10 sản phẩm)</span>
                            <div class="clear"></div>
                        </div>

                        <div class="right-title-container">
                            <span>Sắp xếp</span>
                            <ul id="selectSort" onclick="showSort()">
                                <li>
                                    <span id="dangchon" style="font-size: 17px; color: blue">Chưa chọn</span>
                                    <span class="ky-tu-tro-xuong">
                                        <img src="img/icon/down.gif" alt="">
                                    </span>

                                </li>
                                <li class="sort-type">
                                    <ul>
                                        <li onclick="sort(this)">Mới nhất</li>
                                        <li onclick="sort(this)">Giá tăng dần</li>
                                        <li onclick="sort(this)">Giá giảm dần</li>
                                    </ul>
                                </li>
                            </ul>
                        </div>
                    </div>
                     <!-- edit -->
                    <div id="__filter" onclick="btn_close_filter()">
                        <img src="/static/img/icon/filter.png" alt=""> Lọc
                    </div>
                    <div class="products clear" id="data_server" runat="server">

                    </div>
                </div>
                <div class="right-container" id="category_i">
                    <span class="close" onclick="btn_close_filter()">x</span>
                    <div class="right-title">
                        <h3>Tìm theo</h3>
                    </div>

                    <div class="search-by-conditions">

                        <div class="price-range">
                            <fieldset id="filter1">
                                <legend>
                                    <h3>Khoảng giá</h3>
                                </legend>
                                <input onchange="filter1(this)" type="checkbox" name="filter" value="all" id="f_all"><label for="f_all"  class="cursor">Tất cả</label><br><br>
                                <input onchange="filter1(this)"  type="checkbox" name="filter" value="duoi-100k" id="f_0_10"><label  class="cursor"  for="f_0_10">Dưới 100k</label><br><br>
                                <input onchange="filter1(this)"  type="checkbox" name="filter" value="tu-100k-150k" id="f_10_15"><label class="cursor"  for="f_10_15">Từ 100k - 150k</label><br><br>
                                <input onchange="filter1(this)" type="checkbox" name="filter" value="tu-150k-200k" id="f_15_20"><label class="cursor"  for="f_15_20">Từ 150k - 200k</label><br> <br>
                                <input onchange="filter1(this)" type="checkbox" name="filter" value="tu-200k-250k" id="f_20_25"><label class="cursor"  for="f_20_25">Từ 200k - 250k</label><br> <br>
                                <input onchange="filter1(this)" type="checkbox" name="filter" value="hon-250k" id="f_25"><label class="cursor"  for="f_25">Trên 250k</label><br> <br>
                            </fieldset>
                        </div>
                        <!-- ok -->
                    </div>
                </div>

            </div>
    </section>
    <script src="/static/js/category.js"></script>
</asp:Content>
