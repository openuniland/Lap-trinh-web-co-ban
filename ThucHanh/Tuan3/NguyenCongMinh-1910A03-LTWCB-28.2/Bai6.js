document.getElementById("view").addEventListener("click", function(){
    var NgaySinh = document.getElementById("txtNgaySinh").value;
    var array = NgaySinh.split("/");

    if(array[0] > 31 || array[1] > 12){
        alert('Ngày sinh sai! Hãy nhập lại!');
    }
    
    function check(day, month){
        var cung = [
            "", "BẢO BÌNH", "SONG NGƯ", "BẠCH DƯƠNG", "KIM NGƯU", "SONG TỬ", "CỰ GIẢI", "SƯ TỬ", "XỬ NỮ", "THIÊN BÌNH", "BỌ CẠP", "NHÂN MÃ", "MA KẾT"
        ];

        var Ngay_Sinh = [
            "", 20, 19, 21, 21, 21, 22, 23, 23, 23, 24, 23, 22
        ];

        return day >= Ngay_Sinh[month]?cung[month]:cung[month-1];
    }

    document.getElementById("txtCung").value = check(parseInt(array[0]), parseInt(array[1]));

    if(NgaySinh == ""){
        alert("Bạn chưa nhập ngày sinh!");
        document.getElementById("txtCung").value = "";
    }

    
})

document.getElementById("del").addEventListener("click", function(){
    document.getElementById("txtNgaySinh").value = "";
    document.getElementById("txtCung").value = "";
})