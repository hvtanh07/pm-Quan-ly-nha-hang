﻿using System;
using GUI.NhanVien;
using GUI.MonAn;
using GUI.ThanhToan;
using GUI.BaoCaoDoanhThu;
using GUI.QuiDinh;
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

namespace GUI
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }
        public AdminForm(TaiKhoanDTO tk)
        {
            InitializeComponent();
        }

        private void nhânVienToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyNhanVien frm = new QuanLyNhanVien();
            frm.MdiParent = this;
            frm.Show();
        }

        private void nguyênLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyNguyenLieu frm = new QuanLyNguyenLieu();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mónĂnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyMonAn frm = new QuanLyMonAn();
            frm.MdiParent = this;
            frm.Show();
        }

        private void datBanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DatBan frm = new DatBan();
            frm.MdiParent = this;
            frm.Show();
        }

        private void lậpHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LapHoaDon frm = new LapHoaDon();
            frm.MdiParent = this;
            frm.Show();
        }

        private void báoCáoThángToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CTBaoCaoDoanhThu frm = new CTBaoCaoDoanhThu();
            frm.MdiParent = this;
            frm.Show();
        }

        private void quảnLýTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyTaiKhoan frm = new QuanLyTaiKhoan();
            frm.MdiParent = this;
            frm.Show();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {

        }

        private void quảnLýBànToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ban frm = new Ban();
            frm.MdiParent = this;
            frm.Show();
        }

        private void cácQuyĐịnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyQuiDinh frm = new QuanLyQuiDinh();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
