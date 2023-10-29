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
    public class ChucVuDAL : DBConnect
    {
        public List<ChucVu> getChucVu()
        {
            List<ChucVu> chucVu = new List<ChucVu>();
            Moketnoi();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM ChucVu where tenChucVu != 'Admin' ";
            cmd.Connection = conec;
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                ChucVu cv = new ChucVu();
                cv.maChucVu = rd.GetString(0);
                cv.tenChucVu = rd.GetString(1);
                chucVu.Add(cv);
            }
            rd.Close();
            Dongketnoi();
            return chucVu;
        }

        public ChucVu getChucVuCuaNV(NhanVien nv)
        {
            Moketnoi();
            var sql = "SELECT * FROM ChucVu where maChucVu = @maChucVu";
            var cmd = new SqlCommand(sql, conec);
            cmd.Parameters.AddWithValue("@maChucVu", nv.chucVu);
            ChucVu cv = null;
            using (SqlDataReader rd = cmd.ExecuteReader())
            {
                while (rd.Read())
                {
                    cv = new ChucVu();
                    cv.maChucVu = rd.GetString(rd.GetOrdinal("maChucVu"));
                    cv.tenChucVu = rd.GetString(rd.GetOrdinal("tenChucVu"));
                }
            }
            Dongketnoi();
            return cv;
        }
    }
}
