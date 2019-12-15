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

namespace GUI.QuiDinh
{   
    public partial class Ban : Form
    {
        private BanBUS banBUS;
        public Ban()
        {
            InitializeComponent();           
        }

        private void Ban_Load(object sender, EventArgs e)
        {
            banBUS = new BanBUS();
            Loaddatavaocombo();
        }
        //them
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") return;

            BanDTO ban = new BanDTO();
            ban.soban = int.Parse(textBox1.Text);
            bool kq = banBUS.Them(ban);
            if (kq == false)
                MessageBox.Show("Thêm bàn thất bại. Vui lòng kiểm tra lại dũ liệu");
            else
            {
                MessageBox.Show("Thêm bàn thành công");
                Loaddatavaocombo();
            }
        }
        //xoa
        private void button2_Click(object sender, EventArgs e)
        {           
            BanDTO ban = new BanDTO();
            ban.soban = int.Parse(comboBox1.Text);
            bool kq = banBUS.Xoa(ban);
            if (kq == false)
                MessageBox.Show("Xóa bàn thất bại. Vui lòng kiểm tra lại dũ liệu");
            else
            {
                MessageBox.Show("Xóa bàn thành công");
                Loaddatavaocombo();
            }
        }
        private void Loaddatavaocombo()
        {
            List<string> soban = new List<string>();
            soban = banBUS.LaysoBan();
            comboBox1.DataSource = soban;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
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
