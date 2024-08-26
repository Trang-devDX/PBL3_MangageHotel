using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Util
{
    public class ValidateInformation
    {
        public static Boolean CCCD(string CCCD)
        {
            if (CCCD.Length != 10) return false;
            if(IsNumeric.Check(CCCD) == false) return false;
            return true;
        }
        public static Boolean Phone(string Phone)
        {
            if (Phone.Length != 10) return false;
            if (IsNumeric.Check(Phone) == false) return false;
            if (Phone[0] != '0') return false;
            return true;
        }
    }
}
