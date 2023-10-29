namespace GUI
{
    partial class PassChange
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PassChange));
            this.pnPassChange = new System.Windows.Forms.Panel();
            this.rtPassChange = new System.Windows.Forms.RichTextBox();
            this.lbPassChange = new System.Windows.Forms.Label();
            this.lbChangePassChange = new System.Windows.Forms.Label();
            this.txtPCMKNow = new System.Windows.Forms.TextBox();
            this.picCheckMK = new System.Windows.Forms.PictureBox();
            this.pnPassold = new System.Windows.Forms.Panel();
            this.picEyePassChange = new System.Windows.Forms.PictureBox();
            this.lbPassOld = new System.Windows.Forms.Label();
            this.lbPCMKNew = new System.Windows.Forms.Label();
            this.txtPCMKNew = new System.Windows.Forms.TextBox();
            this.lbPCMMKN = new System.Windows.Forms.Label();
            this.txtPCMKN_Re = new System.Windows.Forms.TextBox();
            this.btPCDMK = new System.Windows.Forms.Button();
            this.btPCClose = new System.Windows.Forms.Button();
            this.lbPCWarning = new System.Windows.Forms.Label();
            this.picCheckMK_Re = new System.Windows.Forms.PictureBox();
            this.lbPC8kytu = new System.Windows.Forms.Label();
            this.lbPCChuHoa = new System.Windows.Forms.Label();
            this.lbPCChuThuong = new System.Windows.Forms.Label();
            this.lbPCSo = new System.Windows.Forms.Label();
            this.lbPCKyTu = new System.Windows.Forms.Label();
            this.pnPassChange.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCheckMK)).BeginInit();
            this.pnPassold.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picEyePassChange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCheckMK_Re)).BeginInit();
            this.SuspendLayout();
            // 
            // pnPassChange
            // 
            this.pnPassChange.BackColor = System.Drawing.Color.DimGray;
            this.pnPassChange.Controls.Add(this.lbPCKyTu);
            this.pnPassChange.Controls.Add(this.lbPCSo);
            this.pnPassChange.Controls.Add(this.lbPCChuThuong);
            this.pnPassChange.Controls.Add(this.lbPCChuHoa);
            this.pnPassChange.Controls.Add(this.lbPC8kytu);
            this.pnPassChange.Controls.Add(this.rtPassChange);
            this.pnPassChange.Controls.Add(this.lbPassChange);
            this.pnPassChange.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnPassChange.Location = new System.Drawing.Point(0, 0);
            this.pnPassChange.Name = "pnPassChange";
            this.pnPassChange.Size = new System.Drawing.Size(192, 417);
            this.pnPassChange.TabIndex = 0;
            // 
            // rtPassChange
            // 
            this.rtPassChange.BackColor = System.Drawing.Color.DimGray;
            this.rtPassChange.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtPassChange.ForeColor = System.Drawing.SystemColors.Window;
            this.rtPassChange.Location = new System.Drawing.Point(7, 78);
            this.rtPassChange.Name = "rtPassChange";
            this.rtPassChange.Size = new System.Drawing.Size(159, 103);
            this.rtPassChange.TabIndex = 1;
            this.rtPassChange.Text = "Bạn nên thay đổi mật khẩu định kỳ để giảm thiểu khả năng tài khoản bị truy cập bở" +
    "i kẻ gian.";
            // 
            // lbPassChange
            // 
            this.lbPassChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPassChange.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbPassChange.Location = new System.Drawing.Point(3, 18);
            this.lbPassChange.Name = "lbPassChange";
            this.lbPassChange.Size = new System.Drawing.Size(168, 57);
            this.lbPassChange.TabIndex = 1;
            this.lbPassChange.Text = "ABC Shop Account-Sign In";
            // 
            // lbChangePassChange
            // 
            this.lbChangePassChange.AutoSize = true;
            this.lbChangePassChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbChangePassChange.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbChangePassChange.Location = new System.Drawing.Point(198, 42);
            this.lbChangePassChange.Name = "lbChangePassChange";
            this.lbChangePassChange.Size = new System.Drawing.Size(137, 24);
            this.lbChangePassChange.TabIndex = 2;
            this.lbChangePassChange.Text = "Đổi mật khẩu:";
            // 
            // txtPCMKNow
            // 
            this.txtPCMKNow.BackColor = System.Drawing.Color.DarkGray;
            this.txtPCMKNow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPCMKNow.ForeColor = System.Drawing.SystemColors.Window;
            this.txtPCMKNow.Location = new System.Drawing.Point(3, 3);
            this.txtPCMKNow.Name = "txtPCMKNow";
            this.txtPCMKNow.Size = new System.Drawing.Size(173, 26);
            this.txtPCMKNow.TabIndex = 3;
            this.txtPCMKNow.UseSystemPasswordChar = true;
            this.txtPCMKNow.TextChanged += new System.EventHandler(this.txtPCMKNow_TextChanged);
            // 
            // picCheckMK
            // 
            this.picCheckMK.Dock = System.Windows.Forms.DockStyle.Right;
            this.picCheckMK.Image = ((System.Drawing.Image)(resources.GetObject("picCheckMK.Image")));
            this.picCheckMK.Location = new System.Drawing.Point(223, 0);
            this.picCheckMK.Name = "picCheckMK";
            this.picCheckMK.Size = new System.Drawing.Size(34, 36);
            this.picCheckMK.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCheckMK.TabIndex = 4;
            this.picCheckMK.TabStop = false;
            // 
            // pnPassold
            // 
            this.pnPassold.Controls.Add(this.picEyePassChange);
            this.pnPassold.Controls.Add(this.picCheckMK);
            this.pnPassold.Controls.Add(this.txtPCMKNow);
            this.pnPassold.Location = new System.Drawing.Point(202, 98);
            this.pnPassold.Name = "pnPassold";
            this.pnPassold.Size = new System.Drawing.Size(257, 36);
            this.pnPassold.TabIndex = 5;
            // 
            // picEyePassChange
            // 
            this.picEyePassChange.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.picEyePassChange.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picEyePassChange.Dock = System.Windows.Forms.DockStyle.Right;
            this.picEyePassChange.Image = ((System.Drawing.Image)(resources.GetObject("picEyePassChange.Image")));
            this.picEyePassChange.Location = new System.Drawing.Point(182, 0);
            this.picEyePassChange.Name = "picEyePassChange";
            this.picEyePassChange.Size = new System.Drawing.Size(41, 36);
            this.picEyePassChange.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picEyePassChange.TabIndex = 10;
            this.picEyePassChange.TabStop = false;
            this.picEyePassChange.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picEyePassChange_MouseDown);
            this.picEyePassChange.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picEyePassChange_MouseUp);
            // 
            // lbPassOld
            // 
            this.lbPassOld.AutoSize = true;
            this.lbPassOld.Location = new System.Drawing.Point(201, 75);
            this.lbPassOld.Name = "lbPassOld";
            this.lbPassOld.Size = new System.Drawing.Size(134, 20);
            this.lbPassOld.TabIndex = 6;
            this.lbPassOld.Text = "Mật khẩu hiện tại:";
            // 
            // lbPCMKNew
            // 
            this.lbPCMKNew.AutoSize = true;
            this.lbPCMKNew.Location = new System.Drawing.Point(201, 137);
            this.lbPCMKNew.Name = "lbPCMKNew";
            this.lbPCMKNew.Size = new System.Drawing.Size(108, 20);
            this.lbPCMKNew.TabIndex = 7;
            this.lbPCMKNew.Text = "Mật khẩu mới:";
            // 
            // txtPCMKNew
            // 
            this.txtPCMKNew.BackColor = System.Drawing.Color.DarkGray;
            this.txtPCMKNew.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPCMKNew.ForeColor = System.Drawing.SystemColors.Window;
            this.txtPCMKNew.Location = new System.Drawing.Point(205, 172);
            this.txtPCMKNew.Name = "txtPCMKNew";
            this.txtPCMKNew.ReadOnly = true;
            this.txtPCMKNew.Size = new System.Drawing.Size(173, 26);
            this.txtPCMKNew.TabIndex = 11;
            this.txtPCMKNew.UseSystemPasswordChar = true;
            this.txtPCMKNew.TextChanged += new System.EventHandler(this.txtPCMKNew_TextChanged);
            // 
            // lbPCMMKN
            // 
            this.lbPCMMKN.AutoSize = true;
            this.lbPCMMKN.Location = new System.Drawing.Point(201, 204);
            this.lbPCMMKN.Name = "lbPCMMKN";
            this.lbPCMMKN.Size = new System.Drawing.Size(97, 20);
            this.lbPCMMKN.TabIndex = 12;
            this.lbPCMMKN.Text = "Nhập lại MK:";
            // 
            // txtPCMKN_Re
            // 
            this.txtPCMKN_Re.BackColor = System.Drawing.Color.DarkGray;
            this.txtPCMKN_Re.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPCMKN_Re.ForeColor = System.Drawing.SystemColors.Window;
            this.txtPCMKN_Re.Location = new System.Drawing.Point(205, 238);
            this.txtPCMKN_Re.Name = "txtPCMKN_Re";
            this.txtPCMKN_Re.PasswordChar = '*';
            this.txtPCMKN_Re.ReadOnly = true;
            this.txtPCMKN_Re.Size = new System.Drawing.Size(173, 26);
            this.txtPCMKN_Re.TabIndex = 13;
            this.txtPCMKN_Re.UseSystemPasswordChar = true;
            this.txtPCMKN_Re.TextChanged += new System.EventHandler(this.txtPCMKN_Re_TextChanged);
            // 
            // btPCDMK
            // 
            this.btPCDMK.BackColor = System.Drawing.Color.Silver;
            this.btPCDMK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btPCDMK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btPCDMK.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btPCDMK.ForeColor = System.Drawing.SystemColors.Control;
            this.btPCDMK.Location = new System.Drawing.Point(209, 329);
            this.btPCDMK.Name = "btPCDMK";
            this.btPCDMK.Size = new System.Drawing.Size(133, 26);
            this.btPCDMK.TabIndex = 14;
            this.btPCDMK.Text = "Đổi Mật Khẩu";
            this.btPCDMK.UseVisualStyleBackColor = false;
            this.btPCDMK.Click += new System.EventHandler(this.btPCDMK_Click);
            // 
            // btPCClose
            // 
            this.btPCClose.BackColor = System.Drawing.Color.Silver;
            this.btPCClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btPCClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btPCClose.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btPCClose.ForeColor = System.Drawing.SystemColors.Control;
            this.btPCClose.Location = new System.Drawing.Point(348, 329);
            this.btPCClose.Name = "btPCClose";
            this.btPCClose.Size = new System.Drawing.Size(111, 26);
            this.btPCClose.TabIndex = 15;
            this.btPCClose.Text = "Đóng";
            this.btPCClose.UseVisualStyleBackColor = false;
            this.btPCClose.Click += new System.EventHandler(this.btPCClose_Click);
            // 
            // lbPCWarning
            // 
            this.lbPCWarning.AutoSize = true;
            this.lbPCWarning.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lbPCWarning.Location = new System.Drawing.Point(205, 283);
            this.lbPCWarning.Name = "lbPCWarning";
            this.lbPCWarning.Size = new System.Drawing.Size(0, 20);
            this.lbPCWarning.TabIndex = 16;
            // 
            // picCheckMK_Re
            // 
            this.picCheckMK_Re.Image = ((System.Drawing.Image)(resources.GetObject("picCheckMK_Re.Image")));
            this.picCheckMK_Re.Location = new System.Drawing.Point(425, 228);
            this.picCheckMK_Re.Name = "picCheckMK_Re";
            this.picCheckMK_Re.Size = new System.Drawing.Size(34, 36);
            this.picCheckMK_Re.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCheckMK_Re.TabIndex = 11;
            this.picCheckMK_Re.TabStop = false;
            // 
            // lbPC8kytu
            // 
            this.lbPC8kytu.AutoSize = true;
            this.lbPC8kytu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lbPC8kytu.Location = new System.Drawing.Point(8, 233);
            this.lbPC8kytu.Name = "lbPC8kytu";
            this.lbPC8kytu.Size = new System.Drawing.Size(136, 20);
            this.lbPC8kytu.TabIndex = 17;
            this.lbPC8kytu.Text = "- Có ít nhất 8 ký tự";
            // 
            // lbPCChuHoa
            // 
            this.lbPCChuHoa.AutoSize = true;
            this.lbPCChuHoa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lbPCChuHoa.Location = new System.Drawing.Point(8, 257);
            this.lbPCChuHoa.Name = "lbPCChuHoa";
            this.lbPCChuHoa.Size = new System.Drawing.Size(181, 20);
            this.lbPCChuHoa.TabIndex = 18;
            this.lbPCChuHoa.Text = "- Có ít nhất một chữ Hoa";
            // 
            // lbPCChuThuong
            // 
            this.lbPCChuThuong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lbPCChuThuong.Location = new System.Drawing.Point(8, 281);
            this.lbPCChuThuong.Name = "lbPCChuThuong";
            this.lbPCChuThuong.Size = new System.Drawing.Size(181, 45);
            this.lbPCChuThuong.TabIndex = 19;
            this.lbPCChuThuong.Text = "-Có ít nhất một chữ thường.";
            // 
            // lbPCSo
            // 
            this.lbPCSo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lbPCSo.Location = new System.Drawing.Point(8, 330);
            this.lbPCSo.Name = "lbPCSo";
            this.lbPCSo.Size = new System.Drawing.Size(181, 25);
            this.lbPCSo.TabIndex = 20;
            this.lbPCSo.Text = "-Có ít nhất một chữ số.";
            // 
            // lbPCKyTu
            // 
            this.lbPCKyTu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lbPCKyTu.Location = new System.Drawing.Point(8, 359);
            this.lbPCKyTu.Name = "lbPCKyTu";
            this.lbPCKyTu.Size = new System.Drawing.Size(136, 49);
            this.lbPCKyTu.TabIndex = 21;
            this.lbPCKyTu.Text = "- Có ít nhất 1 ký tự đặt biệt";
            // 
            // PassChange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(481, 417);
            this.Controls.Add(this.picCheckMK_Re);
            this.Controls.Add(this.lbPCWarning);
            this.Controls.Add(this.btPCClose);
            this.Controls.Add(this.btPCDMK);
            this.Controls.Add(this.txtPCMKN_Re);
            this.Controls.Add(this.lbPCMMKN);
            this.Controls.Add(this.txtPCMKNew);
            this.Controls.Add(this.lbPCMKNew);
            this.Controls.Add(this.lbPassOld);
            this.Controls.Add(this.pnPassold);
            this.Controls.Add(this.lbChangePassChange);
            this.Controls.Add(this.pnPassChange);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(188, 88);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "PassChange";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "PassChange";
            this.pnPassChange.ResumeLayout(false);
            this.pnPassChange.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCheckMK)).EndInit();
            this.pnPassold.ResumeLayout(false);
            this.pnPassold.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picEyePassChange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCheckMK_Re)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnPassChange;
        private System.Windows.Forms.Label lbPassChange;
        private System.Windows.Forms.RichTextBox rtPassChange;
        private System.Windows.Forms.Label lbChangePassChange;
        private System.Windows.Forms.TextBox txtPCMKNow;
        private System.Windows.Forms.PictureBox picCheckMK;
        private System.Windows.Forms.Panel pnPassold;
        private System.Windows.Forms.PictureBox picEyePassChange;
        private System.Windows.Forms.Label lbPassOld;
        private System.Windows.Forms.Label lbPCMKNew;
        private System.Windows.Forms.TextBox txtPCMKNew;
        private System.Windows.Forms.Label lbPCMMKN;
        private System.Windows.Forms.TextBox txtPCMKN_Re;
        private System.Windows.Forms.Button btPCDMK;
        private System.Windows.Forms.Button btPCClose;
        private System.Windows.Forms.Label lbPCWarning;
        private System.Windows.Forms.PictureBox picCheckMK_Re;
        private System.Windows.Forms.Label lbPCChuThuong;
        private System.Windows.Forms.Label lbPCChuHoa;
        private System.Windows.Forms.Label lbPC8kytu;
        private System.Windows.Forms.Label lbPCKyTu;
        private System.Windows.Forms.Label lbPCSo;
    }
}