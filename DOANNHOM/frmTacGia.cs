using System;
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
        private string currentAction = ""; // "add", "edit", "delete"

        public frmTacGia()
        {
            InitializeComponent();
        }

        private void frmTacGia_Load(object sender, EventArgs e)
        {
            LoadData();

            // Sự kiện
            dgvTG.CellClick += dgvTG_CellClick;
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;

            SetEditingMode(false); // Ban đầu khóa nhập
            btnLuu.Enabled = false;
        }

        // ====== LOAD DỮ LIỆU ======
        private void LoadData()
        {
            var data = db.TacGia
                         .Select(tg => new
                         {
                             tg.MaTacGia,
                             TenTacGia = tg.TacGia1,
                             tg.GhiChu
                         })
                         .ToList();

            dgvTG.DataSource = data;
            dgvTG.Columns["MaTacGia"].HeaderText = "Mã Tác Giả";
            dgvTG.Columns["TenTacGia"].HeaderText = "Tên Tác Giả";
            dgvTG.Columns["GhiChu"].HeaderText = "Ghi Chú";

            dgvTG.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTG.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTG.MultiSelect = false;

            ClearTextBoxes();
        }

        // ====== HÀM DỌN Ô NHẬP ======
        private void ClearTextBoxes()
        {
            txtMaTG.Clear();
            txtTenTG.Clear();
            txtGhiChu.Clear();
            txtMaTG.Enabled = true;
            selectedTacGia = null;
        }

        // ====== KHÓA / MỞ Ô NHẬP ======
        private void SetEditingMode(bool enabled)
        {
            txtMaTG.Enabled = enabled;
            txtTenTG.Enabled = enabled;
            txtGhiChu.Enabled = enabled;
        }

        // ===== BẬT / TẮT CÁC NÚT CHỨC NĂNG =====
        private void SetButtonsEnabled(bool enabled)
        {
            btnThem.Enabled = enabled;
            btnSua.Enabled = enabled;
            btnXoa.Enabled = enabled;
        }

        // ====== CLICK DÒNG TRONG DGV ======
        private void dgvTG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
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

        // ====== NÚT THÊM ======
        private void btnThem_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
            SetEditingMode(true);
            currentAction = "add";
            btnLuu.Enabled = true;
            txtMaTG.Focus();

            // VÔ HIỆU HÓA CÁC NÚT KHÁC
            SetButtonsEnabled(false);
        }

        // ====== NÚT SỬA ======
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (selectedTacGia == null)
            {
                MessageBox.Show("Vui lòng chọn tác giả cần sửa!", "Thông báo");
                return;
            }

            SetEditingMode(true);
            txtMaTG.Enabled = false; // Không cho sửa mã
            currentAction = "edit";
            btnLuu.Enabled = true;

            // VÔ HIỆU HÓA CÁC NÚT KHÁC
            SetButtonsEnabled(false);
        }

        // ====== NÚT XÓA ======
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (selectedTacGia == null)
            {
                MessageBox.Show("Vui lòng chọn tác giả cần xóa!", "Thông báo");
                return;
            }

            SetEditingMode(false);
            currentAction = "delete";
            btnLuu.Enabled = true;

            // VÔ HIỆU HÓA CÁC NÚT KHÁC
            SetButtonsEnabled(false);
        }

        // ====== TÌM KIẾM ======
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim().ToLower();

            var result = db.TacGia
                .Where(t =>
                    t.MaTacGia.ToLower().Contains(keyword) ||
                    t.TacGia1.ToLower().Contains(keyword) ||
                    (t.GhiChu ?? "").ToLower().Contains(keyword))
                .Select(t => new
                {
                    t.MaTacGia,
                    TenTacGia = t.TacGia1,
                    t.GhiChu
                })
                .ToList();

            dgvTG.DataSource = result;
        }

        // ====== TRỞ VỀ ======
        private void btnTroVe_Click(object sender, EventArgs e)
        {
            frmQuanLySach frm = new frmQuanLySach();
            frm.Show();
            Hide();
        }

        // ====== NÚT LƯU ======

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentAction == "add")
                {
                    if (string.IsNullOrWhiteSpace(txtMaTG.Text) || string.IsNullOrWhiteSpace(txtTenTG.Text))
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo");
                        return;
                    }

                    if (db.TacGia.Any(x => x.MaTacGia == txtMaTG.Text.Trim()))
                    {
                        MessageBox.Show("Mã tác giả đã tồn tại!", "Cảnh báo");
                        return;
                    }

                    var tg = new TacGia
                    {
                        MaTacGia = txtMaTG.Text.Trim(),
                        TacGia1 = txtTenTG.Text.Trim(),
                        GhiChu = txtGhiChu.Text.Trim()
                    };

                    db.TacGia.Add(tg);
                    db.SaveChanges();
                    MessageBox.Show("Thêm tác giả thành công!", "Thông báo");
                }
                else if (currentAction == "edit")
                {
                    if (selectedTacGia == null)
                    {
                        MessageBox.Show("Chưa chọn tác giả để sửa!", "Thông báo");
                        return;
                    }

                    selectedTacGia.TacGia1 = txtTenTG.Text.Trim();
                    selectedTacGia.GhiChu = txtGhiChu.Text.Trim();
                    db.Entry(selectedTacGia).State = EntityState.Modified;
                    db.SaveChanges();
                    MessageBox.Show("Cập nhật thành công!", "Thông báo");
                }
                else if (currentAction == "delete")
                {
                    if (selectedTacGia == null)
                    {
                        MessageBox.Show("Chưa chọn tác giả để xóa!", "Thông báo");
                        return;
                    }

                    if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?",
                        "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        db.TacGia.Remove(selectedTacGia);
                        db.SaveChanges();
                        MessageBox.Show("Xóa thành công!", "Thông báo");
                    }
                    else
                    {
                        // User chọn No - hủy thao tác và BẬT LẠI CÁC NÚT
                        currentAction = "";
                        SetEditingMode(false);
                        btnLuu.Enabled = false;
                        SetButtonsEnabled(true); // ← BẬT LẠI CÁC NÚT
                        return;
                    }
                }

                // Làm mới sau khi lưu thành công
                currentAction = "";
                LoadData();
                SetEditingMode(false);
                btnLuu.Enabled = false;

                // BẬT LẠI CÁC NÚT THÊM/SỬA/XÓA
                SetButtonsEnabled(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu: " + ex.Message, "Lỗi");
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}