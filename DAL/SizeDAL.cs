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
    public class SizeDAL : DBConnect
    {

        public List<Size> getSize()
        {
            List<Size> sizes = new List<Size>();
            Moketnoi();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Size";
            cmd.Connection = conec;
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                Size size = new Size();
                size.maSize = rd.GetString(0);
                size.tenSize = rd.GetString(1);
                sizes.Add(size);
            }
            rd.Close();
            Dongketnoi();
            return sizes;
        }


    }
}
