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
    public class TypeRoomBLL
    {
        private static TypeRoomBLL _Instance;
        public static TypeRoomBLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new TypeRoomBLL();
                }
                return _Instance;
            }
        }
        public List<TypeRoom> GetAllTypeRoom()
        {
            return TypeRoomDAL.Instance.GetAllTypeRoom();
        }
        public List<TypeRoom> GetTypeRoomByKeyWord(string key)
        {
            return TypeRoomDAL.Instance.GetTypeRoomByKeyWord(key);
        }
        public TypeRoom GetTypeRoomById(int Id)
        {
            foreach (TypeRoom room in GetAllTypeRoom())
            {
                if (room.IdType == Id)
                    return room;
            }
            return null;
        }
        public void Add(TypeRoom room)
        {
            TypeRoomDAL.Instance.Add(room);
        }
        public void Update(TypeRoom room)
        {
            TypeRoomDAL.Instance.Updated(room);
        }
        public void Delete(int room)
        {
            TypeRoomDAL.Instance.Delete(room);
        }      
        public List<CBBItem> GetTypeCBB()
        {
            List<CBBItem> cBBItems = new List<CBBItem>();
            foreach (TypeRoom room in GetAllTypeRoom())
            {
                cBBItems.Add(new CBBItem
                {
                    ID = room.IdType,
                    Text = room.NameType
                });
            }
            return cBBItems;
        }
    }
}
