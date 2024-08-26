using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;
using DTO;

namespace DAL
{
    public class TypeRoomDAL
    {
        private static TypeRoomDAL _Instance;
        public static TypeRoomDAL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new TypeRoomDAL();
                }
                return _Instance;
            }
        }
        public List<TypeRoom> GetAllTypeRoom()
        {
            List<TypeRoom> list = new List<TypeRoom>();
            MangeHotelEntities db = new MangeHotelEntities();
            var result = db.TypeRooms.Where(p => p.IsUse == true).ToList();
            foreach (var type in result)
            {
                list.Add(type);
            }
            return list;
        }
        public List<TypeRoom> GetTypeRoomByKeyWord(string key)
        {
            int keyint = -1;
            if (IsNumeric.Check(key) == true)
                keyint = Convert.ToInt32(key);
            MangeHotelEntities db = new MangeHotelEntities();
            var result = from p in db.TypeRooms
                         where p.NameType == key || p.GuestsMax == keyint || p.HourlyRate == keyint || p.IdType == keyint
                         select p;
            List<TypeRoom> typeRooms = new List<TypeRoom>();
            foreach (var i in result)
            {
                typeRooms.Add(i);
            }
            return typeRooms;
        }
        public void Add(TypeRoom room)
        {
            MangeHotelEntities db = new MangeHotelEntities();
            db.TypeRooms.Add(room);
            db.SaveChanges();
        }
        public void Updated(TypeRoom room)
        {
            MangeHotelEntities db = new MangeHotelEntities();
            TypeRoom type = db.TypeRooms.Where(p => p.IdType == room.IdType).FirstOrDefault();
            type.NameType = room.NameType;
            type.GuestsMax = room.GuestsMax;
            type.HourlyRate = room.HourlyRate;
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            MangeHotelEntities db = new MangeHotelEntities();
            TypeRoom type = db.TypeRooms.Where(p => p.IdType == id).FirstOrDefault();
            type.IsUse = false;
            db.SaveChanges();
        }
    }
}
