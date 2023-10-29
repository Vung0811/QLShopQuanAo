using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HoaDonBan
    {
        public String maHoaDon { set; get; }
        public String maNhanVien { set; get; }
        public String maKhachHang { set; get; }

        public DateTime ngayLapHoaDon { set; get; }

        public decimal TongTien { get; set; }
    }
}
