var tbl = document.getElementById("tableCart");
var inputsl = tbl.querySelectorAll("input");
var csl = document.getElementById("chinhsoluong");
var formgh = document.getElementById("formgiohang");
function nhapsoluong(soluong) {
    if (parseInt(soluong) < 1) {
        sl.value = "1";
    }
    var sl1 = "";
    for (let i = 0; i < inputsl.length; i++) {
        if (i == 0) {
            sl1 = inputsl[i].value;
        } else {
            sl1 += "_" + inputsl[i].value;
        }
    }
    csl.value = sl1;
    console.log(sl1);
    formgh.submit();
}

var huysp = document.getElementById("huysp");
function remove_sp(clicked_value) {
    huysp.value = clicked_value;
}