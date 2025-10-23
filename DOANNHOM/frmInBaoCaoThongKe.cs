using DOANNHOM.data;
using Microsoft.Reporting.WinForms;
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

namespace DOANNHOM
{
    public partial class frmInBaoCaoThongKe : Form
    {
        //QuanLyThuVien ql = new QuanLyThuVien();
        public frmInBaoCaoThongKe()
        {
            InitializeComponent();
        }

        private void frmInBaoCaoThongKe_Load(object sender, EventArgs e)
        {

           
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            using (var ql = new QuanLyThuVien())
            {
                var today = DateTime.Now;
                List<object> dsBaoCao = new List<object>();

                // Lấy lựa chọn trong combobox
                string loaiBaoCao = cmbMuonSach.SelectedItem?.ToString();

                if (loaiBaoCao == "Đang mượn")
                {
                    dsBaoCao = ql.MuonTraSach
                        .Include(m => m.SinhVien)
                        .Include(m => m.Sach)
                        .Where(m => m.NgayTra > today) 
                        .Select(m => new
                        {
                            m.MaPhieuMuon,
                            m.SinhVien.MaSV,
                            SinhVien = m.SinhVien.TenSV,
                            m.Sach.MaSach,
                            Sach = m.Sach.TenSach,
                            m.NgayMuon,
                            m.NgayTra 
                        })
                        .ToList<object>();
                    reportViewer1.LocalReport.ReportEmbeddedResource = "DOANNHOM.report.Danhsachmuon.rdlc";
                    ReportDataSource rp = new ReportDataSource("DataSetBaoCaoThongKe", dsBaoCao);
                    reportViewer1.LocalReport.DataSources.Clear();
                    reportViewer1.LocalReport.DataSources.Add(rp);
                    reportViewer1.RefreshReport();
                }
                else if (loaiBaoCao == "Quá hạn")
                {
                    dsBaoCao = ql.MuonTraSach
                        .Include(m => m.SinhVien)
                        .Include(m => m.Sach)
                        .Where(m =>  m.NgayTra < today) 
                        .Select(m => new
                        {
                            m.MaPhieuMuon,
                            m.SinhVien.MaSV,
                            SinhVien = m.SinhVien.TenSV,
                            m.Sach.MaSach,
                            Sach = m.Sach.TenSach,
                            m.NgayMuon,
                            m.NgayTra
                        })
                        .ToList<object>();
                    reportViewer1.LocalReport.ReportEmbeddedResource = "DOANNHOM.report.Danhsachmuon.rdlc";
                    ReportDataSource rp = new ReportDataSource("DataSetBaoCaoThongKe", dsBaoCao);
                    reportViewer1.LocalReport.DataSources.Clear();
                    reportViewer1.LocalReport.DataSources.Add(rp);
                    reportViewer1.RefreshReport();
                }
                else if(loaiBaoCao=="Danh sách mượn")
                {
                    dsBaoCao = ql.MuonTraSach
                        .Include(m => m.SinhVien)
                        .Include(m => m.Sach)
                        .Select(m => new
                        {
                            m.MaPhieuMuon,
                            m.SinhVien.MaSV,
                            SinhVien = m.SinhVien.TenSV,
                            m.Sach.MaSach,
                            Sach = m.Sach.TenSach,
                            m.NgayMuon,
                            m.NgayTra
                        })
                        .ToList<object>();
                    reportViewer1.LocalReport.ReportEmbeddedResource = "DOANNHOM.report.Danhsachmuon.rdlc";
                    ReportDataSource rp = new ReportDataSource("DataSetBaoCaoThongKe", dsBaoCao);
                    reportViewer1.LocalReport.DataSources.Clear();
                    reportViewer1.LocalReport.DataSources.Add(rp);
                    reportViewer1.RefreshReport();
                }

                else if (loaiBaoCao == "Sách hết")
                {
                    dsBaoCao = ql.Sach
                        .Include(s => s.TacGia)
                        .Where(s => s.SoLuong == 0)
                        .Select(s => new
                        {
                            s.MaSach,
                            s.TenSach,
                            TacGia = s.TacGia.TacGia1,
                            s.GiaBan,
                            s.SoLuong
                        })
                        .ToList<object>();
                    reportViewer1.LocalReport.ReportEmbeddedResource = "DOANNHOM.report.SoLuongSachSapHet.rdlc";
                    ReportDataSource rp = new ReportDataSource("DataSetSapHet", dsBaoCao);
                    reportViewer1.LocalReport.DataSources.Clear();
                    reportViewer1.LocalReport.DataSources.Add(rp);
                    reportViewer1.RefreshReport();
                }

                else if (loaiBaoCao == "Nhân Viên")
                {
                    dsBaoCao = ql.NhanVien
                        .Select(nv => new
                        {
                            nv.MaNhanVien,
                            nv.TenNhanVien,
                            nv.GioiTinh,
                            nv.DiaChi,
                            nv.SoDienThoai
                        })
                        .ToList<object>();

                    reportViewer1.LocalReport.ReportEmbeddedResource = "DOANNHOM.report.NhanVien.rdlc";
                    ReportDataSource rp = new ReportDataSource("DataSetNhanVien", dsBaoCao);
                    reportViewer1.LocalReport.DataSources.Clear();
                    reportViewer1.LocalReport.DataSources.Add(rp);
                    reportViewer1.RefreshReport();
                }
                else if (loaiBaoCao == "Độc giả")
                {
                    dsBaoCao = ql.SinhVien
                        .Select(sv => new
                        {
                            sv.MaSV,
                            sv.TenSV,
                            sv.KhoaHoc,
                            sv.NganhHoc,
                            sv.SoDienThoai
                        })
                        .ToList<object>();

                    reportViewer1.LocalReport.ReportEmbeddedResource = "DOANNHOM.report.DocGia.rdlc";
                    ReportDataSource rp = new ReportDataSource("DataSetDocGia", dsBaoCao);
                    reportViewer1.LocalReport.DataSources.Clear();
                    reportViewer1.LocalReport.DataSources.Add(rp);
                    reportViewer1.RefreshReport();
                }
                else if (loaiBaoCao == "Quản lý sách")
                {
                    dsBaoCao = ql.Sach
                        .Include(s => s.TacGia)
                        .Include(s=>s.NhaXuatBan)
                        .Include(s => s.LoaiSach)
                        .Select(s => new
                        {
                            s.MaSach,
                            s.TenSach,
                            MaLoai=s.LoaiSach.MaLoai,
                            LoaiSach=s.LoaiSach.TenLoaiSach,
                            MaTacGia=s.TacGia.MaTacGia,
                            MaXB=s.NhaXuatBan.MaXB,
                            NhaXuatBan=s.NhaXuatBan.NhaXuatBan1,
                            TacGia=s.TacGia.TacGia1,
                            s.GiaBan,
                            s.SoLuong
                        })
                        .ToList<object>();

                    reportViewer1.LocalReport.ReportEmbeddedResource = "DOANNHOM.report.Sach.rdlc";
                    ReportDataSource rp = new ReportDataSource("DataSetSach", dsBaoCao);
                    reportViewer1.LocalReport.DataSources.Clear();
                    reportViewer1.LocalReport.DataSources.Add(rp);
                    reportViewer1.RefreshReport();
                }


            }
        }
    }
}
