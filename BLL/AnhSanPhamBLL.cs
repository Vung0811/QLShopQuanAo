using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AnhSanPhamBLL
    {
        AnhSanPhamDAL anhSanPhamDAL = new AnhSanPhamDAL();
        public void ThemAnhSanPham(AnhSanPham asp)
        {

            anhSanPhamDAL.ThemAnhSanPham(asp);

        }
        public List<string> LayDanhSachDuongDanAnh(string maSanPham)
        {
            return anhSanPhamDAL.LayDanhSachDuongDanAnh(maSanPham);
        }
        public void XoaMaSanPhamTrongAnh(string maSP)
        {
            anhSanPhamDAL.XoaMaSanPhamTrongAnh(maSP);
        }
    }
}
