using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    public class CBBItem
    {
        public string Text { get; set; }
        public int ID { get; set; }
        public override string ToString()
        {
            return Text;
        }
    }
}
