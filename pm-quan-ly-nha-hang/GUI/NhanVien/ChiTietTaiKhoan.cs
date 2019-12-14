using System;
using DTO;
using BUS;
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
    public partial class ChiTietTaiKhoan : Form
    {
        TaiKhoanBUS tkBUS;
        TaiKhoanDTO tkDTO;
        public ChiTietTaiKhoan()
        {
            InitializeComponent();
        }
        public ChiTietTaiKhoan(TaiKhoanDTO tk)
        {
            tkBUS = new TaiKhoanBUS();
            tkDTO = tk;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!testtext())
            {
                return;
            }
            //1. Map data from GUI
            TaiKhoanDTO nv = new TaiKhoanDTO();
            nv.manv = tkDTO.manv;
            nv.Password = textBox2.Text;
            nv.Username = textBox1.Text;
            nv.Type = comboBox1.Text;
            //2. Kiểm tra data hợp lệ or not

            //3. Thêm vào DB
            bool kq = tkBUS.Sua(nv);
            if (kq == false)
                MessageBox.Show("Sửa tài khoản thất bại. Vui lòng kiểm tra lại dũ liệu");
            else
            {
                MessageBox.Show("Sửa tài khoản thành công");
                this.Close();
            }
        }

        private void ChiTietTaiKhoan_Load(object sender, EventArgs e)
        {
            if (this.tkDTO != null)
            {
                textBox1.Text = tkDTO.Username;
                textBox2.Text = tkDTO.Password;
                comboBox1.Text = tkDTO.Type;
            }
        }
        bool testtext()//kiểm tra ô dữ liệu trống
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
                textBox2.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(comboBox1.Text))
            {
                System.Windows.MessageBox.Show("Bạn chưa chọn loại tài khoản.", "Lỗi");
                comboBox1.Focus();
                return false;
            }//gia  
                                
            return true;//all true then gud to go
        }
    }
}
