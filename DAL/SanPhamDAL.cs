using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;
namespace DAL
{
    public class SanPhamDAL : DBConnect
    {
        List<SanPham> dssp = new List<SanPham>();

        public List<SanPham> LoadDlSanPham()
        {
            Moketnoi();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM SanPham";
            cmd.Connection = conec;
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                string maSP = rd.GetString(0);
                string tenSP = rd.GetString(1);
                string motaSP = rd.GetString(2);
                int giaNhap = rd.GetInt32(3);
                int donGiaNiemYet = rd.GetInt32(4);
                string chatLieu = rd.GetString(5);
                SanPham sp = new SanPham();
                sp.maSanPham = maSP;
                sp.tenSanPham = tenSP;
                sp.moTaSanPham = motaSP;
                sp.giaNhap = giaNhap;
                sp.donGiaNiemYet = donGiaNiemYet;
               
                sp.chatLieu = chatLieu;
                
                dssp.Add(sp);
            }
            rd.Close();
            Dongketnoi();
            return dssp;
        }

        public void ThemSanPham(SanPham sp)
        {
            Moketnoi();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO SanPham VALUES (@maSP, @tenSP, @motaSP, @giaNhap, @donGiaNiemYet, @chatLieu)";
            cmd.Connection = conec;
            cmd.Parameters.AddWithValue("@maSP", sp.maSanPham);
            cmd.Parameters.AddWithValue("@tenSP", sp.tenSanPham);
            cmd.Parameters.AddWithValue("@motaSP", sp.moTaSanPham);
            cmd.Parameters.AddWithValue("@giaNhap", sp.giaNhap);
            cmd.Parameters.AddWithValue("@donGiaNiemYet", sp.donGiaNiemYet);
            cmd.Parameters.AddWithValue("@chatLieu", sp.chatLieu);
            cmd.ExecuteNonQuery();
            Dongketnoi();
        }

        public bool KiemTraMaSanPhamTonTai(string maSP)
        {
            Moketnoi();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT COUNT(*) FROM SanPham WHERE maSanPham = @maSP";
            cmd.Connection = conec;
            cmd.Parameters.AddWithValue("@maSP", maSP);

            int count = (int)cmd.ExecuteScalar();
            Dongketnoi();

            return count > 0;
        }

        public void SuaSanPham(SanPham sp)
        {
            Moketnoi();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE SanPham SET tenSanPham = @tenSP, moTaSanPham = @motaSP, giaNhap = @giaNhap, donGiaNiemYet = @donGiaNiemYet,  chatLieu = @chatLieu WHERE maSanPham = @maSP";
                cmd.Connection = conec;
                cmd.Parameters.AddWithValue("@maSP", sp.maSanPham);
                cmd.Parameters.AddWithValue("@tenSP", sp.tenSanPham);
                cmd.Parameters.AddWithValue("@motaSP", sp.moTaSanPham);
                cmd.Parameters.AddWithValue("@giaNhap", sp.giaNhap);
                cmd.Parameters.AddWithValue("@donGiaNiemYet", sp.donGiaNiemYet);
                cmd.Parameters.AddWithValue("@chatLieu", sp.chatLieu);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu có lỗi
                // Ví dụ: MessageBox.Show("Lỗi khi sửa sản phẩm: " + ex.Message);
                throw ex;
            }
            finally
            {
                Dongketnoi();
            }
        }
        public void XoaSanPham(string maSP)
        {
            Moketnoi();

            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "DELETE FROM SanPham WHERE maSanPham = @maSP";
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
        public List<SanPham> TimKiemSanPham(string tuKhoa)
        {
            List<SanPham> ketQua = new List<SanPham>();

            try
            {
                Moketnoi();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    // Sử dụng câu truy vấn SQL để tìm kiếm sản phẩm theo từ khóa
                    cmd.CommandText = "SELECT * FROM SanPham WHERE maSanPham LIKE @tuKhoa OR tenSanPham LIKE @tuKhoa OR moTaSanPham LIKE @tuKhoa OR chatLieu LIKE @tuKhoa";
                    cmd.Connection = conec;
                    cmd.Parameters.AddWithValue("@tuKhoa", "%" + tuKhoa + "%");

                    SqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        string maSP = rd.GetString(0);
                        string tenSP = rd.GetString(1);
                        string motaSP = rd.GetString(2);
                        int giaNhap = rd.GetInt32(3);
                        int donGiaNiemYet = rd.GetInt32(4);
                        string chatLieu = rd.GetString(5);

                        SanPham sp = new SanPham
                        {
                            maSanPham = maSP,
                            tenSanPham = tenSP,
                            moTaSanPham = motaSP,
                            giaNhap = giaNhap,
                            donGiaNiemYet = donGiaNiemYet,
                            chatLieu = chatLieu,
                        };

                        ketQua.Add(sp);
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
        public SanPham getSanPham(String MaSanPham)
        {
            Moketnoi();
            var sql = "SELECT * FROM SanPham where maSanPham = @maSanPham";
            var cmd = new SqlCommand(sql, conec);
            cmd.Parameters.AddWithValue("@maSanPham", MaSanPham);
            SanPham sp = null;
            using (SqlDataReader rd = cmd.ExecuteReader())
            {
                while (rd.Read())
                {
                    sp = new SanPham();
                    sp.maSanPham = rd.GetString(rd.GetOrdinal("maSanPham"));
                    sp.tenSanPham = rd.GetString(rd.GetOrdinal("tenSanPham"));
                    sp.moTaSanPham = rd.GetString(rd.GetOrdinal("moTaSanPham"));
                    sp.giaNhap = rd.GetInt32(rd.GetOrdinal("giaNhap"));
                    sp.donGiaNiemYet = rd.GetInt32(rd.GetOrdinal("donGiaNiemYet"));
                    sp.chatLieu = rd.GetString(rd.GetOrdinal("chatLieu"));
                }
            }
            Dongketnoi();
            return sp;
        }

        public bool IsForeignKeyInOtherTables(string maSP)
        {
            Moketnoi();
            var sql = "SELECT COUNT(*) FROM MaSanPhamTheoSize WHERE maSanPham = @MaSP";
            var cmd = new SqlCommand(sql, conec);
            cmd.Parameters.AddWithValue("@MaSP", maSP);

            int count = (int)cmd.ExecuteScalar();

            Dongketnoi();

            return count > 0;
        }

    }
}
