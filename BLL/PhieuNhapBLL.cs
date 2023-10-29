using DTO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PhieuNhapBLL
    {
        PhieuNhapDAL pnDAL = new PhieuNhapDAL();
        public List<PhieuNhap> getPhieuNhapList(NhanVien nv)
        {
            return pnDAL.getPhieuNhapList(nv);
        }
        public bool addPhieuNhap(PhieuNhap pn)
        {
            return pnDAL.addPhieuNhap(pn);
        }
        public bool editPhieuNhap(PhieuNhap pn)
        {
            return pnDAL.editPhieuNhap(pn);
        }
        public Boolean delPhieuNhap(PhieuNhap pn)
        {
            return pnDAL.delPhieuNhap(pn);
        }
        public List<ChiTietPhieuNhap> getCTPhieuNhap(PhieuNhap pn)
        {
            return pnDAL.getCTPhieuNhap(pn);
        }

        public bool addCTPhieuNhap(ChiTietPhieuNhap ctpn)
        {
            return pnDAL.addCTPhieuNhap(ctpn);
        }
        public bool editCTPhieuNhap(ChiTietPhieuNhap ctpn)
        {
            return pnDAL.editCTPhieuNhap(ctpn);
        }
        public Boolean delCTPhieuNhap(ChiTietPhieuNhap ctpn)
        {
            return pnDAL.delCTPhieuNhap(ctpn);
        }
        private PhieuNhap pn = new PhieuNhap();
        public PhieuNhap SetPhieuNhap(NhanVien nv)
        {          
            var mch = new String(nv.maCuaHang.Where(Char.IsLetter).ToArray());
           
            pn.maPhieuNhap = mch + nv.maNhanVien  + pn.randomString();
            pn.maNhanVien = nv.maNhanVien;
            pn.maCuaHang = nv.maCuaHang;
            pn.ngayNhap = DateTime.Now;
            pn.trangThai = false;
            return pn;
        }
        public PhieuNhap GetPhieuNhap()
        {
            return pn;
        }
        public List<PhieuNhap> TimKiemPNCH(string tuKhoa)
        {
            return pnDAL.TimKiemPNCH(tuKhoa);
        }
        }
}
