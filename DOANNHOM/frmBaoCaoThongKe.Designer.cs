namespace DOANNHOM
{
    partial class frmBaoCaoThongKe
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.grpThongKeSach = new System.Windows.Forms.GroupBox();
            this.tblSach = new System.Windows.Forms.TableLayoutPanel();
            this.tileTacGia = new System.Windows.Forms.Panel();
            this.lblTacGiaValue = new System.Windows.Forms.Label();
            this.lblTacGiaTitle = new System.Windows.Forms.Label();
            this.tileNXB = new System.Windows.Forms.Panel();
            this.lblNXBValue = new System.Windows.Forms.Label();
            this.lblNXBTitle = new System.Windows.Forms.Label();
            this.tileLoaiSach = new System.Windows.Forms.Panel();
            this.lblLoaiSachValue = new System.Windows.Forms.Label();
            this.lblLoaiSachTitle = new System.Windows.Forms.Label();
            this.tileSach = new System.Windows.Forms.Panel();
            this.lblSachValue = new System.Windows.Forms.Label();
            this.lblSachTitle = new System.Windows.Forms.Label();
            this.grpThongKeKhac = new System.Windows.Forms.GroupBox();
            this.tblKhac = new System.Windows.Forms.TableLayoutPanel();
            this.tileSachMuon = new System.Windows.Forms.Panel();
            this.lblSachMuonValue = new System.Windows.Forms.Label();
            this.lblSachMuonTitle = new System.Windows.Forms.Label();
            this.tileSinhVien = new System.Windows.Forms.Panel();
            this.lblSinhVienValue = new System.Windows.Forms.Label();
            this.lblSinhVienTitle = new System.Windows.Forms.Label();
            this.pnlListHeader = new System.Windows.Forms.Panel();
            this.lblListTitle = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlHeader.SuspendLayout();
            this.grpThongKeSach.SuspendLayout();
            this.tblSach.SuspendLayout();
            this.tileTacGia.SuspendLayout();
            this.tileNXB.SuspendLayout();
            this.tileLoaiSach.SuspendLayout();
            this.tileSach.SuspendLayout();
            this.grpThongKeKhac.SuspendLayout();
            this.tblKhac.SuspendLayout();
            this.tileSachMuon.SuspendLayout();
            this.tileSinhVien.SuspendLayout();
            this.pnlListHeader.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.Teal;
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(16, 10, 16, 10);
            this.pnlHeader.Size = new System.Drawing.Size(1078, 56);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(16, 14);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(309, 28);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "HỆ THỐNG QUẢN LÝ THƯ VIỆN";
            // 
            // grpThongKeSach
            // 
            this.grpThongKeSach.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpThongKeSach.Controls.Add(this.tblSach);
            this.grpThongKeSach.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpThongKeSach.Location = new System.Drawing.Point(12, 62);
            this.grpThongKeSach.Name = "grpThongKeSach";
            this.grpThongKeSach.Padding = new System.Windows.Forms.Padding(12, 10, 12, 12);
            this.grpThongKeSach.Size = new System.Drawing.Size(1054, 118);
            this.grpThongKeSach.TabIndex = 1;
            this.grpThongKeSach.TabStop = false;
            this.grpThongKeSach.Text = "Thống Kê Sách";
            // 
            // tblSach
            // 
            this.tblSach.ColumnCount = 4;
            this.tblSach.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblSach.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblSach.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblSach.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblSach.Controls.Add(this.tileTacGia, 2, 0);
            this.tblSach.Controls.Add(this.tileNXB, 3, 0);
            this.tblSach.Controls.Add(this.tileLoaiSach, 1, 0);
            this.tblSach.Controls.Add(this.tileSach, 0, 0);
            this.tblSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblSach.Location = new System.Drawing.Point(12, 33);
            this.tblSach.Name = "tblSach";
            this.tblSach.RowCount = 1;
            this.tblSach.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblSach.Size = new System.Drawing.Size(1030, 73);
            this.tblSach.TabIndex = 0;
            // 
            // tileTacGia
            // 
            this.tileTacGia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.tileTacGia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tileTacGia.Controls.Add(this.lblTacGiaValue);
            this.tileTacGia.Controls.Add(this.lblTacGiaTitle);
            this.tileTacGia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tileTacGia.Location = new System.Drawing.Point(520, 6);
            this.tileTacGia.Margin = new System.Windows.Forms.Padding(6);
            this.tileTacGia.Name = "tileTacGia";
            this.tileTacGia.Size = new System.Drawing.Size(245, 61);
            this.tileTacGia.TabIndex = 5;
            // 
            // lblTacGiaValue
            // 
            this.lblTacGiaValue.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblTacGiaValue.AutoSize = true;
            this.lblTacGiaValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTacGiaValue.Location = new System.Drawing.Point(184, 15);
            this.lblTacGiaValue.Name = "lblTacGiaValue";
            this.lblTacGiaValue.Size = new System.Drawing.Size(36, 28);
            this.lblTacGiaValue.TabIndex = 1;
            this.lblTacGiaValue.Text = "12";
            // 
            // lblTacGiaTitle
            // 
            this.lblTacGiaTitle.AutoSize = true;
            this.lblTacGiaTitle.Location = new System.Drawing.Point(12, 20);
            this.lblTacGiaTitle.Name = "lblTacGiaTitle";
            this.lblTacGiaTitle.Size = new System.Drawing.Size(67, 23);
            this.lblTacGiaTitle.TabIndex = 0;
            this.lblTacGiaTitle.Text = "Tác Giả";
            // 
            // tileNXB
            // 
            this.tileNXB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(245)))), ((int)(((byte)(235)))));
            this.tileNXB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tileNXB.Controls.Add(this.lblNXBValue);
            this.tileNXB.Controls.Add(this.lblNXBTitle);
            this.tileNXB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tileNXB.Location = new System.Drawing.Point(777, 6);
            this.tileNXB.Margin = new System.Windows.Forms.Padding(6);
            this.tileNXB.Name = "tileNXB";
            this.tileNXB.Size = new System.Drawing.Size(247, 61);
            this.tileNXB.TabIndex = 4;
            // 
            // lblNXBValue
            // 
            this.lblNXBValue.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblNXBValue.AutoSize = true;
            this.lblNXBValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblNXBValue.Location = new System.Drawing.Point(185, 15);
            this.lblNXBValue.Name = "lblNXBValue";
            this.lblNXBValue.Size = new System.Drawing.Size(36, 28);
            this.lblNXBValue.TabIndex = 1;
            this.lblNXBValue.Text = "13";
            // 
            // lblNXBTitle
            // 
            this.lblNXBTitle.AutoSize = true;
            this.lblNXBTitle.Location = new System.Drawing.Point(12, 20);
            this.lblNXBTitle.Name = "lblNXBTitle";
            this.lblNXBTitle.Size = new System.Drawing.Size(119, 23);
            this.lblNXBTitle.TabIndex = 0;
            this.lblNXBTitle.Text = "Nhà Xuất Bản";
            // 
            // tileLoaiSach
            // 
            this.tileLoaiSach.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(245)))));
            this.tileLoaiSach.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tileLoaiSach.Controls.Add(this.lblLoaiSachValue);
            this.tileLoaiSach.Controls.Add(this.lblLoaiSachTitle);
            this.tileLoaiSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tileLoaiSach.Location = new System.Drawing.Point(263, 6);
            this.tileLoaiSach.Margin = new System.Windows.Forms.Padding(6);
            this.tileLoaiSach.Name = "tileLoaiSach";
            this.tileLoaiSach.Size = new System.Drawing.Size(245, 61);
            this.tileLoaiSach.TabIndex = 2;
            // 
            // lblLoaiSachValue
            // 
            this.lblLoaiSachValue.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblLoaiSachValue.AutoSize = true;
            this.lblLoaiSachValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblLoaiSachValue.Location = new System.Drawing.Point(183, 15);
            this.lblLoaiSachValue.Name = "lblLoaiSachValue";
            this.lblLoaiSachValue.Size = new System.Drawing.Size(36, 28);
            this.lblLoaiSachValue.TabIndex = 1;
            this.lblLoaiSachValue.Text = "18";
            // 
            // lblLoaiSachTitle
            // 
            this.lblLoaiSachTitle.AutoSize = true;
            this.lblLoaiSachTitle.Location = new System.Drawing.Point(12, 20);
            this.lblLoaiSachTitle.Name = "lblLoaiSachTitle";
            this.lblLoaiSachTitle.Size = new System.Drawing.Size(85, 23);
            this.lblLoaiSachTitle.TabIndex = 0;
            this.lblLoaiSachTitle.Text = "Loại Sách";
            // 
            // tileSach
            // 
            this.tileSach.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.tileSach.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tileSach.Controls.Add(this.lblSachValue);
            this.tileSach.Controls.Add(this.lblSachTitle);
            this.tileSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tileSach.Location = new System.Drawing.Point(6, 6);
            this.tileSach.Margin = new System.Windows.Forms.Padding(6);
            this.tileSach.Name = "tileSach";
            this.tileSach.Size = new System.Drawing.Size(245, 61);
            this.tileSach.TabIndex = 1;
            // 
            // lblSachValue
            // 
            this.lblSachValue.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblSachValue.AutoSize = true;
            this.lblSachValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblSachValue.Location = new System.Drawing.Point(199, 15);
            this.lblSachValue.Name = "lblSachValue";
            this.lblSachValue.Size = new System.Drawing.Size(24, 28);
            this.lblSachValue.TabIndex = 1;
            this.lblSachValue.Text = "9";
            // 
            // lblSachTitle
            // 
            this.lblSachTitle.AutoSize = true;
            this.lblSachTitle.Location = new System.Drawing.Point(12, 20);
            this.lblSachTitle.Name = "lblSachTitle";
            this.lblSachTitle.Size = new System.Drawing.Size(47, 23);
            this.lblSachTitle.TabIndex = 0;
            this.lblSachTitle.Text = "Sách";
            // 
            // grpThongKeKhac
            // 
            this.grpThongKeKhac.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpThongKeKhac.Controls.Add(this.tblKhac);
            this.grpThongKeKhac.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpThongKeKhac.Location = new System.Drawing.Point(12, 200);
            this.grpThongKeKhac.Name = "grpThongKeKhac";
            this.grpThongKeKhac.Padding = new System.Windows.Forms.Padding(12, 10, 12, 12);
            this.grpThongKeKhac.Size = new System.Drawing.Size(1054, 111);
            this.grpThongKeKhac.TabIndex = 2;
            this.grpThongKeKhac.TabStop = false;
            this.grpThongKeKhac.Text = "Thống kê Nhân viên - Độc giả - Số sách mượn";
            // 
            // tblKhac
            // 
            this.tblKhac.ColumnCount = 3;
            this.tblKhac.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblKhac.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblKhac.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblKhac.Controls.Add(this.tileSachMuon, 1, 0);
            this.tblKhac.Controls.Add(this.tileSinhVien, 0, 0);
            this.tblKhac.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblKhac.Location = new System.Drawing.Point(12, 33);
            this.tblKhac.Name = "tblKhac";
            this.tblKhac.RowCount = 1;
            this.tblKhac.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblKhac.Size = new System.Drawing.Size(1030, 66);
            this.tblKhac.TabIndex = 0;
            // 
            // tileSachMuon
            // 
            this.tileSachMuon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.tileSachMuon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tileSachMuon.Controls.Add(this.lblSachMuonValue);
            this.tileSachMuon.Controls.Add(this.lblSachMuonTitle);
            this.tileSachMuon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tileSachMuon.Location = new System.Drawing.Point(349, 6);
            this.tileSachMuon.Margin = new System.Windows.Forms.Padding(6);
            this.tileSachMuon.Name = "tileSachMuon";
            this.tileSachMuon.Size = new System.Drawing.Size(331, 54);
            this.tileSachMuon.TabIndex = 2;
            // 
            // lblSachMuonValue
            // 
            this.lblSachMuonValue.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblSachMuonValue.AutoSize = true;
            this.lblSachMuonValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblSachMuonValue.Location = new System.Drawing.Point(268, 14);
            this.lblSachMuonValue.Name = "lblSachMuonValue";
            this.lblSachMuonValue.Size = new System.Drawing.Size(36, 28);
            this.lblSachMuonValue.TabIndex = 1;
            this.lblSachMuonValue.Text = "11";
            // 
            // lblSachMuonTitle
            // 
            this.lblSachMuonTitle.AutoSize = true;
            this.lblSachMuonTitle.Location = new System.Drawing.Point(12, 18);
            this.lblSachMuonTitle.Name = "lblSachMuonTitle";
            this.lblSachMuonTitle.Size = new System.Drawing.Size(100, 23);
            this.lblSachMuonTitle.TabIndex = 0;
            this.lblSachMuonTitle.Text = "Sách Mượn";
            // 
            // tileSinhVien
            // 
            this.tileSinhVien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(250)))), ((int)(((byte)(230)))));
            this.tileSinhVien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tileSinhVien.Controls.Add(this.lblSinhVienValue);
            this.tileSinhVien.Controls.Add(this.lblSinhVienTitle);
            this.tileSinhVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tileSinhVien.Location = new System.Drawing.Point(6, 6);
            this.tileSinhVien.Margin = new System.Windows.Forms.Padding(6);
            this.tileSinhVien.Name = "tileSinhVien";
            this.tileSinhVien.Size = new System.Drawing.Size(331, 54);
            this.tileSinhVien.TabIndex = 1;
            // 
            // lblSinhVienValue
            // 
            this.lblSinhVienValue.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblSinhVienValue.AutoSize = true;
            this.lblSinhVienValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblSinhVienValue.Location = new System.Drawing.Point(287, 12);
            this.lblSinhVienValue.Name = "lblSinhVienValue";
            this.lblSinhVienValue.Size = new System.Drawing.Size(24, 28);
            this.lblSinhVienValue.TabIndex = 1;
            this.lblSinhVienValue.Text = "9";
            // 
            // lblSinhVienTitle
            // 
            this.lblSinhVienTitle.AutoSize = true;
            this.lblSinhVienTitle.Location = new System.Drawing.Point(12, 18);
            this.lblSinhVienTitle.Name = "lblSinhVienTitle";
            this.lblSinhVienTitle.Size = new System.Drawing.Size(85, 23);
            this.lblSinhVienTitle.TabIndex = 0;
            this.lblSinhVienTitle.Text = "Sinh Viên";
            // 
            // pnlListHeader
            // 
            this.pnlListHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlListHeader.Controls.Add(this.lblListTitle);
            this.pnlListHeader.Location = new System.Drawing.Point(12, 426);
            this.pnlListHeader.Name = "pnlListHeader";
            this.pnlListHeader.Size = new System.Drawing.Size(1054, 46);
            this.pnlListHeader.TabIndex = 4;
            // 
            // lblListTitle
            // 
            this.lblListTitle.AutoSize = true;
            this.lblListTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblListTitle.Location = new System.Drawing.Point(6, 6);
            this.lblListTitle.Name = "lblListTitle";
            this.lblListTitle.Size = new System.Drawing.Size(182, 21);
            this.lblListTitle.TabIndex = 0;
            this.lblListTitle.Text = "Danh sách đang mượn";
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 327);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1054, 76);
            this.panel1.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button1.BackColor = System.Drawing.Color.Gainsboro;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(802, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(185, 59);
            this.button1.TabIndex = 2;
            this.button1.Text = "DS Quá Hạn";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button2.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(578, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(170, 59);
            this.button2.TabIndex = 1;
            this.button2.Text = "Đang Mượn";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(6, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(395, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thống kê Sinh Viên đang mượn sách và quá hạn";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 478);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1054, 200);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // frmBaoCaoThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1078, 677);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlListHeader);
            this.Controls.Add(this.grpThongKeKhac);
            this.Controls.Add(this.grpThongKeSach);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "frmBaoCaoThongKe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo - Thống kê";
            this.Load += new System.EventHandler(this.frmBaoCaoThongKe_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.grpThongKeSach.ResumeLayout(false);
            this.tblSach.ResumeLayout(false);
            this.tileTacGia.ResumeLayout(false);
            this.tileTacGia.PerformLayout();
            this.tileNXB.ResumeLayout(false);
            this.tileNXB.PerformLayout();
            this.tileLoaiSach.ResumeLayout(false);
            this.tileLoaiSach.PerformLayout();
            this.tileSach.ResumeLayout(false);
            this.tileSach.PerformLayout();
            this.grpThongKeKhac.ResumeLayout(false);
            this.tblKhac.ResumeLayout(false);
            this.tileSachMuon.ResumeLayout(false);
            this.tileSachMuon.PerformLayout();
            this.tileSinhVien.ResumeLayout(false);
            this.tileSinhVien.PerformLayout();
            this.pnlListHeader.ResumeLayout(false);
            this.pnlListHeader.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;

        private System.Windows.Forms.GroupBox grpThongKeSach;

        private System.Windows.Forms.GroupBox grpThongKeKhac;
        private System.Windows.Forms.TableLayoutPanel tblKhac;

        private System.Windows.Forms.Panel pnlListHeader;
        private System.Windows.Forms.Label lblListTitle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tblSach;
        private System.Windows.Forms.Panel tileTacGia;
        private System.Windows.Forms.Label lblTacGiaValue;
        private System.Windows.Forms.Label lblTacGiaTitle;
        private System.Windows.Forms.Panel tileNXB;
        private System.Windows.Forms.Label lblNXBValue;
        private System.Windows.Forms.Label lblNXBTitle;
        private System.Windows.Forms.Panel tileLoaiSach;
        private System.Windows.Forms.Label lblLoaiSachValue;
        private System.Windows.Forms.Label lblLoaiSachTitle;
        private System.Windows.Forms.Panel tileSach;
        private System.Windows.Forms.Label lblSachValue;
        private System.Windows.Forms.Label lblSachTitle;
        private System.Windows.Forms.Panel tileSachMuon;
        private System.Windows.Forms.Label lblSachMuonValue;
        private System.Windows.Forms.Label lblSachMuonTitle;
        private System.Windows.Forms.Panel tileSinhVien;
        private System.Windows.Forms.Label lblSinhVienValue;
        private System.Windows.Forms.Label lblSinhVienTitle;
    }
}
