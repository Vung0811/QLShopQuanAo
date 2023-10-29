using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PhieuNhapKhoBLL
    {
        PhieuNhapKhoDAL pnkDAL = new PhieuNhapKhoDAL();
        public List<PhieuNhapKho> getPhieuNhapKhoList()
        {
            return pnkDAL.getPhieuNhapKhoList();
        }

        public void ThemPhieuNhapKho(PhieuNhapKho pnk)
        {
            pnkDAL.ThemPhieuNhapKho(pnk);
        }
        public List<ChiTietPhieuNhapKho> getCTPhieuNhapKho(PhieuNhapKho pnk)
        {
            return pnkDAL.getCTPhieuNhapKho(pnk);
        }
        public void ThemCTPhieuNhapKho(ChiTietPhieuNhapKho ctpnk)
        {
            pnkDAL.ThemCTPhieuNhapKho(ctpnk);
        }
        public List<PhieuNhapKho> TimKiemPhieuNhapKho(string tuKhoa)
        {
            return pnkDAL.TimKiemPhieuNhapKho(tuKhoa);
        }
        public PhieuNhapKho getPhieuNhapKho(String maPNK)
        {
            return pnkDAL.getPhieuNhapKho(maPNK);
        }
        }
}
