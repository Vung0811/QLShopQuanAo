using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Security.Cryptography;

namespace GUI
{
    public partial class FNVSanPham : UserControl
    {

        SanPhamBLL spBLL = new SanPhamBLL();
        SanPham_CuaHangBLL spchBLL = new SanPham_CuaHangBLL();
        SizeBLL sBLL = new SizeBLL();
        MaSanPhamTheoSizeBLL sptsBLL = new MaSanPhamTheoSizeBLL();
        PhieuNhapBLL pnBLL = new PhieuNhapBLL();
        CuaHangBLL chBLL = new CuaHangBLL();
        NhanVienBLL nvBLL = new NhanVienBLL();
        PrintBLL pBLL = new PrintBLL();
        List<SanPham> spl = null;
        List<SanPham_CuaHang> spchl = null;
        List<DTO.Size> sizel = null;
        List<ChiTietPhieuNhap> ctpnl = null;
        List<PhieuNhap> pnl = null;

        ChiTietPhieuNhap ctpn = null;
        PhieuNhap pn = null;
        NhanVien nv = FNhanVien.GetNhanVien();
        CuaHang ch = null;
        FNVKhachHang fnvkh = new FNVKhachHang();

        public FNVSanPham()
        {
            InitializeComponent();

            tabConSPMenu.SizeMode = TabSizeMode.Fixed;
            tabConSPMenu.ItemSize = new System.Drawing.Size(0, 1);

            spl = spBLL.LoadDlSanPham();
            spchl = spchBLL.getSPTheoCuaHangList();
            pnl = pnBLL.getPhieuNhapList(nv);
            ch = chBLL.getCuaHang(nv.maCuaHang);

            // Load ComboBox Size
            sizel = sBLL.GetSizes();
            cbSize.DataSource = sizel;
            dgDSPN_SP.Hide();
            //Load Danh Sách Sản Phẩm Theo Size của từng cửa hàng
            loadDanhSachSP(dgSPNV);
            picSPSP.Hide();
        }
        private void loadDanhSachSP(DataGridView dgSPNV)
        {
            fnvkh.loadSanPhamNhanVien(dgSPNV, spl, spchl);
            dgSPNV.Columns["giaNhap"].Visible = true;
            dgSPNV.Columns["giaNhap"].HeaderText = "Giá nhập";

            if (!dgSPNV.Columns.Contains("NhapButton"))
            {
                // Tạo cột nhập button
                DataGridViewButtonColumn nhapbutton = new DataGridViewButtonColumn();
                nhapbutton.Name = "NhapButton";
                nhapbutton.HeaderText = " ";
                nhapbutton.Text = "Nhập";
                nhapbutton.UseColumnTextForButtonValue = true;


                // Thêm cột nút "Nhập" vào DataGridView
                dgSPNV.Columns.Add(nhapbutton);
            }
        }

        private void dgSPNV_CellClick(object sender, DataGridViewCellEventArgs e)

        {
            if (e.RowIndex == -1) return;
            txtMaSP.Text = dgSPNV.SelectedRows[0].Cells["maSPTheoSize"].Value.ToString();
            txtSP_Ten.Text = dgSPNV.SelectedRows[0].Cells["tenSanPham"].Value.ToString();
            txtMoTaSP.Text = dgSPNV.SelectedRows[0].Cells["moTaSanPham"].Value.ToString();
            txtGiaNhap.Text = dgSPNV.SelectedRows[0].Cells["giaNhap"].Value.ToString();
            txtGiaNiemYet.Text = dgSPNV.SelectedRows[0].Cells["donGiaNiemYet"].Value.ToString();
            txtChatLieu.Text = dgSPNV.SelectedRows[0].Cells["chatLieu"].Value.ToString();
            txtSoLuong.Text = dgSPNV.SelectedRows[0].Cells["soLuong"].Value.ToString();

            MaSanPhamTheoSize spts = new MaSanPhamTheoSize();
            spts.maSPTheoSize = txtMaSP.Text;
            spts = sptsBLL.getMSPTheoSize(spts);
            foreach (DTO.Size size in cbSize.Items)
            {
                if (size.maSize == spts.maSize)
                {
                    cbSize.SelectedItem = size;
                    break;
                }
            }
            String msp = txtMaSP.Text.Split('_')[0];
            fnvkh.loadAnhSP(msp, fpPicSP, picSPSP);
            if (e.RowIndex >= 0 && e.ColumnIndex == dgSPNV.Columns["NhapButton"].Index)
            {
                ctpn = new ChiTietPhieuNhap();
                if (pn == null)
                {
                    lbWarningPN_SP.Text = "Hãy lập phiếu nhập trước ! ";
                }
                else
                {
                    if((int)dgSPNV.SelectedRows[0].Cells["soLuong"].Value > 40)
                    {
                        lbWarningPN_SP.Text = "Sản phẩm đang có quá nhiều ! ";
                    }
                    else
                    {
                        bool maSanPhamValid = ctpnl.Exists(ct => ct.maSPTheoSize == txtMaSP.Text);

                        if (!maSanPhamValid)
                        {
                            ctpn.maPhieuNhap = pn.maPhieuNhap;
                            int i = ShowInputDialog();
                            if (i > 0)
                            {
                                lbWarningPN_SP.Text = " Bạn đã bấm nhập thành công !";
                                ctpn.soLuong = i;
                                ctpn.maSPTheoSize = txtMaSP.Text;
                                ctpnl.Add(ctpn);
                            }
                            else { lbWarningPN_SP.Text = " Số lượng nhập không hợp lệ"; }

                        }
                        else
                        {
                            lbWarningPN_SP.Text = "Sản Phẩm đã nằm trong list ";
                        }
                    }    
                }

            }

        }

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
        private void txtSPSearch_TextChanged(object sender, EventArgs e)
        {
            spl = spBLL.TimKiemSanPham(txtSPSearch.Text);
            spchl = spchBLL.getSPTheoCuaHangList();
            fnvkh.loadSanPhamNhanVien(dgSPNV, spl, spchl);
        }

        private void dgSPNV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewRow row = dgSPNV.Rows[e.RowIndex];

            if (row.Cells["soLuong"].Value != null)
            {
                int soLuong = Convert.ToInt32(row.Cells["soLuong"].Value);
                if (soLuong < 10)
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 128, 128);
                }
                else
                {
                    if (soLuong < 20)
                    {
                        row.DefaultCellStyle.BackColor = Color.FromArgb(244, 164, 96);
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.FromArgb(0, 250, 154);
                    }
                }
            }
        }


        // ======================= Phiếu Nhập ======================

        // Load các danh sách phiếu nhập
        private void loadDSPhieuNhap(List<PhieuNhap> pnll)
        {
            dgPhieuNhap.DataSource = pnll;
            dgPhieuNhap.Columns["maPhieuNhap"].HeaderText = "Mã Phiếu Nhập";
            dgPhieuNhap.Columns["maNhanVien"].HeaderText = "Mã Nhân Viên";
            dgPhieuNhap.Columns["maCuaHang"].HeaderText = "Mã Cửa Hàng";
            dgPhieuNhap.Columns["ngayNhap"].HeaderText = "Ngày Nhập";
            dgPhieuNhap.Columns["trangThai"].HeaderText = "Trạng Thái";
            dgPhieuNhap.Columns["maCuaHang"].Visible = false;
            dgPhieuNhap.Columns["TongTien"].Visible = false;
        }
        private void loadDS_CTPN(DataGridView dgCTPN, List<ChiTietPhieuNhap> ctpnl)
        {
            dgCTPN.DataSource = ctpnl;

            dgCTPN.Columns["maSPTheoSize"].HeaderText = "Mã Sản Phẩm";
            dgCTPN.Columns["soLuong"].HeaderText = "Số Lượng";
            dgCTPN.Columns["maPhieuNhap"].Visible = false;


            if (!dgCTPN.Columns.Contains("unitprice"))
            {
                DataGridViewTextBoxColumn unitprice = new DataGridViewTextBoxColumn();
                unitprice.HeaderText = "Giá Tiền";
                unitprice.Name = "unitprice";
                dgCTPN.Columns.Add(unitprice);
            }
            if (!dgCTPN.Columns.Contains("total"))
            {
                DataGridViewTextBoxColumn total = new DataGridViewTextBoxColumn();
                total.HeaderText = "Tổng Tiền";
                total.Name = "total";
                dgCTPN.Columns.Add(total);
            }
            int i = 0;
            foreach (DataGridViewRow row in dgCTPN.Rows)
            {
                String msp = row.Cells["maSPTheoSize"].Value.ToString();
                int soLuong = Convert.ToInt32(row.Cells["soLuong"].Value);
                int unitpsrice;

                foreach (SanPham sp in spl)
                {
                    if (msp.Contains(sp.maSanPham))
                    {
                        unitpsrice = sp.giaNhap;
                        row.Cells["unitprice"].Value = unitpsrice;
                        row.Cells["total"].Value = unitpsrice * soLuong;
                        i += Convert.ToInt32(row.Cells["total"].Value);
                    }

                }
            }
            lbDSPN_Tong.Text = i.ToString() + "VNĐ";
            txtTongTienPN.Text = i.ToString() + "VNĐ";
        }
        private void dgPhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            lbDSPN_Ma.Text = dgPhieuNhap.SelectedRows[0].Cells["maPhieuNhap"].Value.ToString();
            lbDSPN_NV.Text = nvBLL.getNhanVien(dgPhieuNhap.SelectedRows[0].Cells["maNhanVien"].Value.ToString()).tenNhanVien;
            lbDSPN_Ngay.Text = ((DateTime)(dgPhieuNhap.SelectedRows[0].Cells["ngayNhap"].Value)).ToShortDateString();
            Boolean tt = (Boolean)dgPhieuNhap.SelectedRows[0].Cells["trangThai"].Value;
            if (tt)
            {
                lbDSPN_TT.Text = "Đã Nhập";
                lbDSPN_TT.ForeColor = Color.Green;
            }
            else
            {
                lbDSPN_TT.Text = "Chưa Nhập";
                lbDSPN_TT.ForeColor = Color.Red;
            }

            pn = new PhieuNhap();
            pn.maPhieuNhap = lbDSPN_Ma.Text;

            ctpnl = pnBLL.getCTPhieuNhap(pn);
            loadDS_CTPN(dgCTPN, ctpnl);
        }
        // Lập Phiếu Nhập
        private void btLapPhieuNhap_Click(object sender, EventArgs e)
        { 
            if (pn == null)
            {
                pn = new PhieuNhap();
                pn = pnBLL.SetPhieuNhap(nv);

                lbWarningPN_SP.Text = " Lập phiếu nhập thành công !";
                dgCTPN_Now.DataSource = null;
                ctpnl = new List<ChiTietPhieuNhap>();
               
            }
            else
                lbWarningPN_SP.Text = " Phiếu nhập đã được lập !";
        }


        // Xem Chi Tiết Phiếu Nhập
        private void btXemCTPN_Click(object sender, EventArgs e)
        {
            if (pn == null)
                lbWarningPN_SP.Text = "Hãy lập phiếu nhập trước !";
            else
            {
                lbWarningPN_SP.Text = "";
                tabConSPMenu.SelectedTab = tabConSPMenu.TabPages["tabCTPhieuDat"];

                txtMaPN.Text = pn.maPhieuNhap;
                txtTenCH_PN.Text = ch.tenCuaHang;
                txtTenNVPN.Text = nv.tenNhanVien;

                dgCTPN_Now.DataSource = null;
                loadDS_CTPN(dgCTPN_Now, ctpnl);
            }
        }

        private void btBackPN_Click(object sender, EventArgs e)
        {
            tabConSPMenu.SelectedTab = tabConSPMenu.TabPages["tabSanPham"];
            bool pnValid = pnl.Exists(pnn => pnn.maPhieuNhap == pn.maPhieuNhap);
            if (pnValid)
            {
                pn = null;
            }
        }

        private void dgCTPN_Now_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            txtMaSP_PN.Text = dgCTPN_Now.SelectedRows[0].Cells["maSPTheoSize"].Value.ToString();
            txtSLSP_PN.Text = dgCTPN_Now.SelectedRows[0].Cells["soLuong"].Value.ToString();
        }
        // =================== Chi Tiết Phiếu Nhập Button ============================

        // Tác vụ Hỗ trợ
        private void resetCTPN()
        {
            txtSLSP_PN.Text = "";
            txtMaSP_PN.Text = "";
        }
        private void txtSLSP_PN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && (!char.IsDigit(e.KeyChar)) && (e.KeyChar != 8 || e.KeyChar != 13))
            {
                e.Handled = true;

            }
        }
        private void resetDSPN()
        {
            lbDSPN_Ma.Text = "";
            lbDSPN_Ngay.Text = "";
            lbDSPN_NV.Text = "";
            lbDSPN_Tong.Text = "";
            lbDSPN_TT.Text = "";
        }

        // Button Sửa CTPN 
        private void btCTPNSua_Click(object sender, EventArgs e)
        {
            bool pnValid = pnl.Exists(pnn => pnn.maPhieuNhap == pn.maPhieuNhap);
            if (pnValid)
            {
                lbWarningCTPN.Text = "Phiếu nhập sau khi lưu không thể sửa ";
            }    
            else
            {
                if (txtMaSP_PN.Text == "")
                {
                    lbWarningCTPN.Text = "Hãy chọn sản phẩm muốn sửa !";
                }
                else
                {
                    if (txtSLSP_PN.Text == "")
                        lbWarningCTPN.Text = "Hãy nhập số lượng cần nhập !";
                    else
                    {
                        int i = Convert.ToInt32(txtSLSP_PN.Text);

                        ChiTietPhieuNhap sanPhamCanCapNhat = ctpnl.FirstOrDefault(ctpn => ctpn.maSPTheoSize == txtMaSP_PN.Text);
                        sanPhamCanCapNhat.soLuong = Convert.ToInt32(txtSLSP_PN.Text);
                        dgCTPN.Refresh();
                       
                        resetCTPN();
                        lbWarningCTPN.Text = "Đổi số lượng thành công !";

                    }
                }
            }    
        }
        // Button Xóa CTPN 
        private void btCTPNXoa_Click(object sender, EventArgs e)
        {
            bool pnValid = pnl.Exists(pnn => pnn.maPhieuNhap == pn.maPhieuNhap);
            if (pnValid)
            {
                lbWarningCTPN.Text = "Phiếu nhập sau khi lưu không thể xóa !";
            }    
           else
            {
                if (txtMaSP_PN.Text == "")
                    lbWarningCTPN.Text = "Hãy chọn sản Phẩm để xóa";
                else
                {
                    ctpnl.RemoveAll(ctpn => ctpn.maSPTheoSize == txtMaSP_PN.Text);
                    
                    dgCTPN_Now.DataSource = null;
                    loadDS_CTPN(dgCTPN_Now, ctpnl);
                    resetCTPN();
                    lbWarningCTPN.Text = "Xóa SP Thành công !";
                }
            }    
        }
        // Button Lưu CTPN
        private void btLuuPN_Click(object sender, EventArgs e)
        {
            bool pnValid = pnl.Exists(pnn => pnn.maPhieuNhap == pn.maPhieuNhap);
            if (pnValid)
            {
                lbWarningCTPN.Text = "Phiếu Nhập đã được lưu";
            }    
           else
            {
                if (ctpnl.Count == 0)
                    lbWarningCTPN.Text = "Phiếu rỗng, không có gì để lưu ! ";
                else
                {
                    DialogResult result = MessageBox.Show("Bạn có chắc sẽ lưu Phiếu Nhập ?", "Phiếu Nhập", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                    if (result == DialogResult.OK)
                    {
                        if (pnBLL.addPhieuNhap(pn))
                        {
                            bool checkThanhCong = true;

                            foreach (ChiTietPhieuNhap ctpn in ctpnl)
                            {

                                if (!pnBLL.addCTPhieuNhap(ctpn))
                                {
                                    checkThanhCong = false;
                                    break;
                                }
                            }
                            if (!checkThanhCong)
                            {
                                lbWarningCTPN.Text = "Lưu sản phẩm vào Phiếu Nhập thất bại !";
                            }
                            else
                            {
                                lbWarningCTPN.Text = "Lưu Phiếu Nhập Thành công !";
                                pnl.Add(pn);
                            }

                        }
                        else
                            lbWarningCTPN.Text = "Lưu Phiếu Nhập Thất Bại !";
                    }

                }
            }    
        }


            // Xem Button Danh Sách sau khi thêm
        private void btDSPN_Click(object sender, EventArgs e)
        {

            tabConSPMenu.SelectedTab = tabConSPMenu.TabPages["tabDSPN"];
            loadDSPhieuNhap(pnBLL.getPhieuNhapList(nv));

            lbDSPN_CH.Text = ch.tenCuaHang;
        }




        // ================= Danh Sách Phiếu Nhập Button ====================

        // Các tác vụ hỗ trợ 
        //Hủy Phiếu Nhập
        private void btHuyPN_Click(object sender, EventArgs e)
        {
            if (lbDSPN_Ma.Text == "")
            {
                lbWarningDSPN.Text = "Hãy chọn phiếu nhập để hủy";
                return;
            }                   
            if (pn.trangThai)
            {
                lbWarningDSPN.Text = "Phiếu nhập đã nhập không thể hủy!";
                return;
            }
           
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn hủy phiếu nhập này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {               
                bool checkXoaSP = true;
                foreach (ChiTietPhieuNhap ctpn in ctpnl)
                    if (!pnBLL.delCTPhieuNhap(ctpn))
                    {
                        checkXoaSP = false;
                        break;
                    }
                if (checkXoaSP)
                {
                    if (pnBLL.delPhieuNhap(pn))
                    {
                        lbWarningDSPN.Text = "Hủy Thành công !";
                        loadDSPhieuNhap(pnBLL.getPhieuNhapList(nv));
                        dgCTPN.DataSource = null;
                        resetDSPN();
                    }  
                    else
                    {
                        lbWarningDSPN.Text = "Hủy Thất Bại !";
                    }    
                }
            }
        }

        private void xemDSPN_CTPN_Click(object sender, EventArgs e)
        {
            tabConSPMenu.SelectedTab = tabConSPMenu.TabPages["tabSanPham"];
        }
        // Xóa Sản Phẩm trong Chi Tiết Phiếu Nhập
        private void btXoaDSPN_Click(object sender, EventArgs e)
        {
            if (lbDSPN_Ma.Text == "")
            {
                lbWarningDSPN.Text = "Hãy chọn phiếu nhập để Xóa";
                return;
            }
            if (pn.trangThai)
            {
                lbWarningDSPN.Text = "Phiếu nhập đã nhập không thể xóa";
                return;
            }
            if (ctpn != null)
            {
                if (pnBLL.delCTPhieuNhap(ctpn))
                {
                    lbWarningDSPN.Text = "Xóa CTPN Thành Công !";

                    ctpnl = pnBLL.getCTPhieuNhap(pn);
                    loadDS_CTPN(dgCTPN, ctpnl);
                }
                else
                {
                    lbWarningDSPN.Text = "Xóa CTPN Thất bại";
                }
            }
            else
            {
                lbWarningDSPN.Text = "Hãy chọn SP để Xóa";
            }

        }    

        // Sửa Sản Phẩm vào Chi Tiết Phiếu Nhập

        private void btSuaDSPN_Click(object sender, EventArgs e)
        {
            if (lbDSPN_Ma.Text == "")
            {
                lbWarningDSPN.Text = "Hãy chọn phiếu nhập để Sửa";
               
            }
            if (pn.trangThai)
            {
                lbWarningDSPN.Text = "Phiếu nhập đã nhập không thể Sửa";
                
            }
            if(ctpn != null )
            {
                int i = ShowInputDialog();

                ctpn.soLuong = i;

                if (pnBLL.editCTPhieuNhap(ctpn))
                {
                    lbWarningDSPN.Text = "Sửa CTPN Thành Công !";
                    ctpnl = pnBLL.getCTPhieuNhap(pn);
                    loadDS_CTPN(dgCTPN, ctpnl);
                }
                else
                {
                    lbWarningDSPN.Text = "Sửa CTPN Thất bại";
                }
            }   
            else
                lbWarningDSPN.Text = "Bạn vẫn chưa chọn Sản Phẩm cần đổi !" ;
            
        }
        private void loadDanhSachSP_DatButton()
        {
            loadDanhSachSP(dgDSPN_SP);

            dgDSPN_SP.Columns["donGiaNiemYet"].Visible = false;
            
        }
        // Thêm Sản Phẩm Vào Chi Tiết Phiếu Nhập
        private void btThemDSPN_Click(object sender, EventArgs e)
        {
            if (lbDSPN_Ma.Text == "")
            {
                lbWarningDSPN.Text = "Hãy chọn phiếu nhập để Thêm";
                return;
            }
            if (pn.trangThai)
            {
                lbWarningDSPN.Text = "Phiếu nhập đã nhập không thể Thêm SP";
                return;
            }
            loadDanhSachSP_DatButton();
            dgPhieuNhap.Hide();
            dgDSPN_SP.Show();   
        }
        private void dgDSPN_SP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            if (e.RowIndex >= 0 && e.ColumnIndex == dgSPNV.Columns["NhapButton"].Index)
            {
                ctpn = new ChiTietPhieuNhap();

                String msp = dgDSPN_SP.SelectedRows[0].Cells["maSPTheoSize"].Value.ToString();
                {
                    bool maSanPhamValid = ctpnl.Exists(ctpn => ctpn.maSPTheoSize == msp);

                    if (!maSanPhamValid)
                    {
                        ctpn.maPhieuNhap = pn.maPhieuNhap;
                        ctpn.maSPTheoSize = msp;
                        int i = ShowInputDialog();
                        if (i > 0)
                        {
                            ctpn.soLuong = i;

                            if (pnBLL.addCTPhieuNhap(ctpn))
                            {
                                lbWarningDSPN.Text = " Bạn đã bấm nhập thành công !";
                                dgPhieuNhap.Show();
                                dgDSPN_SP.Hide();

                                ctpnl = pnBLL.getCTPhieuNhap(pn);
                                loadDS_CTPN(dgCTPN, ctpnl);
                            }

                        }
                    }
                    else
                    {
                        lbWarningDSPN.Text = "Sản Phẩm đã nằm trong list ";
                    }

                }

            }
        }
        // Cell Click Chi Tiết Phiếu Nhập
        private void dgCTPN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            ctpn = new ChiTietPhieuNhap();
            ctpn.maPhieuNhap = dgCTPN.SelectedRows[0].Cells["maPhieuNhap"].Value.ToString();
            ctpn.maSPTheoSize = dgCTPN.SelectedRows[0].Cells["maSPTheoSize"].Value.ToString();
            ctpn.soLuong = Convert.ToInt32(dgCTPN.SelectedRows[0].Cells["soLuong"].Value.ToString());
            lbWarningDSPN.Text = "";
           
        }

        private void btINDSPN_Click(object sender, EventArgs e)
        {

            if (ctpnl.Count != 0)
            {
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show("Bạn muốn In Phiếu Nhập:", "Lựa chọn", buttons, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    printDialogPN.Document = printDocumentPN;
                    DialogResult result1 = printDialogPN.ShowDialog();
                    if (result1 == DialogResult.OK)
                    {
                        printDocumentPN.Print();
                    }
                }
            }
            else
                lbWarningDSPN.Text = "Phiếu nhập rỗng";
        }

        private void printDocumentPN_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
                pBLL.VePhieuNhap(nv, ch, ctpnl, e);
         }
    }
}
