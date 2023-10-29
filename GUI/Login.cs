using BLL;
using DTO;
using System;
using System.Collections;
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
    public partial class Login : Form
    {
        DangNhapBLL dangnhapbll = new DangNhapBLL();
        NhanVien nv = new NhanVien();

        public int i;
        public static String SDT = "";


        public Login()
        {
            InitializeComponent();
            picLogin.ImageLocation = "https://i.pinimg.com/564x/4c/2c/14/4c2c1450672663d539c5900425f43b9f.jpg";
            lbKetQuaLogin.ForeColor = Color.Red;
        }

        private void txtTaiKhoan_Click(object sender, EventArgs e)
        {
            txtTaiKhoan.BackColor = Color.LightGray;
            palTaiKhoan.BackColor = Color.LightGray;
            accontLogin.BackColor = Color.LightGray;
            panelAcount.BackColor = Color.Black;

            txtMatKhau.BackColor = Color.White;
            palMatKhau.BackColor = Color.White;
            picPassLogin.BackColor = Color.White;
            palPassLogin.BackColor = Color.DarkBlue;

        }

        private void txtMatKhau_Click(object sender, EventArgs e)
        {
            txtMatKhau.BackColor = Color.LightGray;
            palMatKhau.BackColor = Color.LightGray;
            picPassLogin.BackColor = Color.LightGray;
            palPassLogin.BackColor = Color.Black;
            txtTaiKhoan.BackColor = Color.White;
            palTaiKhoan.BackColor = Color.White;
            accontLogin.BackColor = Color.White;
            panelAcount.BackColor = Color.DarkBlue;
        }

        private void picEyeLogin_MouseDown(object sender, MouseEventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = false;
        }

        private void picEyeLogin_MouseUp(object sender, MouseEventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = true;
        }

        private void btDangNhap_Click(object sender, EventArgs e)
        {


        }

        private void btDangNhap_Enter(object sender, EventArgs e)
        {
            btDangNhap_Click_1(sender, e);
        }
        int soLanSaiDangNhap = 1;
        private void btDangNhap_Click_1(object sender, EventArgs e)
        {
            if (txtTaiKhoan.Text == "" || txtMatKhau.Text == "")
            {
                lbKetQuaLogin.Text = "Hãy điền đầy đủ thông tin !!";
            }
            else
            {
                nv.soDienThoai = txtTaiKhoan.Text;
                nv.pass = txtMatKhau.Text;
                i = dangnhapbll.CheckUser(nv);

                if (i == 0)
                {
                    lbKetQuaLogin.Text = "Sai tài khoản hoặc mật khẩu lần " + soLanSaiDangNhap.ToString() + " !";
                    soLanSaiDangNhap++;
                    if (soLanSaiDangNhap == 5)
                    {
                        MessageBox.Show("Bạn đã nhập sai mật khẩu quá nhiều lần. Ứng dụng sẽ tự đóng.");
                        Application.Exit();
                    }
                }
                else if (i == 1)
                {
                    FAdminMenu fad = new FAdminMenu();
                    this.Hide();
                    fad.ShowDialog();
                }
                else
                {
                    FNhanVien fnv = new FNhanVien();
                    this.Hide();
                    fnv.Show();
                }
            }
        }


        private void txtTaiKhoan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && (!char.IsDigit(e.KeyChar)) && (e.KeyChar != 8 || e.KeyChar != 13))
            {
                e.Handled = true;

            }
            string DemTaiKhoan = txtTaiKhoan.Text + e.KeyChar;
            if (DemTaiKhoan.Length > 10 && e.KeyChar != 8 )
            {
                e.Handled = true;
                lbKetQuaLogin.Text = "SDT không quá 10 chữ số !!";
            }
            else lbKetQuaLogin.Text = "";
        }

        private void txtTaiKhoan_TextChanged(object sender, EventArgs e)
        {
            SDT = txtTaiKhoan.Text;
        }

        private void txtQuenMatKhau_Click(object sender, EventArgs e)
        {
            if (txtTaiKhoan.Text == "")
                lbKetQuaLogin.Text = "Hãy nhập số điện thoại của bạn .";
            else
            {
                LoginForget lfg = new LoginForget();
                lfg.Show();
            }
        }
    }
}