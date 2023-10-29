using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Runtime.InteropServices;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Drawing.Printing;
using System.Windows.Forms.DataVisualization.Charting;

namespace GUI
{
    public partial class FNVKhachHang : UserControl
    {
        KhachHangBLL khbll = new KhachHangBLL();
        HoaDonBanBLL hdbBLL = new HoaDonBanBLL();
        SanPham_CuaHangBLL spchBLL = new SanPham_CuaHangBLL();
        SanPhamBLL spBLL = new SanPhamBLL();
        MaSanPhamTheoSizeBLL sptsBLL = new MaSanPhamTheoSizeBLL();
        ChucVuBLL cvBLL = new ChucVuBLL();
        PhieuDoiTraBLL pdtBLL = new PhieuDoiTraBLL();
        NhanVienBLL nvBLL = new NhanVienBLL();
        CuaHangBLL chBLL = new CuaHangBLL();
        PrintBLL pBLL = new PrintBLL();
        KhachHang kh = new KhachHang();
        HoaDonBan hdb = null;
        ChucVu cv = null;
        SanPham_CuaHang spch = null;
        PhieuDoiTra pdt = null;
        CTPhieuDoiTra ctpdt = null;
        XuLyDoiTra xldt = new XuLyDoiTra();
        ChiTietHoaDon cthd = null;
        NhanVien nv = FNhanVien.GetNhanVien();

        List<ChiTietHoaDon> cthdl = null;
        List<HoaDonBan> hdbl = null;
        List<SanPham> spl = null;
        List<SanPham_CuaHang> spchl = null;
        List<CTPhieuDoiTra> ctpdtl = null;
        List<PhieuDoiTra> pdtl = null;
        List<SanPham_CuaHang> spchlt = null;
        FNVHoaDon fnvhd = new FNVHoaDon();
        CuaHang ch = new CuaHang();
        private double giamgia = 0.0;
        public FNVKhachHang()
        {
            InitializeComponent();

            loadKhachHangList();
            comboBoxGioiTinh();

            pdtl = pdtBLL.getPhieuDoiTraList(null, null);
            hdbl = hdbBLL.getHoaDonBanList(null);
            spl = spBLL.LoadDlSanPham();
            spchl = spchBLL.getSPTheoCuaHangList();

            tabNhanVienMenu.SizeMode = TabSizeMode.Fixed;
            tabNhanVienMenu.ItemSize = new System.Drawing.Size(0, 1);

            ch = chBLL.getCuaHang(nv.maCuaHang);
            dgSPDT.Hide();
            flPicSP.Hide();
            picSP_HD.Hide();
            lbNgayDoi.Value = DateTime.Now;
            PhanQuyen();
        }

        private void PhanQuyen()
        {
            cv = cvBLL.getChucVuCuaNV(nv);
            if (cv.tenChucVu != "Cửa hàng trưởng")
            {
                btXoaKHNV.Hide();
            }
            else
            {
                btKHNV_LHD.Hide();
                btPhieuDoi.Hide();
                btPhieuTra.Hide();
                btThemKHNV.Hide();
                btResetKHNV.Hide();
            }
        }
        public KhachHang SetKhach()
        {
            kh.maKhachHang = txtKHNVMaKH.Text;
            kh.tenKhach = txtKHNVHo.Text;
            kh.diaChi = txtKHNVDiaChi.Text;
            kh.ngaySinh = dpKHNVNgaySinh.Value;
            kh.soDienThoai = txtKHNVSDT.Text;
            kh.gioiTinh = getGioiTinhKH();
            return kh;
        }
        public KhachHang GetKhach()
        {
            return kh;
        }
        private void loadKhachHangList()
        {
            dgKHNVView.DataSource = khbll.getKhachHangList(null);
            dgKHNVView.Columns["maKhachHang"].HeaderText = "Mã Khách Hàng";
            dgKHNVView.Columns["tenKhach"].HeaderText = "Tên Khách Hàng";
            dgKHNVView.Columns["gioiTinh"].HeaderText = "Giới Tính";
            dgKHNVView.Columns["ngaySinh"].HeaderText = "Ngày Sinh";
            dgKHNVView.Columns["diaChi"].HeaderText = "Địa Chỉ";
            dgKHNVView.Columns["soDienThoai"].HeaderText = "Số Điện Thoại";
        }
        private void txtKHNVSearch_TextChanged(object sender, EventArgs e)
        {
            String x = txtKHNVSearch.Text;
            dgKHNVView.DataSource = khbll.getKhachHangList(x);
        }
        private void dgKHNVView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtKHNVMaKH.Text = dgKHNVView.SelectedRows[0].Cells[0].Value.ToString();
            txtKHNVHo.Text = dgKHNVView.SelectedRows[0].Cells[1].Value.ToString();
            txtKHNVTen.Text = getTenKhachHang(dgKHNVView.SelectedRows[0].Cells[1].Value.ToString());
            string cellValue = dgKHNVView.SelectedRows[0].Cells[2].Value.ToString();
            if (cellValue == "True")
            {
                cbKHNVGioiTinh.SelectedIndex = cbKHNVGioiTinh.FindStringExact("Nam");
            }
            else if (cellValue == "False")
            {
                cbKHNVGioiTinh.SelectedIndex = cbKHNVGioiTinh.FindStringExact("Nữ");
            }
            dpKHNVNgaySinh.Value = (DateTime)(dgKHNVView.SelectedRows[0].Cells[3].Value);
            txtKHNVDiaChi.Text = dgKHNVView.SelectedRows[0].Cells[4].Value.ToString();
            txtKHNVSDT.Text = dgKHNVView.SelectedRows[0].Cells[5].Value.ToString();
            lbWarningKH.Text = "";

            SetKhach();

            double TTT = hdbBLL.tinhTongTien(kh, hdbl,pdtl);

            lbCountHD.Text = hdbBLL.countHoaDonBan(kh).ToString();
            lbTongTienKH.Text = string.Format("{0:#,0}", TTT);
            XepHangKhachHang(TTT, lbXepHang);
        }
       
        int XH = 0;
        public void XepHangKhachHang(double Tien, Label lx)
        {
            string xepHang = "Mới";
            lx.ForeColor = Color.Purple;
            if (Tien > 8000000)
            {
                xepHang = "Vàng";
                lx.ForeColor = Color.Goldenrod;
                XH = 3;
            }
            else
            if (Tien > 5000000)
            {
                xepHang = "Bạc";
                lx.ForeColor = Color.LightGray;
                XH = 2;
            }
            else
            if (Tien > 3000000)
            {
                xepHang = "Đồng";
                lx.ForeColor = Color.DarkKhaki;
                XH = 1;
            }
            else
                XH = 0;


            lbXepHang.Text = xepHang;
        }

        // Giới hạn dữ liệu nhập vào
        private void txtKHNVSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && (!char.IsDigit(e.KeyChar)))
            {
                e.Handled = true;

            }
            string DemTaiKhoan = txtKHNVSDT.Text + e.KeyChar;
            if (DemTaiKhoan.Length >= 11)
            {
                lbWarningKH.Text = "SDT không quá 10 số !";
            }
            else { lbWarningKH.Text = ""; }
        }
        private void txtKHNVHo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 9 && !(char.IsWhiteSpace(e.KeyChar)))
                e.Handled = true;
        }
        private void txtSP_SoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && (!char.IsDigit(e.KeyChar)) && (e.KeyChar != 8 || e.KeyChar != 13))
            {
                e.Handled = true;

            }

        }
        // Tác vụ phụ

        private String getTenKhachHang(String hoten)
        {
            var names = hoten.Split(' ');
            string firstName = names[0];
            string lastName = names[names.Length - 1];
            return lastName;
        }
        private void comboBoxGioiTinh()
        {
            cbKHNVGioiTinh.Items.Add("Nam");
            cbKHNVGioiTinh.Items.Add("Nữ");
            cbKHNVGioiTinh.SelectedIndex = 0;
            cbKHNVGioiTinh.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private Boolean getGioiTinhKH()
        {
            Boolean gt = false;
            String sgt = cbKHNVGioiTinh.SelectedItem.ToString();
            if (sgt == "Nam")
                gt = true;
            return gt;
        }
        private void reset()
        {
            txtKHNVMaKH.Text = "";
            txtKHNVHo.Text = "";
            txtKHNVTen.Text = "";
            txtKHNVDiaChi.Text = "";
            txtKHNVSDT.Text = "";
            txtKHNVMaKH.Text = "";
            dpKHNVNgaySinh.Value = DateTime.Now;

            lbCountHD.Text = "";
            lbTongTienKH.Text = "";
            lbXepHang.Text = "";
        }

        // Thao tác với Khách Hàng

        // Thêm Khách Hàng
        private void btThemKHNV_Click(object sender, EventArgs e)
        {

            if (txtKHNVHo.Text.Equals("") || txtKHNVSDT.Text.Equals(""))
            {
                lbWarningKH.Text = "Hãy nhập đầy đủ thông tin !";
            }
            else
            {
                SetKhach();
                lbWarningKH.Text = khbll.themKhachHang(kh);
                loadKhachHangList();
                reset();
            }
        }
        // Sửa Khách Hàng
        private void btSuaKHNV_Click(object sender, EventArgs e)
        {
            if (txtKHNVMaKH.Text == "")
                lbWarningKH.Text = "Hãy chọn Khách Hàng để đổi !";
            else
            {
                if (txtKHNVHo.Text.Equals("") || txtKHNVDiaChi.Text.Equals("") || txtKHNVSDT.Text.Equals(""))
                {
                    lbWarningKH.Text = "Hãy nhập đầy đủ thông tin !";
                }
                else
                {
                    SetKhach();
                    if (khbll.editKhachHang(kh))
                    {
                        lbWarningKH.Text = "Sửa thành công !";
                        loadKhachHangList();
                        reset();
                    }
                    else lbWarningKH.Text = "Sửa thất bại !";
                }

            }
        }
        // XÓa Khách Hàng
        private void btXoaKHNV_Click(object sender, EventArgs e)
        {
            if (txtKHNVMaKH.Text == "")
                lbWarningKH.Text = "Hãy chọn Khách Hàng để xóa !";
            else
            {
                if (khbll.delKhachHang(kh))
                {
                    lbWarningKH.Text = "Xóa thành công !";
                    loadKhachHangList();
                    reset();
                }
                else
                    lbWarningKH.Text = "Xóa thất bại !";
            }
        }


        //============================ Tab Hóa ĐƠn ==============================
        private void loadKhachHangInfo(KhachHang kh)
        {
            txtSPNVHo.Text = kh.tenKhach;
            txtSPNVMa.Text = kh.maKhachHang;
            txtSPNVNgaySinh.Text = kh.ngaySinh.ToShortDateString();
            txtSPNVDiaChi.Text = kh.diaChi;
            txtSPNVSDT.Text = kh.soDienThoai;
            txtSPNVGioiTinh.Text = (kh.gioiTinh) ? "Nam" : "Nữ";

        }
        // Button Chuyên Sang Hóa Đơn tab
        private void btKHNV_LHD_Click(object sender, EventArgs e)
        {
            if (txtKHNVMaKH.Text == "")
                lbWarningKH.Text = "Hãy chọn Khách Hàng để lập Hóa Đơn !";
            else
            {
                tabNhanVienMenu.SelectedTab = tabNhanVienMenu.TabPages["tabHDB"];
                if(pnPDTLeft != null) {

                    loadKhachHangPDT(pnPDTLeft, pnSPNVLeft);
                }
                loadKhachHangInfo(GetKhach());

                spl = spBLL.LoadDlSanPham();
                spchl = spchBLL.getSPTheoCuaHangList();
                loadSanPhamNhanVien(dgSPNV, spl, spchl);
            }

        }
        // Button Lập Hóa đơn
        private void btLapHoaDon_Click(object sender, EventArgs e)
        {
            if (hdb == null)
            {
                hdb = new HoaDonBan();
                cthdl = new List<ChiTietHoaDon>();

                hdbBLL.SetHoaDonBan(hdb, nv, GetKhach());

                lbWarningSP.Text = "Lập Hóa Đơn thành công";
                loadmaGiamGia();
                if (XH == 3)
                    cbGiamGia.SelectedValue = 0.15;
                else
                {
                    if (XH == 2)
                        cbGiamGia.SelectedValue = 0.1;
                    else
                    {
                        if (XH == 1)
                            cbGiamGia.SelectedValue = 0.05;
                    }
                }
            }
            else
            {
                lbWarningSP.Text = "Hóa Đơn đã được lập";
            }
        }



        // Load Danh sách Sản phẩm
        public void loadSanPhamNhanVien(DataGridView dgSPNV, List<SanPham> spl, List<SanPham_CuaHang> spchl)
        {
            dgSPNV.DataSource = spBLL.ListSPNhanVien(nv, spl,
                    sptsBLL.LoadDlMaSPTheoSize(), spchl);
            if (dgSPNV.Rows.Count > 0)
            {
                try
                {
                    dgSPNV.Columns["maSPTheoSize"].HeaderText = "Mã SP";
                    dgSPNV.Columns["maSPTheoSize"].Width = 80;
                    dgSPNV.Columns["tenSanPham"].HeaderText = "Tên Sản Phẩm";
                    dgSPNV.Columns["tenSanPham"].Width = 129;
                    dgSPNV.Columns["moTaSanPham"].HeaderText = "Mô Tả SP";
                    dgSPNV.Columns["moTaSanPham"].Width = 220;
                    dgSPNV.Columns["donGiaNiemYet"].HeaderText = "Giá Bán";
                    dgSPNV.Columns["chatLieu"].HeaderText = "Chất Liệu";
                    dgSPNV.Columns["soLuong"].HeaderText = "Số Lượng";
                    dgSPNV.Columns["soLuong"].Width = 55;

                    dgSPNV.Columns["giaNhap"].Visible = false;
                    dgSPNV.Columns["maCuaHang"].Visible = false;
                    lbWarningSP.Text = "";
                }
                catch (NullReferenceException ex)
                {
                    lbWarningSP.Text = "Có lỗi trong lúc load dữ liệu";
                }
            }
            else
            {
                lbWarningSP.Text = "Không có dữ liệu để hiển thị";
            }
        }
        private void txtSPNVSearch_TextChanged(object sender, EventArgs e)
        {
            spl = spBLL.TimKiemSanPham(txtSPNVSearch.Text);
            spchl = spchBLL.getSPTheoCuaHangList();
            loadSanPhamNhanVien(dgSPNV, spl, spchl);
        }
        private void dgSPNV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                lbWarningSP.Text = "";
                txtSP_Ma.Text = dgSPNV.SelectedRows[0].Cells["maSPTheoSize"].Value.ToString();
                txtSP_Ten.Text = dgSPNV.SelectedRows[0].Cells["tenSanPham"].Value.ToString();
                txtSP_Gia.Text = dgSPNV.SelectedRows[0].Cells["donGiaNiemYet"].Value.ToString() + " VNĐ";
                txtSP_SoLuong.Text = dgSPNV.SelectedRows[0].Cells["soLuong"].Value.ToString();
                String msp = txtSP_Ma.Text.Split('_')[0];
                loadAnhSP(msp, flPicSP, picSP_HD);
                spch = spchBLL.getSanPhamCuaHang(nv.maCuaHang,txtSP_Ma.Text);

            }
        }
        // Ảnh Sản Phẩm
        public void loadAnhSP(String msp, FlowLayoutPanel flPicSP, PictureBox picSP_HD)
        {
            flPicSP.Show();
            // Gọi BLL để lấy danh sách đường dẫn ảnh tương ứng với sản phẩm
            AnhSanPhamBLL anhBLL = new AnhSanPhamBLL();
            List<string> danhSachDuongDanAnh = anhBLL.LayDanhSachDuongDanAnh(msp);
            // Xóa tất cả các PictureBox hiện có trên flowLayoutPanel1
            flPicSP.Controls.Clear();

            // Lặp qua danh sách đường dẫn ảnh và hiển thị ảnh lên flowLayoutPanel1
            foreach (string duongDanAnh in danhSachDuongDanAnh)
            {
                // Tạo một PictureBox mới cho mỗi đường dẫn ảnh
                PictureBox pictureBox = new PictureBox();

                using (System.Net.WebClient client = new System.Net.WebClient())
                {
                    byte[] imageBytes = client.DownloadData(duongDanAnh);

                    if (imageBytes != null && imageBytes.Length > 0)
                    {
                        using (MemoryStream ms = new MemoryStream(imageBytes))
                        {
                            pictureBox.Image = new Bitmap(ms);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Lỗi.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox.Height = 150;
                pictureBox.Margin = new Padding(0);
                flPicSP.Controls.Add(pictureBox);

                pictureBox.MouseEnter += (sender, e) =>
                {
                    picSP_HD.Show();
                    picSP_HD.ImageLocation = duongDanAnh;
                    picSP_HD.BringToFront();
                };
                pictureBox.MouseLeave += (sender, e) =>
                {
                    picSP_HD.Image = null;
                    picSP_HD.Hide();
                };

            }
        }

        private void btSPNVReset_Click(object sender, EventArgs e)
        {
            txtSPNVMa.Text = "";
            txtSPNVHo.Text = "";
            txtSPNVGioiTinh.Text = "";
            txtSPNVDiaChi.Text = "";
            txtSPNVNgaySinh.Text = "";
            txtSPNVSDT.Text = "";

            txtSP_Gia.Text = "";
            txtSP_Ma.Text = "";
            txtSP_SoLuong.Text = "";
            txtSP_SoLuongM.Text = "";
            txtSP_Ten.Text = "";

        }

        private void btBackToKH_Click(object sender, EventArgs e)
        {
            tabNhanVienMenu.SelectedTab = tabNhanVienMenu.TabPages["tabKhachHang"];
            resetPDT();
        }

        private void btSPHD_Xem_Click(object sender, EventArgs e)
        {
            if (hdb == null)
                lbWarningSP.Text = "Hãy lập hóa đơn trước !";
            else
            {
                lbSPNV_MHD.Text = hdb.maHoaDon;
                tabNhanVienMenu.SelectedTab = tabNhanVienMenu.TabPages["tabCTHD"];

                CTHDList.DataSource = null;
                loadCTHDList(cthdl);
                flPicSP.Hide();
            }
        }
        private void btSPNV_ThemSP_Click(object sender, EventArgs e)
        {
            if (hdb == null)
                lbWarningSP.Text = "Hãy lập Hóa Đơn trước !";
            else
            {
                if (txtSP_Ma.Text == "")
                    lbWarningSP.Text = "Hãy chọn sản phẩm để thêm !";
                else
                {
                    bool HDBValid = hdbl.Exists(ct => ct.maHoaDon == hdb.maHoaDon);

                    if (!HDBValid)
                    {
                        int giaBan = Convert.ToInt32(dgSPNV.SelectedRows[0].Cells["donGiaNiemYet"].Value.ToString());

                        if (txtSP_SoLuongM.Text == "")
                            lbWarningSP.Text = " Hãy nhập số lượng muốn mua !";
                        else
                        {
                            int soluongmua = Convert.ToInt32(txtSP_SoLuongM.Text);
                            int i = Convert.ToInt32(txtSP_SoLuong.Text);
                            if (soluongmua > i)
                            {
                                lbWarningSP.Text = "Số lượng lớn hơn sản phẩm đang có !";
                            }
                            else
                            {
                                ChiTietHoaDon cthd = new ChiTietHoaDon();
                                cthd.maSanPhamTheoSize = txtSP_Ma.Text;
                                String msp = txtSP_Ma.Text.Split('_')[0];
                                cthd.maHoaDon = hdb.maHoaDon;

                                bool maSanPhamValid = cthdl.Exists(ct => ct.maSanPhamTheoSize == txtSP_Ma.Text);

                                if (!maSanPhamValid)
                                {
                                    cthd.soLuong = Convert.ToInt32(txtSP_SoLuongM.Text);

                                    cthd.giamGia = (Double)cbGiamGia.SelectedValue;

                                    cthdl.Add(cthd);
                                    lbWarningSP.Text = "Thêm Sản Phẩm thành công !";

                                    txtSP_Ma.Text = "";
                                    txtSP_Ten.Text = "";
                                    txtSP_Gia.Text = "";
                                    txtSP_SoLuong.Text = "";
                                    txtSP_SoLuongM.Text = "";
                                    flPicSP.Controls.Clear();
                                }
                                else
                                {
                                    lbWarningSP.Text = "Sản Phẩm đã có !";
                                }

                            }
                        }
                    }
                    else
                    {
                        lbWarningSP.Text = "Hóa đơn đã được lưu không thể thêm !";
                    }    

                }
            }
        }
        // ========================== tab Chi Tiết Hóa Đơn ======================

        private void loadmaGiamGia()
        {
            List<Tuple<string, double>> giamGiaList = new List<Tuple<string, double>>
                                    {
                                        Tuple.Create("0%", 0.0),
                                        Tuple.Create("5%", 0.05),
                                        Tuple.Create("10%", 0.10),
                                        Tuple.Create("15%", 0.15),
                                        Tuple.Create("50%", 0.50),
                                        Tuple.Create("70%", 0.70)

                                    };
            cbGiamGia.DropDownStyle = ComboBoxStyle.DropDownList;
            cbGiamGia.DataSource = giamGiaList;
            cbGiamGia.DisplayMember = "Item1";
            cbGiamGia.ValueMember = "Item2";
        }
        private void cbGiamGia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbMSP.Text == "")
            {
                foreach (ChiTietHoaDon cthd in cthdl)
                {
                    cthd.giamGia = (Double)cbGiamGia.SelectedValue;
                }
            }
            else
            {
                lbWarningCTHD.Text = "";
                foreach (ChiTietHoaDon cthd in cthdl)
                {
                    if (lbMSP.Text == cthd.maSanPhamTheoSize)
                        cthd.giamGia = (Double)cbGiamGia.SelectedValue;
                }
            }
            CTHDList.Refresh();
            double tongtienHD = 0;
            foreach (DataGridViewRow row in CTHDList.Rows)
            {
                int soLuong = Convert.ToInt32(row.Cells["soLuong"].Value);
                int donGia = Convert.ToInt32(row.Cells["donGia"].Value);
                double GiamGia = Convert.ToDouble(row.Cells["giamGia"].Value);
                double thanhTien;

                thanhTien = soLuong * donGia - (soLuong * donGia * GiamGia);
                row.Cells["thanhTien"].Value = thanhTien;
                tongtienHD += thanhTien;
            }
            lbSPNV_TongTien.Text = string.Format("{0:#,0}", tongtienHD) + " VNĐ";
        }
        private void loadCTHDList(List<ChiTietHoaDon> cthdlprivate)
        {
            CTHDList.DataSource = cthdlprivate;

            CTHDList.Columns["maHoaDon"].Visible = false;
            CTHDList.Columns["maSanPhamTheoSize"].HeaderText = "Mã SP";
            CTHDList.Columns["soLuong"].HeaderText = "Số Lượng";
            CTHDList.Columns["giamGia"].HeaderText = "Giảm Giá";
            CTHDList.Columns["donGia"].HeaderText = "Đơn Giá";
            if (!CTHDList.Columns.Contains("thanhTien"))
            {
                DataGridViewTextBoxColumn thanhTienColumn = new DataGridViewTextBoxColumn();
                thanhTienColumn.Name = "thanhTien";
                thanhTienColumn.HeaderText = "Thành Tiền";
                CTHDList.Columns.Add(thanhTienColumn);
            }
            double tongtienHD = 0;
            foreach (DataGridViewRow row in CTHDList.Rows)
            {
                string maSanPhamTheoSize = row.Cells["maSanPhamTheoSize"].Value as string;
                String msp = maSanPhamTheoSize.Split('_')[0];
                int soLuong = Convert.ToInt32(row.Cells["soLuong"].Value);
                int donGia = spBLL.getSanPham(msp).donGiaNiemYet;
                double GiamGia = Convert.ToDouble(row.Cells["giamGia"].Value);
                double thanhTien;

                thanhTien = soLuong * donGia - (soLuong * donGia * GiamGia);
                row.Cells["thanhTien"].Value = thanhTien;
                row.Cells["donGia"].Value = donGia;
                tongtienHD += thanhTien;
            }
            lbSPNV_TongTien.Text = string.Format("{0:#,0}", tongtienHD) + " VNĐ";

        }


        // Button Lưu Hóa ĐƠn
        private void btLuuHoaDon_Click(object sender, EventArgs e)
        {
            bool pnValid = hdbl.Exists(hdn => hdn.maHoaDon == hdb.maHoaDon);
            if (pnValid)
            {
                lbWarningCTHD.Text = "Hóa Đơn đã được lưu";
            }
            else
            {
                if (cthdl.Count == 0)
                    lbWarningCTHD.Text = "Hóa đơn rỗng, không có gì để lưu ! ";
                else
                {
                    DialogResult result = MessageBox.Show("Bạn có chắc sẽ lưu hóa đơn ?", "Hóa đơn", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (result == DialogResult.OK)
                    {
                        try
                        {


                            if (hdbBLL.addHoaDonBan(hdb))
                            {
                                bool checkThanhCong = true;

                                foreach (ChiTietHoaDon cthd in cthdl)
                                {
                                    spch = spchBLL.getSanPhamCuaHang(nv.maCuaHang, cthd.maSanPhamTheoSize);
                                    spch.soLuong -= cthd.soLuong;
                                    if (!spchBLL.updateSanPhamCuaHang(spch))
                                    {
                                        checkThanhCong = false;
                                        break;
                                    }
                                    if (!hdbBLL.addChiTietHoaDon(cthd))
                                    {
                                        checkThanhCong = false;
                                        break;
                                    }


                                }
                                if (checkThanhCong)
                                {
                                    MessageBox.Show("Lưu hóa đơn thành công !", "Hóa đơn", MessageBoxButtons.OK);
                                    hdbl.Add(hdb);

                                    spchl = spchBLL.getSPTheoCuaHangList();
                                    loadSanPhamNhanVien(dgSPNV, spl, spchl);
                                }
                                else
                                {
                                    lbWarningCTHD.Text = "Lưu sản phẩm vào hóa đơn thất bại !";
                                }
                            }
                            else
                                MessageBox.Show("Lưu hóa đơn thất bại !", "Hóa đơn", MessageBoxButtons.OK, MessageBoxIcon.Error);


                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Không thể thêm sản phẩm cho cửa hàng. Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }

        }


        //  Button Xóa Sản Phẩm trong CTHD List
        private void resetCTHD()
        {
            txtSP_SoLuongMCTHD.Text = "";
            lbMSP.Text = "";
        }
        private void btCTHDXoa_Click(object sender, EventArgs e)
        {
            bool pnValid = hdbl.Exists(hdn => hdn.maHoaDon == hdb.maHoaDon);
            if (pnValid)
            {
                lbWarningCTHD.Text = "Hóa Đơn đã được lưu Không thể Xóa ";
            }
            else
            {
                if (lbMSP.Text == "")
                    lbWarningCTHD.Text = "Hãy chọn sản Phẩm để xóa";
                else
                {
                    cthdl.RemoveAll(cthd => cthd.maSanPhamTheoSize == lbMSP.Text);
                    lbWarningCTHD.Text = "Xóa SP Thành công !";

                    CTHDList.DataSource = null;
                    loadCTHDList(cthdl);
                    resetCTHD();
                }
            }

        }

        // Button Sửa Sản Phẩm trong CTHD List

        private void btCTHDSua_Click(object sender, EventArgs e)
        {
            bool pnValid = hdbl.Exists(hdn => hdn.maHoaDon == hdb.maHoaDon);
            if (pnValid)
            {
                lbWarningCTHD.Text = "Hóa Đơn sau khi lưu không thể sửa !";
            }
            else
            {
                if (lbMSP.Text == "")
                    lbWarningCTHD.Text = "Hãy chọn sản phẩm để đổi !";
                else
                {
                    if (txtSP_SoLuongMCTHD.Text == "")
                        lbWarningCTHD.Text = "Hãy nhập số lượng cần mua !";
                    else
                    {
                        int i = Convert.ToInt32(txtSP_SoLuongMCTHD.Text);
                        if (spch.soLuong < i)
                            lbWarningCTHD.Text = "Số lượng sản phẩm lớn hơn đang có !";
                        else
                        {
                            ChiTietHoaDon sanPhamCanCapNhat = cthdl.FirstOrDefault(cthd => cthd.maSanPhamTheoSize == lbMSP.Text);
                            sanPhamCanCapNhat.soLuong = Convert.ToInt32(txtSP_SoLuongMCTHD.Text);
                            CTHDList.Refresh();
                            lbWarningCTHD.Text = "Đổi số lượng thành công !";
                            resetCTHD();
                        }
                    }
                }
            }
        }


        // Button Chuyển sang Hóa ĐƠn Bán
        private void btBackHDB_Click(object sender, EventArgs e)
        {
            tabNhanVienMenu.SelectedTab = tabNhanVienMenu.TabPages["tabHDB"];
        }

        // Button Reset
        private void btResetKHNV_Click(object sender, EventArgs e)
        {
            reset();
        }

        // In Hóa Đơn 
        private void printHD_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            pBLL.VeHoaDon(nv, ch, cthdl, e, GetKhach());
        }

        private void InHD_Click(object sender, EventArgs e)
        {
            if (cthdl.Count != 0)
            {
                bool pnValid = hdbl.Exists(hdn => hdn.maHoaDon == hdb.maHoaDon);
                if (pnValid)
                {
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result = MessageBox.Show("Bạn muốn xem trước Hóa Đơn:", "Lựa chọn", buttons, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (result == DialogResult.Yes)
                    {
                        printPreviewHD.Document = printHD;
                        printPreviewHD.ShowDialog();
                    }
                    else
                    {
                        printDialogHD.Document = printHD;
                        DialogResult result1 = printDialogHD.ShowDialog();
                        if (result1 == DialogResult.OK)
                        {
                            printHD.Print();
                        }
                    }

                }
                else
                {
                    lbWarningCTHD.Text = " Hãy lưu hóa đơn trước !";
                }
            }
            else
                lbWarningCTHD.Text = "Hóa đơn rỗng";
        }

        //================================ Thao Tác Trả ==========================
        //Tác vụ phụ 
        public int ShowInputDialog()
        {
            int result = 0;
            bool checkIntput = false;
            while (!checkIntput)
            {
                string inputValue = Interaction.InputBox("Hãy nhập số lượng !", "Số lượng");
                if (string.IsNullOrEmpty(inputValue))
                {
                    return 0;
                }

                if (int.TryParse(inputValue, out result) && result > 0)
                {
                    checkIntput = true;
                }

            }
            return result;
        }
        private void resetPDT()
        {
            lbMaPhieuDoi.Text = "";
            lbTenNVThucHien.Text = "";
            lbMSP_CTPD.Text = "";
            lbSoLuong_CTPD.Text = "";
            lbMaPD_CTPD.Text = "";
            dgCTPD.DataSource = null;
            pdt = null;
            hdb = null;
            spchl = null;
            spchlt = null;
            lbWarningPD.Text = "";
        }

        private void loadKhachHangPDT(Panel pnSPNVLeft, Panel pnPDTLeft)
        {
            Control[] controls = new Control[pnSPNVLeft.Controls.Count];
            pnSPNVLeft.Controls.CopyTo(controls, 0);
            foreach (Control c in controls)
                pnPDTLeft.Controls.Add(c);

            loadKhachHangInfo(GetKhach());
        }

        //// DataGridView Hóa ĐƠn Bán Từ Form Phiếu Đổi Trả
        private void loadHoaDonBan_PDT()
        {
            fnvhd.getHoaDonList(dgHD_PDT, GetKhach());

            if (!dgHD_PDT.Columns.Contains("XemChiTiet"))
            {
                // Tạo cột XemChiTiet button
                DataGridViewButtonColumn xemcbutton = new DataGridViewButtonColumn();
                xemcbutton.Name = "XemChiTiet";
                xemcbutton.HeaderText = " ";
                xemcbutton.Text = "Xem Chi Tiết";
                xemcbutton.UseColumnTextForButtonValue = true;
                xemcbutton.DisplayIndex = dgHD_PDT.Columns.Count;
                // Thêm cột nút "Xem Chi Tiết" vào DataGridView
                dgHD_PDT.Columns.Add(xemcbutton);

            }
            else
            {
                dgHD_PDT.Columns["XemChiTiet"].Visible = true;
            }
            if (dgHD_PDT.Columns.Contains("Doi"))
            {
                dgHD_PDT.Columns["Doi"].Visible = false;
            }
        }
        private Boolean doiColumn = false;
        private void loadCTHD_PDT(String x)
        {
            if (dgHD_PDT.Columns.Contains("XemChiTiet"))
            {
                dgHD_PDT.Columns["XemChiTiet"].Visible = false;
            }

            ChiTietHoaDon cthd = new ChiTietHoaDon();
            cthd.maHoaDon = x;
            fnvhd.getCTHDList(dgHD_PDT, cthd);
            if (!dgHD_PDT.Columns.Contains("Doi") && xldt.maXuLyDoiTra == "1")
            {
                DataGridViewButtonColumn doiButton = new DataGridViewButtonColumn();
                doiButton.Name = "Doi";
                doiButton.HeaderText = " ";
                doiButton.Text = "Đổi";
                doiButton.UseColumnTextForButtonValue = true;
                doiButton.DisplayIndex = dgHD_PDT.Columns.Count;

                // Thêm cột nút "Nhập" vào DataGridView
                dgHD_PDT.Columns.Add(doiButton);
                doiColumn = true;
            }
            else
            {
                if (xldt.maXuLyDoiTra == "1")
                {
                    dgHD_PDT.Columns["Doi"].Visible = true;
                }
            }

        }
        private void dgHD_PDT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgHD_PDT.Columns["XemChiTiet"].Index)
            {
                String x = dgHD_PDT.SelectedRows[0].Cells["maHoaDon"].Value.ToString();

                lbMHD_PD.Text = x;
                hdb = new HoaDonBan();
                hdb.maHoaDon = x;

                String mnv = dgHD_PDT.SelectedRows[0].Cells["maNhanVien"].Value.ToString();
                NhanVien nv = nvBLL.getNhanVien(mnv);
                lbTenNV_PD.Text = nv.hoNhanVien + " " + nv.tenNhanVien;

                lbNgayLap_PD.Value = (DateTime)dgHD_PDT.SelectedRows[0].Cells["ngayLapHoaDon"].Value;

                ChiTietHoaDon cthd = new ChiTietHoaDon();
                cthd.maHoaDon = hdb.maHoaDon;
                cthdl = hdbBLL.getCTHDList(cthd);
                loadCTHD_PDT(x);
            }
            else
                lbWarningPD.Text = "";


            if (dgHD_PDT.Columns.Contains("giamGia"))
            {
                try
                {
                    giamgia = (double)dgHD_PDT.SelectedRows[0].Cells["giamGia"].Value;
                }
                catch { giamgia = 0.0; }
            }
            else
            {
                lbWarningPD.Text = "";
            }
            if (doiColumn && e.ColumnIndex == dgHD_PDT.Columns["Doi"].Index && pdt != null)
            {
                dgSPDT.Show();
                loadSPDT();
            }
            else
            {
                lbWarningPD.Text = "Hãy lập Phiếu !";
            }

            if (xldt.maXuLyDoiTra == "2" && dgHD_PDT.Columns.Contains("maSanPhamTheoSize"))
            {
                try
                {
                    lbMSP_PT.Text = dgHD_PDT.SelectedRows[0].Cells["maSanPhamTheoSize"].Value.ToString();
                    lbSoLuongSPCo.Text = dgHD_PDT.SelectedRows[0].Cells["soLuong"].Value.ToString();
                }
                catch
                {
                    lbMSP_PT.Text = "";
                    lbSoLuongSPCo.Text = "";
                }
            }

        }

        private void loadSPDT()
        {
            spl = spBLL.TimKiemSanPham(txtSPNVSearch.Text);
            spchl = spchBLL.getSPTheoCuaHangList();
            loadSanPhamNhanVien(dgSPDT, spl, spchl);

            if (!dgSPDT.Columns.Contains("Doi"))
            {
                DataGridViewButtonColumn doiButton = new DataGridViewButtonColumn();
                doiButton.Name = "Doi";
                doiButton.HeaderText = " ";
                doiButton.Text = "Đổi";
                doiButton.UseColumnTextForButtonValue = true;


                // Thêm cột nút "Nhập" vào DataGridView
                dgSPDT.Columns.Add(doiButton);
                dgSPDT.Columns["chatLieu"].Visible = false;
            }
        }
        private void dgSPDT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = 0;
            String msp = dgSPDT.SelectedRows[0].Cells["maSPTheoSize"].Value.ToString();
            String mspInHD = dgHD_PDT.SelectedRows[0].Cells["maSanPhamTheoSize"].Value.ToString();
            int soluong = Convert.ToInt32(dgHD_PDT.SelectedRows[0].Cells["soLuong"].Value);
            int soluongSPHD = 0;
            int soluongSPPD = 0;

            foreach (ChiTietHoaDon cthd in cthdl)
            {
                soluongSPHD += cthd.soLuong;
            }

            bool maSanPhamValid = ctpdtl.Exists(ct => ct.maSPTheoSize == msp);

            if (!maSanPhamValid)
            {
                if (e.RowIndex >= 0 && e.ColumnIndex == dgSPDT.Columns["Doi"].Index && pdt != null)
                {
                    i = ShowInputDialog();
                    foreach (CTPhieuDoiTra ctpdt in ctpdtl)
                        soluongSPPD += ctpdt.soLuong;
                    if (i > soluong)
                    {
                        lbWarningPD.Text = "Số lượng sản phẩm lớn hơn sp trong hóa đơn !";
                        dgSPDT.Hide();
                        return;
                    }
                    if (soluongSPPD >= soluongSPHD)
                    {
                        lbWarningPD.Text = "Tổng số lượng sản phẩm lớn hơn trong hóa đơn !";
                        dgSPDT.Hide();
                        return;
                    }
                    else
                    {
                        if (i > 0)
                        {
                            // Thêm Chi Tiết Phiếu Đổi Trả vào List pdtl
                            ctpdt = new CTPhieuDoiTra();
                            ctpdt.maPhieuDoiTra = pdt.maPhieuDoiTra;
                            ctpdt.maSPTheoSize = msp;
                            ctpdt.soLuong = i;
                            ctpdt.giamGia = giamgia;
                            lbWarningPD.Text = " Bạn đã đổi " + i.ToString() + " sản phẩm. ";

                            // Thêm Sản Phẩm Cửa Hàng vào List tạm
                            spch = new SanPham_CuaHang();
                            spch.maCuaHang = nv.maCuaHang;
                            spch.maSPTheoSize = mspInHD;
                            spch.soLuong = i;
                            ctpdt.maSPTheoSizeRe = mspInHD;

                            spchlt.Add(spch);
                            ctpdtl.Add(ctpdt);
                            dgSPDT.Hide();
                        }
                        else
                            lbWarningPD.Text = "Số lượng không hợp lệ !";
                    }
                }
            }
            else
            {
                lbWarningPD.Text = "Sản phẩm đã tồn tại trong List.";
            }
        }
        private PhieuDoiTra setPhieuDoiTra(PhieuDoiTra pdt)
        {
            pdt.maPhieuDoiTra = nv.maNhanVien + "_" + xldt.maXuLyDoiTra + "L" + GetKhach().maKhachHang + (pdtBLL.coutPhieuDoiTra(GetKhach(), xldt.maXuLyDoiTra) + 1).ToString();
            pdt.maNhanVien = nv.maNhanVien;
            pdt.maKhachHang = GetKhach().maKhachHang;
            pdt.ngayDoiTra = DateTime.Now;
            pdt.maXuLyDoiTra = xldt.maXuLyDoiTra;
            pdt.maHoaDon = hdb.maHoaDon;
            return pdt;
        }
        private PhieuDoiTra getPhieuDoiTra()
        {
            return pdt;
        }
        // Chuyển Qua Phiếu Đổi Trả
        private void btPhieuDoi_Click(object sender, EventArgs e)
        {
            if (txtKHNVMaKH.Text == "")
                lbWarningKH.Text = "Hãy chọn Khách Hàng để lập phiếu đổi !";
            else
            {
                tabNhanVienMenu.SelectedTab = tabNhanVienMenu.TabPages["tabPhieuDoi"];
                // Load Thông tin Khách Hàng
                loadKhachHangPDT(pnSPNVLeft, pnPDTLeft);
                flPicSP.Hide();
                // Load Các Hóa Đơn Bán
                loadHoaDonBan_PDT();

                xldt.maXuLyDoiTra = "1";
                switchDoiTra();

                spl = spBLL.LoadDlSanPham();
                spchl = spchBLL.getSPTheoCuaHangList();
            }
        }

        //Button Lập Phiếu Đổi Hàng
        private void btLapPhieuDoi_Click(object sender, EventArgs e)
        {
            if (pdt == null)
            {
                if (hdb == null)
                {
                    lbWarningPD.Text = "Hãy chọn hóa đơn để lập phiếu !";
                }
                else
                {
                    pdt = new PhieuDoiTra();
                    pdt = new PhieuDoiTra();
                    ctpdtl = new List<CTPhieuDoiTra>();
                    spchlt = new List<SanPham_CuaHang>();

                    pdt = setPhieuDoiTra(pdt);
                    lbWarningPD.Text = "Lập Phiếu Đổi thành công";

                    lbMaPhieuDoi.Text = pdt.maPhieuDoiTra;
                    lbTenNVThucHien.Text = nv.tenNhanVien;
                }

            }
            else
            {
                lbWarningPD.Text = "Lập Phiếu Đổi đã được lập";
            }
        }


        // Button Đổi Hóa Đơn
        private void btDHD_PDT_Click(object sender, EventArgs e)
        {
            loadHoaDonBan_PDT();
            dgSPDT.Hide();
            resetPDT();
        }
        // Button Xem CT Phiếu Đổi
        private void btXemCTPD_Click(object sender, EventArgs e)
        {
            if (pdt == null)
                lbWarningPD.Text = "Hãy lập phiếu trước !";
            else
            {
                dgCTPD.DataSource = null;
                // Load CT Phiếu ĐỔi                                
                loadCTPD(ctpdtl);

                lbMaPD_CTPD.Text = pdt.maPhieuDoiTra;

                //lbTonTienCTPD.Text 
                tabNhanVienMenu.SelectedTab = tabNhanVienMenu.TabPages["tabCTPDCont"];
            }
        }
        //Load CT Phiếu ĐỔi
        private void loadCTPD(List<CTPhieuDoiTra> ctpdtl)
        {
            double tongTien = 0;
            double tongTienRe = 0;
            dgCTPD.DataSource = ctpdtl;
            dgCTPD.Columns["maPhieuDoiTra"].Visible = false;
            dgCTPD.Columns["giamGia"].Visible = false;
            dgCTPD.Columns["maSPTheoSize"].HeaderText = "Mã Sản Phẩm";
            dgCTPD.Columns["maSPTheoSizeRe"].HeaderText = "Mã Sản Phẩm Đổi";
            dgCTPD.Columns["soLuong"].HeaderText = "Số Lượng";

            if (!dgCTPD.Columns.Contains("priceunit"))
            {
                DataGridViewTextBoxColumn priceunit = new DataGridViewTextBoxColumn();
                priceunit.Name = "priceunit";
                priceunit.HeaderText = "Giá Tiền";
                dgCTPD.Columns.Add(priceunit);

                DataGridViewTextBoxColumn total = new DataGridViewTextBoxColumn();
                total.Name = "total";
                total.HeaderText = "Tổng";
                dgCTPD.Columns.Add(total);
            }
            foreach (DataGridViewRow row in dgCTPD.Rows)
            {
                string msp = row.Cells["maSPTheoSize"].Value.ToString().Split('_')[0];
                string mspre = row.Cells["maSPTheoSizeRe"].Value.ToString().Split('_')[0];

                int soLuong = Convert.ToInt32(row.Cells["soLuong"].Value);

                int donGia = spBLL.getSanPham(msp).donGiaNiemYet;
                int donGiaRe = spBLL.getSanPham(mspre).donGiaNiemYet;

                double giamgiax = (double)row.Cells["giamGia"].Value;

                row.Cells["priceunit"].Value = donGia;

                row.Cells["total"].Value = ((soLuong * donGia)- (soLuong * donGia* giamgiax)).ToString();

                tongTien += ((soLuong * donGia) - (soLuong * donGia * giamgiax));
                tongTienRe += ((soLuong * donGiaRe) - (soLuong * donGiaRe * giamgiax));
            }

            lbTongTienCTPD.Text = string.Format("{0:#,0}", tongTien);
            double check = tongTien - tongTienRe;

            if(check > 0)
            {
                lbTinhTienChenhLech.Text = "Khách hàng trả thêm " + string.Format("{0:#,0}", check) + " VND";
            }    

            else
            {
                check = check * -1;
                lbTinhTienChenhLech.Text = "Cửa hàng hoàn lại " + string.Format("{0:#,0}", check) + " VND";

            }    

        }
        private void CTHDList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            if (e.RowIndex >= 0 && e.RowIndex < CTHDList.RowCount)
            {
                lbMSP.Text = CTHDList.SelectedRows[0].Cells["maSanPhamTheoSize"].Value.ToString();
                txtSP_SoLuongMCTHD.Text = CTHDList.SelectedRows[0].Cells["soLuong"].Value.ToString();

            }
        }
        // Button Back to Phiếu Đổi
        private void btBackPD_Click(object sender, EventArgs e)
        {
            tabNhanVienMenu.SelectedTab = tabNhanVienMenu.TabPages["tabPhieuDoi"];
        }

        // Các Button trong CT Phiếu Đổi 
        private void resetCTPD()
        {
            lbMSP_CTPD.Text = "";
            lbWarningCTPD.Text = "";
            lbSoLuong_CTPD.Text = "";
            //lbTinhTienChenhLech.Text = "";
        }
        // Button Đổi số lượng CTPD
        private void btDoiSL_PD_Click(object sender, EventArgs e)
        {
            bool pnValid = pdtl.Exists(pdtx => pdtx.maPhieuDoiTra == pdt.maPhieuDoiTra);
            if (pnValid)
            {
                lbWarningCTPD.Text = "Phiếu Đổi Trả sau khi lưu không thể sửa ";
            }
            else
            {
                if (lbMSP_CTPD.Text == "")
                {
                    lbWarningCTPD.Text = "Hãy chọn sản phẩm muốn sửa !";
                }
                else
                {
                    if (lbSoLuong_CTPD.Text == "")
                        lbWarningCTPD.Text = "Hãy nhập số lượng cần đổi !";
                    else
                    {
                        int i = Convert.ToInt32(lbSoLuong_CTPD.Text);
                        int x = spchBLL.getSanPhamCuaHang(nv.maCuaHang, lbMSP_CTPD.Text).soLuong;
                        if (i <= x)
                        {
                            CTPhieuDoiTra sanPhamCanCapNhat = ctpdtl.FirstOrDefault(ctpdtx => ctpdtx.maSPTheoSize == lbMSP_CTPD.Text);
                            sanPhamCanCapNhat.soLuong = i;
                            dgCTPD.Refresh();
                            lbWarningCTPD.Text = "Đổi số lượng thành công !";
                        }    
                        else
                        {
                            lbWarningCTPD.Text = "Số lượng nhiều hơn cửa hàng đang có !";
                        }    
                    }
                }
            }
        }
        // Button Xóa số lượng CTPD
        private void btXoa_CTPD_Click(object sender, EventArgs e)
        {
            bool pnValid = pdtl.Exists(pdtx => pdtx.maPhieuDoiTra == pdt.maPhieuDoiTra);
            if (pnValid)
            {
                lbWarningCTPD.Text = "Phiếu Đổi sau khi lưu không thể xóa !";
            }
            else
            {
                if (lbMSP_CTPD.Text == "")
                    lbWarningCTPD.Text = "Hãy chọn sản Phẩm để xóa";
                else
                {
                    ctpdtl.RemoveAll(ctpd => ctpd.maSPTheoSize == lbMSP_CTPD.Text);
                    lbWarningCTPD.Text = "Xóa SP Thành công !";
                    //lbTinhTienChenhLech.Text = "";
                    dgCTPD.DataSource = null;
                    loadCTPD(ctpdtl);

                }
            }
        }

        private void btLuu_CTPD_Click(object sender, EventArgs e)
        {
            bool pnValid = pdtl.Exists(pdtx => pdtx.maPhieuDoiTra == pdt.maPhieuDoiTra);
            if (pnValid)
            {
                lbWarningCTPD.Text = "Phiếu Đổi đã được lưu";
            }
            else
            {
                if (ctpdtl.Count == 0)
                    lbWarningCTPD.Text = "Phiếu rỗng, không có gì để lưu ! ";
                else
                {
                    DialogResult result = MessageBox.Show("Bạn có chắc sẽ lưu Phiếu Đổi ?", "Phiếu Đổi", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                    if (result == DialogResult.OK)
                    {
                        bool checkThanhCong = true;
                        if (pdtBLL.addPhieuDoiTra(pdt))
                        {
                            foreach (CTPhieuDoiTra ctpdt in ctpdtl)
                            {
                                if (!pdtBLL.addCTPhieuDoiTra(ctpdt))
                                {
                                    checkThanhCong = false;
                                    break;
                                }
                                else
                                {
                                    // Giảm các sản phẩm có mã sản phẩm trong Phiếu Đổi của Cửa Hàng
                                    spch = spchBLL.getSanPhamCuaHang(nv.maCuaHang, ctpdt.maSPTheoSize);
                                    spch.soLuong = spch.soLuong - ctpdt.soLuong;
                                    spchBLL.updateSanPhamCuaHang(spch);

                                }
                            }

                            //Tăng các sản phẩm được đổi
                            foreach (SanPham_CuaHang spcht in spchlt)
                            {
                                spch = spchBLL.getSanPhamCuaHang(nv.maCuaHang, spcht.maSPTheoSize);
                                spch.soLuong = spch.soLuong + spcht.soLuong;
                                if (!spchBLL.updateSanPhamCuaHang(spch))
                                {
                                    checkThanhCong = false;
                                    break;
                                }
                            }
                            if (!checkThanhCong)
                            {
                                lbWarningCTPD.Text = "Lưu sản phẩm vào Phiếu Đổi thất bại !";
                            }
                            else
                            {
                                lbWarningCTPD.Text = "Lưu Phiếu Đổi Thành công !";
                                pdtl.Add(pdt);

                            }

                        }
                        else
                            lbWarningCTPD.Text = "Lưu Phiếu Đổi Thất Bại !";
                    }

                }
            }
        }

        private void dgCTPD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lbMSP_CTPD.Text = dgCTPD.SelectedRows[0].Cells["maSPTheoSize"].Value.ToString();
            lbSoLuong_CTPD.Text = dgCTPD.SelectedRows[0].Cells["soLuong"].Value.ToString();
        }

        private void InPhieuDoi_Click(object sender, EventArgs e)
        {
            if (ctpdtl.Count != 0)
            {
                bool pnValid = pdtl.Exists(hdn => hdn.maPhieuDoiTra == pdt.maPhieuDoiTra);
                if (pnValid)
                {

                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result = MessageBox.Show("Bạn muốn xem trước Phiếu Đổi:", "Lựa chọn", buttons, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (result == DialogResult.Yes)
                    {
                        printPreviewPD.Document = printPD;
                        printPreviewPD.ShowDialog();
                    }
                    else
                    {
                        printDialogPD.Document = printPD;
                        DialogResult result1 = printDialogPD.ShowDialog();
                        if (result1 == DialogResult.OK)
                        {
                            printPD.Print();
                        }
                    }


                }
                else
                {
                    lbWarningCTPD.Text = " Hãy lưu phiếu đổi trước !";
                }
            }
            else
                lbWarningCTPD.Text = "Phiếu đổi rỗng";
        }
        private void printPD_PrintPage(object sender, PrintPageEventArgs e)
        {

            pBLL.VePhieuDoi(nv, ch, ctpdtl, e,GetKhach());

        }
        //=============================== Tác Vụ Trả Hàng ====================================

        private void switchDoiTra()
        {
            if (xldt.maXuLyDoiTra == "1")
            {
                btLapPhieuDoi.Show();
                btXemCTPD.Show();
                btTraHang.Hide();
                panPhieuDoiInfo.Show();
                panPhieuTraInfo.Hide();
                btXemPhieuTra.Hide();
                btLapPhieuTra.Hide();
            }
            else
            {
                btLapPhieuDoi.Hide();
                btXemCTPD.Hide();
                panPhieuDoiInfo.Hide();
                btTraHang.Show();
                panPhieuTraInfo.Show();
                btXemPhieuTra.Show();
                btLapPhieuTra.Show();
            }
        }
        // Load Chi Tiết Phiếu Trả Hàng
        private void loadCTPT(List<CTPhieuDoiTra> ctpdtl)
        {
            dgCTPT.DataSource = ctpdtl;
            dgCTPT.Columns["maSPTheoSize"].HeaderText = "Mã SP";
            dgCTPT.Columns["maSPTheoSizeRe"].HeaderText = "Mã SP Được Trả";
            dgCTPT.Columns["soLuong"].HeaderText = "Số lượng";
            dgCTPT.Columns["giamGia"].Visible = false;
            dgCTPT.Columns["maPhieuDoiTra"].Visible = false;

            double tongTien = 0;
            foreach (CTPhieuDoiTra ctpdt in ctpdtl)
            {
                double thanhTien = 0;
                String msp = ctpdt.maSPTheoSize.Split('_')[0];
                int gia = spBLL.getSanPham(msp).donGiaNiemYet;
                thanhTien = ((gia * ctpdt.soLuong) - (gia * ctpdt.soLuong * ctpdt.giamGia));
                tongTien += thanhTien ;
            }
            

            lbTongTien_CTPT.Text = tongTien.ToString() + "VNĐ";
        }
        private void btPhieuTra_Click(object sender, EventArgs e)
        {
            if (txtKHNVMaKH.Text == "")
                lbWarningKH.Text = "Hãy chọn Khách Hàng để lập phiếu trả !";
            else
            {
                tabNhanVienMenu.SelectedTab = tabNhanVienMenu.TabPages["tabPhieuDoi"];

                // Load Thông tin Khách Hàng
                loadKhachHangPDT(pnSPNVLeft, pnPDTLeft);
                flPicSP.Hide();
                // Load Các Hóa Đơn Bán
                loadHoaDonBan_PDT();

                xldt.maXuLyDoiTra = "2";
                switchDoiTra();
            }
        }

        private void btTraHang_Click(object sender, EventArgs e)
        {
            if (pdt == null)
            {
                lbWarningPD.Text = " Hãy lập phiếu trả !";
                return;
            }
            if (lbMSP_PT.Text == "")
            {
                lbWarningPD.Text = "Hãy chọn sản phẩm để trả !";
            }
            else
            {
                if (lbSoLuong_PT.Text == "")
                    lbWarningPD.Text = "Hãy nhập số lượng sản phẩm muốn trả !";
                else
                {
                    bool maSanPhamValid = ctpdtl.Exists(ct => ct.maSPTheoSize == lbMSP_PT.Text);

                    if (!maSanPhamValid)
                    {
                        int i = Convert.ToInt32(lbSoLuong_PT.Text);
                        int soluongSPInHoaDon = Convert.ToInt32(lbSoLuongSPCo.Text);

                        if (i <= 0 || i > soluongSPInHoaDon)
                            lbWarningPD.Text = "Số lượng sản phẩm không hợp lệ !";
                        else
                        {
                            ctpdt = new CTPhieuDoiTra();
                            ctpdt.maPhieuDoiTra = pdt.maPhieuDoiTra;
                            ctpdt.maSPTheoSize = lbMSP_PT.Text;
                            ctpdt.soLuong = i;
                            ctpdt.maSPTheoSizeRe = lbMSP_PT.Text;
                            ctpdt.giamGia = giamgia;
                            ctpdtl.Add(ctpdt);
                            lbWarningPD.Text = "Trả thành công !";
                        }
                    }
                }
            }
        }
        // Button Lập Phiếu Trả
        private void btLapPhieuTra_Click(object sender, EventArgs e)
        {
            if (pdt == null)
            {
                if (hdb == null)

                {
                    lbWarningPD.Text = "Hãy chọn hóa đơn để lập phiếu trả !";
                }
                else
                {
                    pdt = new PhieuDoiTra();
                    ctpdtl = new List<CTPhieuDoiTra>();

                    pdt = setPhieuDoiTra(pdt);
                    lbWarningPD.Text = "Lập Phiếu Trả thành công";
                }
            }
            else
            {
                lbWarningPD.Text = "Phiếu Trả đã được lập";
            }
        }
        // Button Xem Phiếu Trả
        private void btXemPhieuTra_Click(object sender, EventArgs e)
        {
            if (pdt == null)
                lbWarningPD.Text = "Hãy lập phiếu trước !";
            else
            {
                dgCTPT.DataSource = null;

                loadCTPT(ctpdtl);

                lbMPT_CTPT.Text = pdt.maPhieuDoiTra;


                tabNhanVienMenu.SelectedTab = tabNhanVienMenu.TabPages["tabCTPT"];

            }
        }

        private void dgCTPT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                lbMSP_CTPT.Text = dgCTPT.Rows[e.RowIndex].Cells["maSPTheoSize"].Value.ToString();
                lbSoLuong_CTPT.Text = dgCTPT.Rows[e.RowIndex].Cells["soLuong"].Value.ToString();
            }
        }

        private void btBackToPT_Click(object sender, EventArgs e)
        {
            tabNhanVienMenu.SelectedTab = tabNhanVienMenu.TabPages["tabPhieuDoi"];
        }

        // Button Xóa CT Phiếu Trả
        private void btXoaCTPT_Click(object sender, EventArgs e)
        {
            bool pnValid = pdtl.Exists(pdtx => pdtx.maPhieuDoiTra == pdt.maPhieuDoiTra);
            if (pnValid)
            {
                lbWarningCTPT.Text = "Phiếu Trả sau khi lưu không thể xóa !";
            }
            else
            {
                if (lbMSP_CTPT.Text == "")
                    lbWarningCTPT.Text = "Hãy chọn sản Phẩm để Xóa";
                else
                {
                    ctpdtl.RemoveAll(ctpd => ctpd.maSPTheoSize == lbMSP_CTPT.Text);
                    lbWarningCTPT.Text = "Xóa SP Thành công !";
                    dgCTPT.DataSource = null;
                    loadCTPT(ctpdtl);

                    lbSoLuong_CTPT.Text = "";
                    lbMSP_CTPT.Text = "";
                }
            }
        }
        // Button Lưu CT Phiếu Trả
        private void btLuuCTPT_Click(object sender, EventArgs e)
        {
            bool pdtValid = pdtl.Exists(pnn => pnn.maPhieuDoiTra == pdt.maPhieuDoiTra);
            if (pdtValid)
            {
                lbWarningCTPT.Text = "Phiếu Trả đã được lưu";
            }
            else
            {
                if (ctpdtl.Count == 0)
                    lbWarningCTPT.Text = "Phiếu rỗng, không có gì để lưu ! ";
                else
                {
                    DialogResult result = MessageBox.Show("Bạn có chắc sẽ lưu Phiếu Trả ?", "Phiếu Trả", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                    if (result == DialogResult.OK)
                    {
                        if (pdtBLL.addPhieuDoiTra(pdt))
                        {
                            bool checkThanhCong = true;

                            foreach (CTPhieuDoiTra ctpdt in ctpdtl)
                            {
                                if (!pdtBLL.addCTPhieuDoiTra(ctpdt))
                                {
                                    checkThanhCong = false;
                                    break;
                                }
                                else
                                {
                                    spch = spchBLL.getSanPhamCuaHang(nv.maCuaHang, ctpdt.maSPTheoSize);
                                    spch.soLuong = spch.soLuong + ctpdt.soLuong;
                                    spchBLL.updateSanPhamCuaHang(spch);
                                }
                            }
                            if (!checkThanhCong)
                            {
                                lbWarningCTPT.Text = "Lưu sản phẩm vào Phiếu Trả thất bại !";
                            }
                            else
                            {
                                lbWarningCTPT.Text = "Lưu Phiếu Trả Thành công !";
                                pdtl.Add(pdt);

                            }

                        }
                        else
                            lbWarningCTPT.Text = "Lưu Phiếu Trả Thất Bại !";
                    }

                }
            }
        }

        private void btInPhieuTra_Click(object sender, EventArgs e)
        {
            {
                if (ctpdtl.Count != 0)
                {
                    bool pnValid = pdtl.Exists(hdn => hdn.maPhieuDoiTra == pdt.maPhieuDoiTra);
                    if (pnValid)
                    {

                        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                        DialogResult result = MessageBox.Show("Bạn muốn xem trước Phiếu Trả:", "Lựa chọn", buttons, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if (result == DialogResult.Yes)
                        {
                            printPreviewPD.Document = printPT;
                            printPreviewPD.ShowDialog();
                        }
                        else
                        {
                            printDialogPD.Document = printPT;
                            DialogResult result1 = printDialogPD.ShowDialog();
                            if (result1 == DialogResult.OK)
                            {
                                printPT.Print();
                            }
                        }

                    }
                    else
                    {
                        lbWarningCTPT.Text = " Hãy lưu phiếu trả trước !";
                    }
                }
                else
                    lbWarningCTPT.Text = "Phiếu trả rỗng";
            }
        }
        private void printPT_PrintPage(object sender, PrintPageEventArgs e)
        {
            pBLL.VePhieuTra(nv, ch, ctpdtl, e, GetKhach());
        }

    }
}