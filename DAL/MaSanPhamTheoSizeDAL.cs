using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MaSanPhamTheoSizeDAL : DBConnect
    {
        List<MaSanPhamTheoSize> msptsList = new List<MaSanPhamTheoSize>();
        public List<MaSanPhamTheoSize> LoadDlMaSPTheoSize()
        {
            Moketnoi();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM MaSanPhamTheoSize";
            cmd.Connection = conec;
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                MaSanPhamTheoSize mspts = new MaSanPhamTheoSize();
                mspts.maSPTheoSize = rd["maSPTheoSize"].ToString();
                mspts.maSize = rd["maSize"].ToString();
                mspts.maSanPham = rd["maSanPham"].ToString();
                mspts.soLuongTonKho = Convert.ToInt32(rd["soLuongTonKho"]);
                msptsList.Add(mspts);
            }
            rd.Close();
            Dongketnoi();
            return msptsList;
        }
        public void ThemSizeVaSoLuong(MaSanPhamTheoSize spts)
        {
            Moketnoi();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO MaSanPhamTheoSize (maSPTheoSize , maSize, maSanPham, soLuongTonKho) VALUES (@maSPTheoSize, @maSize, @maSP, @soLuongTonKho)";
            cmd.Connection = conec;
            cmd.Parameters.AddWithValue("@maSPTheoSize", spts.maSPTheoSize);
            cmd.Parameters.AddWithValue("@maSize", spts.maSize);
            cmd.Parameters.AddWithValue("@maSP", spts.maSanPham);
            cmd.Parameters.AddWithValue("@soLuongTonKho", spts.soLuongTonKho);
            cmd.ExecuteNonQuery();
            Dongketnoi();
        }
        public bool KiemTraMaSPTSTonTai(string maSPTS)
        {
            Moketnoi();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT COUNT(*) FROM MaSanPhamTheoSize WHERE maSPTheoSize = @maSPTheoSize";
            cmd.Connection = conec;
            cmd.Parameters.AddWithValue("@maSPTheoSize", maSPTS);
            int count = (int)cmd.ExecuteScalar();
            Dongketnoi();

            return count > 0;
        }
        public List<string> LayMaSizeTheoMaSanPham(string maSanPham)
        {
            List<string> maSizes = new List<string>();

            Moketnoi();

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT maSize FROM MaSanPhamTheoSize WHERE maSanPham = @maSanPham";
                cmd.Connection = conec;
                cmd.Parameters.AddWithValue("@maSanPham", maSanPham);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string maSize = reader["maSize"].ToString();
                        maSizes.Add(maSize);
                    }
                }
            }

            Dongketnoi();

            return maSizes;
        }

        public int LaySoLuongTheoMaSizeVaMaSanPham(string maSize, string maSanPham)
        {
            int soLuong = 0;

            Moketnoi();

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT soLuongTonKho FROM MaSanPhamTheoSize WHERE maSize = @maSize AND maSanPham = @maSanPham";
                cmd.Connection = conec;
                cmd.Parameters.AddWithValue("@maSize", maSize);
                cmd.Parameters.AddWithValue("@maSanPham", maSanPham);

                object result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    soLuong = Convert.ToInt32(result);
                }
            }

            Dongketnoi();

            return soLuong;
        }

        public void SuaSoLuongTonKho(MaSanPhamTheoSize sp)
        {
            Moketnoi();

            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "UPDATE MaSanPhamTheoSize SET soLuongTonKho = @soLuongTonKho WHERE maSize = @maSize AND maSanPham = @maSanPham";
                    cmd.Connection = conec;
                    cmd.Parameters.AddWithValue("@maSize", sp.maSize);
                    cmd.Parameters.AddWithValue("@maSanPham", sp.maSanPham);
                    cmd.Parameters.AddWithValue("@soLuongTonKho", sp.soLuongTonKho);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu có lỗi
                // Ví dụ: MessageBox.Show("Lỗi khi sửa số lượng tồn kho: " + ex.Message);
                throw ex;
            }
            finally
            {
                Dongketnoi();
            }
        }

        public void XoaSanPhamTheoSize(string maSP, string maSize)
        {
            Moketnoi();

            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "DELETE FROM MaSanPhamTheoSize WHERE maSanPham = @maSP and maSize = @maSize";
                    cmd.Connection = conec;
                    cmd.Parameters.AddWithValue("@maSP", maSP);
                    cmd.Parameters.AddWithValue("@maSize", maSize);
                    cmd.ExecuteNonQuery();
                }
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
        public MaSanPhamTheoSize getMSPTheoSize(MaSanPhamTheoSize mspts)
        {
            Moketnoi();
            var sql = "  select * from [MaSanPhamTheoSize] where maSPTheoSize = @maSPTheoSize";
            var cmd = new SqlCommand(sql, conec);
            cmd.Parameters.AddWithValue("@maSPTheoSize", mspts.maSPTheoSize);
            MaSanPhamTheoSize SPTheoSize = SPTheoSize = new MaSanPhamTheoSize();
            using (SqlDataReader rd = cmd.ExecuteReader())
            {
                while (rd.Read())
                {
                    SPTheoSize.maSPTheoSize = rd["maSPTheoSize"].ToString();
                    SPTheoSize.maSize = rd["maSize"].ToString();
                    SPTheoSize.maSanPham = rd["maSanPham"].ToString();
                    SPTheoSize.soLuongTonKho = Convert.ToInt32(rd["soLuongTonKho"].ToString());
                }
                Dongketnoi();
                return SPTheoSize;
            }
        }
        public List<MaSanPhamTheoSize> getSPTheoSIZE(SanPham sp)
        {
            List<MaSanPhamTheoSize> ctsp = new List<MaSanPhamTheoSize>();
            Moketnoi();
            var sql = "SELECT * FROM MaSanPhamTheoSize where maSanPham = @maSanPham";
            var cmd = new SqlCommand(sql, conec);

            cmd.Parameters.AddWithValue("@maSanPham", sp.maSanPham);

            MaSanPhamTheoSize msp = null;
            using (SqlDataReader rd = cmd.ExecuteReader())
            {
                while (rd.Read())
                {
                    msp = new MaSanPhamTheoSize();
                    msp.maSPTheoSize = rd.GetString(rd.GetOrdinal("maSPTheoSize"));
                    msp.maSize = rd["maSize"].ToString();
                    msp.maSanPham = sp.maSanPham.ToString();
                    msp.soLuongTonKho = Convert.ToInt32(rd["soLuongTonKho"]);
                    ctsp.Add(msp);
                }
            }
            Dongketnoi();
            return ctsp;
        }

        public bool IsForeignKeyInOtherTables(string mspts)
        {
            Moketnoi();
            var sql = "SELECT SUM(totalCount) FROM ( SELECT COUNT(*) AS totalCount FROM ChiTietPhieuNhapKho WHERE maSPTheoSize = @MaSP " +
              "UNION " +
              "SELECT COUNT(*) AS totalCount FROM SanPham_CuaHang WHERE maSPTheoSize = @MaSP) AS CombinedCounts";
            var cmd = new SqlCommand(sql, conec);
            cmd.Parameters.AddWithValue("@MaSP", mspts);

            int count = (int)cmd.ExecuteScalar();

            Dongketnoi();

            return count > 0;
        }

    }
}
