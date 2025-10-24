using DOANNHOM.data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace DOANNHOM
{
    public partial class frmThongTinTaiKhoan : Form
    {
        private readonly QuanLyThuVien ql = new QuanLyThuVien();

        public frmThongTinTaiKhoan()
        {
            InitializeComponent();

            // Gán event (kể cả khi Designer đã gán thì vẫn ok)
            this.Load += frmThongTinTaiKhoan_Load;

            if (chkXemMatKhau != null)
                chkXemMatKhau.CheckedChanged += chkXemMatKhau_CheckedChanged;

            if (chkXemMatKhauMoi != null)
                chkXemMatKhauMoi.CheckedChanged += chkXemMatKhauMoi_CheckedChanged;

            if (btnCapNhat != null)
                btnCapNhat.Click += btnCapNhat_Click;

            if (btnThoat != null)
                btnThoat.Click += (s, e) => this.Close();

            // đảm bảo mặc định che mật khẩu lúc form khởi tạo
            ApplyPasswordVisibility();
        }

        // Nếu panel1.Paint đã được auto-wire trong Designer thì để stub để tránh lỗi build
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // không cần vẽ gì
        }

        // ===== LOAD FORM =====
        private void frmThongTinTaiKhoan_Load(object sender, EventArgs e)
        {
            LoadThongTinTaiKhoan();
            ApplyPasswordVisibility();
        }

        // ----- Load theo loại tài khoản hiện tại -----
        private void LoadThongTinTaiKhoan()
        {
            string loai = frmLogin.CurrentLoaiTaiKhoan;

            if (string.Equals(loai, "NhanVien", StringComparison.OrdinalIgnoreCase))
            {
                LoadThongTinNhanVien();
                EnableChangePasswordArea(true); // Nhân viên đổi mật khẩu được
                this.Text = "Trang Chủ - [Thông tin tài khoản - Nhân viên]";
            }
            else if (string.Equals(loai, "SinhVien", StringComparison.OrdinalIgnoreCase))
            {
                LoadThongTinSinhVien();
                EnableChangePasswordArea(true); // Sinh viên cũng được đổi mật khẩu
                this.Text = "Trang Chủ - [Thông tin tài khoản - Sinh viên]";
            }
            else
            {
                ClearUI();
                EnableChangePasswordArea(false);
                this.Text = "Trang Chủ - [Thông tin tài khoản]";
                MessageBox.Show("Chưa xác định tài khoản đăng nhập.",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // ===== HIỂN THỊ NHÂN VIÊN =====
        private void LoadThongTinNhanVien()
        {
            try
            {
                string maNV = frmLogin.CurrentMaNhanVien;
                if (string.IsNullOrWhiteSpace(maNV))
                {
                    ClearUI();
                    MessageBox.Show("Không có mã nhân viên đang đăng nhập.",
                                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var nv = ql.NhanVien
                          .AsNoTracking()
                          .FirstOrDefault(x => x.MaNhanVien == maNV);

                if (nv == null)
                {
                    ClearUI();
                    MessageBox.Show("Không tìm thấy thông tin nhân viên.",
                                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Đổ thông tin
                txtTenDangNhap.Text = nv.MaNhanVien;
                txtTenHienThi.Text = nv.TenNhanVien;
                txtMatKhau.Text = nv.MatKhau;

                // Reset khu mật khẩu mới
                txtMatKhauMoi.Text = "";
                txtNhapLaiMatKhau.Text = "";

                chkXemMatKhau.Checked = false;
                chkXemMatKhauMoi.Checked = false;
                ApplyPasswordVisibility();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải thông tin nhân viên: " + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===== HIỂN THỊ SINH VIÊN =====
        private void LoadThongTinSinhVien()
        {
            try
            {
                string maSV = frmLogin.CurrentMaSinhVien;
                if (string.IsNullOrWhiteSpace(maSV))
                {
                    ClearUI();
                    MessageBox.Show("Không có mã sinh viên đang đăng nhập.",
                                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var sv = ql.SinhVien
                          .AsNoTracking()
                          .FirstOrDefault(x => x.MaSV == maSV);

                if (sv == null)
                {
                    ClearUI();
                    MessageBox.Show("Không tìm thấy thông tin sinh viên.",
                                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Lấy mật khẩu hiện tại:
                // Nếu sv.MatKhau đã đặt riêng -> dùng sv.MatKhau
                // Nếu chưa có -> mặc định là chính MaSV
                string mkDangDung = string.IsNullOrWhiteSpace(sv.MatKhau)
                                        ? sv.MaSV
                                        : sv.MatKhau;

                txtTenDangNhap.Text = sv.MaSV;
                txtTenHienThi.Text = string.IsNullOrWhiteSpace(sv.TenSV) ? sv.MaSV : sv.TenSV;
                txtMatKhau.Text = mkDangDung;

                // Reset khu đổi mật khẩu
                txtMatKhauMoi.Text = "";
                txtNhapLaiMatKhau.Text = "";

                chkXemMatKhau.Checked = false;
                chkXemMatKhauMoi.Checked = false;
                ApplyPasswordVisibility();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải thông tin sinh viên: " + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearUI()
        {
            txtTenDangNhap.Text = "";
            txtTenHienThi.Text = "";
            txtMatKhau.Text = "";
            txtMatKhauMoi.Text = "";
            txtNhapLaiMatKhau.Text = "";
        }

        // Bật/tắt phần đổi mật khẩu
        private void EnableChangePasswordArea(bool allowEdit)
        {
            // Mật khẩu hiện tại luôn chỉ đọc
            txtMatKhau.ReadOnly = true;
            txtMatKhau.Enabled = true;

            // Checkbox xem mật khẩu hiện tại ai cũng được dùng
            chkXemMatKhau.Enabled = true;

            // Phần mật khẩu mới
            txtMatKhauMoi.ReadOnly = !allowEdit;
            txtNhapLaiMatKhau.ReadOnly = !allowEdit;

            txtMatKhauMoi.Enabled = allowEdit;
            txtNhapLaiMatKhau.Enabled = allowEdit;
            chkXemMatKhauMoi.Enabled = allowEdit;
            btnCapNhat.Enabled = allowEdit;
        }

        // Ẩn/hiện mật khẩu
        private void ApplyPasswordVisibility()
        {
            bool xemCu = chkXemMatKhau?.Checked ?? false;
            txtMatKhau.UseSystemPasswordChar = !xemCu;

            bool xemMoi = chkXemMatKhauMoi?.Checked ?? false;
            txtMatKhauMoi.UseSystemPasswordChar = !xemMoi;
            txtNhapLaiMatKhau.UseSystemPasswordChar = !xemMoi;
        }

        private void chkXemMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            ApplyPasswordVisibility();
        }

        private void chkXemMatKhauMoi_CheckedChanged(object sender, EventArgs e)
        {
            ApplyPasswordVisibility();
        }

        // Nút "Cập nhật" mật khẩu
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                string loai = frmLogin.CurrentLoaiTaiKhoan;
                if (string.Equals(loai, "NhanVien", StringComparison.OrdinalIgnoreCase))
                {
                    CapNhatMatKhauNhanVien();
                }
                else if (string.Equals(loai, "SinhVien", StringComparison.OrdinalIgnoreCase))
                {
                    CapNhatMatKhauSinhVien();
                }
                else
                {
                    MessageBox.Show("Không xác định loại tài khoản để cập nhật.",
                                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật mật khẩu: " + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===== ĐỔI MẬT KHẨU NHÂN VIÊN =====
        private void CapNhatMatKhauNhanVien()
        {
            string maNV = frmLogin.CurrentMaNhanVien;
            if (string.IsNullOrWhiteSpace(maNV))
            {
                MessageBox.Show("Không có mã nhân viên đăng nhập.",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string mkCu = (txtMatKhau.Text ?? "").Trim();
            string mkMoi = (txtMatKhauMoi.Text ?? "").Trim();
            string mkLai = (txtNhapLaiMatKhau.Text ?? "").Trim();

            if (string.IsNullOrEmpty(mkMoi))
            {
                MessageBox.Show("Vui lòng nhập Mật khẩu mới.",
                                "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhauMoi.Focus();
                return;
            }

            if (mkMoi != mkLai)
            {
                MessageBox.Show("Mật khẩu mới và Nhập lại mật khẩu không khớp.",
                                "Không khớp", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNhapLaiMatKhau.Focus();
                return;
            }

            var nv = ql.NhanVien.FirstOrDefault(x => x.MaNhanVien == maNV);
            if (nv == null)
            {
                MessageBox.Show("Không tìm thấy nhân viên để cập nhật.",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!string.Equals(nv.MatKhau, mkCu, StringComparison.Ordinal))
            {
                MessageBox.Show("Mật khẩu hiện tại không đúng.",
                                "Sai mật khẩu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.Equals(mkMoi, mkCu, StringComparison.Ordinal))
            {
                MessageBox.Show("Mật khẩu mới phải khác mật khẩu hiện tại.",
                                "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhauMoi.Focus();
                return;
            }

            nv.MatKhau = mkMoi;
            ql.SaveChanges();

            txtMatKhau.Text = mkMoi;
            txtMatKhauMoi.Text = "";
            txtNhapLaiMatKhau.Text = "";
            chkXemMatKhauMoi.Checked = false;
            ApplyPasswordVisibility();

            MessageBox.Show("Cập nhật mật khẩu thành công!",
                            "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ===== ĐỔI MẬT KHẨU SINH VIÊN =====
        private void CapNhatMatKhauSinhVien()
        {
            string maSV = frmLogin.CurrentMaSinhVien;
            if (string.IsNullOrWhiteSpace(maSV))
            {
                MessageBox.Show("Không có mã sinh viên đăng nhập.",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string mkCu = (txtMatKhau.Text ?? "").Trim();
            string mkMoi = (txtMatKhauMoi.Text ?? "").Trim();
            string mkLai = (txtNhapLaiMatKhau.Text ?? "").Trim();

            if (string.IsNullOrEmpty(mkMoi))
            {
                MessageBox.Show("Vui lòng nhập Mật khẩu mới.",
                                "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhauMoi.Focus();
                return;
            }

            if (mkMoi != mkLai)
            {
                MessageBox.Show("Mật khẩu mới và Nhập lại mật khẩu không khớp.",
                                "Không khớp", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNhapLaiMatKhau.Focus();
                return;
            }

            var sv = ql.SinhVien.FirstOrDefault(x => x.MaSV == maSV);
            if (sv == null)
            {
                MessageBox.Show("Không tìm thấy sinh viên để cập nhật.",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // MK hiện đang dùng để login:
            // nếu sv.MatKhau trống => mk hiện tại = MaSV
            // nếu sv.MatKhau có => mk hiện tại = sv.MatKhau
            string mkDangDung = string.IsNullOrWhiteSpace(sv.MatKhau)
                                    ? sv.MaSV
                                    : sv.MatKhau;

            if (!string.Equals(mkCu, mkDangDung, StringComparison.Ordinal))
            {
                MessageBox.Show("Mật khẩu hiện tại không đúng.",
                                "Sai mật khẩu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.Equals(mkMoi, mkCu, StringComparison.Ordinal))
            {
                MessageBox.Show("Mật khẩu mới phải khác mật khẩu hiện tại.",
                                "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhauMoi.Focus();
                return;
            }

            // Lưu mật khẩu mới vào DB
            sv.MatKhau = mkMoi;
            ql.SaveChanges();

            // Cập nhật lại UI khớp với DB
            txtMatKhau.Text = mkMoi;
            txtMatKhauMoi.Text = "";
            txtNhapLaiMatKhau.Text = "";
            chkXemMatKhauMoi.Checked = false;
            ApplyPasswordVisibility();

            MessageBox.Show("Cập nhật mật khẩu thành công!",
                            "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}