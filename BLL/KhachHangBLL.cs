using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class KhachHangBLL
    {
        KhachHangDAL khdal = new KhachHangDAL();
        public List<KhachHang> getKhachHangList(String x)
        {
            return khdal.getKhachHangList(x);
        }
        public KhachHang getKhachHang(String MaKhachHang)
        {
            return khdal.getKhachHang(MaKhachHang);
        }
        public String themKhachHang(KhachHang kh)
        {
            if (!khdal.checkKhachHangValid(kh))
            {
                if (khdal.themKH(kh))
                    return "Thêm Khách Hàng thành công !";
                else
                    return "Thêm Khách hàng thất bại !";
            }
            return "Khách Hàng đã tồn tại !!";
        }
        public String themKhachHang(String tenKhach, Boolean gioiTinh, DateTime ngaySinh, String diaChi, String SDT)
        {
            KhachHang kh = new KhachHang(tenKhach,gioiTinh,ngaySinh,diaChi,SDT);
            if (!khdal.checkKhachHangValid(kh))
            {
                if (khdal.themKH(kh))
                    return "Thêm Khách Hàng thành công !";
                else
                    return "Thêm Khách hàng thất bại !";
            }
            return "Khách Hàng đã tồn tại !!";
        }
        public Boolean checkKhachHangValid(KhachHang kh)
        {
            return khdal.checkKhachHangValid(kh);
        }
        public bool editKhachHang(KhachHang kh)
        {
            return khdal.editKhachHang(kh);
        }
        public Boolean delKhachHang(KhachHang kh)
        {
            return khdal.delKhachHang(kh);
        }
        public void SendPromotionSMS(string promotionMessage)
        { 
            khdal.SendPromotionSMS(promotionMessage);
        }

        public List<KhachHang> TimKiemKH(string tuKhoa)
        {
            return khdal.TimKiemKH(tuKhoa);
        }
      
    }
}
