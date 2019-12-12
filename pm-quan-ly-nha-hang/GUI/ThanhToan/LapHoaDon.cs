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
        private hoaDonBUS hdBUS;
        private DSMonAnBUS dsmaBUS;
        private NhanVienBUS nvBUS;
        private BanDTO banDTO;

        // private DSMonAnBUS dsnlBUS;
        public LapHoaDon()
        {
            dsmaBUS = new DSMonAnBUS();
            hdBUS = new hoaDonBUS();
            nvBUS = new NhanVienBUS();
            InitializeComponent();
            loadDataVaoComboBox();
            loadData_Vao_GridView();
        }
        public LapHoaDon(BanDTO ban)
        {
            dsmaBUS = new DSMonAnBUS();
            hdBUS = new hoaDonBUS();
            nvBUS = new NhanVienBUS();
            banDTO = ban;
            InitializeComponent();
            loadDataVaoComboBox();
            loadData_Vao_GridView();
        }
        private bool testtext()
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
            List<string> mathungan = new List<string>();
            mathungan = nvBUS.Laymanv();
            comboBox2.DataSource = mathungan;
        }

        //xac nhan 
        private void button2_Click(object sender, EventArgs e)
        {
            if (!testtext())
            {
                return;
            }
            hoaDonDTO ma = new hoaDonDTO();
            ma.mahd = textBox1.Text;
            ma.maTN = comboBox2.Text;
            ma.ngayThanhToan = dateTimePicker1.Value;
            ma.soban = int.Parse(textBox3.Text);
            ma.tongtien = 0;

            //2. Kiểm tra data hợp lệ or not

            //3. Thêm vào DB
            bool kq = hdBUS.Them(ma);
            if (kq == false)
                System.Windows.MessageBox.Show("Thêm hóa đơn thất bại. Vui lòng kiểm tra lại dũ liệu");
            else
            {
                System.Windows.MessageBox.Show("Thêm hóa đơn thành công");
                clear();
                ChiTietHoaDon frm = new ChiTietHoaDon(ma);
                frm.ShowDialog();
                loadData_Vao_GridView();             
            }
            loadData_Vao_GridView();
        }
        private void clear (){
            textBox1.Text = "";
        }
        private void LapHoaDon_Load(object sender, EventArgs e)
        {
            if (this.banDTO != null)
            {
                textBox3.Text = banDTO.soban.ToString();
                textBox3.ReadOnly = true;
            }
        }
        private void loadData_Vao_GridView()
        {
            List<hoaDonDTO> listMonAn = hdBUS.select();

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
            clMA.Name = "maHD";
            clMA.HeaderText = "Mã hóa đơn";
            clMA.DataPropertyName = "maHD";
            dataGridView1.Columns.Add(clMA);

            DataGridViewTextBoxColumn clSoBan = new DataGridViewTextBoxColumn();
            clSoBan.Name = "soBan";
            clSoBan.HeaderText = "Số bàn";
            clSoBan.DataPropertyName = "soBan";
            dataGridView1.Columns.Add(clSoBan);

            DataGridViewTextBoxColumn cltongTien = new DataGridViewTextBoxColumn();
            cltongTien.Name = "tongTien";
            cltongTien.HeaderText = "Tổng tiền";
            cltongTien.DataPropertyName = "tongTien";
            dataGridView1.Columns.Add(cltongTien);

            DataGridViewTextBoxColumn clpaydate = new DataGridViewTextBoxColumn();
            clpaydate.Name = "ngayTT";
            clpaydate.HeaderText = "Ngày thanh toán";
            clpaydate.DataPropertyName = "ngayTT";
            dataGridView1.Columns.Add(clpaydate);

            DataGridViewTextBoxColumn clMaTN = new DataGridViewTextBoxColumn();
            clMaTN.Name = "maTN";
            clMaTN.HeaderText = "Mã thu ngân";
            clMaTN.DataPropertyName = "maTN";
            dataGridView1.Columns.Add(clMaTN);

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
                hoaDonDTO dsnl = (hoaDonDTO)dataGridView1.Rows[currentRowIndex].DataBoundItem;
                if (dsnl != null)
                {
                    bool kq2 = dsmaBUS.XoatheoHD(dsnl.mahd);
                    bool kq1 = hdBUS.Xoa(dsnl);
                    if (!kq1 && !kq2)
                        MessageBox.Show("Xóa hóa đơn thất bại. Vui lòng kiểm tra lại dũ liệu");
                    else
                    {
                        MessageBox.Show("Xóa hóa đơn thành công");
                        loadData_Vao_GridView();
                        //Tinhtien();
                    }
                }
            }
        }
        //search
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void xemChiTiếtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int currentRowIndex = dataGridView1.CurrentCellAddress.Y;// 'current row selected

            //'Verify that indexing OK
            if (-1 < currentRowIndex && currentRowIndex < dataGridView1.RowCount)
            {
                hoaDonDTO ma = (hoaDonDTO)dataGridView1.Rows[currentRowIndex].DataBoundItem;
                if (ma != null)
                {
                    ChiTietHoaDon frm = new ChiTietHoaDon(ma);
                    frm.ShowDialog();
                    loadData_Vao_GridView();
                }
            }
        }
    }
}
