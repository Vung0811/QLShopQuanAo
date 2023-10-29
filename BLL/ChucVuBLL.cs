using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ChucVuBLL
    {
        ChucVuDAL cvDAL = new ChucVuDAL();


        public List<ChucVu> GetChucVu()
        {
            return cvDAL.getChucVu();
        }
        public ChucVu getChucVuCuaNV(NhanVien nv)
        {
            return cvDAL.getChucVuCuaNV(nv);
        }
    }
}
