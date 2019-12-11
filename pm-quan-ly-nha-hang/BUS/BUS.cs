using DAL;
using DTO;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace BUS
{
    public class NguyenLieuBUS
    {
        private NguyenLieuDAL nlDAL;

        public NguyenLieuBUS()
        {
            nlDAL = new NguyenLieuDAL();
        }

        public bool Them(NguyenLieuDTO nl)
        {
            bool re = nlDAL.Them(nl);
            return re;
        }

        public bool Sua(NguyenLieuDTO nl)
        {
            bool re = nlDAL.Sua(nl);
            return re;
        }

        public bool Xoa(NguyenLieuDTO nl)
        {
            bool re = nlDAL.Xoa(nl);
            return re;
        }

        public List<NguyenLieuDTO> select()
        {
            return nlDAL.select();
        }

        public List<NguyenLieuDTO> selectByKeyWord(string sKeyword)
        {
            return nlDAL.selectByKeyWord(sKeyword);
        }

        public List<string> Laymanl()
        {
            return nlDAL.Laymanl();
        }
        public int Laygiatien(string ma)
        {
            return nlDAL.Laygiatien(ma);
        }
    }
    public class MonAnBUS
    {
        private MonAnDAL nlDAL;

        public MonAnBUS()
        {
            nlDAL = new MonAnDAL();
        }

        public bool Them(MonAnDTO ma)
        {
            bool re = nlDAL.Them(ma);
            return re;
        }

        public bool Sua(MonAnDTO ma)
        {
            bool re = nlDAL.Sua(ma);
            return re;
        }

        public bool Xoa(MonAnDTO ma)
        {
            bool re = nlDAL.Xoa(ma);
            return re;
        }

        public List<MonAnDTO> select()
        {
            return nlDAL.select();
        }

        public List<MonAnDTO> selectByKeyWord(string sKeyword)
        {
            return nlDAL.selectByKeyWord(sKeyword);
        }

        public List<string> Laymama()
        {
            return nlDAL.Laymama();
        }
        public int Laygia(string mama)
        {
            return nlDAL.Laygia(mama);
        }
    }
    public class DSNguyenLieuBUS
    {
        private DSNguyenLieuDAL dsnlDAL;

        public DSNguyenLieuBUS()
        {
            dsnlDAL = new DSNguyenLieuDAL();
        }

        public bool Them(DSNguyenLieuDTO ma)
        {
            bool re = dsnlDAL.Them(ma);
            return re;
        }

        public bool Xoa(DSNguyenLieuDTO ma)
        {
            bool re = dsnlDAL.Xoa(ma);
            return re;
        }

        public List<DSNguyenLieuDTO> select(string mama)
        {
            return dsnlDAL.select(mama);
        }
        public bool TimNLtrongMA(string manl, string mama)
        {
            return dsnlDAL.TimNLtrongMA(manl,mama);
        }
    }
    public class DSMonAnBUS
    {
        private DSMonAnDAL dsnlDAL;

        public DSMonAnBUS()
        {
            dsnlDAL = new DSMonAnDAL();
        }

        public bool Them(DSMonAnDTO ma)
        {
            bool re = dsnlDAL.Them(ma);
            return re;
        }

        public bool Xoa(DSMonAnDTO ma)
        {
            bool re = dsnlDAL.Xoa(ma);
            return re;
        }

        public List<DSMonAnDTO> select(string mahd)
        {
            return dsnlDAL.select(mahd);
        }
        public bool TimMAtrongHD(string mahd, string mama)
        {
            return dsnlDAL.TimMAtrongHD(mahd, mama);
        }
    }
    public class NhanVienBUS
    {
        private NhanVienDAL nvDAL;

        public NhanVienBUS()
        {
            nvDAL = new NhanVienDAL();
        }

        public bool Them(NhanVienDTO nv)
        {
            bool re = nvDAL.Them(nv);
            return re;
        }

        public bool Sua(NhanVienDTO nv)
        {
            bool re = nvDAL.Sua(nv);
            return re;
        }

        public bool Xoa(NhanVienDTO nv)
        {
            bool re = nvDAL.Xoa(nv);
            return re;
        }

        public List<NhanVienDTO> select()
        {
            return nvDAL.select();
        }

        public List<NhanVienDTO> selectByKeyWord(string sKeyword)
        {
            return nvDAL.selectByKeyWord(sKeyword);
        }

        public List<string> Laymanv()
        {
            return nvDAL.Laymanv();
        }
    }
    public class PhieubaocaoDoanhThuBUS
    {
        private PhieubaocaoDoanhThuDAL bcdtDAL;

        public PhieubaocaoDoanhThuBUS()
        {
            bcdtDAL = new PhieubaocaoDoanhThuDAL();
        }

        public bool Them(PhieubaocaoDoanhThuDTO ma)
        {
            bool re = bcdtDAL.Them(ma);
            return re;
        }

        public bool Sua(PhieubaocaoDoanhThuDTO ma)
        {
            bool re = bcdtDAL.Sua(ma);
            return re;
        }

        public bool Xoa(PhieubaocaoDoanhThuDTO ma)
        {
            bool re = bcdtDAL.Xoa(ma);
            return re;
        }

        public List<PhieubaocaoDoanhThuDTO> select()
        {
            return bcdtDAL.select();
        }

        public List<PhieubaocaoDoanhThuDTO> selectByKeyWord(string sKeyword)
        {
            return bcdtDAL.selectByKeyWord(sKeyword);
        }
        public bool CheckExist(int thang, int year)
        {
            return bcdtDAL.CheckExist(thang, year);
        }


    }
    public class ChitietphieubcdtBUS
    {
        private ChitietphieubcdtDAL ctbcdtDAL;

        public ChitietphieubcdtBUS()
        {
            ctbcdtDAL = new ChitietphieubcdtDAL();
        }

        public bool Them(ChitietphieubcdtDTO ma)
        {
            bool re = ctbcdtDAL.Them(ma);
            return re;
        }

        public bool Xoatheohoadon(string mahd)
        {
            bool re = ctbcdtDAL.Xoatheohoadon(mahd);
            return re;
        }
        public bool XoatheophieuBCDT(string mabcdt)
        {
            bool re = ctbcdtDAL.XoatheophieuBCDT(mabcdt);
            return re;
        }

        public List<ChitietphieubcdtDTO> select(string madt)
        {
            return ctbcdtDAL.select(madt);
        }

        public List<ChitietphieubcdtDTO> selectByKeyWord(string sKeyword, string madt)
        {
            return ctbcdtDAL.selectByKeyWord (sKeyword, madt);
        }
    }
    public class hoaDonBUS
    {
        private hoaDonDAL hdDAL;

        public hoaDonBUS()
        {
            hdDAL = new hoaDonDAL();
        }

        public bool Them(hoaDonDTO ma)
        {
            bool re = hdDAL.Them(ma);
            return re;
        }

        public bool Sua(hoaDonDTO ma)
        {
            bool re = hdDAL.Sua(ma);
            return re;
        }

        public bool Xoa(hoaDonDTO ma)
        {
            bool re = hdDAL.Xoa(ma);
            return re;
        }

        public List<hoaDonDTO> select()
        {
            return hdDAL.select();
        }

        public List<hoaDonDTO> selectByKeyWord(string sKeyword)
        {
            return hdDAL.selectByKeyWord(sKeyword);
        }
    }
    public class BanBUS
    {
        private BanDAL banDAL;

        public BanBUS()
        {
            banDAL = new BanDAL();
        }

        public bool Them(BanDTO ban)
        {
            bool re = banDAL.Them(ban);
            return re;
        }

        public bool Xoa(BanDTO ban)
        {
            bool re = banDAL.Xoa(ban);
            return re;
        }

        public List<BanDTO> select()
        {
            return banDAL.select();
        }
        public List<string> LaysoBan()
        {
            return banDAL.LaysoBan();
        }
    }
    public class dsBandadatBUS
    {
        private dsBandadatDAL ctbcdtDAL;

        public dsBandadatBUS()
        {
            ctbcdtDAL = new dsBandadatDAL();
        }

        public bool Them(dsBandadatDTO ma)
        {
            bool re = ctbcdtDAL.Them(ma);
            return re;
        }
        public bool Sua(dsBandadatDTO ma)
        {
            bool re = ctbcdtDAL.Sua(ma);
            return re;
        }

        public bool Xoa(dsBandadatDTO ma)
        {
            bool re = ctbcdtDAL.Xoa(ma);
            return re;
        }
       

        public List<dsBandadatDTO> select(string soban)
        {
            return ctbcdtDAL.select(soban);
        }

        public bool checkBookStatus(int soban, System.DateTime checkdate)
        {
            return ctbcdtDAL.checkBookStatus(soban, checkdate);
        }
    }
}