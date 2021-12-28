var showmenu = 0;
function showMenu() {

    var x = document.getElementById('lmenu');
    if (showmenu == 0) {
        x.style.height = "205px";
        showmenu = 1;
    }
    else {
        x.style.height = "0px";
        showmenu = 0;
    }

}

// end header

function btnClose(form) {
    var x = document.getElementsByClassName("show-form")[0];
    x.style.display = "none";
}
function btnShowForm(form, ID) {
    var x = document.getElementsByClassName("show-form")[0];
    x.style.display = "block";
    if (form == 1) {
        // Gọi ajax lấy thông tin ID
        var xhttp = new XMLHttpRequest();
        xhttp.onreadystatechange = function () {
            if (this.readyState == 4 && this.status == 200) {
                var dom = document.getElementById("result-ajax");
                dom.innerHTML = this.responseText;
                hideImg();
            }
        };
        xhttp.open("GET", "/api/product/" + ID, true);
        xhttp.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
        xhttp.send();
        
        x.firstElementChild.style.display = "block";
        x.lastElementChild.style.display = "none";
    }
    else {
        x.firstElementChild.style.display = "none";
        x.lastElementChild.style.display = "block";
        // tạm để đây
        tongTienGioHang();
    }
}

function showImage(img) {
    var urlImage = img.getAttribute('src');
    document.getElementById('bigImg').setAttribute('src', urlImage);
}



function hideImg() {
    var a = document.getElementsByClassName('small-img');

    for (var i = 3; i < a.length; i++) {
        a[i].style.display = "none";
    }

}

var start = 0, end = 2;

function nextImg() {
    var a = document.getElementsByClassName('small-img');
    if (end >= a.length - 1) {
        document.getElementsByClassName('chuyen')[1].style.display = "none";
    }
    else {
        document.getElementsByClassName('chuyen')[0].style.display = "block";
        end = (end + 3 >= a.length) ? a.length - 1 : end + 3;
        start = end - 2;

        for (var i = 0; i < a.length; i++) {
            if (i >= start && i <= end)
                a[i].style.display = "block";
            else
                a[i].style.display = "none";
        }
    }


}

function backImg() {
    var a = document.getElementsByClassName('small-img');
    if (start <= 0) {
        document.getElementsByClassName('chuyen')[0].style.display = "none";
        
    }
    else {
        document.getElementsByClassName('chuyen')[1].style.display = "block";
        start = (start - 3 <= 0) ? 0 : start - 3;
        end = start + 2;

        for (var i = 0; i < a.length; i++) {
            if (i >= start && i <= end)
                a[i].style.display = "block";
            else
                a[i].style.display = "none";
        }
    }
}
var b = 0;
function a()
{
    if (b == 0)
    {
        b = 1
        document.title = "ok"
        window.history.pushState('page2', 'Title', '/page2.php');
    } 
    else
    {
        b = 0
        document.title = "ok lun"
        window.history.pushState('page2', 'Title', '/page1.php');
    }
}

// xử lí tăng giảm ô input
function addQuantity(x)
{
    var input = x.parentNode.children[1];
    var num = input.value;
    if (isNaN(parseInt(num)))
        num = 1;
    else
        num ++;
    // nếu là NaN (not number) thì nó sẽ insert 1
    input.value = num;
}

function minusQuantity(x)
{
    var input = x.parentNode.children[1];
    var num = input.value;
    if (isNaN(parseInt(num)))
        num = 1;
    else
        num --;
    if (num <= 0)
        num = 1;
    input.value = num;
}

function sumOfMoney(_this)
{
    checkInput(_this);
    var parent = _this.parentNode.parentNode.parentNode;
    var unitPrice = parent.children[1].children[0].innerHTML;
    unitPrice = unitPrice.replaceAll(',', '');
    unitPrice = unitPrice.replaceAll('₫', '');
    unitPrice = parseInt(unitPrice);

    var total = unitPrice * _this.value;
    parent.children[3].children[0].textContent = formatMoney(total);
    tongTienGioHang();
}

function formatMoney(number)
{
    var numString = number.toString();
    // 123456 -> 123,456
    // không xử lý trường hợp số 0 đứng đầu vì ở đây ko thể đụng tới

    var x = 0;
    var temp = '';

    for (var i = numString.length - 1; i >= 0; i--)
    {
        x ++;
        temp += numString[i];
        if (x == 3 && i != 0)
        {
            x = 0;
            temp += ',';
        }
    }
    var out = '';
    for (var i = temp.length-1; i >= 0 ; i--)
        out += temp[i];
    out += ' ₫';
    return out;
}

function checkInput(x)
{
    var num = parseInt(x.value);
    if (isNaN(num) || num <= 0)
        num = 1;
    x.value = num;
}

// viết tạm
function addToCart(id)
{
    var quantity = document.getElementById('_quantity_').value;
    changeProductSS(id, "add", quantity);

    // mobile ko show form được như pc
    if (window.innerWidth < "1000") {
        window.location.href = "/cart";
        return;
    }
    
    // showNameProClick(this);
    //changeProductSS(id, "add", quantity);
    btnShowForm(2, 1);
    getProductToSession();
    tongTienGioHang();
}

function removeProduct(x)
{ 
    var row = x.parentNode.parentNode.parentNode;
    row.parentNode.removeChild(row);
    tongTienGioHang();
    var ID = x.getAttribute('num');
    changeProductSS(ID, "remove", 0);

}

function tongTienGioHang()
{
    var row = document.getElementsByClassName("view-row-product");
    var sum = 0;
    for (var i = 0; i < row.length; i++)
    {
        var money = row[i].getElementsByClassName("red")[1].innerHTML;
        // chuyen 14.000.000 đ về 14000000
        money = money.replaceAll(',', '');
        money = money.replaceAll('₫', '');
        money = parseInt(money);
        sum += money;
    }
    document.getElementById("tong-tien").innerHTML = formatMoney(sum);
}

function showSort()
{
    var x = document.getElementsByClassName('sort-type')[0];
    x.style.display = (x.style.display == 'block') ? 'none' : 'block';
}


// custom
function addProductSS(ID) {
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            var dom = document.getElementById("result-ajax");
            dom.innerHTML = this.responseText;
            // lat xu li thong bao da them vao gio hang
        }
    };
    xhttp.open("GET", "/api/cart/" + ID, false);
    xhttp.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
    xhttp.send();
} 

function changeProductSS(ID, type, quantity) {
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            var dom = document.getElementById("result-ajax");
            dom.innerHTML = this.responseText;
            // lat xu li thong bao da them vao gio hang
        }
    };
    xhttp.open("GET", "/api/cart/" + ID + "/" + type + "/" + quantity, false);
    xhttp.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
    xhttp.send();
} 


// query date from session

function getProductToSession() {
    var load = document.getElementById("img_loading");
    
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            var dom = document.getElementById("data_session");
            load.style.display = "none"; // ẩn ảnh gif xoay
            var htmlResponse = this.responseText.split('|');
            if (htmlResponse != '') {
                dom.innerHTML = htmlResponse[1];
                changeNumberOrder(htmlResponse[0]);
            } else {
                dom.innerHTML = "Bạn chưa chọn sản phẩm nào";
            }
            
            // lat xu li thong bao da them vao gio hang
        }
    };
    
    xhttp.open("GET", "/api/cart", false);
    xhttp.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
    xhttp.send();
}


// show form add
function showFormCartSession(ID, typeForm) {
    btnShowForm(typeForm);
    
    var load = document.getElementById("img_loading");
    load.style.display = "inline";
    addProductSS(ID);  
    getProductToSession();
    tongTienGioHang();

    
}

// thay đổi số lượng ở icon giỏ hàng
function changeNumberOrderThenRemove() {
    var x = document.getElementById('number_oder');
    x.textContent = parseInt(x.innerHTML) - 1;
}
function changeNumberOrder(value) {
    var x = document.getElementById('number_oder');
    x.textContent = value;
}

// gom ham tang so luong
function addChangeQuantity(x, ID){
    addQuantity(x);
    sumOfMoney(x.parentNode.children[1]);
    addProductSS(ID);
}

function minusChangeQuantity(x, ID, quantity) {
    minusQuantity(x);
    sumOfMoney(x.parentNode.children[1]);
    changeProductSS(ID, "minus", 1);
}

// Lưu onchange vào session
function onchangeAddSession(ID,x) {
    checkInput(x);
    var quantity = x.value;
    changeProductSS(ID, "add", quantity);
}

function showNameProClick(x) {
    var parent = x.parentNode.parentNode;
    var nodeA = parent.getElementsByClassName('title_name_product')[0];
    var nameProduct = nodeA.getAttribute("title");
    var urlProduct = nodeA.getAttribute("href");

    var html = "Bạn đã thêm <a href=" + urlProduct + " id='name_pro_click'>" + nameProduct + "</a> vào giỏ hàng";

    document.getElementById("title_cart").innerHTML = html;

}

// xu li click icon cart
function showCart() {
    btnShowForm(2);
    var load = document.getElementById("img_loading");
    load.style.display = "inline";
    document.getElementById("title_cart").innerHTML = "<b>Giỏ hàng của bạn</b>";
    getProductToSession();
    tongTienGioHang();
}

function checkout() {
    window.location = "/checkout";
}

// alert page cart


// validate form
// form login
function validateLogin() {
    let username = document.getElementById('username');
    let password = document.getElementById('password');

    if (username.value.length < 5 || password.value.length < 5) {
        document.getElementsByClassName("validate")[0].style.display = 'block';
    }
    else
        document.getElementById('__form').submit();
};

function changeTypeButtonLogin() {
    let username = document.getElementById('username').value;
    let password = document.getElementById('password').value;
    let btn = document.getElementById('btn-login');
    if (username.length >= 5 && password.length >= 5)
        btn.setAttribute('type', 'submit');
    else
        btn.setAttribute('type', 'button')
}


// form register
function validateRegister() {
    let fullname = document.getElementById('fullname').value;
    let username = document.getElementById('username').value;
    let phonenumber = document.getElementById('phonenumber').value;
    let password = document.getElementById('password').value;
    let repassword = document.getElementById('repassword').value;

    let username_warn = document.getElementById('username_warn');
    let fullname_warn = document.getElementById('fullname_warn')
    let phonenumber_warn = document.getElementById('phonenumber_warn');
    let password_warn = document.getElementById('password_warn');
    let repassword_warn = document.getElementById('repassword_warn');
    var correct = true;

    if (fullname.length <= 4) {
        correct = false;
        fullname_warn.textContent = "* Nhập tên đầy đủ";
    }
    else
        fullname_warn.textContent = "";

    if (username.length < 5 || username.includes(' ')) {
        correct = false;
        username_warn.textContent = "* Tên đăng nhập chứa ít nhất 5 ký tự, không có dấu cách";
    }
    else
        username_warn.textContent = "";

    /*
        regex: ^0: Bắt đầu từ số 0
               $: Kết thúc 
               [abc] khớp với 1 trong các ký tự
               \d: Tương đương với [0-9] -> khớp với số từ 0-> 9
               {8} lặp lại 8 lần với ký tự đứng trước nó
    */
    if (phonenumber.match(/^0[23789]\d{8}$/g) == null) {
        correct = false;
        phonenumber_warn.textContent = "* Không chứa ký tự, sử dụng 1 trong các đầu số 02, 03, 07, 08, 09, có độ dài là 10 chữ số";
    }
    else
        phonenumber_warn.textContent = "";

    if (password.length < 5) {
        correct = false;
        password_warn.textContent = "* Mật khẩu có ít nhất 5 ký tự";
    }
    else
        password_warn.textContent = "";

    if (repassword != password) {
        repassword_warn.textContent = "* Mật khẩu không khớp";
        correct = false;
    }
    else
        repassword_warn.textContent = "";

    if (correct)
        document.getElementById('__form').submit();
};

function btn_close_category() {
    let option = document.querySelector(".__overlay");
    if (option.style.display == 'block')
        option.style.display = 'none';
    else
        option.style.display = 'block';
}