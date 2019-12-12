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
        public ChitietBaoCaoDoanhThu()
        {
            InitializeComponent();
        }
        public ChitietBaoCaoDoanhThu(PhieubaocaoDoanhThuDTO bcdt)
        {
            this.bcdt = bcdt;
            bcdtBUS = new PhieubaocaoDoanhThuBUS();
            ctbcdtBUS = new ChitietphieubcdtBUS();
            InitializeComponent();
        }

        private void ChitietBaoCaoDoanhThu_Load(object sender, EventArgs e)
        {
            if (bcdt != null)
            {
                label6.Text = bcdt.maphieuBCDT;
                label5.Text = bcdt.ngayLapPhieu.Month.ToString();
                label4.Text = bcdt.tongdt.ToString();
            }                     
        }
        private void loadData_Vao_GridView()
        {
            List<ChitietphieubcdtDTO> listctpx = ctbcdtBUS.laydoanhthu(bcdtDTO.ngaylap.Month, bcdtDTO.ngaylap.Year);

            if (listctpx == null)
            {
                MessageBox.Show("Có lỗi khi lấy hồ sơ từ DB");
                return;
            }
            dsDL.ItemsSource = listctpx;
        }
        private void loadData_Vao_GridViewXem()
        {
            List<ChitietphieubcdtDTO> listctpx = ctbcdtBUS.select(Matxt.Text);

            if (listctpx == null)
            {
                MessageBox.Show("Có lỗi khi lấy hồ sơ từ DB");
                return;
            }
            dsDL.ItemsSource = listctpx;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            bool check = true;
            foreach (ChitietphieubcdtDTO row in dataGridView1.DataSource)
            {
                row.madt = bcdtDTO.madt;
                check = ctbcdtBUS.Them(row);
            }
            if (check == false)
                MessageBox.Show("Lưu thông tin phiếu thất bại. Vui lòng kiểm tra lại dũ liệu");
            else
            {
                PhieubaocaodtDTO bcds = new PhieubaocaodtDTO();
                bcds.madt = bcdtDTO.madt;
                bcds.tongdt = tongtien;
                bool kq = bcdtBUS.Sua(bcds);
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
}
