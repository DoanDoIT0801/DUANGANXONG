using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using DOANNHOM.data;

namespace DOANNHOM
{
    public partial class frmTacGia : Form
    {
        private QuanLyThuVien db = new QuanLyThuVien();
        private TacGia selectedTacGia;
        private List<TacGia> danhSachGoc;

        public frmTacGia()
        {
            InitializeComponent();
            this.Load += frmTacGia_Load;
        }

        private void frmTacGia_Load(object sender, EventArgs e)
        {
            LoadData();

            dgvTG.CellClick += dgvTG_CellClick;
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;
        }

        // ===== LOAD DỮ LIỆU =====
        private void LoadData()
        {
            try
            {
                dgvTG.AutoGenerateColumns = true;

                danhSachGoc = db.TacGia.ToList();

                dgvTG.DataSource = danhSachGoc
                    .Select(t => new
                    {
                        t.MaTacGia,
                        t.TacGia1,
                        t.GhiChu
                    }).ToList();

                dgvTG.Columns["MaTacGia"].HeaderText = "Mã Tác Giả";
                dgvTG.Columns["TacGia1"].HeaderText = "Tên Tác Giả";
                dgvTG.Columns["GhiChu"].HeaderText = "Ghi Chú";

                dgvTG.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvTG.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvTG.AllowUserToAddRows = false;
                dgvTG.ReadOnly = true;

                dgvTG.ClearSelection();
                ClearTextBoxes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi");
            }
        }

        // ===== XÓA TRẮNG Ô NHẬP =====
        private void ClearTextBoxes()
        {
            txtMaTG.Clear();
            txtTenTG.Clear();
            txtGhiChu.Clear();
            selectedTacGia = null;
            txtMaTG.Enabled = true;
            txtMaTG.Focus();
        }

        // ===== THÊM =====
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMaTG.Text) ||
                    string.IsNullOrWhiteSpace(txtTenTG.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ Mã và Tên tác giả!", "Thông báo");
                    return;
                }

                string ma = txtMaTG.Text.Trim();

                if (db.TacGia.Any(t => t.MaTacGia == ma))
                {
                    MessageBox.Show("Mã tác giả đã tồn tại!", "Cảnh báo");
                    return;
                }

                var tg = new TacGia
                {
                    MaTacGia = ma,
                    TacGia1 = txtTenTG.Text.Trim(),
                    GhiChu = txtGhiChu.Text.Trim()
                };

                db.TacGia.Add(tg);
                db.SaveChanges();
                MessageBox.Show("Thêm tác giả thành công!");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm: " + ex.Message);
            }
        }

        // ===== SỬA =====
        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedTacGia == null)
                {
                    MessageBox.Show("Vui lòng chọn tác giả cần sửa!");
                    return;
                }

                selectedTacGia.TacGia1 = txtTenTG.Text.Trim();
                selectedTacGia.GhiChu = txtGhiChu.Text.Trim();

                db.Entry(selectedTacGia).State = EntityState.Modified;
                db.SaveChanges();

                MessageBox.Show("Cập nhật thành công!");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sửa: " + ex.Message);
            }
        }

        // ===== XÓA =====
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedTacGia == null)
                {
                    MessageBox.Show("Vui lòng chọn tác giả cần xóa!");
                    return;
                }

                if (MessageBox.Show("Bạn có chắc muốn xóa tác giả này không?",
                    "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    db.TacGia.Remove(selectedTacGia);
                    db.SaveChanges();

                    MessageBox.Show("Xóa thành công!");
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa: " + ex.Message);
            }
        }

        // ===== CLICK DÒNG TRONG DATAGRID =====
        private void dgvTG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvTG.Rows[e.RowIndex].Cells["MaTacGia"].Value != null)
            {
                string ma = dgvTG.Rows[e.RowIndex].Cells["MaTacGia"].Value.ToString();
                selectedTacGia = db.TacGia.FirstOrDefault(x => x.MaTacGia == ma);

                if (selectedTacGia != null)
                {
                    txtMaTG.Text = selectedTacGia.MaTacGia;
                    txtTenTG.Text = selectedTacGia.TacGia1;
                    txtGhiChu.Text = selectedTacGia.GhiChu;
                }
            }
        }

        // ===== TÌM KIẾM REALTIME =====
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtTimKiem.Text.Trim().ToLower();

                var ketQua = string.IsNullOrWhiteSpace(keyword)
                    ? danhSachGoc
                    : danhSachGoc.Where(t =>
                          (t.MaTacGia != null && t.MaTacGia.ToLower().Contains(keyword)) ||
                          (t.TacGia1 != null && t.TacGia1.ToLower().Contains(keyword)) ||
                          (t.GhiChu != null && t.GhiChu.ToLower().Contains(keyword))
                      ).ToList();

                dgvTG.DataSource = ketQua
                    .Select(t => new
                    {
                        t.MaTacGia,
                        t.TacGia1,
                        t.GhiChu
                    }).ToList();

                dgvTG.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            frmQuanLySach frm = new frmQuanLySach();
            frm.Show();
            Hide();
        }
    }
}
