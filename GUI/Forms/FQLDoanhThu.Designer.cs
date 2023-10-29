namespace GUI.Forms
{
    partial class FQLDoanhThu
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.cbChonSP = new System.Windows.Forms.ComboBox();
            this.panDoanhThuRight = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.chartSanPham = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btLoc_DT = new System.Windows.Forms.Button();
            this.panDoanhThuLeft = new System.Windows.Forms.Panel();
            this.cbCuaHang = new System.Windows.Forms.ComboBox();
            this.btThongKe = new System.Windows.Forms.Button();
            this.btnLocDTCH = new System.Windows.Forms.Button();
            this.btnPhieuNhapKho = new System.Windows.Forms.Button();
            this.btTienLoi = new System.Windows.Forms.Button();
            this.btPhieuNhap = new System.Windows.Forms.Button();
            this.btPhieuTra = new System.Windows.Forms.Button();
            this.btPhieuDoi = new System.Windows.Forms.Button();
            this.btHoaDon = new System.Windows.Forms.Button();
            this.panDT003 = new System.Windows.Forms.Panel();
            this.chartDoanhThu = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lbDoanhThux = new System.Windows.Forms.Label();
            this.dpFromDate = new System.Windows.Forms.DateTimePicker();
            this.lbDT002 = new System.Windows.Forms.Label();
            this.lbWarningDT = new System.Windows.Forms.Label();
            this.dpToDate = new System.Windows.Forms.DateTimePicker();
            this.lbDT001 = new System.Windows.Forms.Label();
            this.panDoanhThuTop = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panDoanhThuRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartSanPham)).BeginInit();
            this.panDoanhThuLeft.SuspendLayout();
            this.panDT003.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).BeginInit();
            this.panDoanhThuTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbChonSP
            // 
            this.cbChonSP.FormattingEnabled = true;
            this.cbChonSP.Location = new System.Drawing.Point(214, 493);
            this.cbChonSP.Name = "cbChonSP";
            this.cbChonSP.Size = new System.Drawing.Size(179, 24);
            this.cbChonSP.TabIndex = 10;
            // 
            // panDoanhThuRight
            // 
            this.panDoanhThuRight.Controls.Add(this.label2);
            this.panDoanhThuRight.Controls.Add(this.label8);
            this.panDoanhThuRight.Controls.Add(this.chartSanPham);
            this.panDoanhThuRight.Controls.Add(this.cbChonSP);
            this.panDoanhThuRight.Controls.Add(this.btLoc_DT);
            this.panDoanhThuRight.Location = new System.Drawing.Point(738, 86);
            this.panDoanhThuRight.Margin = new System.Windows.Forms.Padding(4);
            this.panDoanhThuRight.Name = "panDoanhThuRight";
            this.panDoanhThuRight.Size = new System.Drawing.Size(498, 600);
            this.panDoanhThuRight.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(10, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(280, 32);
            this.label8.TabIndex = 135;
            this.label8.Text = "Danh sách sản phẩm";
            // 
            // chartSanPham
            // 
            chartArea3.Name = "ChartArea1";
            this.chartSanPham.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartSanPham.Legends.Add(legend3);
            this.chartSanPham.Location = new System.Drawing.Point(16, 75);
            this.chartSanPham.Name = "chartSanPham";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chartSanPham.Series.Add(series3);
            this.chartSanPham.Size = new System.Drawing.Size(466, 370);
            this.chartSanPham.TabIndex = 11;
            this.chartSanPham.Text = "chart2";
            // 
            // btLoc_DT
            // 
            this.btLoc_DT.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btLoc_DT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btLoc_DT.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btLoc_DT.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btLoc_DT.Location = new System.Drawing.Point(214, 540);
            this.btLoc_DT.Name = "btLoc_DT";
            this.btLoc_DT.Size = new System.Drawing.Size(150, 46);
            this.btLoc_DT.TabIndex = 9;
            this.btLoc_DT.Text = "Lọc";
            this.btLoc_DT.UseVisualStyleBackColor = false;
            this.btLoc_DT.Click += new System.EventHandler(this.btLoc_DT_Click);
            // 
            // panDoanhThuLeft
            // 
            this.panDoanhThuLeft.Controls.Add(this.label1);
            this.panDoanhThuLeft.Controls.Add(this.cbCuaHang);
            this.panDoanhThuLeft.Controls.Add(this.btThongKe);
            this.panDoanhThuLeft.Controls.Add(this.btnLocDTCH);
            this.panDoanhThuLeft.Controls.Add(this.btnPhieuNhapKho);
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
            this.panDoanhThuLeft.Size = new System.Drawing.Size(730, 707);
            this.panDoanhThuLeft.TabIndex = 8;
            // 
            // cbCuaHang
            // 
            this.cbCuaHang.FormattingEnabled = true;
            this.cbCuaHang.Location = new System.Drawing.Point(184, 494);
            this.cbCuaHang.Name = "cbCuaHang";
            this.cbCuaHang.Size = new System.Drawing.Size(179, 24);
            this.cbCuaHang.TabIndex = 15;
            // 
            // btThongKe
            // 
            this.btThongKe.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btThongKe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btThongKe.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btThongKe.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btThongKe.Location = new System.Drawing.Point(554, 483);
            this.btThongKe.Name = "btThongKe";
            this.btThongKe.Size = new System.Drawing.Size(150, 42);
            this.btThongKe.TabIndex = 7;
            this.btThongKe.Text = "Thống Kê";
            this.btThongKe.UseVisualStyleBackColor = false;
            this.btThongKe.Click += new System.EventHandler(this.btThongKe_Click);
            // 
            // btnLocDTCH
            // 
            this.btnLocDTCH.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnLocDTCH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLocDTCH.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnLocDTCH.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLocDTCH.Location = new System.Drawing.Point(389, 483);
            this.btnLocDTCH.Name = "btnLocDTCH";
            this.btnLocDTCH.Size = new System.Drawing.Size(150, 42);
            this.btnLocDTCH.TabIndex = 14;
            this.btnLocDTCH.Text = "Lọc";
            this.btnLocDTCH.UseVisualStyleBackColor = false;
            this.btnLocDTCH.Click += new System.EventHandler(this.btnLocDTCH_Click);
            // 
            // btnPhieuNhapKho
            // 
            this.btnPhieuNhapKho.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnPhieuNhapKho.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPhieuNhapKho.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnPhieuNhapKho.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnPhieuNhapKho.Location = new System.Drawing.Point(430, 558);
            this.btnPhieuNhapKho.Name = "btnPhieuNhapKho";
            this.btnPhieuNhapKho.Size = new System.Drawing.Size(235, 42);
            this.btnPhieuNhapKho.TabIndex = 13;
            this.btnPhieuNhapKho.Text = "Phiếu nhập kho";
            this.btnPhieuNhapKho.UseVisualStyleBackColor = false;
            this.btnPhieuNhapKho.Click += new System.EventHandler(this.btnPhieuNhapKho_Click);
            // 
            // btTienLoi
            // 
            this.btTienLoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btTienLoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btTienLoi.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btTienLoi.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btTienLoi.Location = new System.Drawing.Point(63, 610);
            this.btTienLoi.Name = "btTienLoi";
            this.btTienLoi.Size = new System.Drawing.Size(150, 42);
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
            this.btPhieuNhap.Location = new System.Drawing.Point(430, 610);
            this.btPhieuNhap.Name = "btPhieuNhap";
            this.btPhieuNhap.Size = new System.Drawing.Size(235, 41);
            this.btPhieuNhap.TabIndex = 11;
            this.btPhieuNhap.Text = "Phiếu nhập cửa hàng";
            this.btPhieuNhap.UseVisualStyleBackColor = false;
            this.btPhieuNhap.Click += new System.EventHandler(this.btPhieuNhap_Click);
            // 
            // btPhieuTra
            // 
            this.btPhieuTra.BackColor = System.Drawing.Color.IndianRed;
            this.btPhieuTra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btPhieuTra.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btPhieuTra.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btPhieuTra.Location = new System.Drawing.Point(253, 610);
            this.btPhieuTra.Name = "btPhieuTra";
            this.btPhieuTra.Size = new System.Drawing.Size(150, 42);
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
            this.btPhieuDoi.Location = new System.Drawing.Point(253, 558);
            this.btPhieuDoi.Name = "btPhieuDoi";
            this.btPhieuDoi.Size = new System.Drawing.Size(150, 42);
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
            this.btHoaDon.Location = new System.Drawing.Point(63, 558);
            this.btHoaDon.Name = "btHoaDon";
            this.btHoaDon.Size = new System.Drawing.Size(150, 42);
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
            this.panDT003.Size = new System.Drawing.Size(730, 462);
            this.panDT003.TabIndex = 0;
            // 
            // chartDoanhThu
            // 
            chartArea4.Name = "ChartArea1";
            this.chartDoanhThu.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chartDoanhThu.Legends.Add(legend4);
            this.chartDoanhThu.Location = new System.Drawing.Point(0, 0);
            this.chartDoanhThu.Name = "chartDoanhThu";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chartDoanhThu.Series.Add(series4);
            this.chartDoanhThu.Size = new System.Drawing.Size(727, 459);
            this.chartDoanhThu.TabIndex = 0;
            this.chartDoanhThu.Text = "chart1";
            // 
            // lbDoanhThux
            // 
            this.lbDoanhThux.AutoSize = true;
            this.lbDoanhThux.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDoanhThux.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbDoanhThux.Location = new System.Drawing.Point(571, 9);
            this.lbDoanhThux.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbDoanhThux.Name = "lbDoanhThux";
            this.lbDoanhThux.Size = new System.Drawing.Size(170, 33);
            this.lbDoanhThux.TabIndex = 2;
            this.lbDoanhThux.Text = "Doanh Thu ";
            // 
            // dpFromDate
            // 
            this.dpFromDate.CustomFormat = "dd/MM/yyyy";
            this.dpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpFromDate.Location = new System.Drawing.Point(113, 54);
            this.dpFromDate.Name = "dpFromDate";
            this.dpFromDate.Size = new System.Drawing.Size(115, 22);
            this.dpFromDate.TabIndex = 5;
            // 
            // lbDT002
            // 
            this.lbDT002.AutoSize = true;
            this.lbDT002.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDT002.Location = new System.Drawing.Point(234, 52);
            this.lbDT002.Name = "lbDT002";
            this.lbDT002.Size = new System.Drawing.Size(108, 24);
            this.lbDT002.TabIndex = 4;
            this.lbDT002.Text = "Đến Ngày:";
            // 
            // lbWarningDT
            // 
            this.lbWarningDT.AutoSize = true;
            this.lbWarningDT.ForeColor = System.Drawing.Color.Red;
            this.lbWarningDT.Location = new System.Drawing.Point(469, 52);
            this.lbWarningDT.Name = "lbWarningDT";
            this.lbWarningDT.Size = new System.Drawing.Size(0, 16);
            this.lbWarningDT.TabIndex = 8;
            // 
            // dpToDate
            // 
            this.dpToDate.CustomFormat = "dd/MM/yyyy";
            this.dpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpToDate.Location = new System.Drawing.Point(348, 53);
            this.dpToDate.Name = "dpToDate";
            this.dpToDate.Size = new System.Drawing.Size(115, 22);
            this.dpToDate.TabIndex = 6;
            // 
            // lbDT001
            // 
            this.lbDT001.AutoSize = true;
            this.lbDT001.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDT001.Location = new System.Drawing.Point(19, 52);
            this.lbDT001.Name = "lbDT001";
            this.lbDT001.Size = new System.Drawing.Size(89, 24);
            this.lbDT001.TabIndex = 3;
            this.lbDT001.Text = "Từ Ngày";
            // 
            // panDoanhThuTop
            // 
            this.panDoanhThuTop.Controls.Add(this.lbWarningDT);
            this.panDoanhThuTop.Controls.Add(this.dpToDate);
            this.panDoanhThuTop.Controls.Add(this.dpFromDate);
            this.panDoanhThuTop.Controls.Add(this.lbDT002);
            this.panDoanhThuTop.Controls.Add(this.lbDT001);
            this.panDoanhThuTop.Controls.Add(this.lbDoanhThux);
            this.panDoanhThuTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panDoanhThuTop.Location = new System.Drawing.Point(0, 0);
            this.panDoanhThuTop.Margin = new System.Windows.Forms.Padding(4);
            this.panDoanhThuTop.Name = "panDoanhThuTop";
            this.panDoanhThuTop.Size = new System.Drawing.Size(1227, 86);
            this.panDoanhThuTop.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 493);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 25);
            this.label1.TabIndex = 16;
            this.label1.Text = "Chọn cửa hàng:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 494);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 25);
            this.label2.TabIndex = 136;
            this.label2.Text = "Chọn sản phẩm:";
            // 
            // FQLDoanhThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1227, 793);
            this.Controls.Add(this.panDoanhThuRight);
            this.Controls.Add(this.panDoanhThuLeft);
            this.Controls.Add(this.panDoanhThuTop);
            this.Name = "FQLDoanhThu";
            this.Text = "Quản lý doanh Thu";
            this.panDoanhThuRight.ResumeLayout(false);
            this.panDoanhThuRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartSanPham)).EndInit();
            this.panDoanhThuLeft.ResumeLayout(false);
            this.panDoanhThuLeft.PerformLayout();
            this.panDT003.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).EndInit();
            this.panDoanhThuTop.ResumeLayout(false);
            this.panDoanhThuTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbChonSP;
        private System.Windows.Forms.Panel panDoanhThuRight;
        private System.Windows.Forms.Button btLoc_DT;
        private System.Windows.Forms.Panel panDoanhThuLeft;
        private System.Windows.Forms.Button btTienLoi;
        private System.Windows.Forms.Button btPhieuNhap;
        private System.Windows.Forms.Button btPhieuTra;
        private System.Windows.Forms.Button btPhieuDoi;
        private System.Windows.Forms.Button btHoaDon;
        private System.Windows.Forms.Panel panDT003;
        private System.Windows.Forms.Label lbDoanhThux;
        private System.Windows.Forms.DateTimePicker dpFromDate;
        private System.Windows.Forms.Label lbDT002;
        private System.Windows.Forms.Label lbWarningDT;
        private System.Windows.Forms.Button btThongKe;
        private System.Windows.Forms.DateTimePicker dpToDate;
        private System.Windows.Forms.Label lbDT001;
        private System.Windows.Forms.Panel panDoanhThuTop;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSanPham;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDoanhThu;
        private System.Windows.Forms.Button btnPhieuNhapKho;
        private System.Windows.Forms.ComboBox cbCuaHang;
        private System.Windows.Forms.Button btnLocDTCH;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}