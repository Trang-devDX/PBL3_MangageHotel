using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
using Util;

namespace BLL
{
    public class AccountBLL
    {
        private static AccountBLL _Instance;
        public static AccountBLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new AccountBLL();
                }
                return _Instance;
            }
        }
        public List<Account> GetAllAccount()
        {
            return AccountDAL.Instance.GetAllAccount();
        }
        public List<Account> GetAccountsByRole(string Role)
        {
            List<Account> list = new List<Account>();
            foreach (var i in AccountDAL.Instance.GetAllAccount())
            {
                if (i.Role == Role)
                {
                    list.Add(i);
                }
            }
            return list;
        }
        public List<Account> GetAccountsByStatus(string Status)
        {
            List<Account> list = new List<Account>();
            foreach (var i in GetAllAccount())
            {
                if (i.Status == Status)
                {
                    list.Add(i);
                }
            }
            return list;
        }
        public Account GetAccountById(int id)
        {
            foreach (var i in GetAllAccount())
            {
                if (i.IdSatff == id)
                {
                    return i;
                }
            }
            return null;
        }
        public void Update(Account ac)
        {
            AccountDAL.Instance.Update(ac);
        }
        public void Delete(int id)
        {
            AccountDAL.Instance.Delete(id);
        }
        public string GetRoleById(int idStaff)
        {
            foreach(Account i in GetAllAccount())
            {
                if (i.IdSatff == idStaff)
                    return i.Role;
            }    
            return null;
        }
        public void CreateAccount(int idStaff)
        {
            AccountDAL.Instance.CreateAccount(idStaff);
        }
        public bool CheckPass(int idStaff,string password)
        {
            if (GetAccountById(idStaff).Password.Trim() == password)
            {
                return true;
            }
            return false;
        }
        /*public Boolean CheckStatus(int username)
        {
            if (AccountDAL.Instance.GetAccount(username).Status == true)
            {
                return true;
            }
            return false;
        }*/
        /*public Account Create()
        {
            return AccountDAL.Instance.Create();
        }*/
        /*  public bool CheckPass(int id, string pass)
          {
              if (AccountDAL.Instance.GetAccount(id).Password == HashPassword.GetHash(pass))
              {
                  return true;
              }
              return false;
          }*/
        /*public void ChangePass(int id, string pass)
        {
            AccountDAL.Instance.ChangePass(id, pass);
        }*/
    }
}
