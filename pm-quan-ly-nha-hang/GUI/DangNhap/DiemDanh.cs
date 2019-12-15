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
    public partial class DiemDanh : Form
    {
        NhanVienDTO nvDTO;
        NhanVienBUS nvBUS;
        QuyDinhBUS qdBUS;
        QuiDinhDTO qd;
        TaiKhoanDTO tkDTO;
        public DiemDanh()
        {
            InitializeComponent();
        }
        public DiemDanh(TaiKhoanDTO nv)
        {
            nvBUS = new NhanVienBUS();
            qdBUS = new QuyDinhBUS();
            qd = qdBUS.Laydulieu();
            tkDTO = nv;
            nvDTO = nvBUS.Laynv(tkDTO.manv);
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DateTime.Today.DayOfWeek == DayOfWeek.Monday)//dau tuan kiem tra so buoi vang roi reset 
            {
                int absent = qd.Dayofwork - nvDTO.Attended;
                nvDTO.Absent += absent;
                nvDTO.Attended = 0;//reset dem                
            }
            if(DateTime.Today.Day == 1)
            {
                nvDTO.Absent = 0;//reset so ngay nghi sau moi thang 
            }
            nvDTO.Attended += 1;
            
            bool kq = nvBUS.Sua(nvDTO);
            if (kq == false)
            {
                MessageBox.Show("Điểm danh thất bại");
                return;
            }
            else
            {
                MessageBox.Show("Điểm danh thành công");
            }
            this.Close();
        }

        private void DiemDanh_Load(object sender, EventArgs e)
        {
            if (nvDTO.tennv != null)
            {
                label1.Text = nvDTO.tennv;
            }
        }
    }
}
