using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ReceptionistDTO
    {
        public int IdReceptionist { get; set; }
        public string CCCD { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public bool Gender { get; set; }
        public DateTime Birth { get; set; }
        public double Salary { get; set; }
        public bool IsWork { get; set; }
    }
}
