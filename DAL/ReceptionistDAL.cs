using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Util;

namespace DAL
{
    public class ReceptionistDAL
    {
        private static ReceptionistDAL _Instance;
        public static ReceptionistDAL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new ReceptionistDAL();
                }
                return _Instance;
            }
        }
        public List<ReceptionistDTO> GetAllReceptionist()
        {
            List<ReceptionistDTO> list = new List<ReceptionistDTO>();
            using (MangeHotelEntities db = new MangeHotelEntities())
            {
                var result = from per in db.People
                             join rep in db.Receptionists on per.CCCD equals rep.CCCD
                             where rep.IsWork == true
                             select new { rep.IdReceptionist, per.CCCD, per.Name, per.Phone, per.Address, per.Gender, per.Birth, rep.Salary };
                foreach (var Receptionist in result)
                {
                    list.Add(new ReceptionistDTO
                    {
                        IdReceptionist = Receptionist.IdReceptionist,
                        CCCD = Receptionist.CCCD,
                        Name = Receptionist.Name,
                        Phone = Receptionist.Phone,
                        Address = Receptionist.Address,
                        Gender = (bool)Receptionist.Gender,
                        Birth = (DateTime)Receptionist.Birth,
                        Salary = (double)Receptionist.Salary,
                    });
                }
            }
            return list;
        } 
        public List<ReceptionistDTO> GetReceptionistsByKeyWord(string find)
        {
            MangeHotelEntities db = new MangeHotelEntities();
            int findint = -1;
            if (IsNumeric.Check(find) == true)
                findint = Convert.ToInt32(find);
            var result = from per in db.People
                         join rep in db.Receptionists on per.CCCD equals rep.CCCD
                         where (per.CCCD.Equals(find) || per.Phone.Equals(find) ||
                                per.Name.Contains(find) || per.Address.Contains(find)
                                || rep.Salary == findint || rep.IdReceptionist == findint) && rep.IsWork == true
                         select new { rep.IdReceptionist, per.CCCD, per.Name, per.Phone, per.Address, per.Gender, per.Birth, rep.Salary };
            List<ReceptionistDTO> list = new List<ReceptionistDTO>();
            foreach (var Receptionist in result)
            {
                list.Add(new ReceptionistDTO
                {
                    IdReceptionist = Receptionist.IdReceptionist,
                    CCCD = Receptionist.CCCD,
                    Name = Receptionist.Name,
                    Phone = Receptionist.Phone,
                    Address = Receptionist.Address,
                    Gender = (bool)Receptionist.Gender,
                    Birth = (DateTime)Receptionist.Birth,
                    Salary = (double)Receptionist.Salary,
                });
            }
            return list;
        }
        public void Add(ReceptionistDTO rec)
        {
            MangeHotelEntities db = new MangeHotelEntities();
            Person per = db.People.Where(t => t.CCCD == rec.CCCD).FirstOrDefault();
            if (per == null)
            {
                Person p = new Person
                {
                    CCCD = rec.CCCD,
                    Name = rec.Name,
                    Phone = rec.Phone,
                    Address = rec.Address,
                    Gender = rec.Gender,
                    Birth = rec.Birth
                };
                db.People.Add(p);
            }
            else
            {
                per.Name = rec.Name;
                per.Phone = rec.Phone;
                per.Address = rec.Address;
                per.Gender = rec.Gender;
                per.Birth = rec.Birth;
            }
            Receptionist r = new Receptionist
            {
                CCCD = rec.CCCD,
                Salary = rec.Salary,    
                IsWork = rec.IsWork
            };
            db.Receptionists.Add(r);
            db.SaveChanges();
        }
        public void Update(ReceptionistDTO rec)
        {
            MangeHotelEntities db = new MangeHotelEntities();
            Receptionist rep = db.Receptionists.Where(t => t.IdReceptionist == rec.IdReceptionist).FirstOrDefault();
            Person old = db.People.Where(t => t.CCCD == rep.CCCD).FirstOrDefault();
            if (rep.CCCD == rec.CCCD)
            {
                old.Name = rec.Name;
                old.Address = rec.Address;
                old.Phone = rec.Phone;
                old.Birth = rec.Birth;
                old.Gender = rec.Gender;
            }
            else
            {
                Person per = new Person
                {
                    CCCD = rec.CCCD,
                    Name = rec.Name,
                    Address = rec.Address,
                    Phone = rec.Phone,
                    Birth = rec.Birth,
                    Gender = rec.Gender
                };
                db.People.Add(per);
                rep.CCCD = rec.CCCD;
                db.People.Remove(old);
            }
            rep.Salary = rec.Salary;
            db.SaveChanges();
        }
        public void Delete (int id)
        {
            MangeHotelEntities db = new MangeHotelEntities();
            Receptionist rep = db.Receptionists.Where(t => t.IdReceptionist == id).FirstOrDefault();
            rep.IsWork = false;
            db.SaveChanges();
        }
    }
}
