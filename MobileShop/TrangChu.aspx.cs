using MobileShop.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MobileShop
{
    public partial class TrangChu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Product> products = (List<Product>)Application["Products"];
            User user = (User)Session["User"];
            if (!IsPostBack)
            {
                checkLogin(user);
            }


            //check xem ấn chi tiết sản phẩm
            if (prDetail.Value != "" && themvaogiohang.Value == "")
            {
                foreach (Product pr in products)
                {
                    if (prDetail.Value == pr.ID)
                    {
                        Session["Product"] = pr;
                        prDetail.Value = "";
                        themvaogiohang.Value = "";
                        Response.Redirect("ChiTietSanPham.aspx");
                    }
                }
            }

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
                    Response.Redirect("DienThoai.aspx");
                }
            }
        }

        protected void checkLogin(User user)
        {
            if (user.TaiKhoan != null)
            {
                lblUsername.Text = user.TaiKhoan;
                btnLogOut.Visible = true;
                if (user.TaiKhoan == "admin")
                {
                    adminsp.InnerText = "Quản lý sản phẩm";
                }
                else
                {
                    adminsp.InnerText = "";
                }
            }
            else
            {
                lblUsername.Text = "Đăng nhập";
                btnLogOut.Visible = false;
                adminsp.InnerText = "";
            }
        }
        protected void Logout(object sender,EventArgs e)
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

        protected void searchProduct(object sender,EventArgs e)
        {
            List<Product> prList = (List<Product>)Application["Products"];
            string searchPr = Request.Form["search"];
            Product result = new Product();
            foreach(Product pr in prList)
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