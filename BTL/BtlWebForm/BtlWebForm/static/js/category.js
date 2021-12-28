window.onload = function () {

    // load checked input
    if (!location.href.includes('filter')) {
        document.getElementById('f_all').checked = true;
    }
    else {
        let nodeFilterParent = document.getElementById('filter1');
        let listFilter = nodeFilterParent.getElementsByTagName('input');
        for (let i = 0; i < listFilter.length; i++) {
            if (location.href.includes(listFilter[i].value))
                listFilter[i].checked = true;
        }
    }

    // load sort selected
    if (location.href.includes('sort')) {
        let sortBy = location.href.split('sort')[1];
        let text = '';
        if (sortBy == '=san-pham-moi-nhat')
            text = 'Mới nhất';
        else if (sortBy == '=gia-tang-dan')
            text = 'Giá tăng dần';
        else
            text = 'Giá giảm dần'
        document.getElementById('dangchon').innerText = text;
    }
    // default select is 'Chưa chọn'
}

function filter1(_this) {
    let nodeFilterParent = document.getElementById('filter1');
    let listFilter = nodeFilterParent.getElementsByTagName('input');

    // nếu click vào all, xóa các filter khác
    if (_this.value == 'all') {
        window.location.href = location.origin + location.pathname;
        return;
    }

    // trường hợp còn lại
    let queryString = "?filter=";
    // first node is "filter all"
    let flag = true;
    for (let i = 1; i < listFilter.length; i++) {
        if (listFilter[i].checked == true) {
            queryString += listFilter[i].value + ",";
            flag = false;
        }
    }
    if (flag) {
        listFilter[0].checked = flag; // nếu ấn lọc thì sẽ bỏ input#all
        window.location.href = location.origin + location.pathname;
        return;
    }
    queryString = queryString.substring(0, queryString.length - 1);
    window.location.href = location.origin + location.pathname + queryString;
}


function sort(_this) {
    document.getElementById('dangchon').innerText = _this.innerText;
    let sort = location.href.includes('filter') ? "&sort=" : "?sort=";
    let temp = sort; // tạm lưu giá trị ban đầu để lát split, tránh trường hợp ???? &&&&&
    if (_this.innerText == 'Mới nhất')
        sort += 'san-pham-moi-nhat';
    if (_this.innerText == 'Giá tăng dần')
        sort += 'gia-tang-dan';
    if (_this.innerText == 'Giá giảm dần')
        sort += 'gia-giam-dan';
    location.href = (location.href.split(temp)[0] + sort);
}


function btn_close_filter() {
    let category = document.getElementById('category_i');
    if (category.style.marginLeft == '0px')
        category.style.marginLeft = '-500px';
    else
        category.style.marginLeft = '0';
}

