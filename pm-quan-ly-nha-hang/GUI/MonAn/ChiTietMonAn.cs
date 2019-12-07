using DTO;
using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.MonAn
{
    public partial class ChiTietMonAn : Form
    {
        private MonAnBUS maBUS;
        private NguyenLieuBUS nlBUS;
        private DSNguyenLieuBUS dsnlBUS;
        private int GiaTien;

        private MonAnDTO maDTO;
        public ChiTietMonAn()
        {
            InitializeComponent();
        }
        public ChiTietMonAn(MonAnDTO ma)
        {
            maBUS = new MonAnBUS();
            nlBUS = new NguyenLieuBUS();
            dsnlBUS = new DSNguyenLieuBUS();
            this.maDTO = ma;
            GiaTien = ma.dongia;
            InitializeComponent();
            this.loadDataVaoComboBox();
            loadData_Vao_GridView();
        }
        private void Tinhtien()
        {
            GiaTien = 0;//dataGridView1
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                GiaTien = int.Parse(dataGridView1[1, i].Value.ToString())* nlBUS.Laygiatien(dataGridView1[0, i].Value.ToString());
            }
            textBox3.Text = GiaTien.ToString();//sau này công thêm phần trăm
        }
        //them nguyen lieu
        private void button1_Click(object sender, EventArgs e)
        {
            if (!testtext1())
            {
                return;
            }
            DSNguyenLieuDTO dsnl = new DSNguyenLieuDTO();
            dsnl.manl = comboBox1.Text;
            dsnl.mama = label6.Text;
            dsnl.soluong = int.Parse(textBox4.Text);
            
            //2. Kiểm tra data hợp lệ or not
            if (dsnlBUS.TimNLtrongMA(dsnl.manl, dsnl.mama))
            {
                System.Windows.MessageBox.Show("Thêm nguyên liệu thất bại. nguyên liệu đã tồn tại.");
                return;
            }
            //3. Thêm vào DB
            bool kq = dsnlBUS.Them(dsnl);
            if (kq == false)
                System.Windows.MessageBox.Show("Thêm nguyên liệu thất bại. Vui lòng kiểm tra lại dũ liệu");
            else
            {
                System.Windows.MessageBox.Show("Thêm nguyên liệu thành công");
            }
            loadData_Vao_GridView();
            Tinhtien();
        }
        //ket thuc sua
        private void button2_Click(object sender, EventArgs e)
        {
            if (!testtext2())
            {
                return;
            }
            //1. Map data from GUI
            MonAnDTO ma = new MonAnDTO();
            ma.mama = label6.Text;
            ma.tenma = textBox2.Text;
            ma.dongia = int.Parse(textBox3.Text);
            //2. Kiểm tra data hợp lệ or not

            //3. Thêm vào DB
            bool kq = maBUS.Sua(ma);
            if (kq == false)
                MessageBox.Show("Sửa món ăn thất bại. Vui lòng kiểm tra lại dũ liệu");
            else
            {
                MessageBox.Show("Sửa món ăn thành công");
                this.Close();
            }
        }
        //xoa nguyen lieu
        private void xóaMónĂnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int currentRowIndex = dataGridView1.CurrentCellAddress.Y;// 'current row selected
            //'Verify that indexing OK
            if (-1 < currentRowIndex && currentRowIndex < dataGridView1.RowCount)
            {
                DSNguyenLieuDTO dsnl = (DSNguyenLieuDTO)dataGridView1.Rows[currentRowIndex].DataBoundItem;
                if (dsnl != null)
                {
                    bool kq = dsnlBUS.Xoa(dsnl);
                    if (kq == false)
                        MessageBox.Show("Xóa nguyên liệu thất bại. Vui lòng kiểm tra lại dũ liệu");
                    else
                    {
                        MessageBox.Show("Xóa nguyên liệu thành công");
                        loadData_Vao_GridView();
                        Tinhtien();
                    }
                }
            }
        }
        private void loadDataVaoComboBox()
        {
            List<string> manl = new List<string>();
            manl = nlBUS.Laymanl();
            comboBox1.DataSource = manl;
        }

        private void ChiTietMonAn_Load(object sender, EventArgs e)
        {
            if (this.maDTO != null)
            {
                label6.Text = maDTO.mama;
                textBox2.Text = maDTO.tenma;
                textBox3.Text = maDTO.dongia.ToString();
            }
        }
        private bool testtext1()
        {
            if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                System.Windows.MessageBox.Show("Bạn chưa nhập số lượng nguyên liệu.", "Lỗi");
                textBox4.Focus();
                return false;
            }
            return true;
        }
        private bool testtext2()
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                System.Windows.MessageBox.Show("Bạn chưa nhập tên món ăn.", "Lỗi");
                textBox4.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                System.Windows.MessageBox.Show("Bạn chưa nhập đơn giá.", "Lỗi");
                textBox4.Focus();
                return false;
            }
            return true;
        }
        private void loadData_Vao_GridView()
        {
            List<DSNguyenLieuDTO> listNguyenLieu = dsnlBUS.select();

            if (listNguyenLieu == null)
            {
                MessageBox.Show("Có lỗi khi lấy Món ăn từ cơ sở dữ liệu");
                return;
            }

            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = null;

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.DataSource = listNguyenLieu;

            DataGridViewTextBoxColumn clNL = new DataGridViewTextBoxColumn();
            clNL.Name = "maNL";
            clNL.HeaderText = "Mã nguyên liệu";
            clNL.DataPropertyName = "maNL";
            dataGridView1.Columns.Add(clNL);

            DataGridViewTextBoxColumn clSoLuong = new DataGridViewTextBoxColumn();
            clSoLuong.Name = "soLuong";
            clSoLuong.HeaderText = "Số lượng";
            clSoLuong.DataPropertyName = "soLuong";
            dataGridView1.Columns.Add(clSoLuong);

            CurrencyManager myCurrencyManager = (CurrencyManager)this.BindingContext[dataGridView1.DataSource];
            myCurrencyManager.Refresh();
        }
    }
}
