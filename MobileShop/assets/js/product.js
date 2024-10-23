let themVaoGioHang = document.getElementById("themvaogiohang");
let prDetail = document.getElementById("prDetail");
let add = document.getElementById("add1");

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
    add.value = "1";
}



