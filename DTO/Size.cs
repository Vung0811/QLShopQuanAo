using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Size
    {
        public string maSize
        { get; set; }
        public string tenSize
        { get; set; }
        public override string ToString()
        {
            return tenSize; 
        }
    }
}
