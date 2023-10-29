using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using System.Data.SqlClient;

namespace BLL
{
    public class SanPhamBLL
    {
        SanPhamDAL spda = new SanPhamDAL();

        public List<SanPham> LoadDlSanPham()
        {
            return spda.LoadDlSanPham();
        }

        public void ThemSanPham(SanPham sp)
        {
            spda.ThemSanPham(sp);
        }
        public bool KiemTraMaSanPhamTonTai(string maSP)
        {
            return spda.KiemTraMaSanPhamTonTai(maSP);
        }
        public void SuaSanPham(SanPham sp)
        {
            spda.SuaSanPham(sp);
        }
        public void XoaSanPham(string maSP)
        {
            spda.XoaSanPham(maSP);
        }
        public List<SanPham> TimKiemSanPham(string tuKhoa)
        {
            return spda.TimKiemSanPham(tuKhoa);
        }

        public SanPham getSanPham(String MaSanPham)
        {
            return spda.getSanPham(MaSanPham);
        }

        public List<object> ListSPNhanVien(NhanVien nv, List<SanPham> spl, List<MaSanPhamTheoSize> sptsl, List<SanPham_CuaHang> spchl)
        {
            var query = (from spTheoSize in sptsl
                         join sp in spl on spTheoSize.maSanPham equals sp.maSanPham
                         join spch in spchl on spTheoSize.maSPTheoSize equals spch.maSPTheoSize
                         where spch.maCuaHang == nv.maCuaHang
                         group new { spTheoSize, sp, spch } by spTheoSize.maSPTheoSize into grouped
                         select new
                         {
                             maSPTheoSize = grouped.Key,
                             tenSanPham = grouped.First().sp.tenSanPham,
                             moTaSanPham = grouped.First().sp.moTaSanPham,
                             giaNhap = grouped.First().sp.giaNhap,
                             donGiaNiemYet = grouped.First().sp.donGiaNiemYet,
                             chatLieu = grouped.First().sp.chatLieu,
                             soLuong = grouped.First().spch.soLuong,
                             maCuaHang = grouped.First().spch.maCuaHang
                         }).OrderBy(x => x.maSPTheoSize);

            List<object> resultList = query.ToList<object>();
            return resultList;
        }
        public bool IsForeignKeyInOtherTables(string maSP)
        {
            return spda.IsForeignKeyInOtherTables(maSP);
        }
    }
}
