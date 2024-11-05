using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Collections.Specialized.BitVector32;

namespace MobileShop
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
    }
    
}