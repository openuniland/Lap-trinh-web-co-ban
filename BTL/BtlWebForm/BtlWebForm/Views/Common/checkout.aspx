<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="checkout.aspx.cs" Inherits="BtlWebForm.Views.Common.checkout" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Đặt hàng - Thanh toán</title>
    <link rel="stylesheet" href="/static/css/style.css">
    <link rel="stylesheet" href="/static/css/reposive.css">
</head>
<body style="overflow-y:hidden;">
    <div class="container-checkout">
        <form action="/checkout" method="post" class="form-login flex" id="form_checkout">
        <div class="left-container-checkout">
            <h1>Shop Quần áo & váy nữ</h1>
            <div class="ship">
                <div class="info_customer">
                    <div class="title">
                        <span class="__ti">Thông tin nhận hàng</span>
                        <%if (Session.Contents[Constant.USER_SESSION] == null)
                            { %>
                        <div class="_login">
                            <img src="/static/img/icon/user.png" alt="">
                            <a href="/login"><span>Đăng nhập</span></a>
                        </div>
                        <%} %>
                    </div>
                    <p>
                        <strong class="red"></strong>
                        <input type="text" placeholder="Họ tên" name="fullname" id="_fullname" runat="server">
                    </p>
                   
                    <p>
                        <strong class="red"></strong>
                        <input type="text" placeholder="Tên đăng nhập (dùng để theo dõi đơn hàng của bạn)" name="username" id="_username" runat="server">
                    </p>
                     <%if (Session.Contents[Constant.USER_SESSION] == null)
                        { %>
                    <p>
                        <strong class="red"></strong>
                        <input type="password" placeholder="Mật khẩu" name="password" id="_password" runat="server">
                    </p>
                    <%} %>
                    <p>
                        <strong class="red"></strong>
                        <input type="text" placeholder="Số điện thoại" name="phonenumber" id="_phonenumber" runat="server">
                    </p>
                    <p>
                        <strong class="red"></strong>
                        <input type="text" placeholder="Địa chỉ" name="address" id="_address" runat="server">
                    </p>
                    <p>
                        <textarea placeholder="Ghi chú cho đơn hàng này" name="_note"></textarea>
                    </p>
                </div>
                <div class="transport_pay">
                    <div class="transport">
                        <span class="__ti">
                            Vận chuyển
                        </span>
                        <div class="alert_green">
                            Vui lòng chọn thông tin giao hàng
                        </div>
                    </div>
                    <div class="pay">
                        <span class="__ti">
                            Thanh toán
                        </span>
                        <div class="COD">
                            <p>
                                <label for="cod">
                                    <input type="radio" id="cod" name="_pay" value="cod" checked>
                                    Thanh toán khi giao hàng (COD)
                                </label>
                            </p>
                           <!-- <p>
                                <label for="pay_online">
                                    <input type="radio" id="pay_online" name="_pay" value="pay_online">
                                    Thanh toán online
                                </label>
                            </p> -->
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="right-container-checkout">
            <div class="__ti">
                Đơn hàng (1 sản phẩm)
            </div>
            <!-- <hr /> -->
            <div class="list_order" id="list_server" runat="server">
                <!-- list do vao day -->
                
            </div>
            <div class="discount_code">
                <input type="text" placeholder="Nhập mã giảm giá" id="code">
                <input value="Áp dụng" type="button" id="btn_minus">
            </div>

            <div class="_total flex">
                <div class="_left">
                    <h4>Tổng cộng</h4>
                    <p>
                        < <a href="/cart"> Quay về giỏ hàng</a>
                    </p>
                </div>
                <div class="_right">
                    <h4 id="_total" runat="server"></h4>
                    <input value="ĐẶT HÀNG" type="button" id="btnOrder">
                </div>
            </div>
        </div>
    </form>
    </div>
    <script src="/static/js/js.js"></script>
    <script src="/static/js/checkout.js"></script>

</body>
    </html>
