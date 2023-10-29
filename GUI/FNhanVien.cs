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
    public partial class FNhanVien : Form
    {
        private static NhanVien nv;
        ChucVu cv = new ChucVu();

        CuaHangBLL chBLL = new CuaHangBLL();
        ChucVuBLL cvBLL = new ChucVuBLL();
        CloudinaryBLL cloudBLL = new CloudinaryBLL();
        public FNhanVien()
        {
            InitializeComponent();

            pnKhachHangNVDef();
            GetNhanVien(); 

            loadInfoNhanVien();
               
        }
       
        public static NhanVien GetNhanVien()
        {         
            DangNhapBLL dangnhapbll = new DangNhapBLL();
            nv = dangnhapbll.getUser(Login.SDT);            
            return nv;
        }
        private void btDangXuatNV_Click(object sender, EventArgs e)
        {
            Login fad = new Login();
            this.Hide();
            fad.ShowDialog();
        }


      
        private void loadInfoNhanVien()
        {
            cv = cvBLL.getChucVuCuaNV(nv);

            lbTenCuaHang.Text = chBLL.getCuaHang(nv.maCuaHang).tenCuaHang;
            lbChucVuNV.Text = cv.tenChucVu;
            lbTenNV.Text = nv.tenNhanVien.ToString();

            //if (nv.gioiTinh == true)
            //    picBoxNV.Image = Image.FromFile("C:\\Users\\tring\\OneDrive\\Desktop\\test\\QLShopQuanAo\\Pic\\male-icon.jpg");
            //else
            //    picBoxNV.Image = Image.FromFile("C:\\Users\\tring\\OneDrive\\Desktop\\test\\QLShopQuanAo\\Pic\\icon-phu-nu.jpg");
            using (System.IO.MemoryStream stream = new System.IO.MemoryStream(cloudBLL.getAnhGioiTinh(nv.gioiTinh)))
            {
                picBoxNV.Image = Image.FromStream(stream);
            }
            if (cv.tenChucVu != "Cửa hàng trưởng")
            {
                pnDoanhThuNV.Hide();
                pnNhanVienNV.Hide();
                pnSanPhamNV.Hide();
            }
            
        }

        private void closeNhanVien_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            pnContainer.Controls.Clear();
            pnContainer.Controls.Add(userControl);
            userControl.BringToFront();
        }
        private void pnSanPhamNV_Click(object sender, EventArgs e)
        {
            lbSanPhamNV.BackColor = Color.DarkTurquoise;
            pnHoaDonNV.BackColor = Color.SkyBlue;
           
            
            pnNhanVienNV.BackColor = Color.SkyBlue;
            pnDoanhThuNV.BackColor = Color.SkyBlue;
            pnKhachHangNV.BackColor = Color.SkyBlue;
            pnSanPhamNV.BackColor = Color.DarkTurquoise;
            lbNhanVienNV.BackColor = Color.SkyBlue;
            lbKhachHangNV.BackColor = Color.SkyBlue;
            lbHoaDonNV.BackColor = Color.SkyBlue;
            lbDoanhThuNV.BackColor = Color.SkyBlue;


            FNVSanPham fnvsp = new FNVSanPham();
            addUserControl(fnvsp);

        }

        private void pnHoaDonNV_Click(object sender, EventArgs e)
        {
            lbHoaDonNV.BackColor = Color.DarkTurquoise;
            
           
            pnSanPhamNV.BackColor = Color.SkyBlue;           
            pnNhanVienNV.BackColor = Color.SkyBlue;
            pnKhachHangNV.BackColor = Color.SkyBlue;
            pnDoanhThuNV.BackColor = Color.SkyBlue;
            pnHoaDonNV.BackColor = Color.DarkTurquoise;
            lbNhanVienNV.BackColor = Color.SkyBlue;
            lbKhachHangNV.BackColor = Color.SkyBlue;
            lbSanPhamNV.BackColor = Color.SkyBlue;
            lbDoanhThuNV.BackColor = Color.SkyBlue;
            FNVHoaDon fnvhd = new FNVHoaDon();
            addUserControl(fnvhd);
        }

       private void pnKhachHangNVDef()
        {
            lbKhachHangNV.BackColor = Color.DarkTurquoise;
            pnHoaDonNV.BackColor = Color.SkyBlue;
            pnSanPhamNV.BackColor = Color.SkyBlue;
            
           
            pnNhanVienNV.BackColor = Color.SkyBlue;
            pnDoanhThuNV.BackColor = Color.SkyBlue;
            pnKhachHangNV.BackColor = Color.DarkTurquoise;
            lbNhanVienNV.BackColor = Color.SkyBlue;
            lbSanPhamNV.BackColor = Color.SkyBlue;
            lbHoaDonNV.BackColor = Color.SkyBlue;
            lbDoanhThuNV.BackColor = Color.SkyBlue;
            FNVKhachHang f = new FNVKhachHang();
            addUserControl(f);
        }
        private void pnKhachHangNV_Click(object sender, EventArgs e)
        {
            pnKhachHangNVDef();
        }

        private void pnNhanVienNV_Click(object sender, EventArgs e)
        {
            lbNhanVienNV.BackColor = Color.DarkTurquoise;
            pnHoaDonNV.BackColor = Color.SkyBlue;
            pnSanPhamNV.BackColor = Color.SkyBlue;            
            pnKhachHangNV.BackColor = Color.SkyBlue;
            
            pnDoanhThuNV.BackColor = Color.SkyBlue;
            pnNhanVienNV.BackColor = Color.DarkTurquoise;

            lbSanPhamNV.BackColor = Color.SkyBlue;
            lbKhachHangNV.BackColor = Color.SkyBlue;
            lbHoaDonNV.BackColor = Color.SkyBlue;
            lbDoanhThuNV.BackColor = Color.SkyBlue;
            FNVNhanVien f = new FNVNhanVien();
            addUserControl(f);
        }

        private void pnDoanhThuNV_Click(object sender, EventArgs e)
        {
            lbDoanhThuNV.BackColor = Color.DarkTurquoise;
            pnHoaDonNV.BackColor = Color.SkyBlue;
            pnSanPhamNV.BackColor = Color.SkyBlue;           
            pnKhachHangNV.BackColor = Color.SkyBlue;
            pnNhanVienNV.BackColor = Color.SkyBlue;
            pnDoanhThuNV.BackColor = Color.DarkTurquoise;
           

            lbNhanVienNV.BackColor = Color.SkyBlue;
            lbKhachHangNV.BackColor = Color.SkyBlue;
            lbHoaDonNV.BackColor = Color.SkyBlue;
            lbSanPhamNV.BackColor = Color.SkyBlue;
            FNVDoanhThu f = new FNVDoanhThu();
            addUserControl(f);

        }

      
        private void btDoiMatKhau_Click(object sender, EventArgs e)
        {
            PassChange f = new PassChange();
            f.Show();
        }
    }
}