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
    public class CuaHangDAL:DBConnect
    {
        DBConnect dbc = new DBConnect();
        public CuaHang getCuaHang(String MaCuaHang)
        {
            dbc.Moketnoi();
            var sql = "SELECT * FROM CuaHang where maCuaHang = @maCuaHang";
            var cmd = new SqlCommand(sql, dbc.conec);
            cmd.Parameters.AddWithValue("@maCuaHang", MaCuaHang);
            CuaHang ch = null;
            using (SqlDataReader rd = cmd.ExecuteReader())
            {
                while (rd.Read())
                {
                    ch = new CuaHang();
                    ch.maCuaHang = rd["maCuaHang"].ToString();
                    ch.tenCuaHang = rd["tenCuaHang"].ToString();
                    ch.diaChi = rd["diaChi"].ToString();
                    ch.SDT = rd["SDT"].ToString();
                    ch.gioMoCua = rd.GetTimeSpan(4);
                    ch.gioDongCua = rd.GetTimeSpan(5);
                }
            }
            dbc.Dongketnoi();
            return ch;
        }

        public List<CuaHang> getCuaHang()
        {
            List<CuaHang> cuaHang = new List<CuaHang>();
            Moketnoi();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM CuaHang";
            cmd.Connection = conec;
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                CuaHang ch = new CuaHang();
                ch.maCuaHang = rd.GetString(0);
                ch.tenCuaHang = rd.GetString(1);
                ch.diaChi = rd.GetString(2);
                ch.SDT = rd.GetString(3);
                ch.gioMoCua = rd.GetTimeSpan(4); 
                ch.gioDongCua = rd.GetTimeSpan(5); 
                cuaHang.Add(ch);
            }
            rd.Close();
            Dongketnoi();
            return cuaHang;
        }

        public void ThemCuaHang(CuaHang ch)
        {
            Moketnoi();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO CuaHang VALUES (@maCH, @tenCH, @diaChi, @SDT, @gioMoCua, @gioDongCua)";
            cmd.Connection = conec;
            cmd.Parameters.AddWithValue("@maCH", ch.maCuaHang);
            cmd.Parameters.AddWithValue("@tenCH", ch.tenCuaHang);
            cmd.Parameters.AddWithValue("@diaChi", ch.diaChi);
            cmd.Parameters.AddWithValue("@SDT", ch.SDT);
            cmd.Parameters.AddWithValue("@gioMoCua", ch.gioMoCua);
            cmd.Parameters.AddWithValue("@gioDongCua", ch.gioDongCua); 
            cmd.ExecuteNonQuery();
            Dongketnoi();
        }
        public void SuaCuaHang(CuaHang ch)
        {
            Moketnoi();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE CuaHang SET tenCuaHang = @tenCH, diaChi = @diaChi, SDT = @SDT, gioMoCua = @gioMoCua, gioDongCua = @gioDongCua WHERE maCuaHang = @maCH";
                cmd.Connection = conec;
                cmd.Parameters.AddWithValue("@maCH", ch.maCuaHang);
                cmd.Parameters.AddWithValue("@tenCH", ch.tenCuaHang);
                cmd.Parameters.AddWithValue("@diaChi", ch.diaChi);
                cmd.Parameters.AddWithValue("@SDT", ch.SDT);
                cmd.Parameters.AddWithValue("@gioMoCua", ch.gioMoCua);
                cmd.Parameters.AddWithValue("@gioDongCua", ch.gioDongCua);
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

        public void XoaCuaHang(string maCH)
        {
            Moketnoi();

            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "DELETE FROM CuaHang WHERE maCuaHang = @maCH";
                    cmd.Connection = conec;
                    cmd.Parameters.AddWithValue("@maCH", maCH);

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

        public List<CuaHang> TimKiemCuaHang(string tuKhoa)
        {
            List<CuaHang> ketQua = new List<CuaHang>();

            try
            {
                Moketnoi();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    // Sử dụng câu truy vấn SQL để tìm kiếm sản phẩm theo từ khóa
                    cmd.CommandText = "SELECT * FROM CuaHang WHERE maCuaHang LIKE @tuKhoa OR tenCuaHang LIKE @tuKhoa OR diaChi LIKE @tuKhoa OR SDT LIKE @tuKhoa";
                    cmd.Connection = conec;
                    cmd.Parameters.AddWithValue("@tuKhoa", "%" + tuKhoa + "%");

                    SqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        CuaHang ch = new CuaHang();
                        ch.maCuaHang = rd["maCuaHang"].ToString();
                        ch.tenCuaHang = rd["tenCuaHang"].ToString();
                        ch.diaChi = rd["diaChi"].ToString();
                        ch.SDT = rd["SDT"].ToString();
                        ch.gioMoCua = rd.GetTimeSpan(4);
                        ch.gioDongCua = rd.GetTimeSpan(5);
                    

                        ketQua.Add(ch);
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
        public bool IsForeignKeyInOtherTables(string maCH)
        {
            Moketnoi();
            var sql = "SELECT SUM(totalCount) FROM ( SELECT COUNT(*) AS totalCount FROM NhanVien WHERE maCuaHang = @MaCH " +
              "UNION " +
              "SELECT COUNT(*) AS totalCount FROM SanPham_CuaHang WHERE maCuaHang = @MaCH) AS CombinedCounts";
            var cmd = new SqlCommand(sql, conec);
            cmd.Parameters.AddWithValue("@MaCH", maCH);

            int count = (int)cmd.ExecuteScalar();

            Dongketnoi();

            return count > 0;
        }

    }
}
