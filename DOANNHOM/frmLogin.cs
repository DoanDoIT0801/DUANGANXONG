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
    public partial class frmLogin : Form
    {
        private readonly QuanLyThuVien ql = new QuanLyThuVien();

        // ====== Session đăng nhập hiện tại ======
        public static string CurrentMaNhanVien;
        public static string CurrentMaSinhVien;
        public static string CurrentTenDangNhap;
        public static string CurrentLoaiTaiKhoan; // "NhanVien" | "SinhVien"

        public static void ClearSession()
        {
            CurrentMaNhanVien = null;
            CurrentMaSinhVien = null;
            CurrentTenDangNhap = null;
            CurrentLoaiTaiKhoan = null;
        }

        private bool _uiReady = false;

        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            // Mỗi lần quay lại màn Login thì reset phiên cũ
            ClearSession();

            // Phím tắt enter / esc
            this.AcceptButton = btnDangNhap;
            this.CancelButton = btnThoat;

            // Che mật khẩu mặc định
            txtMatKhau.UseSystemPasswordChar = true;

            // Đảm bảo sự kiện radio có gắn
            if (rbNhanVien != null) rbNhanVien.CheckedChanged += RbNhanVien_CheckedChanged;
            if (rbSinhVien != null) rbSinhVien.CheckedChanged += RbSinhVien_CheckedChanged;

            rbNhanVien.Checked = true; // mặc định

            _uiReady = true;
        }

        private void CkHienThiMk_CheckedChanged_1(object sender, EventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = !CkHienThiMk.Checked;
            txtMatKhau.SelectionStart = txtMatKhau.TextLength;
        }

        private void RbNhanVien_CheckedChanged(object sender, EventArgs e)
        {
            if (!_uiReady || !rbNhanVien.Checked) return;

            ResetInputs();
            MessageBox.Show("Mời bạn nhập thông tin Nhân viên.",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void RbSinhVien_CheckedChanged(object sender, EventArgs e)
        {
            if (!_uiReady || !rbSinhVien.Checked) return;

            ResetInputs();
            MessageBox.Show("Mời bạn nhập thông tin Sinh viên.",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ResetInputs()
        {
            txtDangNhap.Clear();
            txtMatKhau.Clear();
            txtMatKhau.UseSystemPasswordChar = !(CkHienThiMk?.Checked ?? false);
            txtDangNhap.Focus();
        }

        // ===== NÚT ĐĂNG NHẬP =====
        private void btnDangNhap_Click_1(object sender, EventArgs e)
        {
            string tenDangNhap = (txtDangNhap.Text ?? "").Trim();
            string matKhau = (txtMatKhau.Text ?? "").Trim();

            if (string.IsNullOrWhiteSpace(tenDangNhap) || string.IsNullOrWhiteSpace(matKhau))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Tên đăng nhập và Mật khẩu.",
                                "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // ========== ĐĂNG NHẬP NHÂN VIÊN ==========
                if (rbNhanVien != null && rbNhanVien.Checked)
                {
                    var nv = ql.NhanVien.FirstOrDefault(x =>
                                    x.MaNhanVien == tenDangNhap &&
                                    x.MatKhau == matKhau);

                    if (nv == null)
                    {
                        MessageBox.Show("Sai mã nhân viên hoặc mật khẩu.",
                                        "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    CurrentLoaiTaiKhoan = "NhanVien";
                    CurrentMaNhanVien = nv.MaNhanVien;
                    CurrentMaSinhVien = null;
                    CurrentTenDangNhap = nv.TenNhanVien;

                    MessageBox.Show($"Xin chào nhân viên {nv.TenNhanVien}!",
                                    "Đăng nhập thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    MoTrangChu();
                    return;
                }

                // ========== ĐĂNG NHẬP SINH VIÊN ==========
                if (rbSinhVien != null && rbSinhVien.Checked)
                {
                    // Lấy sinh viên theo MaSV
                    var sv = ql.SinhVien.FirstOrDefault(x => x.MaSV == tenDangNhap);

                    if (sv == null)
                    {
                        MessageBox.Show("Không tìm thấy mã sinh viên.",
                                        "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Mật khẩu hiện tại của sinh viên:
                    // Nếu sv.MatKhau có dữ liệu -> dùng sv.MatKhau
                    // Nếu sv.MatKhau trống -> mặc định mật khẩu = MaSV
                    string matKhauDangDung =
                        string.IsNullOrWhiteSpace(sv.MatKhau)
                            ? sv.MaSV
                            : sv.MatKhau;

                    if (!string.Equals(matKhau, matKhauDangDung, StringComparison.Ordinal))
                    {
                        MessageBox.Show("Sai mật khẩu.",
                                        "Sai mật khẩu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    CurrentLoaiTaiKhoan = "SinhVien";
                    CurrentMaSinhVien = sv.MaSV;
                    CurrentMaNhanVien = null;
                    CurrentTenDangNhap = string.IsNullOrWhiteSpace(sv.TenSV) ? sv.MaSV : sv.TenSV;

                    MessageBox.Show($"Xin chào sinh viên {CurrentTenDangNhap}!",
                                    "Đăng nhập thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    MoTrangChu();
                    return;
                }

                MessageBox.Show("Vui lòng chọn loại tài khoản để đăng nhập.",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi đăng nhập: " + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MoTrangChu()
        {
            this.Hide();

            var home = new frmTrangChu();

            // Khi frmTrangChu đóng (tức user bấm Đăng xuất),
            // ta clear session và show lại frmLogin rỗng.
            home.FormClosed += (s, args) =>
            {
                ClearSession();
                ResetInputs();
                this.Show();
                this.Activate();
                txtDangNhap.Focus();
            };

            home.Show();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Bạn có chắc muốn thoát chương trình?",
                                          "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
                Application.Exit();
        }
    }
}