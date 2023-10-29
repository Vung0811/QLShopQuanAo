using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DangNhapDAL
    {
        DBConnect dbc = new DBConnect();
        public Boolean CheckLogin(NhanVien nv)
        {
            dbc.Moketnoi();
            var sql = "SELECT COUNT(*) FROM dbo.NhanVien WHERE soDienThoai = @soDienThoai  AND pass = @pass";
            var cmd = new SqlCommand(sql, dbc.conec);
            cmd.Parameters.AddWithValue("@soDienThoai", nv.soDienThoai);
            cmd.Parameters.AddWithValue("@pass", nv.pass);
            if ((int)cmd.ExecuteScalar() > 0)
            {
                return true;
            }
            dbc.Dongketnoi();
            return false;
        }

        public String CheckPosition(NhanVien nv)
        {
            dbc.Moketnoi();
            if (CheckLogin(nv))
            {
                var sql = "SELECT chucVu FROM NhanVien where soDienThoai = @sodienthoai";
                var cmd = new SqlCommand(sql, dbc.conec);
                cmd.Parameters.AddWithValue("@sodienthoai", nv.soDienThoai);
                var result = cmd.ExecuteScalar();
                if (result != null)
                {
                    return result.ToString();
                }
            }
            dbc.Dongketnoi();
            return string.Empty;
        }

        public NhanVien getUser(String SDT)
        {
            dbc.Moketnoi();
            var sql = "SELECT * FROM NhanVien where soDienThoai = @sodienthoai";
            var cmd = new SqlCommand(sql, dbc.conec);
            cmd.Parameters.AddWithValue("@sodienthoai", SDT);
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
                    nv.soDienThoai = SDT;
                    nv.ngaySinh = rd.GetDateTime(6);
                    nv.chucVu = rd["chucVu"].ToString();
                    nv.pass = rd["pass"].ToString();
                    nv.maCuaHang = rd["maCuaHang"].ToString();
                }
            }
            dbc.Dongketnoi();
            return nv;
        }
    }
}