using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KhachHang
    {
        public KhachHang() { }
        public String maKhachHang { set; get; }
        public String tenKhach { set; get; }
        public Boolean gioiTinh { set; get; }
        public DateTime ngaySinh { set; get; }
        public String diaChi { set; get; }
        public String soDienThoai { set; get; }
        public string randomString()
        {
            string result = "";
            var rd = new Random();
            for (int i = 0; i <= 4; i++)
            {
                result += rd.Next(10).ToString();
            }

            return result;
        }
        
        public KhachHang(string tenkhachhang,Boolean gioiTinh , DateTime ngaySinh, string diachi, string sdt)
        {
            this.maKhachHang = randomString();
            this.tenKhach = tenkhachhang;
            this.gioiTinh = gioiTinh;
            this.soDienThoai = sdt;
            this.ngaySinh = ngaySinh;
            this.diaChi = diachi;
        }


}
}
