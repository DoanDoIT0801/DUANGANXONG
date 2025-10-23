using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DOANNHOM.data;
using Microsoft.Reporting.WinForms;
using System.Data.Entity;
namespace DOANNHOM
{
    public partial class frmPhieuMuon : Form
    {
        private int maPhieuMuon;

        public frmPhieuMuon(int maPhieuMuon)
        {
            InitializeComponent();
            this.maPhieuMuon = maPhieuMuon;
        }

        private void PhieuMuon_Load(object sender, EventArgs e)
        {
            try
            {
                reportViewer1.LocalReport.ReportEmbeddedResource = "DOANNHOM.report.Inphieumuon.rdlc";
                using (var ql = new QuanLyThuVien())
                {
                  var data = ql.MuonTraSach
                 .Include(m => m.SinhVien)
                 .Include(m => m.Sach)
                 .Where(m => m.MaPhieuMuon == maPhieuMuon)
                 .Select(m => new
                 {
                     m.MaPhieuMuon,
                     m.SinhVien.MaSV,
                     SinhVien = m.SinhVien.TenSV,  // ghi rõ tên để khớp dataset
                     m.Sach.MaSach,
                     Sach = m.Sach.TenSach,  // ghi rõ tên để khớp dataset
                     m.NgayMuon,
                     m.NgayTra,
                     m.GhiChu
                 })
                 .ToList();
                    if (data.Count == 0)
                    {
                        MessageBox.Show("Không có dữ liệu phiếu mượn để in!");
                        return;
                    }
                    ReportDataSource rp = new ReportDataSource("DataSetMuonTraSach", data);
                    reportViewer1.LocalReport.DataSources.Clear();
                    reportViewer1.LocalReport.DataSources.Add(rp);
                    reportViewer1.RefreshReport();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}


