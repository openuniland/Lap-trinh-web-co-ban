window.onload = function(){
    document.getElementsByTagName('body')[0].style.overflowY = 'hidden';
    
}

function sumMoney(){
    var x = document.getElementsByClassName('list_order')[0];
    var list_order = x.getElementsByClassName('_product');
    var sum = 0;
    for (var i = 0; i < list_order.length; i++)
    {
        var price = list_order[i].getElementsByClassName("_price")[0].innerHTML;
        price = price.replaceAll(',', '');
        sum += parseInt(price);
    }
    document.getElementById('_total').textContent = formatMoney(sum);
}


document.getElementById('btnOrder').addEventListener('click', () => {

    let info = document.querySelector('.info_customer');
    let input = info.getElementsByTagName('input');
    let strong = info.getElementsByTagName('strong');
    let flag = true;
    for (let i = 0; i < input.length; i++) {
        if (input[i].value.trim() == '') {
            strong[i].innerText = "* Chưa nhập giá trị";
            flag = false;
        } else {
            strong[i].innerText = '';
        }
        if ((input[i].id == '_username' || input[i].id == '_password') && input[i].value.length < 5) {
            flag = false;
            strong[i].innerText = "* Trường này ít nhất phải có 5 ký tự";
        }
        if (input[i].id == '_phonenumber' && input[i].value.match(/^0[23789]\d{8}$/g) == null) {
            flag = false;
            strong[i].innerText = "* Số điện thoại nhập vào không hợp lệ (10 chữ số, bắt đầu bằng 02, 03, 07, 08, 09)";
        } else {
            strong[i].value = '';
        }
    }

    if (flag)
        document.getElementById('form_checkout').submit();
})