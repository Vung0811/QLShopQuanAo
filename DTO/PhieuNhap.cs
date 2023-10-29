using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PhieuNhap
    {
        public string maPhieuNhap
        { get; set; }
        public string maNhanVien
        { get; set; }
        public string maCuaHang
        { get; set; }
        public DateTime ngayNhap
        { get; set; }
        public Boolean trangThai
        { get; set; }
        public Decimal TongTien
        { get; set; }
        public string randomString()
        {
            string result = "";
            var rd = new Random();
            for (int i = 0; i <= 3; i++)
            {
                result += rd.Next(10).ToString();
            }

            return result;
        }
    }
}
