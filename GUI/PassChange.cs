using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using DTO;

namespace GUI
{
    public partial class PassChange : Form
    {
        DangNhapBLL dnbll = new DangNhapBLL();
        NhanVienBLL nvbll = new NhanVienBLL();
        NhanVien nv = new NhanVien();
        public PassChange()
        {
            InitializeComponent();
            picCheckMK.Hide();
            picCheckMK_Re.Hide();
            nv = dnbll.getUser(Login.SDT);
            nv.pass = dnbll.giaiMaMK(nv.pass);
        }



        private void btPCClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPCMKNow_TextChanged(object sender, EventArgs e)
        {
            if (txtPCMKNow.Text == nv.pass)
            {
                picCheckMK.Show();
                lbPCWarning.Text = "";
                txtPCMKNew.ReadOnly = false;

            }
            else
            {
                txtPCMKNew.ReadOnly = true;
                txtPCMKN_Re.ReadOnly = true;
                lbPCWarning.Text = "Mật khẩu chưa đúng ";
                picCheckMK.Hide();
            }

        }



        private void picEyePassChange_MouseDown(object sender, MouseEventArgs e)
        {
            txtPCMKNow.UseSystemPasswordChar = false;
            txtPCMKNew.UseSystemPasswordChar = false;
            txtPCMKN_Re.UseSystemPasswordChar = false;
        }

        private void picEyePassChange_MouseUp(object sender, MouseEventArgs e)
        {
            txtPCMKNow.UseSystemPasswordChar = true;
            txtPCMKNew.UseSystemPasswordChar = true;
            txtPCMKN_Re.UseSystemPasswordChar = true;
        }

        private void txtPCMKNew_TextChanged(object sender, EventArgs e)
        {
            // Ky tu hon 8
            int i = 0;
            if (txtPCMKNew.Text.Length >= 8 )
            {
                lbPC8kytu.ForeColor = Color.Lime;
                i++;
            }
            else lbPC8kytu.ForeColor = Color.FromArgb(224, 224, 224);
            // Ky tu la chu Hoa
            if (Regex.Match(txtPCMKNew.Text, @".*[A-Z].*", RegexOptions.ECMAScript).Success)
            {
                lbPCChuHoa.ForeColor = Color.Lime;
                i++;
            }
            else lbPCChuHoa.ForeColor = Color.FromArgb(224, 224, 224);
            // Ky tu la chu Thuong
            if (Regex.Match(txtPCMKNew.Text, @".*[a-z].*", RegexOptions.ECMAScript).Success)
            {
                lbPCChuThuong.ForeColor = Color.Lime;
                i++;
            }
            else lbPCChuThuong.ForeColor = Color.FromArgb(224, 224, 224);
            // Ky tu la So
            if (Regex.Match(txtPCMKNew.Text, @".*[0-9].*", RegexOptions.ECMAScript).Success)
            {
                lbPCSo.ForeColor = Color.Lime;
                i++;
            }
            else lbPCSo.ForeColor = Color.FromArgb(224, 224, 224);
            // Ky Tu Dac Biet
            if (Regex.Match(txtPCMKNew.Text, @".*[^A-Za-z0-9].*", RegexOptions.ECMAScript).Success)
            {
                lbPCKyTu.ForeColor = Color.Lime;
                i++;
            }
            else lbPCKyTu.ForeColor = Color.FromArgb(224, 224, 224);
            if (i == 5)
            {
                lbPCWarning.Text = "";
                txtPCMKN_Re.ReadOnly = false;
            }
            else
            {
                txtPCMKN_Re.ReadOnly = true;
                lbPCWarning.Text = "Hãy đáp ứng đủ điều kiện. ";
            }
        }

        private void txtPCMKN_Re_TextChanged(object sender, EventArgs e)
        {
            if (txtPCMKNew.Text == txtPCMKN_Re.Text)
            {
                picCheckMK_Re.Show();
                lbPCWarning.Text = "";
            }
            else
            {
                lbPCWarning.Text = "Mật khẩu chưa giống !";
                picCheckMK_Re.Hide();
            }
        }

        private void btPCDMK_Click(object sender, EventArgs e)
        {
            if (txtPCMKNow.Text == "" || txtPCMKNew.Text == "" || txtPCMKN_Re.Text == "")
                lbPCWarning.Text = "Hãy điền đầy đủ thông tin !";
            else
            {
                if (nvbll.changePassWord(dnbll.maHoaMK(txtPCMKN_Re.Text), nv.maNhanVien) && txtPCMKNew.Text == txtPCMKN_Re.Text)
                {
                    lbPCWarning.Text = "Đổi mật khẩu thành công !";
                }
                else
                    lbPCWarning.Text = "Đổi mật khẩu thất bại !";
            }
        }
    }
}