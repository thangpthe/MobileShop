<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DangKy.aspx.cs" Inherits="MobileShop.DangKy" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Đăng ký</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <link rel="shortcut icon" href="./assets/logo/favicon.ico" type="image/x-icon"/>
    <link rel="stylesheet" href="./assets/fontawesome-free-6.6.0-web/css/all.min.css"/>
    <link rel="stylesheet" href="./assets/css/SignUp.css"/>
</head>
<body>
    <form method="post" autocomplete="off" runat="server" onsubmit="return validateSignUp();">
        <div class="sign-up sign-up-responsive">
            <div class="content">
                <h1 class="heading">Đăng ký tài khoản</h1>
                <div class="form-item">
                    <div class="form-input">
                        <label for="hoten">Họ tên</label>
                        <input type="text" name="hoten" id="hoten" placeholder="Nhập họ tên" runat="server"/>
                    </div>
                    <span class="form-message" id="errorfullname" runat="server"></span>
                </div>
                <div class="form-item">
                    
                    <div class="form-input">
                        <label for="sdt">SĐT</label>
                        <input type="text" name="sdt" id="sdt" placeholder="Nhập số điện thoại" runat="server"/>
                    </div>
                    <span class="form-message" id="errorphone" runat="server"></span>
                </div>
                <div class="form-item">
                   
                    <div class="form-input">
                        <label for="diachi">Địa chỉ</label>
                        <input type="text" name="diachi" id="diachi" placeholder="Nhập địa chỉ" runat="server"/>
                    </div>
                    <span class="form-message" id="erroraddress" runat="server"></span>
                </div>
                
                <div class="form-item">
                    
                    <div class="form-input">
                        <label for="taikhoan">Tài khoản</label>
                        <input type="text" name="taikhoan" id="taikhoan" placeholder="Nhập tài khoản" runat="server"/>
                    </div>
                    <span class="form-message" id="errorusername" runat="server"></span>
                </div>
                <div class="form-item">
                    
                    <div class="form-input">
                        <label for="matkhau">Mật khẩu</label>
                        <input type="password" name="matkhau" id="matkhau" placeholder="Nhập mật khẩu"/>
                    </div>
                    <span class="form-message" id="errorpassword" runat="server"></span>
                </div>

                <div class="form-submit">
                    <button type="submit" class="btn-signup">Đăng ký</button>
                </div>

                <div class="sign-in">
                    <span>Đã có tài khoản?</span>
                    <a href="DangNhap.aspx">Đăng nhập</a>
                </div>

                <div class="signup-success" id="success" runat="server"></div>
            </div>
        </div>
    </form>
    <script src="./assets/js/validator.js"></script>
</body>
</html>
