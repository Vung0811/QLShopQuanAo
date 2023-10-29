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

    public class DBConnect
    {
        public SqlConnection conec = null;
        string strconec = @"Data Source=DELL\MSSQLSERVER02;Initial Catalog=ShopQuanAo;Integrated Security=True";
       
        public void Moketnoi()
        {
            if (conec == null)
            {
                conec = new SqlConnection(strconec);

            }
            if (conec.State == System.Data.ConnectionState.Closed)
            {
                conec.Open();
            }
        }
        public void Dongketnoi()
        {
            if (conec != null && conec.State == System.Data.ConnectionState.Open)
            {
                conec.Close();
            }
        }
    }
}
