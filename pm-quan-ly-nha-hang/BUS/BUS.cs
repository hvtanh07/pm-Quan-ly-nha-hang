using DAL;
using DTO;
using System.Collections.Generic;

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

        public List<DSNguyenLieuDTO> select()
        {
            return dsnlDAL.select();
        }
        public bool TimNLtrongMA(string manl, string mama)
        {
            return dsnlDAL.TimNLtrongMA(manl,mama);
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
    
}