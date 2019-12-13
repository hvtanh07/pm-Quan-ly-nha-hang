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

namespace GUI
{
    public partial class QuanLyNguyenLieu : Form
    {
        private NguyenLieuBUS nlBUS;
        public QuanLyNguyenLieu()
        {
            InitializeComponent();
        }
        private void QuanLyNguyenLieu_Load(object sender, EventArgs e)
        {
            nlBUS = new NguyenLieuBUS();
            this.loadData_Vao_GridView();
            clear();
        }
        //Them
        private void button1_Click(object sender, EventArgs e)
        {
            if (!testtext())
            {
                return;
            }
            NguyenLieuDTO nl = new NguyenLieuDTO();
            nl.manl = textBox1.Text;
            nl.tennl = textBox2.Text;
            nl.dongia = int.Parse(textBox3.Text);
            nl.donvi = textBox4.Text;
            nl.trongkho = int.Parse(textBox5.Text);
            nl.hsd = dateTimePicker1.Value;
            //2. Kiểm tra data hợp lệ or not
            
            //3. Thêm vào DB
            bool kq = nlBUS.Them(nl);
            if (kq == false)
                System.Windows.MessageBox.Show("Thêm nguyên liẹu thất bại. Vui lòng kiểm tra lại dũ liệu");
            else
            {
                System.Windows.MessageBox.Show("Thêm nguyên liẹu thành công");
                clear();
            }
            loadData_Vao_GridView();
        }
        //Search
        private void button4_Click(object sender, EventArgs e)
        {
            string sKeyword = txtKeyword.Text.Trim();
            if (sKeyword == null || sKeyword == string.Empty || sKeyword.Length == 0) // tìm tất cả
            {
                List<NguyenLieuDTO> listNguyenLieu = nlBUS.select();
                this.loadData_Vao_GridView(listNguyenLieu);
            }
            else
            {
                List<NguyenLieuDTO> listNguyenLieu = nlBUS.selectByKeyWord(sKeyword);
                this.loadData_Vao_GridView(listNguyenLieu);
            }
        }
        //sua
        private void suaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int currentRowIndex = dsnguyenlieu.CurrentCellAddress.Y;// 'current row selected


            //'Verify that indexing OK
            if (-1 < currentRowIndex && currentRowIndex < dsnguyenlieu.RowCount)
            {
                NguyenLieuDTO nl = (NguyenLieuDTO)dsnguyenlieu.Rows[currentRowIndex].DataBoundItem;
                if (nl != null)
                {
                    SuaNguyenLieu frm = new SuaNguyenLieu(nl);
                    frm.ShowDialog();
                    loadData_Vao_GridView();
                }
            }
        }
        //xoa
        private void xoaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int currentRowIndex = dsnguyenlieu.CurrentCellAddress.Y;// 'current row selected
            //'Verify that indexing OK
            if (-1 < currentRowIndex && currentRowIndex < dsnguyenlieu.RowCount)
            {
                NguyenLieuDTO kn = (NguyenLieuDTO)dsnguyenlieu.Rows[currentRowIndex].DataBoundItem;
                if (kn != null)
                {
                    bool kq = nlBUS.Xoa(kn);
                    if (kq == false)
                        MessageBox.Show("Xóa nguyên liệu thất bại. Vui lòng kiểm tra lại dũ liệu");
                    else
                    {
                        MessageBox.Show("Xóa nguyên liệu thành công");
                        this.loadData_Vao_GridView();
                    }
                }
            }
        }
        private void loadData_Vao_GridView()
        {
            List<NguyenLieuDTO> listNguyenLieu = nlBUS.select();

            if (listNguyenLieu == null)
            {
                MessageBox.Show("Có lỗi khi lấy món ăn từ cơ sở dữ liệu");
                return;
            }

            dsnguyenlieu.Columns.Clear();
            dsnguyenlieu.DataSource = null;

            dsnguyenlieu.AutoGenerateColumns = false;
            dsnguyenlieu.AllowUserToAddRows = false;
            dsnguyenlieu.DataSource = listNguyenLieu;

            DataGridViewTextBoxColumn clMa = new DataGridViewTextBoxColumn();
            clMa.Name = "maNL";
            clMa.HeaderText = "Mã nguyên liệu";
            clMa.DataPropertyName = "maNL";
            dsnguyenlieu.Columns.Add(clMa);

            DataGridViewTextBoxColumn clTen = new DataGridViewTextBoxColumn();
            clTen.Name = "tenNL";
            clTen.HeaderText = "Tên nguyên liệu";
            clTen.DataPropertyName = "tenNL";
            dsnguyenlieu.Columns.Add(clTen);

            DataGridViewTextBoxColumn clDonGia = new DataGridViewTextBoxColumn();
            clDonGia.Name = "Dongia";
            clDonGia.HeaderText = "Đơn giá";
            clDonGia.DataPropertyName = "Dongia";
            dsnguyenlieu.Columns.Add(clDonGia);

            DataGridViewTextBoxColumn clDonVi = new DataGridViewTextBoxColumn();
            clDonVi.Name = "Donvi";
            clDonVi.HeaderText = "Đơn vị";
            clDonVi.DataPropertyName = "Donvi";
            dsnguyenlieu.Columns.Add(clDonVi);

            DataGridViewTextBoxColumn clKho = new DataGridViewTextBoxColumn();
            clKho.Name = "trongKho";
            clKho.HeaderText = "Còn lại trong kho";
            clKho.DataPropertyName = "trongKho";
            dsnguyenlieu.Columns.Add(clKho);

            DataGridViewTextBoxColumn clHSD = new DataGridViewTextBoxColumn();
            clHSD.Name = "hsd";
            clHSD.HeaderText = "Hạn sử dụng";
            clHSD.DataPropertyName = "hsd";
            dsnguyenlieu.Columns.Add(clHSD);

            CurrencyManager myCurrencyManager = (CurrencyManager)this.BindingContext[dsnguyenlieu.DataSource];
            myCurrencyManager.Refresh();
        }
        private void loadData_Vao_GridView(List<NguyenLieuDTO> listNguyenLieu)
        {
            if (listNguyenLieu == null)
            {
                MessageBox.Show("Có lỗi khi lấy món ăn từ DB");
                return;
            }

            dsnguyenlieu.Columns.Clear();
            dsnguyenlieu.DataSource = null;

            dsnguyenlieu.AutoGenerateColumns = false;
            dsnguyenlieu.AllowUserToAddRows = false;
            dsnguyenlieu.DataSource = listNguyenLieu;

            DataGridViewTextBoxColumn clMa = new DataGridViewTextBoxColumn();
            clMa.Name = "maNL";
            clMa.HeaderText = "Mã nguyên liệu";
            clMa.DataPropertyName = "maNL";
            dsnguyenlieu.Columns.Add(clMa);

            DataGridViewTextBoxColumn clTen = new DataGridViewTextBoxColumn();
            clTen.Name = "tenNL";
            clTen.HeaderText = "Tên nguyên liệu";
            clTen.DataPropertyName = "tenNL";
            dsnguyenlieu.Columns.Add(clTen);

            DataGridViewTextBoxColumn clDonGia = new DataGridViewTextBoxColumn();
            clDonGia.Name = "Dongia";
            clDonGia.HeaderText = "Đơn giá";
            clDonGia.DataPropertyName = "Dongia";
            dsnguyenlieu.Columns.Add(clDonGia);

            DataGridViewTextBoxColumn clDonVi = new DataGridViewTextBoxColumn();
            clDonVi.Name = "Donvi";
            clDonVi.HeaderText = "Đơn vị";
            clDonVi.DataPropertyName = "Donvi";
            dsnguyenlieu.Columns.Add(clDonVi);

            DataGridViewTextBoxColumn clKho = new DataGridViewTextBoxColumn();
            clKho.Name = "trongKho";
            clKho.HeaderText = "Còn lại trong kho";
            clKho.DataPropertyName = "trongKho";
            dsnguyenlieu.Columns.Add(clKho);

            DataGridViewTextBoxColumn clHSD = new DataGridViewTextBoxColumn();
            clHSD.Name = "hsd";
            clHSD.HeaderText = "Hạn sử dụng";
            clHSD.DataPropertyName = "hsd";
            dsnguyenlieu.Columns.Add(clHSD);

            CurrencyManager myCurrencyManager = (CurrencyManager)this.BindingContext[dsnguyenlieu.DataSource];
            myCurrencyManager.Refresh();

        }
        bool testtext()//kiểm tra ô dữ liệu trống
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                System.Windows.MessageBox.Show("Bạn chưa nhập mã nguyên liệu.", "Lỗi");
                textBox1.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                System.Windows.MessageBox.Show("Bạn chưa nhập tên nguyên liệu.", "Lỗi");
                textBox2.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                System.Windows.MessageBox.Show("Bạn chưa nhập đơn giá.", "Lỗi");
                textBox3.Focus();
                return false;
            }
            
            if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                System.Windows.MessageBox.Show("Bạn chưa nhập đơn vị.", "Lỗi");
                textBox4.Focus();
                return false;
            }//gia 
            if (string.IsNullOrWhiteSpace(textBox5.Text))//quan
            {
                System.Windows.MessageBox.Show("Bạn chưa nhập số lượng tồn kho.", "Lỗi");
                textBox5.Focus();
                return false;
            }//don vi tinh      
            if (DateTime.Compare(dateTimePicker1.Value, DateTime.Today) < 0)
            {
                System.Windows.MessageBox.Show("Mặt hàng đã hết hạn sử dụng hoặc hạn sử dụng không đúng, vui lòng thử lại", "Lỗi");
                return false;
            }//check hạn sử dụng

            return true;//all true then gud to go
        }
        private void clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";           
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            dateTimePicker1.Value = DateTime.Today;
        }
        
    }
}
