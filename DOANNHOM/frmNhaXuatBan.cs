using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using DOANNHOM.data;

namespace DOANNHOM
{
    public partial class frmNhaXuatBan : Form
    {
        private QuanLyThuVien db = new QuanLyThuVien();
        private NhaXuatBan selectedNXB;
        private List<NhaXuatBan> danhSachGoc;
        public frmNhaXuatBan()
        {
            InitializeComponent();
            this.Load += frmNhaXuatBan_Load;
        }

        private void frmNhaXuatBan_Load(object sender, EventArgs e)
        {
            LoadData();

            dgvNXB.CellClick += dgvNXB_CellClick;
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;
        }

        // ===== LOAD DỮ LIỆU =====
        private void LoadData()
        {
            try
            {
                dgvNXB.AutoGenerateColumns = true;
                danhSachGoc = db.NhaXuatBan.ToList();

                dgvNXB.DataSource = danhSachGoc
                    .Select(x => new
                    {
                        x.MaXB,
                        x.NhaXuatBan1,
                        x.GhiChu
                    }).ToList();

                dgvNXB.Columns["MaXB"].HeaderText = "Mã NXB";
                dgvNXB.Columns["NhaXuatBan1"].HeaderText = "Nhà Xuất Bản";
                dgvNXB.Columns["GhiChu"].HeaderText = "Ghi Chú";

                dgvNXB.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvNXB.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvNXB.AllowUserToAddRows = false;
                dgvNXB.ReadOnly = true;

                ClearTextBoxes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        // ===== XÓA TRẮNG Ô NHẬP =====
        private void ClearTextBoxes()
        {
            txtMaNXB.Clear();
            txtNXB.Clear();
            txtGhiChu.Clear();
            selectedNXB = null;
            txtMaNXB.Enabled = true;
            txtMaNXB.Focus();
        }

        // ===== THÊM =====
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMaNXB.Text) ||
                    string.IsNullOrWhiteSpace(txtNXB.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ Mã NXB và Tên Nhà Xuất Bản!", "Thông báo");
                    return;
                }

                string ma = txtMaNXB.Text.Trim();
                if (db.NhaXuatBan.Any(x => x.MaXB == ma))
                {
                    MessageBox.Show("Mã NXB đã tồn tại!", "Cảnh báo");
                    return;
                }

                var nxb = new NhaXuatBan
                {
                    MaXB = ma,
                    NhaXuatBan1 = txtNXB.Text.Trim(),
                    GhiChu = txtGhiChu.Text.Trim()
                };

                db.NhaXuatBan.Add(nxb);
                db.SaveChanges();

                MessageBox.Show("Thêm NXB thành công!");
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
                if (selectedNXB == null)
                {
                    MessageBox.Show("Vui lòng chọn NXB cần sửa!");
                    return;
                }

                selectedNXB.NhaXuatBan1 = txtNXB.Text.Trim();
                selectedNXB.GhiChu = txtGhiChu.Text.Trim();

                db.Entry(selectedNXB).State = EntityState.Modified;
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
                if (selectedNXB == null)
                {
                    MessageBox.Show("Vui lòng chọn NXB cần xóa!");
                    return;
                }

                if (MessageBox.Show("Bạn có chắc muốn xóa NXB này không?",
                    "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    db.NhaXuatBan.Remove(selectedNXB);
                    db.SaveChanges();
                    MessageBox.Show("Xóa thành công!");
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể xóa do ràng buộc dữ liệu!\n" + ex.Message);
            }
        }

        // ===== CLICK DÒNG TRONG DATAGRID =====
        private void dgvNXB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvNXB.Rows[e.RowIndex].Cells["MaXB"].Value != null)
            {
                string ma = dgvNXB.Rows[e.RowIndex].Cells["MaXB"].Value.ToString();
                selectedNXB = db.NhaXuatBan.FirstOrDefault(x => x.MaXB == ma);

                if (selectedNXB != null)
                {
                    txtMaNXB.Text = selectedNXB.MaXB;
                    txtNXB.Text = selectedNXB.NhaXuatBan1;
                    txtGhiChu.Text = selectedNXB.GhiChu;
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
                    : danhSachGoc.Where(x =>
                          (x.MaXB != null && x.MaXB.ToLower().Contains(keyword)) ||
                          (x.NhaXuatBan1 != null && x.NhaXuatBan1.ToLower().Contains(keyword)) ||
                          (x.GhiChu != null && x.GhiChu.ToLower().Contains(keyword))
                      ).ToList();

                dgvNXB.DataSource = ketQua
                    .Select(x => new
                    {
                        x.MaXB,
                        x.NhaXuatBan1,
                        x.GhiChu
                    }).ToList();

                dgvNXB.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
        }

        // ===== THOÁT =====
        private void btnThoat_Click(object sender, EventArgs e)
        {
            frmQuanLySach frm = new frmQuanLySach();
            frm.Show();
            Hide();
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            frmQuanLySach frm = new frmQuanLySach();
            frm.Show();
            Hide();
        }
    }
}
