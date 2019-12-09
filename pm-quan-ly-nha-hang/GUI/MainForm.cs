using System;
using GUI.NhanVien;
using GUI.MonAn;
using GUI.ThanhToan;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void nhânVienToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyNhanVien frm = new QuanLyNhanVien();
            frm.MdiParent = this;
            frm.Show();
        }

        private void nguyênLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyNguyenLieu frm = new QuanLyNguyenLieu();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mónĂnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyMonAn frm = new QuanLyMonAn();
            frm.MdiParent = this;
            frm.Show();
        }

        private void datBanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DatBan frm = new DatBan();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
