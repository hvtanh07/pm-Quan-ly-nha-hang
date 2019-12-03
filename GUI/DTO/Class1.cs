using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NguyenLieuDTO
    {
        private string maNL;
        private string tenNL;
        private int donGia;
        private string donVi;
        private int trongKho;
        private DateTime HSD;

        public string manl { get => maNL; set => maNL = value; }
        public string tennl { get => tenNL; set => tenNL = value; }
        public int dongia { get => donGia; set => donGia = value; }
        public string donvi { get => donVi; set => donVi = value; }
        public int trongkho { get => trongKho; set => trongKho = value; } 
        public DateTime hsd { get => HSD; set => HSD = value; }
    }

    public class MonAnDTO
    {
        private string maMA;
        private string tenMA;

        public string mama { get => maMA; set => maMA = value; }
        public string tenma { get => tenMA; set => tenMA = value; }
    }

    public class DSNguyenLieuDTO
    {
        private string maNL;
        private string maMA;
        private int soLuong;

        public string manl { get => maNL; set => maNL = value; }
        public string mama { get => maMA; set => maMA = value; }
        public int soluong { get => soLuong; set => soLuong = value; }
    }

    public class MenuDTO
    {
        private string maMenu;
        private int tongTien;

        public string mamenu { get => maMenu; set => maMenu = value; }
        public int tongtien { get => tongTien; set => tongTien = value; }
    }

    public class DSMonAnDTO
    {
        private string maMA;
        private string maMenu;

        public string mama { get => maMA; set => maMA = value; }
        public string mamenu { get => maMenu; set => maMenu = value; }
    }

    public class khachHangDTO
    {
        private string tenKH;
        private string SDT;

        public string tenkh { get => tenKH; set => tenKH = value; }
        public string sdt { get => SDT; set => SDT = value; }
    }

    public class hoaDonDTO
    {
        private string maHD;
        private string tenKH;
        private int soBan;
        private int tongTien;
        public DateTime ngayThanhToan;
        private string maThuNgan;

        public string mahd { get => maHD; set => maHD = value; }
        public string tenkh { get => tenKH; set => tenKH = value; }
        public int soban { get => soBan; set => soBan = value; }
        public int tongtien { get => tongTien; set => tongTien = value; }
        public DateTime ngayTT { get => ngayThanhToan; set => ngayThanhToan = value; }
        public string maTN { get => maThuNgan; set => maThuNgan = value; }
    }

    public class PhieubaocaoDoanhThuDTO
    {
        private string maPhieuBCDT;
        private int tongDT;
        public DateTime ngayLapPhieu;

        public string maphieuBCDT { get => maPhieuBCDT; set => maPhieuBCDT = value; }
        public int tongdt { get => tongDT; set => tongDT = value; }
        public DateTime ngayLP { get => ngayLapPhieu; set => ngayLapPhieu = value; }
    }

    public class CTPhieubaocaoDoanhThuDTO
    {
        private string maPhieuBCDT;
        private string maHD;

        public string maphieuBCDT { get => maPhieuBCDT; set => maPhieuBCDT = value; }
        public string mahd { get => maHD; set => maHD = value; }
    }
}
