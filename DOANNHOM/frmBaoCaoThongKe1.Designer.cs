namespace DOANNHOM
{
    partial class frmBaoCaoThongKe1
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
            this.grpThongKeKhac = new System.Windows.Forms.GroupBox();
            this.tblKhac = new System.Windows.Forms.TableLayoutPanel();
            this.tileNhanVien = new System.Windows.Forms.Panel();
            this.lblSachMuonValue = new System.Windows.Forms.Label();
            this.lblNhanVienTitle = new System.Windows.Forms.Label();
            this.tileSachMuon = new System.Windows.Forms.Panel();
            this.lblNVValue = new System.Windows.Forms.Label();
            this.lblSachMuonTitle = new System.Windows.Forms.Label();
            this.tileSinhVien = new System.Windows.Forms.Panel();
            this.lblSinhVienValue = new System.Windows.Forms.Label();
            this.lblSinhVienTitle = new System.Windows.Forms.Label();
            this.btnQuaHan = new System.Windows.Forms.Button();
            this.btnDangMuon = new System.Windows.Forms.Button();
            this.lblListTitle = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.dgvDanhSachMuon = new System.Windows.Forms.DataGridView();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.grpSinhVienMuonvaQuaHan = new System.Windows.Forms.GroupBox();
            this.txtTongSach = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
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
            this.btnIn = new System.Windows.Forms.Button();
            this.grpThongKeKhac.SuspendLayout();
            this.tblKhac.SuspendLayout();
            this.tileNhanVien.SuspendLayout();
            this.tileSachMuon.SuspendLayout();
            this.tileSinhVien.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachMuon)).BeginInit();
            this.grpSinhVienMuonvaQuaHan.SuspendLayout();
            this.grpThongKeSach.SuspendLayout();
            this.tblSach.SuspendLayout();
            this.tileTacGia.SuspendLayout();
            this.tileNXB.SuspendLayout();
            this.tileLoaiSach.SuspendLayout();
            this.tileSach.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpThongKeKhac
            // 
            this.grpThongKeKhac.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpThongKeKhac.Controls.Add(this.tblKhac);
            this.grpThongKeKhac.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpThongKeKhac.Location = new System.Drawing.Point(12, 170);
            this.grpThongKeKhac.Name = "grpThongKeKhac";
            this.grpThongKeKhac.Padding = new System.Windows.Forms.Padding(12, 10, 12, 12);
            this.grpThongKeKhac.Size = new System.Drawing.Size(1054, 111);
            this.grpThongKeKhac.TabIndex = 3;
            this.grpThongKeKhac.TabStop = false;
            this.grpThongKeKhac.Text = "Thống kê Nhân viên - Độc giả - Số sách mượn";
            // 
            // tblKhac
            // 
            this.tblKhac.ColumnCount = 3;
            this.tblKhac.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblKhac.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblKhac.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblKhac.Controls.Add(this.tileNhanVien, 2, 0);
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
            // tileNhanVien
            // 
            this.tileNhanVien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.tileNhanVien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tileNhanVien.Controls.Add(this.lblSachMuonValue);
            this.tileNhanVien.Controls.Add(this.lblNhanVienTitle);
            this.tileNhanVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tileNhanVien.Location = new System.Drawing.Point(692, 6);
            this.tileNhanVien.Margin = new System.Windows.Forms.Padding(6);
            this.tileNhanVien.Name = "tileNhanVien";
            this.tileNhanVien.Size = new System.Drawing.Size(332, 54);
            this.tileNhanVien.TabIndex = 3;
            // 
            // lblSachMuonValue
            // 
            this.lblSachMuonValue.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblSachMuonValue.AutoSize = true;
            this.lblSachMuonValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblSachMuonValue.Location = new System.Drawing.Point(288, 12);
            this.lblSachMuonValue.Name = "lblSachMuonValue";
            this.lblSachMuonValue.Size = new System.Drawing.Size(0, 28);
            this.lblSachMuonValue.TabIndex = 1;
            // 
            // lblNhanVienTitle
            // 
            this.lblNhanVienTitle.AutoSize = true;
            this.lblNhanVienTitle.Location = new System.Drawing.Point(12, 18);
            this.lblNhanVienTitle.Name = "lblNhanVienTitle";
            this.lblNhanVienTitle.Size = new System.Drawing.Size(100, 23);
            this.lblNhanVienTitle.TabIndex = 0;
            this.lblNhanVienTitle.Text = "Sách Mượn";
            // 
            // tileSachMuon
            // 
            this.tileSachMuon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.tileSachMuon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tileSachMuon.Controls.Add(this.lblNVValue);
            this.tileSachMuon.Controls.Add(this.lblSachMuonTitle);
            this.tileSachMuon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tileSachMuon.Location = new System.Drawing.Point(349, 6);
            this.tileSachMuon.Margin = new System.Windows.Forms.Padding(6);
            this.tileSachMuon.Name = "tileSachMuon";
            this.tileSachMuon.Size = new System.Drawing.Size(331, 54);
            this.tileSachMuon.TabIndex = 2;
            // 
            // lblNVValue
            // 
            this.lblNVValue.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblNVValue.AutoSize = true;
            this.lblNVValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblNVValue.Location = new System.Drawing.Point(268, 14);
            this.lblNVValue.Name = "lblNVValue";
            this.lblNVValue.Size = new System.Drawing.Size(0, 28);
            this.lblNVValue.TabIndex = 1;
            // 
            // lblSachMuonTitle
            // 
            this.lblSachMuonTitle.AutoSize = true;
            this.lblSachMuonTitle.Location = new System.Drawing.Point(12, 18);
            this.lblSachMuonTitle.Name = "lblSachMuonTitle";
            this.lblSachMuonTitle.Size = new System.Drawing.Size(92, 23);
            this.lblSachMuonTitle.TabIndex = 0;
            this.lblSachMuonTitle.Text = "Nhân Viên";
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
            this.lblSinhVienValue.Size = new System.Drawing.Size(0, 28);
            this.lblSinhVienValue.TabIndex = 1;
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
            // btnQuaHan
            // 
            this.btnQuaHan.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnQuaHan.BackColor = System.Drawing.Color.Gainsboro;
            this.btnQuaHan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuaHan.Location = new System.Drawing.Point(536, 30);
            this.btnQuaHan.Name = "btnQuaHan";
            this.btnQuaHan.Size = new System.Drawing.Size(155, 47);
            this.btnQuaHan.TabIndex = 2;
            this.btnQuaHan.Text = "DS Quá Hạn";
            this.btnQuaHan.UseVisualStyleBackColor = false;
            this.btnQuaHan.Click += new System.EventHandler(this.btnQuaHan_Click);
            // 
            // btnDangMuon
            // 
            this.btnDangMuon.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnDangMuon.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnDangMuon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangMuon.ForeColor = System.Drawing.Color.White;
            this.btnDangMuon.Location = new System.Drawing.Point(287, 35);
            this.btnDangMuon.Name = "btnDangMuon";
            this.btnDangMuon.Size = new System.Drawing.Size(155, 47);
            this.btnDangMuon.TabIndex = 1;
            this.btnDangMuon.Text = "Đang Mượn";
            this.btnDangMuon.UseVisualStyleBackColor = false;
            this.btnDangMuon.Click += new System.EventHandler(this.btnDangMuon_Click);
            // 
            // lblListTitle
            // 
            this.lblListTitle.AutoSize = true;
            this.lblListTitle.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblListTitle.Location = new System.Drawing.Point(375, 104);
            this.lblListTitle.Name = "lblListTitle";
            this.lblListTitle.Size = new System.Drawing.Size(203, 25);
            this.lblListTitle.TabIndex = 0;
            this.lblListTitle.Text = "Danh sách đang mượn";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.dgvDanhSachMuon);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 143);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1042, 187);
            this.flowLayoutPanel1.TabIndex = 8;
            // 
            // dgvDanhSachMuon
            // 
            this.dgvDanhSachMuon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSachMuon.Location = new System.Drawing.Point(3, 3);
            this.dgvDanhSachMuon.Name = "dgvDanhSachMuon";
            this.dgvDanhSachMuon.RowHeadersWidth = 51;
            this.dgvDanhSachMuon.RowTemplate.Height = 24;
            this.dgvDanhSachMuon.Size = new System.Drawing.Size(1039, 184);
            this.dgvDanhSachMuon.TabIndex = 0;
            // 
            // grpSinhVienMuonvaQuaHan
            // 
            this.grpSinhVienMuonvaQuaHan.Controls.Add(this.txtTongSach);
            this.grpSinhVienMuonvaQuaHan.Controls.Add(this.label1);
            this.grpSinhVienMuonvaQuaHan.Controls.Add(this.lblListTitle);
            this.grpSinhVienMuonvaQuaHan.Controls.Add(this.btnQuaHan);
            this.grpSinhVienMuonvaQuaHan.Controls.Add(this.flowLayoutPanel1);
            this.grpSinhVienMuonvaQuaHan.Controls.Add(this.btnDangMuon);
            this.grpSinhVienMuonvaQuaHan.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpSinhVienMuonvaQuaHan.Location = new System.Drawing.Point(12, 287);
            this.grpSinhVienMuonvaQuaHan.Name = "grpSinhVienMuonvaQuaHan";
            this.grpSinhVienMuonvaQuaHan.Size = new System.Drawing.Size(1054, 336);
            this.grpSinhVienMuonvaQuaHan.TabIndex = 10;
            this.grpSinhVienMuonvaQuaHan.TabStop = false;
            this.grpSinhVienMuonvaQuaHan.Text = "Thống kê sinh viên đang mượn sách và quá hạn";
            // 
            // txtTongSach
            // 
            this.txtTongSach.Location = new System.Drawing.Point(845, 104);
            this.txtTongSach.Name = "txtTongSach";
            this.txtTongSach.Size = new System.Drawing.Size(197, 31);
            this.txtTongSach.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(692, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 25);
            this.label1.TabIndex = 9;
            this.label1.Text = "Tổng số sách: ";
            // 
            // grpThongKeSach
            // 
            this.grpThongKeSach.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpThongKeSach.Controls.Add(this.tblSach);
            this.grpThongKeSach.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpThongKeSach.Location = new System.Drawing.Point(15, 23);
            this.grpThongKeSach.Name = "grpThongKeSach";
            this.grpThongKeSach.Padding = new System.Windows.Forms.Padding(12, 10, 12, 12);
            this.grpThongKeSach.Size = new System.Drawing.Size(1054, 118);
            this.grpThongKeSach.TabIndex = 11;
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
            this.lblTacGiaValue.Size = new System.Drawing.Size(0, 28);
            this.lblTacGiaValue.TabIndex = 1;
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
            this.lblNXBValue.Size = new System.Drawing.Size(0, 28);
            this.lblNXBValue.TabIndex = 1;
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
            this.lblLoaiSachValue.Size = new System.Drawing.Size(0, 28);
            this.lblLoaiSachValue.TabIndex = 1;
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
            this.lblSachValue.Size = new System.Drawing.Size(0, 28);
            this.lblSachValue.TabIndex = 1;
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
            // btnIn
            // 
            this.btnIn.Location = new System.Drawing.Point(870, 639);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(181, 34);
            this.btnIn.TabIndex = 13;
            this.btnIn.Text = "In Báo Cáo ";
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // frmBaoCaoThongKe1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 685);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.grpThongKeSach);
            this.Controls.Add(this.grpSinhVienMuonvaQuaHan);
            this.Controls.Add(this.grpThongKeKhac);
            this.Name = "frmBaoCaoThongKe1";
            this.Text = "frmBaoCaoThongKe1";
            this.Load += new System.EventHandler(this.frmBaoCaoThongKe1_Load);
            this.grpThongKeKhac.ResumeLayout(false);
            this.tblKhac.ResumeLayout(false);
            this.tileNhanVien.ResumeLayout(false);
            this.tileNhanVien.PerformLayout();
            this.tileSachMuon.ResumeLayout(false);
            this.tileSachMuon.PerformLayout();
            this.tileSinhVien.ResumeLayout(false);
            this.tileSinhVien.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachMuon)).EndInit();
            this.grpSinhVienMuonvaQuaHan.ResumeLayout(false);
            this.grpSinhVienMuonvaQuaHan.PerformLayout();
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
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox grpThongKeKhac;
        private System.Windows.Forms.TableLayoutPanel tblKhac;
        private System.Windows.Forms.Button btnQuaHan;
        private System.Windows.Forms.Button btnDangMuon;
        private System.Windows.Forms.Label lblListTitle;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.DataGridView dgvDanhSachMuon;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox grpSinhVienMuonvaQuaHan;
        private System.Windows.Forms.TextBox txtTongSach;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel tileNhanVien;
        private System.Windows.Forms.Label lblSachMuonValue;
        private System.Windows.Forms.Label lblNhanVienTitle;
        private System.Windows.Forms.Panel tileSachMuon;
        private System.Windows.Forms.Label lblNVValue;
        private System.Windows.Forms.Label lblSachMuonTitle;
        private System.Windows.Forms.Panel tileSinhVien;
        private System.Windows.Forms.Label lblSinhVienValue;
        private System.Windows.Forms.Label lblSinhVienTitle;
        private System.Windows.Forms.GroupBox grpThongKeSach;
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
        private System.Windows.Forms.Button btnIn;
    }
}