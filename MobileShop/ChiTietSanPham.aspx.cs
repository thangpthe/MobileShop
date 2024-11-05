using MobileShop.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MobileShop
{
    public partial class ChiTietSanPham : System.Web.UI.Page
    {

        public string formatCurrency(int price)
        {
            return string.Format("{0:N0}", price);
        }
        public void showProduct()
        {
            List<Product> prList = (List<Product>)Application["Products"];
            string prId = Request.QueryString["id"]; //lấy id sản phẩm từ url 
            Product showProduct = new Product();
            foreach(Product sp in prList)
            {
                if(sp.ID == prId)
                {
                    showProduct = sp;
                    Session["Product"] = showProduct;
                }
            }
            //breadcrumb
            if (showProduct.Loaisp == "Mobile") {
                linkPrType.InnerText = "Điện thoại";
                linkPrType.HRef = "DienThoai.aspx";
            }
            if(showProduct.Loaisp == "Tablet")
            {
                linkPrType.InnerText = "Máy tính bảng";
                linkPrType.HRef = "MayTinhBang.aspx";
            }
            if(showProduct .Loaisp == "Accessories")
            {
                linkPrType.InnerText = "Phụ kiện";
                linkPrType.HRef = "PhuKien.aspx";
            }
            linkPrName.InnerText = showProduct.TenSP;
            //info
            //string detail = "";
            //detail += "<img src=\"" + showProduct.Anhsp + "\" alt=\"anh-sp\"/>"
            //        + "<div class=\"product-info\">"
            //        + "<h2 class=\"product-name\">" + showProduct.TenSP + "</h2>"
            //        + "<span class=\"product-price\">" + formatCurrency(showProduct.Giatien) + "</span>"
            //        + "<p>" + showProduct.Mota + "</p>"              
            //        + "<div class=\"product-order\">"
            //        + "<button class=\"buy-now-btn\" onclick=\"buynow(this.value)\">Mua ngay</button>"
            //        + "<button class=\"add-to-cart-btn\" onclick=\"addtocart_click()\">"
            //        + "<span>Thêm vào giỏ hàng</span>"
            //        + "<i class=\"fa-solid fa-cart-shopping\"></i>"
            //        + "</button></div></div>";
            //product.InnerHtml = detail;
            prImg.Src = showProduct.Anhsp;
            prName.InnerText = showProduct.TenSP;
            prPrice.InnerText = formatCurrency(showProduct.Giatien);
            prDesribe.InnerText = showProduct.Mota;
            

            //Hiện sản phẩm liên quan (5sp)
            string output = "";
            int count = 0;
            foreach (Product pr in prList)
            {
                if (pr.Loaisp == showProduct.Loaisp && pr.ID != showProduct.ID)
                {
                    output += "<div class=\"related-item\" id=\"" + pr.ID + "\" onclick=\"product_click(this.id)\">"
                            + "<input type=\"hidden\" value=\"" + pr.ID + "\">"
                            + "<img src=\"" + pr.Anhsp + "\" alt=\"anhsp\"/>"
                            + "<h3>" + pr.TenSP.ToString() + "</h3>"
                            + "<span><strong>" + formatCurrency(pr.Giatien) + "</strong></span>"
                            + "<div class=\"product-cta\">" + "<button value=\"" + pr.ID + "\" onclick=\" cart_click(this.value)\">" + "<i class=\"fa-solid fa-cart-shopping\">" + "</i>" + "</button>" + "</div>"
                            + "</div>";
                    count++;
                    if (count == 5) break; // ngừng vòng lặp khi đã đủ 5 sản phẩm
                }
            }

            relatedList.InnerHtml = output;
        }

        protected void checkLogin()
        {
            User user = (User)Session["User"];
            if (user.TaiKhoan != null)
            {
                lblUsername.Text = user.TaiKhoan;
                btnLogOut.Visible = true;
            }
        }

        public void addToCart()
        {
            List<Product> prList = (List<Product>)Application["Products"];
            User user = (User)Session["User"];

            foreach (Product pr in prList)
            {
                if (pr.ID == prDetail.Value)
                {
                    HttpCookie userCartCookie = Request.Cookies[user.TaiKhoan];

                    // Nếu cookie giỏ hàng chưa tồn tại, tạo mới
                    if (userCartCookie == null || string.IsNullOrEmpty(userCartCookie.Value))
                    {
                        string newItem = prDetail.Value + "-" + soluong.Value; // idsp-số lượng
                        Response.Cookies[user.TaiKhoan].Value = newItem;
                        Response.Cookies[user.TaiKhoan].Expires = DateTime.Now.AddDays(15); // Lưu cookie giỏ hàng trong 15 ngày
                    }
                    else
                    {
                        string cart = userCartCookie.Value;
                        string[] cartItems = cart.Split('_');
                        List<string> updateCart = new List<string>();
                        bool productExist = false;

                        foreach (string item in cartItems)
                        {
                            string[] itemInfo = item.Split('-');
                            string itemID = itemInfo[0];
                            int itemQuantity = int.Parse(itemInfo[1]);

                            // Nếu sản phẩm đã có trong giỏ, tăng số lượng
                            if (itemID == prDetail.Value)
                            {
                                itemQuantity += 1;
                                productExist = true;
                            }

                            // Cập nhật giỏ hàng
                            updateCart.Add(itemID + "-" + itemQuantity);
                        }

                        // Nếu sản phẩm chưa có trong giỏ hàng, thêm sản phẩm mới
                        if (!productExist)
                        {
                            updateCart.Add(prDetail.Value + "-1");
                        }

                        // Cập nhật lại giá trị cookie giỏ hàng
                        Response.Cookies[user.TaiKhoan].Value = string.Join("_", updateCart);
                    }

                    // Làm sạch các trường
                    themvaogiohang.Value = "";
                    prDetail.Value = "";
                    Response.Redirect("GioHang.aspx");
                }
            }
        }

        public void addToCart1()
        {
            Product pr1 = (Product)Session["Product"];
            User user = (User)Session["User"];
            if (pr1.ID != null)
            {
                if (user.TaiKhoan!= null)
                {
                    if (Request.Cookies[user.TaiKhoan] == null || Request.Cookies[user.TaiKhoan].Value == "")
                    {
                        string cookie = pr1.ID + "-1";
                        Response.Cookies[user.TaiKhoan].Value = cookie;
                        Response.Cookies[user.TaiKhoan].Expires = DateTime.Now.AddDays(15);
                        Response.Redirect("GioHang.aspx");
                    }
                    else
                    {
                        string cookie = Request.Cookies[user.TaiKhoan].Value;
                        string[] arr = cookie.Split('_');
                        string newcookie = "";
                        List<string> newarr = new List<string>();
                        int endlp = 0;
                        foreach (string arr1 in arr)
                        {
                            string[] sp = arr1.Split('-');
                            if (sp[0] == pr1.ID)
                            {
                                string newelement = sp[0] + "-" + (Int32.Parse(sp[1]) + Int32.Parse("1")).ToString();
                                newarr.Add(newelement);
                                endlp++;
                            }
                            else
                            {
                                newarr.Add(arr1);
                            }
                        }

                        if (endlp == 0)
                        {
                            string element = pr1.ID + "-1";
                            newarr.Add(element);
                        }
                        int i = 0;
                        foreach (string arr2 in newarr)
                        {
                            if (i == 0)
                            {
                                newcookie = arr2;
                            }
                            else
                            {
                                newcookie += "_" + arr2;
                            }
                            i++;
                        }
                        Response.Cookies[user.TaiKhoan].Value = newcookie;
                        Response.Redirect("GioHang.aspx");
                    }
                }
                else
                {
                    string dn = HttpContext.Current.Request.Url.PathAndQuery;
                    Session["SignIn"] = dn;
                    Response.Redirect("DangNhap.aspx");
                }
            }
        }



        protected void Page_Load(object sender, EventArgs e)
        {
            User user = (User)Session["User"];
            List<Product> prList = (List<Product>)Application["Products"];
            checkLogin();
            if(themvaogiohang.Value == "1")
            {
                if(user.TaiKhoan == null)
                {
                    Response.Redirect("DangNhap.aspx");
                    themvaogiohang.Value = "";
                }
                else
                {
                    addToCart();
                }
            }
            showProduct();
            if(add1.Value != "")
            {
                themvaogiohang.Value = "";
                addToCart1();
            }
        }

        protected void Logout(object sender, EventArgs e)
        {
            try
            {
                Session.Clear();
                Session.Abandon();
                Response.Redirect("TrangChu.aspx", true);
            }
            catch (Exception)
            {
                // Xử lý lỗi ở đây
                Response.Write("Đã xảy ra lỗi khi đăng xuất. Vui lòng thử lại sau.");
            }
        }

        protected void searchProduct(object sender, EventArgs e)
        {
            List<Product> prList = (List<Product>)Application["Products"];
            string searchPr = Request.QueryString["search"];
            Product result = new Product();
            foreach (Product pr in prList)
            {
                if ((pr.TenSP).ToLower() == searchPr.ToLower())
                {
                    result = pr;
                    Session["search"] = result;
                }
            }
            Response.Redirect("TimKiem.aspx");

        }
    }
}