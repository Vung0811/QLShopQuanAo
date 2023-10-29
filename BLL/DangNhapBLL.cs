using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BLL
{
    public class DangNhapBLL
    {
        DangNhapDAL dangnhapdall = new DangNhapDAL();
        String hash = ConfigurationManager.AppSettings["hash"];

        public int CheckUser(NhanVien nv)
        {
            int i;
            nv.pass = maHoaMK(nv.pass);
            if (int.TryParse(dangnhapdall.CheckPosition(nv), out i))
                return Int32.Parse(dangnhapdall.CheckPosition(nv));
            else
                return 0;
        }
        public NhanVien getUser(String SDT)
        {
            return dangnhapdall.getUser(SDT);
        }

        public String maHoaMK(String mk)
        {
            byte[] data = UTF8Encoding.UTF8.GetBytes(mk);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider()
                {
                    Key = keys,
                    Mode = CipherMode.CBC,
                    Padding = PaddingMode.PKCS7
                })
                {
                    tripDes.IV = new byte[8];

                    ICryptoTransform transform = tripDes.CreateEncryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    return Convert.ToBase64String(results, 0, results.Length);
                }
            }
        }
        public String giaiMaMK(String mk)
        {
            byte[] data = Convert.FromBase64String(mk);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider()
                {
                    Key = keys,
                    Mode = CipherMode.CBC,
                    Padding = PaddingMode.PKCS7
                })
                {

                    tripDes.IV = new byte[8];

                    ICryptoTransform transform = tripDes.CreateDecryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    return UTF8Encoding.UTF8.GetString(results);
                }
            }
        }
    }
}