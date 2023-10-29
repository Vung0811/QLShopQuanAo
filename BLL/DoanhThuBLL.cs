using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BLL
{
    public class DoanhThuBLL
    {
        HoaDonBanBLL hdbBLL = new HoaDonBanBLL();
        SanPhamBLL spBLL = new SanPhamBLL();
        PhieuDoiTraBLL pdtBLL = new PhieuDoiTraBLL();
        PhieuNhapBLL pnBLL = new PhieuNhapBLL();
        PhieuNhapKhoBLL pnkBLL = new PhieuNhapKhoBLL();
        ChiTietHoaDon cthd = new ChiTietHoaDon();
        List<ChiTietHoaDon> cthdl;
        List<CTPhieuDoiTra> ctpdtl;
        List<PhieuNhap> pnl;
        public decimal TinhTongTienTungHoaDon(HoaDonBan hdb)
        {
            String msp = "";
            int tientungSP = 0;
            decimal tongTienHoaDon = 0;

            cthd.maHoaDon = hdb.maHoaDon;
            cthdl = hdbBLL.getCTHDList(cthd);

            foreach (ChiTietHoaDon cthd in cthdl)
            {
                msp = cthd.maSanPhamTheoSize.Split('_')[0];
                tientungSP = spBLL.getSanPham(msp).donGiaNiemYet;
                tongTienHoaDon += tientungSP * cthd.soLuong;
            }
            return tongTienHoaDon;
        }
        public decimal TinhTongTienTungPDT(PhieuDoiTra pdt)
        {
            String msp = "";
            int tientungSP = 0;
            decimal tongTienPDT = 0;

            CTPhieuDoiTra ctpdt = new CTPhieuDoiTra();
            ctpdt.maPhieuDoiTra = pdt.maPhieuDoiTra;
            List<CTPhieuDoiTra> ctpdtl = pdtBLL.getCTPDTList(ctpdt);

            foreach (CTPhieuDoiTra ctdt in ctpdtl)
            {
                msp = ctdt.maSPTheoSize.Split('_')[0];
                tientungSP = spBLL.getSanPham(msp).donGiaNiemYet;
                tongTienPDT += tientungSP * ctdt.soLuong;
            }
            return tongTienPDT;
        }
        public decimal TinhTongTienTungPhieuNhap(PhieuNhap pn)
        {
            String msp = "";
            int tientungSP = 0;
            decimal tongTienPDT = 0;

            List<ChiTietPhieuNhap> ctpnl = pnBLL.getCTPhieuNhap(pn);

            foreach (ChiTietPhieuNhap ctpn in ctpnl)
            {
                msp = ctpn.maSPTheoSize.Split('_')[0];
                tientungSP = spBLL.getSanPham(msp).donGiaNiemYet;
                tongTienPDT += tientungSP * ctpn.soLuong;
            }
            return tongTienPDT;
        }

        public decimal TinhTongTienTungPhieuNhapKho(PhieuNhapKho pnk)
        {
            String msp = "";
            int tientungSP = 0;
            decimal tongTienPNK = 0;

            List<ChiTietPhieuNhapKho> ctpnkl = pnkBLL.getCTPhieuNhapKho(pnk);

            foreach (ChiTietPhieuNhapKho ctpnk in ctpnkl)
            {
                msp = ctpnk.maSPTheoSize.Split('_')[0];
                tientungSP = spBLL.getSanPham(msp).giaNhap;
                tongTienPNK += tientungSP * ctpnk.soLuong;
            }
            return tongTienPNK;
        }

        public List<Tuple<DateTime, decimal>> TongTienHDTheoNgay(List<HoaDonBan> hdbl, DateTime fromDate, DateTime toDate)
        {
            List<Tuple<DateTime, decimal>> doanhThuTheoNgay = new List<Tuple<DateTime, decimal>>();

            List<HoaDonBan> hoaDonTheoThoiGian = hdbl
                   .Where(h => h.ngayLapHoaDon.Date >= fromDate.Date && h.ngayLapHoaDon.Date <= toDate.Date)
                   .ToList();

            var hoaDonTheoNgay = hoaDonTheoThoiGian
               .GroupBy(h => h.ngayLapHoaDon.Date)
               .Select(group => new Tuple<DateTime, decimal>(
                   group.Key,
                   group.Sum(h => h.TongTien))
               )
               .OrderBy(tuple => tuple.Item1)
               .ToList();
            doanhThuTheoNgay = hoaDonTheoNgay;
            return doanhThuTheoNgay;
        }
        public List<Tuple<DateTime, decimal>> TongTienPDTTheoNgay(List<PhieuDoiTra> pdtl, DateTime fromDate, DateTime toDate)
        {
            List<Tuple<DateTime, decimal>> doanhThuTheoNgay = new List<Tuple<DateTime, decimal>>();

            List<PhieuDoiTra> PDTTheoThoiGian = pdtl
                   .Where(h => h.ngayDoiTra.Date >= fromDate.Date && h.ngayDoiTra.Date <= toDate.Date)
                   .ToList();

            var PDTTheoNgay = PDTTheoThoiGian
               .GroupBy(h => h.ngayDoiTra.Date)
               .Select(group => new Tuple<DateTime, decimal>(
                   group.Key,
                   group.Sum(h => h.TongTien))
               )
               .OrderBy(tuple => tuple.Item1)
               .ToList();
            doanhThuTheoNgay = PDTTheoNgay;
            return doanhThuTheoNgay;
        }
        public List<Tuple<DateTime, decimal>> TongTienPhieuNhap(List<PhieuNhap> pnl, DateTime fromDate, DateTime toDate)
        {
            List<Tuple<DateTime, decimal>> TienNhap = new List<Tuple<DateTime, decimal>>();

            List<PhieuNhap> PNTheoNgay = pnl
                   .Where(h => h.ngayNhap.Date >= fromDate.Date && h.ngayNhap.Date <= toDate.Date)
                   .ToList();

            var TongTienPNTheoNgay = PNTheoNgay
               .GroupBy(h => h.ngayNhap.Date)
               .Select(group => new Tuple<DateTime, decimal>(
                   group.Key,
                   group.Sum(h => h.TongTien))
               )
               .OrderBy(tuple => tuple.Item1)
               .ToList();
            TienNhap = TongTienPNTheoNgay;
            return TienNhap;
        }
        public List<Tuple<DateTime, decimal>> TongTienPhieuNhapKho(List<PhieuNhapKho> pnkl, DateTime fromDate, DateTime toDate)
        {
            List<Tuple<DateTime, decimal>> TienNhapKho = new List<Tuple<DateTime, decimal>>();

            List<PhieuNhapKho> PNKTheoNgay = pnkl
                   .Where(h => h.ngayNhap.Date >= fromDate.Date && h.ngayNhap.Date <= toDate.Date)
                   .ToList();

            var TongTienPNKTheoNgay = PNKTheoNgay
               .GroupBy(h => h.ngayNhap.Date)
               .Select(group => new Tuple<DateTime, decimal>(
                   group.Key,
                   group.Sum(h => h.TongTien))
               )
               .OrderBy(tuple => tuple.Item1)
               .ToList();
            TienNhapKho = TongTienPNKTheoNgay;
            return TienNhapKho;
        }
        public List<Tuple<String, int>> LoadSanPhamList(List<HoaDonBan> hdbl, List<PhieuDoiTra> pdtl)
        {
            List<Tuple<String, int>> SoLuongSPBanRa = new List<Tuple<String, int>>();

            foreach (HoaDonBan hdb in hdbl)
            {
                ChiTietHoaDon cthd = new ChiTietHoaDon();
                cthd.maHoaDon = hdb.maHoaDon;
                cthdl = hdbBLL.getCTHDList(cthd);

                foreach (ChiTietHoaDon x in cthdl)
                {
                    string msp = x.maSanPhamTheoSize;
                    int currentQuantity = 0;
                    Tuple<string, int> existingItem = SoLuongSPBanRa.Find(item => item.Item1 == msp);

                    if (existingItem == null)
                    {
                        SoLuongSPBanRa.Add(new Tuple<string, int>(msp, x.soLuong));
                    }
                    else
                    {
                        currentQuantity = existingItem.Item2;
                        SoLuongSPBanRa.Remove(existingItem);
                        SoLuongSPBanRa.Add(new Tuple<string, int>(msp, currentQuantity + x.soLuong));

                    }

                    foreach (PhieuDoiTra pdt in pdtl)
                    {
                        if (pdt.maHoaDon == hdb.maHoaDon)
                        {
                            CTPhieuDoiTra ctpdt1 = new CTPhieuDoiTra();
                            ctpdt1.maPhieuDoiTra = pdt.maPhieuDoiTra;
                            ctpdtl = pdtBLL.getCTPDTList(ctpdt1);
                            // Là Đổi

                            foreach (CTPhieuDoiTra ctpdtx in ctpdtl)
                            {
                                if (pdt.maXuLyDoiTra == "1")
                                {
                                    Tuple<string, int> exis = SoLuongSPBanRa.Find(item => item.Item1 == ctpdtx.maSPTheoSize);
                                    if (exis == null)
                                    {
                                        SoLuongSPBanRa.Add(new Tuple<string, int>(ctpdtx.maSPTheoSize, ctpdtx.soLuong));

                                        Tuple<string, int> exis2 = SoLuongSPBanRa.Find(item => item.Item1 == ctpdtx.maSPTheoSizeRe);
                                        if (exis2 != null)
                                        {
                                            SoLuongSPBanRa.Remove(exis2);
                                            SoLuongSPBanRa.Add(new Tuple<string, int>(exis2.Item1, exis2.Item2 - ctpdtx.soLuong));

                                        }
                                    }
                                    else
                                    {
                                        Tuple<string, int> exis3 = SoLuongSPBanRa.Find(item => item.Item1 == ctpdtx.maSPTheoSizeRe);
                                        if (exis3 != null)
                                        {
                                            SoLuongSPBanRa.Remove(exis3);
                                            SoLuongSPBanRa.Add(new Tuple<string, int>(exis3.Item1, exis3.Item2 - ctpdtx.soLuong));
                                        }
                                        Tuple<string, int> exis4 = SoLuongSPBanRa.Find(item => item.Item1 == ctpdtx.maSPTheoSize);
                                        if (exis3 != null)
                                        {
                                            SoLuongSPBanRa.Remove(exis4);
                                            SoLuongSPBanRa.Add(new Tuple<string, int>(exis4.Item1, exis4.Item2 + ctpdtx.soLuong));
                                        }
                                    }
                                }
                                else
                                {
                                    Tuple<string, int> exis5 = SoLuongSPBanRa.Find(item => item.Item1 == ctpdtx.maSPTheoSize);
                                    if (exis5 != null)
                                    {
                                        currentQuantity = exis5.Item2;
                                        SoLuongSPBanRa.Remove(exis5);
                                        SoLuongSPBanRa.Add(new Tuple<string, int>(ctpdtx.maSPTheoSize, currentQuantity - ctpdtx.soLuong));
                                    }
                                }
                            }
                        }
                    }

                }

            }
            return SoLuongSPBanRa;
        }

    }
}