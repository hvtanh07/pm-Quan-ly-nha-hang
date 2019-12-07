﻿using System;
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
            //1. Map data from GUI
            NhanVienDTO nv = new NhanVienDTO();
            nv.manv = label6.Text;
            nv.tennv = textBox2.Text;
            nv.luongcoban = int.Parse(textBox4.Text);
            nv.chucvu = textBox5.Text;
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
                textBox5.Text = nvDTO.chucvu;
                dateTimePicker1.Value = nvDTO.birth;
            }
        }
    }
}