using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileShop.Class
{
    public class User
    {
        string hoTen, sdt, diaChi,taiKhoan,matKhau,maXacNhan;
        public string HoTen { 
            get { return hoTen; } 
            set { hoTen = value; }
        }
        public string Sdt { 
            get { return sdt; } 
            set { sdt = value; } 
        }

        public string DiaChi {
            get { return diaChi; }
            set { diaChi = value; } 
        }

        public string TaiKhoan
        {
            get { return taiKhoan; }
            set { taiKhoan = value; }
        }

        public string MatKhau
        {
            get { return matKhau; }
            set { matKhau = value; }
        }

        public string MaXacNhan
        {
            get { return maXacNhan; }
            set { maXacNhan = value; }
        }
    }
}