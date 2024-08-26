using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class BookingBLL
    {
        private static BookingBLL _Instance;
        public static BookingBLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BookingBLL();
                }
                return _Instance;
            }
        }
        public List<Booking> GetAllBooking()
        {
            return BookingDAL.Instance.GetAllBooking();
        }
        public Booking GetBookingById(int Id)
        {
            foreach(var book in GetAllBooking()) 
            {
                if (book.IdBooking == Id)
                    return book;
            }
            return null;
        }
        public int GetIdCustomer(int Id)
        {
            foreach (var book in GetAllBooking())
            {
                if (book.IdBooking == Id)
                    return (int)book.IdCustomer;
            }
            return -1;
        }
        public int GetIdRoom(int Id)
        {
            foreach (var book in GetAllBooking())
            {
                if (book.IdBooking == Id)
                    return (int)book.IdRoom;
            }
            return -1;
        }
        public void Add(Booking room)
        {
            BookingDAL.Instance.Add(room);
        }
        public void Update(Booking room)
        {
            BookingDAL.Instance.Update(room);
        }
        public double TotalBooking(DateTime start, DateTime finish)
        {
            return BookingDAL.Instance.TotalBooking(start, finish);
        }
            /* public int GetIdBoooking(string CCCD)
             {
                 return  BookingDAL.Instance.GetIdBoooking(CCCD);
             }*/
            /* public string GetCCCD(int id)
             {
                 return BookingDAL.Instance.GetCCCD(id);
             }*/
            /* public int GetIdRoom(int id)
             {
                 return BookingDAL.Instance.GetIdRoom(id);
             }*/

        }
}
