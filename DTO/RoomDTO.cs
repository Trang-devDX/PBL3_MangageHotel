using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class RoomDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int People { get; set; }
        public double HourlyRate { get; set; }
        public int IdBooking { get; set; }
    }
}
