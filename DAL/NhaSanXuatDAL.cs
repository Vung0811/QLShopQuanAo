using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class NhaSanXuatDAL : DBConnect
    {
        public List<NhaSanXuat> getNhaSX()
        {
            List<NhaSanXuat> NhaSX = new List<NhaSanXuat>();
            Moketnoi();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM NhaSanXuat";
            cmd.Connection = conec;
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                NhaSanXuat nsx = new NhaSanXuat();
                nsx.maNhaSanXuat = rd.GetString(0);
                nsx.tenNhaSanXuat = rd.GetString(1);
                nsx.soDienThoai = rd.GetString(2);
                nsx.diaChi = rd.GetString(3);
                nsx.email = rd.GetString(4);
                nsx.website = rd.GetString(5);
                NhaSX.Add(nsx);
            }
            rd.Close();
            return NhaSX;
        }

        public void ThemNSX(NhaSanXuat nsx)
        {
            Moketnoi();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO NhaSanXuat VALUES (@maNhaSanXuat, @tenNhaSanXuat, @soDienThoai, @diaChi, @email, @website)";
            cmd.Connection = conec;
            cmd.Parameters.AddWithValue("@maNhaSanXuat", nsx.maNhaSanXuat);
            cmd.Parameters.AddWithValue("@tenNhaSanXuat", nsx.tenNhaSanXuat);
            cmd.Parameters.AddWithValue("@soDienThoai", nsx.soDienThoai);
            cmd.Parameters.AddWithValue("@diaChi", nsx.diaChi);
            cmd.Parameters.AddWithValue("@email", nsx.email);
            cmd.Parameters.AddWithValue("@website", nsx.website);
            cmd.ExecuteNonQuery();
            Dongketnoi();
        }

        public void SuaNSX(NhaSanXuat nsx)
        {
            Moketnoi();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE NhaSanXuat SET tenNhaSanXuat = @tenNhaSanXuat, soDienThoai = @soDienThoai, diaChi = @diaChi, email = @email, website = @website WHERE maNhaSanXuat = @maNhaSanXuat";
                cmd.Connection = conec;
                cmd.Parameters.AddWithValue("@maNhaSanXuat", nsx.maNhaSanXuat);
                cmd.Parameters.AddWithValue("@tenNhaSanXuat", nsx.tenNhaSanXuat);
                cmd.Parameters.AddWithValue("@soDienThoai", nsx.soDienThoai);
                cmd.Parameters.AddWithValue("@diaChi", nsx.diaChi);
                cmd.Parameters.AddWithValue("@email", nsx.email);
                cmd.Parameters.AddWithValue("@website", nsx.website);
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

        public void XoaNSX(string maNSX)
        {
            Moketnoi();

            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "DELETE FROM NhaSanXuat WHERE maNhaSanXuat = @maNSX";
                    cmd.Connection = conec;
                    cmd.Parameters.AddWithValue("@maNSX", maNSX);

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

        public List<NhaSanXuat> TimKiemNSX(string tuKhoa)
        {
            List<NhaSanXuat> ketQua = new List<NhaSanXuat>();

            try
            {
                Moketnoi();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    // Sử dụng câu truy vấn SQL để tìm kiếm sản phẩm theo từ khóa
                    cmd.CommandText = "SELECT * FROM NhaSanXuat WHERE maNhaSanXuat LIKE @tuKhoa OR tenNhaSanXuat LIKE @tuKhoa OR soDienThoai LIKE @tuKhoa OR diaChi LIKE @tuKhoa OR email LIKE @tuKhoa OR website LIKE @tuKhoa";
                    cmd.Connection = conec;
                    cmd.Parameters.AddWithValue("@tuKhoa", "%" + tuKhoa + "%");

                    SqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        NhaSanXuat nsx = new NhaSanXuat();
                        nsx.maNhaSanXuat = rd["maNhaSanXuat"].ToString();
                        nsx.tenNhaSanXuat = rd["tenNhaSanXuat"].ToString();
                        nsx.soDienThoai = rd["soDienThoai"].ToString();
                        nsx.diaChi = rd["diaChi"].ToString();
                        nsx.email = rd["email"].ToString();
                        nsx.website = rd["website"].ToString();
                        ketQua.Add(nsx);
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

        public bool IsForeignKeyInOtherTables(string MaNSX)
        {
            Moketnoi();
            var sql = "SELECT COUNT(*) FROM PhieuNhapKho WHERE maNhaSanXuat = @maNSX";
            var cmd = new SqlCommand(sql, conec);
            cmd.Parameters.AddWithValue("@maNSX", MaNSX);

            int count = (int)cmd.ExecuteScalar();

            Dongketnoi();

            return count > 0;
        }
    }
}
