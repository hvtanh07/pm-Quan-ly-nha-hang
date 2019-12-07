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
    public partial class QuanLyNhanVien : Form
    {
        private NhanVienBUS nvBUS;
        public QuanLyNhanVien()
        {
            InitializeComponent();
        }
        private void QuanLyNhanVien_Load(object sender, EventArgs e)
        {
            nvBUS = new NhanVienBUS();
            loadData_Vao_GridView();
            clear();
        }
        //them
        private void button1_Click(object sender, EventArgs e)
        {
            if (!testtext())
            {
                return;
            }
            NhanVienDTO nv = new NhanVienDTO();
            nv.manv = textBox1.Text;
            nv.tennv = textBox2.Text;
            nv.luongcoban = int.Parse(textBox4.Text);
            nv.chucvu = textBox5.Text;
            nv.birth = dateTimePicker1.Value;
            //2. Kiểm tra data hợp lệ or not

            //3. Thêm vào DB
            bool kq = nvBUS.Them(nv);
            if (kq == false)
                System.Windows.MessageBox.Show("Thêm nhân viên thất bại. Vui lòng kiểm tra lại dũ liệu");
            else
            {
                System.Windows.MessageBox.Show("Thêm nhân viên thành công");
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
                List<NhanVienDTO> listNhanVien = nvBUS.select();
                this.loadData_Vao_GridView(listNhanVien);
            }
            else
            {
                List<NhanVienDTO> listNhanVien = nvBUS.selectByKeyWord(sKeyword);
                this.loadData_Vao_GridView(listNhanVien);
            }
        }
        //xoa
        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int currentRowIndex = dataGridView1.CurrentCellAddress.Y;// 'current row selected
            //'Verify that indexing OK
            if (-1 < currentRowIndex && currentRowIndex < dataGridView1.RowCount)
            {
                NhanVienDTO kn = (NhanVienDTO)dataGridView1.Rows[currentRowIndex].DataBoundItem;
                if (kn != null)
                {
                    bool kq = nvBUS.Xoa(kn);
                    if (kq == false)
                        MessageBox.Show("Xóa nhân viên thất bại. Vui lòng kiểm tra lại dũ liệu");
                    else
                    {
                        MessageBox.Show("Xóa nhân viên thành công");
                        this.loadData_Vao_GridView();
                    }
                }
            }
        }
        //sua
        private void sửaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int currentRowIndex = dataGridView1.CurrentCellAddress.Y;// 'current row selected


            //'Verify that indexing OK
            if (-1 < currentRowIndex && currentRowIndex < dataGridView1.RowCount)
            {
                NhanVienDTO nv = (NhanVienDTO)dataGridView1.Rows[currentRowIndex].DataBoundItem;
                if (nv != null)
                {
                    SuaNhanVien frm = new SuaNhanVien(nv);
                    frm.ShowDialog();
                    loadData_Vao_GridView();
                }
            }
        }
        private void loadData_Vao_GridView()
        {
            List<NhanVienDTO> listNhanVien = nvBUS.select();

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

            DataGridViewTextBoxColumn clMa = new DataGridViewTextBoxColumn();
            clMa.Name = "maNV";
            clMa.HeaderText = "Mã nhân viên";
            clMa.DataPropertyName = "maNV";
            dataGridView1.Columns.Add(clMa);

            DataGridViewTextBoxColumn clTen = new DataGridViewTextBoxColumn();
            clTen.Name = "tenNV";
            clTen.HeaderText = "Tên nhân viên";
            clTen.DataPropertyName = "tenNV";
            dataGridView1.Columns.Add(clTen);

            DataGridViewTextBoxColumn clbirth = new DataGridViewTextBoxColumn();
            clbirth.Name = "Birth";
            clbirth.HeaderText = "Ngày sinh";
            clbirth.DataPropertyName = "Birth";
            dataGridView1.Columns.Add(clbirth);

            DataGridViewTextBoxColumn clLuong = new DataGridViewTextBoxColumn();
            clLuong.Name = "luongCoBan";
            clLuong.HeaderText = "Lương cơ bản";
            clLuong.DataPropertyName = "luongCoBan";
            dataGridView1.Columns.Add(clLuong);

            DataGridViewTextBoxColumn clChucvu = new DataGridViewTextBoxColumn();
            clChucvu.Name = "chucVu";
            clChucvu.HeaderText = "Chức vụ";
            clChucvu.DataPropertyName = "chucVu";
            dataGridView1.Columns.Add(clChucvu);

            CurrencyManager myCurrencyManager = (CurrencyManager)this.BindingContext[dataGridView1.DataSource];
            myCurrencyManager.Refresh();
        }
        private void loadData_Vao_GridView(List<NhanVienDTO> listNhanVien)
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

            DataGridViewTextBoxColumn clMa = new DataGridViewTextBoxColumn();
            clMa.Name = "maNV";
            clMa.HeaderText = "Mã nhân viên";
            clMa.DataPropertyName = "maNV";
            dataGridView1.Columns.Add(clMa);

            DataGridViewTextBoxColumn clTen = new DataGridViewTextBoxColumn();
            clTen.Name = "tenNV";
            clTen.HeaderText = "Tên nhân viên";
            clTen.DataPropertyName = "tenNV";
            dataGridView1.Columns.Add(clTen);

            DataGridViewTextBoxColumn clbirth = new DataGridViewTextBoxColumn();
            clbirth.Name = "Birth";
            clbirth.HeaderText = "Ngày sinh";
            clbirth.DataPropertyName = "Birth";
            dataGridView1.Columns.Add(clbirth);

            DataGridViewTextBoxColumn clLuong = new DataGridViewTextBoxColumn();
            clLuong.Name = "luongCoBan";
            clLuong.HeaderText = "Lương cơ bản";
            clLuong.DataPropertyName = "luongCoBan";
            dataGridView1.Columns.Add(clLuong);

            DataGridViewTextBoxColumn clChucvu = new DataGridViewTextBoxColumn();
            clChucvu.Name = "chucVu";
            clChucvu.HeaderText = "Chức vụ";
            clChucvu.DataPropertyName = "chucVu";
            dataGridView1.Columns.Add(clChucvu);

            CurrencyManager myCurrencyManager = (CurrencyManager)this.BindingContext[dataGridView1.DataSource];
            myCurrencyManager.Refresh();

        }
        bool testtext()//kiểm tra ô dữ liệu trống
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                System.Windows.MessageBox.Show("Bạn chưa nhập mã nhân viên.", "Lỗi");
                textBox1.Focus();
                return false;
            }
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
            if (string.IsNullOrWhiteSpace(textBox5.Text))//quan
            {
                System.Windows.MessageBox.Show("Bạn chưa nhập số chức vụ của nhân viên.", "Lỗi");
                textBox5.Focus();
                return false;
            }//don vi tinh      
            if (DateTime.Compare(dateTimePicker1.Value, DateTime.Today) > 0)
            {
                System.Windows.MessageBox.Show("Ngày sinh sai hoặc ngày sinh không đúng, vui lòng thử lại", "Lỗi");
                return false;
            }//check hạn sử dụng

            return true;//all true then gud to go
        }
        private void clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            dateTimePicker1.Value = DateTime.Today;
        }
    }
}
