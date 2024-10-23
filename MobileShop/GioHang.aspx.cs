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
            string output =  "<table><thead><tr><th></th><th>Sản phẩm</th><th>Giá tiền</th><th>Số lượng</th><th>Đơn giá</th><th></th></tr></thead>";
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
                               //+"<td>" + sp[1] + "</td>"
                               +"<td>"+"<input type =\"number\" value=\"" + sp[1] + "\" id=\"soluong\" name=\"soluong\" value=\"1\" onchange=\"nhapsoluong(this.value)\">"+"</td>" 
                               + "<td>" + formatCurrency(gia) + "</td>"
                               + "<td><button value=\"" + sp[0]+ "\" onclick=\"remove_sp(this.value)\"><i class=\"fa-solid fa-xmark\" class=\"btn-remove\"></i></button></td>"
                               + "</tr>";
                    }
                }
            }
            output += "</tbody></table>";
            tableCart.InnerHtml = output;
            totalPrice.InnerText = formatCurrency(total);
        }

        public void removeCartItem(string cookie_value)
        {
            User user = (User)Session["User"];
            List<Product> products = (List<Product>)Application["Products"];
            string cook = cookie_value;
            string[] arr = cook.Split('_');
            List<string> newarr = new List<string>();
            foreach (string arr1 in arr)
            {
                string[] sp = arr1.Split('-');
                if (huysp.Value != sp[0])
                {
                    newarr.Add(arr1);
                }
            }
            string newcookie = "";
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
            showCart(newcookie);
        }


        public void updateQuantity()
        {
            User user = (User)Session["User"];
            string cookie = Request.Cookies[user.TaiKhoan].Value;
            string newcookie = "";

            if (chinhsoluong.Value != "")
            {
                string[] sl = (chinhsoluong.Value).Split('_');
                string[] cookiearr = cookie.Split('_');
                int i = 0;
                foreach (string arr1 in cookiearr)
                {
                    string[] sp = arr1.Split('-');
                    if (i == 0)
                    {
                        newcookie = sp[0] + "-" + sl[i];
                    }
                    else
                    {
                        newcookie += "_" + sp[0] + "-" + sl[i];
                    }
                    i++;
                }
                Response.Cookies[user.TaiKhoan].Value = newcookie;
                showCart(newcookie);
                chinhsoluong.Value = "";
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

                    if(huysp.Value != "")
                    {
                        removeCartItem(cookie);
                        huysp.Value = "";
                    }
                    if(chinhsoluong.Value != "")
                    {
                        updateQuantity();
                    }
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