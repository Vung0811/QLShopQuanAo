using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SanPham_CuaHangDAL : DBConnect
    {
        List<SanPham_CuaHang> spchList = new List<SanPham_CuaHang>();
        public List<SanPham_CuaHang> LoadDlSP_CH()
        {
            Moketnoi();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM SanPham_CuaHang";
            cmd.Connection = conec;
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                SanPham_CuaHang spch = new SanPham_CuaHang();
                spch.maCuaHang = rd["maCuaHang"].ToString();
                spch.maSPTheoSize = rd["maSPTheoSize"].ToString();
                spch.soLuong = Convert.ToInt32(rd["soLuong"]);
                spchList.Add(spch);
            }
            rd.Close();
            Dongketnoi();
            return spchList;
        }

        public void ThemSPChoCH(SanPham_CuaHang spch)
        {
            Moketnoi();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO SanPham_CuaHang VALUES (@maCuaHang, @maSPTheoSize, @soLuong)";
            cmd.Connection = conec;
            cmd.Parameters.AddWithValue("@maCuaHang", spch.maCuaHang);
            cmd.Parameters.AddWithValue("@maSPTheoSize", spch.maSPTheoSize);
            cmd.Parameters.AddWithValue("@soLuong", spch.soLuong);
            cmd.ExecuteNonQuery();
            Dongketnoi();
        }

        public void SuaSPCuaCH(SanPham_CuaHang spch)
        {
            Moketnoi();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE SanPham_CuaHang SET soLuong = @soLuong WHERE maCuaHang = @maCuaHang AND maSPTheoSize = @maSPTheoSize";
                cmd.Connection = conec;
                cmd.Parameters.AddWithValue("@maCuaHang", spch.maCuaHang);
                cmd.Parameters.AddWithValue("@maSPTheoSize", spch.maSPTheoSize);
                cmd.Parameters.AddWithValue("@soLuong", spch.soLuong);
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

        public void XoaSPCuaCH(string maCH, string maSPTS)
        {
            Moketnoi();

            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "DELETE FROM SanPham_CuaHang WHERE maCuaHang = @maCH AND maSPTheoSize = @maSPTS";
                    cmd.Connection = conec;
                    cmd.Parameters.AddWithValue("@maCH", maCH);
                    cmd.Parameters.AddWithValue("@maSPTS", maSPTS);

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

        public List<SanPham_CuaHang> TimKiemSanPham_CuaHang(string tuKhoa, string mch)
        {
            List<SanPham_CuaHang> ketQua = new List<SanPham_CuaHang>();

            try
            {
                Moketnoi();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    // Sử dụng câu truy vấn SQL để tìm kiếm sản phẩm theo từ khóa
                    cmd.CommandText = "SELECT * FROM SanPham_CuaHang WHERE (maCuaHang LIKE @tuKhoa OR maSPTheoSize LIKE @tuKhoa) AND maCuaHang = @maCH";
                    cmd.Connection = conec;
                    cmd.Parameters.AddWithValue("@tuKhoa", "%" + tuKhoa + "%");
                    cmd.Parameters.AddWithValue("@maCH", mch);
                    SqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        SanPham_CuaHang spch = new SanPham_CuaHang();
                        spch.maCuaHang = rd["maCuaHang"].ToString();
                        spch.maSPTheoSize = rd["maSPTheoSize"].ToString();
                        spch.soLuong = Convert.ToInt32(rd["soLuong"]);


                        ketQua.Add(spch);
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

        public List<SanPham_CuaHang> getSPTheoCuaHangList()
        {
            List<SanPham_CuaHang> SPTheoCuaHangList = new List<SanPham_CuaHang>();
            Moketnoi();
            var sql = "select * from SanPham_CuaHang";
            var cmd = new SqlCommand(sql, conec);
            SanPham_CuaHang SPCH = null;
            using (SqlDataReader rd = cmd.ExecuteReader())
            {
                while (rd.Read())
                {
                    SPCH = new SanPham_CuaHang();
                    SPCH.maSPTheoSize = rd["maSPTheoSize"].ToString();
                    SPCH.maCuaHang = rd["maCuaHang"].ToString();
                    SPCH.soLuong = Convert.ToInt32(rd["soLuong"].ToString());

                    SPTheoCuaHangList.Add(SPCH);
                }
            }
            Dongketnoi();
            return SPTheoCuaHangList;
        }
        public List<SanPham_CuaHang> getPNTheoCH(SanPham_CuaHang spch)
        {
            List<SanPham_CuaHang> SPTheoCuaHangList = new List<SanPham_CuaHang>();
            Moketnoi();
            var sql = "select * from SanPham_CuaHang where maCuaHang = @maCuaHang";
            var cmd = new SqlCommand(sql, conec);
            cmd.Parameters.AddWithValue("@maCuaHang", spch.maCuaHang);
            SanPham_CuaHang SPCH = null;
            using (SqlDataReader rd = cmd.ExecuteReader())
            {
                while (rd.Read())
                {
                    SPCH = new SanPham_CuaHang();
                    SPCH.maSPTheoSize = rd["maSPTheoSize"].ToString();
                    SPCH.maCuaHang = rd["maCuaHang"].ToString();
                    SPCH.soLuong = Convert.ToInt32(rd["soLuong"].ToString());

                    SPTheoCuaHangList.Add(SPCH);
                }
            }
            Dongketnoi();
            return SPTheoCuaHangList;
        }
        public SanPham_CuaHang getSanPhamCuaHang(String mch, String maSPTheoSize)
        {
            
            Moketnoi();
            var sql = "select * from SanPham_CuaHang where maCuaHang = @maCuaHang and maSPTheoSize = @maSPTheoSize";
            var cmd = new SqlCommand(sql, conec);
            cmd.Parameters.AddWithValue("@maCuaHang", mch);
            cmd.Parameters.AddWithValue("@maSPTheoSize", maSPTheoSize);
            SanPham_CuaHang spch = null;
            using (SqlDataReader rd = cmd.ExecuteReader())
            {
                while (rd.Read())
                {
                    spch = new SanPham_CuaHang();
                    spch.maCuaHang = rd.GetString(rd.GetOrdinal("maCuaHang"));
                    spch.maSPTheoSize = rd.GetString(rd.GetOrdinal("maSPTheoSize"));
                    spch.soLuong = rd.GetInt32(rd.GetOrdinal("soLuong"));
                }
            }
            Dongketnoi();
            return spch;
        }
        public bool updateSanPhamCuaHang(SanPham_CuaHang spch)
        {
            Boolean success = false;
            Moketnoi();
            try
            {
                string SQL = string.Format("UPDATE SanPham_CuaHang SET soLuong = '{0}' where maCuaHang = '{1}' and maSPTheoSize = '{2}' ",
                spch.soLuong, spch.maCuaHang, spch.maSPTheoSize);

                SqlCommand cmd = new SqlCommand(SQL, conec);
                if (cmd.ExecuteNonQuery() > 0)
                    success = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally { Dongketnoi(); }
            return success;

        }
    }
}
