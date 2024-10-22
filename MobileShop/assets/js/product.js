function product_click(id){
    const product = document.getElementById(id); //lấy ra id sản phẩm
    const prId = product.querySelector("input").value; //id sp ở input hidden
    location.href = "ChiTietSanPham.aspx?id=" + prId;
}

function cart_click(value) {
    event.cancelBubble = true;
    if (event.stopPropagation()) event.stopPropagation();
    document.getElementById("themvaogiohang").value = "1";
    alert("Đã thêm vào giỏ hàng");
    let prDetail = document.getElementById("prDetail");
    prDetail.value = value;
   
}