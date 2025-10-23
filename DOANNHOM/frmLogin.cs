using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using DOANNHOM.data;
namespace DOANNHOM
{
    public partial class frmLogin : Form
    {
        private readonly QuanLyThuVien ql = new QuanLyThuVien();

        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            this.AcceptButton = btnDangNhap;
            // Ẩn mật khẩu + phím tắt
            txtMatKhau.UseSystemPasswordChar = true;
            this.AcceptButton = btnDangNhap; // Enter = Đăng nhập
            this.CancelButton = btnThoat;    // Esc   = Thoát

            // ===== TabIndex theo CONTAINER ngoài =====
            pnlUser.TabIndex = 0; // Panel Tên đăng nhập
            pnlPass.TabIndex = 1; // Panel Mật khẩu
            rbNhanVien.TabIndex = 2; // Điểm vào nhóm radio
            btnDangNhap.TabIndex = 3;
            btnThoat.TabIndex = 4;

            // ===== Bên trong từng panel =====
            txtDangNhap.TabIndex = 0;       // trong pnlUser
            txtMatKhau.TabIndex = 0;       // trong pnlPass
            CkHienThiMk.TabIndex = 1;       // "Xem mật khẩu" sau ô mật khẩu

            // ===== Nhóm RadioButton =====
            rbNhanVien.TabStop = true;      // chuẩn: TAB dừng 1 lần ở nhóm
            rbSinhVien.TabStop = false;     // chuyển lựa chọn bằng phím ←/→
            rbNhanVien.Checked = true;      // mặc định
        }

      

        private void CkHienThiMk_CheckedChanged_1(object sender, EventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = !CkHienThiMk.Checked;
            txtMatKhau.SelectionStart = txtMatKhau.TextLength; // tuỳ chọn
        }

        private void btnDangNhap_Click_1(object sender, EventArgs e)
        {
            // Chỉ xử lý khi đăng nhập theo Nhân viên
            if (rbNhanVien != null && !rbNhanVien.Checked)
            {
                MessageBox.Show("Vui lòng chọn 'Nhân Viên' để đăng nhập.",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string maHoacTen = txtDangNhap.Text.Trim(); // dùng như MaNhanVien
            string matKhau = txtMatKhau.Text;

            if (string.IsNullOrWhiteSpace(maHoacTen) || string.IsNullOrWhiteSpace(matKhau))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Mã nhân viên và Mật khẩu.",
                                "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var nv = ql.NhanVien.FirstOrDefault(x =>
                            x.MaNhanVien == maHoacTen && x.MatKhau == matKhau);
                // Nếu muốn dùng TenNhanVien:
                // var nv = ql.NhanVien.FirstOrDefault(x =>
                //             x.TenNhanVien == maHoacTen && x.MatKhau == matKhau);

                if (nv != null)
                {
                    MessageBox.Show($"Xin chào {nv.TenNhanVien}!",
                                    "Đăng nhập thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Ẩn Login, mở Trang Chủ (non-modal). Khi Trang Chủ đóng -> Show lại Login
                    this.Hide();
                    var home = new frmTrangChu();
                    home.FormClosed += (s, args) =>
                    {
                        txtDangNhap.Clear();
                        txtMatKhau.Clear();
                        this.Show();
                        this.Activate();
                        txtDangNhap.Focus();
                    };
                    home.Show(); // KHÔNG dùng ShowDialog()
                }
                else
                {
                    MessageBox.Show("Sai mã nhân viên hoặc mật khẩu.",
                                    "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi đăng nhập: " + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Bạn có chắc muốn thoát chương trình?",
                                          "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
    }

