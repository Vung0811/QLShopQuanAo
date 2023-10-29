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
    public partial class FQLKhachHang : Form
    {
        public FQLKhachHang()
        {
            InitializeComponent();
            loadKhachHangList();
        }
        List<KhachHang> dskhGui;
        private void loadKhachHangList()
        {
            KhachHangBLL khBLL = new BLL.KhachHangBLL();
            dskhGui = khBLL.getKhachHangList(null);
            dgvKhachHang.Rows.Clear();
            string gt = null;
            foreach (KhachHang kh in dskhGui)
            {
                // Tạo một hàng mới trong DataGridView
                DataGridViewRow row = new DataGridViewRow();

                // Thêm các ô thông tin từ đối tượng SanPham vào các ô trong hàng
                row.Cells.Add(new DataGridViewTextBoxCell { Value = kh.maKhachHang });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = kh.tenKhach });
                if (kh.gioiTinh == true)
                {
                    gt = "Nam";
                }
                else
                {
                    gt = "Nữ";
                }
                row.Cells.Add(new DataGridViewTextBoxCell { Value = gt });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = kh.ngaySinh });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = kh.diaChi });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = kh.soDienThoai });

                // Thêm hàng vào DataGridView
                dgvKhachHang.Rows.Add(row);
            }

        }

        private void btnGuiTN_Click(object sender, EventArgs e)
        {
            try
            {
                string promotionMessage = rtxtTinNhanGui.Text;
                KhachHangBLL khBLL = new KhachHangBLL();
                khBLL.SendPromotionSMS(promotionMessage);
                MessageBox.Show("Gửi tin nhắn cho khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exception)
            {
                // Hiển thị thông báo khi sửa thất bại và bao gồm thông điệp lỗi từ ngoại lệ trong thông báo
                MessageBox.Show("Gửi tin nhắn cho khách hàng thất bại! Lỗi: " + exception.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void SearchKhachHang(string keyword)
        {
            // Xóa tất cả các hàng hiện có trong DataGridView
            dgvKhachHang.Rows.Clear();

            // Chuyển đổi từ khóa tìm kiếm sang chữ thường
            keyword = keyword.ToLower();

            // Lặp qua danh sách KhachHang ban đầu và thêm các hàng thỏa mãn tìm kiếm
            foreach (KhachHang kh in dskhGui)
            {
                string gt = kh.gioiTinh ? "Nam" : "Nữ";

                // Chuyển đổi giá trị của mỗi trường sang chữ thường
                string maKhachHang = kh.maKhachHang.ToLower();
                string tenKhach = kh.tenKhach.ToLower();
                string gtLowerCase = gt.ToLower();
                string ngaySinh = kh.ngaySinh.ToString().ToLower();
                string diaChi = kh.diaChi.ToLower();
                string soDienThoai = kh.soDienThoai.ToLower();

                // Kiểm tra xem bất kỳ trường nào của KhachHang chứa từ khóa tìm kiếm
                if (maKhachHang.Contains(keyword) ||
                    tenKhach.Contains(keyword) ||
                    gtLowerCase.Contains(keyword) ||
                    ngaySinh.Contains(keyword) ||
                    diaChi.Contains(keyword) ||
                    soDienThoai.Contains(keyword))
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = kh.maKhachHang });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = kh.tenKhach });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = gt });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = kh.ngaySinh });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = kh.diaChi });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = kh.soDienThoai });

                    dgvKhachHang.Rows.Add(row);
                }
            }
        }

        private void txtTimKiemKH_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimKiemKH.Text;
            SearchKhachHang(keyword);
        }

        private void loadHoaDonList(string x)
        {
            KhachHang kh = new KhachHang();
            kh.maKhachHang = x;
            HoaDonBanBLL hdbBLL = new HoaDonBanBLL();
            List<HoaDonBan> dshdGui = hdbBLL.getHoaDonBanList(kh);
            dgvQLHoaDon.Rows.Clear();
            foreach (HoaDonBan hd in dshdGui)
            {
                // Tạo một hàng mới trong DataGridView
                DataGridViewRow row = new DataGridViewRow();

                // Thêm các ô thông tin từ đối tượng SanPham vào các ô trong hàng
                row.Cells.Add(new DataGridViewTextBoxCell { Value = hd.maHoaDon });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = hd.maNhanVien });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = hd.maKhachHang });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = hd.ngayLapHoaDon });

                // Thêm hàng vào DataGridView
                dgvQLHoaDon.Rows.Add(row);
            }
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvKhachHang.Rows.Count)
            {
                DataGridViewRow selectedRow = dgvKhachHang.Rows[e.RowIndex];
                
                loadHoaDonList(selectedRow.Cells["maKhachHang"].Value.ToString());
            }
        }

        private void dgvKhachHang_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvKhachHang.Columns[e.ColumnIndex].Name == "ngaySinhKH" && e.Value != null)
            {
                // Định dạng giá trị trong cột "Ngày nhập" theo định dạng dd/MM/yyyy
                DateTime dateValue = (DateTime)e.Value;
                e.Value = dateValue.ToString("dd/MM/yyyy");
                e.FormattingApplied = true; // Đánh dấu rằng việc định dạng đã được áp dụng
            }
        }
    }
}
