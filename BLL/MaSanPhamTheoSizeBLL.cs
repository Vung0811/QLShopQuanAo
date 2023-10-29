using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MaSanPhamTheoSizeBLL
    {
        MaSanPhamTheoSizeDAL spda = new MaSanPhamTheoSizeDAL();
        public List<MaSanPhamTheoSize> LoadDlMaSPTheoSize()
        {
            return spda.LoadDlMaSPTheoSize();
        }
        public void ThemSizeVaSoLuong(MaSanPhamTheoSize spts)
        {
            spda.ThemSizeVaSoLuong(spts);
        }
        public bool KiemTraMaSPTSTonTai(string maSPTS)
        {
            return spda.KiemTraMaSPTSTonTai(maSPTS);
        }
        public List<string> LayMaSizeTheoMaSanPham(string maSanPham)
        {
            return spda.LayMaSizeTheoMaSanPham(maSanPham);

        }
        public int LaySoLuongTheoMaSizeVaMaSanPham(string maSize, string maSanPham)
        {
            return spda.LaySoLuongTheoMaSizeVaMaSanPham(maSize, maSanPham);
        }

        public void SuaSoLuongTonKho(MaSanPhamTheoSize sp)
        {
            spda.SuaSoLuongTonKho(sp);
        }
        public void XoaSanPhamTheoSize(string maSP, string maSize)
        {
            spda.XoaSanPhamTheoSize(maSP, maSize);
        }
        public MaSanPhamTheoSize getMSPTheoSize(MaSanPhamTheoSize mspts)
        {
            return spda.getMSPTheoSize(mspts);
        }
        public List<MaSanPhamTheoSize> getSPTheoSIZE(SanPham sp)
        {
            return spda.getSPTheoSIZE(sp);
        }
        public bool IsForeignKeyInOtherTables(string mspts)
        {
            return spda.IsForeignKeyInOtherTables(mspts);
        }
        }
}
