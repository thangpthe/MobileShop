﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MayTinhBang.aspx.cs" Inherits="MobileShop.MayTinhBang" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Máy tính bảng</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <link rel="shortcut icon" href="./assets/logo/favicon.ico" type="image/x-icon"/>
    <link rel="stylesheet" href="./assets/fontawesome-free-6.6.0-web/css/all.min.css"/>
    <link rel="stylesheet" href="./assets/css/style.css" />
    <link rel="stylesheet" href="./assets/css/Product.css" />
    <link rel="stylesheet" href="./assets/css/responsive.css"/>
</head>
<body>
    <form id="dienthoai" runat="server">
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
                                <asp:LinkButton runat="server" CssClass="btnsearch" OnClick="searchProduct" ID="ButtonSearch">
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
                        </ul>
                    </div>
                </nav>
            </div>
        </header>

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

        <main>
            <div class="container">
                <section class="breadcrumb">
                    <a href="TrangChu.aspx"><i class="fa-solid fa-house"></i>Trang chủ</a>&nbsp;>&nbsp;
                    <a href="MayTinhBang.aspx">Máy tính bảng</a>
                </section>
                <!--  -->
                <section class="list-container">
                    <div class="list-filters">
                        <div class="list-filter">
                            <h3>Hãng sản xuất</h3>
                                <asp:CheckBoxList ID="listBrand" runat="server">
                                    <asp:ListItem Text="Apple" Value="Apple"></asp:ListItem>
                                    <asp:ListItem Text="Samsung" Value="Samsung"></asp:ListItem>
                                    <asp:ListItem Text="Xiaomi" Value="Xiaomi"></asp:ListItem>
                                    <asp:ListItem Text="Lenovo" Value="Lenovo"></asp:ListItem>
                                </asp:CheckBoxList>
                            </div>

                        <div class="list-filter">
                            <h3>Giá tiền</h3>
                            <asp:CheckBoxList ID="priceRange" runat="server">
                                <asp:ListItem Text="3 triệu - 5 triệu" Value="3000000-5000000"></asp:ListItem>
                                <asp:ListItem Text="5 triệu - 8 triệu" Value="5000000-8000000"></asp:ListItem>
                                <asp:ListItem Text="> 8 triệu" Value="8000000-30000000"></asp:ListItem>
                            </asp:CheckBoxList>
                        </div>
                        <asp:Button CssClass="btn-filter" Text="Lọc sản phẩm" OnClick="filterProduct" runat="server"/>
                    </div>


                    <div class="products">
                        <!-- Sản phẩm -->
                        <div class="product-list" id="productList" runat="server">
                        </div>
                    </div>

                </section>

                <section class="about">
                    <h3>Những ưu đãi khi mua máy tính bảng tại PT Mobile</h3>
                    <p>Khi mua máy tính bảng tại PT Mobile, khách hàng có thể tận hưởng nhiều ưu đãi đặc biệt hấp dẫn để có trải nghiệm mua sắm thoải mái và tiện lợi nhất.</p>
                    <p>Một trong những ưu đãi nổi bật là <strong>bảo hành chính hãng</strong> cho tất cả các sản phẩm. Mọi sản phẩm bạn mua tại PT Mobile đều được hỗ trợ kỹ thuật và sửa chữa theo đúng chính sách và tiêu chuẩn của nhà sản xuất, giúp khách hàng yên tâm sử dụng sản phẩm.</p>
                    <p>Ngoài ra, PT Mobile cung cấp chương trình <strong>hỗ trợ trả góp</strong>, giúp khách hàng mua sắm mà không cần thanh toán toàn bộ chi phí ngay lập tức. Thêm vào đó, chúng tôi còn <strong>miễn phí vận chuyển toàn quốc</strong> cho đơn hàng, giúp khách hàng tiết kiệm chi phí mà còn mang lại sự tiện lợi tối đa khi mua sắm.</p>
                    <p>Cuối cùng, PT Mobile cung cấp sự <strong>linh hoạt trong mua sắm</strong> khi bạn có thể lựa chọn mua hàng trực tiếp tại các cửa hàng hoặc mua sắm trực tuyến thông qua website. Dù bạn ở bất cứ đâu hoặc có lịch trình bận rộn, bạn vẫn có thể mua sắm một cách thuận tiện, nhanh chóng.</p>
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
            </div>
    </main>

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
        
    </form>
    <script src="./assets/js/product.js"></script>
</body>
</html>
