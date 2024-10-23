<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChiTietSanPham.aspx.cs" Inherits="MobileShop.ChiTietSanPham" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Chi tiết sản phẩm</title>
    <link rel="shortcut icon" href="./assets/logo/favicon.ico" type="image/x-icon"/>
    <link rel="stylesheet" href="./assets/fontawesome-free-6.6.0-web/css/all.min.css"/>
    <link rel="stylesheet" href="./assets/css/style.css"/>
    <link rel="stylesheet" href="./assets/css/ProductDetail.css"/>
</head>
<body>
    <form id="chitietsp" runat="server" method="get" enableviewstate="false">
        <input type="hidden" id="prDetail" name="prDetail" value="" runat="server" />
        <input type="hidden" id="add1" name="themvaogiohang" value="" runat="server" />
        <input type="hidden" id="themvaogiohang" name="themvaogiohang" value="" runat="server" />
        <!-- Header top -->
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
                                <a href="Dienthoai.aspx">
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

    <main>
        <div class="container">
            <%-- Breadcrumb --%>
            <section class="breadcrumb">
                <a href="TrangChu.aspx"><i class="fa-solid fa-house"></i>Trang chủ</a>&nbsp;>&nbsp;
                <a href="#!" id="linkPrType" runat="server"></a>&nbsp;>&nbsp;
                <a href="#!" id="linkPrName" runat="server"></a>
            </section>

            <section class="main-content">
                <div class="content-top">
                    <div class="row">
                         <img src="./assets/img/Mobile/iphone16pro.jpeg" alt="" id="prImg" runat="server"/>
                        <div class="product-info">
                            <h2 class="product-name" id="prName" runat="server">Iphone 16 Pro</h2>
                            <span class="product-price" id="prPrice" runat="server">
                                4,390,000
                            </span>
                            <p id="prDesribe" runat="server">Lorem ipsum dolor sit amet consectetur adipisicing elit. Ratione deserunt eos incidunt, quidem reprehenderit porro libero eveniet iusto natus deleniti veniam. Distinctio, aliquid ducimus magnam adipisci vero reiciendis temporibus. Quos consequuntur doloremque id impedit voluptatem sapiente nisi ab nobis, laborum molestias? Maxime, similique! Ratione rem dignissimos, facilis ipsa commodi odio!</p>
                            <div class="product-order">
                              <input type="number" id="soluong" name="soluong" min="1" value="1" onchange="nhapsoluong(this.value)" runat="server"/>
                              <button class="add-to-cart-btn" onclick="addtocart_click()">
                                <i class="fa-solid fa-cart-shopping" ></i>
                                <span>Thêm vào giỏ hàng</span>
                              </button>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="content-bottom">
                    <h2>Sản phẩm liên quan</h2>
                    <div class="related-product">
                        <div class="related-list" id="relatedList" runat="server">
                            <div class="related-item">
                                <a href="#!">
                                    <img src="./assets/img/Mobile/15-pro-max-xanh-2.png" alt="Iphone 15 Pro Max" />
                                  </a>
                                  <h3>Iphone 15 Promax</h3>
                                  <span>
                                    <strong>4,390,000</strong>
                                  </span>
                                  <div class="product-rating">
                                    <img src="./assets/img/Icon/Star.svg" alt="" />
                                  </div>
                                  <div class="product-cta">
                                    <a href="#!">Mua ngay</a>
                                  </div>
                            </div>
                            <div class="related-item">
                              <a href="#!">
                                  <img src="./assets/img/Mobile/15-pro-max-xanh-2.png" alt="Iphone 15 Pro Max" />
                                </a>
                                <h3>Iphone 15 Promax</h3>
                                <span>
                                  <strong>4,390,000</strong>
                                  <del>5,000,000</del>
                                </span>
                                <div class="product-rating">
                                  <img src="./assets/img/Icon/Star.svg" alt="" />
                                </div>
                                <div class="product-cta">
                                  <a href="#!">Mua ngay</a>
                                </div>
                            </div>
                            <div class="related-item">
                            <a href="#!">
                                <img src="./assets/img/Mobile/15-pro-max-xanh-2.png" alt="Iphone 15 Pro Max" />
                              </a>
                              <h3>Iphone 15 Promax</h3>
                              <span>
                                <strong>4,390,000</strong>
                                <del>5,000,000</del>
                              </span>
                              <div class="product-rating">
                                <img src="./assets/img/Icon/Star.svg" alt="" />
                              </div>
                              <div class="product-cta">
                                <a href="#!">Mua ngay</a>
                              </div>
                            </div>
                            <div class="related-item">
                          <a href="#!">
                              <img src="./assets/img/Mobile/15-pro-max-xanh-2.png" alt="Iphone 15 Pro Max" />
                            </a>
                            <h3>Iphone 15 Promax</h3>
                            <span>
                              <strong>4,390,000</strong>
                              <del>5,000,000</del>
                            </span>
                            <div class="product-rating">
                              <img src="./assets/img/Icon/Star.svg" alt="" />
                            </div>
                            <div class="product-cta">
                              <a href="#!">Mua ngay</a>
                            </div>
                            </div>

                            <div class="related-item">
                                <a href="#!">
                                    <img src="./assets/img/Mobile/15-pro-max-xanh-2.png" alt="Iphone 15 Pro Max" />
                                </a>
                                <h3>Iphone 15 Promax</h3>
                                <span>
                                    <strong>4,390,000</strong>
                                    <del>5,000,000</del>
                                </span>
                                <div class="product-rating">
                                    <img src="./assets/img/Icon/Star.svg" alt="" />
                                </div>
                                <div class="product-cta">
                                    <a href="#!">Mua ngay</a>
                                </div>
                            </div>
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
                  <a href="#!"
                    ><i class="social-icon fa-brands fa-facebook"></i
                  ></a>
                  <a href="#!"
                    ><i class="social-icon fa-brands fa-youtube"></i
                  ></a>
                  <a href="#!"><i class="social-icon fa-brands fa-tiktok"></i></a>
                  <a href="#!"
                    ><i class="social-icon fa-brands fa-instagram"></i
                  ></a>
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
    <script src="./assets/js/product.js"></script>
</body>
</html>
