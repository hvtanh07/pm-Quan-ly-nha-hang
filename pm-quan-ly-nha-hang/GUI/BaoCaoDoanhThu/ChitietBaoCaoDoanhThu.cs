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
    public partial class ChitietBaoCaoDoanhThu : Form
    {
        private PhieubaocaoDoanhThuDTO bcdt;
        private PhieubaocaoDoanhThuBUS bcdtBUS;
        private ChitietphieubcdtBUS ctbcdtBUS;
        private Boolean xemornot;
        private int GiaTien;
        public ChitietBaoCaoDoanhThu()
        {
            InitializeComponent();
        }
        public ChitietBaoCaoDoanhThu(PhieubaocaoDoanhThuDTO bcdt, Boolean watch)
        {
            this.bcdt = bcdt;
            bcdtBUS = new PhieubaocaoDoanhThuBUS();
            ctbcdtBUS = new ChitietphieubcdtBUS();
            xemornot = watch;
            InitializeComponent();
            if (watch) { 
                loadData_Vao_GridView();
            }
            else
            {
                loadData_Vao_GridViewXem();
                button1.Enabled = false;
            }
            Tinhtien();
        }
        private void Tinhtien()
        {
            GiaTien = 0;//dataGridView1
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                GiaTien += int.Parse(dataGridView1[1, i].Value.ToString());
            }

            label4.Text = GiaTien.ToString();
        }
        private void ChitietBaoCaoDoanhThu_Load_1(object sender, EventArgs e)
        {
            if (bcdt != null)
            {
                label6.Text = bcdt.maphieuBCDT;
                label5.Text = bcdt.ngayLapPhieu.Month.ToString();
            }
        }       
        private void loadData_Vao_GridView()
        {
            List<ChitietphieubcdtDTO> listpbcdt = ctbcdtBUS.laydoanhthu(bcdt.ngayLapPhieu.Month, bcdt.ngayLapPhieu.Year);

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

            DataGridViewTextBoxColumn clMahd = new DataGridViewTextBoxColumn();
            clMahd.Name = "maHD";
            clMahd.HeaderText = "Mã hóa đơn";
            clMahd.DataPropertyName = "maHD";
            dataGridView1.Columns.Add(clMahd);

            DataGridViewTextBoxColumn cltien = new DataGridViewTextBoxColumn();
            cltien.Name = "tongtien";
            cltien.HeaderText = "Tổng tiền";
            cltien.DataPropertyName = "tongtien";
            dataGridView1.Columns.Add(cltien);

            CurrencyManager myCurrencyManager = (CurrencyManager)this.BindingContext[dataGridView1.DataSource];
            myCurrencyManager.Refresh();         
        }
        private void loadData_Vao_GridViewXem()
        {
            List<ChitietphieubcdtDTO> listpbcdt = ctbcdtBUS.select(bcdt.maphieuBCDT);

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

            DataGridViewTextBoxColumn clMahd = new DataGridViewTextBoxColumn();
            clMahd.Name = "maHD";
            clMahd.HeaderText = "Mã hóa đơn";
            clMahd.DataPropertyName = "maHD";
            dataGridView1.Columns.Add(clMahd);

            DataGridViewTextBoxColumn cltien = new DataGridViewTextBoxColumn();
            cltien.Name = "tongtien";
            cltien.HeaderText = "Tổng tiền";
            cltien.DataPropertyName = "tongtien";
            dataGridView1.Columns.Add(cltien);

            CurrencyManager myCurrencyManager = (CurrencyManager)this.BindingContext[dataGridView1.DataSource];
            myCurrencyManager.Refresh();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            bool check = true;
            ChitietphieubcdtDTO ctbc = new ChitietphieubcdtDTO();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                ctbc.maphieuBCDT = label6.Text;
                ctbc.mahd = row.Cells[0].Value.ToString();
                ctbc.tongtien = int.Parse(row.Cells[1].Value.ToString());
                check = ctbcdtBUS.Them(ctbc);
                if (check == false)
                {
                    MessageBox.Show("Lưu thông tin phiếu thất bại. Vui lòng kiểm tra lại dũ liệu");
                    return;
                }
            }
            PhieubaocaoDoanhThuDTO bcdtnew = new PhieubaocaoDoanhThuDTO();
            bcdtnew.maphieuBCDT = bcdt.maphieuBCDT;
            bcdtnew.ngayLapPhieu = bcdt.ngayLapPhieu;
            bcdtnew.tongdt = GiaTien;
            bool kq = bcdtBUS.Sua(bcdtnew);
            if (kq == false)
                MessageBox.Show("Lưu thông tin phiếu thất bại. Vui lòng kiểm tra lại dũ liệu");
            else
            {
                MessageBox.Show("Lưu thông tin phiếu thành công");
                this.Close();
            }
        }  
    }
}
