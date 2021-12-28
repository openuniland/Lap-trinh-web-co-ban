// mới đầu file này định để cho cart nhưng thêm lung tung h ngại sửa

window.onload = function msg() {
    var url = window.location.href;
    if (url.includes("?msg=success"))
        alert("Đơn hàng của bạn đang được xử lý, bạn có thể theo dõi thông tin đơn hàng bằng tài khoản này");
    if (url.includes("?msg=register-success"))
        alert("Đăng ký tài khoản thành công, xin mời bạn đăng nhập");
    if (url.includes("?msg=false-field-null"))
        alert("Chưa thể thêm sản phẩm vì bạn nhập thiếu thông tin cần thiết");
    if (url.includes("/cart")) {
        if (url.includes("?msg=cart-null"))
            alert("Giỏ hàng của bạn đang rỗng");
        document.getElementById('_cart2').style.display = 'block';
        document.getElementById('_cart1').style.display = 'none';
    }
    if (location.pathname == '/admin')
        loadForm(1);
}

