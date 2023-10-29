using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class NhanVienDAL : DBConnect
    {
        DBConnect dbc = new DBConnect();
        public List<NhanVien> getNhanVienList(String mch, String x)
        {
            List<NhanVien> nvl = new List<NhanVien>();
            dbc.Moketnoi();
            var sql = "SELECT * FROM NhanVien WHERE maCuaHang = @mch AND (maNhanVien LIKE @x OR tenNhanVien LIKE @x or soDienThoai like @x) and chucVu != '1'";
            var cmd = new SqlCommand(sql, dbc.conec);
            cmd.Parameters.AddWithValue("@mch", mch);
            cmd.Parameters.AddWithValue("@x", $"%{x}%");
            NhanVien nv = null;
            using (SqlDataReader rd = cmd.ExecuteReader())
            {
                while (rd.Read())
                {

                    nv = new NhanVien();
                    nv.maNhanVien = rd["maNhanVien"].ToString();
                    nv.hoNhanVien = rd["hoNhanVien"].ToString();
                    nv.tenNhanVien = rd["tenNhanVien"].ToString();
                    nv.gioiTinh = (Boolean)rd["gioiTinh"];
                    nv.diaChi = rd["diaChi"].ToString();
                    nv.soDienThoai = rd["soDienThoai"].ToString();
                    nv.ngaySinh = (DateTime)rd.GetDateTime(6);
                    nv.chucVu = rd["chucVu"].ToString();
                    nv.pass = rd["pass"].ToString();
                    nv.maCuaHang = rd["maCuaHang"].ToString();
                    nvl.Add(nv);
                }
            }
            dbc.Dongketnoi();
            return nvl;
        }

        public NhanVien getNhanVien(String mnv)
        {
            Moketnoi();
            var sql = "SELECT * FROM NhanVien where maNhanVien = @maNhanVien";
            var cmd = new SqlCommand(sql, conec);
            cmd.Parameters.AddWithValue("@maNhanVien", mnv);
            NhanVien nv = null;
            using (SqlDataReader rd = cmd.ExecuteReader())
            {
                while (rd.Read())
                {
                    nv = new NhanVien();
                    nv.maNhanVien = rd.GetString(rd.GetOrdinal("maNhanVien"));
                    nv.hoNhanVien = rd.GetString(rd.GetOrdinal("hoNhanVien"));
                    nv.tenNhanVien = rd.GetString(rd.GetOrdinal("tenNhanVien"));
                    nv.gioiTinh = rd.GetBoolean(rd.GetOrdinal("gioiTinh"));
                    nv.diaChi = rd.GetString(rd.GetOrdinal("diaChi"));
                    nv.soDienThoai = rd.GetString(rd.GetOrdinal("soDienThoai"));
                    nv.ngaySinh = rd.GetDateTime(rd.GetOrdinal("ngaySinh"));
                    nv.chucVu = rd.GetString(rd.GetOrdinal("chucVu"));
                    nv.pass = rd.GetString(rd.GetOrdinal("pass"));
                    nv.maCuaHang = rd.GetString(rd.GetOrdinal("maCuaHang"));
                }
            }
            Dongketnoi();
            return nv;
        }
        public bool themNV(String mch, NhanVien nv)
        {
            dbc.Moketnoi();
            try
            {
                var mchnew = new String(mch.Where(Char.IsLetter).ToArray());
                string SQL = "INSERT INTO nhanvien VALUES (@param1, @hoNhanVien, @tenNhanVien, @gioiTinh, @diaChi, @soDienThoai, @ngaySinh, @chucVu, @pass, @maCuaHang)";

                using (SqlCommand cmd = new SqlCommand(SQL, dbc.conec))
                {
                    cmd.Parameters.AddWithValue("@param1", mchnew + nv.randomString());
                    cmd.Parameters.AddWithValue("@hoNhanVien", nv.hoNhanVien);
                    cmd.Parameters.AddWithValue("@tenNhanVien", nv.tenNhanVien);
                    cmd.Parameters.AddWithValue("@gioiTinh", nv.gioiTinh);
                    cmd.Parameters.AddWithValue("@diaChi", nv.diaChi);
                    cmd.Parameters.AddWithValue("@soDienThoai", nv.soDienThoai);
                    cmd.Parameters.AddWithValue("@ngaySinh", nv.ngaySinh);
                    cmd.Parameters.AddWithValue("@chucVu", nv.chucVu);
                    cmd.Parameters.AddWithValue("@pass", nv.pass);
                    cmd.Parameters.AddWithValue("@maCuaHang", mch);

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                }
            }
            finally
            {
                dbc.Dongketnoi();
            }
            return false;
        }

        public bool checkNhanVienValid(NhanVien nv)
        {
            Boolean Isvalid = false;
            dbc.Moketnoi();
            try
            {
                var sql = "SELECT COUNT(*) FROM dbo.NhanVien WHERE soDienThoai = @soDienThoai";
                var cmd = new SqlCommand(sql, dbc.conec);
                cmd.Parameters.AddWithValue("@soDienThoai", nv.soDienThoai);
                if ((int)cmd.ExecuteScalar() > 0)
                {
                    Isvalid = true;
                }
            }
           
            finally
            {
                dbc.Dongketnoi();
            }
            return Isvalid;
        }
        public bool editNhanVien(NhanVien nv)
        {
            Boolean success = false;
            dbc.Moketnoi();

            try
            {
                string SQL = "UPDATE NhanVien SET hoNhanVien = @hoNhanVien, tenNhanVien = @tenNhanVien, gioiTinh = @gioiTinh, diaChi = @diaChi, soDienThoai = @soDienThoai, ngaySinh = @ngaySinh, chucVu = @chucVu WHERE maNhanVien = @maNhanVien";

                using (SqlCommand cmd = new SqlCommand(SQL, dbc.conec))
                {
                    cmd.Parameters.AddWithValue("@hoNhanVien", nv.hoNhanVien);
                    cmd.Parameters.AddWithValue("@tenNhanVien", nv.tenNhanVien);
                    cmd.Parameters.AddWithValue("@gioiTinh", nv.gioiTinh);
                    cmd.Parameters.AddWithValue("@diaChi", nv.diaChi);
                    cmd.Parameters.AddWithValue("@soDienThoai", nv.soDienThoai);
                    cmd.Parameters.AddWithValue("@ngaySinh", nv.ngaySinh);
                    cmd.Parameters.AddWithValue("@chucVu", nv.chucVu);
                    cmd.Parameters.AddWithValue("@maNhanVien", nv.maNhanVien);

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        success = true;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                dbc.Dongketnoi();
            }
            return success;
        }
        public Boolean delNhanVien(NhanVien nv)
        {
            dbc.Moketnoi();
            Boolean success = false;
            try
            {
                string SQL = string.Format("DELETE FROM NhanVien WHERE maNhanVien = '{0}'", nv.maNhanVien);
                SqlCommand cmd = new SqlCommand(SQL, dbc.conec);
                if (cmd.ExecuteNonQuery() > 0)
                    success = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally { dbc.Dongketnoi(); }
            return success;
        }
        public Boolean changePassWord(String mkn, String mnv)
        {
            Boolean success = false;
            dbc.Moketnoi();
            try
            {
                var SQL = "update NhanVien set pass = @pass where maNhanVien = @maNhanVien";
                var cmd = new SqlCommand(SQL, dbc.conec);
                cmd.Parameters.AddWithValue("@pass", mkn);
                cmd.Parameters.AddWithValue("@maNhanVien", mnv);
                if (cmd.ExecuteNonQuery() > 0)
                    success = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally { dbc.Dongketnoi(); }
            return success;
        }
        public List<NhanVien> LoadDlNhanVien()
        {
            List<NhanVien> nvl = new List<NhanVien>();
            Moketnoi();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM NhanVien";
            cmd.Connection = conec;
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                NhanVien nv = new NhanVien();
                nv.maNhanVien = rd["maNhanVien"].ToString();
                nv.hoNhanVien = rd["hoNhanVien"].ToString();
                nv.tenNhanVien = rd["tenNhanVien"].ToString();
                nv.gioiTinh = (Boolean)rd["gioiTinh"];
                nv.diaChi = rd["diaChi"].ToString();
                nv.soDienThoai = rd["soDienThoai"].ToString();
                nv.ngaySinh = (DateTime)rd.GetDateTime(6);
                nv.chucVu = rd["chucVu"].ToString();
                nv.pass = rd["pass"].ToString();
                nv.maCuaHang = rd["maCuaHang"].ToString();
                nvl.Add(nv);
            }
            rd.Close();
            Dongketnoi();
            return nvl;
        }

        public void ThemNhanVien(NhanVien nv)
        {
            Moketnoi();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO NhanVien VALUES (@maNV, @hoNV, @tenNV, @gioiTinh, @diaChi, @soDienThoai, @ngaySinh, @chucVu, @pass, @maCuaHang)";
            cmd.Connection = conec;
            cmd.Parameters.AddWithValue("@maNV", nv.maNhanVien);
            cmd.Parameters.AddWithValue("@hoNV", nv.hoNhanVien);
            cmd.Parameters.AddWithValue("@tenNV", nv.tenNhanVien);
            cmd.Parameters.AddWithValue("@gioiTinh", nv.gioiTinh);
            cmd.Parameters.AddWithValue("@diaChi", nv.diaChi);
            cmd.Parameters.AddWithValue("@soDienThoai", nv.soDienThoai);
            cmd.Parameters.AddWithValue("@ngaySinh", nv.ngaySinh);
            cmd.Parameters.AddWithValue("@chucVu", nv.chucVu);
            cmd.Parameters.AddWithValue("@pass", nv.pass);
            cmd.Parameters.AddWithValue("@maCuaHang", nv.maCuaHang);
            cmd.ExecuteNonQuery();
            Dongketnoi();
        }
        
        public void XoaNhanVien(string maNV)
        {
            Moketnoi();

            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "DELETE FROM NhanVien WHERE maNhanVien = @maNV";
                    cmd.Connection = conec;
                    cmd.Parameters.AddWithValue("@maNV", maNV);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu có lỗi
                // Ví dụ: MessageBox.Show("Lỗi khi xóa sản phẩm: " + ex.Message);
                throw ex;
            }
            finally
            {
                Dongketnoi();
            }
        }

        public List<NhanVien> TimKiemNhanVien(string tuKhoa)
        {
            List<NhanVien> ketQua = new List<NhanVien>();

            try
            {
                Moketnoi();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    // Sử dụng câu truy vấn SQL để tìm kiếm sản phẩm theo từ khóa
                    cmd.CommandText = "SELECT * FROM NhanVien WHERE maNhanVien LIKE @tuKhoa OR hoNhanVien LIKE @tuKhoa OR tenNhanVien LIKE @tuKhoa";
                    cmd.Connection = conec;
                    cmd.Parameters.AddWithValue("@tuKhoa", "%" + tuKhoa + "%");

                    SqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        NhanVien nv = new NhanVien();
                        nv.maNhanVien = rd["maNhanVien"].ToString();
                        nv.hoNhanVien = rd["hoNhanVien"].ToString();
                        nv.tenNhanVien = rd["tenNhanVien"].ToString();
                        nv.gioiTinh = (Boolean)rd["gioiTinh"];
                        nv.diaChi = rd["diaChi"].ToString();
                        nv.soDienThoai = rd["soDienThoai"].ToString();
                        nv.ngaySinh = (DateTime)rd.GetDateTime(6);
                        nv.chucVu = rd["chucVu"].ToString();
                        nv.pass = rd["pass"].ToString();
                        nv.maCuaHang = rd["maCuaHang"].ToString();


                        ketQua.Add(nv);
                    }

                    rd.Close();
                }

            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu có lỗi
                // Ví dụ: MessageBox.Show("Lỗi khi tìm kiếm sản phẩm: " + ex.Message);
                throw ex;
            }
            finally
            {
                Dongketnoi();
            }
            return ketQua;
        }

        public void SuaNhanVien(NhanVien nv)
        {
            Moketnoi();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE NhanVien SET hoNhanVien = @hoNV, tenNhanVien = @tenNV, gioiTinh = @gioiTinh, diaChi = @diaChi, soDienThoai = @soDienThoai, ngaySinh = @ngaySinh, chucVu = @chucVu, pass = @pass, maCuaHang = @maCuaHang WHERE maNhanVien = @maNV";
                cmd.Connection = conec;
                cmd.Parameters.AddWithValue("@maNV", nv.maNhanVien);
                cmd.Parameters.AddWithValue("@hoNV", nv.hoNhanVien);
                cmd.Parameters.AddWithValue("@tenNV", nv.tenNhanVien);
                cmd.Parameters.AddWithValue("@gioiTinh", nv.gioiTinh);
                cmd.Parameters.AddWithValue("@diaChi", nv.diaChi);
                cmd.Parameters.AddWithValue("@soDienThoai", nv.soDienThoai);
                cmd.Parameters.AddWithValue("@ngaySinh", nv.ngaySinh);
                cmd.Parameters.AddWithValue("@chucVu", nv.chucVu);
                cmd.Parameters.AddWithValue("@pass", nv.pass);
                cmd.Parameters.AddWithValue("@maCuaHang", nv.maCuaHang);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                Dongketnoi();
            }
        }
        public bool IsForeignKeyInOtherTables(string maNV)
        {
            Moketnoi();
            var sql = "SELECT SUM(totalCount) FROM ( SELECT COUNT(*) AS totalCount FROM HoaDonBan WHERE maNhanVien = @MaNV " +
              "UNION " +
              "SELECT COUNT(*) AS totalCount FROM PhieuNhap WHERE maNhanVien = @MaNV) AS CombinedCounts";
            var cmd = new SqlCommand(sql, conec);
            cmd.Parameters.AddWithValue("@MaNV", maNV);

            int count = (int)cmd.ExecuteScalar();

            Dongketnoi();

            return count > 0;
        }

    }
}

