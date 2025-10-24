using DOANNHOM.data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DOANNHOM
{
    public partial class frmDocGia : Form
    {
        // Khai báo DbContext
        QuanLyThuVien db = new QuanLyThuVien();

        /*private bool isAddingMode = false;*/
        private string currentAction = ""; // theo dõi hành động hiện tại: "THEM", "SUA", "XOA", ""

        public frmDocGia()
        {
            InitializeComponent();
        }

        // ------------------ KHI FORM LOAD ------------------
        private void frmDocGia_Load(object sender, EventArgs e)
        {
            LoadData();
            SetControlState(false); // Disable textbox
            ResetButtonState();     // Đặt lại trạng thái ban đầu các nút
        }

        // ------------------ QUẢN LÝ TRẠNG THÁI CONTROL ------------------
        private void SetControlState(bool isEnabled)
        {
            txtMaSV.Enabled = isEnabled;
            txtTenSV.Enabled = isEnabled;
            txtNganhHoc.Enabled = isEnabled;
            txtKhoaHoc.Enabled = isEnabled;
            txtSDT.Enabled = isEnabled;
            txtMatKhau.Enabled = isEnabled;
        }

        private void ResetButtonState()
        {
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnHuy.Enabled = false;
            currentAction = "";
        }

        private void ClearInput()
        {
            txtMaSV.Clear();
            txtTenSV.Clear();
            txtNganhHoc.Clear();
            txtKhoaHoc.Clear();
            txtSDT.Clear();
            txtMatKhau.Clear();
        }

        // ------------------ LOAD DỮ LIỆU ------------------
        private void LoadData()
        {
            var list = db.SinhVien
                .Select(x => new
                {
                    x.MaSV,
                    x.TenSV,
                    x.NganhHoc,
                    x.KhoaHoc,
                    x.SoDienThoai,
                    x.MatKhau
                })
                .ToList();

            dgvDocGia.DataSource = list;
        }

        // ------------------ NÚT THÊM ------------------
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (currentAction == "") // chuyển sang chế độ thêm
            {
                currentAction = "THEM";
                SetControlState(true);
                ClearInput();
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                btnHuy.Enabled = true;
                MessageBox.Show("Đang trong chế độ Thêm", "Thông báo");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMaSV.Text))
            {
                MessageBox.Show("Vui lòng nhập mã độc giả!");
                return;
            }

            try
            {
                if (db.SinhVien.Any(x => x.MaSV == txtMaSV.Text.Trim()))
                {
                    MessageBox.Show("Mã độc giả đã tồn tại!");
                    return;
                }

                string sdt = txtSDT.Text.Trim();
                if (string.IsNullOrEmpty(sdt))
                {
                    MessageBox.Show("Vui lòng nhập số điện thoại!");
                    return;
                }
                if (!int.TryParse(sdt, out int soDienThoai))
                {
                    MessageBox.Show("Số điện thoại phải là số!");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtMatKhau.Text))
                {
                    MessageBox.Show("Vui lòng nhập mật khẩu!");
                    return;
                }

                var dg = new SinhVien
                {
                    MaSV = txtMaSV.Text.Trim(),
                    TenSV = txtTenSV.Text.Trim(),
                    NganhHoc = txtNganhHoc.Text.Trim(),
                    KhoaHoc = txtKhoaHoc.Text.Trim(),
                    SoDienThoai = soDienThoai,
                    MatKhau = txtMatKhau.Text.Trim()
                };

                db.SinhVien.Add(dg);
                db.SaveChanges();

                MessageBox.Show("Thêm độc giả thành công!");
                LoadData();
                ClearInput();
                ResetButtonState();
                SetControlState(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm độc giả: " + ex.Message);
            }
        }

        // ------------------ SỬA ------------------
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (currentAction == "")
            {
                currentAction = "SUA";
                SetControlState(true);
                btnThem.Enabled = false;
                btnXoa.Enabled = false;
                btnHuy.Enabled = true;
                MessageBox.Show("Đang trong chế độ Sửa", "Thông báo");
                return;
            }

            string maDG = txtMaSV.Text.Trim();

            if (string.IsNullOrWhiteSpace(maDG))
            {
                MessageBox.Show("Vui lòng nhập mã độc giả cần sửa!");
                return;
            }

            try
            {
                var dg = db.SinhVien.FirstOrDefault(x => x.MaSV == maDG);
                if (dg == null)
                {
                    MessageBox.Show("Không tìm thấy độc giả có mã này!");
                    return;
                }

                var confirm = MessageBox.Show(
                    $"Bạn có chắc muốn cập nhật thông tin cho độc giả '{dg.TenSV}'?",
                    "Xác nhận sửa thông tin",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    dg.TenSV = txtTenSV.Text.Trim();
                    dg.NganhHoc = txtNganhHoc.Text.Trim();
                    dg.KhoaHoc = txtKhoaHoc.Text.Trim();

                    if (int.TryParse(txtSDT.Text.Trim(), out int sdtMoi))
                    {
                        dg.SoDienThoai = sdtMoi;
                    }
                    else
                    {
                        MessageBox.Show("Số điện thoại không hợp lệ!");
                        return;
                    }

                    if (!string.IsNullOrWhiteSpace(txtMatKhau.Text))
                    {
                        dg.MatKhau = txtMatKhau.Text.Trim();
                    }

                    db.SaveChanges();

                    MessageBox.Show("Cập nhật thông tin thành công!");
                    LoadData();
                    ClearInput();
                    ResetButtonState();
                    SetControlState(false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa thông tin độc giả: " + ex.Message);
            }
        }

        // ------------------ XÓA ------------------
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (currentAction == "")
            {
                currentAction = "XOA";
                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnHuy.Enabled = true;
                MessageBox.Show("Đang trong chế độ Xóa", "Thông báo");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMaSV.Text))
            {
                MessageBox.Show("Vui lòng chọn độc giả cần xóa!");
                return;
            }

            var confirm = MessageBox.Show("Bạn có chắc muốn xóa độc giả này?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.No) return;

            try
            {
                var dg = db.SinhVien.FirstOrDefault(x => x.MaSV == txtMaSV.Text.Trim());
                if (dg == null)
                {
                    MessageBox.Show("Không tìm thấy độc giả cần xóa!");
                    return;
                }

                db.SinhVien.Remove(dg);
                db.SaveChanges();

                MessageBox.Show("Xóa độc giả thành công!");
                LoadData();
                ClearInput();
                ResetButtonState();
                SetControlState(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa độc giả: " + ex.Message);
            }
        }

        // ------------------ CLICK DGV ------------------
        private void dgvDocGia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDocGia.Rows[e.RowIndex];
                txtMaSV.Text = row.Cells["MaSV"].Value?.ToString();
                txtTenSV.Text = row.Cells["TenSV"].Value?.ToString();
                txtNganhHoc.Text = row.Cells["NganhHoc"].Value?.ToString();
                txtKhoaHoc.Text = row.Cells["KhoaHoc"].Value?.ToString();
                txtSDT.Text = row.Cells["SoDienThoai"].Value?.ToString();
                txtMatKhau.Text = row.Cells["MatKhau"].Value?.ToString();
            }
        }

        // ------------------ TÌM KIẾM ------------------
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text.Trim();

            if (string.IsNullOrEmpty(tuKhoa))
            {
                LoadData();
                return;
            }

            var query = db.SinhVien.AsQueryable();

            if (rbTimTheoMa.Checked)
            {
                query = query.Where(x => x.MaSV.Contains(tuKhoa));
            }
            else if (rbTimTheoTen.Checked)
            {
                query = query.Where(x => x.TenSV.Contains(tuKhoa));
            }

            var list = query.Select(x => new
            {
                x.MaSV,
                x.TenSV,
                x.NganhHoc,
                x.KhoaHoc,
                x.SoDienThoai,
                x.MatKhau
            }).ToList();

            dgvDocGia.DataSource = list;
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTimKiem.Text))
            {
                LoadData();
            }
        }

        // ------------------ THOÁT ------------------
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ------------------ HỦY ------------------
        private void btnHuy_Click(object sender, EventArgs e)
        {
            ClearInput();
            SetControlState(false);
            ResetButtonState();
        }
        //done
    }
}
