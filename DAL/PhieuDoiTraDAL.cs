using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PhieuDoiTraDAL : DBConnect
    {
        PhieuDoiTra pdt = new PhieuDoiTra();

        private List<PhieuDoiTra> pdtl = null;
        private List<CTPhieuDoiTra> ctpdtl = null;
        public int coutPhieuDoiTra(KhachHang kh, String mxl)
        {
            int i = 0;
            Moketnoi();
            try
            {
                var sql = "SELECT count(*) FROM PhieuDoiTra WHERE maKhachHang = @maKhachHang";
                if (mxl != null)
                {
                    sql += " and maXuLyDoiTra = @maXuLyDoiTra";
                }
                var cmd = new SqlCommand(sql, conec);
                cmd.Parameters.AddWithValue("@maKhachHang", kh.maKhachHang);

                if (mxl != null)
                {
                    cmd.Parameters.AddWithValue("@maXuLyDoiTra", mxl);
                }

                var result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    i = Convert.ToInt32(result);
                }
            }
            finally { Dongketnoi(); }
            return i;

        }

        public List<PhieuDoiTra> getPhieuDoiTraList(HoaDonBan hdb, XuLyDoiTra xldt)
        {
            List<PhieuDoiTra> pdtl = new List<PhieuDoiTra>();
            Moketnoi();
            try
            {
                var sql = "SELECT * FROM PhieuDoiTra";

                if (hdb != null || xldt != null)
                {
                    sql += " WHERE ";
                    if (hdb != null)
                    {
                        sql += " maHoaDon = @maHoaDon";
                    }
                    if (xldt != null)
                    {
                        if (hdb != null)
                        {
                            sql += " OR ";
                        }
                        sql += " maXuLyDoiTra = @maXuLyDoiTra";
                    }
                }
                sql += "  order by ngayDoiTra DESC";

                var cmd = new SqlCommand(sql, conec);
                if (hdb != null)
                {
                    cmd.Parameters.AddWithValue("@maHoaDon", hdb.maHoaDon);
                }
                if (xldt != null)
                {
                    cmd.Parameters.AddWithValue("@maXuLyDoiTra", xldt.maXuLyDoiTra);
                }
                PhieuDoiTra pdt = null;
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        pdt = new PhieuDoiTra();
                        pdt.maPhieuDoiTra = rd.GetString(rd.GetOrdinal("maPhieuDoiTra"));
                        pdt.maKhachHang = rd.GetString(rd.GetOrdinal("maKhachHang"));
                        pdt.maNhanVien = rd.GetString(rd.GetOrdinal("maNhanVien"));
                        pdt.ngayDoiTra = rd.GetDateTime(rd.GetOrdinal("ngayDoiTra"));
                        pdt.maXuLyDoiTra = rd.GetString(rd.GetOrdinal("maXuLyDoiTra"));
                        pdt.maHoaDon = rd.GetString(rd.GetOrdinal("maHoaDon"));
                        pdtl.Add(pdt);
                    }
                }
            }
            finally
            {
                Dongketnoi();
            }
            return pdtl;
        }
        public bool addPhieuDoiTra(PhieuDoiTra pdt)
        {
            bool success = false;
            Moketnoi();
            try
            {
                string SQL = "INSERT INTO PhieuDoiTra (maPhieuDoiTra, maNhanVien, maKhachHang, ngayDoiTra, maXuLyDoiTra, maHoaDon) " +
                             "VALUES (@maPhieuDoiTra, @maNhanVien, @maKhachHang, @ngayDoiTra, @maXuLyDoiTra, @maHoaDon)";

                SqlCommand cmd = new SqlCommand(SQL, conec);
                cmd.Parameters.AddWithValue("@maPhieuDoiTra", pdt.maPhieuDoiTra);
                cmd.Parameters.AddWithValue("@maNhanVien", pdt.maNhanVien);
                cmd.Parameters.AddWithValue("@maKhachHang", pdt.maKhachHang);
                cmd.Parameters.AddWithValue("@ngayDoiTra", pdt.ngayDoiTra);
                cmd.Parameters.AddWithValue("@maXuLyDoiTra", pdt.maXuLyDoiTra);
                cmd.Parameters.AddWithValue("@maHoaDon", pdt.maHoaDon);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    success = true;
                }
            }
            finally
            {
                Dongketnoi();
            }
            return success;
        }

        public Boolean delPhieuDoiTra(PhieuDoiTra pdt)
        {
            Moketnoi();
            Boolean success = false;
            try
            {
                string SQL = string.Format("DELETE FROM PhieuDoiTra WHERE maPhieuDoiTra = '{0}'", pdt.maPhieuDoiTra);
                SqlCommand cmd = new SqlCommand(SQL, conec);
                if (cmd.ExecuteNonQuery() > 0)
                    success = true;
            }
            finally { Dongketnoi(); }
            return success;
        }


        public List<CTPhieuDoiTra> getCTPDTList(CTPhieuDoiTra ctpdt)
        {
            ctpdtl = new List<CTPhieuDoiTra>();

            try
            {
                Moketnoi();
                var sql = "SELECT * FROM CTPhieuDoiTra WHERE maPhieuDoiTra = @maPhieuDoiTra";
                var cmd = new SqlCommand(sql, conec);
                cmd.Parameters.AddWithValue("@maPhieuDoiTra", ctpdt.maPhieuDoiTra);

                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        ctpdt = new CTPhieuDoiTra();
                        ctpdt.maPhieuDoiTra = rd.GetString(rd.GetOrdinal("maPhieuDoiTra"));
                        ctpdt.maSPTheoSize = rd.GetString(rd.GetOrdinal("maSPTheoSize"));
                        ctpdt.soLuong = rd.GetInt32(rd.GetOrdinal("soLuong"));
                        ctpdt.maSPTheoSizeRe = rd.GetString(rd.GetOrdinal("maSPTheoSizeRe"));
                        ctpdtl.Add(ctpdt);
                    }
                }
            }
            finally
            {
                Dongketnoi();
            }

            return ctpdtl;
        }


        public bool addCTPhieuDoiTra(CTPhieuDoiTra ctpdt)
        {
            Boolean success = false;
            Moketnoi();
            try      
            {
                string SQL = string.Format("INSERT INTO CTPhieuDoiTra VALUES ('{0}', '{1}', '{2}', '{3}' )",
                    ctpdt.maPhieuDoiTra, ctpdt.maSPTheoSize, ctpdt.soLuong, ctpdt.maSPTheoSizeRe);
                SqlCommand cmd = new SqlCommand(SQL, conec);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    success= true;
                }
            }
            finally { Dongketnoi(); }
            return success;
        }

        public List<PhieuDoiTra> TimKiemPDT(string tuKhoa)
        {
            List<PhieuDoiTra> ketQua = new List<PhieuDoiTra>();

            try
            {
                Moketnoi();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    // Sử dụng câu truy vấn SQL để tìm kiếm sản phẩm theo từ khóa
                    cmd.CommandText = "SELECT * FROM PhieuDoiTra WHERE maPhieuDoiTra LIKE @tuKhoa OR maNhanVien LIKE @tuKhoa OR maKhachHang LIKE @tuKhoa OR ngayDoiTra LIKE @tuKhoa OR maXuLyDoiTra LIKE @tuKhoa OR maHoaDon LIKE @tuKhoa";
                    cmd.Connection = conec;
                    cmd.Parameters.AddWithValue("@tuKhoa", "%" + tuKhoa + "%");

                    SqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        PhieuDoiTra pdt = new PhieuDoiTra();
                        pdt.maPhieuDoiTra = rd.GetString(rd.GetOrdinal("maPhieuDoiTra"));
                        pdt.maKhachHang = rd.GetString(rd.GetOrdinal("maKhachHang"));
                        pdt.maNhanVien = rd.GetString(rd.GetOrdinal("maNhanVien"));
                        pdt.ngayDoiTra = rd.GetDateTime(rd.GetOrdinal("ngayDoiTra"));
                        pdt.maXuLyDoiTra = rd.GetString(rd.GetOrdinal("maXuLyDoiTra"));
                        pdt.maHoaDon = rd.GetString(rd.GetOrdinal("maHoaDon"));
                        ketQua.Add(pdt);
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

    }
}
