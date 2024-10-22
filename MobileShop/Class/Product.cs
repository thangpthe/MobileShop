using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileShop.Class
{
    public class Product
    {
        string id, tensp, mota, hangsx, anhsp,loaisp;
        int giatien;
        public string ID { 
            get { return id; }
            set { id = value; } 
        }

        public string TenSP {  
            get { return tensp; } 
            set { tensp = value; } 
        }
        public string Mota { 
            get { return mota; } 
            set { mota = value; } 
        }
        public string Hangsx { 
            get { return hangsx; } 
            set { hangsx = value; } 
        }
        public int Giatien {
            get { return giatien; }
            set { giatien = value; } 
        }
        public string Anhsp { 
            get { return anhsp; } 
            set { anhsp = value; } 
        }
        
        public string Loaisp
        {
            get { return loaisp; }
            set { loaisp = value; }
        }
    }
}