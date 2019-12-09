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
    public partial class DatBan : Form
    {
        BanBUS banBUS;
        dsBandadatBUS dsbanBUS;
        public DatBan()
        {
            InitializeComponent();
        }
        //chuyen qua chon mon
        private void button1_Click(object sender, EventArgs e)
        {
            dsBandadatDTO ban = new dsBandadatDTO();
            ban.soban = int.Parse(comboBox1.Text);
            ban.bookeddate = dateTimePicker1.Value;
            //2. Kiểm tra data hợp lệ or not

            //3. Thêm vào DB
            bool kq = dsbanBUS.Them(ban);
            if (kq == false)
                System.Windows.MessageBox.Show("Thêm nhân viên thất bại. Vui lòng kiểm tra lại dũ liệu");
            else
            {
                System.Windows.MessageBox.Show("Thêm nhân viên thành công");
            }
            loadData_Vao_GridView(comboBox1.Text);
        }
        private void Loaddatavaocombo()
        {
            List<string> soban = new List<string>();
            soban = banBUS.LaysoBan();
            comboBox1.DataSource = soban;
        }
        private void DatBan_Load(object sender, EventArgs e)
        {
            banBUS = new BanBUS();
            dsbanBUS = new dsBandadatBUS();
            loadData_Vao_GridView(comboBox1.Text);
        }
        private void loadData_Vao_GridView(String soban)
        {
            List<dsBandadatDTO> listban = dsbanBUS.select(soban);

            if (listban == null)
            {
                MessageBox.Show("Có lỗi khi lấy nhân viên từ cơ sở dữ liệu");
                return;
            }

            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = null;

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.DataSource = listban;

            DataGridViewTextBoxColumn clMa = new DataGridViewTextBoxColumn();
            clMa.Name = "soBan";
            clMa.HeaderText = "Số bàn";
            clMa.DataPropertyName = "soBan";
            dataGridView1.Columns.Add(clMa);

            DataGridViewTextBoxColumn clDate = new DataGridViewTextBoxColumn();
            clDate.Name = "bookedDate";
            clDate.HeaderText = "Ngày đã được đặt";
            clDate.DataPropertyName = "bookedDate";
            dataGridView1.Columns.Add(clDate);

            CurrencyManager myCurrencyManager = (CurrencyManager)this.BindingContext[dataGridView1.DataSource];
            myCurrencyManager.Refresh();
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            loadData_Vao_GridView(comboBox1.Text);
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int currentRowIndex = dataGridView1.CurrentCellAddress.Y;// 'current row selected
            //'Verify that indexing OK
            if (-1 < currentRowIndex && currentRowIndex < dataGridView1.RowCount)
            {
                dsBandadatDTO ban = (dsBandadatDTO)dataGridView1.Rows[currentRowIndex].DataBoundItem;
                if (ban != null)
                {
                    bool kq = dsbanBUS.Xoa(ban);
                    if (kq == false)
                        MessageBox.Show("Xóa nhân viên thất bại. Vui lòng kiểm tra lại dũ liệu");
                    else
                    {
                        MessageBox.Show("Xóa nhân viên thành công");
                        this.loadData_Vao_GridView(comboBox1.Text);
                    }
                }
            }
        }       
    }
}
