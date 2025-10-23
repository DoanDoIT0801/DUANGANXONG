namespace DOANNHOM
{
    partial class frmQuanLySach
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTK = new System.Windows.Forms.TextBox();
            this.rbNXB = new System.Windows.Forms.RadioButton();
            this.rbLoaiSach = new System.Windows.Forms.RadioButton();
            this.rbTacGia = new System.Windows.Forms.RadioButton();
            this.rbTenSach = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnLoaiSach = new System.Windows.Forms.Button();
            this.btnNXB = new System.Windows.Forms.Button();
            this.btnQLS = new System.Windows.Forms.Button();
            this.btnTacGia = new System.Windows.Forms.Button();
            this.btnTrangChu = new System.Windows.Forms.Button();
            this.dgvDSTK = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSTK)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtTK);
            this.groupBox1.Controls.Add(this.rbNXB);
            this.groupBox1.Controls.Add(this.rbLoaiSach);
            this.groupBox1.Controls.Add(this.rbTacGia);
            this.groupBox1.Controls.Add(this.rbTenSach);
            this.groupBox1.Location = new System.Drawing.Point(17, 69);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(388, 112);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "TÌM KIẾM SÁCH";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Tìm kiếm";
            // 
            // txtTK
            // 
            this.txtTK.Location = new System.Drawing.Point(84, 88);
            this.txtTK.Name = "txtTK";
            this.txtTK.Size = new System.Drawing.Size(233, 20);
            this.txtTK.TabIndex = 10;
            this.txtTK.TextChanged += new System.EventHandler(this.txtTK_TextChanged);
            // 
            // rbNXB
            // 
            this.rbNXB.AutoSize = true;
            this.rbNXB.Location = new System.Drawing.Point(239, 43);
            this.rbNXB.Name = "rbNXB";
            this.rbNXB.Size = new System.Drawing.Size(89, 17);
            this.rbNXB.TabIndex = 9;
            this.rbNXB.TabStop = true;
            this.rbNXB.Text = "Nhà xuất bản";
            this.rbNXB.UseVisualStyleBackColor = true;
            // 
            // rbLoaiSach
            // 
            this.rbLoaiSach.AutoSize = true;
            this.rbLoaiSach.Location = new System.Drawing.Point(95, 43);
            this.rbLoaiSach.Name = "rbLoaiSach";
            this.rbLoaiSach.Size = new System.Drawing.Size(71, 17);
            this.rbLoaiSach.TabIndex = 8;
            this.rbLoaiSach.TabStop = true;
            this.rbLoaiSach.Text = "Loại sách";
            this.rbLoaiSach.UseVisualStyleBackColor = true;
            // 
            // rbTacGia
            // 
            this.rbTacGia.AutoSize = true;
            this.rbTacGia.Location = new System.Drawing.Point(172, 43);
            this.rbTacGia.Name = "rbTacGia";
            this.rbTacGia.Size = new System.Drawing.Size(61, 17);
            this.rbTacGia.TabIndex = 7;
            this.rbTacGia.TabStop = true;
            this.rbTacGia.Text = "Tác giả";
            this.rbTacGia.UseVisualStyleBackColor = true;
            // 
            // rbTenSach
            // 
            this.rbTenSach.AutoSize = true;
            this.rbTenSach.Location = new System.Drawing.Point(6, 43);
            this.rbTenSach.Name = "rbTenSach";
            this.rbTenSach.Size = new System.Drawing.Size(70, 17);
            this.rbTenSach.TabIndex = 6;
            this.rbTenSach.TabStop = true;
            this.rbTenSach.Text = "Tên sách";
            this.rbTenSach.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnLoaiSach);
            this.groupBox2.Controls.Add(this.btnNXB);
            this.groupBox2.Controls.Add(this.btnQLS);
            this.groupBox2.Controls.Add(this.btnTacGia);
            this.groupBox2.Location = new System.Drawing.Point(411, 69);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(372, 112);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            // 
            // btnLoaiSach
            // 
            this.btnLoaiSach.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnLoaiSach.Location = new System.Drawing.Point(27, 19);
            this.btnLoaiSach.Name = "btnLoaiSach";
            this.btnLoaiSach.Size = new System.Drawing.Size(113, 38);
            this.btnLoaiSach.TabIndex = 17;
            this.btnLoaiSach.Text = "Loại Sách";
            this.btnLoaiSach.UseVisualStyleBackColor = false;
            this.btnLoaiSach.Click += new System.EventHandler(this.btnLoaiSach_Click_1);
            // 
            // btnNXB
            // 
            this.btnNXB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnNXB.Location = new System.Drawing.Point(200, 69);
            this.btnNXB.Name = "btnNXB";
            this.btnNXB.Size = new System.Drawing.Size(113, 38);
            this.btnNXB.TabIndex = 18;
            this.btnNXB.Text = "NHÀ SUÂT BẢN ";
            this.btnNXB.UseVisualStyleBackColor = false;
            this.btnNXB.Click += new System.EventHandler(this.btnNXB_Click_1);
            // 
            // btnQLS
            // 
            this.btnQLS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnQLS.Location = new System.Drawing.Point(167, 19);
            this.btnQLS.Name = "btnQLS";
            this.btnQLS.Size = new System.Drawing.Size(113, 38);
            this.btnQLS.TabIndex = 15;
            this.btnQLS.Text = "SÁCH";
            this.btnQLS.UseVisualStyleBackColor = false;
            this.btnQLS.Click += new System.EventHandler(this.btnQLS_Click_1);
            // 
            // btnTacGia
            // 
            this.btnTacGia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnTacGia.Location = new System.Drawing.Point(55, 70);
            this.btnTacGia.Name = "btnTacGia";
            this.btnTacGia.Size = new System.Drawing.Size(113, 36);
            this.btnTacGia.TabIndex = 16;
            this.btnTacGia.Text = "TÁC GIẢ";
            this.btnTacGia.UseVisualStyleBackColor = false;
            this.btnTacGia.Click += new System.EventHandler(this.btnTacGia_Click_1);
            // 
            // btnTrangChu
            // 
            this.btnTrangChu.Location = new System.Drawing.Point(708, 23);
            this.btnTrangChu.Name = "btnTrangChu";
            this.btnTrangChu.Size = new System.Drawing.Size(75, 23);
            this.btnTrangChu.TabIndex = 27;
            this.btnTrangChu.Text = "Trang Chủ";
            this.btnTrangChu.UseVisualStyleBackColor = true;
            this.btnTrangChu.Click += new System.EventHandler(this.btnTrangChu_Click_1);
            // 
            // dgvDSTK
            // 
            this.dgvDSTK.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSTK.Location = new System.Drawing.Point(17, 187);
            this.dgvDSTK.Name = "dgvDSTK";
            this.dgvDSTK.RowHeadersWidth = 51;
            this.dgvDSTK.Size = new System.Drawing.Size(766, 241);
            this.dgvDSTK.TabIndex = 26;
            // 
            // frmQuanLySach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnTrangChu);
            this.Controls.Add(this.dgvDSTK);
            this.Name = "frmQuanLySach";
            this.Text = "frmQuanLySach";
            this.Load += new System.EventHandler(this.frmQuanLySach_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSTK)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTK;
        private System.Windows.Forms.RadioButton rbNXB;
        private System.Windows.Forms.RadioButton rbLoaiSach;
        private System.Windows.Forms.RadioButton rbTacGia;
        private System.Windows.Forms.RadioButton rbTenSach;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnLoaiSach;
        private System.Windows.Forms.Button btnNXB;
        private System.Windows.Forms.Button btnQLS;
        private System.Windows.Forms.Button btnTacGia;
        private System.Windows.Forms.Button btnTrangChu;
        private System.Windows.Forms.DataGridView dgvDSTK;
    }
}