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
        public int Laytonkho(string manl)
        {
            int kho = 0;
            string query = string.Empty;
            query += " SELECT [trongKho]";
            query += " FROM [tblNguyenLieu]";
            query += " WHERE [tblNguyenLieu]";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@maNguyenLieu", manl);
                    try
                    {
                        con.Open();
                        SqlDataReader reader = null;
                        reader = cmd.ExecuteReader();
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                kho = int.Parse(reader["trongKho"].ToString());
                            }
                        }

                        con.Close();
                        con.Dispose();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        return kho;
                    }
                }
            }
            return kho;
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
        public int Laygia(string mama)
        {
            int result = 0;
            List<string> dsmama = new List<string>();
            string query = string.Empty;
            query += " SELECT [dongia]";
            query += " FROM [tblMonAn]";
            query += " WHERE [maMonAn] = @maMonAn";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
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
                                result = int.Parse(reader["dongia"].ToString());
                            }
                        }

                        con.Close();
                        con.Dispose();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        return result;
                    }
                }
            }
            return result;
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
            query += "DELETE FROM tblDSNguyenLieu WHERE [maMonAn]=@maMonAn AND [maNguyenLieu]=@maNguyenLieu";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@maMonAn", DSNL.mama);
                    cmd.Parameters.AddWithValue("@maNguyenLieu", DSNL.manl);
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
        public bool XoatheoMA(string mama)
        {
            string query = string.Empty;
            query += "DELETE FROM tblDSNguyenLieu WHERE [maMonAn]=@maMonAn ";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@maMonAn", mama);
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
        public List<DSNguyenLieuDTO> select(string mama)
        {
            string query = string.Empty;
            query += " SELECT [maNguyenLieu], [maMonAn], [soLuong]";
            query += " FROM [tblDSNguyenLieu]";
            query += " WHERE [maMonAn] = @maMonAn";

            List<DSNguyenLieuDTO> listnl = new List<DSNguyenLieuDTO>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
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
        
    }
    public class DSMonAnDAL
    {
        private string connectionString;

        public DSMonAnDAL()
        {
            connectionString = ConfigurationManager.AppSettings["ConnectionString"];
        }

        public string ConnectionString { get => connectionString; set => connectionString = value; }

        public bool Them(DSMonAnDTO DSNL)
        {
            string query = string.Empty;
            query += "INSERT INTO [dbo].[tblDSMonAn] ([maMonAn], [mahoaDon], [soLuong] )";
            query += "VALUES (@maMonAn, @mahoaDon, @soLuong)";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@maMonAn", DSNL.mama);
                    cmd.Parameters.AddWithValue("@mahoaDon", DSNL.mahd);
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
        public bool Xoa(DSMonAnDTO DSNL)
        {
            string query = string.Empty;
            query += "DELETE FROM tblDSMonAn WHERE [maMonAn]=@maMonAn AND [mahoaDon]=@mahoaDon";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@maMonAn", DSNL.mama);
                    cmd.Parameters.AddWithValue("@mahoaDon", DSNL.mahd);
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
        public bool XoatheoHD(string mahd)
        {
            string query = string.Empty;
            query += "DELETE FROM tblDSMonAn WHERE [mahoaDon]=@mahoaDon";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@mahoaDon", mahd);
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
        public List<DSMonAnDTO> select(string mahd)
        {
            string query = string.Empty;
            query += " SELECT [maMonAn], [mahoaDon], [soLuong]";
            query += " FROM [tblDSMonAn]";
            query += " WHERE [mahoaDon] = @mahoaDon";

            List<DSMonAnDTO> listnl = new List<DSMonAnDTO>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@mahoaDon", mahd);
                    try
                    {
                        con.Open();
                        SqlDataReader reader = null;
                        reader = cmd.ExecuteReader();
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                DSMonAnDTO nl = new DSMonAnDTO();
                                nl.mama = reader["maMonAn"].ToString();
                                nl.mahd = reader["mahoaDon"].ToString();
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

        public bool TimMAtrongHD(string mahd, string mama)
        {
            string query = string.Empty;
            query += " SELECT [maMonAn]";
            query += " FROM [tblDSMonAn]";
            query += " WHERE [mahoaDon]=@mahoaDon";
            query += " AND [maMonAn]=@maMonAn";

            using (SqlConnection con = new SqlConnection(connectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@mahoaDon", mahd);
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
                                DSMonAnDTO DSNL = new DSMonAnDTO();
                                DSNL.mama = reader["maMonAn"].ToString();
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
            query += " INSERT INTO tblnhanVien ([manhanVien], [tenNhanVien], [birth], [luongCoBan], [chucVu], [absent], [attended])";
            query += " VALUES (@manhanVien, @tenNhanVien, @birth, @luongCoBan, @chucVu, @absent, @attended)";
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
                    cmd.Parameters.AddWithValue("@chucVu", NV.chucvu);
                    cmd.Parameters.AddWithValue("@absent", 0);
                    cmd.Parameters.AddWithValue("@attended", 0);
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
            query += " UPDATE tblnhanVien SET [tenNhanVien] = @tenNhanVien, [birth] = @birth, [luongCoBan] = @luongCoBan, [chucVu] = @chucVu, [absent]= @absent, [attended]= @attended WHERE [manhanVien] = @manhanVien";

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
                    cmd.Parameters.AddWithValue("@chucVu", NV.chucvu);
                    cmd.Parameters.AddWithValue("@absent", NV.Absent);
                    cmd.Parameters.AddWithValue("@attended", NV.Attended);
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
            query += " SELECT [manhanVien], [tenNhanVien] ,[birth], [luongCoBan], [chucVu], [absent]";
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
                                nv.chucvu = reader["chucVu"].ToString();
                                nv.Absent = int.Parse(reader["absent"].ToString());
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
            query += " SELECT [manhanVien], [tenNhanVien] ,[birth], [luongCoBan], [chucVu], [absent]";
            query += " FROM [tblnhanVien]";
            query += " WHERE ([manhanVien] LIKE CONCAT('%',@sKeyword,'%'))";
            query += " OR ([tenNhanVien] LIKE CONCAT('%',@sKeyword,'%'))";
            query += " OR ([birth] LIKE CONCAT('%',@sKeyword,'%'))";
            query += " OR ([luongCoBan] LIKE CONCAT('%',@sKeyword,'%'))";
            query += " OR ([chucVu] LIKE CONCAT('%',@sKeyword,'%'))";
            query += " OR ([absent] LIKE CONCAT('%',@sKeyword,'%'))";

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
                                nv.chucvu = reader["chucVu"].ToString();
                                nv.Absent = int.Parse(reader["absent"].ToString());
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
            query += " SELECT [manhanVien]";
            query += " FROM [tblnhanVien]";
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
                                string mama = reader["manhanVien"].ToString();
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

        public NhanVienDTO Laynv(string manv)
        {
            NhanVienDTO nv = new NhanVienDTO();
            string query = string.Empty;
            query += " SELECT [manhanVien], [tenNhanVien] ,[birth], [luongCoBan], [chucVu], [absent], [attended]";
            query += " FROM [tblnhanVien]";
            query += " WHERE [manhanVien]=@manhanVien";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@manhanVien", manv);
                    try
                    {
                        con.Open();
                        SqlDataReader reader = null;
                        reader = cmd.ExecuteReader();
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                nv.manv = reader["manhanVien"].ToString();
                                nv.tennv = reader["tenNhanVien"].ToString();
                                nv.birth = Convert.ToDateTime(reader["birth"].ToString());
                                nv.luongcoban = int.Parse(reader["luongCoBan"].ToString());
                                nv.chucvu = reader["chucVu"].ToString();
                                nv.Absent = int.Parse(reader["absent"].ToString());
                                nv.Attended = int.Parse(reader["attended"].ToString());
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
            return nv;
        }
    }
    public class TaiKhoanDAL
    {
        private string connectionString;

        public TaiKhoanDAL()
        {
            connectionString = ConfigurationManager.AppSettings["ConnectionString"];
        }

        public string ConnectionString { get => connectionString; set => connectionString = value; }

        public bool Them(TaiKhoanDTO TK)
        {
            string query = string.Empty;
            query += " INSERT INTO [tbltaiKhoan] ([username], [manhanVien], [password], [type] )";
            query += " VALUES (@username, @manhanVien, @password, @type)";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@username", TK.Username);
                    cmd.Parameters.AddWithValue("@manhanVien", TK.manv);
                    cmd.Parameters.AddWithValue("@password", TK.Password);
                    cmd.Parameters.AddWithValue("@type", TK.Type);
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

        public bool Sua(TaiKhoanDTO TK)
        {
            string query = string.Empty;
            query += " UPDATE tbltaiKhoan SET [password] = @password, [type] = @type, [username] = @username WHERE [manhanVien] = @manhanVien";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@username", TK.Username);
                    cmd.Parameters.AddWithValue("@manhanVien", TK.manv);
                    cmd.Parameters.AddWithValue("@password", TK.Password);
                    cmd.Parameters.AddWithValue("@type", TK.Type);
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

        public bool Xoa(TaiKhoanDTO TK)
        {
            string query = string.Empty;
            query += " DELETE FROM tbltaiKhoan WHERE [manhanVien] = @manhanVien";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@manhanVien", TK.manv);
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

        public TaiKhoanDTO Laytk(string username, string pass)
        {
            TaiKhoanDTO tk = new TaiKhoanDTO();
            string query = string.Empty;
            query += " SELECT [username], [manhanVien], [type]";
            query += " FROM [tbltaiKhoan]";
            query += " WHERE [username] = @username";
            query += " AND [password] = @password";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", pass);
                    try
                    {
                        con.Open();
                        SqlDataReader reader = null;
                        reader = cmd.ExecuteReader();
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                tk.Username = reader["username"].ToString();
                                tk.manv = reader["manhanVien"].ToString();
                                tk.Type = reader["type"].ToString();
                            }
                        }

                        con.Close();
                        con.Dispose();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        return tk;
                    }
                }
            }
            return tk;
        }

        public List<TaiKhoanDTO> select()
        {
            string query = string.Empty;
            query += " SELECT [username], [manhanVien], [type]";
            query += " FROM [tbltaiKhoan]";

            List<TaiKhoanDTO> listNhanVien = new List<TaiKhoanDTO>();

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
                                TaiKhoanDTO nv = new TaiKhoanDTO();
                                nv.Username = reader["username"].ToString();
                                nv.manv = reader["manhanVien"].ToString();
                                nv.Type = reader["type"].ToString();
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

        public List<TaiKhoanDTO> selectByKeyWord(string sKeyword)
        {
            string query = string.Empty;
            query += " SELECT [username], [manhanVien], [type]";
            query += " FROM [tbltaiKhoan]";
            query += " WHERE ([username] LIKE CONCAT('%',@sKeyword,'%'))";
            query += " OR ([manhanVien] LIKE CONCAT('%',@sKeyword,'%'))";
            query += " OR ([type] LIKE CONCAT('%',@sKeyword,'%'))";

            List<TaiKhoanDTO> listNhanVien = new List<TaiKhoanDTO>();

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
                                TaiKhoanDTO nv = new TaiKhoanDTO();
                                nv.Username = reader["username"].ToString();
                                nv.manv = reader["manhanVien"].ToString();
                                nv.Type = reader["type"].ToString();
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
      
    }
    public class PhieubaocaoDoanhThuDAL
    {
        private string connectionString;

        public PhieubaocaoDoanhThuDAL()
        {
            connectionString = ConfigurationManager.AppSettings["ConnectionString"];
        }

        public string ConnectionString { get => connectionString; set => connectionString = value; }

        public bool Them(PhieubaocaoDoanhThuDTO DT)
        {
            string query = string.Empty;
            query += "INSERT INTO [dbo].[tblPhieubaocaoDoanhThu] ([maPhieu], [tongDoanhThu], [ngayLapPhieu])";
            query += "VALUES (@maPhieu,@tongDoanhThu, @ngayLapPhieu)";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@maPhieu", DT.maphieuBCDT);
                    cmd.Parameters.AddWithValue("@tongDoanhThu", DT.tongdt);
                    cmd.Parameters.AddWithValue("@ngayLapPhieu", DT.ngayLP);
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
        public bool Sua(PhieubaocaoDoanhThuDTO DT)
        {
            string query = string.Empty;
            query += "UPDATE [dbo].[tblPhieubaocaoDoanhThu] SET [tongDoanhThu] = @tongDoanhThu WHERE [maPhieu]=@maPhieu";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@maPhieu", DT.maphieuBCDT);
                    cmd.Parameters.AddWithValue("@tongDoanhThu", DT.tongdt);
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
        public bool Xoa(PhieubaocaoDoanhThuDTO DT)
        {
            string query = string.Empty;
            query += "DELETE FROM tblPhieubaocaoDoanhThu WHERE [maPhieu]=@maPhieu";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@maPhieu", DT.maphieuBCDT);
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
        public List<PhieubaocaoDoanhThuDTO> select()
        {
            string query = string.Empty;
            query += " SELECT [maPhieu], [tongDoanhThu], [ngayLapPhieu]";
            query += " FROM [tblPhieubaocaoDoanhThu]";

            List<PhieubaocaoDoanhThuDTO> listdoanhthu = new List<PhieubaocaoDoanhThuDTO>();

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
                                PhieubaocaoDoanhThuDTO DT = new PhieubaocaoDoanhThuDTO();
                                DT.maphieuBCDT = reader["maPhieu"].ToString();
                                DT.ngayLP = Convert.ToDateTime(reader["ngayLapPhieu"].ToString());
                                DT.tongdt = int.Parse(reader["tongDoanhThu"].ToString());
                                listdoanhthu.Add(DT);
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
            return listdoanhthu;
        }
        public List<PhieubaocaoDoanhThuDTO> selectByKeyWord(string sKeyword)
        {
            string query = string.Empty;
            query += " SELECT [maPhieu], [tongDoanhThu], [ngayLapPhieu]";
            query += " FROM [tblPhieubaocaoDoanhThu]";
            query += " WHERE ([maPhieu] LIKE CONCAT('%',@sKeyword,'%'))";
            query += " OR ([ngayLapPhieu] LIKE CONCAT('%',@sKeyword,'%'))";
            query += " OR ([tongDoanhThu] LIKE CONCAT('%',@sKeyword,'%'))";

            List<PhieubaocaoDoanhThuDTO> listdoanhthu = new List<PhieubaocaoDoanhThuDTO>();

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
                                PhieubaocaoDoanhThuDTO DT = new PhieubaocaoDoanhThuDTO();
                                DT.maphieuBCDT = reader["maPhieu"].ToString();
                                DT.ngayLP = Convert.ToDateTime(reader["ngayLapPhieu"].ToString());
                                DT.tongdt = int.Parse(reader["tongDoanhThu"].ToString());
                                listdoanhthu.Add(DT);
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
            return listdoanhthu;
        }
        public bool CheckExist(int thang, int year)
        {
            string test = null;
            string query = string.Empty;
            query += " SELECT maPhieu";
            query += " FROM tblPhieubaocaoDoanhThu dt";
            query += " WHERE MONTH(dt.ngayLapPhieu)= @month AND YEAR(dt.ngayLapPhieu) = @year";
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
    public class ChitietphieubcdtDAL
    {
        private string connectionString;
        public ChitietphieubcdtDAL()
        {
            connectionString = ConfigurationManager.AppSettings["ConnectionString"];
        }
        public string ConnectionString { get => connectionString; set => connectionString = value; }
        public bool Them(ChitietphieubcdtDTO CTDT)
        {
            string query = string.Empty;
            query += "INSERT INTO [dbo].[tblChitietPhieubaocaoDT] ([maPhieu], [mahoaDon], [tongTien])";
            query += "VALUES (@maPhieu,@mahoaDon,@tongTien)";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@maPhieu", CTDT.maphieuBCDT);
                    cmd.Parameters.AddWithValue("@mahoaDon", CTDT.mahd);
                    cmd.Parameters.AddWithValue("@tongTien", CTDT.tongtien);
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
        public bool Xoatheohoadon(string mahd)
        {
            string query = string.Empty;
            query += "DELETE FROM tblChitietPhieubaocaoDT WHERE [mahoaDon]=@mahoaDon ";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@mahoaDon", mahd);
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
        public bool XoatheophieuBCDT(string mabcdt)
        {
            string query = string.Empty;
            query += "DELETE FROM tblChitietPhieubaocaoDT WHERE [maPhieu]=@maPhieu ";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@maPhieu", mabcdt);
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
        public List<ChitietphieubcdtDTO> select(string madt)
        {
            string query = string.Empty;
            query += " SELECT [mahoaDon], [tongTien]";
            query += " FROM [tblChitietPhieubaocaoDT]";
            query += " WHERE [maPhieu]=@maPhieu";
            List<ChitietphieubcdtDTO> listCTbcdt = new List<ChitietphieubcdtDTO>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@maPhieu", madt);
                    try
                    {
                        con.Open();
                        SqlDataReader reader = null;
                        reader = cmd.ExecuteReader();
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                ChitietphieubcdtDTO CTDT = new ChitietphieubcdtDTO();
                                CTDT.mahd = reader["mahoaDon"].ToString();
                                CTDT.tongtien = int.Parse(reader["tongTien"].ToString());
                                listCTbcdt.Add(CTDT);
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
            return listCTbcdt;
        }
        public List<ChitietphieubcdtDTO> laydoanhthu(int thang, int nam)
        {
            string query = string.Empty;
            query += " SELECT  [mahoaDon], [tongTien] ";
            query += " FROM [tblhoaDon] ";
            query += " WHERE  MONTH([ngayThanhToan])=@month AND YEAR ([ngayThanhToan]) = @year ";
            List<ChitietphieubcdtDTO> listCTbcdt = new List<ChitietphieubcdtDTO>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@month", thang);
                    cmd.Parameters.AddWithValue("@year", nam);
                    try
                    {
                        con.Open();
                        SqlDataReader reader = null;
                        reader = cmd.ExecuteReader();
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                ChitietphieubcdtDTO CTDT = new ChitietphieubcdtDTO();
                                CTDT.mahd = reader["mahoaDon"].ToString();
                                CTDT.tongtien = int.Parse(reader["tongTien"].ToString());
                                listCTbcdt.Add(CTDT);
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
            return listCTbcdt;
        }
        public List<ChitietphieubcdtDTO> selectByKeyWord(string sKeyword, string madt)
        {
            string query = string.Empty;
            query += " SELECT [mahoaDon]";
            query += " FROM [tblChitietPhieubaocaoDT]";
            query += " WHERE [maPhieu]=@maPhieu";
            query += " AND (([mahoaDon] LIKE CONCAT('%',@sKeyword,'%'))";

            List<ChitietphieubcdtDTO> listCTbcdt = new List<ChitietphieubcdtDTO>();

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@maPhieu", madt);
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
                                ChitietphieubcdtDTO CTDT = new ChitietphieubcdtDTO();
                                CTDT.mahd = reader["mahoaDon"].ToString();
                                listCTbcdt.Add(CTDT);
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
            return listCTbcdt;
        }
    }
    public class hoaDonDAL
    {
        private string connectionString;

        public hoaDonDAL()
        {
            connectionString = ConfigurationManager.AppSettings["ConnectionString"];
        }

        public string ConnectionString { get => connectionString; set => connectionString = value; }

        public bool Them(hoaDonDTO HD)
        {
            string query = string.Empty;
            query += " INSERT INTO tblhoaDon ([mahoaDon],[soban],[tongTien],[ngayThanhToan],[mathuNgan])";
            query += " VALUES (@mahoaDon, @soban, @tongTien, @ngayThanhToan, @mathuNgan)";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@mahoaDon", HD.mahd);
                    cmd.Parameters.AddWithValue("@soban", HD.soban);
                    cmd.Parameters.AddWithValue("@tongTien", HD.tongtien);
                    cmd.Parameters.AddWithValue("@ngayThanhToan", HD.ngayThanhToan);
                    cmd.Parameters.AddWithValue("@mathuNgan", HD.maTN);

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
        public bool Sua(hoaDonDTO HD)
        {
            string query = string.Empty;
            query += " UPDATE tblhoaDon SET [soban] = @soban, [tongTien] = @tongTien, [ngayThanhToan] = @ngayThanhToan, [mathuNgan] = @mathuNgan WHERE [mahoaDon] = @mahoaDon";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@mahoaDon", HD.mahd);
                    cmd.Parameters.AddWithValue("@soban", HD.soban);
                    cmd.Parameters.AddWithValue("@tongTien", HD.tongtien);
                    cmd.Parameters.AddWithValue("@ngayThanhToan", HD.ngayThanhToan);
                    cmd.Parameters.AddWithValue("@mathuNgan", HD.maTN);
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
        public bool SuaTien(hoaDonDTO HD)
        {
            string query = string.Empty;
            query += " UPDATE tblhoaDon SET [tongTien] = @tongTien WHERE [mahoaDon] = @mahoaDon";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@mahoaDon", HD.mahd);
                    cmd.Parameters.AddWithValue("@tongTien", HD.tongtien);
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
        public bool Xoa(hoaDonDTO HD)
        {
            string query = string.Empty;
            query += " DELETE FROM tblhoaDon WHERE [mahoaDon] = @mahoaDon";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@mahoaDon", HD.mahd);
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
        public List<hoaDonDTO> select()
        {
            string query = string.Empty;
            query += " SELECT [mahoaDon], [soban], [tongTien], [ngayThanhToan], [mathuNgan]";
            query += " FROM [tblhoaDon]";

            List<hoaDonDTO> listhoaDon = new List<hoaDonDTO>();

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
                                hoaDonDTO hd = new hoaDonDTO();
                                hd.mahd = reader["mahoaDon"].ToString();
                                hd.soban = int.Parse(reader["soban"].ToString());
                                hd.tongtien = int.Parse(reader["tongTien"].ToString());
                                hd.ngayThanhToan = Convert.ToDateTime(reader["ngayThanhToan"].ToString());
                                hd.maTN = reader["mathuNgan"].ToString();
                                listhoaDon.Add(hd);
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
            return listhoaDon;
        }
        public List<hoaDonDTO> selectByKeyWord(string sKeyword)
        {
            string query = string.Empty;
            query += " SELECT [mahoaDon], [soban], [tongTien], [ngayThanhToan], [mathuNgan]";
            query += " FROM [tblhoaDon]";
            query += " WHERE ([mahoaDon] LIKE CONCAT('%',@sKeyword,'%'))";
            query += " OR ([soban] LIKE CONCAT('%',@sKeyword,'%'))";
            query += " OR ([tongTien] LIKE CONCAT('%',@sKeyword,'%'))";
            query += " OR ([ngayThanhToan] LIKE CONCAT('%',@sKeyword,'%'))";
            query += " OR ([mathuNgan] LIKE CONCAT('%',@sKeyword,'%'))";

            List<hoaDonDTO> listhoaDon = new List<hoaDonDTO>();

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
                                hoaDonDTO hd = new hoaDonDTO();
                                hd.mahd = reader["mahoaDon"].ToString();
                                hd.soban = int.Parse(reader["soban"].ToString());
                                hd.tongtien = int.Parse(reader["tongTien"].ToString());
                                hd.ngayThanhToan = Convert.ToDateTime(reader["ngayThanhToan"].ToString());
                                hd.maTN = reader["mathuNgan"].ToString();
                                listhoaDon.Add(hd);
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
            return listhoaDon;
        }
    }
    public class dsBandadatDAL
    {
        private string connectionString;

        public dsBandadatDAL()
        {
            connectionString = ConfigurationManager.AppSettings["ConnectionString"];
        }

        public string ConnectionString { get => connectionString; set => connectionString = value; }

        public bool Them(dsBandadatDTO HD)
        {
            string query = string.Empty;
            query += " INSERT INTO tbldsBandadat ([soban],[ngayDat])";
            query += " VALUES (@soban, @ngayDat)";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@soban", HD.soban);
                    cmd.Parameters.AddWithValue("@ngayDat", HD.bookeddate);
                    
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
        public bool Sua(dsBandadatDTO HD)
        {
            string query = string.Empty;
            query += " UPDATE tbldsBandadat SET [ngayDat] = @ngayDat WHERE [soban] = @soban";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@soban", HD.soban);
                    cmd.Parameters.AddWithValue("@ngayDat", HD.bookeddate);
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
        public bool Xoa(dsBandadatDTO HD)
        {
            string query = string.Empty;
            query += " DELETE FROM tbldsBandadat WHERE [soban] = @soban AND DAY(tbldsBandadat.ngayDat) = @day AND MONTH(tbldsBandadat.ngayDat)= @month AND YEAR(tbldsBandadat.ngayDat) = @year";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@soban", HD.soban);
                    cmd.Parameters.AddWithValue("@month", HD.bookeddate.Month);
                    cmd.Parameters.AddWithValue("@year", HD.bookeddate.Year);
                    cmd.Parameters.AddWithValue("@day", HD.bookeddate.Day);
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
        public List<dsBandadatDTO> select(string soban)
        {
            string query = string.Empty;
            query += " SELECT [soban], [ngayDat]";
            query += " FROM [tbldsBandadat]";
            query += " WHERE [soban]=@soban";

            List<dsBandadatDTO> listBan = new List<dsBandadatDTO>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@soban", soban);
                    try
                    {
                        con.Open();
                        SqlDataReader reader = null;
                        reader = cmd.ExecuteReader();
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                dsBandadatDTO hd = new dsBandadatDTO();
                                hd.soban = int.Parse(reader["soban"].ToString());
                                hd.bookeddate = Convert.ToDateTime(reader["ngayDat"].ToString());
                                listBan.Add(hd);
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
            return listBan;
        }
        public bool checkBookStatus(int soban, DateTime checkdate)
        {
            string test = null;
            string query = string.Empty;
            query += " SELECT soban";
            query += " FROM tbldsBandadat dt";
            query += " WHERE soban = @soban AND DAY(dt.ngayDat) = @day AND MONTH(dt.ngayDat)= @month AND YEAR(dt.ngayDat) = @year";
            List<dsBandadatDTO> listBan = new List<dsBandadatDTO>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@soban", soban);
                    cmd.Parameters.AddWithValue("@month", checkdate.Month);
                    cmd.Parameters.AddWithValue("@year", checkdate.Year);
                    cmd.Parameters.AddWithValue("@day", checkdate.Day);
                    try
                    {
                        con.Open();
                        SqlDataReader reader = null;
                        reader = cmd.ExecuteReader();
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                test = reader["soban"].ToString();
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
    public class BanDAL
    {
        private string connectionString;

        public BanDAL()
        {
            connectionString = ConfigurationManager.AppSettings["ConnectionString"];
        }

        public string ConnectionString { get => connectionString; set => connectionString = value; }

        public bool Them(BanDTO HD)
        {
            string query = string.Empty;
            query += " INSERT INTO tblBan ([soban])";
            query += " VALUES (@soban)";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@soban", HD.soban);

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
        public bool Xoa(BanDTO HD)
        {
            string query = string.Empty;
            query += " DELETE FROM tblBan WHERE [soban] = @soban";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@soban", HD.soban);
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
        public List<BanDTO> select()
        {
            string query = string.Empty;
            query += " SELECT [soban]";
            query += " FROM [tblBan]";
            query += " WHERE [soban]=@soban";

            List<BanDTO> listBan = new List<BanDTO>();

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
                                BanDTO hd = new BanDTO();
                                hd.soban = int.Parse(reader["ngayDat"].ToString());
                                listBan.Add(hd);
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
            return listBan;
        }
        public List<string> LaysoBan()
        {
            List<string> dsban = new List<string>();
            string query = string.Empty;
            query += " SELECT [soban]";
            query += " FROM [tblBan]";
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
                                string manl = reader["soban"].ToString();
                                dsban.Add(manl);
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
            return dsban;
        }
    }
    public class QuiDinhDAL
    {
        private string connectionString;

        public QuiDinhDAL()
        {
            connectionString = ConfigurationManager.AppSettings["ConnectionString"];
        }

        public string ConnectionString { get => connectionString; set => connectionString = value; }

        public bool Sua(QuiDinhDTO QD)//chỉnh sửa qui định
        {
            string query = string.Empty;
            query += " UPDATE tblQuiDinh SET [maxtogetsell] = @maxtogetsell, [sellprice] = @sellprice, [percentnadd] = @percentnadd, [dayofwork] = @dayofwork, [luongtru]=@luongtru WHERE [getkey]= 1";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@maxtogetsell", QD.Maxtogetsell);
                    cmd.Parameters.AddWithValue("@sellprice", QD.Sellprice);
                    cmd.Parameters.AddWithValue("@percentnadd", QD.Percentnadd);
                    cmd.Parameters.AddWithValue("@dayofwork", QD.Dayofwork);
                    cmd.Parameters.AddWithValue("@luongtru", QD.Luongtru);
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
        public QuiDinhDTO Laydulieu()//Lấy dữ liệu
        {
            QuiDinhDTO re = new QuiDinhDTO();
            string query = string.Empty;
            query += " SELECT [maxtogetsell], [sellprice], [percentnadd], [dayofwork], [luongtru]";
            query += " FROM [tblQuiDinh]";
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
                            reader.Read();
                            re.Maxtogetsell = int.Parse(reader["maxtogetsell"].ToString());
                            re.Sellprice = int.Parse(reader["sellprice"].ToString());
                            re.Percentnadd = int.Parse(reader["percentnadd"].ToString());
                            re.Dayofwork = int.Parse(reader["dayofwork"].ToString());
                            re.Luongtru = int.Parse(reader["luongtru"].ToString());
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
            return re;
        }
    }
}