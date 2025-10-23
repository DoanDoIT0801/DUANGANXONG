using DOANNHOM.data;
using System;
using System.Data;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Windows.Forms;
using System.Data.Entity;
using System.Runtime.CompilerServices;
namespace DOANNHOM
{
    public partial class frmMuonTra : Form
    {
        QuanLyThuVien ql = new QuanLyThuVien();
        private bool isAdding = false; // Cờ kiểm tra đang thêm mới hay không
        private bool isExtending = false; //ktra có gia hạn hay không

        public frmMuonTra()
        {
            InitializeComponent();
        }

        // form Chính
        private void frmMuonTra_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadComboBox();
            DisableFields();
        }

        // Lấy dữ liệu vào datagridview
        private void LoadData()
        {
            var list = ql.MuonTraSach
                .Select(m => new
                {
                    m.MaPhieuMuon,
                    m.SinhVien.MaSV,
                    m.SinhVien.TenSV,
                    m.Sach.MaSach,
                    m.Sach.TenSach,
                    m.NgayMuon,
                    m.NgayTra,
                    m.GhiChu
                })
                .ToList();

            dgvMuonTra.DataSource = list;
        }

        // Đưa dư liệu vào combox
        private void LoadComboBox()
        {
            // ComboBox Sách
            var listSach = ql.Sach
                .Select(s => new
                {
                    s.MaSach,
                    s.TenSach
                })
                .ToList();

            cmbTenSachMuon.DataSource = listSach;
            cmbTenSachMuon.DisplayMember = "TenSach";
            cmbTenSachMuon.ValueMember = "MaSach";
            cmbTenSachMuon.SelectedIndex = -1;

            // ComboBox Sinh viên
            var listSinhVien = ql.SinhVien
                .Select(sv => new
                {
                    sv.MaSV,
                    HoTen = sv.MaSV + " - " + sv.TenSV
                })
                .ToList();

            cmbIDStudent.DataSource = listSinhVien;
            cmbIDStudent.DisplayMember = "HoTen";
            cmbIDStudent.ValueMember = "MaSV";
            cmbIDStudent.SelectedIndex = -1;
        }

        // Ẩn các trường hợp
        private void DisableFields()
        {
            txtMaPM.Enabled = false;
            txtIDStudent.Enabled = false;
            txtNameStudent.Enabled = false;
            txtIDSach.Enabled = false;
            txtNameSach.Enabled = false;
            txtSoLuong.Enabled = false;
            txtTTSachMuon.Enabled = false;
            cmbTenSachMuon.Enabled = false;
            cmbIDStudent.Enabled = false;
            dtpNgayMuon.Enabled = false;
            dtpNgayTra.Enabled = false;
            dtpNgayTra.Value = DateTime.Now;
        }

        // Khi chọn 1 dòng trên DataGridView
        private void dgvMuonTra_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvMuonTra.Rows[e.RowIndex];
            txtMaPM.Text = row.Cells["MaPhieuMuon"].Value.ToString();
            txtIDStudent.Text = row.Cells["MaSV"].Value.ToString();
            txtNameStudent.Text = row.Cells["TenSV"].Value.ToString();
            txtIDSach.Text = row.Cells["MaSach"].Value.ToString();
            txtNameSach.Text = row.Cells["TenSach"].Value.ToString();
            if (row.Cells["NgayMuon"].Value != null && row.Cells["NgayMuon"].Value != DBNull.Value)
                dtpNgayMuon.Value = Convert.ToDateTime(row.Cells["NgayMuon"].Value);

            if (row.Cells["NgayTra"].Value != null && row.Cells["NgayTra"].Value != DBNull.Value)
                dtpNgayTra.Value = Convert.ToDateTime(row.Cells["NgayTra"].Value);
            txtTTSachMuon.Text = row.Cells["GhiChu"].Value?.ToString();
             cmbIDStudent.Text = row.Cells["MaSV"].Value.ToString();
            cmbTenSachMuon.Text = row.Cells["MaSach"].Value.ToString();
        } 
         
        //  Khi c họn sách trong ComboBox
        private void cmbTenSachMuon_SelectedIndexChanged(object sender, EventArgs e)
        {                   
            if (cmbTenSachMuon.SelectedIndex == -1) return;

            string maSach = cmbTenSachMuon.SelectedValue.ToString();
            var sach = ql.Sach.FirstOrDefault(s => s.MaSach == maSach);

            if (sach != null)
            {
                txtIDSach.Text = sach.MaSach;
                txtNameSach.Text = sach.TenSach;
                txtSoLuong.Text = sach.SoLuong.ToString();
            }
        }

        // Khi chọn sinh viên trong ComboBox
        private void cmbIDStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbIDStudent.SelectedIndex == -1 || cmbIDStudent.SelectedValue == null)
                return;

            string maSV = cmbIDStudent.SelectedValue.ToString();
            var sv = ql.SinhVien.FirstOrDefault(s => s.MaSV == maSV);

            if (sv != null)
            {
                txtIDStudent.Text = sv.MaSV;
                txtNameStudent.Text = sv.TenSV;
            }
        }

        // Nút "Mượn sách" - Bật chế độ thêm
        private void btnMuon_Click(object sender, EventArgs e)
        {
            isAdding = true;
            isExtending = false;

            cmbTenSachMuon.Enabled = true;
            cmbIDStudent.Enabled = true;
            dtpNgayTra.Enabled = true;
            txtTTSachMuon.Enabled = true;
            dtpNgayMuon.Enabled = false;
            dtpNgayMuon.Value = DateTime.Now;

            //Xóa dữ liệu cũ
            txtMaPM.Clear();
            txtIDSach.Clear();
            txtNameSach.Clear();
            txtSoLuong.Clear();
            txtIDStudent.Clear();
            txtNameStudent.Clear();
            txtTTSachMuon.Clear();
            cmbTenSachMuon.SelectedIndex = -1;
            cmbIDStudent.SelectedIndex = -1;

            MessageBox.Show("Chế độ mượn sách đã bật. Hãy chọn Sinh viên và Sách cần mượn.");
            SetButtonState();
        }

        //  Nút "Ghi lại"
        private void btnGhiLai_Click(object sender, EventArgs e)
        {
            try
            {
                // Nếu đang thêm mới phiếu mượn
                if (isAdding)
                {
                    if (dtpNgayTra.Value <= DateTime.Now)
                    {
                        MessageBox.Show("Ngày trả phải lớn hơn ngày mượn!");
                        return;
                    }

                    if (cmbIDStudent.SelectedValue == null || cmbTenSachMuon.SelectedValue == null)
                    {
                        MessageBox.Show("Vui lòng chọn đầy đủ Sinh viên và Sách!");
                        return;
                    }

                    string maSV = cmbIDStudent.SelectedValue.ToString();
                    string maSach = cmbTenSachMuon.SelectedValue.ToString();
                    DateTime ngayMuon = DateTime.Now;
                    DateTime ngayTra = dtpNgayTra.Value;
                    string ghiChu = txtTTSachMuon.Text;

                    var sach = ql.Sach.FirstOrDefault(s => s.MaSach == maSach);
                    if (sach == null)
                    {
                        MessageBox.Show("Không tìm thấy sách!");
                        return;
                    }
                    if (sach.SoLuong <= 0)
                    {
                        MessageBox.Show("Sách đã hết, không thể mượn!");
                        return;
                    }

                    MuonTraSach phieu = new MuonTraSach()
                    {
                        MaSV = maSV,
                        MaSach = maSach,
                        NgayMuon = ngayMuon,
                        NgayTra = ngayTra,
                        GhiChu = ghiChu
                    };

                    ql.MuonTraSach.Add(phieu);
                    ql.SaveChanges();
                    soLuongsauMuon(maSach);

                    MessageBox.Show("Thêm phiếu mượn mới thành công!");
                    int maPhieuMoi = phieu.MaPhieuMuon;

                    // 👉 Cập nhật DataGridView chỉ hiển thị phiếu mới
                    var dataMoi = ql.MuonTraSach
                        .Include(m => m.SinhVien)
                        .Include(m => m.Sach)
                        .Where(m => m.MaPhieuMuon == maPhieuMoi)
                        .Select(m => new
                        {
                            m.MaPhieuMuon,
                            m.SinhVien.MaSV,
                            m.SinhVien.TenSV,
                            m.Sach.MaSach,
                            m.Sach.TenSach,
                            m.NgayMuon,
                            m.NgayTra,
                            m.GhiChu
                        })
                        .ToList();

                    dgvMuonTra.DataSource = dataMoi;

                    // 👉 Hỏi người dùng có muốn in phiếu ngay không
                    if (MessageBox.Show("Bạn có muốn in phiếu mượn ngay không?", "In phiếu mượn", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        frmPhieuMuon frm = new frmPhieuMuon(maPhieuMoi);
                        frm.ShowDialog();
                    }

                    
                    LoadData();
                    LamMoi();
                    SetButtonState();

                }
                // Nếu đang gia hạn
                else if (isExtending)
                {
                    if (string.IsNullOrWhiteSpace(txtMaPM.Text))
                    {
                        MessageBox.Show("Vui lòng chọn phiếu mượn cần gia hạn!");
                        return;
                    }

                    int maPM = int.Parse(txtMaPM.Text);
                    var phieu = ql.MuonTraSach.FirstOrDefault(p => p.MaPhieuMuon == maPM);
                    if (phieu == null)
                    {
                        MessageBox.Show("Không tìm thấy phiếu mượn để gia hạn!");
                        return;
                    }
                    DateTime ngayTraCu = phieu.NgayTra; // Ngày trả hiện tại
                    DateTime ngayGiaHan = dtpNgayTra.Value; // Ngày trả mới

                    
                    if (ngayGiaHan <= ngayTraCu)
                    {
                        MessageBox.Show("Ngày gia hạn phải lớn hơn ngày trả hiện tại!");
                        return;
                    }

                    if (ngayGiaHan <= DateTime.Now) // Phải lớn hơn ngày hiện tại
                    {
                        MessageBox.Show("Ngày gia hạn phải lớn hơn ngày hiện tại!");
                        return;
                    }
                    // ktra ngay gia han lon hon ngay muon
                    if (dtpNgayTra.Value <= phieu.NgayMuon)
                    {
                        MessageBox.Show("Ngày trả phải lớn hơn ngày mượn!");
                        return;
                    }
                    phieu.NgayTra = dtpNgayTra.Value;
                    ql.SaveChanges();

                    MessageBox.Show("Gia hạn phiếu mượn thành công!");
                }
                else
                {
                    MessageBox.Show("Không có thao tác nào đang thực hiện!");
                    return;
                }

                LoadData();
                LamMoi();
                SetButtonState(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message);
            }

        }

        //  Nút "Gia hạn"
        private void btnGiaHan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaPM.Text))
            {
                MessageBox.Show("Vui lòng chọn phiếu mượn cần gia hạn!");
                return;
            }

            // Bật cờ gia hạn
            isExtending = true;
            isAdding = false; // Đảm bảo không bị nhầm lẫn

            // Chỉ bật cho phép chọn ngày trả
            dtpNgayTra.Enabled = true;

            MessageBox.Show("Chế độ gia hạn đã bật. Hãy chọn ngày trả mới rồi bấm Ghi lại!");
            SetButtonState();
        }

        //  Nút "Trả sách"
        private void btnTraSach_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMaPM.Text))
                {
                    MessageBox.Show("Vui lòng chọn phiếu mượn cần trả!");
                    return;
                }

                int maPM = int.Parse(txtMaPM.Text);
                var phieu = ql.MuonTraSach.FirstOrDefault(p => p.MaPhieuMuon == maPM);

                if (phieu == null)
                {
                    MessageBox.Show("Không tìm thấy phiếu mượn cần trả!");
                    return;
                }

                if (MessageBox.Show("Xác nhận trả sách này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;

                soLuongSauTra(phieu.MaSach);
                ql.MuonTraSach.Remove(phieu);
                ql.SaveChanges();

                MessageBox.Show("Trả sách thành công!");
                LoadData();
                LamMoi();
                dtpNgayTra.Value = DateTime.Now;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi trả sách: " + ex.Message);
            }
        }

        //  Nút "Hủy bỏ"
        private void btnHuyBo_Click(object sender, EventArgs e)
        {

            LamMoi();
            MessageBox.Show("Đã hủy thao tác!");
            SetButtonState();
            dtpNgayTra.Value = DateTime.Now;
        }

        //  Giảm số lượng khi mượn
        public void soLuongsauMuon(string maSach)
        {
            var sach = ql.Sach.FirstOrDefault(s => s.MaSach == maSach);
            if (sach != null && sach.SoLuong > 0)
            {
                sach.SoLuong--;
                ql.SaveChanges();
            }
        }

        // Tăng số lượng khi trả
        public void soLuongSauTra(string maSach)
        {
            var sach = ql.Sach.FirstOrDefault(s => s.MaSach == maSach);
            if (sach != null)
            {
                sach.SoLuong++;
                ql.SaveChanges();
            }
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TimKiem();
            }
        }
        private void TimKiem()
        {
            try
            {
                string tuKhoa = txtTimKiem.Text.Trim();

                if (string.IsNullOrEmpty(tuKhoa))
                {
                    MessageBox.Show("Vui lòng nhập thông tin cần tìm!");
                    return;
                }

                var query = ql.MuonTraSach.AsQueryable();

                if (rbMaSV.Checked)
                {
                    query = query.Where(m => m.MaSV.Contains(tuKhoa));
                }
                else if (rbMaPhieuMuon.Checked)
                {
                    // Nếu Mã Phiếu Mượn là số
                    if (int.TryParse(tuKhoa, out int maPM))
                        query = query.Where(m => m.MaPhieuMuon == maPM);
                    else
                    {
                        MessageBox.Show("Mã phiếu mượn phải là số!");
                        return;
                    }
                }

                var list = query
                    .Select(m => new
                    {
                        m.MaPhieuMuon,
                        m.SinhVien.MaSV,
                        m.SinhVien.TenSV,
                        m.Sach.MaSach,
                        m.Sach.TenSach,
                        m.NgayMuon,
                        m.NgayTra,
                        m.GhiChu
                    })
                    .ToList();

                if (list.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy kết quả phù hợp!");
                }

                dgvMuonTra.DataSource = list;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message);
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTimKiem.Text))
            {
                LoadData(); // Gọi lại hàm hiển thị toàn bộ danh sách
            }
        }
        private void SetButtonState()
        {
            // Nếu đang thêm mới hoặc gia hạn -> chỉ cho phép bấm "Ghi lại" và "Hủy bỏ"
            if (isAdding || isExtending)
            {
                btnMuon.Enabled = false;
                btnGiaHan.Enabled = false;
                btnTraSach.Enabled = false;
                btnInPhieuMuon.Enabled = false;
                btnHuyBo.Enabled = true;
                btnGhiLai.Enabled = true;
            }
            else
            {
                // Ngược lại: bật tất cả lại bình thường
                btnMuon.Enabled = true;
                btnGiaHan.Enabled = true;
                btnTraSach.Enabled = true;
                btnInPhieuMuon.Enabled = true;
                btnHuyBo.Enabled = true;
                btnGhiLai.Enabled = true;
            }
        }
        private void btnInPhieuMuon_Click(object sender, EventArgs e)
        {

            int maPM = int.Parse(txtMaPM.Text);
            frmPhieuMuon pm = new frmPhieuMuon(maPM);
            pm.ShowDialog();
        }

        private void LamMoi()
        {
            isAdding = false;
            isExtending = false;
            DisableFields();

            txtMaPM.Clear();
            txtIDSach.Clear();
            txtNameSach.Clear();
            txtSoLuong.Clear();
            txtIDStudent.Clear();
            txtNameStudent.Clear();
            txtTTSachMuon.Clear();
            cmbTenSachMuon.DataSource = null;
            cmbIDStudent.DataSource = null;
            LoadComboBox();
        }
    }
}
