using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhanVien
    {
        public NhanVien() { }
        public String maNhanVien { set; get; }
        public String hoNhanVien { set; get; }
        public String tenNhanVien { set; get; }
        public Boolean gioiTinh { set; get; }
        public String diaChi { set; get; }
        public String soDienThoai { set; get; }

        public DateTime ngaySinh { set; get; }

        public String chucVu { set; get; }
        public String pass { set; get; }

        public String maCuaHang { set; get; }
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
    }
}
