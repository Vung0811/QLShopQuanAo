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



namespace GUI.Forms
{
    public partial class FQLCuaHang : Form
    {
        public FQLCuaHang()
        {
            InitializeComponent();
            LoadDsCuaHang();
            loadCbMaSanPham();
            loadCbMaCuaHang();
            loadCbMaSize();
        }
        private void LoadDsCuaHang()
        {
            CuaHangBLL chBLL = new BLL.CuaHangBLL();
            List<CuaHang> dsCHGui = chBLL.getCuaHang();
            dgvCuaHang.Rows.Clear();
            foreach (CuaHang ch in dsCHGui)
            {
                // Tạo một hàng mới trong DataGridView
                DataGridViewRow row = new DataGridViewRow();

                // Thêm các ô thông tin từ đối tượng SanPham vào các ô trong hàng
                row.Cells.Add(new DataGridViewTextBoxCell { Value = ch.maCuaHang });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = ch.tenCuaHang });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = ch.diaChi });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = ch.SDT });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = ch.gioMoCua });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = ch.gioDongCua });

                // Thêm hàng vào DataGridView
                dgvCuaHang.Rows.Add(row);
            }
        }
        private void loadCbMaSanPham()
        {
            BLL.SanPhamBLL spBLL = new BLL.SanPhamBLL();
            List<SanPham> msp = spBLL.LoadDlSanPham();

            // Xóa tất cả các mục hiện tại trong ComboBox (nếu có)

            cbMaSanPham.Items.Clear();
            // Thêm danh sách "maNSX" vào ComboBox
            foreach (SanPham sp in msp)
            {
                cbMaSanPham.Items.Add(sp.maSanPham);

            }
        }
        private void btnThemCH_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaCH.Text) ||
                string.IsNullOrWhiteSpace(txtTenCH.Text) ||
                string.IsNullOrWhiteSpace(txtDiaChiCH.Text) ||
                string.IsNullOrWhiteSpace(txtSDTCH.Text))

            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin cửa hàng.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                string mCH = txtMaCH.Text;
                CuaHangBLL chBLL = new CuaHangBLL();
                CuaHang kiemtraMCH = chBLL.getCuaHang(mCH);
                if (kiemtraMCH != null)
                {
                    // Mã sản phẩm đã tồn tại, hiển thị cảnh báo cho người dùng
                    MessageBox.Show("Mã cửa hàng đã tồn tại! Vui lòng nhập mã cửa hàng khác.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    try
                    {
                        TimeSpan gioMoCH = dateGioMoCua.Value.TimeOfDay; // Lấy thời gian mở cửa
                        TimeSpan gioDongCH = dateGioDongCua.Value.TimeOfDay; // Lấy thời gian đóng cửa

                        CuaHang ch = new CuaHang
                        {

                            maCuaHang = mCH,
                            tenCuaHang = txtTenCH.Text,
                            diaChi = txtDiaChiCH.Text,
                            SDT = txtSDTCH.Text,
                            gioMoCua = gioMoCH,
                            gioDongCua = gioDongCH



                        };
                        chBLL.ThemCuaHang(ch);
                        MessageBox.Show("Cửa hàng được thêm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDsCuaHang();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Không thể thêm cửa hàng. Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnSuaCH_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaCH.Text) ||
                string.IsNullOrWhiteSpace(txtTenCH.Text) ||
                string.IsNullOrWhiteSpace(txtDiaChiCH.Text) ||
                string.IsNullOrWhiteSpace(txtSDTCH.Text))

            {
                MessageBox.Show("Vui lòng chọn cửa hàng để sửa.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                try
                {
                    TimeSpan gioMoCH = dateGioMoCua.Value.TimeOfDay; // Lấy thời gian mở cửa
                    TimeSpan gioDongCH = dateGioDongCua.Value.TimeOfDay; // Lấy thời gian đóng cửa
                    CuaHang ch = new CuaHang
                    {
                        maCuaHang = txtMaCH.Text,
                        tenCuaHang = txtTenCH.Text,
                        diaChi = txtDiaChiCH.Text,
                        SDT = txtSDTCH.Text,
                        gioMoCua = gioMoCH,
                        gioDongCua = gioDongCH,

                    };


                    CuaHangBLL chBLL = new CuaHangBLL();
                    chBLL.SuaCuaHang(ch);


                    MessageBox.Show("Sửa thông tin cửa hàng " + txtTenCH.Text + " thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    LoadDsCuaHang();
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Sửa thông tin cửa hàng thất bại. Lỗi: " + exception.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvCuaHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvCuaHang.Rows.Count)
            {
                DataGridViewRow selectedRow = dgvCuaHang.Rows[e.RowIndex];
                string maCuaHang = dgvCuaHang.Rows[e.RowIndex].Cells[0].Value.ToString();
                LoadDsSPCH(maCuaHang);
                cbMaCuaHangSP.Text = maCuaHang;
                txtMaCH.Text = selectedRow.Cells["maCuaHang1"].Value.ToString();
                txtMaCH.ReadOnly = true; // không cho sửa mã
                txtTenCH.Text = selectedRow.Cells["tenCuaHang"].Value.ToString();
                txtDiaChiCH.Text = selectedRow.Cells["diaChiCuaHang"].Value.ToString();
                txtSDTCH.Text = selectedRow.Cells["SDT"].Value.ToString();

                // Lấy giờ mở cửa và giờ đóng cửa từ DataGridView
                string gioMoCuaStr = selectedRow.Cells["gioMoCua"].Value.ToString();
                string gioDongCuaStr = selectedRow.Cells["gioDongCua"].Value.ToString();

                // Chuyển đổi chuỗi thời gian sang kiểu TimeSpan
                TimeSpan gioMoCua = TimeSpan.Parse(gioMoCuaStr);
                TimeSpan gioDongCua = TimeSpan.Parse(gioDongCuaStr);

                // Hiển thị giờ mở cửa và giờ đóng cửa lên các DateTimePicker hoặc TextBox tương ứng
                dateGioMoCua.Value = DateTime.Today.Add(gioMoCua);
                dateGioDongCua.Value = DateTime.Today.Add(gioDongCua);

            }
        }

        private void btnNhapLaiCH_Click(object sender, EventArgs e)
        {
            txtMaCH.ReadOnly = false;
            txtMaCH.Clear();
            txtTenCH.Clear();
            txtDiaChiCH.Clear();
            txtSDTCH.Clear();
            dateGioMoCua.ResetText();
            dateGioDongCua.ResetText();
        }

        private void btnXoaCH_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaCH.Text) ||
                string.IsNullOrWhiteSpace(txtTenCH.Text) ||
                string.IsNullOrWhiteSpace(txtDiaChiCH.Text) ||
                string.IsNullOrWhiteSpace(txtSDTCH.Text))

            {
                MessageBox.Show("Vui lòng chọn cửa hàng để xóa.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                try
                {
                    if (MessageBox.Show("Bạn có thật sự muốn xóa cửa hàng " + txtTenCH.Text + "?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string maCH = txtMaCH.Text;
                        CuaHangBLL chBLL = new CuaHangBLL();
                        bool isForeignKey = chBLL.IsForeignKeyInOtherTables(maCH);
                        if (isForeignKey)
                        {
                            MessageBox.Show("Xóa cửa hàng thất bại. Do cửa hàng đang được hoạt động.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }
                        else
                        {
                            chBLL.XoaCuaHang(maCH);
                            MessageBox.Show("Xóa cửa hàng " + txtTenCH.Text + " thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadDsCuaHang();
                        }
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Xóa cửa hàng " + txtTenCH.Text + " thất bại. Lỗi: " + exception.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void txtTimKiemCH_TextChanged(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiemCH.Text;

            CuaHangBLL chBLL = new CuaHangBLL();
            List<CuaHang> ketQuaTimKiem = chBLL.TimKiemCuaHang(tuKhoa);

            dgvCuaHang.Rows.Clear();

           
                foreach (CuaHang ch in ketQuaTimKiem)
                {
                    dgvCuaHang.Rows.Add(ch.maCuaHang, ch.tenCuaHang, ch.diaChi, ch.SDT, ch.gioMoCua, ch.gioDongCua);
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

        private void LoadDsSPCH(string mch)
        {
            SanPham_CuaHangBLL spchBLL = new SanPham_CuaHangBLL();
            // Gọi phương thức để lấy danh sách chi tiết phiếu nhập dựa trên maPhieuNhap
            List<SanPham_CuaHang> dsSPCH = spchBLL.getPNTheoCH(new SanPham_CuaHang { maCuaHang = mch });

            // Xóa các dòng hiện tại trong dgvChiTietPN (nếu có)
            dgvSanPhamCuaHang.Rows.Clear();

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
                dgvSanPhamCuaHang.Rows.Add(row);
            }
        }
        private void loadCbMaSize()
        {
            BLL.SizeBLL sizeBLL = new BLL.SizeBLL();
            List<DTO.Size> sizelist = sizeBLL.GetSizes(); // Sử dụng DTO.Size để chỉ rõ bạn đang sử dụng Size từ DTO

            // Xóa tất cả các mục hiện tại trong ComboBox (nếu có)
            cbSize.Items.Clear();

            // Thêm danh sách các size vào ComboBox
            foreach (DTO.Size size in sizelist) // Sử dụng DTO.Size để chỉ rõ bạn đang sử dụng Size từ DTO
            {
                // Sử dụng thuộc tính hoặc phương thức của đối tượng Size để lấy giá trị cần hiển thị trong ComboBox
                cbSize.Items.Add(size.maSize);
            }
        }
        private void dgvSanPhamCuaHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvSanPhamCuaHang.Rows.Count)
            {
                DataGridViewRow selectedRow = dgvSanPhamCuaHang.Rows[e.RowIndex];
                foreach (var item in cbMaCuaHangSP.Items)
                    if ((string)item == selectedRow.Cells["maCuaHangSP"].Value.ToString())
                        cbMaCuaHangSP.SelectedItem = item;

                string maSP = selectedRow.Cells["maSanPhamCH"].Value.ToString();
                string maSize = selectedRow.Cells["maSanPhamCH"].Value.ToString();
                cbMaSanPham.Text = maSP.Split('_')[0];
                cbSize.Text = maSize.Split('_')[1];

                txtSoLuongSPCH.Text = selectedRow.Cells["soLuongSPCH"].Value.ToString();

            }
        }

        private void btnThemSPChoCH_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cbMaCuaHangSP.Text) ||
                string.IsNullOrWhiteSpace(cbMaSanPham.Text) ||
                string.IsNullOrWhiteSpace(cbSize.Text) ||
                string.IsNullOrWhiteSpace(txtSoLuongSPCH.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                try
                {
                    string maSP = cbMaSanPham.Text;
                    string maSize = cbSize.Text;
                    string maSanPham = maSP +'_'+maSize;
                    int soLuongNhap = int.Parse(txtSoLuongSPCH.Text);
                    SanPham_CuaHangBLL spchBLL = new SanPham_CuaHangBLL();
                    List<SanPham_CuaHang> dsSPCH = spchBLL.getPNTheoCH(new SanPham_CuaHang { maCuaHang = txtMaCH.Text });
                    SanPham_CuaHang mspts = dsSPCH.SingleOrDefault(s => s.maSPTheoSize == maSanPham);
                    if (mspts != null)
                    {
                        MessageBox.Show("Sản phẩm theo size đã được thêm cho cửa hàng.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        // Load số lượng tồn kho hiện tại từ cơ sở dữ liệu
                        MaSanPhamTheoSizeBLL msptsBLL = new MaSanPhamTheoSizeBLL();
                        List<MaSanPhamTheoSize> msptsList = msptsBLL.LoadDlMaSPTheoSize();
                        MaSanPhamTheoSize maSPtheoSize = msptsList.SingleOrDefault(s => s.maSPTheoSize == maSanPham);

                        if (maSPtheoSize != null)
                        {
                            // Kiểm tra xem số lượng nhập có vượt quá số lượng tồn kho không
                            if (soLuongNhap > maSPtheoSize.soLuongTonKho)
                            {
                                MessageBox.Show("Số lượng nhập vượt quá số lượng tồn kho. Không thể thêm sản phẩm.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {


                                // Trừ số lượng nhập từ số lượng tồn kho hiện tại
                                maSPtheoSize.soLuongTonKho -= soLuongNhap;

                                // Cập nhật số lượng tồn kho mới vào cơ sở dữ liệu
                                msptsBLL.SuaSoLuongTonKho(maSPtheoSize);
                                SanPham_CuaHang spch = new SanPham_CuaHang
                                {
                                    maCuaHang = cbMaCuaHangSP.Text,
                                    maSPTheoSize = maSanPham,
                                    soLuong = soLuongNhap
                                };
                                spchBLL.ThemSPChoCH(spch);

                                MessageBox.Show("Sản phẩm được thêm cho cửa hàng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadDsSPCH(cbMaCuaHangSP.Text);

                            }

                        }
                    }



                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể thêm sản phẩm cho cửa hàng. Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }


        }

        private void btnSuaSPCuaCH_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cbMaCuaHangSP.Text) ||
                string.IsNullOrWhiteSpace(cbMaSanPham.Text) ||
                string.IsNullOrWhiteSpace(cbSize.Text) ||
                string.IsNullOrWhiteSpace(txtSoLuongSPCH.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                try
                {
                    string maCuaHang = cbMaCuaHangSP.Text;
                    string maSP = cbMaSanPham.Text;
                    string maSize = cbSize.Text;
                    string maSanPham = maSP + '_' + maSize;
                    int soLuongNhapMoi = int.Parse(txtSoLuongSPCH.Text);

                    // Declare the spch variable here

                    SanPham_CuaHangBLL spchBLL = new SanPham_CuaHangBLL();
                    List<SanPham_CuaHang> dsSPCH = spchBLL.getPNTheoCH(new SanPham_CuaHang { maCuaHang = txtMaCH.Text });
                    SanPham_CuaHang mspts = dsSPCH.SingleOrDefault(s => s.maSPTheoSize == maSanPham);
                    if (mspts != null)
                    {
                        MaSanPhamTheoSizeBLL msptsBLL = new MaSanPhamTheoSizeBLL();
                        List<MaSanPhamTheoSize> msptsList = msptsBLL.LoadDlMaSPTheoSize();
                        MaSanPhamTheoSize sanPham = msptsList.SingleOrDefault(s => s.maSPTheoSize == maSanPham);

                        if (sanPham != null)
                        {
                            int soLuongBanDau = int.Parse(dgvSanPhamCuaHang.SelectedRows[0].Cells["soLuongSPCH"].Value.ToString());
                            int soLuongChenhLech = soLuongNhapMoi - soLuongBanDau;

                            // Kiểm tra xem số lượng nhập mới có vượt quá số lượng tồn kho không
                            if (soLuongChenhLech > sanPham.soLuongTonKho)
                            {
                                MessageBox.Show("Số lượng sửa vượt quá số lượng tồn kho. Không thể sửa sản phẩm.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return; // Không thực hiện sửa sản phẩm nếu số lượng nhập vượt quá tồn kho
                            }
                            else
                            {
                                // Tính toán số lượng tồn kho mới bằng số lượng nhập mới
                                sanPham.soLuongTonKho -= soLuongChenhLech;

                                // Cập nhật số lượng tồn kho mới vào cơ sở dữ liệu
                                msptsBLL.SuaSoLuongTonKho(sanPham);
                                // Tiến hành sửa sản phẩm cho cửa hàng
                                SanPham_CuaHang spch = new SanPham_CuaHang
                                {
                                    maCuaHang = maCuaHang,
                                    maSPTheoSize = maSanPham,
                                    soLuong = soLuongNhapMoi
                                };

                                spchBLL.SuaSPCuaCH(spch);

                                MessageBox.Show("Sửa thông tin sản phẩm cho cửa hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                LoadDsSPCH(maCuaHang);
                            }
                        }
                    }
                    else
                    {

                        MessageBox.Show("Sản phẩm theo size không tồn tại.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }


                }
                catch (Exception exception)
                {
                    MessageBox.Show("Sửa thông tin sản phẩm cho cửa hàng thất bại. Lỗi: " + exception.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnXoaSPCuaCH_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cbMaCuaHangSP.Text) ||
                string.IsNullOrWhiteSpace(cbMaSanPham.Text) ||
                string.IsNullOrWhiteSpace(cbSize.Text) ||
                string.IsNullOrWhiteSpace(txtSoLuongSPCH.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                try
                {
                    if (MessageBox.Show("Bạn có thật sự muốn xóa sản phẩm của cửa hàng này?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string maCH = cbMaCuaHangSP.Text;
                        string maSP = cbMaSanPham.Text;
                        string maSize = cbSize.Text;
                        string maSanPham = maSP + '_' + maSize;

                        // Lấy thông tin sản phẩm từ DataGridView
                        int soLuongBanDau = int.Parse(dgvSanPhamCuaHang.SelectedRows[0].Cells["soLuongSPCH"].Value.ToString());

                        // Trừ soLuongBanDau từ soLuongTonKho của sản phẩm trong cơ sở dữ liệu
                        MaSanPhamTheoSizeBLL msptsBLL = new MaSanPhamTheoSizeBLL();
                        List<MaSanPhamTheoSize> msptsList = msptsBLL.LoadDlMaSPTheoSize();
                        MaSanPhamTheoSize sanPham = msptsList.SingleOrDefault(s => s.maSPTheoSize == maSanPham);

                        if (sanPham != null)
                        {
                            sanPham.soLuongTonKho += soLuongBanDau;

                            // Cập nhật số lượng tồn kho mới vào cơ sở dữ liệu
                            msptsBLL.SuaSoLuongTonKho(sanPham);
                        }

                        // Xóa sản phẩm của cửa hàng
                        SanPham_CuaHangBLL spchBLL = new SanPham_CuaHangBLL();
                        spchBLL.XoaSPCuaCH(maCH, maSanPham);

                        MessageBox.Show("Xóa sản phẩm của cửa hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDsSPCH(maCH);
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Xóa sản phẩm của cửa hàng thất bại. Lỗi: " + exception.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnNhapLaiSPChoCH_Click(object sender, EventArgs e)
        {
            cbMaCuaHangSP.SelectedIndex = -1;
            cbMaSanPham.SelectedIndex = -1;
            cbSize.SelectedIndex = -1;
            txtSoLuongSPCH.Clear();
        }
        private void txtTimKiemSPCuaCH_TextChanged(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiemSPCuaCH.Text;
            string maCH = cbMaCuaHangSP.Text;
            SanPham_CuaHangBLL spchBLL = new SanPham_CuaHangBLL();
            List<SanPham_CuaHang> ketQuaTimKiem = spchBLL.TimKiemSanPham_CuaHang(tuKhoa, maCH);

            dgvSanPhamCuaHang.Rows.Clear();


                foreach (SanPham_CuaHang spch in ketQuaTimKiem)
                {
                    dgvSanPhamCuaHang.Rows.Add(spch.maCuaHang, spch.maSPTheoSize, spch.soLuong);
                }


        }


        //=======================================Nhân viên===================================
        DangNhapBLL dnBLL = new DangNhapBLL();
        List<NhanVien> dsnvGui;
        private void LoadDsNhanVien()
        {
            
            NhanVienBLL nvbll = new BLL.NhanVienBLL();
            dsnvGui = nvbll.LoadDlNhanVien();
            dgvNhanVien.Rows.Clear();
            string gt = null;
            foreach (NhanVien nv in dsnvGui)
            {
                // Tạo một hàng mới trong DataGridView
                DataGridViewRow row = new DataGridViewRow();

                // Thêm các ô thông tin từ đối tượng SanPham vào các ô trong hàng
                row.Cells.Add(new DataGridViewTextBoxCell { Value = nv.maNhanVien });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = nv.hoNhanVien });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = nv.tenNhanVien });
                if(nv.gioiTinh ==true)
                {
                    gt = "Nam";
                }
                else
                {
                    gt = "Nữ";
                }
                row.Cells.Add(new DataGridViewTextBoxCell { Value = gt });

                row.Cells.Add(new DataGridViewTextBoxCell { Value = nv.diaChi });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = nv.soDienThoai });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = nv.ngaySinh });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = nv.chucVu });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = dnBLL.giaiMaMK(nv.pass).ToString() });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = nv.maCuaHang });
                // Thêm hàng vào DataGridView
                dgvNhanVien.Rows.Add(row);
            }
        }
        private void loadCbMaChucVu()
        {
            BLL.ChucVuBLL chucVuBLL = new BLL.ChucVuBLL();
            List<ChucVu> chucVu = chucVuBLL.GetChucVu();

            // Xóa tất cả các mục hiện tại trong ComboBox (nếu có)
            cbChucVu.Items.Clear();

            // Thêm danh sách "maNSX" vào ComboBox
            foreach (ChucVu cv in chucVu)
            {
                cbChucVu.Items.Add(cv.maChucVu);
            }
        }

        private void loadCbMaCuaHang()
        {
            BLL.CuaHangBLL chBLL = new BLL.CuaHangBLL();
            List<CuaHang> cuaHang = chBLL.getCuaHangList();

            // Xóa tất cả các mục hiện tại trong ComboBox (nếu có)
            cbMaCuaHang.Items.Clear();
            cbMaCuaHangSP.Items.Clear();
            // Thêm danh sách "maNSX" vào ComboBox
            foreach (CuaHang ch in cuaHang)
            {
                cbMaCuaHang.Items.Add(ch.maCuaHang);
                cbMaCuaHangSP.Items.Add(ch.maCuaHang);
            }
        }
        private Boolean getGioiTinhNV()
        {
            Boolean gt = false;
            String sgt = cbGioiTinhNV.SelectedItem.ToString();
            if (sgt == "Nam")
                gt = true;
            return gt;
        }
        private void btnThemNV_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNV.Text) ||
                string.IsNullOrWhiteSpace(txtHoNV.Text) ||
                string.IsNullOrWhiteSpace(txtTenNV.Text) ||
                string.IsNullOrWhiteSpace(cbGioiTinhNV.Text) ||
                string.IsNullOrWhiteSpace(txtDiaChiNV.Text) ||
                string.IsNullOrWhiteSpace(txtSDTNV.Text) ||
                string.IsNullOrWhiteSpace(txtPass.Text) ||
                string.IsNullOrWhiteSpace(cbChucVu.Text) ||
                string.IsNullOrWhiteSpace(cbMaCuaHang.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin nhân viên.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                string mNV = txtMaNV.Text;
                NhanVienBLL nvBLL = new NhanVienBLL();
                NhanVien kiemtraMNV = nvBLL.getNhanVien(mNV);
                if (kiemtraMNV != null)
                {
                    // Mã sản phẩm đã tồn tại, hiển thị cảnh báo cho người dùng
                    MessageBox.Show("Mã nhân viên đã tồn tại! Vui lòng nhập mã nhân viên khác.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    try
                    {
                        NhanVien nv = new NhanVien
                        {
                            maNhanVien = mNV,
                            hoNhanVien = txtHoNV.Text,
                            tenNhanVien = txtTenNV.Text,
                            gioiTinh = getGioiTinhNV(),
                            diaChi = txtDiaChiNV.Text,
                            soDienThoai = txtSDTNV.Text,
                            ngaySinh = dateNgaySinhNV.Value,

                            chucVu = cbChucVu.Text,
                            pass = dnBLL.maHoaMK(txtPass.Text) ,
                            maCuaHang = cbMaCuaHang.Text
                        };

                        nvBLL.ThemNhanVien(nv);
                        MessageBox.Show("Nhân viên được thêm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDsNhanVien();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Không thể thêm nhân viên. Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvNhanVien.Rows.Count)
            {
                DataGridViewRow selectedRow = dgvNhanVien.Rows[e.RowIndex];
                txtMaNV.Text = selectedRow.Cells["maNhanVien"].Value.ToString();
                txtMaNV.ReadOnly = true; // không cho sửa mã
                txtHoNV.Text = selectedRow.Cells["hoNhanVien"].Value.ToString();
                txtTenNV.Text = selectedRow.Cells["tenNhanVien"].Value.ToString();
                txtDiaChiNV.Text = selectedRow.Cells["diaChi"].Value.ToString();
                txtSDTNV.Text = selectedRow.Cells["soDienThoai"].Value.ToString();
                txtPass.Text = selectedRow.Cells["pass"].Value.ToString();


                foreach (var item in cbGioiTinhNV.Items)
                    if ((string)item == selectedRow.Cells["gioiTinh"].Value.ToString())
                        cbGioiTinhNV.SelectedItem = item;

                foreach (var item in cbChucVu.Items)
                    if ((string)item == selectedRow.Cells["chucVu"].Value.ToString())
                        cbChucVu.SelectedItem = item;

                foreach (var item in cbMaCuaHang.Items)
                    if ((string)item == selectedRow.Cells["maCuaHang"].Value.ToString())
                        cbMaCuaHang.SelectedItem = item;

                string ngaySinhValue = selectedRow.Cells["ngaySinh"].Value.ToString();

                // Chuyển đổi giá trị thành kiểu DateTime và gán cho DateTimePicker
                if (DateTime.TryParse(ngaySinhValue, out DateTime ngaySinh))
                {
                    dateNgaySinhNV.Value = ngaySinh;
                }
            }
        }

        private void btnSuaNV_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNV.Text) ||
                string.IsNullOrWhiteSpace(txtHoNV.Text) ||
                string.IsNullOrWhiteSpace(txtTenNV.Text) ||
                string.IsNullOrWhiteSpace(cbGioiTinhNV.Text) ||
                string.IsNullOrWhiteSpace(txtDiaChiNV.Text) ||
                string.IsNullOrWhiteSpace(txtSDTNV.Text) ||
                string.IsNullOrWhiteSpace(txtPass.Text) ||
                string.IsNullOrWhiteSpace(cbChucVu.Text) ||
                string.IsNullOrWhiteSpace(cbMaCuaHang.Text))
            {
                MessageBox.Show("Vui lòng chọn nhân viên để sửa.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                try
                {
                    bool gioiTinhValue;
                    if (cbGioiTinhNV.Text == "Nam")
                    {
                        gioiTinhValue = true;
                    }
                    else
                    {
                        gioiTinhValue = false;
                    }
                    NhanVien nv = new NhanVien
                    {
                        maNhanVien = txtMaNV.Text,
                        hoNhanVien = txtHoNV.Text,
                        tenNhanVien = txtTenNV.Text,
                        gioiTinh = gioiTinhValue,
                        diaChi = txtDiaChiNV.Text,
                        soDienThoai = txtSDTNV.Text,
                        ngaySinh = dateNgaySinhNV.Value,
                        chucVu = cbChucVu.Text,
                        pass = dnBLL.maHoaMK(txtPass.Text),

                        maCuaHang = cbMaCuaHang.Text
                    };


                    NhanVienBLL nvBLL = new NhanVienBLL();
                    nvBLL.SuaNhanVien(nv);


                    MessageBox.Show("Sửa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    LoadDsNhanVien();
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Sửa nhân viên thất bại. Lỗi: " + exception.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnNhapLaiNV_Click(object sender, EventArgs e)
        {
            txtMaNV.ReadOnly = false;
            txtMaNV.Clear();
            txtHoNV.Clear();
            txtTenNV.Clear();
            txtDiaChiNV.Clear();
            txtSDTNV.Clear();
            txtPass.Clear();
            cbGioiTinhNV.SelectedIndex = -1;
            dateNgaySinhNV.ResetText();
            cbChucVu.SelectedIndex = -1;
            cbMaCuaHang.SelectedIndex = -1;
        }

        private void btnXoaNV_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNV.Text) ||
                string.IsNullOrWhiteSpace(txtHoNV.Text) ||
                string.IsNullOrWhiteSpace(txtTenNV.Text) ||
                string.IsNullOrWhiteSpace(cbGioiTinhNV.Text) ||
                string.IsNullOrWhiteSpace(txtDiaChiNV.Text) ||
                string.IsNullOrWhiteSpace(txtSDTNV.Text) ||
                string.IsNullOrWhiteSpace(txtPass.Text) ||
                string.IsNullOrWhiteSpace(cbChucVu.Text) ||
                string.IsNullOrWhiteSpace(cbMaCuaHang.Text))
            {
                MessageBox.Show("Vui lòng chọn nhân viên để xóa.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                try
                {
                    if (MessageBox.Show("Bạn có thật sự muốn xóa nhân viên này?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string maNV = txtMaNV.Text;
                        NhanVienBLL nvBLL = new NhanVienBLL();
                        bool isForeignKey = nvBLL.IsForeignKeyInOtherTables(maNV);
                        if (isForeignKey)
                        {
                            MessageBox.Show("Xóa nhân viên thất bại. Do nhân viên đang làm việc.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }
                        else
                        {
                            nvBLL.XoaNhanVien(maNV);
                            MessageBox.Show("Xóa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadDsNhanVien();
                        }
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Xóa nhân viên thất bại. Lỗi: " + exception.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnTimKiemNV_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiemNV.Text;

            NhanVienBLL nvBLL = new NhanVienBLL();
            List<NhanVien> ketQuaTimKiem = nvBLL.TimKiemNhanVien(tuKhoa);

            dgvNhanVien.Rows.Clear();

            if (ketQuaTimKiem.Count > 0)
            {
                foreach (NhanVien nv in ketQuaTimKiem)
                {
                    dgvNhanVien.Rows.Add(nv.maNhanVien, nv.hoNhanVien, nv.tenNhanVien, nv.gioiTinh, nv.diaChi, nv.soDienThoai, nv.ngaySinh, nv.chucVu, nv.pass, nv.maCuaHang);
                }

                MessageBox.Show("Tìm thấy " + ketQuaTimKiem.Count + " nhân viên.");
            }
            else
            {
                MessageBox.Show("Không tìm thấy nhân viên nào với từ khóa '" + tuKhoa + "'.");
            }
        }

        private void tabQLCuaHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabPage selectedTab = tabQLCuaHang.SelectedTab;

            // Kiểm tra xem TabPage được chọn có tên là gì (tùy thuộc vào tên bạn đã đặt)
            if (selectedTab.Name == "tabCH") // Thay "tabPage1" bằng tên thực sự của TabPage
            {
                LoadDsCuaHang();
                loadCbMaSanPham();
                loadCbMaCuaHang();

            }
            if (selectedTab.Name == "tabNV") // Thay "tabPage1" bằng tên thực sự của TabPage
            {
                LoadDsNhanVien();
                loadCbMaChucVu();
                loadCbMaCuaHang();
            }
        }

        private void SearchNhanVien(string keyword)
        {
            // Xóa tất cả các hàng hiện có trong DataGridView
            dgvNhanVien.Rows.Clear();

            // Chuyển đổi từ khóa tìm kiếm sang chữ thường
            keyword = keyword.ToLower();

            // Lặp qua danh sách NhanVien ban đầu và thêm các hàng thỏa mãn tìm kiếm
            foreach (NhanVien nv in dsnvGui)
            {
                string gt = nv.gioiTinh ? "Nam" : "Nữ";

                // Chuyển đổi giá trị của mỗi trường sang chữ thường
                string maNhanVien = nv.maNhanVien.ToLower();
                string hoNhanVien = nv.hoNhanVien.ToLower();
                string tenNhanVien = nv.tenNhanVien.ToLower();
                string gtLowerCase = gt.ToLower();
                string diaChi = nv.diaChi.ToLower();
                string soDienThoai = nv.soDienThoai.ToLower();
                string ngaySinh = nv.ngaySinh.ToString().ToLower();
                string chucVu = nv.chucVu.ToLower();
                string pass = nv.pass.ToLower();
                string maCuaHang = nv.maCuaHang.ToLower();

                // Kiểm tra xem bất kỳ trường nào của NhanVien chứa từ khóa tìm kiếm
                if (maNhanVien.Contains(keyword) ||
                    hoNhanVien.Contains(keyword) ||
                    tenNhanVien.Contains(keyword) ||
                    gtLowerCase.Contains(keyword) ||
                    diaChi.Contains(keyword) ||
                    soDienThoai.Contains(keyword) ||
                    ngaySinh.Contains(keyword) ||
                    chucVu.Contains(keyword) ||
                    pass.Contains(keyword) ||
                    maCuaHang.Contains(keyword))
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = nv.maNhanVien });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = nv.hoNhanVien });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = nv.tenNhanVien });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = gt });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = nv.diaChi });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = nv.soDienThoai });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = nv.ngaySinh });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = nv.chucVu });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = nv.pass });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = nv.maCuaHang });

                    dgvNhanVien.Rows.Add(row);
                }
            }
        }

        private void txtTimKiemNV_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimKiemNV.Text;
            SearchNhanVien(keyword);
        }

        private void dgvNhanVien_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvNhanVien.Columns[e.ColumnIndex].Name == "ngaySinh" && e.Value != null)
            {
                // Định dạng giá trị trong cột "Ngày nhập" theo định dạng dd/MM/yyyy
                DateTime dateValue = (DateTime)e.Value;
                e.Value = dateValue.ToString("dd/MM/yyyy");
                e.FormattingApplied = true; // Đánh dấu rằng việc định dạng đã được áp dụng
            }
        }

        
    }
}
