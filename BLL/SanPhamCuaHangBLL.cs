using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SanPhamCuaHangBLL
    {
        SanPham_CuaHangDAL spchdal = new SanPham_CuaHangDAL();
        public List<SanPham_CuaHang> getSPTheoCuaHangList()
        {
            return spchdal.getSPTheoCuaHangList();
        }
        public SanPham_CuaHang getSanPhamCuaHang(String mch, String maSPTheoSize)
        {
            return spchdal.getSanPhamCuaHang(mch,maSPTheoSize);
        }
        public bool updateSanPhamCuaHang(SanPham_CuaHang spch)
        {
            return spchdal.updateSanPhamCuaHang(spch);
        }
    }
}