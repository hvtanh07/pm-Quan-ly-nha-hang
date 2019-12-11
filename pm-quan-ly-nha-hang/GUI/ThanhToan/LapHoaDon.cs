using System;
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

namespace GUI.ThanhToan
{
    public partial class LapHoaDon : Form
    {
        private MonAnBUS maBUS;
        private DSMonAnBUS dsmaBUS;
        private NhanVienBUS nvBUS;
        private BanDTO banDTO;

        // private DSMonAnBUS dsnlBUS;
        public LapHoaDon()
        {           
            InitializeComponent();
        }
        public LapHoaDon(BanDTO ban)
        {
            maBUS = new MonAnBUS();
            dsmaBUS = new DSMonAnBUS();
            nvBUS = new NhanVienBUS();
            banDTO = ban;           
            InitializeComponent();
            loadDataVaoComboBox();
            //loadData_Vao_GridView();
        }
        //them mon an
        private void button1_Click(object sender, EventArgs e)
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
            //Tinhtien();
        }

        private bool testtext1()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                System.Windows.MessageBox.Show("Bạn chưa nhập mã hóa đơn.", "Lỗi");
                textBox1.Focus();
                return false;
            }          
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                System.Windows.MessageBox.Show("Bạn chưa nhập số lượng món ăn.", "Lỗi");
                textBox2.Focus();
                return false;
            }
            return true;
        }
        private bool testtext2()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                System.Windows.MessageBox.Show("Bạn chưa nhập mã hóa đơn.", "Lỗi");
                textBox1.Focus();
                return false;
            }            
            return true;
        }
        private void loadDataVaoComboBox()
        {
            List<string> mama = new List<string>();
            mama = maBUS.Laymama();
            comboBox3.DataSource = mama;

            List<string> mathungan = new List<string>();
            mathungan = nvBUS.Laymanv();
            comboBox2.DataSource = mathungan;
        }

        //xac nhan 
        private void button2_Click(object sender, EventArgs e)
        {

        }
        private void LapHoaDon_Load(object sender, EventArgs e)
        {
            if (this.banDTO != null)
            {
                label9.Text = banDTO.soban.ToString();               
            }
        }
        private void loadData_Vao_GridView()
        {
            List<DSMonAnDTO> listMonAn = dsmaBUS.select(textBox1.Text);

            if (listMonAn == null)
            {
                MessageBox.Show("Có lỗi khi lấy món ăn từ cơ sở dữ liệu");
                return;
            }

            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = null;

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.DataSource = listMonAn;

            DataGridViewTextBoxColumn clMA = new DataGridViewTextBoxColumn();
            clMA.Name = "maMA";
            clMA.HeaderText = "Mã món ăn";
            clMA.DataPropertyName = "maMA";
            dataGridView1.Columns.Add(clMA);

            DataGridViewTextBoxColumn clSoLuong = new DataGridViewTextBoxColumn();
            clSoLuong.Name = "soLuong";
            clSoLuong.HeaderText = "Số lượng";
            clSoLuong.DataPropertyName = "soLuong";
            dataGridView1.Columns.Add(clSoLuong);

            CurrencyManager myCurrencyManager = (CurrencyManager)this.BindingContext[dataGridView1.DataSource];
            myCurrencyManager.Refresh();
        }
        //xoa mon an
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
                        //Tinhtien();
                    }
                }
            }
        }
    }
}
