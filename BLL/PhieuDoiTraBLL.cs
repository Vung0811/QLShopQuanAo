using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PhieuDoiTraBLL
    {
        PhieuDoiTraDAL pdtDAL = new PhieuDoiTraDAL();
        public int coutPhieuDoiTra(KhachHang kh, String mxl)
        {
            return pdtDAL.coutPhieuDoiTra(kh, mxl);
        }
        public List<PhieuDoiTra> getPhieuDoiTraList(HoaDonBan hdb, XuLyDoiTra xldt)
        {
            return pdtDAL.getPhieuDoiTraList(hdb, xldt);
        }
        public bool addPhieuDoiTra(PhieuDoiTra pdt)
        {
            return pdtDAL.addPhieuDoiTra(pdt);
        }

        public Boolean delPhieuDoiTra(PhieuDoiTra pdt)
        {
            return pdtDAL.delPhieuDoiTra(pdt);
        }

        public List<PhieuDoiTra> getPDTListTheoCH(List<NhanVien> nhanVienList, List<PhieuDoiTra> pdtl)
        {
            List<PhieuDoiTra> pdtlSameStore = new List<PhieuDoiTra>();
            foreach (PhieuDoiTra pdt in pdtl)
            {
                if (nhanVienList.Any(nhanvien => nhanvien.maNhanVien == pdt.maNhanVien))
                {
                    pdtlSameStore.Add(pdt);
                }
            }
            return pdtlSameStore;
        }
        // Chi Tiết Phiếu Đổi Trả
        public List<CTPhieuDoiTra> getCTPDTList(CTPhieuDoiTra ctpdt)
        {
            return pdtDAL.getCTPDTList(ctpdt);
        }
        public bool addCTPhieuDoiTra(CTPhieuDoiTra ctpdt)
        {
            return pdtDAL.addCTPhieuDoiTra(ctpdt);
        }
        public List<PhieuDoiTra> TimKiemPDT(string tuKhoa)
        {
            return pdtDAL.TimKiemPDT(tuKhoa);
        }
        }
}
