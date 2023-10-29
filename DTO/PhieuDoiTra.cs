using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PhieuDoiTra
    {
        public String maPhieuDoiTra
        { set; get; }
        public String maNhanVien
        { set; get; }

        public String maKhachHang
        { set; get; }

        public DateTime ngayDoiTra
        { set; get; }

        public String maXuLyDoiTra
        { set; get; }

        public String maHoaDon
        { set; get; }

        public decimal TongTien { get; set; }
    }
}
