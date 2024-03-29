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

namespace GUI.QuiDinh
{
    public partial class QuanLyQuiDinh : Form
    {
        private QuyDinhBUS qdBUS;
        public QuanLyQuiDinh()
        {
            InitializeComponent();
            
        }
        private void LayduLieu()
        {
            try
            {
                QuiDinhDTO qd = qdBUS.Laydulieu();
                textBox1.Text = qd.Maxtogetsell.ToString();
                textBox2.Text = qd.Sellprice.ToString();
                textBox3.Text = qd.Percentnadd.ToString();
                textBox4.Text = qd.Dayofwork.ToString();
                textBox5.Text = qd.Luongtru.ToString();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Lấy dữ liệu qui định thất bại");
                return;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            QuiDinhDTO qd = qdBUS.Laydulieu();
            qd.Maxtogetsell = int.Parse(textBox1.Text);
            qd.Sellprice = int.Parse(textBox2.Text);
            qd.Percentnadd = int.Parse(textBox3.Text);
            qd.Dayofwork = int.Parse(textBox4.Text);
            qd.Luongtru = int.Parse(textBox5.Text);
            Boolean kq = qdBUS.Sua(qd);
            if (kq == false)
                MessageBox.Show("Sửa qui định thất bại. Vui lòng kiểm tra lại dũ liệu");
            else
            {
                MessageBox.Show("Sửa qui định thành công");
                LayduLieu();
            }
        }

        private void QuanLyQuiDinh_Load(object sender, EventArgs e)
        {
            qdBUS = new QuyDinhBUS();
            LayduLieu();
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
