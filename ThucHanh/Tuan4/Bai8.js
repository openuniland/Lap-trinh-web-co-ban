document.querySelector('#button--add').addEventListener('click', function(){

    var date = document.querySelector('#txtNgayRaMat').value;
    var array = date.split('-');

    var time = new Date(array[0], array[1], array[2])
    if(time.getTime() > Date.now()){
        alert('ban da nhap ngay sai!')
    } else {

        var table = document.querySelector('table tbody');
                var tr = document.createElement('tr');
                table.appendChild(tr);
                
        var c = document.querySelector('tr').children.length;
        for(var i=0; i<c; i++){
            var create = document.createElement('td');
            tr.appendChild(create);
        }
        var value = document.querySelector('.content').children;

        for(var i=1; i<c; i++){
            if(isNaN(value[3].querySelector('input').value) || value[3].querySelector('input').value < 0){
                alert('nhap sai gia!');
                break;
            }else{
                
                tr.children[0].textContent = table.children.length-1;
                
                tr.children[i].textContent = value[i-1].querySelector('input').value;
            }
        }

        
        
    }
});