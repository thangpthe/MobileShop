<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TrangChu.aspx.cs" Inherits="MobileShop.TrangChu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Trang chủ</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <link rel="shortcut icon" href="./assets/logo/favicon.ico" type="image/x-icon"/>
    <link rel="stylesheet" href="./assets/fontawesome-free-6.6.0-web/css/all.min.css"/>
    <link rel="stylesheet" href="./assets/css/style.css" />
    <link rel="stylesheet" href="./assets/css/responsive.css"/>
</head>
<body>
    <form id="trangchu" runat="server" method="post">
        <input type="hidden" id="prDetail" name="prDetail" runat="server" />
        <input type="hidden" id="themvaogiohang" name="themvaogiohang" runat="server" />
        <header class="header">
            <!-- Header top -->
            <div class="header-top">
                <div class="container">
                    <div class="header-intro">
                        <div class="logo">
                            <a href="TrangChu.aspx">
                                <img
                                    src="./assets/logo/ptmobile.png"
                                    alt="Logo"
                                    class="logo-img" />
                            </a>
                        </div>

                        <!-- Thanh tìm kiếm -->
                       
                        <div class="search">
                            <div class="search-bar">
                                <input id="search" name="search" placeholder="Tìm kiếm sản phẩm..." type="text" />
                                <asp:LinkButton runat="server" OnClick="searchProduct" CssClass="btnsearch" ID="ButtonSearch">
                                    <i class="fa-solid fa-magnifying-glass"></i>
                                </asp:LinkButton>
                            </div>
                        </div>
                        
                        <!-- Đăng ký đăng nhập -->
                        <div class="user">
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
                        </div>

                        <!-- Giỏ hàng -->
                        <div class="cart" onclick="location.href='GioHang.aspx';">
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
                            <li>
                                <a href="AdminSP.aspx" id="adminsp" runat="server"></a>
                            </li>
                        </ul>
                    </div>
                </nav>
            </div>
        </header>
        <%-- Responsive --%>
        <header class="header-responsive">
            <div class="header-top-responsive">
                <div class="icon" onclick="toggleMenu()">
                    <i class="fa-solid fa-bars"></i>
                </div> 
                <a href="TrangChu.aspx">
                    <img
                        src="./assets/logo/ptmobile.png"
                        alt="Logo"
                        class="logo-img" />
                </a>
                              
            </div>
        </header>
        <button class="backToTop" onclick="backTop();">
            <div class="iconBack">
                <i class="fa-solid fa-chevron-up"></i>
            </div>
        </button>

        <!-- Banner -->
        <section class="banner">
            <div class="container">
                <div class="slider">
                    <div class="slider-list">
                        <div class="slider-item">
                            <img
                                src="./assets/img/Banner/dki-web1_638625122095967621.png"
                                alt="Iphone 16" />
                        </div>
                    </div>
                </div>
            </div>
        </section>

        <section class="services">
            <div class="container">
                <div class="service-list">

                    <div class="service">
                        <div class="service-left">
                            <i class="fa-solid fa-truck"></i>
                        </div>
                        <div class="service-right">
                            <span>Giao hàng nhanh chóng</span>
                        </div>
                    </div>

                    <div class="service">
                        <div class="service-left">
                            <i class="fa-regular fa-credit-card"></i>
                        </div>
                        <div class="service-right">
                            <span>Thanh toán online chỉ 5 phút</span>
                        </div>
                    </div>

                    <div class="service">
                        <div class="service-left">
                            <i class="fa-solid fa-arrows-rotate"></i>
                        </div>
                        <div class="service-right">
                            <span>Thủ tục đổi trả </span>
                            <strong>dễ dàng</strong>
                        </div>
                    </div>
                    <div class="service">
                        <div class="service-left">
                            <i class="fa-solid fa-phone-volume"></i>
                        </div>
                        <div class="service-right">
                            <span>Hỗ trợ 24/7</span>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <!-- Categories -->
        <section class="categories">
            <div class="container">
                <div class="row">
                    <div class="categories-item">
                        <div class="left">
                            <div class="coupon">
                                <span>-20%</span>
                            </div>
                            <div class="title">
                                <h3>Điện thoại</h3>
                                <ul>
                                    <li>Iphone</li>
                                    <li>Samsung</li>
                                    <li>Xiaomi</li>
                                    <li>Huawei</li>
                                </ul>
                                <a href="DienThoai.aspx"><span>Tìm hiểu thêm</span><i class="fa-solid fa-arrow-right"></i></a>
                            </div>

                        </div>
                        <div class="right">
                            <a href="DienThoai.aspx" onclick="location.href='ChiTietSanPham.aspx?id=001';">
                                <img src="./assets/img/Mobile/s24-ultra-vang_638409930027889246.png" alt="Banner" />
                            </a>
                        </div>
                    </div>
                    <div class="categories-item">
                        <div class="left">
                            <div class="coupon">
                                <span>-20%</span>
                            </div>
                            <div class="title">
                                <h3>Máy tính bảng</h3>
                                <ul>
                                    <li>Ipad</li>
                                    <li>Samsung Pad</li>
                                    <li>Xiaomi Pad</li>
                                    <li>Huawei Pad</li>
                                </ul>
                                <a href="MayTinhBang.aspx"><span>Tìm hiểu thêm</span><i class="fa-solid fa-arrow-right"></i></a>
                            </div>

                        </div>
                        <div class="right">
                            <a href="MayTinhBang.aspx">
                                <img src="./assets/img/Tablet/ipadgen9.jpg" alt="Banner" />
                            </a>
                        </div>
                    </div>
                    <div class="categories-item">
                        <div class="left">
                            <div class="coupon">
                                <span>-20%</span>
                            </div>
                            <div class="title">
                                <h3>Phụ kiện</h3>
                                <ul>
                                    <li>Ốp lưng</li>
                                    <li>Giá treo màn hình</li>
                                    <li>Sạc dự phòng</li>
                                    <li>Bàn phím</li>
                                </ul>
                                <a href="PhuKien.aspx"><span>Tìm hiểu thêm</span><i class="fa-solid fa-arrow-right"></i></a>
                            </div>

                        </div>
                        <div class="right">
                            <a href="PhuKien.aspx">
                                <img src="./assets/img/Accessories/op-lung-magsafe-iphone-15-pro-max-nhua-trong-apple-mt233-thumb-650x650.png" alt="Banner" />
                            </a>
                        </div>
                    </div>
                </div>
            </div>
        </section>

        <!-- Popular  - sản phẩm nổi bật -->
        <section class="popular">
            <div class="container">
                <div class="top popular-top">
                    <h2 class="popular-heading">Sản phẩm bán chạy</h2>
                </div>

                <div class="popular-content">
                    <div class="popular-list">
                        <div class="popular-item" id="001" onclick="product_click(this.id)">
                            <img src="./assets/img/Mobile/s24-ultra-vang_638409930027889246.png" alt="Samsung-Galaxy-S24-Ultra" />                                
                            <input type="hidden" value="001" />
                            <h3>Samsung Galaxy S24 Ultra</h3>
                            <span>
                                <strong>29,990,000</strong>
                            </span>
                            
                            <div class="product-cta">
                                <button value="001" onclick="cart_click(this.value)"><i class="fa-solid fa-cart-shopping"></i></button>
                            </div>
                        </div>

                        <div class="popular-item" id="009" onclick="product_click(this.id)">
                             <img  src="./assets/img/Mobile/15-pro-max-xanh-2.png" alt="Iphone 15 Promax" />  
                            <input type="hidden" value="009" />
                            <h3>Iphone 15 Promax</h3>
                            <span>
                                <strong>26,690,000</strong>
                            </span>
                            
                            <div class="product-cta">
                                <button value="009" onclick="cart_click(this.value)"><i class="fa-solid fa-cart-shopping"></i></button>
                            </div>
                        </div>

                        <div class="popular-item" id="010" onclick="product_click(this.id)">
                            
                             <img src="./assets/img/Tablet/ipadgen9.jpg" alt="Ipad Gen 9" />
                            <input type="hidden" value="010"/>
                            <h3>Ipad Gen 9</h3>
                            <span>
                                <strong>6,990,000</strong>
                            </span>
                            
                            <div class="product-cta">
                                <button value="010" onclick="cart_click(this.value)"><i class="fa-solid fa-cart-shopping"></i></button>
                            </div>
                        </div>

                        <div class="popular-item" id="016" onclick="product_click(this.id)">
                            <img src="./assets/img/Tablet/xiaomi-pad-6.jpg" alt="Xiaomi Pad 6" />
                            <input type="hidden" value="016"/>
                            <h3>Xiaomi Pad 6</h3>
                            <span>
                                <strong>8,990,000</strong>
                            </span>
                            
                            <div class="product-cta">
                                <button value="016" onclick="cart_click(this.value)"><i class="fa-solid fa-cart-shopping"></i></button>
                            </div>
                        </div>

                        <div class="popular-item" id="020" onclick="product_click(this.id)">
                            
                            <img src="./assets/img/Accessories/op-lung-magsafe-iphone-15-pro-max-nhua-trong-apple-mt233-thumb-650x650.png" alt="Ốp lưng Magsafe" />
                            <input type="hidden" value="020"/>
                            <h3>Ốp lưng Magsafe</h3>
                            <span>
                                <strong>1,140,000</strong>
                            </span>
                            
                            <div class="product-cta">
                                <button value="020" onclick="cart_click(this.value)"><i class="fa-solid fa-cart-shopping"></i></button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    
        <section class="email-register">
            <div class="register">
                <div class="container">
                    <div class="main-content">
                        <div class="newsletter">
                            <div class="newsletter-left"><i class="fa-regular fa-paper-plane"></i></div>
                            <div class="newsletter-right">
                                <p>Đăng Ký Ngay</p>
                                <span>nhận mã giảm giá cho lần mua sắm đầu tiên</span>
                            </div>
                        </div>
                        <div class="email-form">
                            <input type="text" placeholder="Email của bạn ..." name="" id="" />
                            <button class="normal">Đăng ký</button>
                        </div>
                    </div>

                </div>
            </div>
        </section>

        <!-- Footer -->
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

        <!-- Sidebar-->
        <div class="sidebar">
            <div class="sidebar-top">
                <img src="./assets/logo/ptmobile.png" alt="logo" />
                <button onclick="cancel()"><i class="fa-solid fa-x"></i></button>
            </div>
            <div class="sidebar-content">
                <!--search-->
                <div class="search">
                    <div class="search-bar">
                        <input id="search" name="search" placeholder="Tìm kiếm sản phẩm..." type="text" />
                        <asp:LinkButton runat="server" OnClick="searchProduct" CssClass="btnsearch" ID="LinkButton1">
                        <i class="fa-solid fa-magnifying-glass"></i>
                        </asp:LinkButton>
                    </div>
                </div>
                <!--navigation-->
                <ul class="navigation">
                    <li>
                        <a href="DienThoai.aspx">Điện thoại
                        </a>
                    </li>
                    <li>
                        <a href="MayTinhBang.aspx">Máy tính bảng
                        </a>
                    </li>
                    <li>
                        <a href="PhuKien.aspx">Phụ kiện
                        </a>
                    </li>
                    <li>
                        <a href="Blog.aspx">Blog
                        </a>
                    </li>
                </ul>
            </div>
        </div>
        <!--Menu bottom-->
        <div class="menu-bottom">
            <div class="menu-bottom-container">
                <a class="menu-item" href="DangNhap.aspx">
                    <i class="fa-regular fa-user"></i>
                    Tài khoản
                </a>
                <div class="menu-item">
                    <i class="fa-solid fa-filter"></i>
                    Lọc sản phẩm
                </div>
                <div class="menu-item">
                    <i class="fa-solid fa-magnifying-glass"></i>
                    Tìm kiếm
                </div>
                <a class="menu-item" onclick="location.href='GioHang.aspx';">
                    <i class="fa-solid fa-cart-shopping"></i>
                    Giỏ hàng
                </a>
            </div>
        </div>
        <script src="./assets/js/index.js"></script>
        <script src="./assets/js/product.js"></script>
    </form>
</body>
</html>
