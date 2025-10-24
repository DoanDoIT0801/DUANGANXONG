using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using DOANNHOM.data;

namespace DOANNHOM
{
    public partial class frmQuanLySach : Form
    {
        private QuanLyThuVien db; 
        private List<object> danhSachSachGoc;

        public frmQuanLySach()
        {
            InitializeComponent();
            db = new QuanLyThuVien();
        }

        private void frmQuanLySach_Load(object sender, EventArgs e)
        {
            LoadData();
            rbTenSach.Checked = true;
            txtTK.TextChanged += txtTK_TextChanged;
        }

        private void LoadData()
        {
            try
            {
                var sachList = db.Sach
                    .Include(s => s.LoaiSach)
                    .Include(s => s.NhaXuatBan)
                    .Include(s => s.TacGia)
                    .Select(s => new
                    {
                        MaSach = s.MaSach,
                        TenSach = s.TenSach,
                        TenLoaiSach = s.LoaiSach.TenLoaiSach,
                        NhaXuatBan = s.NhaXuatBan.NhaXuatBan1,
                        TacGia = s.TacGia.TacGia1,
                        SoTrang = s.SoTrang,
                        GiaBan = s.GiaBan,
                        SoLuong = s.SoLuong
                    })
                    .ToList<object>(); // Thay đổi ở đây

                danhSachSachGoc = sachList;
                HienThiDanhSach(sachList);
                CustomizeDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HienThiDanhSach(List<dynamic> danhSach)
        {
            dgvDSTK.DataSource = null;
            dgvDSTK.DataSource = danhSach;
        }

        private void CustomizeDataGridView()
        {
            if (dgvDSTK.Columns.Count == 0) return;

            dgvDSTK.Columns["MaSach"].Visible = false;
            dgvDSTK.Columns["TenSach"].HeaderText = "Tên Sách";
            dgvDSTK.Columns["TenLoaiSach"].HeaderText = "Loại Sách";
            dgvDSTK.Columns["NhaXuatBan"].HeaderText = "Nhà Xuất Bản";
            dgvDSTK.Columns["TacGia"].HeaderText = "Tác Giả";
            dgvDSTK.Columns["SoTrang"].HeaderText = "Số Trang";
            dgvDSTK.Columns["GiaBan"].HeaderText = "Giá Bán (VNĐ)";
            dgvDSTK.Columns["SoLuong"].HeaderText = "Số Lượng";

            dgvDSTK.Columns["GiaBan"].DefaultCellStyle.Format = "N0";
            dgvDSTK.Columns["GiaBan"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDSTK.Columns["SoLuong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDSTK.Columns["SoTrang"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvDSTK.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDSTK.AllowUserToAddRows = false;
        }

        private void TimKiem()
        {
            if (danhSachSachGoc == null || danhSachSachGoc.Count == 0) return;

            string keyword = txtTK.Text.Trim().ToLower();
            List<object> ketQua;

            if (string.IsNullOrWhiteSpace(keyword))
            {
                ketQua = danhSachSachGoc;
            }
            else
            {
                if (rbTenSach.Checked)
                {
                    ketQua = danhSachSachGoc.Where(s =>
                    {
                        var obj = s.GetType().GetProperty("TenSach")?.GetValue(s, null);
                        return obj?.ToString().ToLower().Contains(keyword) == true;
                    }).ToList();
                }
                else if (rbLoaiSach.Checked)
                {
                    ketQua = danhSachSachGoc.Where(s =>
                    {
                        var obj = s.GetType().GetProperty("TenLoaiSach")?.GetValue(s, null);
                        return obj?.ToString().ToLower().Contains(keyword) == true;
                    }).ToList();
                }
                else if (rbTacGia.Checked)
                {
                    ketQua = danhSachSachGoc.Where(s =>
                    {
                        var obj = s.GetType().GetProperty("TacGia")?.GetValue(s, null);
                        return obj?.ToString().ToLower().Contains(keyword) == true;
                    }).ToList();
                }
                else if (rbNXB.Checked)
                {
                    ketQua = danhSachSachGoc.Where(s =>
                    {
                        var obj = s.GetType().GetProperty("NhaXuatBan")?.GetValue(s, null);
                        return obj?.ToString().ToLower().Contains(keyword) == true;
                    }).ToList();
                }
                else
                {
                    ketQua = danhSachSachGoc.Where(s =>
                    {
                        var tenSach = s.GetType().GetProperty("TenSach")?.GetValue(s, null)?.ToString().ToLower();
                        var loaiSach = s.GetType().GetProperty("TenLoaiSach")?.GetValue(s, null)?.ToString().ToLower();
                        var tacGia = s.GetType().GetProperty("TacGia")?.GetValue(s, null)?.ToString().ToLower();
                        var nxb = s.GetType().GetProperty("NhaXuatBan")?.GetValue(s, null)?.ToString().ToLower();

                        return (tenSach?.Contains(keyword) == true ||
                                loaiSach?.Contains(keyword) == true ||
                                tacGia?.Contains(keyword) == true ||
                                nxb?.Contains(keyword) == true);
                    }).ToList();
                }
            }

            HienThiDanhSach(ketQua);
        }

        private void rbTenSach_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTenSach.Checked) TimKiem();
        }

        private void rbLoaiSach_CheckedChanged(object sender, EventArgs e)
        {
            if (rbLoaiSach.Checked) TimKiem();
        }

        private void rbTacGia_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTacGia.Checked) TimKiem();
        }

        private void rbNXB_CheckedChanged(object sender, EventArgs e)
        {
            if (rbNXB.Checked) TimKiem();
        }

        private void trangChủToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDocGia frm = new frmDocGia();
            frm.Show();
            Hide();
        }

        private void độcGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDocGia frm = new frmDocGia();
            frm.Show();
            Hide();
        }

        private void btnLoaiSach_Click_1(object sender, EventArgs e)
        {
            frmLoaiSach frm = new frmLoaiSach();
            frm.Show();
            Hide();
        }

        private void btnQLS_Click_1(object sender, EventArgs e)
        {
            frmSach frm = new frmSach();
            frm.Show();
            Hide();
        }

        private void btnTacGia_Click_1(object sender, EventArgs e)
        {
            frmTacGia frm = new frmTacGia();
            frm.Show();
            Hide();
        }

        private void btnNXB_Click_1(object sender, EventArgs e)
        {
            frmNhaXuatBan frm = new frmNhaXuatBan();
            frm.Show();
            Hide();
        }

        private void txtTK_TextChanged(object sender, EventArgs e)
        {
            TimKiem();
        }

        private void btnTrangChu_Click_1(object sender, EventArgs e)
        {
            frmTrangChu frm = new frmTrangChu();
            frm.Show();
            Hide();
        }
    }
}