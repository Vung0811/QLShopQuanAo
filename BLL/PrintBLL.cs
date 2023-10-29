using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Printing;

namespace BLL
{
    public class PrintBLL
    {
        double tongTien = 0;
        double tongTienRe = 0;
        SanPhamBLL spBLL = new SanPhamBLL();
        private void DauHoaDon(PrintPageEventArgs e, String x, CuaHang ch, NhanVien nv, KhachHang kh)
        {
            e.Graphics.DrawString(ch.tenCuaHang, new System.Drawing.Font("Ariel", 20, FontStyle.Bold), Brushes.DarkRed, new Point(20, 10));
            e.Graphics.DrawString(x, new System.Drawing.Font("Ariel", 16, FontStyle.Bold), Brushes.Black, new Point(360, 40));
            e.Graphics.DrawString("______________________________________________________________________________________", new System.Drawing.Font("Ariel", 16, FontStyle.Bold), Brushes.Black, new Point(0, 60));
            e.Graphics.DrawString("Ngày :" + DateTime.Now.ToShortDateString(), new System.Drawing.Font("Ariel", 12, FontStyle.Regular), Brushes.Black, new Point(30, 90));
            e.Graphics.DrawString("Nhân Viên:" + nv.tenNhanVien, new System.Drawing.Font("Ariel", 12, FontStyle.Regular), Brushes.Black, new Point(30, 120));
            e.Graphics.DrawString("Khách hàng:" + kh.tenKhach, new System.Drawing.Font("Ariel", 12, FontStyle.Regular), Brushes.Black, new Point(230, 120));
            e.Graphics.DrawString("Số điện thoại:" + kh.soDienThoai, new System.Drawing.Font("Ariel", 12, FontStyle.Regular), Brushes.Black, new Point(600, 120));
            e.Graphics.DrawString(".......................................................................................", new System.Drawing.Font("Ariel", 16, FontStyle.Bold), Brushes.Black, new Point(100, 160));

        }
        private void ThanHoaDonTaoBang(PrintPageEventArgs e, int columnWidth, int i)
        {
            // Vẽ header cho bảng
            e.Graphics.DrawString("Mã Sản Phẩm", new System.Drawing.Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(20, 190));
            e.Graphics.DrawString("Tên SP", new System.Drawing.Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(columnWidth, 190));
            e.Graphics.DrawString("Số Lượng", new System.Drawing.Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(60 + 2 * columnWidth, 190));
            if (i == 1)
            {
                e.Graphics.DrawString("Giá Tiền", new System.Drawing.Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(20 + 3 * columnWidth, 190));
                e.Graphics.DrawString("Giảm giá", new System.Drawing.Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(20 + 4 * columnWidth, 190));
                e.Graphics.DrawString("Thành Tiền", new System.Drawing.Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(20 + 5 * columnWidth, 190));
            }
            else
            {
                e.Graphics.DrawString("Giá Tiền", new System.Drawing.Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(20 + 3 * columnWidth, 190));
                e.Graphics.DrawString("Thành Tiền", new System.Drawing.Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(20 + 4 * columnWidth, 190));
                e.Graphics.DrawString("SP bị đổi", new System.Drawing.Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(20 + 5 * columnWidth, 190));
            }
        }
        private void ThanPhieuDoiTra(PrintPageEventArgs e, List<CTPhieuDoiTra> ctpdtl)
        {
            // Định nghĩa kích thước hàng
            int rowHeight = 30;
            int columnWidth = 140;
            ThanHoaDonTaoBang(e, columnWidth, 0);
            // Vẽ dữ liệu sản phẩm
            int startY = 210;

            String mhd = "";
            foreach (var cthd in ctpdtl)
            {
                mhd = cthd.maPhieuDoiTra;
                String msp = cthd.maSPTheoSize.Split('_')[0];
                String mspRe = cthd.maSPTheoSizeRe.Split('_')[0];
                SanPham sp = spBLL.getSanPham(msp);
                SanPham spr = spBLL.getSanPham(mspRe);
                int donGia = sp.donGiaNiemYet;
                int donGiaRe = spr.donGiaNiemYet;
                double giamGia = cthd.giamGia;
                double thanhTien = donGia * cthd.soLuong - (donGia * cthd.soLuong * giamGia);
                double thanhTienRe = donGiaRe * cthd.soLuong - (donGiaRe * cthd.soLuong * giamGia);
                tongTien += thanhTien;
                tongTienRe += thanhTienRe;
                e.Graphics.DrawString(cthd.maSPTheoSize, new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(20, startY));
                e.Graphics.DrawString(sp.tenSanPham, new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(columnWidth, startY));
                e.Graphics.DrawString(cthd.soLuong.ToString(), new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(60 + 2 * columnWidth, startY));
                e.Graphics.DrawString(donGia.ToString(), new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(20 + 3 * columnWidth, startY));
                e.Graphics.DrawString(thanhTien.ToString(), new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(20 + 4 * columnWidth, startY));
                e.Graphics.DrawString(cthd.maSPTheoSizeRe.ToString(), new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(20 + 5 * columnWidth, startY));
                startY += rowHeight;
            }
            e.Graphics.DrawString("Mã Hóa Đơn :" + mhd, new System.Drawing.Font("Ariel", 12, FontStyle.Regular), Brushes.Black, new Point(230, 90));
            // Vẽ các dòng cách nhau
            e.Graphics.DrawString(".......................................................................................", new System.Drawing.Font("Ariel", 16, FontStyle.Bold), Brushes.Black, new Point(2 * columnWidth, startY + 30));

            // Vẽ tổng tiền
            e.Graphics.DrawString("Tổng Tiền :" + string.Format("{0:#,0}", tongTien) + " VNĐ", new System.Drawing.Font("Ariel", 12, FontStyle.Regular), Brushes.Black, new Point(20 + 3 * columnWidth, startY + 60));
            
        }
        public void VeHoaDon(NhanVien nv, CuaHang ch, List<ChiTietHoaDon> cthdl, PrintPageEventArgs e, KhachHang kh)
        {
            DauHoaDon(e, "HÓA ĐƠN BÁN", ch, nv,kh);

            // Định nghĩa kích thước hàng
            int rowHeight = 30;
            int columnWidth = 140;
            ThanHoaDonTaoBang(e, columnWidth, 1);

            // Vẽ dữ liệu sản phẩm
            int startY = 210;
            double tongTien = 0;
            String mhd = "";
            foreach (var cthd in cthdl)
            {
                mhd = cthd.maHoaDon;
                String msp = cthd.maSanPhamTheoSize.Split('_')[0];
                SanPham sp = spBLL.getSanPham(msp);
                int donGia = sp.donGiaNiemYet;
                double giamGia = cthd.giamGia;
                double thanhTien = donGia * cthd.soLuong - (donGia * cthd.soLuong * giamGia);
                tongTien += thanhTien;
                e.Graphics.DrawString(cthd.maSanPhamTheoSize, new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(20, startY));
                e.Graphics.DrawString(sp.tenSanPham, new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(columnWidth, startY));
                e.Graphics.DrawString(cthd.soLuong.ToString(), new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(60 + 2 * columnWidth, startY));
                e.Graphics.DrawString(donGia.ToString(), new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(20 + 3 * columnWidth, startY));
                e.Graphics.DrawString(giamGia.ToString(), new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(20 + 4 * columnWidth, startY));
                e.Graphics.DrawString(thanhTien.ToString(), new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(20 + 5 * columnWidth, startY));

                startY += rowHeight;
            }
            e.Graphics.DrawString("Mã Hóa Đơn :" + mhd, new System.Drawing.Font("Ariel", 12, FontStyle.Regular), Brushes.Black, new Point(230, 90));
            // Vẽ các dòng cách nhau
            e.Graphics.DrawString(".......................................................................................", new System.Drawing.Font("Ariel", 16, FontStyle.Bold), Brushes.Black, new Point(2 * columnWidth, startY + 30));

            // Vẽ tổng tiền
            e.Graphics.DrawString("Tổng Tiền :" + string.Format("{0:#,0}", tongTien) + " VNĐ", new System.Drawing.Font("Ariel", 12, FontStyle.Regular), Brushes.Black, new Point(20 + 3 * columnWidth, startY + 60));
        }
        public void VePhieuDoi(NhanVien nv, CuaHang ch, List<CTPhieuDoiTra> ctpdtl, PrintPageEventArgs e, KhachHang kh)
        {
            int startY = 210;

            int columnWidth = 140;
            DauHoaDon(e, "PHIẾU ĐỔI HÀNG", ch, nv, kh);
            ThanPhieuDoiTra(e, ctpdtl);
            if (tongTien - tongTienRe > 0)
            {
                
                e.Graphics.DrawString("Tổng Tiền khách trả:" + string.Format("{0:#,0}" + " VNĐ", (tongTien - tongTienRe)), new System.Drawing.Font("Ariel", 12, FontStyle.Regular), Brushes.Black, new Point(20 + 3 * columnWidth, startY + 150));
            }
            else
            {
                e.Graphics.DrawString("Tổng Tiền cửa hàng trả:" + string.Format("{0:#,0}" + " VNĐ", ((tongTien - tongTienRe)) *-1).ToString(), new System.Drawing.Font("Ariel", 12, FontStyle.Regular), Brushes.Black, new Point(20 + 3 * columnWidth, startY + 150));

            }
        }
         public void VePhieuTra(NhanVien nv, CuaHang ch, List<CTPhieuDoiTra> ctpdtl, PrintPageEventArgs e, KhachHang kh)

        {
            int startY = 210;

            int columnWidth = 140;
            DauHoaDon(e, "PHIẾU TRẢ HÀNG", ch, nv, kh);
            ThanPhieuDoiTra(e, ctpdtl);
            e.Graphics.DrawString("Tổng Tiền cửa hàng trả:" + string.Format("{0:#,0}", tongTien)+ " VNĐ", new System.Drawing.Font("Ariel", 12, FontStyle.Regular), Brushes.Black, new Point(20 + 3 * columnWidth, startY +150));
        }
        public void VePhieuNhap(NhanVien nv, CuaHang ch, List<ChiTietPhieuNhap> pnl, PrintPageEventArgs e)
        {
                int startY = 210;

                int columnWidth = 140;
                e.Graphics.DrawString(ch.tenCuaHang, new System.Drawing.Font("Ariel", 20, FontStyle.Bold), Brushes.DarkRed, new Point(20, 10));
                e.Graphics.DrawString("Phiếu Nhập Hàng", new System.Drawing.Font("Ariel", 16, FontStyle.Bold), Brushes.Black, new Point(360, 40));
                e.Graphics.DrawString("______________________________________________________________________________________", new System.Drawing.Font("Ariel", 16, FontStyle.Bold), Brushes.Black, new Point(0, 60));
                e.Graphics.DrawString("Ngày :" + DateTime.Now.ToShortDateString(), new System.Drawing.Font("Ariel", 12, FontStyle.Regular), Brushes.Black, new Point(30, 90));
                e.Graphics.DrawString("Nhân Viên:" + nv.tenNhanVien, new System.Drawing.Font("Ariel", 12, FontStyle.Regular), Brushes.Black, new Point(30, 120));
                e.Graphics.DrawString("Số điện thoại:" + nv.soDienThoai, new System.Drawing.Font("Ariel", 12, FontStyle.Regular), Brushes.Black, new Point(450, 120));
                e.Graphics.DrawString(".......................................................................................", new System.Drawing.Font("Ariel", 16, FontStyle.Bold), Brushes.Black, new Point(100, 160));
                // Định nghĩa kích thước hàng
                int rowHeight = 30;
                ThanHoaDonTaoBang(e, columnWidth, 1);

                double tongTien = 0;
                String mhd = "";

                foreach (var pn in pnl)
                {
                    mhd = pn.maPhieuNhap;
                    String msp = pn.maSPTheoSize.Split('_')[0];
                    SanPham sp = spBLL.getSanPham(msp);
                    int donGia = sp.donGiaNiemYet;

                    double thanhTien = donGia * pn.soLuong;
                    tongTien += thanhTien;
                    e.Graphics.DrawString(pn.maSPTheoSize, new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(20, startY));
                    e.Graphics.DrawString(sp.tenSanPham, new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point( columnWidth, startY));
                    e.Graphics.DrawString(pn.soLuong.ToString(), new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(60 + 2 * columnWidth, startY));
                    e.Graphics.DrawString(donGia.ToString(), new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(20 + 3 * columnWidth, startY));
                    e.Graphics.DrawString("None", new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(20 + 4 * columnWidth, startY));
                    e.Graphics.DrawString(thanhTien.ToString(), new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(20 + 5 * columnWidth, startY));

                    startY += rowHeight;
                }
                e.Graphics.DrawString("Mã Phiếu Nhập :" + mhd, new System.Drawing.Font("Ariel", 12, FontStyle.Regular), Brushes.Black, new Point(230, 90));
                // Vẽ các dòng cách nhau
                e.Graphics.DrawString(".......................................................................................", new System.Drawing.Font("Ariel", 16, FontStyle.Bold), Brushes.Black, new Point(2 * columnWidth, startY + 30));
            
                // Vẽ tổng tiền
                e.Graphics.DrawString("Tổng Tiền :" + string.Format("{0:#,0}", tongTien) + " VNĐ", new System.Drawing.Font("Ariel", 12, FontStyle.Regular), Brushes.Black, new Point(20 + 3 * columnWidth, startY + 60));
            }
    }
}
