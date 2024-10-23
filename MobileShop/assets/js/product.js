let themVaoGioHang = ocument.getElementById("themvaogiohang");
let prDetail = document.getElementById("prDetail");
let add = document.getElementById("add1"); 
function product_click(id) {
    const product = document.getElementById(id); //lấy ra id sản phẩm
    const prId = product.querySelector("input").value; //id sp ở input hidden
    location.href = "ChiTietSanPham.aspx?id=" + prId;
}

function cart_click(value) {
    event.cancelBubble = true;
    if (event.stopPropagation()) event.stopPropagation();
    themVaoGioHang.value = "1";
    alert("Đã thêm vào giỏ hàng");
    prDetail.value = value;
}

function addtocart_click() {
    addToCart.value = "1";
}