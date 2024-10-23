using MobileShop.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MobileShop
{
    public partial class TimKiem : System.Web.UI.Page
    {
        //xử lý giá
        public string formatCurrency(int price)
        {
            return string.Format("{0:N0}", price);
        }
        //các sản phẩm tìm kiếm 
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
        public void showSearchProduct()
        {
            Product searchPr = (Product)Session["search"];
            string output = "";
            if (searchPr == null)
            {
                output = "Không tìm thấy sản phẩm";
            }
            else
            {
                output = "<div class=\"product-item search-item\" id=\"" + searchPr.ID + "\" onclick=\"product_click(this.id)\">"
                            + "<input type=\"hidden\" value=\"" + searchPr.ID + "\">"
                            + "<img src=\"" + searchPr.Anhsp + "\" alt=\"anhsp\"/>"
                            + "<h3>" + searchPr.TenSP.ToString() + "</h3>"
                            + "<span>" + "<strong>" + formatCurrency(searchPr.Giatien) + "</strong>" + "<span>"
                            + "<div class=\"product-cta\">" + "<button value=\"" + searchPr.ID + "\" onclick=\" cart_click(this.value)\">" + "<i class=\"fa-solid fa-cart-shopping\">" + "</i>" + "</button>" + "</div>"
                            + "</div>";
            }
            searchList.InnerHtml = output;
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
                    Response.Redirect("GioHang.aspx");
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
            List<Product> products = (List<Product>)Application["DsProduct"];
            User user = (User)Session["User"];
            Product searched = (Product)Session["search"];

            checkLogin();

            if (searched.ID == "" || searched.ID == null)
            {
                resultLabel.Text = "Không có sản phẩm tìm kiếm";
            }
            else
            {
                //hiện ra danh sách sản phẩm
                showSearchProduct();

                //check xem ấn thêm vào giỏ hàng
                if (themvaogiohang.Value == "1")
                {
                    if (user.TaiKhoan == null)
                    {
                        Response.Redirect("DangNhap.aspx");
                        themvaogiohang.Value = "";
                    }
                    else
                    {
                        addToCart();
                    }
                }

                //Session["search"] = new Product();
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