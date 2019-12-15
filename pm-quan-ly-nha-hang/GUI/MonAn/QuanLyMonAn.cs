using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.MonAn
{
    public partial class QuanLyMonAn : Form
    {
        private MonAnBUS maBUS;
        private DSNguyenLieuBUS dsnlBUS;
        public QuanLyMonAn()
        {
            InitializeComponent();
        }
        //them
        private void button1_Click(object sender, EventArgs e)
        {
            if (!testtext())
            {
                return;
            }
            MonAnDTO ma = new MonAnDTO();
            ma.mama = textBox1.Text;
            ma.tenma = textBox2.Text;
            ma.dongia = int.Parse(textBox4.Text);
            //2. Kiểm tra data hợp lệ or not

            //3. Thêm vào DB
            bool kq = maBUS.Them(ma);
            if (kq == false)
                System.Windows.MessageBox.Show("Thêm món ăn thất bại. Vui lòng kiểm tra lại dũ liệu");
            else
            {
                System.Windows.MessageBox.Show("Thêm món ăn thành công");
                clear();
            }
            loadData_Vao_GridView();
        }
        //search
        private void button2_Click(object sender, EventArgs e)
        {
            string sKeyword = txtKeyword.Text.Trim();
            if (sKeyword == null || sKeyword == string.Empty || sKeyword.Length == 0) // tìm tất cả
            {
                List<MonAnDTO> listMonAn = maBUS.select();
                this.loadData_Vao_GridView(listMonAn);
            }
            else
            {
                List<MonAnDTO> listMonAn = maBUS.selectByKeyWord(sKeyword);
                this.loadData_Vao_GridView(listMonAn);
            }
        }

        private void MonAn_Load(object sender, EventArgs e)
        {
            dsnlBUS = new DSNguyenLieuBUS();
            maBUS = new MonAnBUS();
            this.loadData_Vao_GridView();
            clear();
        }
        bool testtext()//kiểm tra ô dữ liệu trống
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                System.Windows.MessageBox.Show("Bạn chưa nhập mã món ăn.", "Lỗi");
                textBox1.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                System.Windows.MessageBox.Show("Bạn chưa nhập tên món ăn.", "Lỗi");
                textBox2.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                textBox4.Text = "0";
            }
            return true;//all true then gud to go
        }
        private void clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
        }
        private void loadData_Vao_GridView()
        {
            List<MonAnDTO> listMonAn = maBUS.select();

            if (listMonAn == null)
            {
                MessageBox.Show("Có lỗi khi lấy Món ăn từ cơ sở dữ liệu");
                return;
            }

            dsmonan.Columns.Clear();
            dsmonan.DataSource = null;

            dsmonan.AutoGenerateColumns = false;
            dsmonan.AllowUserToAddRows = false;
            dsmonan.DataSource = listMonAn;

            DataGridViewTextBoxColumn clMa = new DataGridViewTextBoxColumn();
            clMa.Name = "maMA";
            clMa.HeaderText = "Mã món ăn";
            clMa.DataPropertyName = "maMA";
            dsmonan.Columns.Add(clMa);

            DataGridViewTextBoxColumn clTen = new DataGridViewTextBoxColumn();
            clTen.Name = "tenMA";
            clTen.HeaderText = "Tên món ăn";
            clTen.DataPropertyName = "tenMA";
            dsmonan.Columns.Add(clTen);

            DataGridViewTextBoxColumn clDonGia = new DataGridViewTextBoxColumn();
            clDonGia.Name = "Dongia";
            clDonGia.HeaderText = "Đơn giá";
            clDonGia.DataPropertyName = "Dongia";
            dsmonan.Columns.Add(clDonGia);

            CurrencyManager myCurrencyManager = (CurrencyManager)this.BindingContext[dsmonan.DataSource];
            myCurrencyManager.Refresh();
        }
        private void loadData_Vao_GridView(List<MonAnDTO> listMonAn)
        {
            if (listMonAn == null)
            {
                MessageBox.Show("Có lỗi khi lấy Món ăn từ DB");
                return;
            }

            dsmonan.Columns.Clear();
            dsmonan.DataSource = null;

            dsmonan.AutoGenerateColumns = false;
            dsmonan.AllowUserToAddRows = false;
            dsmonan.DataSource = listMonAn;

            DataGridViewTextBoxColumn clMa = new DataGridViewTextBoxColumn();
            clMa.Name = "maMA";
            clMa.HeaderText = "Mã món ăn";
            clMa.DataPropertyName = "maMA";
            dsmonan.Columns.Add(clMa);

            DataGridViewTextBoxColumn clTen = new DataGridViewTextBoxColumn();
            clTen.Name = "tenMA";
            clTen.HeaderText = "Tên món ăn";
            clTen.DataPropertyName = "tenMA";
            dsmonan.Columns.Add(clTen);

            DataGridViewTextBoxColumn clDonGia = new DataGridViewTextBoxColumn();
            clDonGia.Name = "Dongia";
            clDonGia.HeaderText = "Đơn giá";
            clDonGia.DataPropertyName = "Dongia";
            dsmonan.Columns.Add(clDonGia);

            CurrencyManager myCurrencyManager = (CurrencyManager)this.BindingContext[dsmonan.DataSource];
            myCurrencyManager.Refresh();
        }
        //xoa
        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int currentRowIndex = dsmonan.CurrentCellAddress.Y;// 'current row selected
            //'Verify that indexing OK
            if (-1 < currentRowIndex && currentRowIndex < dsmonan.RowCount)
            {
                MonAnDTO ma = (MonAnDTO)dsmonan.Rows[currentRowIndex].DataBoundItem;
                if (ma != null)
                {
                    bool kq1 = dsnlBUS.XoatheoMA(ma.mama);
                    bool kq2 = maBUS.Xoa(ma);
                    if (!kq1 && !kq2)
                        MessageBox.Show("Xóa món ăn thất bại. Vui lòng kiểm tra lại dũ liệu");
                    else
                    {
                        MessageBox.Show("Xóa món ăn thành công");
                        this.loadData_Vao_GridView();
                    }
                }
            }
        }

        private void xemChiTiếtMónĂnToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int currentRowIndex = dsmonan.CurrentCellAddress.Y;// 'current row selected


            //'Verify that indexing OK
            if (-1 < currentRowIndex && currentRowIndex < dsmonan.RowCount)
            {
                MonAnDTO ma = (MonAnDTO)dsmonan.Rows[currentRowIndex].DataBoundItem;
                if (ma != null)
                {
                    ChiTietMonAn frm = new ChiTietMonAn(ma);
                    frm.ShowDialog();
                    loadData_Vao_GridView();
                }
            }
        }
    }
}
