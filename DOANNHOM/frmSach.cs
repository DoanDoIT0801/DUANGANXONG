using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using DOANNHOM.data;

namespace DOANNHOM
{
    public partial class frmSach : Form
    {
        private QuanLyThuVien db;
        private List<Sach> danhSachGoc;
        private Sach selectedSach;

        public frmSach()
        {
            InitializeComponent();
            db = new QuanLyThuVien();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                var newSach = new Sach
                {
                    MaSach = txtMaSach1.Text.Trim(),
                    TenSach = txtTenSach1.Text.Trim(),
                    MaTacGia = txtMaTacGia1.Text.Trim(),
                    MaXB = txtMaNXB1.Text.Trim(),
                    MaLoai = txtMaLoai.Text.Trim(),
                    SoTrang = int.Parse(txtSoTrang.Text),
                    GiaBan = int.Parse(txtGiaBan.Text),
                    SoLuong = int.Parse(txtSoLuong.Text)
                };

                if (db.Sach.Any(s => s.MaSach == newSach.MaSach))
                {
                    MessageBox.Show("Mã sách đã tồn tại!");
                    return;
                }

                db.Sach.Add(newSach);
                db.SaveChanges();

                MessageBox.Show("Thêm sách thành công!");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm sách: " + ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedSach == null)
                {
                    MessageBox.Show("Vui lòng chọn sách cần sửa!");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtTenSach1.Text) ||
                    string.IsNullOrWhiteSpace(txtMaTacGia1.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo");
                    return;
                }

                if (!db.TacGia.Any(tg => tg.MaTacGia == txtMaTacGia1.Text.Trim()))
                {
                    MessageBox.Show("Mã tác giả không tồn tại!", "Lỗi");
                    return;
                }

                if (!db.NhaXuatBan.Any(nxb => nxb.MaXB == txtMaNXB1.Text.Trim()))
                {
                    MessageBox.Show("Mã nhà xuất bản không tồn tại!", "Lỗi");
                    return;
                }

                if (!db.LoaiSach.Any(ls => ls.MaLoai == txtMaLoai.Text.Trim()))
                {
                    MessageBox.Show("Mã loại sách không tồn tại!", "Lỗi");
                    return;
                }

                var sachCanSua = db.Sach.Find(selectedSach.MaSach);

                if (sachCanSua == null)
                {
                    MessageBox.Show("Không tìm thấy sách cần sửa!");
                    return;
                }

                sachCanSua.TenSach = txtTenSach1.Text.Trim();
                sachCanSua.MaTacGia = txtMaTacGia1.Text.Trim();
                sachCanSua.MaXB = txtMaNXB1.Text.Trim();
                sachCanSua.MaLoai = txtMaLoai.Text.Trim();

                if (!int.TryParse(txtSoTrang.Text, out int soTrang) || soTrang <= 0)
                {
                    MessageBox.Show("Số trang phải là số nguyên dương!", "Lỗi");
                    return;
                }
                sachCanSua.SoTrang = soTrang;

                if (!int.TryParse(txtGiaBan.Text, out int giaBan) || giaBan < 0)
                {
                    MessageBox.Show("Giá bán phải là số không âm!", "Lỗi");
                    return;
                }
                sachCanSua.GiaBan = giaBan;

                if (!int.TryParse(txtSoLuong.Text, out int soLuong) || soLuong < 0)
                {
                    MessageBox.Show("Số lượng phải là số không âm!", "Lỗi");
                    return;
                }
                sachCanSua.SoLuong = soLuong;

                db.SaveChanges();
                MessageBox.Show("Cập nhật sách thành công!");
                LoadData();
                ClearInputs();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                string errors = "Lỗi validation:\n";
                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        errors += $"- {validationError.PropertyName}: {validationError.ErrorMessage}\n";
                    }
                }
                MessageBox.Show(errors, "Lỗi");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sửa sách: " + ex.Message + "\n\n" +
                               (ex.InnerException != null ? ex.InnerException.Message : ""), "Lỗi");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedSach == null)
                {
                    MessageBox.Show("Vui lòng chọn sách cần xóa!");
                    return;
                }

                if (MessageBox.Show("Bạn có chắc muốn xóa sách này không?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    db.Sach.Remove(selectedSach);
                    db.SaveChanges();
                    MessageBox.Show("Xóa thành công!");
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa sách: " + ex.Message);
            }
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            frmQuanLySach frm = new frmQuanLySach();
            frm.Show();
            Hide();
        }

        private void txtTK_TextChanged(object sender, EventArgs e)
        {
            TimKiem();
        }

        private void frmSach_Load(object sender, EventArgs e)
        {
            LoadData();
            rbTenSach.Checked = true;
            txtTK.TextChanged += txtTK_TextChanged;
        }

        private void LoadData()
        {
            try
            {
                danhSachGoc = db.Sach.Include(s => s.LoaiSach)
                                     .Include(s => s.TacGia)
                                     .Include(s => s.NhaXuatBan)
                                     .ToList();

                dgvSach.DataSource = danhSachGoc
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
                    }).ToList();

                dgvSach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvSach.AllowUserToAddRows = false;
                dgvSach.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }
        private void TimKiem()
        {
            if (danhSachGoc == null) return;

            string keyword = txtTK.Text.Trim().ToLower();
            List<Sach> ketQua;

            if (string.IsNullOrWhiteSpace(keyword))
            {
                ketQua = danhSachGoc;
            }
            else if (rbMaSach.Checked)
            {
                ketQua = danhSachGoc.Where(s => s.MaSach.ToLower().Contains(keyword)).ToList();
            }
            else if (rbTenSach.Checked)
            {
                ketQua = danhSachGoc.Where(s => s.TenSach.ToLower().Contains(keyword)).ToList();
            }
            else if (rbMaTG.Checked)
            {
                ketQua = danhSachGoc.Where(s => s.MaTacGia.ToLower().Contains(keyword)).ToList();
            }
            else if (rbMaNXB.Checked)
            {
                ketQua = danhSachGoc.Where(s => s.MaXB.ToLower().Contains(keyword)).ToList();
            }
            else
            {
                ketQua = danhSachGoc;
            }

            dgvSach.DataSource = ketQua
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
                }).ToList();
        }

        private void frmSach_Click(object sender, EventArgs e)
        {

        }

        private void dgvSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string maSach = dgvSach.Rows[e.RowIndex].Cells["MaSach"].Value.ToString();
                selectedSach = db.Sach.FirstOrDefault(s => s.MaSach == maSach);

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
            selectedSach = null;
        }

    }
}
