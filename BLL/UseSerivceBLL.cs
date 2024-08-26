using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class UseSerivceBLL
    {
        private static UseSerivceBLL _Instance;
        public static UseSerivceBLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new UseSerivceBLL();
                }
                return _Instance;
            }
        }
        public int Check(int IdBooking, int IdService)
        {
            foreach (var i in UseSerivceDAL.Instance.GetAllUseService())
            {
                if (i.IdBooking == IdBooking && IdService == i.IdService)
                {
                    return i.IdUseService;
                }
            }
            return -1;
        }
        public void Add(int IdService, int IdBooking, int Quantity)
        {
            UseService use = new UseService
            {
                IdService = IdService,
                IdBooking = IdBooking,
                Quantity = Quantity,
            };
            if (Check(IdBooking, IdService) == -1)
            {
                UseSerivceDAL.Instance.Add(use);

            }
            else
            {
                use.IdUseService = Check(IdBooking, IdService);
                UseSerivceDAL.Instance.Up(use);
            }
        }
        public List<ServiceDTO> GetAllUseService(int booking)
        {
            return UseSerivceDAL.Instance.GetAllUseService(booking);
        }
        public double Money(int booking)
        {
            double total = 0;
            foreach (var i in UseSerivceDAL.Instance.GetAllUseService(booking))
            {
                total += i.Cost * i.Quantity;
            }
            return total;
        }
        public List<KeyValuePair<string, double>> TopService(DateTime start, DateTime finish)
        {
            return UseSerivceDAL.Instance.TopService(start, finish);
        }
        public int TotalService(DateTime start, DateTime finish)
        {
            return UseSerivceDAL.Instance.TotalService(start, finish);
        }
    }
}
