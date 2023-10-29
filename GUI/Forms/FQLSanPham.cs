using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GUI.Forms
{
    public partial class FQLSanPham : Form
    {
        CloudinaryBLL cloudinaryBLL = new CloudinaryBLL();
        List<string> danhSachDuongDanAnh = null;
        public FQLSanPham()
        {

            InitializeComponent();
            LoadDsSanPham();
            loadCbMaSize();
            LoadDsCTSanPham();
            picSP_HD.Hide();
    
        }
        private void LoadDsSanPham()
        {
            SanPhamBLL spbll = new BLL.SanPhamBLL();
            List<SanPham> dsspGui = spbll.LoadDlSanPham();
            dgvSanPham.Rows.Clear();
            foreach (SanPham sp in dsspGui)
            {
                // Tạo một hàng mới trong DataGridView
                DataGridViewRow row = new DataGridViewRow();

                // Thêm các ô thông tin từ đối tượng SanPham vào các ô trong hàng
                row.Cells.Add(new DataGridViewTextBoxCell { Value = sp.maSanPham });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = sp.tenSanPham });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = sp.moTaSanPham });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = sp.giaNhap });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = sp.donGiaNiemYet });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = sp.chatLieu });
                // Thêm hàng vào DataGridView
                dgvSanPham.Rows.Add(row);
            }
        }

        private void LoadDsCTSanPham()
        {
            MaSanPhamTheoSizeBLL sptsBLL = new MaSanPhamTheoSizeBLL();
            List<MaSanPhamTheoSize> dsspGui = sptsBLL.LoadDlMaSPTheoSize();
            dgvCTSP.Rows.Clear();
            foreach (MaSanPhamTheoSize sp in dsspGui)
            {
                // Tạo một hàng mới trong DataGridView
                DataGridViewRow row = new DataGridViewRow();

                // Thêm các ô thông tin từ đối tượng SanPham vào các ô trong hàng
                row.Cells.Add(new DataGridViewTextBoxCell { Value = sp.maSPTheoSize });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = sp.maSize });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = sp.maSanPham });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = sp.soLuongTonKho });
                // Thêm hàng vào DataGridView
                dgvCTSP.Rows.Add(row);
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

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            danhSachDuongDanAnh = new List<string>();
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Multiselect = true;
                    openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp|All Files|*.*";
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        foreach (string fileName in openFileDialog.FileNames)
                        {
                            // Tạo một PictureBox mới cho mỗi hình ảnh
                            PictureBox pictureBox = new PictureBox();
                            pictureBox.Image = new System.Drawing.Bitmap(fileName);
                            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                            pictureBox.Height = 106;
                            pictureBox.Width = 160;

                            // Thêm PictureBox vào form
                            flowLayoutPanel1.Controls.Add(pictureBox);

                            danhSachDuongDanAnh.Add(fileName);
                        }
                    }
                }
           
        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaSP.Text) ||
                string.IsNullOrWhiteSpace(txtTenSP.Text) ||
                string.IsNullOrWhiteSpace(txtMoTaSP.Text) ||
                string.IsNullOrWhiteSpace(txtGiaNhap.Text) ||
                string.IsNullOrWhiteSpace(txtGiaNiemYet.Text) ||
                string.IsNullOrWhiteSpace(txtChatLieu.Text)||
                flowLayoutPanel1.Controls.Count == 0)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin sản phẩm.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                try
                {
                    // Lấy thông tin sản phẩm từ giao diện người dùng
                    string maSP = txtMaSP.Text;
                    string tenSP = txtTenSP.Text;
                    string moTaSP = txtMoTaSP.Text;
                    int giaNhap = int.Parse(txtGiaNhap.Text);
                    int donGiaNiemYet = int.Parse(txtGiaNiemYet.Text);
                    string chatLieu = txtChatLieu.Text;
                    SanPhamBLL spBLL = new SanPhamBLL();
                    SanPham kiemtraMSP = spBLL.getSanPham(maSP);
                    AnhSanPhamBLL anhBLL = new AnhSanPhamBLL();

                    if (kiemtraMSP != null)
                    {
                        // Mã sản phẩm đã tồn tại, hiển thị cảnh báo cho người dùng
                        MessageBox.Show("Mã sản phẩm đã tồn tại! Vui lòng nhập mã sản phẩm khác.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    else
                    {
                        SanPham sp = new SanPham
                        {
                            maSanPham = maSP,
                            tenSanPham = tenSP,
                            moTaSanPham = moTaSP,
                            giaNhap = giaNhap,
                            donGiaNiemYet = donGiaNiemYet,
                            chatLieu = chatLieu,
                        };

                        // Gọi phương thức ThemSanPham từ lớp SanPhamBLL để thêm sản phẩm
                        spBLL.ThemSanPham(sp);


                        int i = 0;
                        foreach (string duongDanAnh in danhSachDuongDanAnh)
                        {
                            AnhSanPham asp = new AnhSanPham()
                            {
                                maAnh = maSP + "_" + i++,
                                maSanPham = maSP,
                                urlAnh = duongDanAnh
                            };
                            // Gọi phương thức ThemAnhSanPham từ lớp AnhSanPhamBLL để thêm đường dẫn ảnh vào CSDL
                            cloudinaryBLL.UploadAndSaveToDatabase(duongDanAnh, asp);
                        }
                        i = 0;
                        
                        MessageBox.Show("Thêm sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception exception)
                {
                    // Hiển thị thông báo khi sửa thất bại và bao gồm thông điệp lỗi từ ngoại lệ trong thông báo
                    MessageBox.Show("Thêm sản phẩm thất bại. Lỗi: " + exception.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } 
            }

            // Sau khi thêm sản phẩm, bạn có thể cập nhật DataGridView để hiển thị danh sách sản phẩm mới
            LoadDsSanPham();
        }

        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvSanPham.Rows.Count)
            {

                DataGridViewRow selectedRow = dgvSanPham.Rows[e.RowIndex];
                string maSanPham = dgvSanPham.Rows[e.RowIndex].Cells[0].Value.ToString();
                LoadChiTietSanPham(maSanPham);
                txtMaSP.Text = selectedRow.Cells["maSanPham"].Value.ToString();
                txtMaSP.ReadOnly = true; // không cho sửa mã
                txtTenSP.Text = selectedRow.Cells["tenSanPham"].Value.ToString();
                txtMoTaSP.Text = selectedRow.Cells["moTaSanPham"].Value.ToString();
                txtGiaNhap.Text = selectedRow.Cells["giaNhap"].Value.ToString();
                txtGiaNiemYet.Text = selectedRow.Cells["donGiaNiemYet"].Value.ToString();
                txtChatLieu.Text = selectedRow.Cells["chatLieu"].Value.ToString();
                loadAnhSP(txtMaSP.Text, flowLayoutPanel1, picSP_HD);

            }
        }
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
                    try
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
                    catch {
                        MessageBox.Show("Có lỗi mạng", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }   
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox.Height = 106;
                pictureBox.Width = 160; 
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
        private void cbSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSize.SelectedItem != null) // Đảm bảo đã chọn một mã size
            {
                string maSize = cbSize.Text;
                string maSanPham = txtMaSP.Text; // Lấy mã sản phẩm từ TextBox txtMaSP

                // Gọi BLL để lấy số lượng tương ứng
                MaSanPhamTheoSizeBLL msptsBLL = new MaSanPhamTheoSizeBLL();
                int soLuong = msptsBLL.LaySoLuongTheoMaSizeVaMaSanPham(maSize, maSanPham);

                // Hiển thị số lượng lên TextBox txtSoLuong
                txtSoLuong.Text = soLuong.ToString();
            }
        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            txtMaSP.ReadOnly = false;
            txtMaSP.Clear();
            txtTenSP.Clear();
            txtMoTaSP.Clear();
            txtGiaNhap.Clear();
            txtGiaNiemYet.Clear();
            txtChatLieu.Clear();
            flowLayoutPanel1.Controls.Clear();
        }

        private void btnSuaSP_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaSP.Text) ||
                string.IsNullOrWhiteSpace(txtTenSP.Text) ||
                string.IsNullOrWhiteSpace(txtMoTaSP.Text) ||
                string.IsNullOrWhiteSpace(txtGiaNhap.Text) ||
                string.IsNullOrWhiteSpace(txtGiaNiemYet.Text) ||
                string.IsNullOrWhiteSpace(txtChatLieu.Text)
                )
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần sửa.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                try
                {
                    // Lấy thông tin sản phẩm từ giao diện người dùng và cập nhật vào đối tượng SanPham
                    SanPham sp = new SanPham
                    {
                        maSanPham = txtMaSP.Text,
                        tenSanPham = txtTenSP.Text,
                        moTaSanPham = txtMoTaSP.Text,
                        giaNhap = int.Parse(txtGiaNhap.Text),
                        donGiaNiemYet = int.Parse(txtGiaNiemYet.Text),
                        chatLieu = txtChatLieu.Text,
                    };

                    // Gọi phương thức SuaSanPham từ lớp SanPhamBLL để thực hiện cập nhật sản phẩm vào CSDL
                    SanPhamBLL spbll = new SanPhamBLL();
                    spbll.SuaSanPham(sp);



                    // Hiển thị thông báo khi sửa thành công
                    MessageBox.Show("Sửa sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Tải lại danh sách sản phẩm sau khi sửa thành công
                    LoadDsSanPham();
                }
                catch (Exception exception)
                {
                    // Hiển thị thông báo khi sửa thất bại và bao gồm thông điệp lỗi từ ngoại lệ trong thông báo
                    MessageBox.Show("Sửa sản phẩm thất bại. Lỗi: " + exception.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaSP.Text) ||
                string.IsNullOrWhiteSpace(txtTenSP.Text) ||
                string.IsNullOrWhiteSpace(txtMoTaSP.Text) ||
                string.IsNullOrWhiteSpace(txtGiaNhap.Text) ||
                string.IsNullOrWhiteSpace(txtGiaNiemYet.Text) ||
                string.IsNullOrWhiteSpace(txtChatLieu.Text)
                )
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                try
                {
                    if (MessageBox.Show("Bạn có thật sự muốn xóa sản phẩm này?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string maSP = txtMaSP.Text;
                        SanPhamBLL spbll = new SanPhamBLL();
                        bool isForeignKey = spbll.IsForeignKeyInOtherTables(maSP);

                        if (isForeignKey)
                        {
                            MessageBox.Show("Xóa sản phẩm thất bại. Do sản phẩm đang được sử dụng.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                           
                        }
                        else
                        {
                            // Nếu không phải là khóa ngoại, thực hiện xóa sản phẩm
                            AnhSanPhamBLL asp = new AnhSanPhamBLL();
                            asp.XoaMaSanPhamTrongAnh(maSP);
                            spbll.XoaSanPham(maSP); // Truyền mã sản phẩm (chuỗi) vào phương thức
                            MessageBox.Show("Xóa sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadDsSanPham();
                        }
                    
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Xóa sản phẩm thất bại. Lỗi: " + exception.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        

        private void btnNhapLaiCTSP_Click(object sender, EventArgs e)
        {
            cbSize.SelectedIndex = -1;
            txtSoLuong.Clear();
        }

        private void btnThemCTSP_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaSP.Text) ||
                string.IsNullOrWhiteSpace(txtTenSP.Text) ||
                string.IsNullOrWhiteSpace(txtMoTaSP.Text) ||
                string.IsNullOrWhiteSpace(txtGiaNhap.Text) ||
                string.IsNullOrWhiteSpace(txtGiaNiemYet.Text) ||
                string.IsNullOrWhiteSpace(txtChatLieu.Text)
                )
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần thêm size.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                if (string.IsNullOrWhiteSpace(cbSize.Text) ||
                string.IsNullOrWhiteSpace(txtSoLuong.Text)
                )
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin size và số lượng sản phẩm.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    try
                    {
                        string maSize = cbSize.Text;
                        int soLuongTonKho = int.Parse(txtSoLuong.Text);
                        string maSP = txtMaSP.Text;
                        string maSPTS = maSP + '_' + maSize;

                        SanPhamBLL spbll = new SanPhamBLL();
                        MaSanPhamTheoSizeBLL sptsbll = new MaSanPhamTheoSizeBLL();


                        if (sptsbll.KiemTraMaSPTSTonTai(maSPTS))
                        {
                            MessageBox.Show("Mã sản phẩm và mã size đã tồn tại.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            MaSanPhamTheoSize spts = new MaSanPhamTheoSize
                            {
                                maSPTheoSize = maSP + '_' + maSize,
                                maSize = maSize,
                                maSanPham = maSP,
                                soLuongTonKho = soLuongTonKho
                            };

                            // Gọi phương thức ThemSizeVaSoLuong từ lớp MaSanPhamTheoSizeBLL để thêm số lượng size cho sản phẩm
                            sptsbll.ThemSizeVaSoLuong(spts);

                            MessageBox.Show("Thêm số lượng size cho sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        LoadChiTietSanPham(maSP);



                    }
                    catch (Exception exception)
                    {
                        // Hiển thị thông báo khi sửa thất bại và bao gồm thông điệp lỗi từ ngoại lệ trong thông báo
                        MessageBox.Show("Thêm sản phẩm thất bại. Lỗi: " + exception.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            // Sau khi thêm sản phẩm, bạn có thể cập nhật DataGridView để hiển thị danh sách sản phẩm mới
            LoadDsSanPham();
        }

        private void LoadChiTietSanPham(string msp)
        {
            MaSanPhamTheoSizeBLL msptsBLL = new MaSanPhamTheoSizeBLL();
            // Gọi phương thức để lấy danh sách chi tiết phiếu nhập dựa trên maPhieuNhap
            List<MaSanPhamTheoSize> danhSachChiTiet = msptsBLL.getSPTheoSIZE(new SanPham { maSanPham = msp });

            // Xóa các dòng hiện tại trong dgvChiTietPN (nếu có)
            dgvCTSP.Rows.Clear();

            // Thêm các dòng mới từ danh sách chi tiết phiếu nhập vào dgvChiTietPN
            foreach (MaSanPhamTheoSize ctsp in danhSachChiTiet)
            {
                // Tạo một hàng mới trong DataGridView
                DataGridViewRow row = new DataGridViewRow();

                // Thêm các ô thông tin từ đối tượng ChiTietPhieuNhap vào các ô trong hàng
                row.Cells.Add(new DataGridViewTextBoxCell { Value = ctsp.maSPTheoSize });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = ctsp.maSize });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = ctsp.maSanPham });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = ctsp.soLuongTonKho.ToString() });

                // Thêm hàng vào DataGridView
                dgvCTSP.Rows.Add(row);
            }

        }

        private void dgvCTSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvCTSP.Rows.Count)
            {

                DataGridViewRow selectedRow = dgvCTSP.Rows[e.RowIndex];
                foreach (var item in cbSize.Items)
                    if ((string)item == selectedRow.Cells["maSizeSP"].Value.ToString())
                        cbSize.SelectedItem = item;

                txtSoLuong.Text = selectedRow.Cells["soLuongTonKho"].Value.ToString();
                
            }
        }

        private void btnSuaCTSP_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaSP.Text) ||
                string.IsNullOrWhiteSpace(txtTenSP.Text) ||
                string.IsNullOrWhiteSpace(txtMoTaSP.Text) ||
                string.IsNullOrWhiteSpace(txtGiaNhap.Text) ||
                string.IsNullOrWhiteSpace(txtGiaNiemYet.Text) ||
                string.IsNullOrWhiteSpace(txtChatLieu.Text)
                )
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần sửa.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                if (string.IsNullOrWhiteSpace(cbSize.Text) ||
                string.IsNullOrWhiteSpace(txtSoLuong.Text)
                )
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin size và số lượng sản phẩm cần sửa.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    try
                    {

                        string maSize = cbSize.Text;
                        string maSP = txtMaSP.Text;
                        string maSPTS = maSP + '_' + maSize;
                        MaSanPhamTheoSizeBLL sptsBLL = new MaSanPhamTheoSizeBLL();
                        if (sptsBLL.KiemTraMaSPTSTonTai(maSPTS))
                        {
                            MaSanPhamTheoSize sp = new MaSanPhamTheoSize
                            {
                                maSize = cbSize.Text,
                                maSanPham = txtMaSP.Text,
                                soLuongTonKho = int.Parse(txtSoLuong.Text),
                            };

                            // Gọi phương thức SuaSanPham từ lớp SanPhamBLL để thực hiện cập nhật sản phẩm vào CSDL

                            sptsBLL.SuaSoLuongTonKho(sp);



                            // Hiển thị thông báo khi sửa thành công
                            MessageBox.Show("Sửa sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            MessageBox.Show("Sản phẩm chưa có size này. Hãy thêm size trước khi sửa!!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        // Tải lại danh sách sản phẩm sau khi sửa thành công
                        LoadChiTietSanPham(maSP);
                    }
                    catch (Exception exception)
                    {
                        // Hiển thị thông báo khi sửa thất bại và bao gồm thông điệp lỗi từ ngoại lệ trong thông báo
                        MessageBox.Show("Sửa sản phẩm thất bại. Lỗi: " + exception.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
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


        private void txtGiaNiemYet_Leave(object sender, EventArgs e)
        {
            // Kiểm tra xem ô textbox giá nhập và giá bán có chứa giá trị hợp lệ không.
            if (decimal.TryParse(txtGiaNhap.Text, out decimal giaNhap) && decimal.TryParse(txtGiaNiemYet.Text, out decimal giaBan))
            {
                // Kiểm tra nếu giá bán nhỏ hơn hoặc bằng giá nhập, hiển thị thông báo lỗi.
                if (giaBan <= giaNhap)
                {
                    MessageBox.Show("Giá bán phải lớn hơn giá nhập!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtGiaNiemYet.Focus();
                }
            }
        }

        private void txtTimKiemSP_TextChanged(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiemSP.Text;

            SanPhamBLL spbll = new SanPhamBLL();
            List<SanPham> ketQuaTimKiem = spbll.TimKiemSanPham(tuKhoa);

            // Xóa tất cả các hàng hiện có trong DataGridView
            dgvSanPham.Rows.Clear();
                // Nếu có kết quả tìm kiếm, thêm từng sản phẩm vào DataGridView
                foreach (SanPham sp in ketQuaTimKiem)
                {
                    dgvSanPham.Rows.Add(sp.maSanPham, sp.tenSanPham, sp.moTaSanPham, sp.giaNhap, sp.donGiaNiemYet, sp.chatLieu);
                }
        }

        private void btnXoaCTSP_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaSP.Text) ||
                string.IsNullOrWhiteSpace(txtTenSP.Text) ||
                string.IsNullOrWhiteSpace(txtMoTaSP.Text) ||
                string.IsNullOrWhiteSpace(txtGiaNhap.Text) ||
                string.IsNullOrWhiteSpace(txtGiaNiemYet.Text) ||
                string.IsNullOrWhiteSpace(txtChatLieu.Text)||
                string.IsNullOrWhiteSpace(cbSize.Text) ||
                string.IsNullOrWhiteSpace(txtSoLuong.Text) 
                )
            {
                MessageBox.Show("Vui lòng chọn sản phẩm theo size cần xóa.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                try
                {
                    if (MessageBox.Show("Bạn có thật sự muốn xóa size sản phẩm này?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string maSP = txtMaSP.Text;
                        string maSize = cbSize.Text;// Lấy mã sản phẩm từ TextBox
                        string maSPTS = maSP + '_' + maSize;
                        MaSanPhamTheoSizeBLL sptsBLL = new MaSanPhamTheoSizeBLL();
                        bool isForeignKey = sptsBLL.IsForeignKeyInOtherTables(maSPTS);

                        if (isForeignKey)
                        {
                            MessageBox.Show("Xóa size sản phẩm thất bại. Do sản phẩm đang được sử dụng.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }
                        else
                        {
                            sptsBLL.XoaSanPhamTheoSize(maSP, maSize); // Truyền mã sản phẩm (chuỗi) vào phương thức
                            MessageBox.Show("Xóa size sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadChiTietSanPham(maSP);
                        }
                        
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Xóa size sản phẩm thất bại. Lỗi: " + exception.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

       
    }
}
