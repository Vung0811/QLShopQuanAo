using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class NhanVienBLL
    {
        NhanVienDAL nvdal = new NhanVienDAL();
        DangNhapBLL dnBLL = new DangNhapBLL();
        public List<NhanVien> getNhanVienList(String mch, String x)
        {
            return nvdal.getNhanVienList(mch, x);
        }
        public bool checkNhanVienValid(NhanVien nv)
        {
            return nvdal.checkNhanVienValid(nv);
        }
        public bool themNV(String mch, NhanVien nv)
        {
            nv.pass = dnBLL.maHoaMK("123");
            return nvdal.themNV(mch, nv);
        }
        public bool editNhanVien(NhanVien nv)
        {
            return nvdal.editNhanVien(nv);
        }
        public bool delNhanVien(NhanVien nv)
        {
            return nvdal.delNhanVien(nv);
        }
        public Boolean changePassWord(String mkn, String mnv)
        {
            return nvdal.changePassWord(mkn, mnv);
        }
        public NhanVien getNhanVien(String mnv)
        {
            return nvdal.getNhanVien(mnv);
        }



        public List<NhanVien> LoadDlNhanVien()
        {
            return nvdal.LoadDlNhanVien();
        }
        public void ThemNhanVien(NhanVien nv)
        {
            nvdal.ThemNhanVien(nv);
        }

        public void XoaNhanVien(string maNV)
        {
            nvdal.XoaNhanVien(maNV);
        }
        public List<NhanVien> TimKiemNhanVien(string tuKhoa)
        {
            return nvdal.TimKiemNhanVien(tuKhoa);
        }

        public void SuaNhanVien(NhanVien nv)
        {
            nvdal.SuaNhanVien(nv);
        }
        public bool IsForeignKeyInOtherTables(string maNV)
        {
            return nvdal.IsForeignKeyInOtherTables(maNV);
        }
        }
}
