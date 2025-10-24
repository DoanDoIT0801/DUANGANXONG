using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DOANNHOM.data;

namespace DOANNHOM
{
    public partial class frmNhaXuatBan : Form
    {
        private QuanLyThuVien db = new QuanLyThuVien();
        private NhaXuatBan selectedNXB;
        private string currentAction = "";

        public frmNhaXuatBan()
        {
            InitializeComponent();
        }

        private void frmNhaXuatBan_Load(object sender, EventArgs e)
        {
            LoadData();
            dgvNXB.CellClick += dgvNXB_CellClick;
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;

            SetInputEnabled(false);
            btnLuu.Enabled = false;
        }

        // ===== LOAD DỮ LIỆU =====
        private void LoadData()
        {
            var data = db.NhaXuatBan
                .Select(nxb => new { nxb.MaXB, nxb.NhaXuatBan1, nxb.GhiChu })
                .ToList();

            dgvNXB.DataSource = data;

            dgvNXB.Columns["MaXB"].HeaderText = "Mã NXB";
            dgvNXB.Columns["NhaXuatBan1"].HeaderText = "Tên Nhà Xuất Bản";
            dgvNXB.Columns["GhiChu"].HeaderText = "Ghi Chú";

            dgvNXB.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNXB.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNXB.MultiSelect = false;
            dgvNXB.ReadOnly = true;

            ClearTextBoxes();
        }

        // ===== BẬT / TẮT Ô NHẬP =====
        private void SetInputEnabled(bool enabled)
        {
            txtMaNXB.Enabled = enabled;
            txtNXB.Enabled = enabled;
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
            txtMaNXB.Clear();
            txtNXB.Clear();
            txtGhiChu.Clear();
        }

        // ===== CLICK DÒNG TRONG DATAGRID =====
        private void dgvNXB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
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
            string keyword = txtTimKiem.Text.Trim().ToLower();
            var result = db.NhaXuatBan
                .Where(nxb =>
                    nxb.MaXB.ToLower().Contains(keyword) ||
                    nxb.NhaXuatBan1.ToLower().Contains(keyword) ||
                    (nxb.GhiChu ?? "").ToLower().Contains(keyword))
                .Select(nxb => new { nxb.MaXB, nxb.NhaXuatBan1, nxb.GhiChu })
                .ToList();

            dgvNXB.DataSource = result;
        }

        // ===== NÚT TRỞ VỀ =====
        private void btnTroVe_Click(object sender, EventArgs e)
        {
            frmQuanLySach frm = new frmQuanLySach();
            frm.Show();
            Hide();
        }

        // ===== NÚT THÊM =====
        private void btnThem_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
            SetInputEnabled(true);
            txtMaNXB.Enabled = true;

            currentAction = "add";
            btnLuu.Enabled = true;

            // VÔ HIỆU HÓA CÁC NÚT KHÁC
            SetButtonsEnabled(false);
        }

        // ===== NÚT SỬA =====
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (selectedNXB == null)
            {
                MessageBox.Show("Vui lòng chọn nhà xuất bản cần sửa!", "Thông báo");
                return;
            }

            SetInputEnabled(true);
            txtMaNXB.Enabled = false; // Không cho sửa mã
            currentAction = "edit";
            btnLuu.Enabled = true;

            // VÔ HIỆU HÓA CÁC NÚT KHÁC
            SetButtonsEnabled(false);
        }

        // ===== NÚT XÓA =====
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (selectedNXB == null)
            {
                MessageBox.Show("Vui lòng chọn nhà xuất bản cần xóa!", "Thông báo");
                return;
            }

            SetInputEnabled(false);
            currentAction = "delete";
            btnLuu.Enabled = true;

            // VÔ HIỆU HÓA CÁC NÚT KHÁC
            SetButtonsEnabled(false);
        }

        // ===== NÚT LƯU =====
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentAction == "add")
                {
                    if (string.IsNullOrWhiteSpace(txtMaNXB.Text) || string.IsNullOrWhiteSpace(txtNXB.Text))
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ Mã và Tên Nhà Xuất Bản!", "Thông báo");
                        return;
                    }

                    if (db.NhaXuatBan.Any(x => x.MaXB == txtMaNXB.Text.Trim()))
                    {
                        MessageBox.Show("Mã NXB đã tồn tại!", "Cảnh báo");
                        return;
                    }

                    var newNXB = new NhaXuatBan
                    {
                        MaXB = txtMaNXB.Text.Trim(),
                        NhaXuatBan1 = txtNXB.Text.Trim(),
                        GhiChu = txtGhiChu.Text.Trim()
                    };

                    db.NhaXuatBan.Add(newNXB);
                    db.SaveChanges();
                    MessageBox.Show("Thêm nhà xuất bản thành công!", "Thông báo");
                }
                else if (currentAction == "edit")
                {
                    if (selectedNXB == null)
                    {
                        MessageBox.Show("Vui lòng chọn nhà xuất bản để sửa!", "Thông báo");
                        return;
                    }

                    selectedNXB.NhaXuatBan1 = txtNXB.Text.Trim();
                    selectedNXB.GhiChu = txtGhiChu.Text.Trim();

                    db.SaveChanges();
                    MessageBox.Show("Cập nhật nhà xuất bản thành công!", "Thông báo");
                }
                else if (currentAction == "delete")
                {
                    if (selectedNXB == null)
                    {
                        MessageBox.Show("Vui lòng chọn nhà xuất bản cần xóa!", "Thông báo");
                        return;
                    }

                    if (MessageBox.Show("Bạn có chắc muốn xóa nhà xuất bản này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        db.NhaXuatBan.Remove(selectedNXB);
                        db.SaveChanges();
                        MessageBox.Show("Xóa nhà xuất bản thành công!", "Thông báo");
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

                // reset trạng thái
                currentAction = "";
                SetInputEnabled(false);
                ClearTextBoxes();
                LoadData();
                btnLuu.Enabled = false;
                selectedNXB = null;

                // BẬT LẠI CÁC NÚT THÊM/SỬA/XÓA
                SetButtonsEnabled(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu: " + ex.Message, "Lỗi");
            }
        }

    }
}