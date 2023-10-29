using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Forms
{
    public partial class FQLPhieuNhap : Form
    {
        List<ChiTietPhieuNhapKho> ctpnkTam = null;
        List<SanPham_CuaHang> spchTam = null;
        int rowCountSLSPPN = 0;
        public FQLPhieuNhap()
        {
            InitializeComponent();
            loadCbMaNhaSX();
            loadCbMaSanPham();
            loadCbMaSize();
            dgvCTPhieuNhapKho.AutoGenerateColumns = false;
            LoadDsPhieuNhapKho();
            LoadDsNSX();
            ctpnkTam = new List<ChiTietPhieuNhapKho>();
        }

        private void loadCbMaNhaSX()
        {
            BLL.NhaSanXuatBLL nSXBLL = new BLL.NhaSanXuatBLL();
            List<NhaSanXuat> NhaSX = nSXBLL.getNhaSX();

            // Xóa tất cả các mục hiện tại trong ComboBox (nếu có)
            cbNSX.Items.Clear();
            // Thêm danh sách "maNSX" vào ComboBox
            foreach (NhaSanXuat nsx in NhaSX)
            {
                cbNSX.Items.Add(nsx.maNhaSanXuat);
            }
        }
        private void loadCbMaSanPham()
        {
            BLL.SanPhamBLL spBLL = new BLL.SanPhamBLL();
            List<SanPham> msp = spBLL.LoadDlSanPham();

            // Xóa tất cả các mục hiện tại trong ComboBox (nếu có)

            cbMSPPNK.Items.Clear();
            // Thêm danh sách "maNSX" vào ComboBox
            foreach (SanPham sp in msp)
            {
                cbMSPPNK.Items.Add(sp.maSanPham);

            }
        }
        private void loadCbMaSize()
        {
            BLL.SizeBLL sizeBLL = new BLL.SizeBLL();
            List<DTO.Size> sizelist = sizeBLL.GetSizes(); // Sử dụng DTO.Size để chỉ rõ bạn đang sử dụng Size từ DTO

            // Xóa tất cả các mục hiện tại trong ComboBox (nếu có)

            cbSizePNK.Items.Clear();

            // Thêm danh sách các size vào ComboBox
            foreach (DTO.Size size in sizelist) // Sử dụng DTO.Size để chỉ rõ bạn đang sử dụng Size từ DTO
            {
                // Sử dụng thuộc tính hoặc phương thức của đối tượng Size để lấy giá trị cần hiển thị trong ComboBox

                cbSizePNK.Items.Add(size.maSize);
            }
        }
        private void btnThemSPPNK_Click(object sender, EventArgs e)
        {
            
            if (txtMaPhieuNhapKho.ReadOnly == true)
            {
                MessageBox.Show("Phiếu nhập đã được nhập!!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (string.IsNullOrWhiteSpace(cbMSPPNK.Text) ||
                string.IsNullOrWhiteSpace(cbSizePNK.Text) ||
                string.IsNullOrWhiteSpace(txtSLSPPNK.Text) 
                )
                {
                    MessageBox.Show("Vui lòng chọn sản phẩm cần thêm.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    string maSize = cbSizePNK.Text;
                    int soLuong = int.Parse(txtSLSPPNK.Text);
                    string maSP = cbMSPPNK.Text;
                    string mpnk = txtMaPhieuNhapKho.Text;
                    bool maSanPhamValid = ctpnkTam.Exists(ct => ct.maSPTheoSize == maSP + '_' + maSize);
                    if (!maSanPhamValid)
                    {

                        ChiTietPhieuNhapKho ctpnk = new ChiTietPhieuNhapKho();
                        ctpnk.maPhieuNhap = mpnk;
                        ctpnk.maSPTheoSize = maSP + '_' + maSize;
                        ctpnk.soLuong = soLuong;
                        ctpnkTam.Add(ctpnk);
                        txtSLSPPNK.Clear();
                        cbSizePNK.SelectedIndex = -1;
                        cbMSPPNK.SelectedIndex = -1;
                        dgvCTPhieuNhapKho.DataSource = null;
                        loadCTHDList(ctpnkTam);
                    }
                    else
                    {
                        MessageBox.Show("Sản phẩm đã được thêm!!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void loadCTHDList(List<ChiTietPhieuNhapKho> ctpnk)
        {
            dgvCTPhieuNhapKho.DataSource = ctpnk;
        }

        private void btnSuaSLPNK_Click(object sender, EventArgs e)
        {
            if (cbMSPPNK.Text == "")
                MessageBox.Show("Hãy chọn sản phẩm để sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (cbSizePNK.Text == "")
            {
                MessageBox.Show("Hãy chọn size để sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);


            }
            else if (txtSLSPPNK.Text == "")
            {
                MessageBox.Show("Hãy nhập số lượng để sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                string maSPTheoSize = cbMSPPNK.Text + '_' + cbSizePNK.Text;

                // Tìm sản phẩm trong danh sách ctpnkTam
                ChiTietPhieuNhapKho sanPhamCanCapNhat = ctpnkTam.FirstOrDefault(ctpn => ctpn.maSPTheoSize == maSPTheoSize);

                if (sanPhamCanCapNhat != null)
                {
                    sanPhamCanCapNhat.soLuong = Convert.ToInt32(txtSLSPPNK.Text);
                    dgvCTPhieuNhapKho.Refresh();
                    MessageBox.Show("Sửa số lượng cho sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sản phẩm để sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnLuuPhieuNhapKho_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaPhieuNhapKho.Text) ||
                string.IsNullOrWhiteSpace(cbNSX.Text))

            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin phiếu nhập kho.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                string mpnk = txtMaPhieuNhapKho.Text;
            PhieuNhapKhoBLL pnkBLL = new PhieuNhapKhoBLL();
            PhieuNhapKho kiemtraPNK = pnkBLL.getPhieuNhapKho(mpnk);
                if (kiemtraPNK != null)
                {
                    // Mã sản phẩm đã tồn tại, hiển thị cảnh báo cho người dùng
                    MessageBox.Show("Phiếu nhập kho đã được nhập!!!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    if (ctpnkTam.Count == 0)
                        MessageBox.Show("Phiếu nhập rỗng, không có gì để lưu ", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {

                        DialogResult result = MessageBox.Show("Bạn có chắc sẽ lưu phiếu nhập kho?", "Phiếu nhập", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                        try
                        {


                            string mnsx = cbNSX.Text;
                            DateTime ngayNhap = dateNgayNhapKho.Value;



                            PhieuNhapKho pnk = new PhieuNhapKho()
                            {
                                maPhieuNhap = mpnk,
                                maNhaSanXuat = mnsx,
                                ngayNhap = ngayNhap,
                            };
                            pnkBLL.ThemPhieuNhapKho(pnk);



                            foreach (ChiTietPhieuNhapKho ctpnkl in ctpnkTam)
                            {
                                MaSanPhamTheoSizeBLL msptsBLL = new MaSanPhamTheoSizeBLL();
                                List<MaSanPhamTheoSize> msptsList = msptsBLL.LoadDlMaSPTheoSize();
                                MaSanPhamTheoSize maSPtheoSize = msptsList.SingleOrDefault(s => s.maSPTheoSize == ctpnkl.maSPTheoSize);
                                if (msptsBLL.KiemTraMaSPTSTonTai(ctpnkl.maSPTheoSize))
                                {
                                    MaSanPhamTheoSize spts = new MaSanPhamTheoSize
                                    {

                                        maSize = ctpnkl.maSPTheoSize.Split('_')[1],
                                        maSanPham = ctpnkl.maSPTheoSize.Split('_')[0],
                                        soLuongTonKho = maSPtheoSize.soLuongTonKho + ctpnkl.soLuong
                                    };

                                    // Gọi phương thức ThemSizeVaSoLuong từ lớp MaSanPhamTheoSizeBLL để thêm số lượng size cho sản phẩm
                                    msptsBLL.SuaSoLuongTonKho(spts);
                                }
                                else
                                {

                                    MaSanPhamTheoSize spts = new MaSanPhamTheoSize
                                    {
                                        maSPTheoSize = ctpnkl.maSPTheoSize,
                                        maSize = ctpnkl.maSPTheoSize.Split('_')[1],
                                        maSanPham = ctpnkl.maSPTheoSize.Split('_')[0],
                                        soLuongTonKho = ctpnkl.soLuong
                                    };

                                    // Gọi phương thức ThemSizeVaSoLuong từ lớp MaSanPhamTheoSizeBLL để thêm số lượng size cho sản phẩm
                                    msptsBLL.ThemSizeVaSoLuong(spts);


                                }

                                ChiTietPhieuNhapKho ctpnk = new ChiTietPhieuNhapKho()
                                {
                                    maPhieuNhap = mpnk,
                                    maSPTheoSize = ctpnkl.maSPTheoSize,
                                    soLuong = ctpnkl.soLuong,
                                };
                                pnkBLL.ThemCTPhieuNhapKho(ctpnk);
                                // Sau khi thêm sản phẩm, bạn có thể cập nhật DataGridView để hiển thị danh sách sản phẩm mới

                            }

                            MessageBox.Show("Lưu phiếu nhập kho thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadDsPhieuNhapKho();

                        }

                        catch (Exception ex)
                        {
                            MessageBox.Show("Không thể thêm sản phẩm cho cửa hàng. Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            ctpnkTam.Clear();
                            dgvCTPhieuNhapKho.DataSource = null;
                        }

                    }
                }
            }
        }

     
        private void LoadDsPhieuNhapKho()
        {
            PhieuNhapKhoBLL pnkBLL = new PhieuNhapKhoBLL();
            List<PhieuNhapKho>  dspnkGui = pnkBLL.getPhieuNhapKhoList();
            dgvPhieuNhapKho.Rows.Clear();
            foreach (PhieuNhapKho pn in dspnkGui)
            {
                // Tạo một hàng mới trong DataGridView
                DataGridViewRow row = new DataGridViewRow();

                // Thêm các ô thông tin từ đối tượng SanPham vào các ô trong hàng
                row.Cells.Add(new DataGridViewTextBoxCell { Value = pn.maPhieuNhap });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = pn.maNhaSanXuat });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = pn.ngayNhap });
                // Thêm hàng vào DataGridView
                dgvPhieuNhapKho.Rows.Add(row);
            }
        }

        private void LoadCTPhieuNhapKho(string mpnk)
        {

            PhieuNhapKhoBLL pnkBLL = new PhieuNhapKhoBLL();
            // Gọi phương thức để lấy danh sách chi tiết phiếu nhập dựa trên maPhieuNhap
            List<ChiTietPhieuNhapKho> danhSachChiTiet = pnkBLL.getCTPhieuNhapKho(new PhieuNhapKho { maPhieuNhap = mpnk });
            // Xóa dữ liệu hiện có trong DataGridView
            dgvCTPhieuNhapKho.DataSource = null;

            // Thiết lập nguồn dữ liệu mới cho DataGridView
            dgvCTPhieuNhapKho.DataSource = danhSachChiTiet;

        }

        private void dgvPhieuNhapKho_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            // Kiểm tra xem có phải là cột bạn quan tâm không (ví dụ: cột maPhieuNhap ở cột 0)
            if (e.RowIndex >= 0 && e.RowIndex < dgvPhieuNhapKho.Rows.Count)
            {
                DataGridViewRow selectedRow = dgvPhieuNhapKho.Rows[e.RowIndex];
                // Lấy giá trị maPhieuNhap từ ô được chọn
                string maPhieuNhap = selectedRow.Cells["maPhieuNhapKho"].Value.ToString();
                
                txtMaPhieuNhapKho.Text = maPhieuNhap;
                txtMaPhieuNhapKho.ReadOnly = true;
                cbNSX.Text = selectedRow.Cells["maNSXPhieuNhapKho"].Value.ToString();
                string ngayNhapPhieuNhapKho = selectedRow.Cells["ngayNhapPhieuNhapKho"].Value.ToString();
                if (DateTime.TryParse(ngayNhapPhieuNhapKho, out DateTime ngay))
                {
                    dateNgayNhapKho.Value = ngay;
                }
                // Gọi phương thức để tải dgvChiTietPN dựa trên maPhieuNhap
                LoadCTPhieuNhapKho(maPhieuNhap);
            }
        }

        private void btnNhapLaiPNK_Click(object sender, EventArgs e)
        {
            txtMaPhieuNhapKho.ReadOnly = false;
            txtMaPhieuNhapKho.Clear();
            dateNgayNhapKho.ResetText();
            cbNSX.SelectedIndex = -1;
            txtSLSPPNK.Clear();
            cbSizePNK.SelectedIndex = -1;
            cbMSPPNK.SelectedIndex = -1;
            ctpnkTam.Clear();
            dgvCTPhieuNhapKho.DataSource = null;
        }

        private void btnThemNSX_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNSX.Text) ||
            string.IsNullOrWhiteSpace(txtTenNSX.Text) ||
            string.IsNullOrWhiteSpace(txtSDTNSX.Text) ||
            string.IsNullOrWhiteSpace(txtDiaChiNSX.Text) ||
            string.IsNullOrWhiteSpace(txtEmailNSX.Text) ||
            string.IsNullOrWhiteSpace(txtWebsiteNSX.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin nhà sản xuất.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                string maNSX = txtMaNSX.Text;
                NhaSanXuatBLL nsxBLL = new NhaSanXuatBLL();
                // Kiểm tra xem mã nhà sản xuất đã tồn tại trong danh sách NhaSX
                NhaSanXuat kiemTraMNSX = nsxBLL.getNhaSX().FirstOrDefault(x => x.maNhaSanXuat == maNSX);

                if (kiemTraMNSX != null)
                {
                    MessageBox.Show("Mã nhà sản xuất đã tồn tại.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    try
                    {
                        NhaSanXuat nsx = new NhaSanXuat
                        {
                            maNhaSanXuat = maNSX,
                            tenNhaSanXuat = txtTenNSX.Text,
                            soDienThoai = txtSDTNSX.Text,
                            diaChi = txtDiaChiNSX.Text,
                            email = txtEmailNSX.Text,
                            website = txtWebsiteNSX.Text,

                        };
                        nsxBLL.ThemNSX(nsx);
                        MessageBox.Show("Nhà sản xuất được thêm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDsNSX();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Không thể thêm nhà sản xuất. Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void LoadDsNSX()
        {
            NhaSanXuatBLL nsxBLL = new BLL.NhaSanXuatBLL();
            List<NhaSanXuat> dsnsxGui = nsxBLL.getNhaSX();
            dgvNSX.Rows.Clear();
            foreach (NhaSanXuat nsx in dsnsxGui)
            {
                // Tạo một hàng mới trong DataGridView
                DataGridViewRow row = new DataGridViewRow();

                // Thêm các ô thông tin từ đối tượng SanPham vào các ô trong hàng
                row.Cells.Add(new DataGridViewTextBoxCell { Value = nsx.maNhaSanXuat });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = nsx.tenNhaSanXuat });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = nsx.soDienThoai });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = nsx.diaChi });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = nsx.email });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = nsx.website });
                // Thêm hàng vào DataGridView
                dgvNSX.Rows.Add(row);
            }
        }

        private void btnSuaNSX_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNSX.Text) ||
            string.IsNullOrWhiteSpace(txtTenNSX.Text) ||
            string.IsNullOrWhiteSpace(txtSDTNSX.Text) ||
            string.IsNullOrWhiteSpace(txtDiaChiNSX.Text) ||
            string.IsNullOrWhiteSpace(txtEmailNSX.Text) ||
            string.IsNullOrWhiteSpace(txtWebsiteNSX.Text))
            {
                MessageBox.Show("Vui lòng chọn nhà sản xuất.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                try
                {

                    NhaSanXuat nsx = new NhaSanXuat
                    {
                        maNhaSanXuat = txtMaNSX.Text,
                        tenNhaSanXuat = txtTenNSX.Text,
                        soDienThoai = txtSDTNSX.Text,
                        diaChi = txtDiaChiNSX.Text,
                        email = txtEmailNSX.Text,
                        website = txtWebsiteNSX.Text,

                    };


                    NhaSanXuatBLL nsxBLL = new NhaSanXuatBLL();
                    nsxBLL.SuaNSX(nsx);


                    MessageBox.Show("Sửa nhà sản xuất thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    LoadDsNSX();
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Sửa nhà sản xuất thất bại. Lỗi: " + exception.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void dgvNSX_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvNSX.Rows.Count)
            {
                DataGridViewRow selectedRow = dgvNSX.Rows[e.RowIndex];
                txtMaNSX.Text = selectedRow.Cells["maNSX"].Value.ToString();
                txtMaNSX.ReadOnly = true; // không cho sửa mã
                txtTenNSX.Text = selectedRow.Cells["tenNSX"].Value.ToString();
                txtSDTNSX.Text = selectedRow.Cells["sdtNSX"].Value.ToString();
                txtDiaChiNSX.Text = selectedRow.Cells["diaChiNSX"].Value.ToString();
                txtEmailNSX.Text = selectedRow.Cells["emailNSX"].Value.ToString();
                txtWebsiteNSX.Text = selectedRow.Cells["websiteNSX"].Value.ToString();
            }
        }
        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ngăn chặn ký tự không phải số được nhập vào TextBox
            }
            if (e.KeyChar == '-' && ((sender as TextBox).Text.IndexOf('-') >= 0 || (sender as TextBox).SelectionStart != 0))
            {
                e.Handled = true; // Ngăn người dùng nhập thêm dấu trừ '-'
            }
        }
        private void btnXoaNSX_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNSX.Text) ||
            string.IsNullOrWhiteSpace(txtTenNSX.Text) ||
            string.IsNullOrWhiteSpace(txtSDTNSX.Text) ||
            string.IsNullOrWhiteSpace(txtDiaChiNSX.Text) ||
            string.IsNullOrWhiteSpace(txtEmailNSX.Text) ||
            string.IsNullOrWhiteSpace(txtWebsiteNSX.Text))
            {
                MessageBox.Show("Vui lòng chọn nhà sản xuất.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                try
                {
                    if (MessageBox.Show("Bạn có thật sự muốn xóa nhà sản xuất này?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string maNSX = txtMaNSX.Text;
                        NhaSanXuatBLL nsxBLL = new NhaSanXuatBLL();
                        bool isForeignKey = nsxBLL.IsForeignKeyInOtherTables(maNSX);
                        if (isForeignKey)
                        {
                            MessageBox.Show("Xóa nhà sản xuất thất bại. Do thông tin nhà sản xuất đang được lưu.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }
                        else
                        {
                            nsxBLL.XoaNSX(maNSX);
                            MessageBox.Show("Xóa nhà sản xuất thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadDsNSX();
                        }
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Xóa nhà sản xuất thất bại. Lỗi: " + exception.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnNhapLaiNSX_Click(object sender, EventArgs e)
        {
            txtMaNSX.ReadOnly = false;
            txtMaNSX.Clear();
            txtTenNSX.Clear();
            txtSDTNSX.Clear();
            txtDiaChiNSX.Clear();
            txtEmailNSX.Clear();
            txtWebsiteNSX.Clear();
        }

        private void dgvCTPhieuNhapKho_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvCTPhieuNhapKho.Rows.Count)
            {
                DataGridViewRow selectedRow = dgvCTPhieuNhapKho.Rows[e.RowIndex];
                string maSP = selectedRow.Cells["maSPPNK"].Value.ToString();
                string maSize = selectedRow.Cells["maSPPNK"].Value.ToString();
                cbMSPPNK.Text = maSP.Split('_')[0];
                cbSizePNK.Text = maSize.Split('_')[1];
                txtSLSPPNK.Text = selectedRow.Cells["soLuongSPPNK"].Value.ToString();
            }
        }

        //===========================Cửa hàng==============================

        List<PhieuNhap> dspnGui;
        private void loadPhieuNhapList()
        {
            NhanVien nv = null;
            PhieuNhapBLL pnBLL = new PhieuNhapBLL();
            dspnGui = pnBLL.getPhieuNhapList(nv);
            dgvPhieuNhap.Rows.Clear();
            string tt = null;
            foreach (PhieuNhap pn in dspnGui)
            {
                // Tạo một hàng mới trong DataGridView
                DataGridViewRow row = new DataGridViewRow();
                if(pn.trangThai == true)
                {
                    tt = "Đã nhập";
                }
                else
                {
                    tt = "Chưa nhập";
                }
                // Thêm các ô thông tin từ đối tượng SanPham vào các ô trong hàng
                row.Cells.Add(new DataGridViewTextBoxCell { Value = pn.maPhieuNhap });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = pn.maNhanVien });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = pn.maCuaHang });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = pn.ngayNhap });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = tt });

                // Thêm hàng vào DataGridView
                dgvPhieuNhap.Rows.Add(row);
            }
        }

        private void dgvPhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem có phải là cột bạn quan tâm không (ví dụ: cột maPhieuNhap ở cột 0)
            if (e.RowIndex >= 0 && e.RowIndex < dgvPhieuNhap.Rows.Count)
            {
                DataGridViewRow selectedRow = dgvPhieuNhap.Rows[e.RowIndex];
                // Lấy giá trị maPhieuNhap từ ô được chọn
                string maPhieuNhap = dgvPhieuNhap.Rows[e.RowIndex].Cells[0].Value.ToString();
                string maCuaHang = dgvPhieuNhap.Rows[e.RowIndex].Cells[2].Value.ToString();
                // Gọi phương thức để tải dgvChiTietPN dựa trên maPhieuNhap
                LoadChiTietPhieuNhap(maPhieuNhap);
                LoadSPCHPN(maCuaHang);
                txtMaCHPN.Text = selectedRow.Cells["maCuaHangPN"].Value.ToString();
                txtMaPN.Text = selectedRow.Cells["maPhieuNhap"].Value.ToString();
                txtMaNVPN.Text = selectedRow.Cells["maNhanVienPN"].Value.ToString();
                string ngayNhapPhieuNhap = selectedRow.Cells["ngayNhapPN"].Value.ToString();
                if (DateTime.TryParse(ngayNhapPhieuNhap, out DateTime ngay))
                {
                    dateNgayNhapPN.Value = ngay;
                }
                txtTrangThaiPN.Text = selectedRow.Cells["trangThaiPN"].Value.ToString();
                spchTam = new List<SanPham_CuaHang>();
                if (txtTrangThaiPN.Text == "Đã nhập")
                {
                    lbSLSP.Text = "Đã thêm";
                    lbSLSP.BackColor = Color.Green;
                }
                else
                {
                    lbSLSP.Text = "Chưa thêm";
                    lbSLSP.BackColor = Color.Red;
                }

            }
        }

        private void LoadChiTietPhieuNhap(string mpn)
        {
            PhieuNhapBLL pnBLL = new PhieuNhapBLL();
            // Gọi phương thức để lấy danh sách chi tiết phiếu nhập dựa trên maPhieuNhap
            List<ChiTietPhieuNhap> danhSachChiTiet = pnBLL.getCTPhieuNhap(new PhieuNhap { maPhieuNhap = mpn });

            // Xóa các dòng hiện tại trong dgvChiTietPN (nếu có)
            dgvChiTietPN.Rows.Clear();

            // Thêm các dòng mới từ danh sách chi tiết phiếu nhập vào dgvChiTietPN
            foreach (ChiTietPhieuNhap ctpn in danhSachChiTiet)
            {
                // Tạo một hàng mới trong DataGridView
                DataGridViewRow row = new DataGridViewRow();

                // Thêm các ô thông tin từ đối tượng ChiTietPhieuNhap vào các ô trong hàng
                row.Cells.Add(new DataGridViewTextBoxCell { Value = ctpn.maPhieuNhap });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = ctpn.maSPTheoSize });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = ctpn.soLuong.ToString() });

                // Thêm hàng vào DataGridView
                dgvChiTietPN.Rows.Add(row);
            }
            rowCountSLSPPN = dgvChiTietPN.RowCount - 1;
        }
        private void LoadSPCHPN(string mch)
        {
            SanPham_CuaHangBLL spchBLL = new SanPham_CuaHangBLL();
            // Gọi phương thức để lấy danh sách chi tiết phiếu nhập dựa trên maPhieuNhap
            List<SanPham_CuaHang> dsSPCH = spchBLL.getPNTheoCH(new SanPham_CuaHang { maCuaHang = mch });

            // Xóa các dòng hiện tại trong dgvChiTietPN (nếu có)
            dgvSPCHPN.Rows.Clear();

            // Thêm các dòng mới từ danh sách chi tiết phiếu nhập vào dgvChiTietPN
            foreach (SanPham_CuaHang spch in dsSPCH)
            {
                // Tạo một hàng mới trong DataGridView
                DataGridViewRow row = new DataGridViewRow();

                // Thêm các ô thông tin từ đối tượng ChiTietPhieuNhap vào các ô trong hàng
                row.Cells.Add(new DataGridViewTextBoxCell { Value = spch.maCuaHang });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = spch.maSPTheoSize });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = spch.soLuong.ToString() });

                // Thêm hàng vào DataGridView
                dgvSPCHPN.Rows.Add(row);
            }
        }


        private void dgvChiTietPN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvChiTietPN.Rows.Count)
            {
                DataGridViewRow selectedRow = dgvChiTietPN.Rows[e.RowIndex];
                string maSP = selectedRow.Cells["maSPTheoSizePN"].Value.ToString();

                txtMaSPPN.Text = maSP;
                txtsoLuongSPTSPN.Text = selectedRow.Cells["soLuongSPPN"].Value.ToString();
                if (txtTrangThaiPN.Text == "Chưa nhập")
                {


                    // Kiểm tra xem danh sách ctpnTam có dữ liệu không
                    if (spchTam == null)
                    {
                        // Nếu danh sách chưa được khởi tạo, mặc định là False
                        lbSLSP.Text = "Chưa thêm";
                        lbSLSP.BackColor = Color.Red;
                    }
                    else
                    {
                        // Kiểm tra xem mã sản phẩm đã được thêm vào danh sách ctpnTam hay chưa
                        if (spchTam.Any(item => item.maSPTheoSize == maSP))
                        {
                            // Nếu đã thêm, giữ nguyên giá trị True
                            lbSLSP.Text = "Đã thêm";
                            lbSLSP.BackColor = Color.Green;

                        }
                        else
                        {
                            // Nếu chưa thêm, cập nhật giá trị False
                            lbSLSP.Text = "Chưa thêm";
                            lbSLSP.BackColor = Color.Red;
                        }
                    }
                }
                else
                {
                    lbSLSP.Text = "Đã thêm";
                    lbSLSP.BackColor = Color.Green;
                }
            }
        }

        private void btnThemSPPN_Click(object sender, EventArgs e)
        {
            // Lấy mã sản phẩm từ textbox
            string maSP = txtMaSPPN.Text;


            if (string.IsNullOrWhiteSpace(txtMaSPPN.Text) ||
                string.IsNullOrWhiteSpace(txtsoLuongSPTSPN.Text) 
                )
            {

                MessageBox.Show("Hãy chọn sản phẩm cần nhập cho cửa hàng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                if (txtTrangThaiPN.Text == "Chưa nhập")
                {
                    // Load số lượng tồn kho hiện tại từ cơ sở dữ liệu
                    MaSanPhamTheoSizeBLL msptsBLL = new MaSanPhamTheoSizeBLL();
                    List<MaSanPhamTheoSize> msptsList = msptsBLL.LoadDlMaSPTheoSize();
                    MaSanPhamTheoSize maSPtheoSize = msptsList.SingleOrDefault(s => s.maSPTheoSize == txtMaSPPN.Text);
                    bool anyProductExceedsInventory = false;
                    if (int.Parse(txtsoLuongSPTSPN.Text) > maSPtheoSize.soLuongTonKho)
                    {
                        anyProductExceedsInventory = true;
                        // Thoát khỏi vòng lặp khi có ít nhất một sản phẩm vượt quá tồn kho
                    }
                    // Kiểm tra xem mã sản phẩm đã được thêm vào danh sách ctpnTam hay chưa
                    if (anyProductExceedsInventory)
                    {
                        MessageBox.Show("Số lượng sản phẩm " + txtMaSPPN.Text + " vượt quá số lượng tồn kho. Không thể thêm sản phẩm.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    else
                    {

                        if (lbSLSP.Text == "Đã thêm")
                        {
                            MessageBox.Show("Không thêm được sản phẩm vì sản phẩm đã được thêm vào rồi!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            // Nếu đã thêm, giữ nguyên giá trị True
                            lbSLSP.Text = "Đã thêm";
                            lbSLSP.BackColor = Color.Green;
                        }
                        else
                        {
                            // Thêm mục vào danh sách ctpnTam
                            SanPham_CuaHang spch = new SanPham_CuaHang();
                            spch.maCuaHang = txtMaCHPN.Text;
                            spch.maSPTheoSize = txtMaSPPN.Text;
                            spch.soLuong = int.Parse(txtsoLuongSPTSPN.Text);
                            spchTam.Add(spch);
                            lbSLSP.Text = "Đã thêm";
                            lbSLSP.BackColor = Color.Green;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Phiếu nhập đã được nhập, không thể nhập thêm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
        }

        private void btnLuuPN_Click(object sender, EventArgs e)
        {
            if(txtTrangThaiPN.Text == "Đã nhập")
            {
                MessageBox.Show("Phiếu nhập đã được nhập!!!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {


                if (spchTam.Count == 0)
                    MessageBox.Show("Phiếu nhập rỗng, không có gì để lưu ", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    if (spchTam.Count == rowCountSLSPPN)
                    {
                        DialogResult result = MessageBox.Show("Bạn có chắc sẽ lưu phiếu nhập?", "Phiếu nhập", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                        try
                        {

                            bool anyProductExceedsInventory = false;
                            foreach (SanPham_CuaHang spchList in spchTam)
                            {
                                // Load số lượng tồn kho hiện tại từ cơ sở dữ liệu
                                MaSanPhamTheoSizeBLL msptsBLL = new MaSanPhamTheoSizeBLL();
                                List<MaSanPhamTheoSize> msptsList = msptsBLL.LoadDlMaSPTheoSize();
                                MaSanPhamTheoSize maSPtheoSize = msptsList.SingleOrDefault(s => s.maSPTheoSize == spchList.maSPTheoSize);

                                if (spchList.soLuong > maSPtheoSize.soLuongTonKho)
                                {
                                    anyProductExceedsInventory = true;
                                    break; // Thoát khỏi vòng lặp khi có ít nhất một sản phẩm vượt quá tồn kho
                                }
                            }
                            if (anyProductExceedsInventory)
                            {
                                MessageBox.Show("Có ít nhất một sản phẩm nhập vượt quá số lượng tồn kho. Không thể thêm sản phẩm.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {
                                SanPham_CuaHangBLL spchBLL = new SanPham_CuaHangBLL();
                                List<string> existingProductCodes = new List<string>();

                                foreach (DataGridViewRow row in dgvSPCHPN.Rows)
                                {
                                    DataGridViewCell cell = row.Cells["maSPTheoSizePN1"];

                                    if (cell != null && cell.Value != null)
                                    {
                                        string maSPTheoSizeFromDGV = cell.Value.ToString();
                                        existingProductCodes.Add(maSPTheoSizeFromDGV);
                                    }
                                    else
                                    {
                                        // Xử lý trường hợp giá trị là null (nếu cần thiết)
                                    }
                                }

                                foreach (SanPham_CuaHang spchList in spchTam)
                                {
                                    MaSanPhamTheoSizeBLL msptsBLL = new MaSanPhamTheoSizeBLL();
                                    List<MaSanPhamTheoSize> msptsList = msptsBLL.LoadDlMaSPTheoSize();
                                    MaSanPhamTheoSize maSPtheoSize = msptsList.SingleOrDefault(s => s.maSPTheoSize == spchList.maSPTheoSize);
                                    // Kiểm tra xem sản phẩm có tồn tại trong danh sách đã có hay không
                                    if (existingProductCodes.Contains(spchList.maSPTheoSize))
                                    {
                                        foreach (DataGridViewRow row in dgvSPCHPN.Rows)
                                        {
                                            DataGridViewCell maSPTheoSizeCell = row.Cells["maSPTheoSizePN1"];
                                            DataGridViewCell soLuongCell = row.Cells["soLuongSPCHPN"];

                                            if (maSPTheoSizeCell.Value != null && soLuongCell.Value != null)
                                            {
                                                string maSPTheoSizeFromDGV1 = maSPTheoSizeCell.Value.ToString();
                                                int soLuongDGV = int.Parse(soLuongCell.Value.ToString());

                                                if (spchList.maSPTheoSize == maSPTheoSizeFromDGV1)
                                                {
                                                    // Trừ số lượng nhập từ số lượng tồn kho hiện tại
                                                    maSPtheoSize.soLuongTonKho -= spchList.soLuong;

                                                    SanPham_CuaHang spch = new SanPham_CuaHang
                                                    {
                                                        maCuaHang = spchList.maCuaHang,
                                                        maSPTheoSize = spchList.maSPTheoSize,
                                                        soLuong = soLuongDGV + spchList.soLuong
                                                    };

                                                    spchBLL.SuaSPCuaCH(spch);
                                                    // Cập nhật số lượng tồn kho mới vào cơ sở dữ liệu
                                                    msptsBLL.SuaSoLuongTonKho(maSPtheoSize);


                                                }
                                            }
                                        }



                                    }
                                    else
                                    {
                                        // Sản phẩm không tồn tại trong danh sách, thêm sản phẩm mới

                                        maSPtheoSize.soLuongTonKho -= spchList.soLuong;
                                        msptsBLL.SuaSoLuongTonKho(maSPtheoSize);
                                        spchBLL.ThemSPChoCH(spchList);
                                    }


                                }
                                PhieuNhapBLL pnBLL = new PhieuNhapBLL();
                                PhieuNhap pn = new PhieuNhap()
                                {
                                    maPhieuNhap = txtMaPN.Text,
                                    maNhanVien = txtMaNVPN.Text,
                                    maCuaHang = txtMaCHPN.Text,
                                    ngayNhap = dateNgayNhapPN.Value,
                                    trangThai = true
                                };
                                pnBLL.editPhieuNhap(pn);
                                MessageBox.Show("Số lượng sản phẩm được thêm cho cửa hàng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadSPCHPN(txtMaCHPN.Text);
                                loadPhieuNhapList();




                            }
                        }

                        catch (Exception ex)
                        {
                            MessageBox.Show("Không thể thêm sản phẩm cho cửa hàng. Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            spchTam = null;
                            rowCountSLSPPN = 0;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bạn chưa thêm đủ sản phẩm cho phiếu nhập. Hãy thêm đủ sản phẩm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                }
            }
        }

        private void tabPhieuNhap_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabPage selectedTab = tabPhieuNhap.SelectedTab;

            // Kiểm tra xem TabPage được chọn có tên là gì (tùy thuộc vào tên bạn đã đặt)
            if (selectedTab.Name == "tabPNK") // Thay "tabPage1" bằng tên thực sự của TabPage
            {
                loadCbMaNhaSX();
                loadCbMaSanPham();
                loadCbMaSize();
                dgvCTPhieuNhapKho.AutoGenerateColumns = false;
                LoadDsPhieuNhapKho();
                LoadDsNSX();
                ctpnkTam = new List<ChiTietPhieuNhapKho>();

            }
            if (selectedTab.Name == "tabPNCH") // Thay "tabPage1" bằng tên thực sự của TabPage
            {
                loadPhieuNhapList();
                spchTam = new List<SanPham_CuaHang>();
            }
        }

        private void txtTimKiemPNK_TextChanged(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiemPNK.Text;

            PhieuNhapKhoBLL pnkBLL = new PhieuNhapKhoBLL();
            List<PhieuNhapKho> ketQuaTimKiem = pnkBLL.TimKiemPhieuNhapKho(tuKhoa);
            dgvPhieuNhapKho.Rows.Clear();


            foreach (PhieuNhapKho pnk in ketQuaTimKiem)
            {
                dgvPhieuNhapKho.Rows.Add(pnk.maPhieuNhap, pnk.maNhaSanXuat, pnk.ngayNhap);
            }
        }

        private void txtTimKiemNSX_TextChanged(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiemNSX.Text;

            NhaSanXuatBLL nsxBLL = new NhaSanXuatBLL();
            List<NhaSanXuat> ketQuaTimKiem = nsxBLL.TimKiemNSX(tuKhoa);

            dgvNSX.Rows.Clear();


            foreach (NhaSanXuat nsx in ketQuaTimKiem)
            {
                dgvNSX.Rows.Add(nsx.maNhaSanXuat, nsx.tenNhaSanXuat, nsx.soDienThoai, nsx.diaChi, nsx.email, nsx.website);
            }
        }
        private void SearchPhieuNhap(string keyword)
        {
            // Xóa tất cả các hàng hiện có trong DataGridView
            dgvPhieuNhap.Rows.Clear();

            // Chuyển đổi từ khóa tìm kiếm và các trường cần tìm kiếm sang chữ thường
            keyword = keyword.ToLower();

            // Lặp qua danh sách PhieuNhap ban đầu và thêm các hàng thỏa mãn tìm kiếm
            foreach (PhieuNhap pn in dspnGui)
            {
                string tt = pn.trangThai ? "Đã nhập" : "Chưa nhập";

                // Chuyển đổi giá trị của mỗi trường sang chữ thường
                string maPhieuNhap = pn.maPhieuNhap.ToString().ToLower();
                string maNhanVien = pn.maNhanVien.ToString().ToLower();
                string maCuaHang = pn.maCuaHang.ToString().ToLower();
                string ngayNhap = pn.ngayNhap.ToString().ToLower();
                string ttLowerCase = tt.ToLower();

                // Kiểm tra xem bất kỳ trường nào của PhieuNhap chứa từ khóa tìm kiếm
                if (maPhieuNhap.Contains(keyword) ||
                    maNhanVien.Contains(keyword) ||
                    maCuaHang.Contains(keyword) ||
                    ngayNhap.Contains(keyword) ||
                    ttLowerCase.Contains(keyword))
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = pn.maPhieuNhap });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = pn.maNhanVien });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = pn.maCuaHang });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = pn.ngayNhap });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = tt });

                    dgvPhieuNhap.Rows.Add(row);
                }
            }
        }

        private void txtTimKiemPNCH_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimKiemPNCH.Text;
            SearchPhieuNhap(keyword);
        }

        private void txtEmailNSX_Leave(object sender, EventArgs e)
        {
            string email = txtEmailNSX.Text.Trim();
            if (IsValidEmail(email))
            {
            }
            else
            {
                MessageBox.Show("Địa chỉ email không hợp lệ. Vui lòng nhập lại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmailNSX.Focus();
            }
        }
        private bool IsValidEmail(string email)
        {
            // Sử dụng biểu thức chính quy để kiểm tra địa chỉ email
            string pattern = @"^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)*(\.[a-z]{2,})$";
            return Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase);
        }

        private void txtWebsiteNSX_Leave(object sender, EventArgs e)
        {
            string website = txtWebsiteNSX.Text.Trim();
            if (IsValidWebsite(website))
            { 
            }
            else
            {
                MessageBox.Show("Địa chỉ website không hợp lệ. Vui lòng nhập lại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtWebsiteNSX.Focus();
            }
        }
        private bool IsValidWebsite(string website)
        {
            // Sử dụng biểu thức chính quy để kiểm tra địa chỉ website
            string pattern = @"^(http|https)://[a-zA-Z0-9.-]+\.[a-z]{2,}$";
            return Regex.IsMatch(website, pattern, RegexOptions.IgnoreCase);
        }

        private void dgvPhieuNhapKho_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvPhieuNhapKho.Columns[e.ColumnIndex].Name == "ngayNhapPhieuNhapKho" && e.Value != null)
            {
                // Định dạng giá trị trong cột "Ngày nhập" theo định dạng dd/MM/yyyy
                DateTime dateValue = (DateTime)e.Value;
                e.Value = dateValue.ToString("dd/MM/yyyy");
                e.FormattingApplied = true; // Đánh dấu rằng việc định dạng đã được áp dụng
            }
        }

        private void dgvPhieuNhap_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvPhieuNhap.Columns[e.ColumnIndex].Name == "ngayNhapPN" && e.Value != null)
            {
                // Định dạng giá trị trong cột "Ngày nhập" theo định dạng dd/MM/yyyy
                DateTime dateValue = (DateTime)e.Value;
                e.Value = dateValue.ToString("dd/MM/yyyy");
                e.FormattingApplied = true; // Đánh dấu rằng việc định dạng đã được áp dụng
            }
        }
    }
}
