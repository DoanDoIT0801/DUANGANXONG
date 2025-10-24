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
        private LoaiSach selectedLoai;
        private string currentAction = "";

        public frmLoaiSach()
        {
            InitializeComponent();
        }

        private void frmLoaiSach_Load(object sender, EventArgs e)
        {
            LoadData();
            dgvLS.CellClick += dgvLS_CellClick_2;
            txtTimKiem.TextChanged += txtTimKiem_TextChanged_1;

            SetInputEnabled(false);
            btnLuu.Enabled = false;
        }

        // ===== LOAD DỮ LIỆU =====
        private void LoadData()
        {
            var data = db.LoaiSach
                .Select(ls => new { ls.MaLoai, ls.TenLoaiSach, ls.GhiChu })
                .ToList();

            dgvLS.DataSource = data;

            dgvLS.Columns["MaLoai"].HeaderText = "Mã Loại";
            dgvLS.Columns["TenLoaiSach"].HeaderText = "Tên Loại Sách";
            dgvLS.Columns["GhiChu"].HeaderText = "Ghi Chú";

            dgvLS.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLS.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLS.MultiSelect = false;
            dgvLS.ReadOnly = true;

            ClearTextBoxes();
        }

        // ===== BẬT / TẮT Ô NHẬP =====
        private void SetInputEnabled(bool enabled)
        {
            txtMaLoai.Enabled = enabled;
            txtLoaiSach.Enabled = enabled;
            txtGhiChu.Enabled = enabled;
        }

        // ===== BẬT / TẮT CÁC NÚT CHỨC NĂNG =====
        private void SetButtonsEnabled(bool enabled)
        {
            btnThem.Enabled = enabled;
            btnSua.Enabled = enabled;
            btnXoa.Enabled = enabled;
        }

        // ===== XÓA TRẮNG Ô NHẬP =====
        private void ClearTextBoxes()
        {
            txtMaLoai.Clear();
            txtLoaiSach.Clear();
            txtGhiChu.Clear();
        }


        private void btnSua_Click(object sender, EventArgs e)
        {
            if (selectedLoai == null)
            {
                MessageBox.Show("Vui lòng chọn loại sách cần sửa!", "Thông báo");
                return;
            }

            SetInputEnabled(true);
            txtMaLoai.Enabled = false; // Không cho sửa mã
            currentAction = "edit";
            btnLuu.Enabled = true;

            // VÔ HIỆU HÓA CÁC NÚT KHÁC
            SetButtonsEnabled(false);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (selectedLoai == null)
            {
                MessageBox.Show("Vui lòng chọn loại sách cần xóa!", "Thông báo");
                return;
            }

            SetInputEnabled(false);
            currentAction = "delete";
            btnLuu.Enabled = true;

            // VÔ HIỆU HÓA CÁC NÚT KHÁC
            SetButtonsEnabled(false);
        }

        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (currentAction == "add")
                {
                    if (string.IsNullOrWhiteSpace(txtMaLoai.Text) || string.IsNullOrWhiteSpace(txtLoaiSach.Text))
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ Mã loại và Tên loại sách!", "Thông báo");
                        return;
                    }

                    if (db.LoaiSach.Any(x => x.MaLoai == txtMaLoai.Text.Trim()))
                    {
                        MessageBox.Show("Mã loại đã tồn tại!", "Cảnh báo");
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
                    MessageBox.Show("Thêm loại sách thành công!", "Thông báo");
                }
                else if (currentAction == "edit")
                {
                    if (selectedLoai == null)
                    {
                        MessageBox.Show("Vui lòng chọn loại sách để sửa!", "Thông báo");
                        return;
                    }

                    selectedLoai.TenLoaiSach = txtLoaiSach.Text.Trim();
                    selectedLoai.GhiChu = txtGhiChu.Text.Trim();

                    db.SaveChanges();
                    MessageBox.Show("Cập nhật loại sách thành công!", "Thông báo");
                }
                else if (currentAction == "delete")
                {
                    if (selectedLoai == null)
                    {
                        MessageBox.Show("Vui lòng chọn loại sách cần xóa!", "Thông báo");
                        return;
                    }

                    if (MessageBox.Show("Bạn có chắc muốn xóa loại sách này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        db.LoaiSach.Remove(selectedLoai);
                        db.SaveChanges();
                        MessageBox.Show("Xóa loại sách thành công!", "Thông báo");
                    }
                    else
                    {
                        // User chọn No - hủy thao tác và BẬT LẠI CÁC NÚT
                        currentAction = "";
                        SetInputEnabled(false);
                        btnLuu.Enabled = false;
                        SetButtonsEnabled(true); // ← BẬT LẠI CÁC NÚT
                        return;
                    }
                }

                // Reset trạng thái sau khi lưu thành công
                currentAction = "";
                SetInputEnabled(false);
                ClearTextBoxes();
                LoadData();
                btnLuu.Enabled = false;
                selectedLoai = null;

                // BẬT LẠI CÁC NÚT THÊM/SỬA/XÓA
                SetButtonsEnabled(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu: " + ex.Message, "Lỗi");
            }
        }

        private void btnTroVe_Click_2(object sender, EventArgs e)
        {
            frmQuanLySach frm = new frmQuanLySach();
            frm.Show();
            Hide();
        }

        private void txtTimKiem_TextChanged_1(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim().ToLower();
            var result = db.LoaiSach
                .Where(ls =>
                    ls.MaLoai.ToLower().Contains(keyword) ||
                    ls.TenLoaiSach.ToLower().Contains(keyword) ||
                    (ls.GhiChu ?? "").ToLower().Contains(keyword))
                .Select(ls => new { ls.MaLoai, ls.TenLoaiSach, ls.GhiChu })
                .ToList();

            dgvLS.DataSource = result;
        }

        private void dgvLS_CellClick_2(object sender, DataGridViewCellEventArgs e)
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

        private void btnThem_Click(object sender, EventArgs e)
        {

            ClearTextBoxes();
            SetInputEnabled(true);
            txtMaLoai.Enabled = true;

            currentAction = "add";
            btnLuu.Enabled = true;

            // VÔ HIỆU HÓA CÁC NÚT KHÁC
            SetButtonsEnabled(false);
        }
    }
}


