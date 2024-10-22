using MobileShop.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MobileShop
{
    public partial class GioHang : System.Web.UI.Page
    {
        protected void checkLogin()
        {
            User user = (User)Session["User"];
            if(user.TaiKhoan != null)
            {
                lblUsername.Text = user.TaiKhoan;
                btnLogOut.Visible = true;
            }
        }

        public string formatCurrency(int price)
        {
            return string.Format("{0:N0}", price);
        }

        public void showCart(string cookie)
        {
            List<Product> prList = (List<Product>)Application["Products"];
            string[]cartItems = cookie.Split('_');
            int total = 0;
            string output =  "<table><thead><tr><th></th><th>Sản phẩm</th><th>Giá tiền</th><th>Số lượng</th><th>Đơn giá</th></tr><thead>";
            foreach (string cartItem in cartItems)
            {
                string []sp = cartItem.Split('-');//sp[0] id sản phẩm ,sp[1] số lượng
                foreach (Product product in prList)
                {
                    if(product.ID == sp[0])
                    {
                        int gia = (Int32.Parse(sp[1]) * product.Giatien);
                        total +=  gia;
                        output += "<tbody><tr>"
                               + "<td><img src=\"" + product.Anhsp + "\"/></td>"
                               + "<td>"+product.TenSP +"</td>"
                               +"<td>"+formatCurrency(product.Giatien) +"</td>"
                               +"<td>" + sp[1] + "</td>"
                               + "<td>" + formatCurrency(gia) + "</td>"
                               +"</tr>";
                    }
                }
            }
            output += "</tbody></table>";
            tableCart.InnerHtml = output;
            totalPrice.InnerText = formatCurrency(total);
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

        protected void Page_Load(object sender, EventArgs e)
        {
            checkLogin();
            User user = (User)Session["User"];
            if (user.TaiKhoan != null)
            {
                if (Request.Cookies[user.TaiKhoan] == null || Request.Cookies[user.TaiKhoan].Value == "") return;
                else
                {
                    string cookie = Request.Cookies[user.TaiKhoan].Value;
                    showCart(cookie);
                }
            }
            else
            {
                string dn = HttpContext.Current.Request.Url.PathAndQuery; //lưu lại lịch sử trang
                Session["SignIn"] = dn;
                Response.Redirect("DangNhap.aspx");
            }
        }

        protected void Logout(object sender,EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Response.Redirect("TrangChu.aspx");
        }
    }
}