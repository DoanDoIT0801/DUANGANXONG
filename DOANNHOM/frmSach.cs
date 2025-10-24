using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DOANNHOM.data;

namespace DOANNHOM
{
    public partial class frmSach : Form
    {
        private QuanLyThuVien db = new QuanLyThuVien();
        private Sach selectedSach;
        private string currentAction = "";

        public frmSach()
        {
            InitializeComponent();
        }

        private void frmSach_Load(object sender, EventArgs e)
        {
            LoadData();
            dgvSach.CellClick += dgvSach_CellClick;
            txtTK.TextChanged += txtTK_TextChanged;

            SetInputEnabled(false);
            btnLuu.Enabled = false;
        }

        // ===== LOAD DỮ LIỆU =====
        private void LoadData()
        {
            var data = db.Sach
                .Select(s => new
                {
                    s.MaSach,
                    s.TenSach,
                    s.MaTacGia,
                    s.MaXB,
                    s.MaLoai,
                    s.SoTrang,
                    s.GiaBan,
                    s.SoLuong
                })
                .ToList();

            dgvSach.DataSource = data;

            dgvSach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSach.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSach.MultiSelect = false;
            dgvSach.ReadOnly = true;

            ClearInputs();
        }

        // ===== BẬT / TẮT Ô NHẬP =====
        private void SetInputEnabled(bool enabled)
        {
            txtMaSach1.Enabled = enabled;
            txtTenSach1.Enabled = enabled;
            txtMaTacGia1.Enabled = enabled;
            txtMaNXB1.Enabled = enabled;
            txtMaLoai.Enabled = enabled;
            txtSoTrang.Enabled = enabled;
            txtGiaBan.Enabled = enabled;
            txtSoLuong.Enabled = enabled;
        }

        // ===== BẬT / TẮT CÁC NÚT CHỨC NĂNG =====
        private void SetButtonsEnabled(bool enabled)
        {
            btnThem.Enabled = enabled;
            btnSua.Enabled = enabled;
            btnXoa.Enabled = enabled;
        }

        // ===== XÓA TRẮNG Ô NHẬP =====
        private void ClearInputs()
        {
            txtMaSach1.Clear();
            txtTenSach1.Clear();
            txtMaTacGia1.Clear();
            txtMaNXB1.Clear();
            txtMaLoai.Clear();
            txtSoTrang.Clear();
            txtGiaBan.Clear();
            txtSoLuong.Clear();
        }

        // ===== CLICK DÒNG TRONG DATAGRID =====
        private void dgvSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string ma = dgvSach.Rows[e.RowIndex].Cells["MaSach"].Value.ToString();
                selectedSach = db.Sach.FirstOrDefault(x => x.MaSach == ma);

                if (selectedSach != null)
                {
                    txtMaSach1.Text = selectedSach.MaSach;
                    txtTenSach1.Text = selectedSach.TenSach;
                    txtMaTacGia1.Text = selectedSach.MaTacGia;
                    txtMaNXB1.Text = selectedSach.MaXB;
                    txtMaLoai.Text = selectedSach.MaLoai;
                    txtSoTrang.Text = selectedSach.SoTrang.ToString();
                    txtGiaBan.Text = selectedSach.GiaBan.ToString();
                    txtSoLuong.Text = selectedSach.SoLuong.ToString();
                }
            }
        }

        // ===== TÌM KIẾM REALTIME =====
        private void txtTK_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTK.Text.Trim().ToLower();
            var result = db.Sach
                .Where(s =>
                    s.MaSach.ToLower().Contains(keyword) ||
                    s.TenSach.ToLower().Contains(keyword) ||
                    s.MaTacGia.ToLower().Contains(keyword) ||
                    s.MaXB.ToLower().Contains(keyword) ||
                    s.MaLoai.ToLower().Contains(keyword))
                .Select(s => new
                {
                    s.MaSach,
                    s.TenSach,
                    s.MaTacGia,
                    s.MaXB,
                    s.MaLoai,
                    s.SoTrang,
                    s.GiaBan,
                    s.SoLuong
                })
                .ToList();

            dgvSach.DataSource = result;
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
            ClearInputs();
            SetInputEnabled(true);
            txtMaSach1.Enabled = true;

            currentAction = "add";
            btnLuu.Enabled = true;

            // VÔ HIỆU HÓA CÁC NÚT KHÁC
            SetButtonsEnabled(false);
        }

        // ===== NÚT SỬA =====
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (selectedSach == null)
            {
                MessageBox.Show("Vui lòng chọn sách cần sửa!", "Thông báo");
                return;
            }

            SetInputEnabled(true);
            txtMaSach1.Enabled = false;
            currentAction = "edit";
            btnLuu.Enabled = true;

            // VÔ HIỆU HÓA CÁC NÚT KHÁC
            SetButtonsEnabled(false);
        }

        // ===== NÚT XÓA =====
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (selectedSach == null)
            {
                MessageBox.Show("Vui lòng chọn sách cần xóa!", "Thông báo");
                return;
            }

            SetInputEnabled(false);
            currentAction = "delete";
            btnLuu.Enabled = true;

            // VÔ HIỆU HÓA CÁC NÚT KHÁC
            SetButtonsEnabled(false);
        }
       

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentAction == "add")
                {
                    // KIỂM TRA CÁC TRƯỜNG BẮT BUỘC
                    if (string.IsNullOrWhiteSpace(txtMaSach1.Text))
                    {
                        MessageBox.Show("Vui lòng nhập mã sách!", "Thông báo");
                        txtMaSach1.Focus();
                        return;
                    }

                    if (string.IsNullOrWhiteSpace(txtTenSach1.Text))
                    {
                        MessageBox.Show("Vui lòng nhập tên sách!", "Thông báo");
                        txtTenSach1.Focus();
                        return;
                    }

                    if (string.IsNullOrWhiteSpace(txtMaTacGia1.Text))
                    {
                        MessageBox.Show("Vui lòng nhập mã tác giả!", "Thông báo");
                        txtMaTacGia1.Focus();
                        return;
                    }

                    if (string.IsNullOrWhiteSpace(txtMaNXB1.Text))
                    {
                        MessageBox.Show("Vui lòng nhập mã nhà xuất bản!", "Thông báo");
                        txtMaNXB1.Focus();
                        return;
                    }

                    if (string.IsNullOrWhiteSpace(txtMaLoai.Text))
                    {
                        MessageBox.Show("Vui lòng nhập mã loại sách!", "Thông báo");
                        txtMaLoai.Focus();
                        return;
                    }

                    // Kiểm tra mã sách đã tồn tại chưa
                    if (db.Sach.Any(x => x.MaSach == txtMaSach1.Text.Trim()))
                    {
                        MessageBox.Show("Mã sách đã tồn tại!", "Cảnh báo");
                        txtMaSach1.Focus();
                        return;
                    }

                    // TỰ ĐỘNG TẠO TÁC GIẢ NẾU CHƯA CÓ
                    string maTacGia = txtMaTacGia1.Text.Trim();
                    var tacGia = db.TacGia.Find(maTacGia);
                    if (tacGia == null)
                    {
                        var newTacGia = new TacGia
                        {
                            MaTacGia = maTacGia,
                            TacGia1 = maTacGia,
                            GhiChu = "Tự động tạo"
                        };
                        db.TacGia.Add(newTacGia);
                        db.SaveChanges();
                    }

                    // TỰ ĐỘNG TẠO NHÀ XUẤT BẢN NẾU CHƯA CÓ
                    string maNXB = txtMaNXB1.Text.Trim();
                    var nxb = db.NhaXuatBan.Find(maNXB);
                    if (nxb == null)
                    {
                        var newNXB = new NhaXuatBan
                        {
                            MaXB = maNXB,
                            NhaXuatBan1 = maNXB,
                        };
                        db.NhaXuatBan.Add(newNXB);
                        db.SaveChanges();
                    }

                    // TỰ ĐỘNG TẠO LOẠI SÁCH NẾU CHƯA CÓ
                    string maLoai = txtMaLoai.Text.Trim();
                    var loai = db.LoaiSach.Find(maLoai);
                    if (loai == null)
                    {
                        var newLoai = new LoaiSach
                        {
                            MaLoai = maLoai,
                            TenLoaiSach = maLoai,
                            GhiChu = "Tự động tạo"
                        };
                        db.LoaiSach.Add(newLoai);
                        db.SaveChanges();
                    }

                    // Chuyển đổi số
                    int.TryParse(txtSoTrang.Text, out int soTrang);
                    int.TryParse(txtGiaBan.Text, out int giaBan);
                    int.TryParse(txtSoLuong.Text, out int soLuong);

                    // Tạo sách mới
                    var newSach = new Sach
                    {
                        MaSach = txtMaSach1.Text.Trim(),
                        TenSach = txtTenSach1.Text.Trim(),
                        MaTacGia = maTacGia,
                        MaXB = maNXB,
                        MaLoai = maLoai,
                        SoTrang = soTrang,
                        GiaBan = giaBan,
                        SoLuong = soLuong
                    };

                    db.Sach.Add(newSach);
                    db.SaveChanges();
                    MessageBox.Show("Thêm sách thành công!", "Thành công");
                }
                else if (currentAction == "edit")
                {
                    if (selectedSach == null)
                    {
                        MessageBox.Show("Vui lòng chọn sách để sửa!", "Thông báo");
                        return;
                    }

                    // Kiểm tra các trường bắt buộc
                    if (string.IsNullOrWhiteSpace(txtTenSach1.Text))
                    {
                        MessageBox.Show("Vui lòng nhập tên sách!", "Thông báo");
                        txtTenSach1.Focus();
                        return;
                    }

                    if (string.IsNullOrWhiteSpace(txtMaTacGia1.Text))
                    {
                        MessageBox.Show("Vui lòng nhập mã tác giả!", "Thông báo");
                        txtMaTacGia1.Focus();
                        return;
                    }

                    if (string.IsNullOrWhiteSpace(txtMaNXB1.Text))
                    {
                        MessageBox.Show("Vui lòng nhập mã nhà xuất bản!", "Thông báo");
                        txtMaNXB1.Focus();
                        return;
                    }

                    if (string.IsNullOrWhiteSpace(txtMaLoai.Text))
                    {
                        MessageBox.Show("Vui lòng nhập mã loại sách!", "Thông báo");
                        txtMaLoai.Focus();
                        return;
                    }

                    // TỰ ĐỘNG TẠO TÁC GIẢ NẾU CHƯA CÓ (khi sửa)
                    string maTacGia = txtMaTacGia1.Text.Trim();
                    var tacGia = db.TacGia.Find(maTacGia);
                    if (tacGia == null)
                    {
                        var newTacGia = new TacGia
                        {
                            MaTacGia = maTacGia,
                            TacGia1 = maTacGia,
                            GhiChu = "Tự động tạo"
                        };
                        db.TacGia.Add(newTacGia);
                        db.SaveChanges();
                    }

                    // TỰ ĐỘNG TẠO NXB NẾU CHƯA CÓ (khi sửa)
                    string maNXB = txtMaNXB1.Text.Trim();
                    var nxb = db.NhaXuatBan.Find(maNXB);
                    if (nxb == null)
                    {
                        var newNXB = new NhaXuatBan
                        {
                            MaXB = maNXB,
                            NhaXuatBan1 = maNXB,
                        };
                        db.NhaXuatBan.Add(newNXB);
                        db.SaveChanges();
                    }

                    // TỰ ĐỘNG TẠO LOẠI SÁCH NẾU CHƯA CÓ (khi sửa)
                    string maLoai = txtMaLoai.Text.Trim();
                    var loai = db.LoaiSach.Find(maLoai);
                    if (loai == null)
                    {
                        var newLoai = new LoaiSach
                        {
                            MaLoai = maLoai,
                            TenLoaiSach = maLoai,
                            GhiChu = "Tự động tạo"
                        };
                        db.LoaiSach.Add(newLoai);
                        db.SaveChanges();
                    }

                    int.TryParse(txtSoTrang.Text, out int soTrang);
                    int.TryParse(txtGiaBan.Text, out int giaBan);
                    int.TryParse(txtSoLuong.Text, out int soLuong);

                    // Cập nhật thông tin
                    selectedSach.TenSach = txtTenSach1.Text.Trim();
                    selectedSach.MaTacGia = maTacGia;
                    selectedSach.MaXB = maNXB;
                    selectedSach.MaLoai = maLoai;
                    selectedSach.SoTrang = soTrang;
                    selectedSach.GiaBan = giaBan;
                    selectedSach.SoLuong = soLuong;

                    db.SaveChanges();
                    MessageBox.Show("Cập nhật sách thành công!", "Thông báo");
                }
                else if (currentAction == "delete")
                {
                    if (selectedSach == null)
                    {
                        MessageBox.Show("Vui lòng chọn sách cần xóa!", "Thông báo");
                        return;
                    }

                    if (MessageBox.Show("Bạn có chắc muốn xóa sách này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        db.Sach.Remove(selectedSach);
                        db.SaveChanges();
                        MessageBox.Show("Xóa sách thành công!", "Thông báo");
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
                ClearInputs();
                LoadData();
                btnLuu.Enabled = false;
                selectedSach = null;

                // BẬT LẠI CÁC NÚT THÊM/SỬA/XÓA
                SetButtonsEnabled(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + (ex.InnerException?.Message ?? ex.Message), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}