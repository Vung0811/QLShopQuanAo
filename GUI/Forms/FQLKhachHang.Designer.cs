namespace GUI.Forms
{
    partial class FQLKhachHang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FQLKhachHang));
            this.rtxtTinNhanGui = new System.Windows.Forms.RichTextBox();
            this.btnGuiTN = new System.Windows.Forms.Button();
            this.dgvKhachHang = new System.Windows.Forms.DataGridView();
            this.maKhachHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenKhach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gioiTinhKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngaySinhKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diaChiKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soDienThoaiKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTimKiemKH = new System.Windows.Forms.TextBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvQLHoaDon = new System.Windows.Forms.DataGridView();
            this.maHoaDon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maNhanVienHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maKhachHangHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngayLapHoaDon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhachHang)).BeginInit();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQLHoaDon)).BeginInit();
            this.SuspendLayout();
            // 
            // rtxtTinNhanGui
            // 
            this.rtxtTinNhanGui.Location = new System.Drawing.Point(27, 255);
            this.rtxtTinNhanGui.Name = "rtxtTinNhanGui";
            this.rtxtTinNhanGui.Size = new System.Drawing.Size(519, 167);
            this.rtxtTinNhanGui.TabIndex = 5;
            this.rtxtTinNhanGui.Text = "";
            // 
            // btnGuiTN
            // 
            this.btnGuiTN.Location = new System.Drawing.Point(586, 255);
            this.btnGuiTN.Name = "btnGuiTN";
            this.btnGuiTN.Size = new System.Drawing.Size(133, 43);
            this.btnGuiTN.TabIndex = 4;
            this.btnGuiTN.Text = "Gửi tin nhắn";
            this.btnGuiTN.UseVisualStyleBackColor = true;
            this.btnGuiTN.Click += new System.EventHandler(this.btnGuiTN_Click);
            // 
            // dgvKhachHang
            // 
            this.dgvKhachHang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKhachHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKhachHang.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.maKhachHang,
            this.tenKhach,
            this.gioiTinhKH,
            this.ngaySinhKH,
            this.diaChiKH,
            this.soDienThoaiKH});
            this.dgvKhachHang.Location = new System.Drawing.Point(27, 21);
            this.dgvKhachHang.Name = "dgvKhachHang";
            this.dgvKhachHang.RowHeadersWidth = 51;
            this.dgvKhachHang.RowTemplate.Height = 24;
            this.dgvKhachHang.Size = new System.Drawing.Size(1006, 150);
            this.dgvKhachHang.TabIndex = 3;
            this.dgvKhachHang.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKhachHang_CellClick);
            this.dgvKhachHang.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvKhachHang_CellFormatting);
            // 
            // maKhachHang
            // 
            this.maKhachHang.HeaderText = "Mã khách hàng";
            this.maKhachHang.MinimumWidth = 6;
            this.maKhachHang.Name = "maKhachHang";
            // 
            // tenKhach
            // 
            this.tenKhach.HeaderText = "Tên khách hàng";
            this.tenKhach.MinimumWidth = 6;
            this.tenKhach.Name = "tenKhach";
            // 
            // gioiTinhKH
            // 
            this.gioiTinhKH.HeaderText = "Giới tính ";
            this.gioiTinhKH.MinimumWidth = 6;
            this.gioiTinhKH.Name = "gioiTinhKH";
            // 
            // ngaySinhKH
            // 
            this.ngaySinhKH.HeaderText = "Ngày sinh";
            this.ngaySinhKH.MinimumWidth = 6;
            this.ngaySinhKH.Name = "ngaySinhKH";
            // 
            // diaChiKH
            // 
            this.diaChiKH.HeaderText = "Địa chỉ";
            this.diaChiKH.MinimumWidth = 6;
            this.diaChiKH.Name = "diaChiKH";
            // 
            // soDienThoaiKH
            // 
            this.soDienThoaiKH.HeaderText = "Số điện thoại";
            this.soDienThoaiKH.MinimumWidth = 6;
            this.soDienThoaiKH.Name = "soDienThoaiKH";
            // 
            // txtTimKiemKH
            // 
            this.txtTimKiemKH.Location = new System.Drawing.Point(54, 2);
            this.txtTimKiemKH.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTimKiemKH.Name = "txtTimKiemKH";
            this.txtTimKiemKH.Size = new System.Drawing.Size(217, 27);
            this.txtTimKiemKH.TabIndex = 137;
            this.txtTimKiemKH.TextChanged += new System.EventHandler(this.txtTimKiemKH_TextChanged);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.panel8);
            this.panel7.Controls.Add(this.label6);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1111, 47);
            this.panel7.TabIndex = 185;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.pictureBox2);
            this.panel8.Controls.Add(this.txtTimKiemKH);
            this.panel8.Location = new System.Drawing.Point(784, 12);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(271, 29);
            this.panel8.TabIndex = 1;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(55, 29);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 131;
            this.pictureBox2.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(303, 32);
            this.label6.TabIndex = 0;
            this.label6.Text = "Danh sách khách hàng";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dgvQLHoaDon);
            this.panel1.Controls.Add(this.dgvKhachHang);
            this.panel1.Controls.Add(this.rtxtTinNhanGui);
            this.panel1.Controls.Add(this.btnGuiTN);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 47);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1111, 643);
            this.panel1.TabIndex = 186;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 441);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(259, 32);
            this.label2.TabIndex = 189;
            this.label2.Text = "Danh sách hóa đơn";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 199);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(429, 32);
            this.label1.TabIndex = 188;
            this.label1.Text = "Thông báo chương trình giảm giá";
            // 
            // dgvQLHoaDon
            // 
            this.dgvQLHoaDon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvQLHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQLHoaDon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.maHoaDon,
            this.maNhanVienHD,
            this.maKhachHangHD,
            this.ngayLapHoaDon});
            this.dgvQLHoaDon.Location = new System.Drawing.Point(27, 497);
            this.dgvQLHoaDon.Margin = new System.Windows.Forms.Padding(4);
            this.dgvQLHoaDon.Name = "dgvQLHoaDon";
            this.dgvQLHoaDon.RowHeadersWidth = 51;
            this.dgvQLHoaDon.RowTemplate.Height = 24;
            this.dgvQLHoaDon.Size = new System.Drawing.Size(1006, 136);
            this.dgvQLHoaDon.TabIndex = 187;
            // 
            // maHoaDon
            // 
            this.maHoaDon.HeaderText = "Mã hóa đơn";
            this.maHoaDon.MinimumWidth = 6;
            this.maHoaDon.Name = "maHoaDon";
            // 
            // maNhanVienHD
            // 
            this.maNhanVienHD.HeaderText = "Mã nhân viên";
            this.maNhanVienHD.MinimumWidth = 6;
            this.maNhanVienHD.Name = "maNhanVienHD";
            // 
            // maKhachHangHD
            // 
            this.maKhachHangHD.HeaderText = "Mã khách hàng";
            this.maKhachHangHD.MinimumWidth = 6;
            this.maKhachHangHD.Name = "maKhachHangHD";
            // 
            // ngayLapHoaDon
            // 
            this.ngayLapHoaDon.HeaderText = "Ngày lập hóa đơn";
            this.ngayLapHoaDon.MinimumWidth = 6;
            this.ngayLapHoaDon.Name = "ngayLapHoaDon";
            // 
            // FQLKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(243)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(1111, 693);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel7);
            this.Name = "FQLKhachHang";
            this.Text = "Quản lý khách hàng";
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhachHang)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQLHoaDon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtxtTinNhanGui;
        private System.Windows.Forms.Button btnGuiTN;
        private System.Windows.Forms.DataGridView dgvKhachHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn maKhachHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenKhach;
        private System.Windows.Forms.DataGridViewTextBoxColumn gioiTinhKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngaySinhKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn diaChiKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn soDienThoaiKH;
        private System.Windows.Forms.TextBox txtTimKiemKH;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvQLHoaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn maHoaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn maNhanVienHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn maKhachHangHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngayLapHoaDon;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}