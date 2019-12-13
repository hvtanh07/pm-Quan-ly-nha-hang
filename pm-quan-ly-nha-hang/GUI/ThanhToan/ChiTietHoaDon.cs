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

namespace GUI.ThanhToan
{
    public partial class ChiTietHoaDon : Form
    {
        private hoaDonDTO hoadon;
        private DSMonAnBUS dsmaBUS;
        private MonAnBUS maBUS;
        private hoaDonBUS hdBUS;
        private QuyDinhBUS qdBUS;
        private QuiDinhDTO quydinh;
        private int GiaTien;

        public ChiTietHoaDon()
        {
            InitializeComponent();
        }
        public ChiTietHoaDon(hoaDonDTO hoadon)
        {
            maBUS = new MonAnBUS();
            dsmaBUS = new DSMonAnBUS();
            hdBUS = new hoaDonBUS();
            qdBUS = new QuyDinhBUS();
            quydinh = qdBUS.Laydulieu();
            this.hoadon = hoadon;            
            InitializeComponent();
            loadDataVaoComboBox();
            loadData_Vao_GridView();
        }
        private void Tinhtien()
        {
            GiaTien = 0;//dataGridView1
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                int a = int.Parse(dataGridView1[1, i].Value.ToString());
                int b = maBUS.Laygia(dataGridView1[0, i].Value.ToString());
                GiaTien += a * b; 
            }
            //tính tiền giam gia
            if(GiaTien > quydinh.Maxtogetsell)
            {
                GiaTien -= quydinh.Sellprice;
            }
            textBox3.Text = GiaTien.ToString();//sau này công thêm phần trăm
        }
        //them mon an
        private void button1_Click(object sender, EventArgs e)
        {
            if (!testtext1())
            {
                return;
            }
            DSMonAnDTO dsnl = new DSMonAnDTO();
            dsnl.mama = comboBox3.Text;
            dsnl.mahd = textBox1.Text;
            dsnl.soluong = int.Parse(textBox2.Text);

            //2. Kiểm tra data hợp lệ or not
            if (dsmaBUS.TimMAtrongHD(dsnl.mahd, dsnl.mama))
            {
                System.Windows.MessageBox.Show("Thêm món ăn thất bại. món ăn đã tồn tại.");
                return;
            }
            //3. Thêm vào DB
            bool kq = dsmaBUS.Them(dsnl);
            if (kq == false)
                System.Windows.MessageBox.Show("Thêm món ăn thất bại. Vui lòng kiểm tra lại dũ liệu");
            else
            {
                System.Windows.MessageBox.Show("Thêm món ăn thành công");
            }
            loadData_Vao_GridView();
            Tinhtien();
        }
        //ket thuc sua
        private void button2_Click(object sender, EventArgs e)
        {
            //1. Map data from GUI
            hoaDonDTO ma = new hoaDonDTO();
            ma.mahd = textBox1.Text;
            ma.tongtien = int.Parse(textBox3.Text);            
            //2. Kiểm tra data hợp lệ or not

            //3. Thêm vào DB
            bool kq = hdBUS.SuaTien(ma);
            if (kq == false)
                MessageBox.Show("Sửa hóa đơn thất bại. Vui lòng kiểm tra lại dũ liệu");
            else
            {
                MessageBox.Show("Sửa hóa đơn thành công");
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
                DSMonAnDTO dsnl = (DSMonAnDTO)dataGridView1.Rows[currentRowIndex].DataBoundItem;
                if (dsnl != null)
                {
                    bool kq = dsmaBUS.Xoa(dsnl);
                    if (kq == false)
                        MessageBox.Show("Xóa món ăn thất bại. Vui lòng kiểm tra lại dũ liệu");
                    else
                    {
                        MessageBox.Show("Xóa món ăn thành công");
                        loadData_Vao_GridView();
                        Tinhtien();
                    }
                }
            }
        }
        private void loadDataVaoComboBox()
        {
            List<string> manl = new List<string>();
            manl = maBUS.Laymama();
            comboBox3.DataSource = manl;
        }
        private void ChiTietHoaDon_Load(object sender, EventArgs e)
        {
            if (this.hoadon != null)
            {               
                textBox1.Text = hoadon.mahd;
                textBox3.Text = hoadon.tongtien.ToString();
            }
        }
        private bool testtext1()
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                System.Windows.MessageBox.Show("Bạn chưa nhập số lượng món ăn.", "Lỗi");
                textBox2.Focus();
                return false;
            }
            return true;
        } 
        private void loadData_Vao_GridView()
        {
            List<DSMonAnDTO> listNguyenLieu = dsmaBUS.select(hoadon.mahd);

            if (listNguyenLieu == null)
            {
                MessageBox.Show("Có lỗi khi lấy nguyên liệu từ cơ sở dữ liệu");
                return;
            }

            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = null;

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.DataSource = listNguyenLieu;

            DataGridViewTextBoxColumn clNL = new DataGridViewTextBoxColumn();
            clNL.Name = "maMA";
            clNL.HeaderText = "Mã món ăn";
            clNL.DataPropertyName = "maMA";
            dataGridView1.Columns.Add(clNL);

            DataGridViewTextBoxColumn clSoLuong = new DataGridViewTextBoxColumn();
            clSoLuong.Name = "soLuong";
            clSoLuong.HeaderText = "Số lượng";
            clSoLuong.DataPropertyName = "soLuong";
            dataGridView1.Columns.Add(clSoLuong);

            CurrencyManager myCurrencyManager = (CurrencyManager)this.BindingContext[dataGridView1.DataSource];
            myCurrencyManager.Refresh();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (!testtext1())
            {
                return;
            }
            DSMonAnDTO dsnl = new DSMonAnDTO();
            dsnl.mahd = textBox1.Text;
            dsnl.mama = comboBox3.Text;
            dsnl.soluong = int.Parse(textBox2.Text);

            //2. Kiểm tra data hợp lệ or not
            if (dsmaBUS.TimMAtrongHD(dsnl.mahd, dsnl.mama))
            {
                System.Windows.MessageBox.Show("Thêm món ăn thất bại. nguyên liệu đã tồn tại.");
                return;
            }
            //3. Thêm vào DB
            bool kq = dsmaBUS.Them(dsnl);
            if (kq == false)
                System.Windows.MessageBox.Show("Thêm món ăn thất bại. Vui lòng kiểm tra lại dũ liệu");
            else
            {
                System.Windows.MessageBox.Show("Thêm món ăn thành công");
            }
            loadData_Vao_GridView();
            Tinhtien();
        }
    }
}
