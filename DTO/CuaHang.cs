using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CuaHang
    {
        public String maCuaHang { set; get; }
        public String tenCuaHang { set; get; }
        public String diaChi { set; get; }
        public String SDT { set; get; }
        public TimeSpan gioMoCua { set; get; }
        public TimeSpan gioDongCua { set; get; }

    }
}
