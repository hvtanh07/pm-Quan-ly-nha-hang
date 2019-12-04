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

        public List<string> Laymadl()
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
}