using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DTO;
using Util;

namespace DAL
{
    public class CustomerDAL
    {
        private static CustomerDAL _Instance;
        public static CustomerDAL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new CustomerDAL();
                }
                return _Instance;
            }
        }
        public List<CustomerDTO> GetAllCustomer()
        {
            List<CustomerDTO> list = new List<CustomerDTO>();
            using (MangeHotelEntities db = new MangeHotelEntities())
            {
                var result = from per in db.People
                             join cus in db.Customers on per.CCCD equals cus.CCCD
                             //where cus.IsUse == true
                             select new { cus.IdCustomer , per.CCCD , per.Name , per.Phone , per.Address ,per.Gender,per.Birth };
                foreach (var person in result)
                {
                    list.Add(new CustomerDTO
                    {
                        IdCustomer = person.IdCustomer,
                        CCCD = person.CCCD,
                        Name = person.Name,
                        Phone = person.Phone,
                        Address = person.Address,
                        Gender = (bool)person.Gender,
                        Birth = (DateTime)person.Birth
                    });
                }
            }
            return list;
        }
        public List<CustomerDTO> GetCustomerByKeyWord(string find)
        {
            MangeHotelEntities db = new MangeHotelEntities();
            int findint = -1;
            if (IsNumeric.Check(find) == true)
                findint = Convert.ToInt32(find);
            var result = from per in db.People
                         join cus in db.Customers on per.CCCD equals cus.CCCD
                         where (per.CCCD.Equals(find) || per.Phone.Equals(find) ||
                                per.Name.Contains(find) || per.Address.Contains(find)
                                || cus.IdCustomer == findint) && cus.IsUse == true
                         select new { cus.IdCustomer, per.CCCD, per.Name, per.Phone, per.Address, per.Gender, per.Birth };
            List<CustomerDTO> list = new List<CustomerDTO>();
            foreach (var person in result)
            {
                list.Add(new CustomerDTO
                {
                    IdCustomer = person.IdCustomer,
                    CCCD = person.CCCD,
                    Name = person.Name,
                    Phone = person.Phone,
                    Address = person.Address,
                    Gender = (bool)person.Gender,
                    Birth = (DateTime)person.Birth
                });
            }
            return list;
        }
        public void Add(CustomerDTO cus)
        {
            MangeHotelEntities db = new MangeHotelEntities();
            Person per = db.People.Where(t => t.CCCD == cus.CCCD).FirstOrDefault();
            if (per == null)
            {
                Person p = new Person
                {
                    CCCD = cus.CCCD,
                    Name = cus.Name,
                    Phone = cus.Phone,
                    Address = cus.Address,
                    Gender = cus.Gender,
                    Birth = cus.Birth
                };
                db.People.Add(p);
            }
            else
            {
                per.Name = cus.Name;
                per.Phone = cus.Phone;
                per.Address = cus.Address;
                per.Gender = cus.Gender;
                per.Birth = cus.Birth;
            }    
            Customer c = new Customer
            {
                CCCD = cus.CCCD,
                IsUse = true
            };
            db.Customers.Add(c);
            db.SaveChanges();
        }
        public void Update(CustomerDTO cusDTO)
        {
            MangeHotelEntities db= new MangeHotelEntities();
            Customer cus = db.Customers.Where(t => t.IdCustomer == cusDTO.IdCustomer).FirstOrDefault();
            Person old = db.People.Where(t => t.CCCD == cus.CCCD).FirstOrDefault();
            if (cus.CCCD == cusDTO.CCCD)
            {
                old.Name = cusDTO.Name;
                old.Address = cusDTO.Address;   
                old.Phone = cusDTO.Phone;
                old.Birth = cusDTO.Birth;
                old.Gender = cusDTO.Gender;
                db.SaveChanges();
            }   
            else
            {
                Person per = new Person
                {
                    CCCD = cusDTO.CCCD,
                    Name = cusDTO.Name,
                    Address = cusDTO.Address,
                    Phone = cusDTO.Phone,
                    Birth = cusDTO.Birth,
                    Gender = cusDTO.Gender
                };
                db.People.Add(per);
                cus.CCCD = cusDTO.CCCD;
                db.People.Remove(old);
                db.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            MangeHotelEntities db = new MangeHotelEntities();
            Customer cus = db.Customers.Where(t => t.IdCustomer == id).FirstOrDefault();
            cus.IsUse = false; 
            db.SaveChanges();
        }
        /*public Customer GetCustomer(string CCCD)
        {
            MangeHotelEntities db = new MangeHotelEntities();
            return db.Customers.Where(p => p.CCCD == CCCD).FirstOrDefault();
        }
        public Customer CheckCCCD(string CCCD)
        {
            MangeHotelEntities db = new MangeHotelEntities();
            return db.Customers.Where(t => t.CCCD == CCCD).FirstOrDefault();
        }
        public string GetCCCD(int id)
        {
            MangeHotelEntities db = new MangeHotelEntities();
            return db.Customers.Where(t => t.IdCustomer == id).FirstOrDefault().CCCD;        
        }
        public void UpdatePerson(Person person)
        {
            MangeHotelEntities db = new MangeHotelEntities();
            Person temp = db.People.Where(t => t.CCCD == person.CCCD).FirstOrDefault();
            temp.Name= person.Name;
            temp.Address= person.Address;
            temp.Gender= person.Gender;
            temp.Birth= person.Birth;
            temp.Phone= person.Phone;
            db.SaveChanges();
        }
        */
    }
}

