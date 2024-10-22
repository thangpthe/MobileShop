using MobileShop.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            productImg.Src = showProduct.Anhsp; 
            productName.InnerText = showProduct.TenSP;
            productPrice.InnerHtml = "<strong>" +formatCurrency(showProduct.Giatien)+ "</strong>";
            productDescribe.InnerText = showProduct.Mota;

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
                            + "<div class=\"product-cta\">" + "<a href=\"#!\">" + "<i class=\"fa-solid fa-cart-shopping\">" + "</i>" + "</a>" + "</div>"
                            + "</div>";
                    count++;
                    if (count == 5) break; // ngừng vòng lặp khi đã đủ 5 sản phẩm
                }
            }

            relatedList.InnerHtml = output;
        }

        
            

        protected void Page_Load(object sender, EventArgs e)
        {
            showProduct();
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