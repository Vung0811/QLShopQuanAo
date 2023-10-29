using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CuaHangBLL
    {
        CuaHangDAL chdal = new CuaHangDAL();
        public CuaHang getCuaHang(String MaCuaHang)
        { return chdal.getCuaHang(MaCuaHang); }
        public List<CuaHang> getCuaHangList()
        {
            return chdal.getCuaHang();
        }
        public List<CuaHang> getCuaHang()
        {
            return chdal.getCuaHang();
        }
        public void ThemCuaHang(CuaHang ch)
        {
            chdal.ThemCuaHang(ch);
        }
        public void SuaCuaHang(CuaHang ch)
        {
            chdal.SuaCuaHang(ch);
        }
        public void XoaCuaHang(string maCH)
        {
            chdal.XoaCuaHang(maCH);
        }
        public List<CuaHang> TimKiemCuaHang(string tuKhoa)
        {
            return chdal.TimKiemCuaHang(tuKhoa);
        }
        public bool IsForeignKeyInOtherTables(string maCH)
        {
            return chdal.IsForeignKeyInOtherTables(maCH);
        }
    }
}
