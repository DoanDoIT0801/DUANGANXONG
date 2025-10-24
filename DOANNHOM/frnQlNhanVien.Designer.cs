namespace DOANNHOM
{
    partial class frmQLNhanVien
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
            this.panel5 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTimKiemNV = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.rdoGioiTinh = new System.Windows.Forms.RadioButton();
            this.rdoTenNV = new System.Windows.Forms.RadioButton();
            this.rdoMaNV = new System.Windows.Forms.RadioButton();
            this.btnThoat = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvNV = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnHuy = new System.Windows.Forms.Button();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnDK = new System.Windows.Forms.Button();
            this.txtMK = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.rdNu = new System.Windows.Forms.RadioButton();
            this.rdNam = new System.Windows.Forms.RadioButton();
            this.txtTenNV = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNV)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.groupBox1);
            this.panel5.Location = new System.Drawing.Point(15, 415);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(387, 101);
            this.panel5.TabIndex = 15;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTimKiemNV);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.rdoGioiTinh);
            this.groupBox1.Controls.Add(this.rdoTenNV);
            this.groupBox1.Controls.Add(this.rdoMaNV);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(381, 93);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm Kiếm Nhân Viên";
            // 
            // txtTimKiemNV
            // 
            this.txtTimKiemNV.Location = new System.Drawing.Point(76, 47);
            this.txtTimKiemNV.Name = "txtTimKiemNV";
            this.txtTimKiemNV.Size = new System.Drawing.Size(188, 22);
            this.txtTimKiemNV.TabIndex = 15;
            this.txtTimKiemNV.TextChanged += new System.EventHandler(this.txtTimKiemNV_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 16);
            this.label7.TabIndex = 14;
            this.label7.Text = "Tìm Kiếm";
            // 
            // rdoGioiTinh
            // 
            this.rdoGioiTinh.AutoSize = true;
            this.rdoGioiTinh.Location = new System.Drawing.Point(277, 21);
            this.rdoGioiTinh.Name = "rdoGioiTinh";
            this.rdoGioiTinh.Size = new System.Drawing.Size(81, 20);
            this.rdoGioiTinh.TabIndex = 13;
            this.rdoGioiTinh.TabStop = true;
            this.rdoGioiTinh.Text = "Giới Tính";
            this.rdoGioiTinh.UseVisualStyleBackColor = true;
            // 
            // rdoTenNV
            // 
            this.rdoTenNV.AutoSize = true;
            this.rdoTenNV.Location = new System.Drawing.Point(136, 21);
            this.rdoTenNV.Name = "rdoTenNV";
            this.rdoTenNV.Size = new System.Drawing.Size(117, 20);
            this.rdoTenNV.TabIndex = 12;
            this.rdoTenNV.TabStop = true;
            this.rdoTenNV.Text = "Tên Nhân Viên";
            this.rdoTenNV.UseVisualStyleBackColor = true;
            // 
            // rdoMaNV
            // 
            this.rdoMaNV.AutoSize = true;
            this.rdoMaNV.Location = new System.Drawing.Point(6, 21);
            this.rdoMaNV.Name = "rdoMaNV";
            this.rdoMaNV.Size = new System.Drawing.Size(112, 20);
            this.rdoMaNV.TabIndex = 11;
            this.rdoMaNV.TabStop = true;
            this.rdoMaNV.Text = "Mã Nhân Viên";
            this.rdoMaNV.UseVisualStyleBackColor = true;
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(1012, 517);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 31);
            this.btnThoat.TabIndex = 14;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvNV);
            this.panel3.Location = new System.Drawing.Point(409, 77);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(684, 439);
            this.panel3.TabIndex = 13;
            // 
            // dgvNV
            // 
            this.dgvNV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNV.Location = new System.Drawing.Point(3, 3);
            this.dgvNV.Name = "dgvNV";
            this.dgvNV.RowHeadersWidth = 51;
            this.dgvNV.RowTemplate.Height = 24;
            this.dgvNV.Size = new System.Drawing.Size(675, 431);
            this.dgvNV.TabIndex = 1;
            this.dgvNV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNV_CellClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnHuy);
            this.panel2.Controls.Add(this.txtSDT);
            this.panel2.Controls.Add(this.btnXoa);
            this.panel2.Controls.Add(this.btnDK);
            this.panel2.Controls.Add(this.txtMK);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtDiaChi);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.rdNu);
            this.panel2.Controls.Add(this.rdNam);
            this.panel2.Controls.Add(this.txtTenNV);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtMaNV);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(15, 77);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(388, 323);
            this.panel2.TabIndex = 12;
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(280, 282);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(96, 30);
            this.btnHuy.TabIndex = 17;
            this.btnHuy.Text = "Hủy Bỏ";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(156, 153);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(220, 22);
            this.txtSDT.TabIndex = 16;
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(155, 282);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(101, 30);
            this.btnXoa.TabIndex = 15;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnDK
            // 
            this.btnDK.Location = new System.Drawing.Point(17, 282);
            this.btnDK.Name = "btnDK";
            this.btnDK.Size = new System.Drawing.Size(104, 30);
            this.btnDK.TabIndex = 14;
            this.btnDK.Text = "Đăng Ký";
            this.btnDK.UseVisualStyleBackColor = true;
            this.btnDK.Click += new System.EventHandler(this.btnDK_Click);
            // 
            // txtMK
            // 
            this.txtMK.Location = new System.Drawing.Point(155, 56);
            this.txtMK.Name = "txtMK";
            this.txtMK.Size = new System.Drawing.Size(220, 22);
            this.txtMK.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(30, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "Mật Khẩu";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(156, 240);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(220, 22);
            this.txtDiaChi.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(14, 243);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Địa Chỉ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(47, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "SĐT";
            // 
            // rdNu
            // 
            this.rdNu.AutoSize = true;
            this.rdNu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdNu.Location = new System.Drawing.Point(178, 106);
            this.rdNu.Name = "rdNu";
            this.rdNu.Size = new System.Drawing.Size(47, 21);
            this.rdNu.TabIndex = 6;
            this.rdNu.TabStop = true;
            this.rdNu.Text = "Nữ";
            this.rdNu.UseVisualStyleBackColor = true;
            // 
            // rdNam
            // 
            this.rdNam.AutoSize = true;
            this.rdNam.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdNam.Location = new System.Drawing.Point(61, 106);
            this.rdNam.Name = "rdNam";
            this.rdNam.Size = new System.Drawing.Size(58, 21);
            this.rdNam.TabIndex = 5;
            this.rdNam.TabStop = true;
            this.rdNam.Text = "Nam";
            this.rdNam.UseVisualStyleBackColor = true;
            // 
            // txtTenNV
            // 
            this.txtTenNV.Location = new System.Drawing.Point(156, 197);
            this.txtTenNV.Name = "txtTenNV";
            this.txtTenNV.Size = new System.Drawing.Size(220, 22);
            this.txtTenNV.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 202);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Tên Nhân Viên";
            // 
            // txtMaNV
            // 
            this.txtMaNV.Location = new System.Drawing.Point(156, 13);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Size = new System.Drawing.Size(220, 22);
            this.txtMaNV.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(30, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mã NV-TK";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(6, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1087, 44);
            this.panel1.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(412, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quản Lý Nhân Viên";
            // 
            // frmQLNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1099, 555);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmQLNhanVien";
            this.Text = "frnQlNhanVien";
            this.Load += new System.EventHandler(this.frmQLNhanVien_Load);
            this.panel5.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNV)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtTimKiemNV;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton rdoGioiTinh;
        private System.Windows.Forms.RadioButton rdoTenNV;
        private System.Windows.Forms.RadioButton rdoMaNV;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvNV;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnDK;
        private System.Windows.Forms.TextBox txtMK;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rdNu;
        private System.Windows.Forms.RadioButton rdNam;
        private System.Windows.Forms.TextBox txtTenNV;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMaNV;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
    }
}