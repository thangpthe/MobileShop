<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ThanhToan.aspx.cs" Inherits="MobileShop.ThanhToan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Thanh toán</title>
    <link rel="shortcut icon" href="./assets/logo/favicon.ico" type="image/x-icon"/>
    <link rel="stylesheet" href="./assets/fontawesome-free-6.6.0-web/css/all.min.css"/>
    <link rel="stylesheet" href="./assets/css/style.css"/>
    <link rel="stylesheet" href="./assets/css/Payment.css"/>
</head>
<body>
    <form id="form1" runat="server">
        <%-- Header --%>
        <header class="header">
            <!-- Header top -->
            <div class="header-top">
                <div class="container">
                    <div class="header-intro">
                        <div class="logo">
                            <a href="TrangChu.aspx">
                                <img
                                    src="./assets/logo/logo.png"
                                    alt="Logo"
                                    class="logo-img" />
                            </a>
                        </div>

                        <!-- Thanh tìm kiếm -->
                        <div class="search-box">
                            <div class="border">
                                <input
                                    type="search"
                                    name=""
                                    id=""
                                    placeholder="Tìm kiếm sản phẩm" />
                                <button type="submit" class="btn-search">
                                    <!-- icon search -->
                                    <i class="fa-solid fa-magnifying-glass"></i>
                                </button>
                            </div>
                        </div>

                        <!-- Đăng ký đăng nhập -->
                        <%--<div class="user">
                            <div class="btn-action">
                                <a href="DangNhap.aspx">
                                    <i class="fa-regular fa-user"></i>
                                </a>
                            </div>
                            <div class="user-info">
                                <asp:Label ID="lblUsername" CssClass="user-info" runat="server" Text="Đăng nhập"></asp:Label>
                            </div>
                            <div class="user-logout">
                                <asp:Button ID="btnLogOut" CssClass="logoutbtn" runat="server" Visible="false" Text="Đăng xuất" OnClick="Logout"></asp:Button>
                            </div>
                        </div>--%>

                        <!-- Giỏ hàng -->
                        <div class="cart">
                            <!-- icon -->
                            <a href="#!">
                                <i class="fa-solid fa-cart-shopping"></i>
                            </a>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Header bottom -->
            <div class="header-bottom">
                <nav class="navbar">
                    <div class="container">
                        <ul>
                            <li>
                                <a href="DienThoai.aspx">
                                    <i class="fa-solid fa-mobile-screen-button"></i>
                                    Điện thoại
                                </a>
                            </li>
                            <li>
                                <a href="MayTinhBang.aspx">
                                    <i class="fa-solid fa-tablet-screen-button"></i>
                                    Máy tính bảng
                                </a>
                            </li>
                            <li>
                                <a href="PhuKien.aspx">
                                    <i class="fa-solid fa-headphones"></i>
                                    Phụ kiện
                                </a>
                            </li>
                            <li>
                                <a href="Blog.aspx">
                                    <i class="fa-solid fa-newspaper"></i>
                                    Blog
                                </a>
                            </li>
                        </ul>
                    </div>
                </nav>
            </div>
        </header>
         <div class="container">
        <div class="checkout-form">
            <!-- Phần thông tin khách hàng -->
            <div class="billing-details">
                <h2>Thông tin giao hàng</h2>
                
                    <div class="form-group">
                        <label for="name">Họ và tên:</label>
                        <input type="text" id="name" name="name" />
                    </div>
                    <div class="form-group">
                        <label for="address">Địa chỉ giao hàng:</label>
                        <input type="text" id="address" name="address" />
                    </div>
                    <div class="form-group">
                        <label for="phone">Số điện thoại:</label>
                        <input type="tel" id="phone" name="phone" />
                    </div>
                    <div class="form-group">
                        <label for="email">Email:</label>
                        <input type="email" id="email" name="email"/>
                    </div>
            </div>

            <!-- Phần phương thức thanh toán -->
            <!-- <div class="payment-methods">
                <h2>Phương thức thanh toán</h2>
                <div class="form-group">
                    <input type="radio" id="cod" name="payment" value="cod" checked>
                    <label for="cod">Thanh toán khi nhận hàng (COD)</label>
                </div>
                <div class="form-group">
                    <input type="radio" id="bank" name="payment" value="bank">
                    <label for="bank">Chuyển khoản ngân hàng</label>
                </div>
                <div class="form-group">
                    <input type="radio" id="card" name="payment" value="card">
                    <label for="card">Thanh toán bằng thẻ (Visa, MasterCard)</label>
                </div>
            </div> -->

            <div class="order-summary">
                <h2>Đơn hàng của bạn</h2>
                <div class="summary-item">
                    <span>Tổng tiền hàng:</span>
                    <span class="price" id="totalPrice" runat="server"></span>
                </div>
                <div class="summary-item">
                    <span>Phí vận chuyển:</span>
                    <span class="price">Miễn phí</span>
                </div>
                <div class="summary-item total">
                    <span>Tổng cộng:</span>
                    <span class="price" runat="server" id="finalPrice">5.000.000₫</span>
                </div>
                <button type="submit" class="btn-checkout">Xác nhận thanh toán</button>
            </div>
        </div>
    </div>

        <footer class="footer">
            <div class="container">
                <div class="footer-bg">
                    <div class="footer-content">
                        <!-- section 1 -->
                        <div class="footer-section">
                            <h3 class="title">Thông tin</h3>
                            <p class="address">Địa chỉ: Lorem ipsum dolor sit</p>
                            <p class="phone">
                                Số điện thoại: <a href="tel:+00 151515">+00 151515</a>
                            </p>
                            <p class="email">
                                Email: <a href="mailto: mail@email.com">mail@email.com</a>
                            </p>
                        </div>

                        <!-- section 2 -->
                        <div class="footer-section">
                            <h3 class="title">Hỗ trợ và dịch vụ</h3>
                            <ul>
                                <li>
                                    <a href="#!">Chính sách và hướng dẫn mua hàng trả góp</a>
                                </li>
                                <li>
                                    <a href="#!">Hướng dẫn mua hàng và chính sách vận chuyển</a>
                                </li>
                                <li>
                                    <a href="#!">Tra cứu đơn hàng</a>
                                </li>
                                <li>
                                    <a href="#!">Dịch vụ bảo hành</a>
                                </li>
                            </ul>
                        </div>

                        <!-- section 3 -->
                        <div class="footer-section">
                            <h3 class="title">Phương thức thanh toán</h3>
                            <ul>
                                <li>
                                    <img src="./assets/img/Footer/one-pay.jpg" alt="OnePay" />
                                    <img src="./assets/img/Footer/Apple-Pay-Card-Image.png" alt="ApplePay" />
                                    <img src="./assets/img/Footer/vn-pay.jpg" alt="VnPay" />
                                </li>
                                <li>

                                    <img src="./assets/img/Footer/1622682588188_zalopay.png" alt="ZaloPay" />
                                    <img src="./assets/img/Footer/visa.png" alt="ViettelPay" />
                                </li>
                            </ul>
                        </div>

                        <!-- section 4 -->
                        <div class="footer-section">
                            <h3 class="title">Mạng xã hội</h3>
                            <div class="socials">
                                <a href="#!"><i class="social-icon fa-brands fa-facebook"></i></a>
                                <a href="#!"><i class="social-icon fa-brands fa-youtube"></i></a>
                                <a href="#!"><i class="social-icon fa-brands fa-tiktok"></i></a>
                                <a href="#!"><i class="social-icon fa-brands fa-instagram"></i></a>
                            </div>
                        </div>
                    </div>
                    <div class="copyright">
                        <p class="copyright-year" style="text-align: center">
                            &copy; 2024 Bản quyền thuộc về PT Mobile
                        </p>
                    </div>
                </div>
            </div>
        </footer>   
    </form>
</body>
</html>
