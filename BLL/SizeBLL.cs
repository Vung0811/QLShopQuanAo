using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace BLL
{
    public class SizeBLL
    {
        
        SizeDAL sizeDAL = new SizeDAL();
        

        public List<Size> GetSizes()
        {
            return sizeDAL.getSize();
        }
    }

}

