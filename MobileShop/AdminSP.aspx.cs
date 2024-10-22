using MobileShop.Class;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MobileShop
{
    public partial class AdminSP : System.Web.UI.Page
    {
        public string formatCurrency(int price)
        {
            return string.Format("{0:N0}", price);
        }

        public bool checkInput()
        {
            string id = Request.Form["idsp"];
            string sp = Request.Form["tensp"];
            string mota = Request.Form["motasp"];
            string selectedType = prtype.Value;
            string hang = Request.Form["hangsx"];
            string gia = Request.Form["giasp"];
            HttpPostedFile file = Request.Files["anhsp"]; //file ảnh được tải lên
            bool check = true;
            if (id.Trim().Length == 0)
            {
                checkID.InnerText = "Bạn hãy điền ID sản phẩm";
                tensp.Value = sp;
                motasp.Value = mota;
                prtype.Value = selectedType;
                hangsx.Value = hang;
                giasp.Value = gia;
                check = false;
            }
            else
            {
                checkID.InnerText = "";
            }
            if (sp.Trim().Length == 0)
            {
                checktensp.InnerText = "Bạn hãy điền tên sản phẩm";
                idsp.Value = id;
                motasp.Value = mota;
                prtype.Value = selectedType;
                hangsx.Value = hang;
                giasp.Value = gia;
                check = false;
            }
            else
            {
                checktensp.InnerText = "";
            }
            if (mota.Trim().Length == 0)
            {
                checkmota.InnerText = "Bạn hãy điền mô tả sản phẩm";
                idsp.Value = id;
                tensp.Value = sp;
                prtype.Value = selectedType;
                hangsx.Value = hang;
                giasp.Value = gia;
                check = false;
            }
            else
            {
                checkmota.InnerText = "";
            }
            if (string.IsNullOrEmpty(selectedType))
            {
                checkloai.InnerText = "Bạn hãy chọn loại sản phẩm";
                idsp.Value = id;
                tensp.Value = sp;
                motasp.Value = mota;
                hangsx.Value = hang;
                giasp.Value = gia;
                check = false;
            }
            else
            {
                checkloai.InnerText = "";
            }
            if (file.FileName == "" || file == null)
            {
                checkanhsp.InnerText = "Bạn chưa tải ảnh sản phẩm lên";
                check = false;
            }
            else
            {
                checkanhsp.InnerText = "";
            }
            if (gia.Trim().Length == 0)
            {
                checkgia.InnerText = "Bạn hãy điền giá sản phẩm";
                idsp.Value = id;
                tensp.Value = sp;
                motasp.Value = mota;
                hangsx.Value = hang;
                prtype.Value = selectedType;
                check = false;
            }
            else
            {
                checkgia.InnerText = "";
            }
            return check;
        }

        public bool checkInput1()
        {
            string id = Request.Form["idsp"];
            string sp = Request.Form["tensp"];
            string mota = Request.Form["motasp"];
            string selectedType = prtype.Value;
            string hang = Request.Form["hangsx"];
            string gia = Request.Form["giasp"];
            bool check = true;
            if (id.Trim().Length == 0)
            {
                checkID.InnerText = "Bạn hãy điền ID sản phẩm";
                tensp.Value = sp;
                motasp.Value = mota;
                prtype.Value = selectedType;
                hangsx.Value = hang;
                giasp.Value = gia;
                check = false;
            }
            else
            {
                checkID.InnerText = "";
            }
            if (sp.Trim().Length == 0)
            {
                checktensp.InnerText = "Bạn hãy điền tên sản phẩm";
                idsp.Value = id;
                motasp.Value = mota;
                prtype.Value = selectedType;
                hangsx.Value = hang;
                giasp.Value = gia;
                check = false;
            }
            else
            {
                checktensp.InnerText = "";
            }
            if (mota.Trim().Length == 0)
            {
                checkmota.InnerText = "Bạn hãy điền mô tả sản phẩm";
                idsp.Value = id;
                tensp.Value = sp;
                prtype.Value = selectedType;
                hangsx.Value = hang;
                giasp.Value = gia;
                check = false;
            }
            else
            {
                checkmota.InnerText = "";
            }
            if (string.IsNullOrEmpty(selectedType))
            {
                checkloai.InnerText = "Bạn hãy chọn loại sản phẩm";
                idsp.Value = id;
                tensp.Value = sp;
                motasp.Value = mota;
                hangsx.Value = hang;
                giasp.Value = gia;
                check = false;
            }
            else
            {
                checkloai.InnerText = "";
            }
            if (gia.Trim().Length == 0)
            {
                checkgia.InnerText = "Bạn hãy điền giá sản phẩm";
                idsp.Value = id;
                tensp.Value = sp;
                motasp.Value = mota;
                hangsx.Value = hang;
                prtype.Value = selectedType;
                check = false;
            }
            else
            {
                checkgia.InnerText = "";
            }
            return check;
        }
        public void hienSP()
        {
            List<Product> dssp = (List<Product>)Application["Products"];
            int i = 1;
            string output = "<table><thead><tr><td>STT</td><td>ID</td><td>Tên SP</td><td>Mô tả</td><td>Loại SP</td><td>Hãng SX</td><td>Ảnh SP</td><td>Giá tiền</td><td>Sửa/Xóa</td></tr></thead>";
            output += "<tbody>";
            foreach (Product sp in dssp)
            {
                output += "<tr><td>" + i + "</td>"
                    + "<td>" + sp.ID + "</td>"
                    + "<td>" + sp.TenSP + "</td>"
                    + "<td>" + sp.Mota + "</td>"
                    + "<td>" + sp.Loaisp + "</td>"
                    + "<td>" + sp.Hangsx + "</td>"
                    + "<td><img src =\"" + sp.Anhsp + "\" alt=\"anh-sp\"></td>"
                    + "<td>" + formatCurrency(sp.Giatien) + "</td>"
                    + "<td><button type=\"button\" value=\""+sp.ID+"|"+sp.TenSP+"|"+sp.Mota+"|"+sp.Loaisp+"|"+sp.Hangsx+"|"+sp.Giatien+"\" onclick=\"suasp(this.value)\">Chọn</button></td>"
                    + "</tr>";
                i++;
            }
            output += "</tbody></table>";
            hienthidanhsachsp.InnerHtml = output;
        }
        protected void themSP(object sender, EventArgs e)
        {
            List<Product> prList = (List<Product>)Application["Products"];
            if (checkInput())
            {
                string id = Request.Form["idsp"];
                string sp = Request.Form["tensp"];
                string mota = Request.Form["motasp"];
                string selectedType = prtype.Value; //loại sp
                string hang = Request.Form["hangsx"];
                string gia = Request.Form["giasp"];
                HttpPostedFile file = Request.Files["anhsp"];
                file.SaveAs(Server.MapPath("./assets/img/" + selectedType + "/" + file.FileName));//lấy đường dẫn file từ server và lưu lại vào ứng dụng
                bool isDuplicate = false;
                foreach (Product pr in prList)
                {
                    if (pr.ID == id)
                    {
                        checkID.InnerText = "ID sản phầm đã có trong hệ thống, hãy thử lại!";
                        isDuplicate = true;
                        return;
                    }
                    if (pr.TenSP == sp)
                    {
                        checktensp.InnerText = "Sản phẩm " + pr.TenSP + " đã có trong hệ thống!Hãy nhập sản phẩm khác";
                        isDuplicate = true;
                        return;
                    }
                }
                if (!isDuplicate)
                {
                    Product newProduct = new Product();
                    newProduct.ID = id;
                    newProduct.TenSP = sp;
                    newProduct.Mota = mota;
                    newProduct.Loaisp = selectedType;
                    newProduct.Anhsp = "./assets/img/" + selectedType + "/" + file.FileName;
                    newProduct.Hangsx = hang;
                    newProduct.Giatien = Int32.Parse(gia);
                    prList.Add(newProduct);
                    Application["Products"] = prList;
                    message.InnerText = "Thêm thành công!";
                }
                hienSP();
            }
        }
        protected void btnHuy_Click(object sender, EventArgs e)
        {
            idsp.Value = "";
            checkID.InnerText = "";
            motasp.Value = "";
            checkmota.InnerText = "";
            tensp.Value = "";
            checktensp.InnerText = "";
            prtype.Value = "";
            checkloai.InnerText = "";
            hangsx.Value = "";
            checkhangsx.InnerText = "";
            checkanhsp.InnerText = "";
            giasp.Value = "";
            checkgia.InnerText = "";
            message.InnerText = "";
        }
       
        protected void suaSP(object sender, EventArgs e)
        {
            List<Product> prList = (List<Product>)Application["Products"];
            if (checkInput1())
            {
                string id = Request.Form["idsp"];
                string sp = Request.Form["tensp"];
                string mota = Request.Form["motasp"];
                string selectedType = prtype.Value;
                string hang = Request.Form["hangsx"];
                string gia = Request.Form["giasp"];
                HttpPostedFile file = Request.Files["anhsp"]; 
                foreach(Product pr in prList) {
                    if (pr.ID == id)
                    {
                        // Cập nhật thông tin sản phẩm
                        pr.ID = id;
                        pr.TenSP = sp;
                        pr.Mota = mota;
                        pr.Loaisp = selectedType;
                        pr.Hangsx = hang;
                        pr.Giatien = Int32.Parse(gia);
                        // Xử lý cập nhật ảnh nếu có
                        if (file != null && file.ContentLength > 0)
                        {
                            string imagePath = "./assets/img/" + pr.Loaisp + "/" + file.FileName;
                            file.SaveAs(Server.MapPath(imagePath));
                            pr.Anhsp = imagePath;
                        }
                        // Nếu không có ảnh mới thì giữ nguyên ảnh cũ;
                    }
                }
                message.InnerText = "Sửa thành công";
            }
            Application["Products"] = prList;
            hienSP();
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



        //public void hienUser()
        //{
        //    List<User> userList = (List<User>)Application["Users"];
        //    int i = 1;
        //    string output = "<table><thead><tr><td>STT</td><td>Họ tên</td><td>SĐT</td><td>Địa chỉ</td><td>Tài khoản</td><td>Mật khẩu</td><td>Sửa/Xóa</td></tr></thead>";
        //    output += "<tbody>";
        //    foreach (User u1 in userList)
        //    {
        //        output += "<tr><td>" + i + "</td>"
        //            + "<td>" + u1.HoTen + "</td>"
        //            + "<td>" + u1.Sdt + "</td>"
        //            + "<td>" + u1.DiaChi + "</td>"
        //            + "<td>" + u1.TaiKhoan + "</td>"
        //            + "<td>" + u1.MatKhau + "</td>"
        //            + "<td><a href=AdminSP.aspx?id=" + i + ">" + "Sửa" + "</a></td>"
        //            + "</tr>";
        //        i++;
        //    }
        //    output += "</tbody></table>";
        //    hienthidanhsachuser.InnerHtml = output;
        //}


        protected void Page_Load(object sender, EventArgs e)
        {
            User curUser = (User)Session["User"];
            if (curUser == null || curUser.TaiKhoan != "admin")
            {
                Response.Redirect("DangNhap.aspx");
            }                    
            lblUsername.Text = curUser.TaiKhoan;
            btnLogOut.Visible = true;
            hienSP();
            
            //hienUser();
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