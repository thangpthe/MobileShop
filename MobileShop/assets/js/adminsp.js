let id = document.getElementById("idsp");
let ckID = document.getElementById("checkID");
let tensp = document.getElementById("tensp");
let ckten = document.getElementById("checktensp");
let mota = document.getElementById("motasp");
let ckmota = document.getElementById("checkmota");
let loai = document.getElementById("prtype");
let ckloai = document.getElementById("checkloai");
let hang = document.getElementById("hangsx");
let ckhang = document.getElementById("checkhangsx");
let anh = document.getElementById("anhsp");
let ckanh = document.getElementById("checkanhsp");
let gia = document.getElementById("giasp");
let ckgia = document.getElementById("checkgia");

//function checkInp() {
//    let check = true;
//    if (id.value.trim().length == 0) {
//        ckID.innerText = "Bạn hãy điền ID sản phẩm";
//        check = false;
//    }
//    else {
//        ckID.innerText = "";
//    }
//    if (sp.value.trim().length == 0) {
//        ckten.innerText = "Bạn hãy điền tên sản phẩm";
//        check = false;
//    }
//    else {
//        ckten.innerText = "";
//    }
//    if (mota.value.trim().length == 0) {
//        ckmota.innerText = "Bạn hãy điền mô tả sản phẩm";
//        check = false;
//    }
//    else {
//        ckmota.innerText = "";
//    }
//    if (loai.trim().length == 0) {
//        ckloai.innerText = "Bạn hãy điền loại sản phẩm";
//        check = false;
//    }
//    else {
//        ckloai.innerText = "";
//    }
//    if (gia.value.trim().Length == 0) {
//        ckloai.innerText = "Bạn hãy điền giá sản phẩm";
//        check = false;
//    }
//    else if (isNaN(parseInt(gia.value))) {
//        ckgia.innerText = "Bạn nhập sai định dạng giá, hãy nhập lại";
//        check = false;
//    }
//    return check;
//}

//sửa sp
function suasp(click_value) {
    ckID.innerText = "";
    ckgia.innerText = "";
    ckhang.innerText = "";
    ckloai.innerText = "";
    ckmota.innerText = "";
    ckten.innerText = "";
    ckanh.innerText = "";

    const sp = click_value.split("|");
    id.value = sp[0];
    tensp.value = sp[1];
    mota.value = sp[2];
    loai.value = sp[3];
    hang.value = sp[4];
    gia.value = sp[5];
    location.href = "#quanlysp";
}