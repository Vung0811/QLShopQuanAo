using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChucVu
    {
        public String maChucVu { set; get; }
        public String tenChucVu { set; get; }
        public override string ToString()
        {
            return tenChucVu;
        }
    }
}
