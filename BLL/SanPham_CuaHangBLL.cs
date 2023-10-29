using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SanPham_CuaHangBLL
    {
        SanPham_CuaHangDAL spchDAL = new SanPham_CuaHangDAL();
        public List<SanPham_CuaHang> LoadDlSP_CH()
        {
            return spchDAL.LoadDlSP_CH();
        }
        public void ThemSPChoCH(SanPham_CuaHang spch)
        {
            spchDAL.ThemSPChoCH(spch);
        }
        public void SuaSPCuaCH(SanPham_CuaHang spch)
        {
            spchDAL.SuaSPCuaCH(spch);
        }
        public void XoaSPCuaCH(string maCH, string maSPTS)
        {
            spchDAL.XoaSPCuaCH(maCH, maSPTS);
        }
        public List<SanPham_CuaHang> TimKiemSanPham_CuaHang(string tuKhoa, string mch)
        {
            return spchDAL.TimKiemSanPham_CuaHang(tuKhoa, mch);
        }

        public List<SanPham_CuaHang> getSPTheoCuaHangList()
        {
            return spchDAL.getSPTheoCuaHangList();
        }
        public SanPham_CuaHang getSanPhamCuaHang(String mch, String maSPTheoSize)
        {
            return spchDAL.getSanPhamCuaHang(mch, maSPTheoSize);
        }
        public bool updateSanPhamCuaHang(SanPham_CuaHang spch)
        {
            return spchDAL.updateSanPhamCuaHang(spch);
        }
        public List<SanPham_CuaHang> getPNTheoCH(SanPham_CuaHang spch)
        {
            return spchDAL.getPNTheoCH(spch);
        }
        }
}
