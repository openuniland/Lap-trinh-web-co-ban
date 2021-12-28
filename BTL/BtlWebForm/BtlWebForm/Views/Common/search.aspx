<%@ Page Title="" Language="C#" MasterPageFile="~/WebCommon.Master" AutoEventWireup="true" CodeBehind="search.aspx.cs" Inherits="BtlWebForm.Views.Common.search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Tìm kiếm</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CommonBody" runat="server">
    <section class="vitritrang">
        <div class="container">
            <ul>
                <li class="tenvitri"><a href="/"> Trang chủ</a></li>
                <li class="tenvitri"><a href="">></a></li>
                <li class="tenvitri"><a href=""><span> Tìm kiếm</span></a></li>
            </ul>
        </div>
    </section>
    <section class="content">
        <div class="container" >
            <div class="message margin-bottom-20">
                <h1 id="CountResult" runat="server"></h1>
            </div>
            <div class="products" id="ListProduct" runat="server">
                
                


            </div>
        </div>
    </section>
    <div class="clear"></div>
    
    <div class="pagination">
        <a href=""><span class="arrow-left"></span></a>
        <a href=""><span>1</span></a>
        <a href=""><span class="arrow-right"></span></a>
    </div>

</asp:Content>
