const hoTen = document.getElementById("hoten");
const sdt = document.getElementById("sdt");
const diaChi = document.getElementById("diachi");
const taiKhoan = document.getElementById("taikhoan");
const matKhau = document.getElementById("matkhau");
const maXacNhan = document.getElementById("confirmcode");
let loiTen = document.getElementById("errorfullname");
let loiSDT = document.getElementById("errorphone");
let loiDiaChi = document.getElementById("erroraddress");
let loiTK = document.getElementById("errorusername");
let loiMK = document.getElementById("errorpassword");

let loiMaXacNhan = document.getElementById("errorconfirm");
function checkPhoneNumber(phone) {
    return /^0[1-9][0-9]{8}$/.test(phone);
}

function checkUserName(userName) {
    return /^[a-zA-Z0-9]{5,20}$/.test(userName);
}

function checkPassWord(passWord) {
    return /^[a-zA-Z0-9]{5,20}$/.test(passWord);
}

function checkConfirmCode(confirmCode) {
const uppercaseCount = (confirmCode.match(/[A-Z]/g) || []).length;
const lowercaseCount = (confirmCode.match(/[a-z]/g) || []).length;
return uppercaseCount === 3 && lowercaseCount === 2;
}


//function checkConfirmCode(confirmCode) {
//    return /^[a-z]{2}[A-Z]{3}$/.test(confirmCode);
//}
function validateSignUp() {
    let check = true;
    if (hoTen.value.trim().length == 0) {
        loiTen.innerText = "Không được để trống tên";
        check = false;
    }
    else {
        loiTen.innerText = "";
    }
    if (sdt.value.trim().length == 0) {
        loiSDT.innerText = "Không được để trống số điện thoại";
        check = false;
    }
    else if(!checkPhoneNumber(sdt.value)){
        loiSDT.innerText = "Nhập sai định dạng SĐT, bạn phải nhập 10 chữ số bắt đầu bằng chữ số 0";
        check = false;
    }
    if (diaChi.value == "") {
        loiDiaChi.innerText = "Không được để trống địa chỉ";
        check = false;
    }
    else{
        loiDiaChi.innerText = "";
    }
    
    if (taiKhoan.value.trim().length == 0) {
        loiTK.innerText = "Không được để trống tài khoản";
        check = false;
    }
    else if (!checkUserName(taiKhoan.value)) {
        loiTK.innerText = "Bạn phải nhập ít nhất 6 ký tự bao gồm chữ thường, chữ hoa và số";
        check = false;
    }
    if (matKhau.value.trim().length == 0) {
        loiMK.innerText = "Không được để trống mật khẩu";
        check = false;
    }
    else if (!checkPassWord(matKhau.value)) {
        loiMK.innerText = "Bạn phải nhập ít nhất 6 ký tự bao gồm chữ thường, chữ hoa và số";
        check = false;
    }
    if (maXacNhan.value.trim().length == 0) {
        loiMaXacNhan.innerText = "Không được để trống mã xác nhận";
        check = false;
    }
    else if (!checkConfirmCode(maXacNhan.value)){
        loiMaXacNhan.innerText = "Bạn phải nhập ít nhất 5 ký tự bao gồm 3 ký tự in hoa và 2 ký tự in thường";
        check = false;
    }
    return check;
}
function validateSignIn() {
    let check = true;
    if (taiKhoan.value.trim().length == 0) {
        loiTK.innerText = "Không được để trống tài khoản";
        check = false;
    }
    else if (checkUserName(taiKhoan.value)) {
        loiTK.innerText = "";
    } else {
        loiTK.innerText = "Bạn phải nhập ít nhất 6 ký tự bao gồm chữ thường, chữ hoa và số";
        check = false;
    }
    if (matKhau.value.trim().length == 0) {
        loiMK.innerText = "Không được để trống mật khẩu";
        check = false;
    }
    else if (checkPassWord(matKhau.value)) {
        loiMK.innerText = "";
    }
    else {
        loiMK.innerText = "Bạn phải nhập ít nhất 6 ký tự bao gồm chữ thường, chữ hoa và số";
        check = false;
    }
    return check;
}