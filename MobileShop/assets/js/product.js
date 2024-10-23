let themVaoGioHang = document.getElementById("themvaogiohang");
let prDetail = document.getElementById("prDetail");
let add = document.getElementById("add1");
let sl = document.getElementById("soluong");
function nhapsoluong(soluong) {
    if (parseInt(soluong) <= 0) {
        sl.value = "1";
    }
}
function product_click(id) {
    const product = document.getElementById(id); //lấy ra id sản phẩm
    const prId = product.querySelector("input").value; //id sp ở input hidden
    location.href = "ChiTietSanPham.aspx?id=" + prId;
}

function cart_click(value) {
    if (Event.stopPropagation) {
        Event.stopPropagation(); // Cho các trình duyệt hiện đại
    } else {
        Event.cancelBubble = true; // Cho IE
    }
    themVaoGioHang.value = "1";
    alert("Đã thêm vào giỏ hàng");
    prDetail.value = value;
}

function addtocart_click() {
    addToCart.value = "1";
}

var huysp = document.getElementById("huysp");
function remove_sp(clicked_value) {
    huysp.value = clicked_value;
}

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