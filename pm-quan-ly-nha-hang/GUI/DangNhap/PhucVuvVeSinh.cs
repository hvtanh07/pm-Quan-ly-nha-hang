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

namespace GUI.DangNhap
{
    public partial class PhucVuvVeSinh : Form
    {
        TaiKhoanDTO tkDTO;
        public PhucVuvVeSinh()
        {
            InitializeComponent();
        }
        public PhucVuvVeSinh(TaiKhoanDTO tk)
        {
            tkDTO = tk;
            InitializeComponent();           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            XemLuong frm = new XemLuong(tkDTO);
            frm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DiemDanh frm = new DiemDanh(tkDTO);
            frm.ShowDialog();
        }
    }
}
