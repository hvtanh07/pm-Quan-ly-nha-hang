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
    public partial class LoginForm : Form
    {
        TaiKhoanBUS tkBUS;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user = textBox1.Text.ToUpper();
            TaiKhoanDTO tkDTO = tkBUS.Laytk(user, textBox2.Text);
            if (tkDTO.manv != null)
            {
                if (tkDTO.Type == "quanly")
                {
                    this.Hide();
                    var form2 = new AdminForm(tkDTO);
                    form2.Closed += (s, args) => this.Close();
                    form2.Show();
                }
                else if (tkDTO.Type == "thungan")
                {
                    this.Hide();
                    var form2 = new ThuNganForm(tkDTO);
                    form2.Closed += (s, args) => this.Close();
                    form2.Show();
                }
                else if (tkDTO.Type == "phucvu")
                {
                    this.Hide();
                    var form2 = new PhucVuvVeSinh(tkDTO);
                    form2.Closed += (s, args) => this.Close();
                    form2.Show();
                }
                else if (tkDTO.Type == "vesinh")
                {
                    this.Hide();
                    var form2 = new PhucVuvVeSinh(tkDTO);
                    form2.Closed += (s, args) => this.Close();
                    form2.Show();
                }
            }
            else
            {
                label3.Text = "Đăng nhập sai!";
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            tkBUS = new TaiKhoanBUS();
        }
    }
}
