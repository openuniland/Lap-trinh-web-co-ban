<%@ Page Title="" Language="C#" MasterPageFile="~/WebCommon.Master" AutoEventWireup="true" CodeBehind="cart.aspx.cs" Inherits="BtlWebForm.Views.Common.cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CommonBody" runat="server">
    <div class="container_cart">
        <div class="form-cart frame">
            <div class="content-cart">
                <div class="title-cart">
                    Giỏ hàng của bạn
                </div>
                <div class="row-title" id="status_order" runat="server">
                    
                    <div class="title-view view-product-info">
                        Sản phẩm
                    </div>
                    <div class="title-view view-product-price">
                        Giá
                    </div>
                    <div class="title-view view-product-quantity">
                        Số lượng
                    </div>
                    <div class="title-view view-product-total-money">
                        Tổng tiền
                    </div>
                </div>
                <div class="view-product-selected" style="max-height: none;" id="data_render" runat="server">
                    <!-- data render from server -->
                    
                </div>
            </div>
            <div class="check-out">
                <span>Tổng số thành tiền: </span>
                <span class="red" id="tong-tien">
                    <b id="tong" runat="server">0đ</b>
                </span>
                <br style="margin: 15px;">
                <button id="btn-add-to-cart" type="button" onclick="checkout();">Tiến hành thanh toán</button>
            </div>
        </div>
    </div>
    <script src="/static/js/cart.js"></script>
</asp:Content>
