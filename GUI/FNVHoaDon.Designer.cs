namespace GUI
{
    partial class FNVHoaDon
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FNVHoaDon));
            this.pnHDNVTop = new System.Windows.Forms.Panel();
            this.pnKHNVSearch = new System.Windows.Forms.Panel();
            this.txtHDNVSearch = new System.Windows.Forms.TextBox();
            this.pbHDNVSearch = new System.Windows.Forms.PictureBox();
            this.lbHDNV1 = new System.Windows.Forms.Label();
            this.pnHDNVMid = new System.Windows.Forms.Panel();
            this.dgHDNV = new System.Windows.Forms.DataGridView();
            this.pnHDNVMid2 = new System.Windows.Forms.Panel();
            this.btXemHoaDon = new Guna.UI2.WinForms.Guna2Button();
            this.btXemPhieuTra = new Guna.UI2.WinForms.Guna2Button();
            this.lbWarningHD = new System.Windows.Forms.Label();
            this.dpHDNgay = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.txtTenKHHD = new System.Windows.Forms.TextBox();
            this.txtTenNVHD = new System.Windows.Forms.TextBox();
            this.txtMaHD = new System.Windows.Forms.TextBox();
            this.lnHDNV_Ngay = new System.Windows.Forms.Label();
            this.lbHDNV_TenKH = new System.Windows.Forms.Label();
            this.lbHDNV_TenNV = new System.Windows.Forms.Label();
            this.lbHDNV_MHD = new System.Windows.Forms.Label();
            this.lbHDNVInfo = new System.Windows.Forms.Label();
            this.btHDXem = new Guna.UI2.WinForms.Guna2Button();
            this.btXemPhieuDoi = new Guna.UI2.WinForms.Guna2Button();
            this.dgCTHD = new System.Windows.Forms.DataGridView();
            this.eslCTHDXoa = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.eslCTHDXem = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.lbHDTongTien = new System.Windows.Forms.Label();
            this.txtTongTienCTHD = new System.Windows.Forms.Label();
            this.eslXemphieutra = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.pnHDNVTop.SuspendLayout();
            this.pnKHNVSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbHDNVSearch)).BeginInit();
            this.pnHDNVMid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgHDNV)).BeginInit();
            this.pnHDNVMid2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCTHD)).BeginInit();
            this.SuspendLayout();
            // 
            // pnHDNVTop
            // 
            this.pnHDNVTop.Controls.Add(this.pnKHNVSearch);
            this.pnHDNVTop.Controls.Add(this.lbHDNV1);
            this.pnHDNVTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnHDNVTop.Location = new System.Drawing.Point(0, 0);
            this.pnHDNVTop.Name = "pnHDNVTop";
            this.pnHDNVTop.Size = new System.Drawing.Size(887, 48);
            this.pnHDNVTop.TabIndex = 1;
            this.pnHDNVTop.TabStop = true;
            // 
            // pnKHNVSearch
            // 
            this.pnKHNVSearch.Controls.Add(this.txtHDNVSearch);
            this.pnKHNVSearch.Controls.Add(this.pbHDNVSearch);
            this.pnKHNVSearch.Location = new System.Drawing.Point(554, 12);
            this.pnKHNVSearch.Name = "pnKHNVSearch";
            this.pnKHNVSearch.Size = new System.Drawing.Size(318, 22);
            this.pnKHNVSearch.TabIndex = 5;
            // 
            // txtHDNVSearch
            // 
            this.txtHDNVSearch.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtHDNVSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtHDNVSearch.Dock = System.Windows.Forms.DockStyle.Right;
            this.txtHDNVSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHDNVSearch.Location = new System.Drawing.Point(40, 0);
            this.txtHDNVSearch.Name = "txtHDNVSearch";
            this.txtHDNVSearch.Size = new System.Drawing.Size(278, 27);
            this.txtHDNVSearch.TabIndex = 1;
            this.txtHDNVSearch.TextChanged += new System.EventHandler(this.txtHDNVSearch_TextChanged);
            // 
            // pbHDNVSearch
            // 
            this.pbHDNVSearch.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbHDNVSearch.Image = ((System.Drawing.Image)(resources.GetObject("pbHDNVSearch.Image")));
            this.pbHDNVSearch.Location = new System.Drawing.Point(0, 0);
            this.pbHDNVSearch.Name = "pbHDNVSearch";
            this.pbHDNVSearch.Size = new System.Drawing.Size(34, 22);
            this.pbHDNVSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbHDNVSearch.TabIndex = 0;
            this.pbHDNVSearch.TabStop = false;
            // 
            // lbHDNV1
            // 
            this.lbHDNV1.AutoSize = true;
            this.lbHDNV1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHDNV1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbHDNV1.Location = new System.Drawing.Point(4, 10);
            this.lbHDNV1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbHDNV1.Name = "lbHDNV1";
            this.lbHDNV1.Size = new System.Drawing.Size(199, 24);
            this.lbHDNV1.TabIndex = 1;
            this.lbHDNV1.Text = "Danh sách Hóa Đơn";
            // 
            // pnHDNVMid
            // 
            this.pnHDNVMid.Controls.Add(this.dgHDNV);
            this.pnHDNVMid.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnHDNVMid.Location = new System.Drawing.Point(0, 48);
            this.pnHDNVMid.Name = "pnHDNVMid";
            this.pnHDNVMid.Size = new System.Drawing.Size(887, 190);
            this.pnHDNVMid.TabIndex = 3;
            // 
            // dgHDNV
            // 
            this.dgHDNV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgHDNV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgHDNV.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgHDNV.ColumnHeadersHeight = 30;
            this.dgHDNV.Location = new System.Drawing.Point(9, 6);
            this.dgHDNV.Name = "dgHDNV";
            this.dgHDNV.ReadOnly = true;
            this.dgHDNV.RowHeadersWidth = 51;
            this.dgHDNV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgHDNV.Size = new System.Drawing.Size(863, 164);
            this.dgHDNV.TabIndex = 0;
            this.dgHDNV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgHDNV_CellContentClick);
            // 
            // pnHDNVMid2
            // 
            this.pnHDNVMid2.Controls.Add(this.btXemHoaDon);
            this.pnHDNVMid2.Controls.Add(this.btXemPhieuTra);
            this.pnHDNVMid2.Controls.Add(this.lbWarningHD);
            this.pnHDNVMid2.Controls.Add(this.dpHDNgay);
            this.pnHDNVMid2.Controls.Add(this.txtTenKHHD);
            this.pnHDNVMid2.Controls.Add(this.txtTenNVHD);
            this.pnHDNVMid2.Controls.Add(this.txtMaHD);
            this.pnHDNVMid2.Controls.Add(this.lnHDNV_Ngay);
            this.pnHDNVMid2.Controls.Add(this.lbHDNV_TenKH);
            this.pnHDNVMid2.Controls.Add(this.lbHDNV_TenNV);
            this.pnHDNVMid2.Controls.Add(this.lbHDNV_MHD);
            this.pnHDNVMid2.Controls.Add(this.lbHDNVInfo);
            this.pnHDNVMid2.Controls.Add(this.btHDXem);
            this.pnHDNVMid2.Controls.Add(this.btXemPhieuDoi);
            this.pnHDNVMid2.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnHDNVMid2.Location = new System.Drawing.Point(0, 238);
            this.pnHDNVMid2.Name = "pnHDNVMid2";
            this.pnHDNVMid2.Size = new System.Drawing.Size(887, 144);
            this.pnHDNVMid2.TabIndex = 4;
            // 
            // btXemHoaDon
            // 
            this.btXemHoaDon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btXemHoaDon.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btXemHoaDon.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btXemHoaDon.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btXemHoaDon.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btXemHoaDon.FillColor = System.Drawing.Color.DarkSlateGray;
            this.btXemHoaDon.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btXemHoaDon.ForeColor = System.Drawing.Color.White;
            this.btXemHoaDon.Location = new System.Drawing.Point(386, 92);
            this.btXemHoaDon.Name = "btXemHoaDon";
            this.btXemHoaDon.Size = new System.Drawing.Size(168, 40);
            this.btXemHoaDon.TabIndex = 36;
            this.btXemHoaDon.Text = "Xem Hóa Đơn";
            this.btXemHoaDon.Click += new System.EventHandler(this.btXemHoaDon_Click);
            // 
            // btXemPhieuTra
            // 
            this.btXemPhieuTra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btXemPhieuTra.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btXemPhieuTra.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btXemPhieuTra.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btXemPhieuTra.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btXemPhieuTra.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btXemPhieuTra.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btXemPhieuTra.ForeColor = System.Drawing.Color.White;
            this.btXemPhieuTra.Location = new System.Drawing.Point(734, 92);
            this.btXemPhieuTra.Name = "btXemPhieuTra";
            this.btXemPhieuTra.Size = new System.Drawing.Size(150, 40);
            this.btXemPhieuTra.TabIndex = 35;
            this.btXemPhieuTra.Text = "Xem Phiếu Trả";
            this.btXemPhieuTra.Click += new System.EventHandler(this.btXemPhieuTra_Click);
            // 
            // lbWarningHD
            // 
            this.lbWarningHD.AutoSize = true;
            this.lbWarningHD.ForeColor = System.Drawing.Color.Red;
            this.lbWarningHD.Location = new System.Drawing.Point(370, 64);
            this.lbWarningHD.Name = "lbWarningHD";
            this.lbWarningHD.Size = new System.Drawing.Size(0, 25);
            this.lbWarningHD.TabIndex = 34;
            // 
            // dpHDNgay
            // 
            this.dpHDNgay.Checked = true;
            this.dpHDNgay.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dpHDNgay.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dpHDNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpHDNgay.Location = new System.Drawing.Point(518, 16);
            this.dpHDNgay.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dpHDNgay.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dpHDNgay.Name = "dpHDNgay";
            this.dpHDNgay.Size = new System.Drawing.Size(192, 32);
            this.dpHDNgay.TabIndex = 33;
            this.dpHDNgay.Value = new System.DateTime(2023, 9, 20, 15, 11, 3, 2);
            // 
            // txtTenKHHD
            // 
            this.txtTenKHHD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtTenKHHD.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTenKHHD.Location = new System.Drawing.Point(156, 113);
            this.txtTenKHHD.Name = "txtTenKHHD";
            this.txtTenKHHD.ReadOnly = true;
            this.txtTenKHHD.Size = new System.Drawing.Size(192, 23);
            this.txtTenKHHD.TabIndex = 32;
            // 
            // txtTenNVHD
            // 
            this.txtTenNVHD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtTenNVHD.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTenNVHD.Location = new System.Drawing.Point(156, 81);
            this.txtTenNVHD.Name = "txtTenNVHD";
            this.txtTenNVHD.ReadOnly = true;
            this.txtTenNVHD.Size = new System.Drawing.Size(192, 23);
            this.txtTenNVHD.TabIndex = 31;
            // 
            // txtMaHD
            // 
            this.txtMaHD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtMaHD.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMaHD.Location = new System.Drawing.Point(156, 49);
            this.txtMaHD.Name = "txtMaHD";
            this.txtMaHD.ReadOnly = true;
            this.txtMaHD.Size = new System.Drawing.Size(192, 23);
            this.txtMaHD.TabIndex = 30;
            this.txtMaHD.TextChanged += new System.EventHandler(this.txtMaHD_TextChanged);
            // 
            // lnHDNV_Ngay
            // 
            this.lnHDNV_Ngay.AutoSize = true;
            this.lnHDNV_Ngay.Location = new System.Drawing.Point(370, 28);
            this.lnHDNV_Ngay.Name = "lnHDNV_Ngay";
            this.lnHDNV_Ngay.Size = new System.Drawing.Size(177, 25);
            this.lnHDNV_Ngay.TabIndex = 29;
            this.lnHDNV_Ngay.Text = "Ngày lập Hóa Đơn:";
            // 
            // lbHDNV_TenKH
            // 
            this.lbHDNV_TenKH.AutoSize = true;
            this.lbHDNV_TenKH.Location = new System.Drawing.Point(20, 112);
            this.lbHDNV_TenKH.Name = "lbHDNV_TenKH";
            this.lbHDNV_TenKH.Size = new System.Drawing.Size(167, 25);
            this.lbHDNV_TenKH.TabIndex = 28;
            this.lbHDNV_TenKH.Text = "Tên Khách Hàng:";
            // 
            // lbHDNV_TenNV
            // 
            this.lbHDNV_TenNV.AutoSize = true;
            this.lbHDNV_TenNV.Location = new System.Drawing.Point(20, 80);
            this.lbHDNV_TenNV.Name = "lbHDNV_TenNV";
            this.lbHDNV_TenNV.Size = new System.Drawing.Size(150, 25);
            this.lbHDNV_TenNV.TabIndex = 27;
            this.lbHDNV_TenNV.Text = "Tên Nhân Viên:";
            // 
            // lbHDNV_MHD
            // 
            this.lbHDNV_MHD.AutoSize = true;
            this.lbHDNV_MHD.Location = new System.Drawing.Point(20, 48);
            this.lbHDNV_MHD.Name = "lbHDNV_MHD";
            this.lbHDNV_MHD.Size = new System.Drawing.Size(128, 25);
            this.lbHDNV_MHD.TabIndex = 26;
            this.lbHDNV_MHD.Text = "Mã Hóa Đơn:";
            // 
            // lbHDNVInfo
            // 
            this.lbHDNVInfo.AutoSize = true;
            this.lbHDNVInfo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHDNVInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbHDNVInfo.Location = new System.Drawing.Point(5, 16);
            this.lbHDNVInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbHDNVInfo.Name = "lbHDNVInfo";
            this.lbHDNVInfo.Size = new System.Drawing.Size(190, 24);
            this.lbHDNVInfo.TabIndex = 25;
            this.lbHDNVInfo.Text = "Thông tin Hóa Đơn";
            // 
            // btHDXem
            // 
            this.btHDXem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btHDXem.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btHDXem.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btHDXem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btHDXem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btHDXem.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btHDXem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btHDXem.ForeColor = System.Drawing.Color.White;
            this.btHDXem.Location = new System.Drawing.Point(734, 46);
            this.btHDXem.Name = "btHDXem";
            this.btHDXem.Size = new System.Drawing.Size(150, 40);
            this.btHDXem.TabIndex = 24;
            this.btHDXem.Text = "Xem Chi Tiết";
            this.btHDXem.Click += new System.EventHandler(this.btHDXem_Click);
            // 
            // btXemPhieuDoi
            // 
            this.btXemPhieuDoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btXemPhieuDoi.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btXemPhieuDoi.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btXemPhieuDoi.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btXemPhieuDoi.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btXemPhieuDoi.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btXemPhieuDoi.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btXemPhieuDoi.ForeColor = System.Drawing.Color.White;
            this.btXemPhieuDoi.Location = new System.Drawing.Point(560, 92);
            this.btXemPhieuDoi.Name = "btXemPhieuDoi";
            this.btXemPhieuDoi.Size = new System.Drawing.Size(168, 40);
            this.btXemPhieuDoi.TabIndex = 23;
            this.btXemPhieuDoi.Text = "Xem Phiếu Đổi";
            this.btXemPhieuDoi.Click += new System.EventHandler(this.btXemPhieuDoi_Click);
            // 
            // dgCTHD
            // 
            this.dgCTHD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgCTHD.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgCTHD.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgCTHD.ColumnHeadersHeight = 30;
            this.dgCTHD.Location = new System.Drawing.Point(8, 417);
            this.dgCTHD.Name = "dgCTHD";
            this.dgCTHD.ReadOnly = true;
            this.dgCTHD.RowHeadersWidth = 51;
            this.dgCTHD.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgCTHD.Size = new System.Drawing.Size(863, 119);
            this.dgCTHD.TabIndex = 6;
            // 
            // eslCTHDXoa
            // 
            this.eslCTHDXoa.BorderRadius = 15;
            this.eslCTHDXoa.TargetControl = this.btXemPhieuDoi;
            // 
            // eslCTHDXem
            // 
            this.eslCTHDXem.BorderRadius = 15;
            this.eslCTHDXem.TargetControl = this.btHDXem;
            // 
            // lbHDTongTien
            // 
            this.lbHDTongTien.AutoSize = true;
            this.lbHDTongTien.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHDTongTien.Location = new System.Drawing.Point(20, 385);
            this.lbHDTongTien.Name = "lbHDTongTien";
            this.lbHDTongTien.Size = new System.Drawing.Size(107, 24);
            this.lbHDTongTien.TabIndex = 35;
            this.lbHDTongTien.Text = "Tổng tiền:";
            // 
            // txtTongTienCTHD
            // 
            this.txtTongTienCTHD.AutoSize = true;
            this.txtTongTienCTHD.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongTienCTHD.Location = new System.Drawing.Point(131, 385);
            this.txtTongTienCTHD.Name = "txtTongTienCTHD";
            this.txtTongTienCTHD.Size = new System.Drawing.Size(0, 24);
            this.txtTongTienCTHD.TabIndex = 36;
            // 
            // eslXemphieutra
            // 
            this.eslXemphieutra.BorderRadius = 15;
            this.eslXemphieutra.TargetControl = this.btXemPhieuTra;
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 15;
            this.guna2Elipse1.TargetControl = this.btXemHoaDon;
            // 
            // FNVHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.txtTongTienCTHD);
            this.Controls.Add(this.lbHDTongTien);
            this.Controls.Add(this.dgCTHD);
            this.Controls.Add(this.pnHDNVMid2);
            this.Controls.Add(this.pnHDNVMid);
            this.Controls.Add(this.pnHDNVTop);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FNVHoaDon";
            this.Size = new System.Drawing.Size(887, 550);
            this.pnHDNVTop.ResumeLayout(false);
            this.pnHDNVTop.PerformLayout();
            this.pnKHNVSearch.ResumeLayout(false);
            this.pnKHNVSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbHDNVSearch)).EndInit();
            this.pnHDNVMid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgHDNV)).EndInit();
            this.pnHDNVMid2.ResumeLayout(false);
            this.pnHDNVMid2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCTHD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnHDNVTop;
        private System.Windows.Forms.Panel pnKHNVSearch;
        private System.Windows.Forms.TextBox txtHDNVSearch;
        private System.Windows.Forms.PictureBox pbHDNVSearch;
        private System.Windows.Forms.Label lbHDNV1;
        private System.Windows.Forms.Panel pnHDNVMid;
        private System.Windows.Forms.DataGridView dgHDNV;
        private System.Windows.Forms.Panel pnHDNVMid2;
        private Guna.UI2.WinForms.Guna2Button btXemPhieuDoi;
        private Guna.UI2.WinForms.Guna2Button btHDXem;
        private System.Windows.Forms.Label lbHDNVInfo;
        private System.Windows.Forms.Label lbHDNV_MHD;
        private System.Windows.Forms.Label lnHDNV_Ngay;
        private System.Windows.Forms.Label lbHDNV_TenKH;
        private System.Windows.Forms.Label lbHDNV_TenNV;
        private System.Windows.Forms.TextBox txtTenKHHD;
        private System.Windows.Forms.TextBox txtTenNVHD;
        private System.Windows.Forms.TextBox txtMaHD;
        private Guna.UI2.WinForms.Guna2DateTimePicker dpHDNgay;
        private System.Windows.Forms.DataGridView dgCTHD;
        private Guna.UI2.WinForms.Guna2Elipse eslCTHDXoa;
        private Guna.UI2.WinForms.Guna2Elipse eslCTHDXem;
        private System.Windows.Forms.Label lbWarningHD;
        private System.Windows.Forms.Label lbHDTongTien;
        private System.Windows.Forms.Label txtTongTienCTHD;
        private Guna.UI2.WinForms.Guna2Button btXemPhieuTra;
        private Guna.UI2.WinForms.Guna2Elipse eslXemphieutra;
        private Guna.UI2.WinForms.Guna2Button btXemHoaDon;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
    }
}
