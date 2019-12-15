using GUI.BaoCaoDoanhThu;
using GUI.ThanhToan;
using GUI.DangNhap;
using System;
using BUS;
using DTO;
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
    public partial class ThuNganForm : Form
    {
        TaiKhoanDTO tkDTO;
        public ThuNganForm()
        {
            InitializeComponent();
        }
        public ThuNganForm(TaiKhoanDTO tk)
        {
            tkDTO = tk;
            InitializeComponent();
            if (DateTime.Today.Day <31|| DateTime.Today.Day > 28)
            {
                button3.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DatBan frm = new DatBan();
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LapHoaDon frm = new LapHoaDon();
            frm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CTBaoCaoDoanhThu frm = new CTBaoCaoDoanhThu();
            frm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DiemDanh frm = new DiemDanh(tkDTO);
            frm.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            XemLuong frm = new XemLuong(tkDTO);
            frm.ShowDialog();
        }
    }
}
