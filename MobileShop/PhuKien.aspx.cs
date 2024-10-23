using MobileShop.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MobileShop
{
    public partial class PhuKien : System.Web.UI.Page
    {
        
        public string formatCurrency(int price)
        {
            return string.Format("{0:N0}", price);
        }
        protected void ShowProducts()
        {
            List<Product> prList = (List<Product>)Application["Products"];
            string output = "";
            foreach (Product pr in prList)
            {
                if (pr.Loaisp == "Accessories")
                {
                    output += "<div class=\"product-item\" id=\"" + pr.ID + "\" onclick=\"product_click(this.id)\">"
                       + "<input type=\"hidden\" value=\"" + pr.ID + "\">"
                       + "<img src=\"" + pr.Anhsp + "\" alt=\"anhsp\"/>"
                       + "<h3>" + pr.TenSP.ToString() + "</h3>"
                       + "<span>" + "<strong>" + formatCurrency(pr.Giatien) + "</strong>" + "</span>"
                       + "<div class=\"product-cta\">" + "<button value=\"" + pr.ID + "\" onclick=\" cart_click(this.value)\">" + "<i class=\"fa-solid fa-cart-shopping\">" + "</i>" + "</button>" + "</div>"
                       + "</div>";
                }
            }
            productList.InnerHtml = output;
        }

        //lọc sản phẩm

        protected List<string> filterByBrand() //theo hãng sản xuất
        {
            List<string> selectedBrands = new List<string>();
            List<Product> prList = (List<Product>)Application["Products"];
            // Duyệt qua các mục trong CheckBoxList và lấy những mục được chọn
            foreach (ListItem item in listBrand.Items)
            {
                if (item.Selected)
                {
                    selectedBrands.Add(item.Value);
                }
            }
            return selectedBrands;

        }

        protected List<(int, int)> filterByPrice() //theo giá
        {
            List<(int, int)> selectedPrice = new List<(int, int)>();
            foreach (ListItem item in priceRange.Items)
            {
                if (item.Selected)
                {
                    // Tách khoảng giá từ giá trị của ListItem
                    string[] priceRange = item.Value.Split('-');
                    int minPrice = int.Parse(priceRange[0]);
                    int maxPrice = int.Parse(priceRange[1]);

                    selectedPrice.Add((minPrice, maxPrice));
                }
            }

            return selectedPrice;
        }

        protected bool brandMatch(List<string> selectedBrand, Product pr)
        {
            if (selectedBrand.Count == 0 || selectedBrand.Contains(pr.Hangsx)) return true; //sp có hãng sx trong danh sách lọc hoặc không lọc =>true;
            return false;
        }

        protected bool priceMatch(List<(int, int)> selectedPrice, Product pr)
        {
            if (selectedPrice.Count == 0 || selectedPrice.Any(price => pr.Giatien >= price.Item1 && pr.Giatien <= price.Item2)) return true; //nếu không lọc giá hoặc có sản phẩm trong khoảng lọc giá =>true;
            return false;
        }
        protected void filterProduct(object sender, EventArgs e)
        {
            List<Product> prList = (List<Product>)Application["Products"];
            List<String> brandFilter = filterByBrand();
            List<(int, int)> priceFilter = filterByPrice();
            string output = "";
            foreach (Product pr in prList)
            {

                if (brandMatch(brandFilter, pr) && priceMatch(priceFilter, pr) && pr.Loaisp == "Accessories")
                {

                    output += "<div class=\"product-item\" id=\"" + pr.ID + "\" onclick=\"product_click(this.id)\">"
                            + "<input type=\"hidden\" value=\"" + pr.ID + "\">"
                            + "<img src=\"" + pr.Anhsp + "\" alt=\"anhsp\"/>"
                            + "<h3>" + pr.TenSP.ToString() + "</h3>"
                            + "<span>" + "<strong>" + formatCurrency(pr.Giatien) + "</strong>" + "</span>"
                            + "<div class=\"product-cta\">" + "<button value=\"" + pr.ID + "\" onclick=\" cart_click(this.value)\">" + "<i class=\"fa-solid fa-cart-shopping\">" + "</i>" + "</button>" + "</div>"
                            + "</div>";
                }
            }
            if (output == "") productList.InnerText = "Không có sản phẩm thỏa mãn điều kiện";
            else
            {
                productList.InnerHtml = output;
            }
        }

        protected void searchProduct(object sender, EventArgs e)
        {
            List<Product> prList = (List<Product>)Application["Products"];
            string searchPr = Request.Form["search"];
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
                        string newItem = prDetail.Value + "-1"; // idsp-số lượng
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
                    Response.Redirect("PhuKien.aspx");
                }
            }
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
        protected void Page_Load(object sender, EventArgs e)
        {
            User user = (User)Session["User"];
            checkLogin();
            ShowProducts();
            if (themvaogiohang.Value == "1")
            {
                if (user.TaiKhoan == null)
                {
                    Response.Redirect("DangNhap.aspx");
                }
                else
                {
                    addToCart();
                }
            }
        }

        protected void Logout(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Response.Redirect("TrangChu.aspx");
        }
    }
}