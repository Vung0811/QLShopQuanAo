using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class NhaSanXuatBLL
    {
        NhaSanXuatDAL nsxDAL = new NhaSanXuatDAL();

        public List<NhaSanXuat> getNhaSX()
        {
            return nsxDAL.getNhaSX();
        }
        public void ThemNSX(NhaSanXuat nsx)
        {
            nsxDAL.ThemNSX(nsx);
        }
        public void SuaNSX(NhaSanXuat nsx)
        {
            nsxDAL.SuaNSX(nsx);
        }
        public void XoaNSX(string maNSX)
        {
            nsxDAL.XoaNSX(maNSX);
        }
        public List<NhaSanXuat> TimKiemNSX(string tuKhoa)
        {
            return nsxDAL.TimKiemNSX(tuKhoa);
        }
        public bool IsForeignKeyInOtherTables(string MaNSX)
        {
            return nsxDAL.IsForeignKeyInOtherTables(MaNSX);
        }
        }
}
