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
    public partial class FAdminMenu : Form
    {
        //Fields
        private Button currentButton;

        private int tempIndex;
        private Form activeForm;
        int index = 0;
        public FAdminMenu()
        {
            InitializeComponent();
        }

        private Color SelectThemeColor()
        {

            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    panelTitleBar.BackColor = color;
                    panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                   
                }
            }
        }
        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(95, 111, 148);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
                activeForm.Close();
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktopPane.Controls.Add(childForm);
            this.panelDesktopPane.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitle.Text = childForm.Text;
        }
        private void btnQLSanPham_Click(object sender, EventArgs e)
        {
            index = 0;
            OpenChildForm(new Forms.FQLSanPham(), sender);
        }

        private void btnQLCuaHang_Click(object sender, EventArgs e)
        {
            index = 1;
            OpenChildForm(new Forms.FQLCuaHang(), sender);
        }

        private void btnQLKhachHang_Click(object sender, EventArgs e)
        {
            index = 2;
            OpenChildForm(new Forms.FQLKhachHang(), sender);
        }

        private void btnQLHoaDonBan_Click(object sender, EventArgs e)
        {
            index = 3;
            OpenChildForm(new Forms.FQLHoaDon(), sender);
        }

        private void btnQLDoanhThu_Click(object sender, EventArgs e)
        {
            index = 4;
            OpenChildForm(new Forms.FQLDoanhThu(), sender);
        }
        private void btnQLPhieuNhapKho_Click(object sender, EventArgs e)
        {
            index = 5;
            OpenChildForm(new Forms.FQLPhieuNhap(), sender);
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            this.Hide();
            lg.ShowDialog();
        }

        
        private void Reset()
        {
            DisableButton();
            lblTitle.Text = "HOME";
            panelTitleBar.BackColor = Color.FromArgb(110, 133, 183);
            panelLogo.BackColor = Color.FromArgb(37, 49, 109);
            currentButton = null;
            
        }

        private void panelLogo_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
            Reset();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }
        private void bntMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}