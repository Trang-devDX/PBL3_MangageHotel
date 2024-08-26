using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;
using DTO;

namespace DAL
{
    public class AccountDAL
    {
        private static AccountDAL _Instance;
        public static AccountDAL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new AccountDAL();
                }
                return _Instance;
            }
        }
        public List<Account> GetAllAccount()
        {
            List<Account> listaccount = new List<Account>();
            using (MangeHotelEntities db = new MangeHotelEntities())
            {
                var result = db.Accounts.Where(p => p.Status.Trim() != "Xóa");
                foreach(Account acc in result)
                {
                    listaccount.Add(acc);
                }    
            }
            return listaccount;
        }
        /*public Account Create()
        {
            Account account = new Account
            {
                Password = HashPassword.GetHash("123456"),
                Status = true,
                Role = "Lễ tân"
            };
            MangeHotelEntities db = new MangeHotelEntities();
            db.Accounts.Add(account);
            db.SaveChanges();
            return account;
        }*/
        public void Update(Account ac)
        {
            MangeHotelEntities db = new MangeHotelEntities();
            Account result = db.Accounts.Where(p => p.IdSatff == ac.IdSatff).FirstOrDefault();
            result.Password = ac.Password;
            result.Status = ac.Status;
            result.Role = ac.Role;
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            MangeHotelEntities db = new MangeHotelEntities();
            Account result = db.Accounts.Where(p => p.IdSatff == id).FirstOrDefault();
            result.Status = "Xóa";
            db.SaveChanges();
        }
        public void CreateAccount(int idStaff)
        {
            MangeHotelEntities db = new MangeHotelEntities();
            Account acc = new Account
            {
                IdSatff = idStaff,
                Role = "Lễ tân",
                Password = HashPassword.GetHash("123456"),
                Status = "Mở"
            };
            db.Accounts.Add(acc);
            db.SaveChanges();
        }
    }
}
