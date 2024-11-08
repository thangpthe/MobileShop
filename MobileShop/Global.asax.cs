using MobileShop.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace MobileShop
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            //Danh sách tài khoản
            //Application Users
            Application["Users"] = new List<User>();
            List<User> userList = (List<User>)Application["Users"];
            //admin
            User ad = new User();
            ad.HoTen = "admin";
            ad.Sdt = "admin";
            ad.DiaChi = "admin";
            ad.TaiKhoan = "admin";
            ad.MatKhau = "admin";
            ad.MaXacNhan = "MaXaC";
            userList.Add(ad);

            //Người dùng 1
            User u1 = new User();
            u1.HoTen = "Phùng Thế Thăng";
            u1.Sdt = "0347826929";
            u1.DiaChi = "Thanh Xuân";
            u1.TaiKhoan = "thethang";
            u1.MatKhau = "thethang";
            u1.MaXacNhan = "TheTH";
            userList.Add(u1);

            //Người dùng 2
            User u2 = new User();
            u2.HoTen = "Vũ Văn Phúc";
            u2.DiaChi = "Định Công";
            u2.Sdt = "0123456789";
            u2.TaiKhoan = "vanphuc";
            u2.MatKhau = "vanphuc";
            u2.MaXacNhan = "VanPH";
            userList.Add(u2);
            Application["Users"] = userList;


            //Danh sách sản phẩm
            Application["Products"] = new List<Product>();
            List<Product> productList = (List<Product>)Application["Products"];

            Product pr1 = new Product();
            pr1.ID = "001";
            pr1.TenSP = "Samsung Galaxy S24 Ultra";
            pr1.Mota = "Màn hình 6.8 inch Dynamic AMOLED 2X tần số quét 120Hz. Máy cũng sở hữu camera chính 200MP, camera zoom quang học 50MP, camera tele 10MP và camera góc siêu rộng 12MP.";
            pr1.Anhsp = "./assets/img/Mobile/s24-ultra-vang_638409930027889246.png";
            pr1.Hangsx = "Samsung";
            pr1.Giatien = 29990000;
            pr1.Loaisp = "Mobile";
            productList.Add(pr1);

            Product pr2 = new Product();
            pr2.ID = "002";
            pr2.TenSP = "Xiaomi 14 Ultra";
            pr2.Mota = "Màn hình: Kích thước 6.73 inch, tấm nền AMOLED, độ phân giải 2K (3.200 x 1.440 pixels), tần số quét 120 Hz, độ sáng tối đa 3.000 nits. CPU: Snapdragon 8 Gen 3. RAM: 16 GB. Bộ nhớ trong: 512 GB.";
            pr2.Anhsp = "./assets/img/Mobile/xiaomi-14-ultra.jpg";
            pr2.Hangsx = "Xiaomi";
            pr2.Giatien = 29990000;
            pr2.Loaisp = "Mobile";
            productList.Add(pr2);

            Product pr3 = new Product();
            pr3.ID = "003";
            pr3.TenSP = "Oppo A78";
            pr3.Mota = "Màn hình: Kích thước 6.43 inch, tấm nền IPS LCD, độ phân giải Full HD+ (1.080 x 2.400 pixels), tần số quét 90 Hz. Vi xử lý: Snapdragon 680. RAM: 8 GB. Bộ nhớ trong: 256 GB, hỗ trợ mở rộng bộ nhớ qua thẻ nhớ MicroSD (tối đa 1 TB).";
            pr3.Anhsp = "./assets/img/Mobile/oppo-a78-xanh-thumb-1-600x600.jpg";
            pr3.Hangsx = "Oppo";
            pr3.Giatien = 6990000;
            pr3.Loaisp = "Mobile";
            productList.Add(pr3);

            Product pr4 = new Product();
            pr4.ID = "004";
            pr4.TenSP = "Samsung Galaxy A55";
            pr4.Mota = "Hiệu năng mạnh mẽ nhờ chip Exynos 1480 8 nhân, bên cạnh màn hình Super AMOLED cùng độ phân giải Full HD+ 1080 x 2400 cho trải nghiệm giải trí đỉnh cao";
            pr4.Anhsp = "./assets/img/Mobile/sp1.jpg";
            pr4.Hangsx = "Samsung";
            pr4.Giatien = 9690000;
            pr4.Loaisp = "Mobile";
            productList.Add(pr4);

            Product pr5 = new Product();
            pr5.ID = "005";
            pr5.TenSP = "Redmi Note 13";
            pr5.Mota = "Màn hình: Kích thước 6.67 inch, tấm nền AMOLED, độ phân giải Full HD+ (1.080 x 2.400 pixels), tần số quét 120 Hz. CPU: Snapdragon 685.";
            pr5.Anhsp = "./assets/img/Mobile/sp3.jpg";
            pr5.Hangsx = "Xiaomi";
            pr5.Giatien = 4390000;
            pr5.Loaisp = "Mobile";
            productList.Add(pr5);

            Product pr6 = new Product();
            pr6.ID = "006";
            pr6.TenSP = "Realme C67";
            pr6.Mota = "Chipset Snapdragon 685 6nm, dung lượng RAM 8GB, bộ nhớ trong 128 GB cùng viên pin Li-po 5000 mAh";
            pr6.Anhsp = "./assets/img/Mobile/realme-c67.jpg";
            pr6.Hangsx = "Realme";
            pr6.Giatien = 4390000;
            pr6.Loaisp = "Mobile";
            productList.Add(pr6);

            Product pr7 = new Product();
            pr7.ID = "007";
            pr7.TenSP = "Iphone 16 Pro";
            pr7.Mota = "Phone 16 Pro có thay đổi một chút về kích thước với màn hình 6.3 inch lớn hơn, viền mỏng hơn và lớp hoàn thiện bằng titan. Sự bổ sung các nâng cấp vượt trội về camera cũng là điểm nhấn với Apple Intelligence (AI) bao gồm nút Điều khiển Camera - Camera Control. Hiệu suất và tốc độ nhanh hơn đến 20% với chipset Apple A18 Pro mới của nhà sản xuất hàng đầu thế giới - TSMC."; 
            pr7.Hangsx = "Apple";
            pr7.Anhsp = "./assets/img/Mobile/iphone16pro.jpeg";
            pr7.Giatien = 28990000;
            pr7.Loaisp = "Mobile";
            productList.Add(pr7);

            Product pr8 = new Product();
            pr8.ID = "008";
            pr8.TenSP = "Iphone 16 Plus";
            pr8.Mota = " IPhone 16 Plus được trang bị chip Apple A18 Bionic (3nm), mang lại hiệu năng mạnh mẽ, xử lý mượt mà mọi tác vụ từ đa nhiệm đến các ứng dụng nặng";
            pr8.Anhsp = "./assets/img/Mobile/iphone-16-plus.jpg";
            pr8.Hangsx = "Apple";
            pr8.Giatien = 24990000;
            pr8.Loaisp = "Mobile";
            productList.Add(pr8);

            Product pr9 = new Product();
            pr9.ID = "009";
            pr9.TenSP = "Iphone 15 Pro Max";
            pr9.Mota = "Chip A17 Bionic mạnh mẽ hơn 30% so với phiên bản tiền nhiệm, cùng RAM 8GB cho khả năng đa nhiệm tối ưu nhất. Pin dung lượng lớn hỗ trợ 95 giờ phát nhạc, giúp người dùng sử dụng trong cả ngày dài. ";
            pr9.Anhsp = "./assets/img/Mobile/15-pro-max-xanh-2.png";
            pr9.Hangsx = "Apple";
            pr9.Giatien = 26690000;
            pr9.Loaisp = "Mobile";
            productList.Add(pr9);

            Product pr10 = new Product();
            pr10.ID = "010";
            pr10.TenSP = "Ipad Gen 9";
            pr10.Mota = "Màn hình Retina IPS LCD, có độ phân giải chuẩn 1620 x 2160 Pixel với tỷ lệ khung 4:3 và sở hữu tốc độ chạm là 60 Hz. Ngoài ra, cả mật độ điểm ảnh và độ sáng của iPad Gen 9 đều được nhận xét là vô cùng tốt, cụ thể là đạt chỉ số 264 ppi và 450 nits. ";
            pr10.Anhsp = "./assets/img/Tablet/ipadgen9.jpg";
            pr10.Hangsx = "Apple";
            pr10.Giatien = 6990000;
            pr10.Loaisp = "Tablet";
            productList.Add(pr10);

            Product pr11 = new Product();
            pr11.ID = "011";
            pr11.TenSP = "Ipad Gen 10";
            pr11.Mota = "Trang bị màn hình Liquid Retina IPS, kích thước 10.9 inch, 2.360 x 1.640 pixel giúp hiển thị sắc nét và chi tiết hơn, trang bị công nghệ True Tone. ";
            pr11.Anhsp = "./assets/img/Tablet/ipad-gen-10-4.jpg";
            pr11.Hangsx = "Apple";
            pr11.Giatien = 13490000;
            pr11.Loaisp = "Tablet";
            productList.Add(pr11);

            Product pr12 = new Product();
            pr12.ID = "012";
            pr12.TenSP = "Ipad Pro M4 11 inch";
            pr12.Mota = "iPad Pro M4 11 inch là mẫu máy tính bảng dành cho các công việc chuyên nghiệp khi được trang bị con chip M4 với hiệu năng vượt bậc. Thế hệ iPad Pro mới còn sở hữu thiết kế mới mảnh mai hơn cùng màn hình Ultra Retina XDR siêu đẹp mắt để nâng tầm trải nghiệm.";
            pr12.Anhsp = "./assets/img/Tablet/ipad-pro-13.jpg";
            pr12.Hangsx = "Apple";
            pr12.Giatien = 6990000;
            pr12.Loaisp = "Tablet";
            productList.Add(pr12);

            Product pr13 = new Product();
            pr13.ID = "013";
            pr13.TenSP = "Samsung Galaxy Tab A7";
            pr13.Mota = "Bên trong Samsung Galaxy Tab A7 (2020) là bộ vi xử lý Snapdragon 662 gồm 4 lõi 2.0 GHz và 4 lỗi 1.8 Ghz được sản xuất theo tiến trình 11 nm mang đến hiệu năng ổn định, đảm bảo các tác vụ luôn được xử lý một cách mượt mà, hiếm khi xảy ra hiện tượng giật lag.\r\n\r\n";
            pr13.Anhsp = "./assets/img/Tablet/samsung-galaxy-tab-a7.jpg";
            pr13.Hangsx = "Samsung";
            pr13.Giatien = 3790000;
            pr13.Loaisp = "Tablet";
            productList.Add(pr13);

            Product pr14 = new Product();
            pr14.ID = "014";
            pr14.TenSP = "Lenovo Tab M11";
            pr14.Mota = "Lenovo Tab M11 sở hữu cho mình màn hình IPS LCD với kích thước lớn lên đến 11 inch, độ phân giải 1.920 x 1.200 pixels, tấm nền được trang bị trên Tab M11 còn hỗ trợ tần số quét 90 Hz.";
            pr14.Anhsp = "./assets/img/Tablet/sp5.png";
            pr14.Hangsx = "Lenovo";
            pr14.Giatien = 5090000;
            pr14.Loaisp = "Tablet";
            productList.Add(pr14);

            Product pr15 = new Product();
            pr15.ID = "015";
            pr15.TenSP = "Xiaomi Pad 5 Pro";
            pr15.Mota = "Xiaomi Pad 5 Pro sở hữu chip Snapdragon 870 5G cực mạnh, màn hình IPS LCD độ phân giải QHD+ (2K+), tần số quét 120Hz siêu mượt. Cung cấp năng lượng cho máy hoạt động là viên pin 8600mAh kèm sạc siêu nhanh 67W";
            pr15.Anhsp = "/assets/img/Tablet/xiao-pad-5-pro.jpg";
            pr15.Hangsx = "Xiaomi";
            pr15.Giatien = 8690000;
            pr15.Loaisp = "Tablet";
            productList.Add(pr15);

            Product pr16 = new Product();
            pr16.ID = "016";
            pr16.TenSP = "Xiaomi Pad 6";
            pr16.Mota = "Hiệu năng siêu mạnh với Snapdragon 8+ Gen 1, màn hình 11 inch, độ phân giải 2.8K với tần số quét 144Hz, viên pin lớn 8600mAh kèm sạc nhanh 67W cũng như camera kép 50MP chất lượng";
            pr16.Anhsp = "./assets/img/Tablet/xiaomi-pad-6.jpg";
            pr16.Hangsx = "Xiaomi";
            pr16.Giatien = 8490000;
            pr16.Loaisp = "Tablet";
            productList.Add(pr16);

            Product pr17 = new Product();
            pr17.ID = "017";
            pr17.TenSP = "Xiaomi Pad SE";
            pr17.Mota = "Hiệu năng siêu mạnh với Snapdragon 8+ Gen 1, màn hình 11 inch, độ phân giải 2.8K với tần số quét 144Hz, viên pin lớn 8600mAh kèm sạc nhanh 67W cũng như camera kép 50MP chất lượng";
            pr17.Anhsp = "./assets/img/Tablet/xiaomi-pad-se.jpg";
            pr17.Hangsx = "Xiaomi";
            pr17.Giatien = 4390000;
            pr17.Loaisp = "Tablet";
            productList.Add(pr17);

            Product pr18 = new Product();
            pr18.ID = "018";
            pr18.TenSP = "Samsung Galaxy Tab S9";
            pr18.Mota = "Với vi xử lý Qualcomm Snapdragon 8nm và RAM 8GB, Samsung Galaxy Tab S9 128GB mang đến khả năng xử lý mạnh mẽ và tốc độ chưa từng có. Điều này cho phép bạn trải nghiệm mượt mà các ứng dụng, trò chơi, và dễ dàng chuyển đổi giữa các tác vụ mà không hề bị gián đoạn.";
            pr18.Anhsp = "./assets/img/Tablet/samsung-galaxy-tab-s9.png";
            pr18.Hangsx = "Samsung";
            pr18.Giatien = 16990000;
            pr18.Loaisp = "Tablet";
            productList.Add(pr18);

            Product pr19 = new Product();
            pr19.ID = "019";
            pr19.TenSP = "Giá treo màn hình";
            pr19.Mota = "Giá treo màn hình North Bayou M2 Màu xám là giải pháp hoàn hảo cho những ai muốn tối ưu hóa không gian làm việc và nâng cao trải nghiệm sử dụng màn hình. Với thiết kế hiện đại và tính năng linh hoạt, sản phẩm này giúp bạn dễ dàng điều chỉnh vị trí của màn hình để đạt được góc nhìn tối ưu.";
            pr19.Anhsp = "./assets/img/Accessories/66681_gia_treo_man_hinh_north_bayou_g40.jpg";
            pr19.Hangsx = "North Bayou";
            pr19.Giatien = 349000;
            pr19.Loaisp = "Accessories";
            productList.Add(pr19);

            Product pr20 = new Product();
            pr20.ID = "020";
            pr20.TenSP = "Ốp lưng Magsafe";
            pr20.Mota = "Được chế tạo từ hỗn hợp chất liệu polycarbonate trong suốt và chất liệu dẻo, ốp lưng vừa khít với các nút bấm của điện thoại, vô cùng tiện dụng. Ốp lưng này phối hợp mượt mà với Điều Khiển Camera. Ốp có mặt tinh thể sapphire, kết hợp với lớp dẫn truyền để chuyển động của ngón tay bạn có thể truyền qua Điều Khiển Camera.";
            pr20.Anhsp = "./assets/img/Accessories/op-lung-magsafe-iphone-15-pro-max-nhua-trong-apple-mt233-thumb-650x650.png";
            pr20.Hangsx = "Iphone";
            pr20.Giatien = 490000;
            pr20.Loaisp = "Accessories";
            productList.Add(pr20);

            Product pr21 = new Product();
            pr21.ID = "021";
            pr21.TenSP = "Sạc dự phòng";
            pr21.Mota = "Sạc dự phòng Energizer 10,000mAh - UE10053 chính hãng có thiết kế khá mỏng và nhẹ. Nó có kích thước khoảng 140 x 68 x 16 mm và trọng lượng chỉ khoảng 218g. Nhờ đó, bạn có thể dễ dàng bỏ vào túi và mang theo khi di chuyển bên ngoài.";
            pr21.Anhsp = "./assets/img/Accessories/sacduphong.jpg";
            pr21.Hangsx = "Energizer";
            pr21.Giatien = 299000;
            pr21.Loaisp = "Accessories";
            productList.Add(pr21);

            Product pr22 = new Product();
            pr22.ID = "022";
            pr22.TenSP = "Sạc nhanh 15W";
            pr22.Mota = "Sạc nhanh Samsung 15W type C được tích hợp với các công nghệ hiện đại để đảm bảo an toàn tối đa và giảm thiểu thời gian chờ đợi. Bên cạnh đó, việc tích hợp cáp USB-C cũng giúp người dùng dễ dàng kết nối với điện thoại hoặc máy tính bảng.";
            pr22.Anhsp = "./assets/img/Accessories/sacnhanh15w.jpg";
            pr22.Hangsx = "Apple";
            pr22.Giatien = 310000;
            pr22.Loaisp = "Accessories";
            productList.Add(pr22);

            Product pr23 = new Product();
            pr23.ID = "023";
            pr23.TenSP = "Bao da Ipad Gen 9";
            pr23.Mota = "Bao da cho iPad Gen 9 10.2 Mutural Design được hoàn thiện vô cùng độc đáo. Bên ngoài là chất liệu da tổng hợp. Chất liệu da này sẽ giúp mang đến vẻ ngoài thời thượng, giống hệt da thật. Do đó, không những nó mang lại vẻ sang trọng, tinh tế mà còn đem đến khả năng chống sốc, trầy xước rất tốt.";
            pr23.Anhsp = "./assets/img/Accessories/bao-da-ipad-gen-9.jpeg";
            pr23.Hangsx = "Apple";
            pr23.Giatien = 380000;
            pr23.Loaisp = "Accessories";
            productList.Add(pr23);

            Product pr24 = new Product();
            pr24.ID = "024";
            pr24.TenSP = "Camera Tapo C200";
            pr24.Mota = "Camera Tapo C200 được thiết kế trụ tròn quen thuộc với phần chân đế chắc chắn. Nó có kích thước cực nhỏ gọn để bạn có thể đặt ở bất cứ vị trí nào trong ngôi nhà của mình mà không lo chiếm diện tích. ";
            pr24.Anhsp = "./assets/img/Accessories/Camera IP Wi-Fi TP-Link Tapo C212 3M.png";
            pr24.Hangsx = "TP-Link";
            pr24.Giatien = 470000;
            pr24.Loaisp = "Accessories";
            productList.Add(pr24);

            Product pr25 = new Product();
            pr25.ID = "025";
            pr25.TenSP = "Tay cầm chống rung DJI Osmo Mobile 4";
            pr25.Mota = "Thiết bị này chỉ có trọng lượng khoảng 390g, nhẹ hơn một chút so với thế hệ cũ, tất nhiên rồi. Điều này giúp người dùng có thể dễ dàng cầm nắm và thao tác cùng chiêc tay cầm chống rung mà không có cảm giác nặng tay khi sử dụng liên tục trong một thời gian dài. DJI Osmo Mobile 4 chính hãng được giữ nguyên các nút bấm điều chỉnh không có thay đổi nhiều.";
            pr25.Anhsp = "./assets/img/Accessories/tay-cam-chong-rung.jpg";
            pr25.Hangsx = "DJI";
            pr25.Giatien = 2890000;
            pr25.Loaisp = "Accessories";
            productList.Add(pr25);

            Product pr26 = new Product();
            pr26.ID = "026";
            pr26.TenSP = "Pin XS Max Pisen";
            pr26.Mota = "Với dung lượng lên tới 3450mAh, viên pin PISEN này cung cấp năng lượng dồi dào, giúp bạn sử dụng điện thoại trong thời gian dài mà không cần lo lắng về việc sạc lại thường xuyên..";
            pr26.Anhsp = "./assets/img/Accessories/pin-xs-max.png";
            pr26.Hangsx = "Apple";
            pr26.Giatien = 890000;
            pr26.Loaisp = "Accessories";
            productList.Add(pr26);

            Product pr27 = new Product();
            pr27.ID = "027";
            pr27.TenSP = "Dây đeo Apple Air Tag";
            pr27.Mota = "Dây đeo AirTag Loop là giải pháp sử dụng và bảo vệ AirTag hiệu quả từ chính Apple. Với thiết kế thân thiện, bền bỉ và nhiều màu sắc đa dạng khác nhau, chiếc dây deo này sẽ hỗ trợ bạn treo AirTag lên các đồ vật dễ thất lạc để định vị bất cứ khi nào bạn cần.\r\n\r\n";
            pr27.Anhsp = "./assets/img/Accessories/apple-air-tag.jpg";
            pr27.Hangsx = "Apple";
            pr27.Giatien = 50000;
            pr27.Loaisp = "Accessories";
            productList.Add(pr27);


            Application["Products"] = productList;

        }
        protected void Session_Start(object sender, EventArgs e)
        {
            Session["User"] = new User();
            Session["Product"] = new Product();
            Session["SignIn"] = "";
            Session["search"] = new Product();
        }

    }
}