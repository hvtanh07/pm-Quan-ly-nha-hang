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
    public class TaiKhoanDTO
    {
        private string username;
        private string manhanVien;
        private string password;
        private string type;

        public string Username { get => username; set => username = value; }
        public string manv { get => manhanVien; set => manhanVien = value; }
        public string Password { get => password; set => password = value; }
        public string Type { get => type; set => type = value; }
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
        public string mama { get => maMA; set => maMA = value; }
        public string mahd { get => maHD; set => maHD = value; }
        public int soluong { get => soLuong; set => soLuong = value; }
    }
    public class BanDTO
    {
        private int soBan;
        public int soban { get => soBan; set => soBan = value; }
    }
    public class dsBandadatDTO
    {
        private int soBan;
        private DateTime bookedDate;
        public int soban { get => soBan; set => soBan = value; }
        public DateTime bookeddate { get => bookedDate; set => bookedDate = value; }
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
    public class ChitietphieubcdtDTO
    {
        private string maPhieuBCDT;
        private string maHD;
        private int Tongtien;

        public string maphieuBCDT { get => maPhieuBCDT; set => maPhieuBCDT = value; }
        public string mahd { get => maHD; set => maHD = value; }
        public int tongtien { get => Tongtien; set => Tongtien = value; }
    }
    public class QuiDinhDTO
    {
        private int getkey;
        private int maxtogetsell;
        private int sellprice;
        private int percentnadd;
        private int luongtosum;
        private int workday;

        public int Getkey { get => getkey; set => getkey = value; }
        public int Maxtogetsell { get => maxtogetsell; set => maxtogetsell = value; }
        public int Sellprice { get => sellprice; set => sellprice = value; }
        public int Percentnadd { get => percentnadd; set => percentnadd = value; }
        public int Luongtosum { get => luongtosum; set => luongtosum = value; }
        public int Workday { get => workday; set => workday = value; }
    }
}