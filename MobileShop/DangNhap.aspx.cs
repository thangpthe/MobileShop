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
                bool checkUser = false;
                bool checkPassWord = false;
                foreach (User u1 in userList)
                {
                    if(u1.TaiKhoan == tentk)
                    {
                        checkUser = true;

                        if(u1.MatKhau == mk)
                        {
                            checkPassWord = true;
                            user = u1;
                            break;
                        }
                    }
                }

                if(checkUser && checkPassWord)
                {
                    Session["User"] = user;
                    Session["username"] = user.TaiKhoan;
                    Response.Redirect("TrangChu.aspx");
                }
                //nếu tồn tại user mật khẩu sai
                else if (checkUser && !checkPassWord)
                {
                    errorpassword.InnerText = "Bạn nhập sai mật khẩu, vui lòng nhập lại !";
                }

                else
                {
                    errorusername.InnerText = "Tài khoản của bạn chưa được đăng ký!";
                }
            }
        }
    }
}