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
    public class AnhSanPhamDAL : DBConnect
    {
        public void ThemAnhSanPham(AnhSanPham asp)
        {
            Moketnoi();

            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO AnhSanPham VALUES (@maAnh, @urlAnh, @maSanPham)";
                    cmd.Connection = conec;
                    cmd.Parameters.AddWithValue("@maAnh", asp.maAnh);
                    cmd.Parameters.AddWithValue("@urlAnh", asp.urlAnh);
                    cmd.Parameters.AddWithValue("@maSanPham", asp.maSanPham);


                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu có lỗi
                // Ví dụ: MessageBox.Show("Lỗi khi thêm ảnh: " + ex.Message);
                throw ex;
            }
            finally
            {
                Dongketnoi();
            }
        }

        public List<string> LayDanhSachDuongDanAnh(string maSanPham)
        {
            List<string> danhSachDuongDanAnh = new List<string>();

            Moketnoi();

            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT urlAnh FROM AnhSanPham WHERE maSanPham = @maSanPham";
                    cmd.Connection = conec;
                    cmd.Parameters.AddWithValue("@maSanPham", maSanPham);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string duongDanAnh = reader["urlAnh"].ToString();
                            danhSachDuongDanAnh.Add(duongDanAnh);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu có lỗi
                // Ví dụ: MessageBox.Show("Lỗi khi lấy đường dẫn ảnh: " + ex.Message);
                throw ex;
            }
            finally
            {
                Dongketnoi();
            }

            return danhSachDuongDanAnh;
        }
        public void XoaMaSanPhamTrongAnh(string maSP)
        {
            Moketnoi();

            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "DELETE FROM AnhSanPham WHERE maSanPham = @maSP";
                    cmd.Connection = conec;
                    cmd.Parameters.AddWithValue("@maSP", maSP);

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
    }
}
