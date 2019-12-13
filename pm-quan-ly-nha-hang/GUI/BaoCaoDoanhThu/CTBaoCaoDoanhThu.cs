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

namespace GUI.BaoCaoDoanhThu
{
    public partial class CTBaoCaoDoanhThu : Form
    {
        PhieubaocaoDoanhThuBUS bcdtBUS;
        ChitietphieubcdtBUS ctbcdtBUS;
        
        public CTBaoCaoDoanhThu()
        {           
            InitializeComponent();
        }
        
        private void BaoCaoDoanhThu_Load(object sender, EventArgs e)
        {
            bcdtBUS = new PhieubaocaoDoanhThuBUS();
            ctbcdtBUS = new ChitietphieubcdtBUS();
            loadData_Vao_GridView();
        }
        //add
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã phiếu");
                textBox1.Focus();
                return;
            }
            PhieubaocaoDoanhThuDTO dt = new PhieubaocaoDoanhThuDTO();
            dt.maphieuBCDT = textBox1.Text;
            dt.ngayLapPhieu = DateTime.Today;
            dt.tongdt = 0;
            if (bcdtBUS.CheckExist(DateTime.Today.Month, DateTime.Today.Year))
            {
                MessageBox.Show("Thêm hồ sơ thất bại. Tháng này đã có phiếu báo cáo doanh thu");
                return;
            }
            bool kq = bcdtBUS.Them(dt);
            if (kq == false)
                MessageBox.Show("Thêm hồ sơ thất bại. Vui lòng kiểm tra lại dũ liệu");
            else
            {
                MessageBox.Show("Thêm hồ sơ thành công");
                textBox1.Text = "";
                ChitietBaoCaoDoanhThu frm = new ChitietBaoCaoDoanhThu(dt,true);
                frm.ShowDialog();
            }
            loadData_Vao_GridView();
        }
        //search
        private void button2_Click(object sender, EventArgs e)
        {
            string sKeyword = textBox2.Text.Trim();
            if (sKeyword == null || sKeyword == string.Empty || sKeyword.Length == 0) // tìm tất cả
            {
                List<PhieubaocaoDoanhThuDTO> listpbcdt = bcdtBUS.select();
                this.loadData_Vao_GridView(listpbcdt);
            }
            else
            {
                List<PhieubaocaoDoanhThuDTO> listpbcdt = bcdtBUS.selectByKeyWord(sKeyword);
                this.loadData_Vao_GridView(listpbcdt);
            }
        }
        //xoa
        private void xóaPhiếuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int currentRowIndex = dataGridView1.CurrentCellAddress.Y;// 'current row selected
            //'Verify that indexing OK
            if (-1 < currentRowIndex && currentRowIndex < dataGridView1.RowCount)
            {
                PhieubaocaoDoanhThuDTO ma = (PhieubaocaoDoanhThuDTO)dataGridView1.Rows[currentRowIndex].DataBoundItem;
                if (ma != null)
                {
                    bool kq1 = ctbcdtBUS.XoatheophieuBCDT(ma.maphieuBCDT);
                    bool kq2 = bcdtBUS.Xoa(ma);
                    if (!kq1 && !kq2)
                        MessageBox.Show("Xóa phiếu thất bại. Vui lòng kiểm tra lại dũ liệu");
                    else
                    {
                        MessageBox.Show("Xóa phiếu thành công");
                        this.loadData_Vao_GridView();
                    }
                }
            }
        }
        //xem chi tiet
        private void xemChiTiếtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int currentRowIndex = dataGridView1.CurrentCellAddress.Y;// 'current row selected


            //'Verify that indexing OK
            if (-1 < currentRowIndex && currentRowIndex < dataGridView1.RowCount)
            {
                PhieubaocaoDoanhThuDTO ma = (PhieubaocaoDoanhThuDTO)dataGridView1.Rows[currentRowIndex].DataBoundItem;
                if (ma != null)
                {
                    ChitietBaoCaoDoanhThu frm = new ChitietBaoCaoDoanhThu(ma,false);
                    frm.ShowDialog();
                    loadData_Vao_GridView();
                }
            }
        }
        private void loadData_Vao_GridView()
        {
            List<PhieubaocaoDoanhThuDTO> listpbcdt = bcdtBUS.select();

            if (listpbcdt == null)
            {
                MessageBox.Show("Có lỗi khi lấy phiếu từ cơ sở dữ liệu");
                return;
            }

            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = null;

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.DataSource = listpbcdt;

            DataGridViewTextBoxColumn clMa = new DataGridViewTextBoxColumn();
            clMa.Name = "maphieuBCDT";
            clMa.HeaderText = "Mã phiếu báo cáo doanh thu";
            clMa.DataPropertyName = "maphieuBCDT";
            dataGridView1.Columns.Add(clMa);

            DataGridViewTextBoxColumn cldt = new DataGridViewTextBoxColumn();
            cldt.Name = "tongdt";
            cldt.HeaderText = "Tổng doanh thu";
            cldt.DataPropertyName = "tongdt";
            dataGridView1.Columns.Add(cldt);

            DataGridViewTextBoxColumn clngaylap = new DataGridViewTextBoxColumn();
            clngaylap.Name = "ngayLP";
            clngaylap.HeaderText = "Ngày lập phiếu";
            clngaylap.DataPropertyName = "ngayLP";
            dataGridView1.Columns.Add(clngaylap);            

            CurrencyManager myCurrencyManager = (CurrencyManager)this.BindingContext[dataGridView1.DataSource];
            myCurrencyManager.Refresh();
        }
        private void loadData_Vao_GridView(List<PhieubaocaoDoanhThuDTO> listpbcdt)
        {
            if (listpbcdt == null)
            {
                MessageBox.Show("Có lỗi khi lấy phiếu từ DB");
                return;
            }

            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = null;

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.DataSource = listpbcdt;

            DataGridViewTextBoxColumn clMa = new DataGridViewTextBoxColumn();
            clMa.Name = "maphieuBCDT";
            clMa.HeaderText = "Mã phiếu báo cáo doanh thu";
            clMa.DataPropertyName = "maphieuBCDT";
            dataGridView1.Columns.Add(clMa);

            DataGridViewTextBoxColumn cldt = new DataGridViewTextBoxColumn();
            cldt.Name = "tongdt";
            cldt.HeaderText = "Tổng doanh thu";
            cldt.DataPropertyName = "tongdt";
            dataGridView1.Columns.Add(cldt);

            DataGridViewTextBoxColumn clngaylap = new DataGridViewTextBoxColumn();
            clngaylap.Name = "ngayLP";
            clngaylap.HeaderText = "Ngày lập phiếu";
            clngaylap.DataPropertyName = "ngayLP";
            dataGridView1.Columns.Add(clngaylap);

            CurrencyManager myCurrencyManager = (CurrencyManager)this.BindingContext[dataGridView1.DataSource];
            myCurrencyManager.Refresh();
        }

       
    }
}
