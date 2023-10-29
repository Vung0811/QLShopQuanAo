using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SanPham
    {
        public string maSanPham
        { get; set; }
        public string tenSanPham
        { get; set; }
        public string moTaSanPham
        { get; set; }
        public int giaNhap
        { get; set; }
        public int donGiaNiemYet
        { get; set; }
      
        public string chatLieu
        { get; set; }
        public override string ToString()
        {
            return tenSanPham;
        }
    }
}
