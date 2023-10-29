using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace DAL
{
    public class KhachHangDAL:DBConnect
    {
        DBConnect DBConnect = new DBConnect();
        public List<KhachHang> getKhachHangList(String x)
        {
            List<KhachHang> khl = new List<KhachHang>();
            DBConnect.Moketnoi();
            var sql = "SELECT * FROM [KhachHang] WHERE [tenKhach] COLLATE Latin1_General_BIN LIKE @x OR SoDienThoai LIKE @x";
            var cmd = new SqlCommand(sql, DBConnect.conec);
            cmd.Parameters.AddWithValue("@x", $"%{x}%");
            KhachHang kh = null;
            using (SqlDataReader rd = cmd.ExecuteReader())
            {
                while (rd.Read())
                {

                    kh = new KhachHang();
                    kh.maKhachHang = rd["maKhachHang"].ToString();
                    kh.tenKhach = rd["tenKhach"].ToString();
                    kh.gioiTinh = (Boolean)rd["gioiTinh"];
                    kh.ngaySinh = rd.GetDateTime(3);
                    kh.diaChi = rd["diaChi"].ToString();
                    kh.soDienThoai = rd["soDienThoai"].ToString();
                    khl.Add(kh);
                }
            }
            DBConnect.Dongketnoi();
            return khl;
        }
        public KhachHang getKhachHang(String MaKhachHang)
        {
            DBConnect.Moketnoi();
            var sql = "SELECT * FROM KhachHang where maKhachHang = @maKhachHang or soDienThoai = @maKhachHang";
            var cmd = new SqlCommand(sql, DBConnect.conec);
            cmd.Parameters.AddWithValue("@maKhachHang", MaKhachHang);
            KhachHang kh = null;
            using (SqlDataReader rd = cmd.ExecuteReader())
            {
                while (rd.Read())
                {
                    kh = new KhachHang();
                    kh.maKhachHang = rd["maKhachHang"].ToString();
                    kh.tenKhach = rd["tenKhach"].ToString();                   
                    kh.gioiTinh = (Boolean)rd["gioiTinh"];
                    kh.diaChi = rd["diaChi"].ToString();
                    kh.ngaySinh = rd.GetDateTime(3);
                    kh.soDienThoai = rd["soDienThoai"].ToString();
                }
            }
            DBConnect.Dongketnoi();
            return kh;
        }
        public bool themKH(KhachHang kh)
        {
            DBConnect.Moketnoi();
            try
            {
                string SQL = "INSERT INTO khachhang (maKhachHang,tenKhach, gioiTinh, ngaySinh, diaChi, soDienThoai) " +
                             "VALUES (@maKhach,@tenKhach, @gioiTinh, @ngaySinh, @diaChi, @soDienThoai)";
                SqlCommand cmd = new SqlCommand(SQL, DBConnect.conec);

                cmd.Parameters.AddWithValue("@maKhach", kh.randomString());
                cmd.Parameters.AddWithValue("@tenKhach", kh.tenKhach);
                cmd.Parameters.AddWithValue("@gioiTinh", kh.gioiTinh);
                cmd.Parameters.AddWithValue("@ngaySinh", kh.ngaySinh);
                cmd.Parameters.AddWithValue("@diaChi", kh.diaChi);
                cmd.Parameters.AddWithValue("@soDienThoai", kh.soDienThoai);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            finally
            {
                DBConnect.Dongketnoi();
            }
        }
        public bool checkKhachHangValid(KhachHang kh)
        {
            Boolean Isvalid = false;
            DBConnect.Moketnoi();
            try
            {
                var sql = "SELECT COUNT(*) FROM dbo.KhachHang WHERE soDienThoai = @soDienThoai";
                var cmd = new SqlCommand(sql, DBConnect.conec);
                cmd.Parameters.AddWithValue("@soDienThoai", kh.soDienThoai);
                if ((int)cmd.ExecuteScalar() > 0)
                {
                    Isvalid = true;
                }
            }
         
            finally
            {
                DBConnect.Dongketnoi();
            }
            return Isvalid;
        }
        public bool editKhachHang(KhachHang kh) {
            Boolean success = false;
            DBConnect.Moketnoi();

            try
            {
                string SQL = "UPDATE khachhang SET tenKhach = @tenKhach, gioiTinh = @gioiTinh, ngaySinh = @ngaySinh, diaChi = @diaChi, soDienThoai = @soDienThoai WHERE maKhachHang = @maKhachHang";

                using (SqlCommand cmd = new SqlCommand(SQL, DBConnect.conec))
                {
                    cmd.Parameters.AddWithValue("@tenKhach", kh.tenKhach);
                    cmd.Parameters.AddWithValue("@gioiTinh", kh.gioiTinh);
                    cmd.Parameters.AddWithValue("@ngaySinh", kh.ngaySinh);
                    cmd.Parameters.AddWithValue("@diaChi", kh.diaChi);
                    cmd.Parameters.AddWithValue("@soDienThoai", kh.soDienThoai);
                    cmd.Parameters.AddWithValue("@maKhachHang", kh.maKhachHang);

                    if (cmd.ExecuteNonQuery() > 0)
                        success = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                DBConnect.Dongketnoi();
            }

            return success;

        }
        public void SendPromotionSMS(string promotionMessage)
        {

            List<KhachHang> khl = new List<KhachHang>();
            Moketnoi();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM KhachHang";
            cmd.Connection = conec;
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                KhachHang kh = new KhachHang();
                kh.tenKhach = rd["tenKhach"].ToString();
                kh.soDienThoai = rd["soDienThoai"].ToString();
                khl.Add(kh);
            }
            rd.Close();

            string twilioAccountSid = "AC5b783e3ca07e2574ff563832d11a039a";
            string twilioAuthToken = "b5a19624c9084f3238e1bb202b244573";
            string twilioPhoneNumber = "+19733232910";
            TwilioClient.Init(twilioAccountSid, twilioAuthToken);

            try
            {
                foreach (KhachHang kh1 in khl)
                {
                    string tenKhach = kh1.tenKhach;
                    string soDienThoai = kh1.soDienThoai;
                    var message = MessageResource.Create(
                    body: $"Shop ABC xin chào " + tenKhach + " ." + promotionMessage,
                    from: new Twilio.Types.PhoneNumber(twilioPhoneNumber),
                    //to: new Twilio.Types.PhoneNumber("+84" + soDienThoai)
                    to: new Twilio.Types.PhoneNumber("+84" + "396195139")
                );
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Boolean delKhachHang(KhachHang kh)
        {
            DBConnect.Moketnoi();
            Boolean success = false;
            try
            {
                string SQL = string.Format("DELETE FROM khachhang WHERE maKhachHang = '{0}'", kh.maKhachHang);
                SqlCommand cmd = new SqlCommand(SQL, DBConnect.conec);
                if (cmd.ExecuteNonQuery() > 0)
                    success = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally { DBConnect.Dongketnoi(); }
            return success;
        }

        public List<KhachHang> TimKiemKH(string tuKhoa)
        {
            List<KhachHang> ketQua = new List<KhachHang>();

            try
            {
                Moketnoi();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    // Sử dụng câu truy vấn SQL để tìm kiếm sản phẩm theo từ khóa
                    cmd.CommandText = "SELECT * FROM KhachHang WHERE maKhachHang LIKE @tuKhoa OR tenKhach LIKE @tuKhoa OR gioiTinh LIKE @tuKhoa OR diaChi LIKE @tuKhoa OR soDienThoai LIKE @tuKhoa";
                    cmd.Connection = conec;
                    cmd.Parameters.AddWithValue("@tuKhoa", "%" + tuKhoa + "%");

                    SqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        KhachHang kh = new KhachHang();
                        kh.maKhachHang = rd["maKhachHang"].ToString();
                        kh.tenKhach = rd["tenKhach"].ToString();
                        kh.gioiTinh = (Boolean)rd["gioiTinh"];
                        kh.diaChi = rd["diaChi"].ToString();
                        kh.ngaySinh = rd.GetDateTime(3);
                        kh.soDienThoai = rd["soDienThoai"].ToString();
                        ketQua.Add(kh);
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
