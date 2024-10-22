using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MobileShop
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void ShowProducts()
        {
            List<Product> prList = (List<Product>)Application["Products"];
            string output = "";
            foreach (Product pr in prList)
            {
                if (pr.Loaisp == "Mobile")
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
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowProducts();
            if (!IsPostBack)
            {
                if (Session["User"] != null && Session["username"] != null)
                {
                    //Khi người dùng đăng nhập, hiển thị xin chào + tên user , nút đăng xuất
                    lblUsername.Text = "Xin chào" + " " + Session["username"];
                    btnLogOut.Visible = true;
                }
            }
        }
    }
}