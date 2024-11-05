<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DangNhap.aspx.cs" Inherits="MobileShop.DangNhap" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>Đăng nhập</title>
     <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
     <link rel="shortcut icon" href="./assets/logo/favicon.ico" type="image/x-icon"/>
     <link rel="stylesheet" href="./assets/css/SignIn.css"/>
</head>
<body>
   <form runat="server" method="post" onsubmit="return validateSignIn();">
        <div class="sign-in">
            <div class="content">
                <h1 class="heading">Đăng nhập</h1>
                <div class="form-item">
                    <label for="taikhoan">Tài khoản</label>
                    <div class="form-input">
                        <input type="text" name="taikhoan" id="taikhoan" placeholder="Nhập tài khoản"/>
                    </div>
                    <div class="form-message"><span class="error-message" id="errorusername" runat="server"></span></div>
                </div>  
                <div class="form-item">
                    <label for="matkhau">Mật khẩu</label>
                    <div class="form-input">
                        <input type="password" name="matkhau" id="matkhau" placeholder="Nhập mật khẩu"/>
                    </div>
                    <div class="form-message"><span class="error-message" id="errorpassword" runat="server"></span></div>
                </div>
                
                <button type="submit">Đăng nhập</button>

                <div class="sign-up">
                    <span>Chưa có tài khoản?</span>
                    <a href="DangKy.aspx">Đăng ký</a>
                </div>
            </div>
        </div>
    </form>
    <script src="./assets/js/validator.js"></script>
</body>
</html>
