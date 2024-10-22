using MobileShop.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MobileShop
{
    public partial class DangNhap : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (IsPostBack)
            {
                List<User> userList = (List<User>)Application["Users"];
                User user = new User();
                string tentk = Request.Form["taikhoan"];
                string mk = Request.Form["matkhau"];
                bool check = true;
                foreach (User u1 in userList){
                    if (u1.TaiKhoan == tentk && u1.MatKhau == mk)
                    {
                        user = u1;
                        Session["User"] = user;
                        check = true;
                        break;
                    }
                    else
                    {
                        check = false;
                    }
                }
                if (check)
                {
                    Session["User"] = user;
                    Session["username"] = user.TaiKhoan;
                    Response.Redirect("TrangChu.aspx");
                }
                else
                {
                    Response.Redirect("Dangnhap.aspx");
                }

            }
        }
    }
}