using MobileShop.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MobileShop
{
    public partial class DangKy : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                // Lấy danh sách người dùng từ Application
                List<User> userList = (List<User>)Application["Users"];
                User u1 = new User();
                // Lấy thông tin từ form đăng ký
                string name = Request.Form["hoten"];
                string phone = Request.Form["sdt"];
                string address = Request.Form["diachi"];
                string tk = Request.Form["taikhoan"];
                string mk = Request.Form["matkhau"];
                bool check = false;
                // Kiểm tra xem tài khoản đã tồn tại chưa
                foreach(User user in userList)
                {
                    if(user.TaiKhoan == tk && user.MatKhau == mk)
                    {
                        check = true;
                        errorusername.InnerHtml = "Tài khoản đã được đăng ký , vui lòng thử lại!";
                        hoten.Value = name;
                        sdt.Value = phone;
                        diachi.Value = address;
                        taikhoan.Value = "";
                        taikhoan.Focus();
                    }
                }
                if(check == false)
                {
                    u1.HoTen = name;
                    u1.Sdt = phone;
                    u1.DiaChi = address;
                    u1.TaiKhoan = tk;
                    u1.MatKhau = mk;
                    userList.Add(u1);
                    Application["Users"] = userList;
                    Response.Redirect("DangNhap.aspx");
                }
            }
        }
    }
}
