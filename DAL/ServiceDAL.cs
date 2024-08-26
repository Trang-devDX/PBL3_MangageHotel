using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;
using DTO;

namespace DAL
{
    public class ServiceDAL
    {
        private static ServiceDAL _Instance;
        public static ServiceDAL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new ServiceDAL();
                }
                return _Instance;
            }
        }
        public List<Service> GetAllService()
        {
            List<Service> list = new List<Service>();
            using (MangeHotelEntities db = new MangeHotelEntities())
            {
                var result = db.Services.Where(p => p.IsUse == true).ToList();
                foreach (var service in result)
                {
                    list.Add(service);
                }
            }
            return list;
        }
        public void Add(Service service)
        {
            MangeHotelEntities db = new MangeHotelEntities();
            db.Services.Add(service);
            db.SaveChanges();
        }
        public void Update(Service service)
        {
            MangeHotelEntities db = new MangeHotelEntities();
            Service type = db.Services.Where(p => p.IdService == service.IdService).FirstOrDefault();
            type.Name = service.Name;
            type.Cost = service.Cost;
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            MangeHotelEntities db = new MangeHotelEntities();
            Service service = db.Services.Where(p => p.IdService == id).FirstOrDefault();
            service.IsUse = false;
            db.SaveChanges();
        }
        public List<Service> Find(string key)
        {
            int keyint = -1;
            if (IsNumeric.Check(key) == true)
                keyint = Convert.ToInt32(key);
            MangeHotelEntities db = new MangeHotelEntities();
            var result = from p in db.Services
                         where p.Name.Contains(key) || p.Cost == keyint || p.IdService == keyint
                         select p;
            List<Service> service = new List<Service>();
            foreach (var i in result)
            {
                service.Add(i);
            }
            return service;
        }
    }
}
