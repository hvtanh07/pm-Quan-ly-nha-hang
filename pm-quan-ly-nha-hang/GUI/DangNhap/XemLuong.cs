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
    public partial class XemLuong : Form
    {
        NhanVienDTO nvDTO;
        NhanVienBUS nvBUS;
        TaiKhoanDTO tkDTO;
        QuyDinhBUS qdBUS;
        QuiDinhDTO qd;
        public XemLuong()
        {
            InitializeComponent();
        }
        public XemLuong(TaiKhoanDTO nv)
        {
            nvBUS = new NhanVienBUS();
            qdBUS = new QuyDinhBUS();
            qd = qdBUS.Laydulieu();
            tkDTO = nv;
            nvDTO = nvBUS.Laynv(tkDTO.manv);
            InitializeComponent();
        }

        private void XemLuong_Load(object sender, EventArgs e)
        {
            if (nvDTO.tennv != null)
            {
                label6.Text = nvDTO.tennv;
                label5.Text = nvDTO.Absent.ToString();
                int luong = nvDTO.luongcoban - (nvDTO.Absent * qd.Luongtru);
                label4.Text = luong.ToString();
            }
        }
    }
}
