using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DOANNHOM
{
    public partial class frmTrangChu : Form
    {
        public frmTrangChu()
        {
            InitializeComponent();
        }

        private void kiemTraKichHoatForm(Form form)
        {
            var kiemTraTonTai = this.MdiChildren.FirstOrDefault(s => s.Name == form.Name);
            if (kiemTraTonTai != null)
            {
                kiemTraTonTai.Activate();
            }
            else
            {
                form.MdiParent = this;
                form.Show();
                form.WindowState = FormWindowState.Maximized;
            }
        }

        private void frmTrangChu_Load(object sender, EventArgs e)
        {
            // this.KeyPreview = true; // nếu muốn xử lý KeyDown ở cấp form
            // this.IsMdiContainer = true; // nếu đây là MDI Parent
        }

        private void tàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // mở “Thông tin tài khoản” nếu có
        }

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

        private void quánLýNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kiemTraKichHoatForm(new frmQLNhanVien());
        }

        private void báoCáoThốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kiemTraKichHoatForm(new frmBaoCaoThongKe1());
        }

        // ====== ĐĂNG XUẤT ======
        private void DangXuat()
        {
            var confirm = MessageBox.Show("Bạn có muốn đăng xuất?",
                                          "Đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            // Đóng tất cả MDI con rồi đóng Trang Chủ
            foreach (var child in this.MdiChildren) child.Close();

            // Chỉ cần Close(); frmLogin sẽ Show lại nhờ FormClosed handler ở frmLogin
            this.Close();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DangXuat();
        }

        // Bắt phím ESC để đăng xuất nhanh
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                DangXuat();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void thôngTinTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // xử lý nếu có
        }
    }
}
