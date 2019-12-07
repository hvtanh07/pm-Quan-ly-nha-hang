using DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace DAL
{
    public class NguyenLieuDAL
    {
        private string connectionString;

        public NguyenLieuDAL()
        {
            connectionString = ConfigurationManager.AppSettings["ConnectionString"];
        }

        public string ConnectionString { get => connectionString; set => connectionString = value; }

        public bool Them(NguyenLieuDTO NL)
        {
            string query = string.Empty;
            query += " INSERT INTO [tblNguyenLieu] ([maNguyenLieu], [tenNguyenLieu], [dongia],[donVi], [trongKho], [HSD])";
            query += " VALUES (@maNguyenLieu, @tenNguyenLieu, @dongia, @donVi, @trongKho,@HSD)";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@maNguyenLieu", NL.manl);
                    cmd.Parameters.AddWithValue("@tenNguyenLieu", NL.tennl);
                    cmd.Parameters.AddWithValue("@dongia", NL.dongia);
                    cmd.Parameters.AddWithValue("@donVi", NL.donvi);
                    cmd.Parameters.AddWithValue("@trongKho", NL.trongkho);
                    cmd.Parameters.AddWithValue("@HSD", NL.hsd);

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        con.Dispose();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        return false;
                    }
                }
            }
            return true;
        }

        public bool Sua(NguyenLieuDTO NL)
        {
            string query = string.Empty;
            query += " UPDATE tblNguyenLieu SET [tenNguyenLieu] = @tenNguyenLieu, [dongia] = @dongia, [donVi] = @donVi, [trongKho] = @trongKho, [HSD] = @HSD WHERE [maNguyenLieu] = @maNguyenLieu";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@maNguyenLieu", NL.manl);
                    cmd.Parameters.AddWithValue("@tenNguyenLieu", NL.tennl);
                    cmd.Parameters.AddWithValue("@dongia", NL.dongia);
                    cmd.Parameters.AddWithValue("@donVi", NL.donvi);
                    cmd.Parameters.AddWithValue("@trongKho", NL.trongkho);
                    cmd.Parameters.AddWithValue("@HSD", NL.hsd);
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        con.Dispose();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        return false;
                    }
                }
            }
            return true;
        }
        public int Laygiatien(string ma)
        {
            string query = string.Empty;
            query += " SELECT [dongia]";
            query += " FROM [tblNguyenLieu]";
            query += " WHERE [maNguyenLieu]=@maNguyenLieu";

            int gia = 0;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@maNguyenLieu", ma);
                    try
                    {
                        con.Open();
                        SqlDataReader reader = null;
                        reader = cmd.ExecuteReader();
                        if (reader.HasRows == true)
                        {                           
                            while (reader.Read())
                            {                                
                                gia = int.Parse(reader["dongia"].ToString());                               
                            }
                        }
                        con.Close();
                        con.Dispose();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        return 0;
                    }
                }
            }
            return gia;
        }

        public bool Xoa(NguyenLieuDTO NL)
        {
            string query = string.Empty;
            query += " DELETE FROM tblNguyenLieu WHERE [maNguyenLieu] = @maNguyenLieu";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@maNguyenLieu", NL.manl);
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        con.Dispose();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        return false;
                    }
                }
            }
            return true;
        }

        public List<NguyenLieuDTO> select()
        {
            string query = string.Empty;
            query += " SELECT [maNguyenLieu], [tenNguyenLieu], [dongia],[donVi], [trongKho], [HSD]";
            query += " FROM [tblNguyenLieu]";

            List<NguyenLieuDTO> listNguyenLieu = new List<NguyenLieuDTO>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    try
                    {
                        con.Open();
                        SqlDataReader reader = null;
                        reader = cmd.ExecuteReader();
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                NguyenLieuDTO nl = new NguyenLieuDTO();
                                nl.manl = reader["maNguyenLieu"].ToString();
                                nl.tennl = reader["tenNguyenLieu"].ToString();
                                nl.dongia = int.Parse(reader["dongia"].ToString());
                                nl.donvi = reader["donVi"].ToString();
                                nl.trongkho = int.Parse(reader["trongKho"].ToString());
                                nl.hsd = Convert.ToDateTime(reader["HSD"].ToString());
                                listNguyenLieu.Add(nl);
                            }
                        }

                        con.Close();
                        con.Dispose();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        return null;
                    }
                }
            }
            return listNguyenLieu;
        }

        public List<NguyenLieuDTO> selectByKeyWord(string sKeyword)
        {
            string query = string.Empty;
            query += " SELECT [maNguyenLieu], [tenNguyenLieu], [dongia],[donVi], [trongKho], [HSD]";
            query += " FROM [tblNguyenLieu]";
            query += " WHERE ([maNguyenLieu] LIKE CONCAT('%',@sKeyword,'%'))";
            query += " OR ([tenNguyenLieu] LIKE CONCAT('%',@sKeyword,'%'))";
            query += " OR ([dongia] LIKE CONCAT('%',@sKeyword,'%'))";
            query += " OR ([donVi] LIKE CONCAT('%',@sKeyword,'%'))";
            query += " OR ([trongKho] LIKE CONCAT('%',@sKeyword,'%'))";
            query += " OR ([HSD] LIKE CONCAT('%',@sKeyword,'%'))";

            List<NguyenLieuDTO> listNguyenLieu = new List<NguyenLieuDTO>();

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@sKeyword", sKeyword);
                    try
                    {
                        con.Open();
                        SqlDataReader reader = null;
                        reader = cmd.ExecuteReader();
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                NguyenLieuDTO nl = new NguyenLieuDTO();
                                nl.manl = reader["maNguyenLieu"].ToString();
                                nl.tennl = reader["tenNguyenLieu"].ToString();
                                nl.dongia = int.Parse(reader["dongia"].ToString());
                                nl.donvi = reader["donVi"].ToString();
                                nl.trongkho = int.Parse(reader["trongKho"].ToString());
                                nl.hsd = Convert.ToDateTime(reader["HSD"].ToString());
                                listNguyenLieu.Add(nl);
                            }
                        }
                        con.Close();
                        con.Dispose();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        return null;
                    }
                }
            }
            return listNguyenLieu;
        }

        public List<string> Laymanl()
        {
            List<string> dsmanl = new List<string>();
            string query = string.Empty;
            query += " SELECT [maNguyenLieu]";
            query += " FROM [tblNguyenLieu]";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    try
                    {
                        con.Open();
                        SqlDataReader reader = null;
                        reader = cmd.ExecuteReader();
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                string manl = reader["maNguyenLieu"].ToString();
                                dsmanl.Add(manl);
                            }
                        }

                        con.Close();
                        con.Dispose();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        return null;
                    }
                }
            }
            return dsmanl;
        }
    }
    public class MonAnDAL
    {
        private string connectionString;

        public MonAnDAL()
        {
            connectionString = ConfigurationManager.AppSettings["ConnectionString"];
        }

        public string ConnectionString { get => connectionString; set => connectionString = value; }

        public bool Them(MonAnDTO MA)
        {
            string query = string.Empty;
            query += " INSERT INTO [tblMonAn] ([maMonAn], [tenMonAn], [dongia])";
            query += " VALUES (@maMonAn, @tenMonAn, @dongia)";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@maMonAn", MA.mama);
                    cmd.Parameters.AddWithValue("@tenMonAn", MA.tenma);
                    cmd.Parameters.AddWithValue("@dongia", MA.dongia);

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        con.Dispose();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        return false;
                    }
                }
            }
            return true;
        }

        public bool Sua(MonAnDTO MA)
        {
            string query = string.Empty;
            query += " UPDATE tblMonAn SET [tenMonAn] = @tenMonAn, [dongia] = @dongia WHERE [maMonAn] = @maMonAn";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@maMonAn", MA.mama);
                    cmd.Parameters.AddWithValue("@tenMonAn", MA.tenma);
                    cmd.Parameters.AddWithValue("@dongia", MA.dongia);
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        con.Dispose();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        return false;
                    }
                }
            }
            return true;
        }

        public bool Xoa(MonAnDTO MA)
        {
            string query = string.Empty;
            query += " DELETE FROM tblMonAn WHERE [maMonAn] = @maMonAn";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@maMonAn", MA.mama);
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        con.Dispose();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        return false;
                    }
                }
            }
            return true;
        }

        public List<MonAnDTO> select()
        {
            string query = string.Empty;
            query += " SELECT [maMonAn], [tenMonAn], [dongia]";
            query += " FROM [tblMonAn]";

            List<MonAnDTO> listMonAn = new List<MonAnDTO>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    try
                    {
                        con.Open();
                        SqlDataReader reader = null;
                        reader = cmd.ExecuteReader();
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                MonAnDTO ma = new MonAnDTO();
                                ma.mama = reader["maMonAn"].ToString();
                                ma.tenma = reader["tenMonAn"].ToString();
                                ma.dongia = int.Parse(reader["dongia"].ToString());
                                listMonAn.Add(ma);
                            }
                        }

                        con.Close();
                        con.Dispose();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        return null;
                    }
                }
            }
            return listMonAn;
        }

        public List<MonAnDTO> selectByKeyWord(string sKeyword)
        {
            string query = string.Empty;
            query += " SELECT [maMonAn], [tenMonAn], [dongia]";
            query += " FROM [tblMonAn]";
            query += " WHERE ([maMonAn] LIKE CONCAT('%',@sKeyword,'%'))";
            query += " OR ([tenMonAn] LIKE CONCAT('%',@sKeyword,'%'))";
            query += " OR ([dongia] LIKE CONCAT('%',@sKeyword,'%'))";

            List<MonAnDTO> listMonAn = new List<MonAnDTO>();

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@sKeyword", sKeyword);
                    try
                    {
                        con.Open();
                        SqlDataReader reader = null;
                        reader = cmd.ExecuteReader();
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                MonAnDTO ma = new MonAnDTO();
                                ma.mama = reader["maMonAn"].ToString();
                                ma.tenma = reader["tenMonAn"].ToString();
                                ma.dongia = int.Parse(reader["dongia"].ToString());
                                listMonAn.Add(ma);
                            }
                        }
                        con.Close();
                        con.Dispose();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        return null;
                    }
                }
            }
            return listMonAn;
        }

        public List<string> Laymama()
        {
            List<string> dsmama = new List<string>();
            string query = string.Empty;
            query += " SELECT [maMonAn]";
            query += " FROM [tblMonAn]";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    try
                    {
                        con.Open();
                        SqlDataReader reader = null;
                        reader = cmd.ExecuteReader();
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                string mama = reader["maMonAn"].ToString();
                                dsmama.Add(mama);
                            }
                        }

                        con.Close();
                        con.Dispose();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        return null;
                    }
                }
            }
            return dsmama;
        }
    }
    public class DSNguyenLieuDAL
    {
        private string connectionString;

        public DSNguyenLieuDAL()
        {
            connectionString = ConfigurationManager.AppSettings["ConnectionString"];
        }

        public string ConnectionString { get => connectionString; set => connectionString = value; }

        public bool Them(DSNguyenLieuDTO DSNL)
        {
            string query = string.Empty;
            query += "INSERT INTO [dbo].[tblDSNguyenLieu] ([maNguyenLieu], [maMonAn], [soLuong])";
            query += "VALUES (@maNguyenLieu, @maMonAn, @soLuong)";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@maNguyenLieu", DSNL.manl);
                    cmd.Parameters.AddWithValue("@maMonAn", DSNL.mama);
                    cmd.Parameters.AddWithValue("@soLuong", DSNL.soluong);
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        con.Dispose();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        return false;
                    }
                }
            }
            return true;
        }
        public bool Xoa(DSNguyenLieuDTO DSNL)
        {
            string query = string.Empty;
            query += "DELETE FROM tblDSNguyenLieu WHERE [maMonAn]=@maMonAn";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@maMonAn", DSNL.mama);
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        con.Dispose();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        return false;
                    }
                }
            }
            return true;
        }
        public List<DSNguyenLieuDTO> select()
        {
            string query = string.Empty;
            query += " SELECT [maNguyenLieu], [maMonAn], [soLuong]";
            query += " FROM [tblDSNguyenLieu]";

            List<DSNguyenLieuDTO> listnl = new List<DSNguyenLieuDTO>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    try
                    {
                        con.Open();
                        SqlDataReader reader = null;
                        reader = cmd.ExecuteReader();
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                DSNguyenLieuDTO nl = new DSNguyenLieuDTO();
                                nl.mama = reader["maMonAn"].ToString();
                                nl.manl = reader["maNguyenLieu"].ToString();
                                nl.soluong = int.Parse(reader["soLuong"].ToString());
                                listnl.Add(nl);
                            }
                        }

                        con.Close();
                        con.Dispose();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        return null;
                    }
                }
            }
            return listnl;
        }
        
        public bool TimNLtrongMA(string manl, string mama)
        {
            string query = string.Empty;
            query += " SELECT [maNguyenLieu]";
            query += " FROM [tblDSNguyenLieu]";
            query += " WHERE [maNguyenLieu]=@maNguyenLieu";
            query += " AND [maMonAn]=@maMonAn";

            using (SqlConnection con = new SqlConnection(connectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@maNguyenLieu", manl);
                    cmd.Parameters.AddWithValue("@maMonAn", mama);
                    try
                    {
                        con.Open();
                        SqlDataReader reader = null;
                        reader = cmd.ExecuteReader();
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                DSNguyenLieuDTO DSNL = new DSNguyenLieuDTO();
                                DSNL.manl = reader["maNguyenLieu"].ToString();
                                if (DSNL != null)
                                {
                                    return true;
                                }
                            }
                        }
                        con.Close();
                        con.Dispose();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        return true;
                    }
                }
            }
            return false;
        }
        public bool Check(int thang, int year)
        {
            string test = null;
            string query = string.Empty;
            query += " SELECT maPhieu";
            query += " FROM tblPhieubaocaoCongNo no";
            query += " WHERE MONTH(no.ngayLapPhieu)= @month AND YEAR (no.ngayLapPhieu) = @year";

            using (SqlConnection con = new SqlConnection(connectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@month", thang);
                    cmd.Parameters.AddWithValue("@year", year);
                    try
                    {
                        con.Open();
                        SqlDataReader reader = null;
                        reader = cmd.ExecuteReader();
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                test = reader["maPhieu"].ToString();
                            }
                        }

                        con.Close();
                        con.Dispose();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                    }
                }
            }
            if (test != null)
            {
                return true;
            }
            return false;
        }
    }
    public class NhanVienDAL
    {
        private string connectionString;

        public NhanVienDAL()
        {
            connectionString = ConfigurationManager.AppSettings["ConnectionString"];
        }

        public string ConnectionString { get => connectionString; set => connectionString = value; }

        public bool Them(NhanVienDTO NV)
        {
            string query = string.Empty;
            query += " INSERT INTO tblnhanVien ([manhanVien], [tenNhanVien], [birth], [luongCoBan], [machucVu] )";
            query += " VALUES (@manhanVien, @tenNhanVien, @birth, @luongCoBan, @machucVu)";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@manhanVien", NV.manv);
                    cmd.Parameters.AddWithValue("@tenNhanVien", NV.tennv);
                    cmd.Parameters.AddWithValue("@birth", NV.birth);
                    cmd.Parameters.AddWithValue("@luongCoBan", NV.luongcoban);
                    cmd.Parameters.AddWithValue("@machucVu", NV.chucvu);
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        con.Dispose();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        return false;
                    }
                }
            }
            return true;
        }

        public bool Sua(NhanVienDTO NV)
        {
            string query = string.Empty;
            query += " UPDATE tblnhanVien SET [tenNhanVien] = @tenNhanVien, [birth] = @birth, [luongCoBan] = @luongCoBan, [machucVu] = @machucVu WHERE [manhanVien] = @manhanVien";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@manhanVien", NV.manv);
                    cmd.Parameters.AddWithValue("@tenNhanVien", NV.tennv);
                    cmd.Parameters.AddWithValue("@birth", NV.birth);
                    cmd.Parameters.AddWithValue("@luongCoBan", NV.luongcoban);
                    cmd.Parameters.AddWithValue("@machucVu", NV.chucvu);
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        con.Dispose();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        return false;
                    }
                }
            }
            return true;
        }

        public bool Xoa(NhanVienDTO NV)
        {
            string query = string.Empty;
            query += " DELETE FROM tblnhanVien WHERE [manhanVien] = @manhanVien";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@manhanVien", NV.manv);
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        con.Dispose();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        return false;
                    }
                }
            }
            return true;
        }

        public List<NhanVienDTO> select()
        {
            string query = string.Empty;
            query += " SELECT [manhanVien], [tenNhanVien] ,[birth], [luongCoBan], [machucVu]";
            query += " FROM [tblnhanVien]";

            List<NhanVienDTO> listNhanVien = new List<NhanVienDTO>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    try
                    {
                        con.Open();
                        SqlDataReader reader = null;
                        reader = cmd.ExecuteReader();
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                NhanVienDTO nv = new NhanVienDTO();
                                nv.manv = reader["manhanVien"].ToString();
                                nv.tennv = reader["tenNhanVien"].ToString();
                                nv.birth = Convert.ToDateTime(reader["birth"].ToString());
                                nv.luongcoban = int.Parse(reader["luongCoBan"].ToString());
                                nv.chucvu = reader["machucVu"].ToString();
                                listNhanVien.Add(nv);
                            }
                        }

                        con.Close();
                        con.Dispose();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        return null;
                    }
                }
            }
            return listNhanVien;
        }

        public List<NhanVienDTO> selectByKeyWord(string sKeyword)
        {
            string query = string.Empty;
            query += " SELECT [manhanVien], [tenNhanVien] ,[birth], [luongCoBan], [machucVu]";
            query += " FROM [tblnhanVien]";
            query += " WHERE ([manhanVien] LIKE CONCAT('%',@sKeyword,'%'))";
            query += " OR ([tenNhanVien] LIKE CONCAT('%',@sKeyword,'%'))";
            query += " OR ([birth] LIKE CONCAT('%',@sKeyword,'%'))";
            query += " OR ([luongCoBan] LIKE CONCAT('%',@sKeyword,'%'))";
            query += " OR ([machucVu] LIKE CONCAT('%',@sKeyword,'%'))";

            List<NhanVienDTO> listNhanVien = new List<NhanVienDTO>();

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@sKeyword", sKeyword);
                    try
                    {
                        con.Open();
                        SqlDataReader reader = null;
                        reader = cmd.ExecuteReader();
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                NhanVienDTO nv = new NhanVienDTO();
                                nv.manv = reader["manhanVien"].ToString();
                                nv.tennv = reader["tenNhanVien"].ToString();
                                nv.birth = Convert.ToDateTime(reader["birth"].ToString());
                                nv.luongcoban = int.Parse(reader["luongCoBan"].ToString());
                                nv.chucvu = reader["machucVu"].ToString();
                                listNhanVien.Add(nv);
                            }
                        }
                        con.Close();
                        con.Dispose();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        return null;
                    }
                }
            }
            return listNhanVien;
        }

        public List<string> Laymanv()
        {
            List<string> dsmama = new List<string>();
            string query = string.Empty;
            query += " SELECT [maMonAn]";
            query += " FROM [tblMonAn]";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    try
                    {
                        con.Open();
                        SqlDataReader reader = null;
                        reader = cmd.ExecuteReader();
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                string mama = reader["maMonAn"].ToString();
                                dsmama.Add(mama);
                            }
                        }

                        con.Close();
                        con.Dispose();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        return null;
                    }
                }
            }
            return dsmama;
        }
    }
}