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
    public  class ServiceBLL
    {
        private static ServiceBLL _Instance;
        public static ServiceBLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new ServiceBLL();
                }
                return _Instance;
            }
        }
        public List<Service> GetAllService()
        {
            return ServiceDAL.Instance.GetAllService();
        }
        public List<Service> GetServiceByKeyWord(string key)
        {
            return ServiceDAL.Instance.Find(key);
        }
        public Service GetServiceById(int Id)
        {
            foreach (Service service in GetAllService())
            {
                if (service.IdService == Id)
                    return service;
            }
            return null;
        }
        public void Add(Service ser)
        {
            ServiceDAL.Instance.Add(ser);
        }
        public void Update(Service ser)
        {
            ServiceDAL.Instance.Update(ser);
        }
        public void Delete(int ser)
        {
            ServiceDAL.Instance.Delete(ser);
        }
    }
}
