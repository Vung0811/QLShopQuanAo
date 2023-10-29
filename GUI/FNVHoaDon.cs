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
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace GUI
{
    public partial class FNVHoaDon : UserControl
    {
        HoaDonBanBLL hdbBLL = new HoaDonBanBLL();
        NhanVienBLL nvBLL = new NhanVienBLL();
        KhachHangBLL khBLL = new KhachHangBLL();
        ChucVuBLL cvBLL = new ChucVuBLL();
        SanPhamBLL spbll = new SanPhamBLL();
        PhieuDoiTraBLL pdtBLL = new PhieuDoiTraBLL();

        NhanVien nv = FNhanVien.GetNhanVien();
        KhachHang kh = null;
        ChiTietHoaDon cthd = new ChiTietHoaDon();
        XuLyDoiTra xldt = new XuLyDoiTra();
        HoaDonBan hdb = null;
        CTPhieuDoiTra ctpdt = null;
        List<PhieuDoiTra> pdtl = null;
        List<CTPhieuDoiTra> ctpdtl = null;
        List<ChiTietHoaDon> cthdl = new List<ChiTietHoaDon>();
        List<ChiTietHoaDon> listtam = new List<ChiTietHoaDon>();

        double tongtien;
        public FNVHoaDon()
        {
            InitializeComponent();
            getHoaDonList(dgHDNV, kh);

        }
       
        public void getHoaDonList(DataGridView dgHDNV,  KhachHang kh)
        {
            List<HoaDonBan> hdbl = hdbBLL.getHoaDonBanList(kh);

            List<NhanVien> nhanVienList = nvBLL.getNhanVienList(nv.maCuaHang, null);
            List<HoaDonBan> hdblSameStore = hdbBLL.getHDBListTheoCH(nhanVienList, hdbl);

            dgHDNV.DataSource = hdblSameStore;
            dgHDNV.Columns["maHoaDon"].HeaderText = "Mã Hóa Đơn";
            dgHDNV.Columns["maNhanVien"].HeaderText = "Mã Nhân Viên";
            dgHDNV.Columns["maKhachHang"].HeaderText = "Mã Khách Hàng";
            dgHDNV.Columns["ngayLapHoaDon"].HeaderText = "Ngày Lập";
            dgHDNV.Columns["TongTien"].Visible = false;
        }
        public void getPDTList(DataGridView dgHDNV,HoaDonBan hdb , XuLyDoiTra xldt)
        {
           
            pdtl = pdtBLL.getPhieuDoiTraList(hdb, null);
            if(xldt.maXuLyDoiTra == "1")
            {
                pdtl = pdtl.Where(x => x.maXuLyDoiTra == "1").ToList();
            }    
            else
            {
                pdtl = pdtl.Where(x => x.maXuLyDoiTra != "1").ToList();
            }    
            dgHDNV.DataSource = pdtl;
            dgHDNV.Columns["maPhieuDoiTra"].HeaderText = "Mã Phiếu ";
            dgHDNV.Columns["maNhanVien"].HeaderText = "Mã Nhân Viên";
            dgHDNV.Columns["ngayDoiTra"].HeaderText = "Ngày Lập";
            dgHDNV.Columns["maHoaDon"].HeaderText = "Mã Hóa Đơn";

            dgHDNV.Columns["maKhachHang"].Visible = false;
            dgHDNV.Columns["maXuLyDoiTra"].Visible = false;
            dgHDNV.Columns["tongTien"].Visible = false;
        }
        public void getCTHDList(DataGridView dgCTHD, ChiTietHoaDon cthd)
        {
            cthdl = hdbBLL.getCTHDList(cthd);
            listtam = cthdl;
            dgCTHD.DataSource = cthdl;
            dgCTHD.Columns["maHoaDon"].HeaderText = "Mã Hóa Đơn";
            dgCTHD.Columns["maSanPhamTheoSize"].HeaderText = "Mã Sản Phẩm";

            dgCTHD.Columns["soLuong"].HeaderText = "Số lượng";
            dgCTHD.Columns["giamGia"].HeaderText = "Giảm Giá";
            dgCTHD.Columns["donGia"].HeaderText = "Đơn Giá";

            tongtien = 0;
            foreach (DataGridViewRow row in dgCTHD.Rows)
            {
                String mspx = row.Cells["maSanPhamTheoSize"].Value as string;
                String msp = mspx.Split('_')[0];
                int soLuong = Convert.ToInt32(row.Cells["soLuong"].Value);
                int donGia = spbll.getSanPham(msp).donGiaNiemYet;
                row.Cells["donGia"].Value = donGia;
                double giamGia = Convert.ToDouble(row.Cells["giamGia"].Value);
                tongtien += donGia * soLuong - (donGia * soLuong * giamGia);
               
            }


        }
        public void getCTPDTList(DataGridView dgCTHD, List<CTPhieuDoiTra> ctpdtl)
        {
            dgCTHD.DataSource = ctpdtl;

            dgCTHD.Columns["maPhieuDoiTra"].HeaderText = "Mã Phiếu Đổi Trả";
            dgCTHD.Columns["maSPTheoSize"].HeaderText = "Mã Sản Phẩm";

            dgCTHD.Columns["soLuong"].HeaderText = "Số lượng";
            dgCTHD.Columns["maSPTheoSizeRe"].HeaderText = "Sản Phẩm Trước Đây";
            dgCTHD.Columns["giamGia"].HeaderText = "Giảm Giá";

            tongtien = 0;

            foreach (DataGridViewRow row in dgCTHD.Rows)
            {
                String mspx = row.Cells["maSPTheoSize"].Value as string;
                String msp = mspx.Split('_')[0];
                double giamgia = 0;
                foreach (var x in listtam)
                {
                    if (x.maSanPhamTheoSize == mspx)
                        giamgia = x.giamGia;
                }
                int soLuong = Convert.ToInt32(row.Cells["soLuong"].Value);
                int donGia = spbll.getSanPham(msp).donGiaNiemYet;

                tongtien += (donGia * soLuong) - (donGia * soLuong * giamgia);
            }
        }
        private Boolean HoaDonBanValid = false;
        private void dgHDNV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgHDNV.Columns.Contains("ngayLapHoaDon"))
            {
                txtMaHD.Text = dgHDNV.SelectedRows[0].Cells["maHoaDon"].Value.ToString();

                String mnv = dgHDNV.SelectedRows[0].Cells["maNhanVien"].Value.ToString();
                NhanVien nvhd = nvBLL.getNhanVien(mnv);
                txtTenNVHD.Text = nvhd.hoNhanVien + " " + nvhd.tenNhanVien;

                String mkh = dgHDNV.SelectedRows[0].Cells["maKhachHang"].Value.ToString();
                txtTenKHHD.Text = khBLL.getKhachHang(mkh).tenKhach;

                dpHDNgay.Value = (DateTime)(dgHDNV.SelectedRows[0].Cells["ngayLapHoaDon"].Value);
                hdb = new HoaDonBan();
                hdb.maHoaDon = dgHDNV.SelectedRows[0].Cells["maHoaDon"].Value.ToString();
                HoaDonBanValid = true;
            }
            else
            {
                ctpdt = new CTPhieuDoiTra();
                ctpdt.maPhieuDoiTra = dgHDNV.SelectedRows[0].Cells["maPhieuDoiTra"].Value.ToString();
                HoaDonBanValid = false;
            }    
        }    
                

        private void btHDXem_Click(object sender, EventArgs e)
        {
            if (txtMaHD.Text == "")
            {
                lbWarningHD.Text = "Hãy chọn hóa đơn để xem !";
            }
            else
            {
               if(HoaDonBanValid)
                {
                    dgCTHD.DataSource = null;
                    cthd.maHoaDon = txtMaHD.Text;
                    getCTHDList(dgCTHD, cthd);
                    txtTongTienCTHD.Text = tongtien.ToString() + "VND";
                }    
                 else
                {
                    if(pdtBLL == null)
                    {
                        lbWarningHD.Text = "Hãy chọn Phiếu để xem Chi Tiết";
                    }    
                    else
                    {
                        lbWarningHD.Text = "";
                        dgCTHD.DataSource = null;
                        List<CTPhieuDoiTra> ctpdtl = pdtBLL.getCTPDTList(ctpdt);
                        getCTPDTList(dgCTHD, ctpdtl);
                        dgCTHD.Columns["giamGia"].Visible = false;
                        txtTongTienCTHD.Text = tongtien.ToString();
                    }    
                }    
              
            }
        }

        private void txtMaHD_TextChanged(object sender, EventArgs e)
        {
            dgCTHD.DataSource = null;
            txtTongTienCTHD.Text = "";
        }
        private void reset()
        {
            txtMaHD.Text = "";
            txtTenKHHD.Text = "";
            txtTenNVHD.Text = "";
            dpHDNgay.Value = DateTime.Now;
        }
      
        private void txtHDNVSearch_TextChanged(object sender, EventArgs e)
        {
            kh = khBLL.getKhachHang(txtHDNVSearch.Text);
            if (kh == null)
            {
                getHoaDonList(dgHDNV,kh);
                lbWarningHD.Text = "";
            }    
            else
            {
                lbWarningHD.Text = "Bạn đang tìm hóa đơn của " + kh.tenKhach;
                getHoaDonList(dgHDNV,kh);
            }    

        }

        private void btXemPhieuDoi_Click(object sender, EventArgs e)
        {
            if (txtMaHD.Text == "")
            {
                lbWarningHD.Text = "Hãy chọn hóa đơn để xem !";
            }
            else
            {
                lbWarningHD.Text = "";
                xldt.maXuLyDoiTra = "1";
                dgHDNV.DataSource = null;
                dgCTHD.DataSource = null;
                getPDTList(dgHDNV, hdb, xldt);
                txtTongTienCTHD.Text = "";
               
            }
        }

        private void btXemHoaDon_Click(object sender, EventArgs e)
        {
            dgHDNV.DataSource = null;
            getHoaDonList(dgHDNV, kh);
            dgCTHD.DataSource = null;
            txtTongTienCTHD.Text = "";
        }

        private void btXemPhieuTra_Click(object sender, EventArgs e)
        {
            if (txtMaHD.Text == "")
            {
                lbWarningHD.Text = "Hãy chọn hóa đơn để xem !";
            }
            else
            {
                lbWarningHD.Text = "";
                txtTongTienCTHD.Text = "";
                dgHDNV.DataSource = null;
                xldt.maXuLyDoiTra = "2";
                dgCTHD.DataSource = null;
                getPDTList(dgHDNV, hdb, xldt);
               
            }
        }


    }
}