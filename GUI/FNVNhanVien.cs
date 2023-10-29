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

namespace GUI
{
    public partial class FNVNhanVien : UserControl
    {
        // Gọi Các lớp BLL Cần thiết
        NhanVienBLL nvbll = new NhanVienBLL();
        DangNhapBLL dnbll = new DangNhapBLL();
        CuaHangBLL chbll = new CuaHangBLL();
        ChucVuBLL cvBLL = new ChucVuBLL();

        NhanVien nv = FNhanVien.GetNhanVien();
        String mch = "";
        public FNVNhanVien()
        {
            InitializeComponent();
            mch = nv.maCuaHang;
            loadNhanVien(mch, null);
         
            lbNVNVCuaHang.Text = chbll.getCuaHang(mch).tenCuaHang;
            

            comboBoxChucVu();
            comboBoxGioiTinh();
        }
        private void loadNhanVien(String mch, String x)
        {

            dgNVNV.DataSource = nvbll.getNhanVienList(mch, x);

            dgNVNV.Columns["maNhanVien"].HeaderText = "Mã NV";
            dgNVNV.Columns["hoNhanVien"].HeaderText = "Họ NV";
            dgNVNV.Columns["tenNhanVien"].HeaderText = "Tên NV";
            dgNVNV.Columns["gioiTinh"].HeaderText = "Giới Tính";
            dgNVNV.Columns["diaChi"].HeaderText = "Địa Chỉ";
            dgNVNV.Columns["soDienThoai"].HeaderText = "SĐT";
            dgNVNV.Columns["ngaySinh"].HeaderText = "Ngày Sinh";

            dgNVNV.Columns["pass"].Visible = false;
            dgNVNV.Columns["maCuaHang"].Visible = false;
        }

        private void txtNVNVSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && (!char.IsDigit(e.KeyChar)))
            {
                e.Handled = true;

            }
            string DemTaiKhoan = txtNVNVSDT.Text + e.KeyChar;
            if (DemTaiKhoan.Length >= 11)
            {
                lbWarningNVNV.Text = "SDT không quá 10 số !";
            }
            else { lbWarningNVNV.Text = ""; }
        }

        private void txtNVNVHo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 9 && !(char.IsWhiteSpace(e.KeyChar)))
                e.Handled = true;
        }

        private void txtNVNVSearch_TextChanged(object sender, EventArgs e)
        {
            loadNhanVien(mch, txtNVNVSearch.Text);
        }

        private void dgNVNV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            txtNVNVMa.Text = dgNVNV.SelectedRows[0].Cells[0].Value.ToString();
            txtNVNVHo.Text = dgNVNV.SelectedRows[0].Cells[1].Value.ToString();
            txtNVNVTen.Text = dgNVNV.SelectedRows[0].Cells[2].Value.ToString();
            string gt = dgNVNV.SelectedRows[0].Cells[3].Value.ToString();
            if (gt == "True")
            {
                cbNVNVGioiTinh.SelectedIndex = cbNVNVGioiTinh.FindStringExact("Nam");
            }
            else
            {
                cbNVNVGioiTinh.SelectedIndex = cbNVNVGioiTinh.FindStringExact("Nữ");
            }
            dpNVNVNgaySinh.Value = (DateTime)(dgNVNV.SelectedRows[0].Cells[6].Value);
            txtNVNVSDT.Text = dgNVNV.SelectedRows[0].Cells[5].Value.ToString();
            txtNVNVDiaChi.Text = dgNVNV.SelectedRows[0].Cells[4].Value.ToString();

            string maChucVu = dgNVNV.SelectedRows[0].Cells[7].Value.ToString();

            cbNVNVChucVu.SelectedValue = maChucVu;
            lbWarningNVNV.Text = "";
                                
        }
        private void comboBoxChucVu()
        {
            List<ChucVu> cvl = cvBLL.GetChucVu();
            cbNVNVChucVu.DataSource = cvl;
            cbNVNVChucVu.ValueMember = "maChucVu";
            cbNVNVChucVu.DisplayMember = "tenChucVu";
            cbNVNVChucVu.DropDownStyle = ComboBoxStyle.DropDownList;

        }      
        private void comboBoxGioiTinh()
        {
            List<String> gioiTinh = new List<string>() { "Nam", "Nữ" };
            cbNVNVGioiTinh.DataSource = gioiTinh;
            cbNVNVGioiTinh.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private Boolean getGioiTinhNV()
        {
            Boolean gt = false;
            String sgt = cbNVNVGioiTinh.SelectedItem.ToString();
            if (sgt == "Nam")
                gt = true;
            return gt;
        }
        private NhanVien setNhanVien()
        {
            nv.maNhanVien = txtNVNVMa.Text;
            nv.hoNhanVien = txtNVNVHo.Text;
            nv.tenNhanVien = txtNVNVTen.Text;
            nv.gioiTinh = getGioiTinhNV();
            nv.soDienThoai = txtNVNVSDT.Text;
            nv.diaChi = txtNVNVDiaChi.Text;
            nv.ngaySinh = dpNVNVNgaySinh.Value;

            nv.chucVu = cbNVNVChucVu.SelectedValue.ToString();
            return nv;
        }
        private void reset()
        {
            txtNVNVMa.Text = "";
            txtNVNVHo.Text = "";
            txtNVNVTen.Text = "";
           
            txtNVNVSDT.Text = "";
            txtNVNVDiaChi.Text = "";
            dpNVNVNgaySinh.Value = DateTime.Now;

        }
        private void btThemNVNV_Click(object sender, EventArgs e)
        {
            if (txtNVNVHo.Text == "" || txtNVNVTen.Text == "" || cbNVNVGioiTinh.Text == "" ||
                txtNVNVDiaChi.Text == "" || txtNVNVSDT.Text == "" )
                lbWarningNVNV.Text = "Hãy điền đầy đủ thông tin !";
            else
            {
                setNhanVien();
                if (!nvbll.checkNhanVienValid(nv))
                {
                    if (nvbll.themNV(mch, nv))
                    {
                        lbWarningNVNV.Text = "Thêm mới nhân viên thành công !";
                        loadNhanVien(mch, null);
                        reset();
                    }
                    else
                        lbWarningNVNV.Text = "Thêm thất bại !";
                }
                else
                    lbWarningNVNV.Text = "Nhân Viên đã tồn tại !";
            }
        }

        private void btNVNVSua_Click(object sender, EventArgs e)
        {
            if (txtNVNVMa.Text == "")
                lbWarningNVNV.Text = "Hãy chọn Nhân Viên để Sửa !";
            else
            {
                if (txtNVNVHo.Text == "" || txtNVNVTen.Text == "" || cbNVNVGioiTinh.Text == "" ||
                    txtNVNVDiaChi.Text == "" || txtNVNVSDT.Text == "" )
                    lbWarningNVNV.Text = "Hãy điền đầy đủ thông tin !";
                else
                {
                    setNhanVien();
                    if (nvbll.editNhanVien(nv))
                    {
                        loadNhanVien(mch, null);
                        lbWarningNVNV.Text = "Sửa Thành Công Nhân Viên";
                        reset();
                    }
                    else
                        lbWarningNVNV.Text = "Sửa thất bại ! ";
                }
            }
        }

        private void btNVNVReset_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void btNVNVXoa_Click(object sender, EventArgs e)
        {
            if (txtNVNVMa.Text == "")
                lbWarningNVNV.Text = "Hãy chọn Nhân Viên để xóa !";
            else
            {
                setNhanVien();
                if (nvbll.delNhanVien(nv))
                {
                    lbWarningNVNV.Text = "Xóa thành công !";
                    loadNhanVien(mch, null);
                    reset();
                }
                else
                    lbWarningNVNV.Text = "Xóa thất bại !";
            }
        }


    }
}