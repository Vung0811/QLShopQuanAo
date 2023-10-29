using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PhieuNhapKho
    {
        public string maPhieuNhap
        { get; set; }
        public string maNhaSanXuat
        { get; set; }
        public DateTime ngayNhap
        { get; set; }

        public Decimal TongTien
        { get; set; }
    }
}
