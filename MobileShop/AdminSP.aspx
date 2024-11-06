<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminSP.aspx.cs" Inherits="MobileShop.AdminSP" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin</title>
    <link rel="stylesheet" href="./assets/css/style.css"/>
    <link rel="stylesheet" href="./assets/fontawesome-free-6.6.0-web/css/all.min.css"/>
    <link rel="stylesheet" href="./assets/css/style.css"/>
    <link rel="stylesheet" href="./assets/css/AdminSP.css" />

</head>
<body>
    <form id="adminsp" runat="server" method="post" onsubmit="return checkInp();">
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
           <%-- Quản lý sản phẩm --%>
            <div id="quanlysp" class="form-product" runat="server">
                <h2>Quản lý sản phẩm</h2>
                <div class="form-container">
                    <div class="form-row">
                        <label>ID</label>
                        <input type="text" name="idsp" id="idsp" placeholder="Nhập ID sản phẩm" runat="server" />
                        <span class="checksp" id="checkID" runat="server"></span>
                    </div>
                    <div class="form-row">
                        <label>Tên sản phẩm</label>
                        <input type="text" name="tensp" id="tensp" placeholder="Nhập tên sản phẩm" runat="server" />
                        <span class="checksp" id="checktensp" runat="server"></span>
                    </div>
                    <div class="form-row">
                        <label>Mô tả</label>
                        <textarea id="motasp" name="motasp" placeholder="Nhập mô tả sp" runat="server"></textarea>
                        <span class="checksp" id="checkmota" runat="server"></span>
                    </div>
                    <div class="form-row">
                        <label>Loại sản phẩm</label>
                        <select id="prtype" value="type" name="loaisp" runat="server">
                            <option value=""></option>
                            <option value="Mobile">Mobile</option>
                            <option value="Tablet">Tablet</option>
                            <option value="Accessories">Accessories</option>
                        </select>
                        <span class="checksp" id="checkloai" runat="server"></span>
                    </div>
                    <div class="form-row">
                        <label>Hãng sản xuất</label>
                        <input type="text" name="hangsx" id="hangsx" placeholder="Nhập hãng sản xuất" runat="server" />
                        <span class="checksp" id="checkhangsx" runat="server"></span>
                    </div>
                    <div class="form-row">
                        <label>Ảnh sản phẩm</label>
                        <input type="file" name="anhsp" id="anhsp" accept=".png,.jpg,.jpeg" runat="server" />
                        <span class="checksp" id="checkanhsp" runat="server"></span>
                    </div>
                    <%--<div class="form-row" runat="server">
                        <label>Ảnh sản phẩm hiện tại</label>
                        <img id="previewImage" src="" alt="Ảnh sản phẩm" style="max-width: 200px; max-height: 200px;" runat="server" />
                    </div>--%>
                    <div class="form-row">
                       <label> Giá tiền</label>
                        <input type="text" name="giasp" id="giasp" placeholder="Nhập giá tiền(chỉ chấp nhận số)" runat="server"/>
                        <span class="checksp" id="checkgia" runat="server"></span>
                    </div>
                    <div class="checksp" id ="message" runat="server"></div>
                    <div class="form-btn">
                        <asp:Button ID="btnAdd"  CssClass="btnThem" Text="Thêm"  runat="server" OnClick="themSP"/>
                        <asp:Button ID="btnUpdate" CssClass="btnSua" Text="Sửa"  runat="server" OnClick="suaSP"/>
                        <asp:Button ID="btnCancel" CssClass ="btnHuy" Text="Hủy" runat="server" OnClick="btnHuy_Click"/>
                    </div>
                </div>
            </div>
            <%-- Danh sách sản phẩm --%>
            <h2>Danh sách sản phẩm</h2>
            <div id="hienthidanhsachsp" class="products" runat="server">
            </div>

            <div id="hienthidanhsachuser" runat="server">
            </div>
        </div>
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
    </form>
    <script src="./assets/js/adminsp.js"></script>
</body>
</html>
