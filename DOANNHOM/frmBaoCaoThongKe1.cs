using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using DOANNHOM.data;
namespace DOANNHOM
{
   
    public partial class frmBaoCaoThongKe1 : Form
    {
        QuanLyThuVien ql  = new QuanLyThuVien();
        public frmBaoCaoThongKe1()
        {
            InitializeComponent();
        }

        private void frmBaoCaoThongKe1_Load(object sender, EventArgs e)
        {
            ThongKeTongHop();
            LoadData();
        }

        private void btnDangMuon_Click(object sender, EventArgs e)
        {
            LoadDanhSachDangMuon();
        }

        private void btnQuaHan_Click(object sender, EventArgs e)
        {
            LoadDanhSachQuaHan();   
        }

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

            dgvDanhSachMuon.DataSource = list;
            txtTongSach.Text = list.Count.ToString();
        }
        private void LoadDanhSachDangMuon()
        {
            DateTime today = DateTime.Now;
            var ds = (from mt in ql.MuonTraSach
                      where mt.NgayTra > today
                      select new
                      {
                          mt.MaPhieuMuon,
                          mt.MaSV,
                          mt.SinhVien.TenSV,
                          mt.MaSach,
                          mt.Sach.TenSach,
                          mt.NgayMuon,
                          mt.NgayTra
                      }).ToList();

            dgvDanhSachMuon.DataSource = ds;
            txtTongSach.Text = ds.Count.ToString();
        }

        private void LoadDanhSachQuaHan()
        {
            DateTime today = DateTime.Now;
            var ds = (from mt in ql.MuonTraSach
                      where mt.NgayTra < today
                      select new
                      {
                          mt.MaPhieuMuon,
                          mt.MaSV,
                          mt.SinhVien.TenSV,
                          mt.MaSach,
                          mt.Sach.TenSach,
                          mt.NgayMuon,
                          mt.NgayTra
                      }).ToList();

            dgvDanhSachMuon.DataSource = ds;
            txtTongSach.Text = ds.Count.ToString();
        }

        private void ThongKeTongHop()
        {
            // Thống kê sách
            int tongSach = ql.Sach.Count();
            int tongLoaiSach = ql.LoaiSach.Count();
            int tongTacGia = ql.TacGia.Count();
            int tongNXB = ql.NhaXuatBan.Count();

            // Thống kê người đọc và nhân viên
            int tongSinhVien = ql.SinhVien.Count();
            int tongNhanVien = ql.NhanVien.Count();

            // Thống kê sách mượn
            int tongSachMuon = ql.MuonTraSach.Count();

            // Gán lên các label hoặc textbox tương ứng
            lblSachValue.Text = tongSach.ToString();
            lblLoaiSachValue.Text = tongLoaiSach.ToString();
            lblTacGiaValue.Text = tongTacGia.ToString();
            lblNXBValue.Text = tongNXB.ToString();

            lblSinhVienValue.Text = tongSinhVien.ToString();
            lblNVValue.Text = tongNhanVien.ToString();
            lblSachMuonValue.Text = tongSachMuon.ToString();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            frmInBaoCaoThongKe f = new frmInBaoCaoThongKe();
            f.ShowDialog();
        }
    }
}
 