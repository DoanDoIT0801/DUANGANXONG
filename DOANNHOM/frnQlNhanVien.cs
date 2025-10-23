using DOANNHOM.data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DOANNHOM
{
    public partial class frmQLNhanVien : Form
    {
        /*string imagePath = "";*/
        QuanLyThuVien db = new QuanLyThuVien();

        private string currentAction = ""; // "THEM", "SUA", "XOA", ""

        public frmQLNhanVien()
        {
            InitializeComponent();
        }

        // ------------------ KHI FORM LOAD ------------------
        private void frmQLNhanVien_Load(object sender, EventArgs e)
        {
            LoadData();
            ResetButtonState();
            SetControlState(false);
        }

        // ------------------ QUẢN LÝ TRẠNG THÁI CONTROL ------------------
        private void SetControlState(bool isEnabled)
        {
            txtMaNV.Enabled = isEnabled;
            txtTenNV.Enabled = isEnabled;
            txtSDT.Enabled = isEnabled;
            txtDiaChi.Enabled = isEnabled;
            txtMK.Enabled = isEnabled;
            rdNam.Enabled = isEnabled;
            rdNu.Enabled = isEnabled;
        }

        private void ResetButtonState()
        {
            btnDK.Enabled = true;
            
            btnXoa.Enabled = true;
            btnHuy.Enabled = false;
            currentAction = "";
        }

        private void ClearInput()
        {
            txtMaNV.Clear();
            txtTenNV.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();
            txtMK.Clear();
            rdNam.Checked = false;
            rdNu.Checked = false;
        }

        // ------------------ LOAD DỮ LIỆU ------------------
        private void LoadData()
        {
            var list = db.NhanVien
                .Select(x => new
                {
                    x.MaNhanVien,
                    x.TenNhanVien,
                    x.SoDienThoai,
                    x.DiaChi,
                    x.GioiTinh,
                    x.MatKhau
                })
                .ToList();

            dgvNV.DataSource = list;
        }

        // ------------------ ĐĂNG KÝ (THÊM) ------------------
        private void btnDK_Click(object sender, EventArgs e)
        {
            if (currentAction == "")
            {
                currentAction = "THEM";
                SetControlState(true);
                ClearInput();
                
                btnXoa.Enabled = false;
                btnHuy.Enabled = true;
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMaNV.Text))
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên!");
                return;
            }

            try
            {
                if (db.NhanVien.Any(x => x.MaNhanVien == txtMaNV.Text.Trim()))
                {
                    MessageBox.Show("Mã nhân viên đã tồn tại!");
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

                var nv = new NhanVien
                {
                    MaNhanVien = txtMaNV.Text.Trim(),
                    TenNhanVien = txtTenNV.Text.Trim(),
                    SoDienThoai = soDienThoai,
                    DiaChi = txtDiaChi.Text.Trim(),
                    GioiTinh = rdNam.Checked ? "Nam" : "Nữ",
                    MatKhau = txtMK.Text.Trim()
                };

                db.NhanVien.Add(nv);
                db.SaveChanges();

                MessageBox.Show("Thêm nhân viên thành công!");
                LoadData();
                ClearInput();
                ResetButtonState();
                SetControlState(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm nhân viên: " + ex.Message);
            }
        }


        // ------------------ XÓA ------------------
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (currentAction == "")
            {
                currentAction = "XOA";
                btnDK.Enabled = false;
                
                btnHuy.Enabled = true;
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMaNV.Text))
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa!");
                return;
            }

            var confirm = MessageBox.Show("Bạn có chắc muốn xóa nhân viên này?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.No) return;

            try
            {
                var nv = db.NhanVien.FirstOrDefault(x => x.MaNhanVien == txtMaNV.Text.Trim());
                if (nv == null)
                {
                    MessageBox.Show("Không tìm thấy nhân viên cần xóa!");
                    return;
                }

                db.NhanVien.Remove(nv);
                db.SaveChanges();

                MessageBox.Show("Xóa nhân viên thành công!");
                LoadData();
                ClearInput();
                ResetButtonState();
                SetControlState(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa nhân viên: " + ex.Message);
            }
        }

        // ------------------ HỦY ------------------
        private void btnHuy_Click(object sender, EventArgs e)
        {
            ClearInput();
            SetControlState(false);
            ResetButtonState();
        }

        // ------------------ CLICK TRONG DATAGRIDVIEW ------------------
        private void dgvNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvNV.Rows[e.RowIndex];
                txtMaNV.Text = row.Cells["MaNhanVien"].Value?.ToString();
                txtTenNV.Text = row.Cells["TenNhanVien"].Value?.ToString();
                txtSDT.Text = row.Cells["SoDienThoai"].Value?.ToString();
                txtDiaChi.Text = row.Cells["DiaChi"].Value?.ToString();
                txtMK.Text = row.Cells["MatKhau"].Value?.ToString();

                string gioiTinh = row.Cells["GioiTinh"].Value?.ToString();
                rdNam.Checked = (gioiTinh == "Nam");
                rdNu.Checked = (gioiTinh == "Nữ");
            }
        }

        // ------------------ TÌM KIẾM REALTIME ------------------
        private void txtTimKiemNV_TextChanged(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiemNV.Text.Trim();
            var query = db.NhanVien.AsQueryable();

            if (!string.IsNullOrEmpty(tuKhoa))
            {
                if (rdoMaNV.Checked)
                    query = query.Where(x => x.MaNhanVien.Contains(tuKhoa));
                else if (rdoTenNV.Checked)
                    query = query.Where(x => x.TenNhanVien.Contains(tuKhoa));
                else if (rdoGioiTinh.Checked)
                    query = query.Where(x => x.GioiTinh.Contains(tuKhoa));
            }

            var list = query
                .Select(x => new
                {
                    x.MaNhanVien,
                    x.TenNhanVien,
                    x.SoDienThoai,
                    x.DiaChi,
                    x.GioiTinh,
                    x.MatKhau
                })
                .ToList();

            dgvNV.DataSource = list;
        }

        // ------------------ THOÁT ------------------
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //done
    }
}
