using System;
using System.Linq;
using System.Windows.Forms;

namespace DOANNHOM
{
    public partial class frmTrangChu : Form
    {
        public frmTrangChu()
        {
            InitializeComponent();
        }

        private void frmTrangChu_Load(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            this.KeyPreview = true;
        }

        // ===== Mở hoặc kích hoạt form con =====
        private void kiemTraKichHoatForm(Form form)
        {
            var kiemTraTonTai = this.MdiChildren.FirstOrDefault(s => s.Name == form.Name);
            if (kiemTraTonTai != null)
                kiemTraTonTai.Activate();
            else
            {
                form.MdiParent = this;
                form.WindowState = FormWindowState.Maximized;
                form.Show();
            }
        }

        // ===== Thông tin tài khoản =====
        private void thôngTinTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kiemTraKichHoatForm(new frmThongTinTaiKhoan());
        }

        // ===== Đăng xuất =====
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đăng xuất?", "Đăng xuất",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.Yes)
            {
                foreach (var child in this.MdiChildren) child.Close();
                this.Close();
            }
        }

        // ===== Các menu khác =====
        private void quảnLýSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kiemTraKichHoatForm(new frmQuanLySach());
        }

        private void độcGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kiemTraKichHoatForm(new frmDocGia());
        }

        private void mượnTrảSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kiemTraKichHoatForm(new frmMuonTra());
        }

        private void quảnLýNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kiemTraKichHoatForm(new frmQLNhanVien());
        }

        private void báoCáoThốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kiemTraKichHoatForm(new frmBaoCaoThongKe());
        }

        private void thôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kiemTraKichHoatForm(new frmThongTinTaiKhoan());
        }
    }
}
