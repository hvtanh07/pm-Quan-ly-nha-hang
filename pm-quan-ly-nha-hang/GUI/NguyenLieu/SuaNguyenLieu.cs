using DTO;
using BUS;
using System;
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
    public partial class SuaNguyenLieu : Form
    {
        private NguyenLieuBUS nlBUS;
        private NguyenLieuDTO nlDTO;
        public SuaNguyenLieu()
        {
            InitializeComponent();
        }
        public SuaNguyenLieu(NguyenLieuDTO nl)
        {
            nlBUS = new NguyenLieuBUS();
            this.nlDTO = nl;
            InitializeComponent();
        }
        private void SuaNguyenLieu_Load(object sender, EventArgs e)
        {
            if (this.nlDTO != null)
            {
                label7.Text = nlDTO.manl;
                textBox2.Text = nlDTO.tennl;
                textBox3.Text = nlDTO.dongia.ToString();
                textBox4.Text = nlDTO.donvi;
                textBox5.Text = nlDTO.trongkho.ToString();
                dateTimePicker1.Value = nlDTO.hsd;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //1. Map data from GUI
            NguyenLieuDTO nl = new NguyenLieuDTO();
            nl.manl = label7.Text;
            nl.tennl = textBox2.Text;
            nl.dongia = int.Parse(textBox3.Text);
            nl.donvi = textBox4.Text;
            nl.trongkho = int.Parse(textBox5.Text);
            nl.hsd = dateTimePicker1.Value;

            //2. Kiểm tra data hợp lệ or not

            //3. Thêm vào DB
            bool kq = nlBUS.Sua(nl);
            if (kq == false)
                MessageBox.Show("Sửa Kiểu nấu thất bại. Vui lòng kiểm tra lại dũ liệu");
            else
            {
                MessageBox.Show("Sửa Kiểu nấu thành công");
                this.Close();
            }
        }
    }
}
