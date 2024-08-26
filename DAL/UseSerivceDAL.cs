using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class UseSerivceDAL
    {
        private static UseSerivceDAL _Instance;
        public static UseSerivceDAL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new UseSerivceDAL();
                }
                return _Instance;
            }
        }
        public List<UseService> GetAllUseService()
        {
            List<UseService> list = new List<UseService>();
            MangeHotelEntities db = new MangeHotelEntities();
            var i = db.UseServices.ToList();
            foreach ( var ser in i )
            {
                list.Add(ser);
            }
            return list;
        }
        public void Add(UseService ser)
        {
            MangeHotelEntities db = new MangeHotelEntities();
            db.UseServices.Add(ser);
            db.SaveChanges();
        }
        public void Up(UseService ser) 
        {
            MangeHotelEntities db = new MangeHotelEntities();
            var result = db.UseServices.Where(p => p.IdUseService == ser.IdUseService).FirstOrDefault();
            result.Quantity += ser.Quantity;
            db.SaveChanges();
        }
        public List<ServiceDTO> GetAllUseService(int booking)
        {
            List<ServiceDTO> list = new List<ServiceDTO>();
            MangeHotelEntities db = new MangeHotelEntities();
            var result = from use in db.UseServices
                         join ser in db.Services on use.IdService equals ser.IdService
                         where use.IdBooking == booking
                         select new
                         {
                             ser.Name,
                             ser.Cost,
                             use.Quantity
                         };
            foreach(var i in result)
            {
                list.Add(new ServiceDTO
                {
                    Name = i.Name,
                    Cost = (double)i.Cost,
                    Quantity = (int)i.Quantity
                });
            }
            return list;
        }
        public List<KeyValuePair<string, double>> TopService(DateTime start, DateTime finish)
        {
            MangeHotelEntities db = new MangeHotelEntities();
            List<KeyValuePair<string, double>> result = new List<KeyValuePair<string, double>>();
            var temp = (from booking in db.Bookings
                       join useService in db.UseServices on booking.IdBooking equals useService.IdBooking
                       join service in db.Services on useService.IdService equals service.IdService
                       where booking.DateIn >= start && booking.DateIn <= finish
                       group useService.Quantity by service.Name into g
                       orderby g.Sum() descending
                       select new
                       {
                           Date = g.Key,
                           Amount = g.Sum()
                       }).Take(3).ToList();
            foreach (var i in temp)
            {
                result.Add(new KeyValuePair<string, double>(i.Date,(double)i.Amount));
            }    
            return result;
        }
        public int TotalService(DateTime start, DateTime finish)
        {
            MangeHotelEntities db = new MangeHotelEntities();
            var temp = (from booking in db.Bookings
                        join useService in db.UseServices on booking.IdBooking equals useService.IdBooking
                        join service in db.Services on useService.IdService equals service.IdService
                        where booking.DateIn >= start && booking.DateIn <= finish
                        select new
                        {
                            useService.Quantity
                        }).ToList();
            int result = 0;
            foreach (var i in temp)
            {
                result += (int)i.Quantity;
            }
            return result;
        }
    }
}
