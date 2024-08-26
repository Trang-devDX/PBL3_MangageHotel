using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    public class MoneyRoom
    {
        public  static double CalculateCost(DateTime dateIn, DateTime dateOut, double costPerHour)
        {
            
            double totalCost = 0;
            int totalMinutes = (int)(dateOut - dateIn).TotalMinutes;
            int remainderMinutes = totalMinutes % 60;
            int hours = totalMinutes / 60;
            if(remainderMinutes > 40) 
            {
                hours++;
                totalCost = hours * costPerHour;
            }
            if (remainderMinutes <= 40 && remainderMinutes >= 10)
            {
                totalCost = hours * costPerHour + 0.5 * costPerHour;
            }
            if(remainderMinutes >=0 && remainderMinutes < 10)
            {
                totalCost = hours * costPerHour;
            }    
            return totalCost;
        }

    }
}
