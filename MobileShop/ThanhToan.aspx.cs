using MobileShop.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MobileShop
{
    public partial class ThanhToan : System.Web.UI.Page
    {
        protected void CheckLogin()
        {
            User user = (User)Session["User"];
            if (user.TaiKhoan != null)
            {
                lblUsername.Text = user.TaiKhoan;
                btnLogOut.Visible = true;
            }
        }

        public string formatCurrency(int price)
        {
            return string.Format("{0:N0}", price);
        }
        //hiện sp trong giỏ hàng
        public void ShowCart(string cookie)
        {
            List<Product> prList = (List<Product>)Application["Products"];
            string[] cartItems = cookie.Split('_');//cookie 
            int total = 0;
            string output = "";
            foreach (string cartItem in cartItems)
            {
                string[] sp = cartItem.Split('-');//sp[0] id sản phẩm ,sp[1] số lượng
                foreach (Product product in prList)
                {
                    if (product.ID == sp[0])
                    {
                        int gia = (Int32.Parse(sp[1]) * product.Giatien);
                        output += "<div class=\"cart-item\"><span>" + product.TenSP + "</span>" + "<span>" + formatCurrency(gia) + "</span>" + "</div>";
                        total += gia;
                       
                    }
                }
            }
            cartitems.InnerHtml = output;//danh sách sp
            totalPrice.InnerText = formatCurrency(total);
        }

        //tìm kiếm
        protected void SearchProduct(object sender, EventArgs e)
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
        //thanh toán
        protected void Checkout_Click(object sender, EventArgs e)
        {
            cartitems.InnerHtml = "";
            totalPrice.InnerText = "0";
            User user = (User)Session["User"];
            // Kiểm tra nếu có cookie giỏ hàng thì xóa nó
            if (Request.Cookies[user.TaiKhoan] != null)
            {
                // Thiết lập cookie hết hạn để xóa nó
                HttpCookie cartCookie = new HttpCookie(user.TaiKhoan);
                cartCookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(cartCookie);
            }

            // Hiển thị thông báo mua hàng thành công
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Mua hàng thành công');", true);
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            CheckLogin();
            User user = (User)Session["User"];
            if (user.TaiKhoan != null)
            {
                name.InnerText = user.HoTen;
                phone.InnerText = user.Sdt;
                address.InnerText = user.DiaChi;
                if (Request.Cookies[user.TaiKhoan] == null || Request.Cookies[user.TaiKhoan].Value == "") return;
                else
                {
                    string cookie = Request.Cookies[user.TaiKhoan].Value;
                    ShowCart(cookie);
                }
            }
            else
            {
                string dn = HttpContext.Current.Request.Url.PathAndQuery; //lưu lại lịch sử trang
                Session["SignIn"] = dn;
                Response.Redirect("DangNhap.aspx");
            }
        }
        //Đăng xuất
        protected void Logout(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Response.Redirect("TrangChu.aspx");
        }
    }
}