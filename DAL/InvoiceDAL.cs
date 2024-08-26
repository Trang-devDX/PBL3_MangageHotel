using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class InvoiceDAL
    {
        private static InvoiceDAL _Instance;
        public static InvoiceDAL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new InvoiceDAL();
                }
                return _Instance;
            }
        }
        public void Add(Invoice inv)
        {
            MangeHotelEntities db = new MangeHotelEntities();
            db.Invoices.Add(inv);
            db.SaveChanges();
        }
        public double TotalMoney(DateTime start, DateTime finish)
        {
            MangeHotelEntities db = new MangeHotelEntities();
            var temp = from book in db.Bookings
                       join invoice in db.Invoices on book.IdBooking equals invoice.IdBooking
                       where book.DateIn >= start && book.DateIn <= finish
                       select new
                       {
                           invoice.Total
                       };
            double totalMoney = 0;  
            foreach(var i in temp)
            {
                totalMoney += (double)i.Total;
            }
            return totalMoney;
                       
        }
        public List<KeyValuePair<string, double>> Statistical_Amount(DateTime start, DateTime finish)
        {
            MangeHotelEntities db = new MangeHotelEntities();
            List<KeyValuePair<string, double>> result = new List<KeyValuePair<string, double>>();
            var temp = (from book in db.Bookings
                       join invoice in db.Invoices on book.IdBooking equals invoice.IdBooking
                       let date = book.DateIn ?? DateTime.MinValue
                       where book.DateIn >= start && book.DateIn <= finish
                       group invoice.Total by DbFunctions.TruncateTime(date) into g
                       select new
                       {
                           Date = g.Key,
                           Amount = g.Sum()
                       }).ToList();
            TimeSpan duration = finish - start;
            int numberOfDays = Math.Abs(duration.Days);
            if (numberOfDays <= 30)
            {
                foreach (var i in temp)
                {
                    result.Add(new KeyValuePair<string, double>(((DateTime)i.Date).ToString("dd MMM"), (double)i.Amount));
                }
            }
            else
            {
                if (numberOfDays <= 92)
                {
                    result = (from orderList in temp
                              group orderList.Amount by new
                              {
                                  Week = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(
                                      (DateTime)orderList.Date,
                                      CalendarWeekRule.FirstDay,
                                      DayOfWeek.Monday
                                  ),
                                  Month = ((DateTime)orderList.Date).Month
                              } into order
                              select new KeyValuePair<string, double>(
                                   "Week " + order.Key.Week.ToString(), (double)order.Sum())).ToList();


                }
                else
                {
                    if (numberOfDays <= 365*2)
                    {
                        bool Isyear = numberOfDays <= 365 ? true : false;   
                        result = (from orderList in temp
                                  group orderList.Amount by ((DateTime)orderList.Date).ToString("MMM yyyy")
                                  into order
                                  select new KeyValuePair<string, double>(
                                      Isyear ? order.Key.Substring(0,order.Key.IndexOf(" ")) : order.Key, (double)order.Sum())
                                ).ToList();
                    }
                    else
                    {
                            bool Isyear = numberOfDays <= 365 ? true : false;
                            result = (from orderList in temp
                                      group orderList.Amount by ((DateTime)orderList.Date).ToString("yyyy")
                                      into order
                                      select new KeyValuePair<string, double>(
                                          order.Key , (double)order.Sum())
                                    ).ToList();
                    }
                }
            }
            return result;
        }
    }
}

