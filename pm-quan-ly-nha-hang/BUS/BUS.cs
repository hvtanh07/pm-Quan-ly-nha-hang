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

        public bool Them(NguyenLieuDTO hs)
        {
            bool re = nlDAL.Them(hs);
            return re;
        }

        public bool Sua(NguyenLieuDTO hs)
        {
            bool re = nlDAL.Sua(hs);
            return re;
        }

        public bool Xoa(NguyenLieuDTO hs)
        {
            bool re = nlDAL.Xoa(hs);
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

        public List<string> Laymadl()
        {
            return nlDAL.Laymadl();
        }
    }
}