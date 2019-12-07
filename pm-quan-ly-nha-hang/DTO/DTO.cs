using System;

namespace DTO
{
    public class NhanVienDTO
    {
        private string manhanVien;
        private string tennhanVien;
        private DateTime Birth;
        private int luongCoBan;
        private string chucVu;
       
        public string manv { get => manhanVien; set => manhanVien = value; }
        public string tennv { get => tennhanVien; set => tennhanVien = value; }
        public string chucvu { get => chucVu; set => chucVu = value; }
        public int luongcoban { get => luongCoBan; set => luongCoBan = value; }
        public DateTime birth { get => Birth; set => Birth = value; }
    }
    public class PhucVuDTO
    {
        private string maphucVu;
        private int soBanDaPhucVu;
        private int thuongTheoBan;

        public string maphucvu { get => maphucVu; set => maphucVu = value; }
        public int sobanphucvu { get => soBanDaPhucVu; set => soBanDaPhucVu = value; }
        public int thuongtheoban { get => thuongTheoBan; set => thuongTheoBan = value; }
    }
    public class QuanLyDTO
    {
        private string maquanLy;
        private int kpi;
        private int luongDatkpi;

        public string maquanly { get => maquanLy; set => maquanLy = value; }
        public int KPI { get => kpi; set => kpi = value; }
        public int luongdatkpi { get => luongDatkpi; set => luongDatkpi = value; }
    }
    public class ThuNganDTO
    {
        private string mathuNgan;
        private int gioLam;
        private int thuongGioLam;

        public string mathungan { get => mathuNgan; set => mathuNgan = value; }
        public int giolam { get => gioLam; set => gioLam = value; }
        public int thuonggiolam { get => thuongGioLam; set => thuongGioLam = value; }
    }
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
        private int donGia;

        public string mama { get => maMA; set => maMA = value; }
        public string tenma { get => tenMA; set => tenMA = value; }
        public int dongia { get => donGia; set => donGia = value; }

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
    public class DSMonAnDTO
    {
        private string maMA;
        private string maHD;
        private int soLuong;
        private int giaTien;
        public string mama { get => maMA; set => maMA = value; }
        public string mahd { get => maHD; set => maHD = value; }
        public int soluong { get => soLuong; set => soLuong = value; }
        public int giatien { get => giaTien; set => giaTien = value; }
    }
    public class hoaDonDTO
    {
        private string maHD;
        private int soBan;
        private int tongTien;
        public DateTime ngayThanhToan;
        private string maThuNgan;

        public string mahd { get => maHD; set => maHD = value; }
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