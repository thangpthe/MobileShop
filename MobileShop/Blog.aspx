<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Blog.aspx.cs" Inherits="MobileShop.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Tin tức</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <link rel="shortcut icon" href="./assets/logo/favicon.ico" type="image/x-icon"/>
    <link rel="stylesheet" href="./assets/fontawesome-free-6.6.0-web/css/all.min.css"/>
    <link rel="stylesheet" href="./assets/css/style.css"/>
    <link rel="stylesheet" href="./assets/css/responsive.css"/>
</head>
<body>
    <form id="blog" runat="server">
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

    <main>
        <div class="container">
            <section class="news">
                <h1>Tin tức mới nhất</h1>
                <div class="news-item">
                    <div class="thumbnail">
                        <img src="./assets/img/Blog/searching-internet.jpg" alt="Tìm kiếm"/>
                    </div>
                    <div class="content">
                        <h2 class="title">Bão Yagi, Iphone 16 lọt top xu hướng tìm kiếm</h2>
                        <p class="desc">Những sự kiện nổi bật trong quý III như bão Yagi đổ bộ, iPhone 16 ra mắt khiến lượng tìm kiếm các từ khóa liên quan tăng vọt...</p>
                        <div class="author">
                            <img src="./assets/img/Review/uifaces-popular-image.jpg" alt="avatar" class="avatar"/>
                            <p class="author-name">Unknown</p>
                        </div>
                    </div>
                </div>

                <div class="news-item">
                    <div class="thumbnail">
                        <img src="./assets/img/Banner/xiaomi-redmi-pad-se-thumb-yt-1020x570.jpg" alt="Xiaomi Pad SE"/>
                    </div>
                    <div class="content">
                        <h2 class="title">Xiaomi Pad SE giá rẻ bất ngờ</h2>
                        <p class="desc">Lorem ipsum dolor sit amet consectetur adipisicing elit. Libero, possimus!</p>
                        <div class="author">
                            <img src="./assets/img/Review/uifaces-popular-image (2).jpg" alt="avatar" class="avatar"/>
                            <p class="author-name">Unknown</p>
                        </div>
                    </div>
                </div>

                <div class="news-item">
                    <div class="thumbnail">
                        <img src="./assets/img/Blog/tin-tuc-dien-thoai-moi-nhat-1.jpg" alt="Xiaomi 12T"/>
                    </div>
                    <div class="content">
                        <h2 class="title">Xiaomi 12T Series</h2>
                        <p class="desc">Đầu tháng 10 vừa qua, Xiaomi đã chính thức giới thiệu dòng sản phẩm điện thoại 12T Series tại thị trường Việt Nam với hai phiên bản là Xiaomi 12T và Xiaomi 12T Pro....</p>
                        <div class="author">
                            <img src="./assets/img/Review/uifaces-popular-image-1.jpg" alt="avatar" class="avatar"/>
                            <p class="author-name">Unknown</p>
                        </div>
                    </div>
                </div>
                
            </section>
        </div>
    </main>

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
    </form>
    <script src="./assets/js/index.js"></script>
</body>
</html>
