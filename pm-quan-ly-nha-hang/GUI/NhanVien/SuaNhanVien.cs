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
    public partial class SuaNhanVien : Form
    {
        private NhanVienBUS nvBUS;
        private NhanVienDTO nvDTO;
        public SuaNhanVien()
        {
            InitializeComponent();
        }
        public SuaNhanVien(NhanVienDTO nv)
        {
            nvBUS = new NhanVienBUS();
            this.nvDTO = nv;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!testtex())
            {
                return;
            }
            //1. Map data from GUI
            NhanVienDTO nv = new NhanVienDTO();
            nv.manv = label6.Text;
            nv.tennv = textBox2.Text;
            nv.luongcoban = int.Parse(textBox4.Text);
            nv.chucvu = comboBox1.Text;
            nv.birth = dateTimePicker1.Value;

            //2. Kiểm tra data hợp lệ or not

            //3. Thêm vào DB
            bool kq = nvBUS.Sua(nv);
            if (kq == false)
                MessageBox.Show("Sửa nhân viên thất bại. Vui lòng kiểm tra lại dũ liệu");
            else
            {
                MessageBox.Show("Sửa nhân viên thành công");
                this.Close();
            }
        }

        private void SuaNhanVien_Load(object sender, EventArgs e)
        {
            if (this.nvDTO != null)
            {
                label6.Text = nvDTO.manv;
                textBox2.Text = nvDTO.tennv;                
                textBox4.Text = nvDTO.luongcoban.ToString();
                comboBox1.Text = nvDTO.chucvu;
                dateTimePicker1.Value = nvDTO.birth;
            }
        }
        private Boolean testtex()
        {           
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                System.Windows.MessageBox.Show("Bạn chưa nhập tên nhân viên.", "Lỗi");
                textBox2.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                System.Windows.MessageBox.Show("Bạn chưa nhập lương cơ bản của nhân viên.", "Lỗi");
                textBox4.Focus();
                return false;
            }//gia  
            if (string.IsNullOrWhiteSpace(comboBox1.Text))
            {
                System.Windows.MessageBox.Show("Bạn chưa chọn chức vụ của nhân viên.", "Lỗi");
                textBox4.Focus();
                return false;
            }//gia                          

            return true;//all true then gud to go
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
