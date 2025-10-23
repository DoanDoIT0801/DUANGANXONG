using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using DOANNHOM.data;

namespace DOANNHOM
{
    public partial class frmLoaiSach : Form
    {
        private QuanLyThuVien db = new QuanLyThuVien();
        private LoaiSach selectedLoai; // Lưu loại sách đang chọn

        public frmLoaiSach()
        {
            InitializeComponent();
        }

        private void frmLoaiSach_Load(object sender, EventArgs e)
        {
            LoadData();
            dgvLS.CellClick += dgvLS_CellClick;
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;
        }

        // ===== LOAD DỮ LIỆU =====
        private void LoadData()
        {
            var data = db.LoaiSach
                         .Select(ls => new
                         {
                             ls.MaLoai,
                             ls.TenLoaiSach,
                             ls.GhiChu
                         })
                         .ToList();

            dgvLS.DataSource = data;

            dgvLS.Columns["MaLoai"].HeaderText = "Mã Loại";
            dgvLS.Columns["TenLoaiSach"].HeaderText = "Tên Loại Sách";
            dgvLS.Columns["GhiChu"].HeaderText = "Ghi Chú";

            dgvLS.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLS.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLS.MultiSelect = false;

            ClearTextBoxes();
        }

        // ===== XÓA TRẮNG Ô NHẬP =====
        private void ClearTextBoxes()
        {
            txtMaLoai.Clear();
            txtLoaiSach.Clear();
            txtGhiChu.Clear();

            // ✅ Giờ cho phép nhập mã loại
            txtMaLoai.Enabled = true;
            txtLoaiSach.Focus();
            selectedLoai = null;
        }

        // ===== CLICK DÒNG TRONG DATAGRID =====
        private void dgvLS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string ma = dgvLS.Rows[e.RowIndex].Cells["MaLoai"].Value.ToString();
                selectedLoai = db.LoaiSach.FirstOrDefault(x => x.MaLoai == ma);

                if (selectedLoai != null)
                {
                    txtMaLoai.Text = selectedLoai.MaLoai;
                    txtLoaiSach.Text = selectedLoai.TenLoaiSach;
                    txtGhiChu.Text = selectedLoai.GhiChu;
                }
            }
        }


        private void btnSua_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (selectedLoai == null)
                {
                    MessageBox.Show("Vui lòng chọn loại sách cần sửa!");
                    return;
                }

                string oldMa = selectedLoai.MaLoai;
                string newMa = txtMaLoai.Text.Trim();

                if (db.LoaiSach.Any(x => x.MaLoai == newMa && x.MaLoai != oldMa))
                {
                    MessageBox.Show("Mã loại mới đã tồn tại, vui lòng chọn mã khác!");
                    return;
                }

                // Tạo đối tượng mới
                var newLoai = new LoaiSach
                {
                    MaLoai = newMa,
                    TenLoaiSach = txtLoaiSach.Text.Trim(),
                    GhiChu = txtGhiChu.Text.Trim()
                };

                db.LoaiSach.Add(newLoai);
                db.LoaiSach.Remove(selectedLoai);
                db.SaveChanges();

                MessageBox.Show("Cập nhật thành công!");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa: " + ex.Message);
            }
        }
        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (selectedLoai == null)
                {
                    MessageBox.Show("Vui lòng chọn loại sách cần xóa!");
                    return;
                }

                DialogResult dr = MessageBox.Show(
                    "Bạn có chắc chắn muốn xóa loại sách này không?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    db.LoaiSach.Remove(selectedLoai);
                    db.SaveChanges();
                    MessageBox.Show("Xóa thành công!");
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể xóa do ràng buộc dữ liệu!\nChi tiết: " + ex.Message);
            }
        }

        private void btnTroVe_Click_1(object sender, EventArgs e)
        {
            frmQuanLySach frm = new frmQuanLySach();
            frm.Show();
            Hide();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim().ToLower();

            var result = db.LoaiSach
                .Where(ls =>
                    ls.MaLoai.ToLower().Contains(keyword) ||
                    ls.TenLoaiSach.ToLower().Contains(keyword) ||
                    (ls.GhiChu ?? "").ToLower().Contains(keyword))
                .Select(ls => new
                {
                    ls.MaLoai,
                    ls.TenLoaiSach,
                    ls.GhiChu
                })
                .ToList();

            dgvLS.DataSource = result;
        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMaLoai.Text) || string.IsNullOrWhiteSpace(txtLoaiSach.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ Mã Loại và Tên Loại Sách!", "Thông báo");
                    return;
                }

                // Kiểm tra trùng mã
                if (db.LoaiSach.Any(x => x.MaLoai == txtMaLoai.Text.Trim()))
                {
                    MessageBox.Show("Mã loại này đã tồn tại! Vui lòng nhập mã khác.", "Cảnh báo");
                    return;
                }

                var newLoai = new LoaiSach
                {
                    MaLoai = txtMaLoai.Text.Trim(),
                    TenLoaiSach = txtLoaiSach.Text.Trim(),
                    GhiChu = txtGhiChu.Text.Trim()
                };

                db.LoaiSach.Add(newLoai);
                db.SaveChanges();

                MessageBox.Show("Thêm loại sách thành công!");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm: " + ex.Message);
            }
        }
    }
}