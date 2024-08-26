using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;
using DTO;

namespace DAL
{
    public class BookingDAL
    {
        private static BookingDAL _Instance;
        public static BookingDAL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BookingDAL();
                }
                return _Instance;
            }
        }
        public List<Booking> GetAllBooking()
        {
            List<Booking> list = new List<Booking>();
            using (MangeHotelEntities db = new MangeHotelEntities())
            {
                var result = db.Bookings.ToList();
                foreach (var book in result)
                {
                    list.Add(book);
                }
            }
            return list;
        }
        public void Add(Booking book)
        {
            MangeHotelEntities db = new MangeHotelEntities();
            db.Bookings.Add(book);
            db.SaveChanges();
        }
        public void Update(Booking book)
        {
            MangeHotelEntities db = new MangeHotelEntities();
            Booking temp = db.Bookings.Where(p => p.IdBooking == book.IdBooking).FirstOrDefault();
            temp.IdRoom = book.IdRoom;
            temp.IdCustomer = book.IdCustomer;
            temp.IdCreater = book.IdCreater;
            temp.DateIn = book.DateIn;
            temp.DateOut = book.DateOut;
            db.SaveChanges();
        }
        public double TotalBooking(DateTime start, DateTime finish)
        {
            MangeHotelEntities db = new MangeHotelEntities();
            var temp = from book in db.Bookings
                       where book.DateIn >= start && book.DateIn <= finish
                       select new
                       {
                           book.DateIn
                       };
            double result = 0;
            foreach (var i in temp)
            {
                result++;
            }
            return result;

        }
        /*public int GetIdBoooking(string CCCD)
        {
            MangeHotelEntities db = new MangeHotelEntities();
            var result = from customer in db.Customers
                         join book in db.Bookings on customer.IdCustomer equals book.IdCustomer 
                         join r in db.Rooms on book.IdBooking equals r.IdBooking
                         where customer.CCCD == CCCD
                         select new { book.IdBooking };
            int temp = 0;
            foreach(var item in result)
            {
                temp = item.IdBooking;
            }
            return temp;
        }
        public string GetCCCD(int id)
        {
            MangeHotelEntities db = new MangeHotelEntities();
            var result = from room in db.Rooms
                         join book in db.Bookings on room.IdBooking equals book.IdBooking
                         join cus in db.Customers on book.IdCustomer equals cus.IdCustomer
                         where room.IdRoom == id
                         select new { cus.CCCD };
            string temp = "";
            foreach (var item in result)
            {
                temp = item.CCCD;
            }
            return temp;
        }
        public int GetIdRoom (int id)
        {
            MangeHotelEntities db = new MangeHotelEntities();
            Booking book = db.Bookings.Where(p => p.IdBooking == id).FirstOrDefault();
            return (int)book.IdRoom;
        }*/
    }
}
