namespace GUI
{
    partial class FNVDoanhThu
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panDoanhThuTop = new System.Windows.Forms.Panel();
            this.lbWarningDT = new System.Windows.Forms.Label();
            this.btThongKe = new System.Windows.Forms.Button();
            this.dpToDate = new System.Windows.Forms.DateTimePicker();
            this.dpFromDate = new System.Windows.Forms.DateTimePicker();
            this.lbDT002 = new System.Windows.Forms.Label();
            this.lbDT001 = new System.Windows.Forms.Label();
            this.lbDoanhThux = new System.Windows.Forms.Label();
            this.panDoanhThuLeft = new System.Windows.Forms.Panel();
            this.btTienLoi = new System.Windows.Forms.Button();
            this.btPhieuNhap = new System.Windows.Forms.Button();
            this.btPhieuTra = new System.Windows.Forms.Button();
            this.btPhieuDoi = new System.Windows.Forms.Button();
            this.btHoaDon = new System.Windows.Forms.Button();
            this.panDT003 = new System.Windows.Forms.Panel();
            this.chartDoanhThu = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panDoanhThuRight = new System.Windows.Forms.Panel();
            this.cbChonSP = new System.Windows.Forms.ComboBox();
            this.btLoc_DT = new System.Windows.Forms.Button();
            this.chartSanPham = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panDoanhThuTop.SuspendLayout();
            this.panDoanhThuLeft.SuspendLayout();
            this.panDT003.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).BeginInit();
            this.panDoanhThuRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartSanPham)).BeginInit();
            this.SuspendLayout();
            // 
            // panDoanhThuTop
            // 
            this.panDoanhThuTop.Controls.Add(this.lbWarningDT);
            this.panDoanhThuTop.Controls.Add(this.btThongKe);
            this.panDoanhThuTop.Controls.Add(this.dpToDate);
            this.panDoanhThuTop.Controls.Add(this.dpFromDate);
            this.panDoanhThuTop.Controls.Add(this.lbDT002);
            this.panDoanhThuTop.Controls.Add(this.lbDT001);
            this.panDoanhThuTop.Controls.Add(this.lbDoanhThux);
            this.panDoanhThuTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panDoanhThuTop.Location = new System.Drawing.Point(0, 0);
            this.panDoanhThuTop.Margin = new System.Windows.Forms.Padding(4);
            this.panDoanhThuTop.Name = "panDoanhThuTop";
            this.panDoanhThuTop.Size = new System.Drawing.Size(887, 86);
            this.panDoanhThuTop.TabIndex = 4;
            // 
            // lbWarningDT
            // 
            this.lbWarningDT.AutoSize = true;
            this.lbWarningDT.ForeColor = System.Drawing.Color.Red;
            this.lbWarningDT.Location = new System.Drawing.Point(469, 52);
            this.lbWarningDT.Name = "lbWarningDT";
            this.lbWarningDT.Size = new System.Drawing.Size(0, 18);
            this.lbWarningDT.TabIndex = 8;
            // 
            // btThongKe
            // 
            this.btThongKe.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btThongKe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btThongKe.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btThongKe.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btThongKe.Location = new System.Drawing.Point(743, 35);
            this.btThongKe.Name = "btThongKe";
            this.btThongKe.Size = new System.Drawing.Size(116, 35);
            this.btThongKe.TabIndex = 7;
            this.btThongKe.Text = "Thống Kê";
            this.btThongKe.UseVisualStyleBackColor = false;
            this.btThongKe.Click += new System.EventHandler(this.btThongKe_Click);
            // 
            // dpToDate
            // 
            this.dpToDate.CustomFormat = "dd/MM/yyyy";
            this.dpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpToDate.Location = new System.Drawing.Point(329, 46);
            this.dpToDate.Name = "dpToDate";
            this.dpToDate.Size = new System.Drawing.Size(115, 24);
            this.dpToDate.TabIndex = 6;
            // 
            // dpFromDate
            // 
            this.dpFromDate.CustomFormat = "dd/MM/yyyy";
            this.dpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpFromDate.Location = new System.Drawing.Point(94, 46);
            this.dpFromDate.Name = "dpFromDate";
            this.dpFromDate.Size = new System.Drawing.Size(115, 24);
            this.dpFromDate.TabIndex = 5;
            // 
            // lbDT002
            // 
            this.lbDT002.AutoSize = true;
            this.lbDT002.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDT002.Location = new System.Drawing.Point(234, 52);
            this.lbDT002.Name = "lbDT002";
            this.lbDT002.Size = new System.Drawing.Size(86, 18);
            this.lbDT002.TabIndex = 4;
            this.lbDT002.Text = "Đến Ngày:";
            // 
            // lbDT001
            // 
            this.lbDT001.AutoSize = true;
            this.lbDT001.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDT001.Location = new System.Drawing.Point(19, 52);
            this.lbDT001.Name = "lbDT001";
            this.lbDT001.Size = new System.Drawing.Size(70, 18);
            this.lbDT001.TabIndex = 3;
            this.lbDT001.Text = "Từ Ngày";
            // 
            // lbDoanhThux
            // 
            this.lbDoanhThux.AutoSize = true;
            this.lbDoanhThux.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDoanhThux.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbDoanhThux.Location = new System.Drawing.Point(339, 11);
            this.lbDoanhThux.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbDoanhThux.Name = "lbDoanhThux";
            this.lbDoanhThux.Size = new System.Drawing.Size(176, 19);
            this.lbDoanhThux.TabIndex = 2;
            this.lbDoanhThux.Text = "Doanh Thu Cửa Hàng";
            // 
            // panDoanhThuLeft
            // 
            this.panDoanhThuLeft.Controls.Add(this.btTienLoi);
            this.panDoanhThuLeft.Controls.Add(this.btPhieuNhap);
            this.panDoanhThuLeft.Controls.Add(this.btPhieuTra);
            this.panDoanhThuLeft.Controls.Add(this.btPhieuDoi);
            this.panDoanhThuLeft.Controls.Add(this.btHoaDon);
            this.panDoanhThuLeft.Controls.Add(this.panDT003);
            this.panDoanhThuLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panDoanhThuLeft.Location = new System.Drawing.Point(0, 86);
            this.panDoanhThuLeft.Margin = new System.Windows.Forms.Padding(4);
            this.panDoanhThuLeft.Name = "panDoanhThuLeft";
            this.panDoanhThuLeft.Size = new System.Drawing.Size(541, 503);
            this.panDoanhThuLeft.TabIndex = 5;
            // 
            // btTienLoi
            // 
            this.btTienLoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btTienLoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btTienLoi.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btTienLoi.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btTienLoi.Location = new System.Drawing.Point(33, 452);
            this.btTienLoi.Name = "btTienLoi";
            this.btTienLoi.Size = new System.Drawing.Size(149, 35);
            this.btTienLoi.TabIndex = 12;
            this.btTienLoi.Text = "Doanh Thu";
            this.btTienLoi.UseVisualStyleBackColor = false;
            this.btTienLoi.Click += new System.EventHandler(this.btTienLoi_Click);
            // 
            // btPhieuNhap
            // 
            this.btPhieuNhap.BackColor = System.Drawing.Color.Lime;
            this.btPhieuNhap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btPhieuNhap.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btPhieuNhap.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btPhieuNhap.Location = new System.Drawing.Point(366, 452);
            this.btPhieuNhap.Name = "btPhieuNhap";
            this.btPhieuNhap.Size = new System.Drawing.Size(149, 35);
            this.btPhieuNhap.TabIndex = 11;
            this.btPhieuNhap.Text = "Phiếu Nhập";
            this.btPhieuNhap.UseVisualStyleBackColor = false;
            this.btPhieuNhap.Click += new System.EventHandler(this.btPhieuNhap_Click);
            // 
            // btPhieuTra
            // 
            this.btPhieuTra.BackColor = System.Drawing.Color.IndianRed;
            this.btPhieuTra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btPhieuTra.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btPhieuTra.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btPhieuTra.Location = new System.Drawing.Point(199, 452);
            this.btPhieuTra.Name = "btPhieuTra";
            this.btPhieuTra.Size = new System.Drawing.Size(149, 35);
            this.btPhieuTra.TabIndex = 10;
            this.btPhieuTra.Text = "Phiếu Trả";
            this.btPhieuTra.UseVisualStyleBackColor = false;
            this.btPhieuTra.Click += new System.EventHandler(this.btPhieuTra_Click);
            // 
            // btPhieuDoi
            // 
            this.btPhieuDoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btPhieuDoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btPhieuDoi.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btPhieuDoi.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btPhieuDoi.Location = new System.Drawing.Point(366, 400);
            this.btPhieuDoi.Name = "btPhieuDoi";
            this.btPhieuDoi.Size = new System.Drawing.Size(149, 35);
            this.btPhieuDoi.TabIndex = 9;
            this.btPhieuDoi.Text = "Phiếu Đổi";
            this.btPhieuDoi.UseVisualStyleBackColor = false;
            this.btPhieuDoi.Click += new System.EventHandler(this.btPhieuDoi_Click);
            // 
            // btHoaDon
            // 
            this.btHoaDon.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btHoaDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btHoaDon.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btHoaDon.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btHoaDon.Location = new System.Drawing.Point(199, 400);
            this.btHoaDon.Name = "btHoaDon";
            this.btHoaDon.Size = new System.Drawing.Size(149, 35);
            this.btHoaDon.TabIndex = 8;
            this.btHoaDon.Text = "Hóa Đơn";
            this.btHoaDon.UseVisualStyleBackColor = false;
            this.btHoaDon.Click += new System.EventHandler(this.btHoaDon_Click);
            // 
            // panDT003
            // 
            this.panDT003.Controls.Add(this.chartDoanhThu);
            this.panDT003.Dock = System.Windows.Forms.DockStyle.Top;
            this.panDT003.Location = new System.Drawing.Point(0, 0);
            this.panDT003.Name = "panDT003";
            this.panDT003.Size = new System.Drawing.Size(541, 348);
            this.panDT003.TabIndex = 0;
            // 
            // chartDoanhThu
            // 
            chartArea3.Name = "ChartArea1";
            this.chartDoanhThu.ChartAreas.Add(chartArea3);
            this.chartDoanhThu.Dock = System.Windows.Forms.DockStyle.Fill;
            legend3.Name = "Legend1";
            this.chartDoanhThu.Legends.Add(legend3);
            this.chartDoanhThu.Location = new System.Drawing.Point(0, 0);
            this.chartDoanhThu.Name = "chartDoanhThu";
            this.chartDoanhThu.Size = new System.Drawing.Size(541, 348);
            this.chartDoanhThu.TabIndex = 3;
            this.chartDoanhThu.Text = "chart1";
            // 
            // panDoanhThuRight
            // 
            this.panDoanhThuRight.Controls.Add(this.cbChonSP);
            this.panDoanhThuRight.Controls.Add(this.btLoc_DT);
            this.panDoanhThuRight.Controls.Add(this.chartSanPham);
            this.panDoanhThuRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panDoanhThuRight.Location = new System.Drawing.Point(549, 86);
            this.panDoanhThuRight.Margin = new System.Windows.Forms.Padding(4);
            this.panDoanhThuRight.Name = "panDoanhThuRight";
            this.panDoanhThuRight.Size = new System.Drawing.Size(338, 503);
            this.panDoanhThuRight.TabIndex = 6;
            // 
            // cbChonSP
            // 
            this.cbChonSP.FormattingEnabled = true;
            this.cbChonSP.Location = new System.Drawing.Point(21, 455);
            this.cbChonSP.Name = "cbChonSP";
            this.cbChonSP.Size = new System.Drawing.Size(179, 26);
            this.cbChonSP.TabIndex = 10;
            // 
            // btLoc_DT
            // 
            this.btLoc_DT.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btLoc_DT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btLoc_DT.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btLoc_DT.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btLoc_DT.Location = new System.Drawing.Point(206, 449);
            this.btLoc_DT.Name = "btLoc_DT";
            this.btLoc_DT.Size = new System.Drawing.Size(116, 35);
            this.btLoc_DT.TabIndex = 9;
            this.btLoc_DT.Text = "Lọc";
            this.btLoc_DT.UseVisualStyleBackColor = false;
            this.btLoc_DT.Click += new System.EventHandler(this.btLoc_DT_Click);
            // 
            // chartSanPham
            // 
            chartArea4.Name = "ChartArea1";
            this.chartSanPham.ChartAreas.Add(chartArea4);
            this.chartSanPham.Dock = System.Windows.Forms.DockStyle.Top;
            legend4.Name = "Legend1";
            this.chartSanPham.Legends.Add(legend4);
            this.chartSanPham.Location = new System.Drawing.Point(0, 0);
            this.chartSanPham.Name = "chartSanPham";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartSanPham.Series.Add(series2);
            this.chartSanPham.Size = new System.Drawing.Size(338, 348);
            this.chartSanPham.TabIndex = 0;
            this.chartSanPham.Text = "chart1";
            // 
            // FNVDoanhThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.Controls.Add(this.panDoanhThuRight);
            this.Controls.Add(this.panDoanhThuLeft);
            this.Controls.Add(this.panDoanhThuTop);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FNVDoanhThu";
            this.Size = new System.Drawing.Size(887, 589);
            this.panDoanhThuTop.ResumeLayout(false);
            this.panDoanhThuTop.PerformLayout();
            this.panDoanhThuLeft.ResumeLayout(false);
            this.panDT003.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).EndInit();
            this.panDoanhThuRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartSanPham)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panDoanhThuTop;
        private System.Windows.Forms.Label lbWarningDT;
        private System.Windows.Forms.Button btThongKe;
        private System.Windows.Forms.DateTimePicker dpToDate;
        private System.Windows.Forms.DateTimePicker dpFromDate;
        private System.Windows.Forms.Label lbDT002;
        private System.Windows.Forms.Label lbDT001;
        private System.Windows.Forms.Label lbDoanhThux;
        private System.Windows.Forms.Panel panDoanhThuLeft;
        private System.Windows.Forms.Panel panDT003;
        private System.Windows.Forms.Panel panDoanhThuRight;
        private System.Windows.Forms.ComboBox cbChonSP;
        private System.Windows.Forms.Button btLoc_DT;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSanPham;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDoanhThu;
        private System.Windows.Forms.Button btPhieuNhap;
        private System.Windows.Forms.Button btPhieuTra;
        private System.Windows.Forms.Button btPhieuDoi;
        private System.Windows.Forms.Button btHoaDon;
        private System.Windows.Forms.Button btTienLoi;
    }
}
