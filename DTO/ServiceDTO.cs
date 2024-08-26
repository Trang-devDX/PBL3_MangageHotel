using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ServiceDTO
    {
        public int IdBooking { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }    
        public int Quantity { get; set; }
    }
}
