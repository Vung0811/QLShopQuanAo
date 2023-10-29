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
    public class PhieuNhapKhoDAL : DBConnect
    {
        public List<PhieuNhapKho> getPhieuNhapKhoList()
        {
            List<PhieuNhapKho> pnkl = new List<PhieuNhapKho>();
            Moketnoi();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM PhieuNhapKho";
            cmd.Connection = conec;
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                PhieuNhapKho pnk = new PhieuNhapKho();
                pnk.maPhieuNhap = rd["maPhieuNhap"].ToString();
                pnk.maNhaSanXuat = rd["maNhaSanXuat"].ToString();
                pnk.ngayNhap = (DateTime)rd.GetDateTime(2);
                pnkl.Add(pnk);
            }
            rd.Close();
            Dongketnoi();
            return pnkl;
        }

        public void ThemPhieuNhapKho(PhieuNhapKho pnk)
        {
            Moketnoi();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO PhieuNhapKho VALUES (@maPhieuNhap, @maNhaSanXuat, @ngayNhap)";
            cmd.Connection = conec;
            cmd.Parameters.AddWithValue("@maPhieuNhap", pnk.maPhieuNhap);
            cmd.Parameters.AddWithValue("@maNhaSanXuat", pnk.maNhaSanXuat);
            cmd.Parameters.AddWithValue("@ngayNhap", pnk.ngayNhap);
            cmd.ExecuteNonQuery();
            Dongketnoi();
        }

        public void ThemCTPhieuNhapKho(ChiTietPhieuNhapKho ctpnk)
        {
            Moketnoi();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO ChiTietPhieuNhapKho VALUES (@maPhieuNhap, @maSPTheoSize, @soLuong)";
            cmd.Connection = conec;
            cmd.Parameters.AddWithValue("@maPhieuNhap", ctpnk.maPhieuNhap);
            cmd.Parameters.AddWithValue("@maSPTheoSize", ctpnk.maSPTheoSize);
            cmd.Parameters.AddWithValue("@soLuong", ctpnk.soLuong);
            cmd.ExecuteNonQuery();
            Dongketnoi();
        }

        public List<ChiTietPhieuNhapKho> getCTPhieuNhapKho(PhieuNhapKho pnk)
        {
            List<ChiTietPhieuNhapKho> ctpnkl = new List<ChiTietPhieuNhapKho>();
            Moketnoi();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM ChiTietPhieuNhapKho WHERE maPhieuNhap = @maPhieuNhap";
            cmd.Connection = conec;
            cmd.Parameters.AddWithValue("@maPhieuNhap", pnk.maPhieuNhap);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                ChiTietPhieuNhapKho ctpn = new ChiTietPhieuNhapKho();
                ctpn.maPhieuNhap = rd["maPhieuNhap"].ToString();
                ctpn.maSPTheoSize = rd["maSPTheoSize"].ToString();
                ctpn.soLuong = Convert.ToInt32(rd["soLuong"]);
                ctpnkl.Add(ctpn);
            }
            rd.Close();
            Dongketnoi();
            return ctpnkl;
        }

        public List<PhieuNhapKho> TimKiemPhieuNhapKho(string tuKhoa)
        {
            List<PhieuNhapKho> ketQua = new List<PhieuNhapKho>();

            try
            {
                Moketnoi();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    // Sử dụng câu truy vấn SQL để tìm kiếm sản phẩm theo từ khóa
                    cmd.CommandText = "SELECT * FROM PhieuNhapKho WHERE maPhieuNhap LIKE @tuKhoa OR maNhaSanXuat LIKE @tuKhoa OR ngayNhap LIKE @tuKhoa";
                    cmd.Connection = conec;
                    cmd.Parameters.AddWithValue("@tuKhoa", "%" + tuKhoa + "%");

                    SqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        PhieuNhapKho pnk = new PhieuNhapKho();
                        pnk.maPhieuNhap = rd["maPhieuNhap"].ToString();
                        pnk.maNhaSanXuat = rd["maNhaSanXuat"].ToString();
                        pnk.ngayNhap = (DateTime)rd.GetDateTime(2);
                        ketQua.Add(pnk);
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
        public PhieuNhapKho getPhieuNhapKho(String maPNK)
        {
            Moketnoi();
            var sql = "SELECT * FROM PhieuNhapKho where maPhieuNhap = @maPN";
            var cmd = new SqlCommand(sql, conec);
            cmd.Parameters.AddWithValue("@maPN", maPNK);
            PhieuNhapKho pnk = null;
            using (SqlDataReader rd = cmd.ExecuteReader())
            {
                while (rd.Read())
                {

                    pnk = new PhieuNhapKho();
                    pnk.maPhieuNhap = rd["maPhieuNhap"].ToString();
                    pnk.maNhaSanXuat = rd["maNhaSanXuat"].ToString();
                    pnk.ngayNhap = (DateTime)rd.GetDateTime(2);
                }
            }
            Dongketnoi();
            return pnk;
        }
    }
}
