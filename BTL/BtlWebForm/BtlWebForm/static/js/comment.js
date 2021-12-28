function sendCommentLevel1(idProduct)
{
    let comment = document.getElementById('comment').value;
    if (comment == '')
        return;

    let child = document.createElement("div");
    var html
    //reset input
    document.getElementById('comment').value = '';
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            // response tra ve dang "fullname|role|idcomment"
            var response = this.responseText;
            if (response == '') {
                alert('Đăng nhập trước nhé =))');
            }
            else {
                html = htmlCommentLv1(response.split('|')[0], comment, response.split('|')[1], "Hôm nay");
                child.setAttribute("id", response.split('|')[2]);
            }
            
        }
    }
    xhttp.open("POST", "/api/comment", false);
    xhttp.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
    xhttp.send("idProduct=" + idProduct + "&comment=" + comment + "&level=1");


    child.setAttribute("class", "detail_comment flex");
    let listComment = document.getElementById('list_comment');
    
    child.innerHTML = html;
    listComment.appendChild(child);
}


function htmlCommentLv1(fullname, comment, role, time)
{
    let rolename = role == "admin" ? "<span class='role'>Quản trị viên</span>" : "";
    
    fullname = fullname.trim();
    let words = fullname.split(' ');

    let x = '';
    for (let i = 0 ; i < words.length; i++)
        x += words[i][0];

    let html = "<div class='avatar_comment'>";
        html += x;
        html += "</div>";
        html += "<div class='user_comment'>";
        html += "    <div class='flex'>";
        html += "        <h4>" + fullname + "</h4> " + rolename;
        html += "        <span class='time'>" + time + "</span>";
        html += "    </div>";
        html += "    <span class='content_comment'>";
        html +=           comment;
        html += "    </span>";
        html += "    <a class='btn_reply' onclick='addCommentLevel2(this)'>Trả lời</a>";
        html += "</div>";
    return html;
}


function sendCommentLevel2(_this, idProduct)
{
    let comment = _this.parentNode.getElementsByClassName('commentlv2')[0].value;
    if (comment == '')
        return;

    var idCmt = _this.parentNode.parentNode.parentNode.getAttribute("id");

    
    let html;
    //reset input
    _this.parentNode.getElementsByClassName('commentlv2')[0].value = "";
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            var response = this.responseText;
            if (response == '') 
            {
                alert('Đăng nhập thì mới được rep');
                return;
            }
            else
            {
                html = htmlCommentLv2(response.split('|')[0], comment, response.split('|')[1], "Hôm nay");
            }
        }
    }
    xhttp.open("POST", "/api/comment", false);
    xhttp.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
    xhttp.send("idProduct=" + idProduct + "&comment=" + comment + "&level=2&idCmt=" + idCmt);

    
    let child = document.createElement("div");

    child.setAttribute("class", "reply");
    let listComment = _this.parentNode.parentNode;
    
    child.innerHTML = html;
    listComment.appendChild(child);

    // custom
    var _this_button_send = _this.parentNode.parentNode.getElementsByClassName('btn_reply')[0];
}

function htmlCommentLv2(fullname, comment, role, time)
{
    let rolename = role == "admin" ? "<span class='role'>Quản trị viên</span>" : '';
    let html  = "   <div class='user_comment'>"; 
        html += "       <div class='flex'>"
        html += "           <h4>" + fullname +"</h4> " + rolename;
        html += "           <span class='time'>Hôm nay</span>";
        html += "       </div>";
        html += "       <span class='content_comment'>";
        html +=               comment;
        html += "       </span>";
        html += "   </div>"
    return html;
}
function addCommentLevel2(x)
{
    let nodeForm = x.parentNode.getElementsByClassName('relative');
    if (nodeForm.length > 0)
    {
        x.innerHTML = "Trả lời";
        nodeForm[0].remove();
        return;
    }
    x.innerHTML = "Thôi";
    let formComment = document.createElement('div');
    formComment.setAttribute('class', 'relative');
    let idxx = document.getElementById('btn_send_lv1').getAttribute('idxx');
    idxx = parseInt(idxx);
    let html = "   <textarea placeholder='Viết câu hỏi của bạn' name='' class='commentlv2' cols='30' rows='3'></textarea>";
    html += "   <button type='button' onclick='sendCommentLevel2(this," + idxx + ")'>Gửi bình luận</button>";
    formComment.innerHTML = html;
    x.parentNode.appendChild(formComment);
}


function login()
{
    window.location.href = "/login";
}