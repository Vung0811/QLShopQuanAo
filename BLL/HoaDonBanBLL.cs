using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class HoaDonBanBLL
    {
        HoaDonBanDAL hdbDAL = new HoaDonBanDAL();
        SanPhamBLL spBLL = new SanPhamBLL();
        PhieuDoiTraBLL pdtBLL = new PhieuDoiTraBLL();
        public List<HoaDonBan> getHoaDonBanList(KhachHang kh)
        {
            return hdbDAL.getHoaDonBanList(kh);
        }
        public bool addHoaDonBan(HoaDonBan hdb)
        {
            return hdbDAL.addHoaDonBan(hdb);
        }
        public bool delHoaDonBan(HoaDonBan hdb)
        {
            return hdbDAL.delHoaDonBan(hdb);
        }
        public HoaDonBan SetHoaDonBan(HoaDonBan hdb, NhanVien nv, KhachHang kh)
        {
            var mchnew = new String(nv.maCuaHang.Where(Char.IsLetter).ToArray());
            hdb.maHoaDon = mchnew + kh.maKhachHang + (countHoaDonBan(kh) + 1).ToString();
            hdb.maNhanVien = nv.maNhanVien;
            hdb.maKhachHang = kh.maKhachHang;
            hdb.ngayLapHoaDon = DateTime.Now;
            return hdb;
        }

        // Chi Tiết Hóa Đơn Bán
        public List<ChiTietHoaDon> getCTHDList(ChiTietHoaDon cthd)
        {
            return hdbDAL.getCTHDList(cthd);
        }

        public bool addChiTietHoaDon(ChiTietHoaDon cthd)
        {
            return hdbDAL.addChiTietHoaDon(cthd);
        }
        public bool editChiTietHoaDon(ChiTietHoaDon cthd)
        {
            return hdbDAL.editChiTietHoaDon(cthd);
        }
        public Boolean delChiTietHoaDon(ChiTietHoaDon cthd)
        {
            return hdbDAL.delChiTietHoaDon(cthd);
        }
        public int countHoaDonBan(KhachHang kh)
        {
            return hdbDAL.countHoaDonBan(kh);
        }

        public double tinhTongTien(KhachHang kh , List<HoaDonBan> hdbl, List<PhieuDoiTra> pdtl)

        {
            double tongTien = 0;
            hdbl = hdbl.Where(hd => hd.maKhachHang == kh.maKhachHang).ToList();
            foreach (var hoaDon in hdbl)
            {
                ChiTietHoaDon cthdxx = new ChiTietHoaDon();
                cthdxx.maHoaDon = hoaDon.maHoaDon;
                List<ChiTietHoaDon> cthdl = hdbDAL.getCTHDList(cthdxx);

                double tongTienHoaDon = 0;

                foreach (ChiTietHoaDon chiTiet in cthdl)
                {
                    String msp = chiTiet.maSanPhamTheoSize.Split('_')[0];
                    SanPham sanPham = spBLL.getSanPham(msp);
                    if (sanPham != null)
                    {
                        int donGia = sanPham.donGiaNiemYet;
                        double tienGiamGia = donGia * chiTiet.soLuong * chiTiet.giamGia;
                        double thanhTien = donGia * chiTiet.soLuong - tienGiamGia;
                        tongTienHoaDon += thanhTien;
                    }
                }

                var phieuDoiTra = pdtl.Where(pd => pd.maHoaDon == hoaDon.maHoaDon);

                foreach (var phieu in phieuDoiTra)
                {

                    CTPhieuDoiTra ctpdtxx = new CTPhieuDoiTra();
                    ctpdtxx.maPhieuDoiTra = phieu.maPhieuDoiTra;
                    List<CTPhieuDoiTra> ctpdtl = pdtBLL.getCTPDTList(ctpdtxx);

                    foreach (var chiTiet in ctpdtl)
                    {
                        String msp = chiTiet.maSPTheoSize.Split('_')[0];
                        var sanPham = spBLL.getSanPham(msp);
                        if (sanPham != null)
                        {
                            double giamgia = cthdl.FirstOrDefault(x => x.maSanPhamTheoSize == chiTiet.maSPTheoSize)?.giamGia ?? 0;
                            double donGia = sanPham.donGiaNiemYet;
                            double tienGiamGia = donGia * chiTiet.soLuong * giamgia;
                            double thanhTien = donGia * chiTiet.soLuong - tienGiamGia;
                            tongTienHoaDon -= thanhTien;
                        }
                    }

                    if (phieu.maXuLyDoiTra == "1")
                    {
                        foreach (var chiTiet in ctpdtl)
                        {
                            String mspRE = chiTiet.maSPTheoSizeRe.Split('_')[0];
                            var sanPhamRe = spBLL.getSanPham(mspRE);
                            if (sanPhamRe != null)
                            {
                                double giamgia = cthdl.FirstOrDefault(x => x.maSanPhamTheoSize == chiTiet.maSPTheoSize)?.giamGia ?? 0;
                                double donGia = sanPhamRe.donGiaNiemYet;
                                double tienGiamGia = donGia * chiTiet.soLuong * giamgia;
                                double thanhTien = donGia * chiTiet.soLuong - tienGiamGia;
                                tongTienHoaDon += thanhTien;
                            }
                        }
                    }
                }
                tongTien += tongTienHoaDon;
            }

            return tongTien;
        }
        public int TinhTongTien(List<ChiTietHoaDon> cthdlprivate)
        {
            int t = 0;
            foreach (ChiTietHoaDon cthd in cthdlprivate)
            {
                String msp = cthd.maSanPhamTheoSize.Split('_')[0];
                int donGia = spBLL.getSanPham(msp).donGiaNiemYet;
                t += donGia * cthd.soLuong;
            }
            return t;
        }
        public List<HoaDonBan> getHDBListTheoCH(List<NhanVien> nhanVienList, List<HoaDonBan> hdbl)
        {
            List<HoaDonBan> hdblSameStore = new List<HoaDonBan>();
            foreach (HoaDonBan hdb in hdbl)
            {
                if (nhanVienList.Any(nhanvien => nhanvien.maNhanVien == hdb.maNhanVien))
                {
                    hdblSameStore.Add(hdb);
                }
            }
            return hdblSameStore;
        }
        public List<HoaDonBan> TimKiemHDB(string tuKhoa)
        {
            return hdbDAL.TimKiemHDB(tuKhoa);
        }

    }
}