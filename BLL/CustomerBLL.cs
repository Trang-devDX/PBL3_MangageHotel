using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
using Util;

namespace BLL
{
    public class CustomerBLL
    {
        private static CustomerBLL _Instance;
        public static CustomerBLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new CustomerBLL();
                }
                return _Instance;
            }
        }
        public List<CustomerDTO> GetAllCustomer()
        {
            return CustomerDAL.Instance.GetAllCustomer();
        }
        public List<CustomerDTO> GetCustomerByKeyWord(string find)
        {
            return CustomerDAL.Instance.GetCustomerByKeyWord(find);

        }
        public CustomerDTO GetCustomerById(int id)
        {
            foreach (CustomerDTO cus in GetAllCustomer())
            {
                if (cus.IdCustomer == id)
                    return cus;
            }
            return null;
        }
        public CustomerDTO GetCustomerByCCCD(string CCCD)
        {
            foreach (CustomerDTO cus in GetAllCustomer())
            {
                if (cus.CCCD == CCCD)
                    return cus;
            }
            return null;
        }
        public string GetCCCD(int id)
        {
            foreach (CustomerDTO cus in GetAllCustomer())
            {
                if (cus.IdCustomer == id)
                    return cus.CCCD;
            }
            return null;
        }
        public void Add(CustomerDTO cus)
        {
            CustomerDAL.Instance.Add(cus);
        }
        public void Update(CustomerDTO cus)
        {
            CustomerDAL.Instance.Update(cus);
        }
        public void Delete(int id)
        {
            CustomerDAL.Instance.Delete(id);
        }
       /* public bool CheckCustomer(string CCCD)
        {
            if (CustomerDAL.Instance.GetCustomer(CCCD) != null)
            {
                return true;
            }
            return false;
        }
        public string GetCCCD(int id)
        {
            return CustomerDAL.Instance.GetCCCD(id);
        }
        public bool CheckCCCD (string CCCD)
        {
            if(CustomerDAL.Instance.CheckCCCD(CCCD) != null)
            {
                return true;
            }
            return false;
        }
        public int GetId (string CCCD)
        {
            foreach (var i in GetAllCustomer())
            {
                if (i.CCCD == CCCD)
                {
                    return i.IdCustomer;
                }
            }
            return -1;
        }*/
    }
}

