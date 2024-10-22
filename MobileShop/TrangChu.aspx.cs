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
            //User user = (User)Session["User"];
            //if (user != null)
            //{
            //    lblUsername.Text = "Xin chào " + user.TaiKhoan.ToString();
            //    btnLogOut.Visible = true;

            //    // Hiển thị phần quản lý sản phẩm nếu tài khoản là admin
            //    adminsp.InnerText = user.TaiKhoan == "admin" ? "Quản lý sản phẩm" : "";
            //}
            //else
            //{
            //    lblUsername.Text = "Đăng nhập";
            //}
            User user = (User)Session["User"];
            if (!IsPostBack)
            {
                checkLogin(user);
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