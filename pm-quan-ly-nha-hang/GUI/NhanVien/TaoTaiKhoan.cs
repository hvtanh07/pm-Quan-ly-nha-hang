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

namespace GUI.NhanVien
{
    public partial class TaoTaiKhoan : Form
    {
        TaiKhoanBUS tkBUS;
        NhanVienDTO nvDTO;
        public TaoTaiKhoan()
        {
            InitializeComponent();
        }
        public TaoTaiKhoan(NhanVienDTO nv)
        {
            nvDTO = nv;
            InitializeComponent();
            if (nvDTO.chucvu == "Quản lý")
            {
                label4.Text = "quanly";
            }
            if (nvDTO.chucvu == "Thu ngân")
            {
                label4.Text = "thungan";
            }
            if (nvDTO.chucvu == "Phục vụ")
            {
                label4.Text = "phucvu";
            }
            if (nvDTO.chucvu == "Vệ sinh")
            {
                label4.Text = "vesinh";
            }
        }

        private void TaoTaiKhoan_Load(object sender, EventArgs e)
        {
            tkBUS = new TaiKhoanBUS();
        }
        //them
        private void button1_Click(object sender, EventArgs e)
        {
            if (!testtext())
            {
                return;
            }
            TaiKhoanDTO nv = new TaiKhoanDTO();           
            nv.manv = nvDTO.manv;
            nv.Username = textBox1.Text.ToUpper();
            nv.Password = textBox2.Text;
            if (nvDTO.chucvu== "Quản lý")
            {
                nv.Type = "quanly";
            }
            if (nvDTO.chucvu == "Thu ngân")
            {
                nv.Type = "thungan";
            }
            if (nvDTO.chucvu == "Phục vụ")
            {
                nv.Type = "phucvu";
            }
            if (nvDTO.chucvu == "Vệ sinh")
            {
                nv.Type = "vesinh";
            }
            //2. Kiểm tra data hợp lệ or not

            //3. Thêm vào DB
            bool kq = tkBUS.Them(nv);
            if (kq == false)
                System.Windows.MessageBox.Show("Tạo tài khoản thất bại. Vui lòng kiểm tra lại dũ liệu");
            else
            {
                System.Windows.MessageBox.Show("Tạo tài khoản thành công");
                this.Close();
            }           
        }
        private Boolean testtext()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                System.Windows.MessageBox.Show("Bạn chưa nhập tên đăng nhập.", "Lỗi");
                textBox1.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                System.Windows.MessageBox.Show("Bạn chưa nhập mật khẩu.", "Lỗi");
                textBox1.Focus();
                return false;
            }
            return true;//all true then gud to go
        }
    }
}
