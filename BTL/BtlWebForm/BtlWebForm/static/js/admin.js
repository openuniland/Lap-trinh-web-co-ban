document.getElementById('name_admin').addEventListener('click', function () {
    var x = document.getElementsByClassName('option-x')[0];
    if (x.style.display == 'none')
        x.style.display = 'block';
    else
        x.style.display = 'none';
});

function gen() {
    var text = document.getElementById('name_pro').value;
    var kq = text.replace(/[áạãảàâấậẩẫầăắặẵẳ]/g, 'a');
    kq = kq.replace(/[êếễểệẽẻẹéè]/g, 'e');
    kq = kq.replace(/[ìỉĩịí]/g, 'i');
    kq = kq.replace(/[ỏòõọóôốồỗộốơớỡợở]/g, 'o');
    kq = kq.replace(/[ủụũúùưứừựữ]/g, 'u');
    kq = kq.replace(/[ỳýỵỹỷ]/g, 'y')
    kq = kq.replace(/[|\/()*~ .]/g, '-');
    kq = kq.replace(/[+]/g, '-');
    kq = kq.replace("---", '-');
    kq = kq.replace("--", '-');
    kq = kq.substring(0, 60);
    document.getElementById('url_pro').value = kq;
}

var h = 1;
function addFileImage()
{
    var inp = document.createElement("input");
    inp.setAttribute("type", "file");
    inp.setAttribute("name", "file" + h);
    document.getElementById("image_sss").appendChild(document.createElement("br"));
    document.getElementById("image_sss").appendChild(inp);
}

function showFormAdd()
{
    document.getElementsByClassName("show-form")[0].style.display = "block";
    // Gọi ajax lấy form - có thể fix html luôn cũng được nhưng đang còn sửa nữa nên gộp chung
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            var dom = document.getElementById("response");
            dom.innerHTML = this.responseText;
        }
    };
    xhttp.open("GET", "/api/form", true);
    xhttp.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
    xhttp.send();
}

function editProduct(x)
{
    document.getElementsByClassName("show-form")[1].style.display = "block";

    var trCurrent =  x.parentNode.parentNode;
    
}


// api
function getListProduct()
{
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            var dom = document.getElementById("list_pro");
            dom.innerHTML = this.responseText;
        }
    };
    xhttp.open("GET", "/api/product", true);
    xhttp.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
    xhttp.send();
}

//api
function getListUser() {
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            var dom = document.getElementById("list_user");
            dom.innerHTML = this.responseText;
        }
    };
    xhttp.open("GET", "/api/user", true);
    xhttp.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
    xhttp.send();
}

//api
function getListOrder() {
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            var dom = document.getElementById("list_order");
            dom.innerHTML = this.responseText;
        }
    };
    xhttp.open("GET", "/api/order", true);
    xhttp.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
    xhttp.send();
}

function loadForm(x) {
    var form = document.getElementsByClassName("right-admin-container");
    var li = document.getElementsByClassName('__select');
    for (var i = 0; i < form.length; i++) {
        if (i == x - 1) {
            li[i].style.fontWeight = "bold";
            form[i].style.display = "block";
        }
        else {
            li[i].style.fontWeight = "normal";
            form[i].style.display = "none";
        }
    }
    if (x == 1)
        getListProduct();

    if (x==2)
        getListUser();
    if (x == 3)
        getListOrder();
}



// detailed article about of product
//
function addParagraph() {
    var amount = document.getElementsByClassName('paragraph').length + 1;
    var fieldset = document.createElement('fieldset');
    fieldset.setAttribute('class', 'paragraph');
    var html = "<legend class='index'><button type='button' onclick='removeParagraph(this)'>Xóa đoạn văn này</button></legend><br><br>";
    html += "<input type='text' placeholder='Nhập tiêu đề đoạn văn' class='paragraph_title'>";
    html += "<textarea name='paragraph1' id='' cols='30' rows='10' class='paragraph_content' placeholder='Nội dung đoạn văn'></textarea>";
    html += "<br>Chọn ảnh hiển thị trong đoạn văn: <input class='paragraph_file' type='file' name='imgPost" + amount + "'>";
    fieldset.innerHTML = html;
    document.getElementById('post').appendChild(fieldset)
}

function resetForm() {
    var x = confirm("Bạn muốn reset lại form");
    if (x)
        document.forms[0].reset();
}

function removeParagraph(x) {
    var fieldset = x.parentNode.parentNode;
    var txtTitle = fieldset.getElementsByClassName('paragraph_title')[0].value;
    var txtContent = fieldset.getElementsByClassName('paragraph_content')[0].value;
    if (txtTitle != '' || txtContent != '') {
        var x = confirm("Đoạn văn đang được viết, bạn có muốn xóa?")
        x ? fieldset.remove() : ''
    }
    else {
        fieldset.remove();
    }

}


// vì bài viết có nhiều đoạn, chứa cả ảnh, không thể lưu trữ theo cách thông thường
// ở đây sẽ lưu bài viết có chứa các thẻ html, code bên dưới sẽ xử lí input và ghép với html
function saveProduct() {
    let textarea = document.createElement('textarea');
    textarea.setAttribute('name', 'html');
    let html = "";
    let paragraph = document.getElementsByClassName('paragraph');

    let stt_anh = 0;
    for (let i = 0; i < paragraph.length; i++) {
        let title = paragraph[i].getElementsByClassName('paragraph_title')[0].value;
        let content = paragraph[i].getElementsByClassName('paragraph_content')[0].value;
        let filename = paragraph[i].getElementsByClassName('paragraph_file')[0].value;

        html += "<h3>" + title + "</h3>";
        html += "<p>" + content + "</p>";

        // file name sẽ được replace trên server
        if (filename != '') {
            html += "<p><img class='img' src='filename" + stt_anh + "' ></p>";
            stt_anh++;
        }
        // vẫn có trường hợp file rỗng, nếu rỗng thì ko nối html hiển thị ảnh
    }

    textarea.innerHTML = html;
    document.forms[0].appendChild(textarea);
    document.forms[0].submit();
}