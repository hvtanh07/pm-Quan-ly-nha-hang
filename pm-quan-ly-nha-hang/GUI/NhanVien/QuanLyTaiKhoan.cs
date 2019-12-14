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
    public partial class QuanLyTaiKhoan : Form
    {
        private TaiKhoanBUS tkBUS;
        public QuanLyTaiKhoan()
        {    
            InitializeComponent();           
        }

        private void QuanLyTaiKhoan_Load(object sender, EventArgs e)
        {
            tkBUS = new TaiKhoanBUS();
            loadData_Vao_GridView();
        }
        //search
        private void button1_Click(object sender, EventArgs e)
        {
            string sKeyword = textBox1.Text.Trim();
            if (sKeyword == null || sKeyword == string.Empty || sKeyword.Length == 0) // tìm tất cả
            {
                List<TaiKhoanDTO> listNhanVien = tkBUS.select();
                this.loadData_Vao_GridView(listNhanVien);
            }
            else
            {
                List<TaiKhoanDTO> listNhanVien = tkBUS.selectByKeyWord(sKeyword);
                this.loadData_Vao_GridView(listNhanVien);
            }
        }
        private void xemSửaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int currentRowIndex = dataGridView1.CurrentCellAddress.Y;// 'current row selected


            //'Verify that indexing OK
            if (-1 < currentRowIndex && currentRowIndex < dataGridView1.RowCount)
            {
                TaiKhoanDTO nv = (TaiKhoanDTO)dataGridView1.Rows[currentRowIndex].DataBoundItem;
                if (nv != null)
                {
                    ChiTietTaiKhoan frm = new ChiTietTaiKhoan(nv);
                    frm.ShowDialog();
                    loadData_Vao_GridView();
                }
            }
        }
        private void loadData_Vao_GridView()
        {
            List<TaiKhoanDTO> listNhanVien = tkBUS.select();

            if (listNhanVien == null)
            {
                MessageBox.Show("Có lỗi khi lấy nhân viên từ cơ sở dữ liệu");
                return;
            }

            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = null;

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.DataSource = listNhanVien;

            DataGridViewTextBoxColumn clName = new DataGridViewTextBoxColumn();
            clName.Name = "Username";
            clName.HeaderText = "Tên đăng nhập";
            clName.DataPropertyName = "Username";
            dataGridView1.Columns.Add(clName);

            DataGridViewTextBoxColumn clMa = new DataGridViewTextBoxColumn();
            clMa.Name = "maNV";
            clMa.HeaderText = "Mã nhân viên";
            clMa.DataPropertyName = "maNV";
            dataGridView1.Columns.Add(clMa);

            DataGridViewTextBoxColumn cltype = new DataGridViewTextBoxColumn();
            cltype.Name = "Type";
            cltype.HeaderText = "Loại tài khoản";
            cltype.DataPropertyName = "Type";
            dataGridView1.Columns.Add(cltype);           

            CurrencyManager myCurrencyManager = (CurrencyManager)this.BindingContext[dataGridView1.DataSource];
            myCurrencyManager.Refresh();
        }
        private void loadData_Vao_GridView(List<TaiKhoanDTO> listNhanVien)
        {
            if (listNhanVien == null)
            {
                MessageBox.Show("Có lỗi khi lấy nhân viên từ DB");
                return;
            }

            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = null;

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.DataSource = listNhanVien;

            DataGridViewTextBoxColumn clName = new DataGridViewTextBoxColumn();
            clName.Name = "Username";
            clName.HeaderText = "Tên đăng nhập";
            clName.DataPropertyName = "Username";
            dataGridView1.Columns.Add(clName);

            DataGridViewTextBoxColumn clMa = new DataGridViewTextBoxColumn();
            clMa.Name = "maNV";
            clMa.HeaderText = "Mã nhân viên";
            clMa.DataPropertyName = "maNV";
            dataGridView1.Columns.Add(clMa);

            DataGridViewTextBoxColumn cltype = new DataGridViewTextBoxColumn();
            cltype.Name = "Type";
            cltype.HeaderText = "Loại tài khoản";
            cltype.DataPropertyName = "Type";
            dataGridView1.Columns.Add(cltype);

            CurrencyManager myCurrencyManager = (CurrencyManager)this.BindingContext[dataGridView1.DataSource];
            myCurrencyManager.Refresh();

        }
    }
}
