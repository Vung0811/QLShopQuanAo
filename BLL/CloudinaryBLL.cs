using System;

using CloudinaryDotNet;
using System.Data.SqlClient;
using CloudinaryDotNet.Actions;
using DTO;
using System.Drawing;
using System.IO;
using System.Configuration;
namespace BLL
{

    public class CloudinaryBLL
    {
        AnhSanPhamBLL aspBLL = new AnhSanPhamBLL();

        private static String CLOUD_NAME = ConfigurationManager.AppSettings["CLOUD_NAME"];
        private static String API_KEY = ConfigurationManager.AppSettings["API_KEY"];
        private static String API_SECRET = ConfigurationManager.AppSettings["API_SECRET"];
        static CloudinaryDotNet.Account account = new CloudinaryDotNet.Account(
                CLOUD_NAME,
                 API_KEY,
                API_SECRET
            );
         Cloudinary cloudinary = new Cloudinary(account);

        public void UploadAndSaveToDatabase(string imagePath, AnhSanPham asp)
        {
           
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(imagePath),
                Folder = "ShopQuanAo"
            };

            var uploadResult = cloudinary.Upload(uploadParams);

            string imageUrl = uploadResult.SecureUri.ToString();
            asp.urlAnh = imageUrl;
            aspBLL.ThemAnhSanPham(asp);
        }
        public byte[] getAnhGioiTinh(Boolean x)
        {
            String femaleID = "hffkhwzxjmysubhbnqqi";
            String maleID = "hxmt8cdamwkooqxe6ujx";
            String imgUrl = "";
            CloudinaryDotNet.Actions.GetResourceResult rs = null;
            if (x)
            {
                rs = cloudinary.GetResource(maleID);  
            }   
            else
            {
                rs = cloudinary.GetResource(femaleID);
            }
            imgUrl = rs.Url.ToString();
            System.Net.WebClient  webClient = new System.Net.WebClient();
            byte[] imageBytes = webClient.DownloadData(imgUrl);
            return imageBytes;
        }
    }
}