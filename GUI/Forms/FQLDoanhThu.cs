using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Management;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GUI.Forms
{
    public partial class FQLDoanhThu : Form
    {
        HoaDonBanBLL hdbBLL = new HoaDonBanBLL();
        DoanhThuBLL dtBLL = new DoanhThuBLL();
        NhanVienBLL nvBLL = new NhanVienBLL();
        PhieuDoiTraBLL pdtBLL = new PhieuDoiTraBLL();
        PhieuNhapBLL pnBLL = new PhieuNhapBLL();
        PhieuNhapKhoBLL pnkBLL = new PhieuNhapKhoBLL();
        XuLyDoiTra xldt = new XuLyDoiTra();
        SanPhamBLL spBLL = new SanPhamBLL();
        KhachHang kh = null;
        NhanVien nv = null;

        List<HoaDonBan> hdbl;
        List<PhieuDoiTra> pdl;
        List<PhieuDoiTra> ptl;
        List<PhieuDoiTra> pdtl;
        List<PhieuNhap> pnl;
        List<PhieuNhapKho> pnkl;
        List<Tuple<DateTime, decimal>> doanhThuTheoNgay = null;
        List<Tuple<DateTime, decimal>> phieuDoiTheoNgay = null;
        List<Tuple<DateTime, decimal>> phieuTraTheoNgay = null;
        List<Tuple<DateTime, decimal>> phieuNhapTheoNgay = null;
        public FQLDoanhThu()
        {
            InitializeComponent();
            comboBoxChucVu();
            loadCbMaCuaHang();
        }

        private void setColumnBieuDo(String x, Color y, List<Tuple<DateTime, decimal>> z)
        {
            if (z != null)
            {
                Series hdcolumn = new Series(x);
                hdcolumn.ChartType = SeriesChartType.Column;
                hdcolumn.Color = y;
                chartDoanhThu.Series.Add(hdcolumn);

                foreach (var dataPoint in z)
                {
                    DateTime ngay = dataPoint.Item1;
                    decimal tongTien = dataPoint.Item2;

                    chartDoanhThu.Series[x].Points.AddXY(ngay, (double)tongTien);
                }
            }
        }
        private void SetBieuDo(List<Tuple<DateTime, decimal>> doanhThuTheoNgay, List<Tuple<DateTime,
            decimal>> phieuDoiTheoNgay, List<Tuple<DateTime, decimal>> phieuTraTheoNgay)
        {
            chartDoanhThu.Series.Clear();
            chartDoanhThu.Titles.Clear();
            // Thêm loạt dữ liệu mới với kiểu biểu đồ đường

            createBieuDo();
            setColumnBieuDo("HoaDon", Color.Blue, doanhThuTheoNgay);
            setColumnBieuDo("PhieuDoi", Color.Orange, phieuDoiTheoNgay);
            setColumnBieuDo("PhieuTra", Color.Red, phieuTraTheoNgay);

        }
        private void createBieuDo()
        {
            chartDoanhThu.Series.Clear();
            chartDoanhThu.Titles.Clear();
            // Thêm loạt dữ liệu mới với kiểu biểu đồ đường

            chartDoanhThu.Titles.Add("Biểu đồ doanh thu theo ngày");


            chartDoanhThu.ChartAreas[0].AxisY.Title = "Giá trị (VNĐ)";
            chartDoanhThu.ChartAreas[0].AxisX.Title = "Ngày";
            chartDoanhThu.ChartAreas[0].AxisX.LabelStyle.Format = "dd/MM/yyyy";
            chartDoanhThu.ChartAreas[0].AxisX.Interval = 1;
            chartDoanhThu.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Days;
        }
        private void btThongKe_Click(object sender, EventArgs e)
        {
            
            DateTime fromDate = dpFromDate.Value;
            DateTime toDate = dpToDate.Value;

            if (toDate > DateTime.Now)
            {
                lbWarningDT.Text = "Không thể vượt quá thời gian hiện tại !";
                return;
            }
            if (fromDate > toDate)
            {
                lbWarningDT.Text = " Ngày Bắt đầu không thể lớn hơn !";

            }  
            else
            {
                lbWarningDT.Text = " ";
                doanhThuTheoNgay = dtBLL.TongTienHDTheoNgay(hdbl, fromDate, toDate);
                phieuDoiTheoNgay = dtBLL.TongTienPDTTheoNgay(pdl, fromDate, toDate);
                phieuTraTheoNgay = dtBLL.TongTienPDTTheoNgay(ptl, fromDate, toDate);
                SetBieuDo(doanhThuTheoNgay, phieuDoiTheoNgay, phieuTraTheoNgay);

                List<HoaDonBan> hdbTheoNgay = hdbl
                  .Where(h => h.ngayLapHoaDon.Date >= fromDate.Date && h.ngayLapHoaDon.Date <= toDate.Date)
                  .ToList();
                List<PhieuDoiTra> pdtTheoNgay = pdtl
                  .Where(h => h.ngayDoiTra.Date >= fromDate.Date && h.ngayDoiTra.Date <= toDate.Date)
                  .ToList();

                PieSanPhamCharts(hdbTheoNgay, pdtTheoNgay, null);
            }

        }

        private void btHoaDon_Click(object sender, EventArgs e)
        {
            DateTime fromDate = dpFromDate.Value;
            DateTime toDate = dpToDate.Value;

            if (toDate > DateTime.Now)
            {
                lbWarningDT.Text = "Không thể vượt quá thời gian hiện tại !";
                return;
            }
            if (fromDate > toDate)
            {
                lbWarningDT.Text = " Ngày Bắt đầu không thể lớn hơn !";
                return;
            }
            else
            {
                lbWarningDT.Text = " ";
                doanhThuTheoNgay = dtBLL.TongTienHDTheoNgay(hdbl, fromDate, toDate);
                SetBieuDo(doanhThuTheoNgay, null, null);
            }
        }

        private void btPhieuDoi_Click(object sender, EventArgs e)
        {
            DateTime fromDate = dpFromDate.Value;
            DateTime toDate = dpToDate.Value;

            if (toDate > DateTime.Now)
            {
                lbWarningDT.Text = "Không thể vượt quá thời gian hiện tại !";
                return;
            }
            if (fromDate > toDate)
            {
                lbWarningDT.Text = " Ngày Bắt đầu không thể lớn hơn !";
                return;
            }
            else
            {
                lbWarningDT.Text = " ";
                phieuDoiTheoNgay = dtBLL.TongTienPDTTheoNgay(pdl, fromDate, toDate);
                SetBieuDo(null, phieuDoiTheoNgay, null);
            }
        }

        private void btPhieuTra_Click(object sender, EventArgs e)
        {
            DateTime fromDate = dpFromDate.Value;
            DateTime toDate = dpToDate.Value;

            if (toDate > DateTime.Now)
            {
                lbWarningDT.Text = "Không thể vượt quá thời gian hiện tại !";
                return;
            }
            if (fromDate > toDate)
            {
                lbWarningDT.Text = " Ngày Bắt đầu không thể lớn hơn !";
                return;
            }
            else
            {
                lbWarningDT.Text = " ";
                phieuTraTheoNgay = dtBLL.TongTienPDTTheoNgay(ptl, fromDate, toDate);
                SetBieuDo(null, null, phieuTraTheoNgay);
            }
        }

        

        private void btTienLoi_Click(object sender, EventArgs e)
        {
            DateTime fromDate = dpFromDate.Value;
            DateTime toDate = dpToDate.Value;

            if (toDate > DateTime.Now)
            {
                lbWarningDT.Text = "Không thể vượt quá thời gian hiện tại !";
                return;
            }
            if (fromDate > toDate)
            {
                lbWarningDT.Text = " Ngày Bắt đầu không thể lớn hơn !";
                return;
            }
            else
            {
                List<Tuple<DateTime, decimal>> DSLoiNhuanTheoNgay = new List<Tuple<DateTime, decimal>>();

                List<HoaDonBan> hdbTheoNgay = hdbl
                  .Where(h => h.ngayLapHoaDon.Date >= fromDate.Date && h.ngayLapHoaDon.Date <= toDate.Date)
                  .ToList();
                List<PhieuDoiTra> pdtTheoNgay = pdtl
                  .Where(h => h.ngayDoiTra.Date >= fromDate.Date && h.ngayDoiTra.Date <= toDate.Date)
                  .ToList();

                decimal tongTienSP = 0;
                decimal tongTienHD = 0;
                foreach (var item in dtBLL.LoadSanPhamList(hdbTheoNgay, pdtTheoNgay))
                {
                    int soLuong = item.Item2;
                    String msp = item.Item1.Split('_')[0];
                    decimal donGia = spBLL.getSanPham(msp).donGiaNiemYet;
                    tongTienSP = donGia * soLuong;
                    tongTienHD += tongTienSP;
                }
                DSLoiNhuanTheoNgay.Add(new Tuple<DateTime, decimal>(toDate.Date, tongTienHD));
                createBieuDo();
                setColumnBieuDo("Thu Nhap", Color.Purple, DSLoiNhuanTheoNgay);

            }
        }
        //=============================Pie Chart==================================

        private void comboBoxChucVu()
        {
            List<SanPham> SanPhamList = spBLL.LoadDlSanPham();

            cbChonSP.DataSource = SanPhamList;
            cbChonSP.ValueMember = "maSanPham";
            cbChonSP.DisplayMember = "tenSanPham";

        }
        private void PieSanPhamCharts(List<HoaDonBan> hdbTheoNgay, List<PhieuDoiTra> pdtTheoNgay, String msp)
        {
            chartSanPham.Series.Clear();
            chartSanPham.Titles.Clear();
            // Thêm loạt dữ liệu mới với kiểu biểu đồ đường

            chartSanPham.Titles.Add("Biểu đồ Sản Phẩm Bán Ra");
            Series series = new Series("SanPham");
            series.ChartType = SeriesChartType.Pie;
            chartSanPham.Series.Add(series);
            List<Tuple<String, int>> spbr = dtBLL.LoadSanPhamList(hdbTheoNgay, pdtTheoNgay);
            if (msp == null)
            {
                foreach (var item in spbr)
                {
                    chartSanPham.Series["SanPham"].Points.AddXY(item.Item1, item.Item2);
                }
            }
            else
            {
                int i = spbr.Where(x => x.Item1.Split('_')[0] == msp).Sum(x => x.Item2);
                int j = spbr.Sum(x => x.Item2);


                chartSanPham.Series["SanPham"].Points.AddXY(cbChonSP.SelectedValue.ToString(), i);
                chartSanPham.Series["SanPham"].Points.AddXY("Sản phẩm khác", j - i);
            }
        }

        private void btLoc_DT_Click(object sender, EventArgs e)
        {
            DateTime fromDate = dpFromDate.Value;
            DateTime toDate = dpToDate.Value;

            if (toDate > DateTime.Now)
            {
                lbWarningDT.Text = "Không thể vượt quá thời gian hiện tại !";
                return;
            }
            if (fromDate > toDate)
            {
                lbWarningDT.Text = " Ngày Bắt đầu không thể lớn hơn !";
                return;
            }
            else
            {
                List<HoaDonBan> hdbTheoNgay = hdbl
                  .Where(h => h.ngayLapHoaDon.Date >= fromDate.Date && h.ngayLapHoaDon.Date <= toDate.Date)
                  .ToList();
                List<PhieuDoiTra> pdtTheoNgay = pdtl
                  .Where(h => h.ngayDoiTra.Date >= fromDate.Date && h.ngayDoiTra.Date <= toDate.Date)
                  .ToList();

                PieSanPhamCharts(hdbTheoNgay, pdtTheoNgay, cbChonSP.SelectedValue.ToString());

            }
        }

        private void btPhieuNhap_Click(object sender, EventArgs e)
        {
            DateTime fromDate = dpFromDate.Value;
            DateTime toDate = dpToDate.Value;

            if (toDate > DateTime.Now)
            {
                lbWarningDT.Text = "Không thể vượt quá thời gian hiện tại !";
                return;
            }
            if (fromDate > toDate)
            {
                lbWarningDT.Text = " Ngày Bắt đầu không thể lớn hơn !";
                return;
            }
            else
            {
                lbWarningDT.Text = " ";
                pnl = pnl.Where(x => x.trangThai == true).ToList();
                List<Tuple<DateTime, decimal>> tinhDoanhThu = dtBLL.TongTienPhieuNhap(pnl, fromDate, toDate);

                createBieuDo();
                setColumnBieuDo("PhieuNhap", Color.Green, tinhDoanhThu);

            }
        }

        private void btnPhieuNhapKho_Click(object sender, EventArgs e)
        {
            DateTime fromDate = dpFromDate.Value;
            DateTime toDate = dpToDate.Value;

            if (toDate > DateTime.Now)
            {
                lbWarningDT.Text = "Không thể vượt quá thời gian hiện tại !";
                return;
            }
            if (fromDate > toDate)
            {
                lbWarningDT.Text = " Ngày Bắt đầu không thể lớn hơn !";
                return;
            }
            else
            {
                lbWarningDT.Text = " ";
                List<Tuple<DateTime, decimal>> tinhTongPhieuNhapKho = dtBLL.TongTienPhieuNhapKho(pnkl, fromDate, toDate);

                createBieuDo();
                setColumnBieuDo("PhieuNhapKho", Color.Green, tinhTongPhieuNhapKho);

            }
        }

        private void loadCbMaCuaHang()
        {
            BLL.CuaHangBLL chBLL = new BLL.CuaHangBLL();
            List<CuaHang> cuaHang = chBLL.getCuaHangList();

            // Xóa tất cả các mục hiện tại trong ComboBox (nếu có)
            cbCuaHang.Items.Clear();

            // Thêm danh sách "maNSX" vào ComboBox
            foreach (CuaHang ch in cuaHang)
            {
                cbCuaHang.Items.Add(ch.maCuaHang);

            }
        }

        private void btnLocDTCH_Click(object sender, EventArgs e)
        {
            DateTime fromDate = dpFromDate.Value;
            DateTime toDate = dpToDate.Value;

            if (toDate > DateTime.Now)
            {
                lbWarningDT.Text = "Không thể vượt quá thời gian hiện tại !";
                return;
            }
            if (fromDate > toDate)
            {
                lbWarningDT.Text = " Ngày Bắt đầu không thể lớn hơn !";
                return;
            }

            if (cbCuaHang.Text == "")
            {
                hdbl = hdbBLL.getHoaDonBanList(kh);


                xldt.maXuLyDoiTra = "1";
                pdl = new List<PhieuDoiTra>();
                pdl = pdtBLL.getPhieuDoiTraList(null, xldt);


                xldt.maXuLyDoiTra = "2";
                ptl = new List<PhieuDoiTra>();
                ptl = pdtBLL.getPhieuDoiTraList(null, xldt);

                pdtl = pdtBLL.getPhieuDoiTraList(null, null);

                pnl = pnBLL.getPhieuNhapList(nv);
                pnkl = pnkBLL.getPhieuNhapKhoList();

                foreach (HoaDonBan hdb in hdbl)
                {
                    hdb.TongTien = dtBLL.TinhTongTienTungHoaDon(hdb);
                }
                foreach (PhieuDoiTra pdt in pdl)
                {
                    pdt.TongTien = dtBLL.TinhTongTienTungPDT(pdt);
                }
                foreach (PhieuDoiTra pdt in ptl)
                {
                    pdt.TongTien = dtBLL.TinhTongTienTungPDT(pdt);
                }
                foreach (PhieuNhap pn in pnl)
                {
                    pn.TongTien = dtBLL.TinhTongTienTungPhieuNhap(pn);
                }
                foreach (PhieuNhapKho pnk in pnkl)
                {
                    pnk.TongTien = dtBLL.TinhTongTienTungPhieuNhapKho(pnk);
                }
            }
            else
            {
                List<NhanVien> nhanVienList = nvBLL.getNhanVienList(cbCuaHang.Text, null);
                hdbl = hdbBLL.getHDBListTheoCH(nhanVienList, hdbBLL.getHoaDonBanList(null));


                xldt.maXuLyDoiTra = "1";
                pdl = new List<PhieuDoiTra>();
                pdl = pdtBLL.getPDTListTheoCH(nhanVienList, pdtBLL.getPhieuDoiTraList(null, xldt));


                xldt.maXuLyDoiTra = "2";
                ptl = new List<PhieuDoiTra>();
                ptl = pdtBLL.getPDTListTheoCH(nhanVienList, pdtBLL.getPhieuDoiTraList(null, xldt));

                pdtl = pdtBLL.getPDTListTheoCH(nhanVienList, pdtBLL.getPhieuDoiTraList(null, null));
                nv = new NhanVien();
                nv.maCuaHang = cbCuaHang.Text;
                pnl = pnBLL.getPhieuNhapList(nv);

                foreach (HoaDonBan hdb in hdbl)
                {
                    hdb.TongTien = dtBLL.TinhTongTienTungHoaDon(hdb);
                }
                foreach (PhieuDoiTra pdt in pdl)
                {
                    pdt.TongTien = dtBLL.TinhTongTienTungPDT(pdt);
                }
                foreach (PhieuDoiTra pdt in ptl)
                {
                    pdt.TongTien = dtBLL.TinhTongTienTungPDT(pdt);
                }
                foreach (PhieuNhap pn in pnl)
                {
                    pn.TongTien = dtBLL.TinhTongTienTungPhieuNhap(pn);
                }
            }
        }
    }
}
