using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
using Microsoft.SqlServer.Server;
using Util;

namespace BLL
{
    public class RoomBLL
    {
        private static RoomBLL _Instance;
        public static RoomBLL Instance
        {
            get
            {
                if(_Instance == null)
                {
                    _Instance = new RoomBLL();
                }    
                return _Instance;
            }
        }
       
        public void Add(Room r)
        {
            RoomDAL.Instance.Add(r);
        }
        public void Update(Room r)
        {
            RoomDAL.Instance.Update(r);
        }
        public void Delete(int r)
        {
            RoomDAL.Instance.Delete(r);
        }
        public List<RoomDTO> GetAllRoom()
        {
            return RoomDAL.Instance.GetAllRoom();
        }
        public List<RoomDTO> GetRoomByStatus(int idbooking)
        {
            List<RoomDTO> list = new List<RoomDTO>();
            foreach (var i in RoomDAL.Instance.GetAllRoom())
            {
                if ((idbooking == 0 && i.IdBooking == 0) || (idbooking == 1 && i.IdBooking > 0))
                {
                    list.Add(i);
                }
            }
            return list;
        }
        public RoomDTO GetIdRoomPay(int id)
        {
            return RoomDAL.Instance.GetIdRoomPay(id);
        }    
        public List<RoomDTO> GetRoomByKeyWord(string find)
        {
            return RoomDAL.Instance.FindRoom(find);
        }
        public List<RoomDTO> GetRoomByTypeAndStatus(string type, string status)
        {
            List<RoomDTO> list = new List<RoomDTO>();
            string temp;
            foreach (var i in RoomDAL.Instance.GetAllRoom())
            {
                temp = i.IdBooking == 0 ? "Trống" : "Bận";
                if ((type == "Tất cả" && temp == status) || (i.Type == type && temp == status) || (status == "Tất cả" && type == i.Type))
                {
                    list.Add(i);
                }
            }
            return list;
        }
        public RoomDTO GetRoomById(int id)
        {
            foreach(RoomDTO r in GetAllRoom())
            {
                if (r.ID == id)
                    return r;
            }
            return null;
        }
        public RoomDTO GetRoomByName(string name)
        {
            foreach (RoomDTO r in GetAllRoom())
            {
                if (r.Name.Trim() == name.Trim())
                    return r;
            }
            return null;
        }
        public List<CBBItem> GetAllNameRoom()
        {
            List<CBBItem> list = new List<CBBItem>();
            foreach (var i in RoomDAL.Instance.GetAllRoom())
            {
                list.Add(new CBBItem
                {
                    ID = i.ID,
                    Text = i.Name
                });
            }
            return list;
        }
        public List<CBBItem> GetAllRoomUse()
        {
            List<CBBItem> list = new List<CBBItem>();
            foreach (var i in RoomDAL.Instance.GetAllRoom())
            {
                if (i.IdBooking > 0)
                {
                    list.Add(new CBBItem
                    {
                        ID = i.ID,
                        Text = i.Name
                    });
                }
            }
            return list;
        }
        public bool CheckNameRoom(string name)
        {
            foreach (var i in RoomDAL.Instance.GetAllRoom())
            {
                if (i.Name.Trim() == name)
                {
                    return true;
                }
            }
            return false;
        }
        public bool CheckRent(int id)
        {
            if (GetRoomById(id).IdBooking > 0)
                return true;
            return false;
        }
        public void ChangStatus(int IdBooking , int IdRoom)
        {
            RoomDAL.Instance.ChangStatus(IdBooking,IdRoom);
        }
        public string GetName(int id)
        {
            foreach (var i in RoomDAL.Instance.GetAllRoom())
            {
                if (i.ID == id)
                {
                    return i.Name.Trim();
                }
            }
            return null;
        }
        /*  
         public List<RoomDTO> FindDetail(string key)
         {
             return RoomDAL.Instance.FindDetail(key);
         }
         public List<RoomDTO> FindPeople(int x , int y)
         {
             return RoomDAL.Instance.FindPeople(x, y);
         }
         public List<RoomDTO> FindCost(int x, int y)
         {
             return RoomDAL.Instance.FindCost(x, y);
         }
         public int GetIdBookng(int id)
         {
             return RoomDAL.Instance.GetIdBookng(id);
         }
         public List<RoomDTO> GetRoomCCCD(string CCCD)
         {
             return RoomDAL.Instance.GetRoomCCCD(CCCD);
         }*/
        /*public List<RoomDTO> GetRoomyTypeAndStatus(int idbooking, string type)
        {
            List<RoomDTO> list = new List<RoomDTO>();
            foreach (var i in RoomDAL.Instance.GetAllRoom())
            {
                if (((idbooking == 0 && i.IdBooking == 0) || (idbooking == 1 && i.IdBooking > 0)) && i.Type == type)
                {
                    list.Add(i);
                }
            }
            return list;
        }*/
        /* public List<RoomDTO> GetRoomByType(string type)
         {
             List<RoomDTO> list = new List<RoomDTO>();
             foreach (var i in RoomDAL.Instance.GetAllRoom())
             {
                 if (i.Type == type)
                 {
                     list.Add(i);
                 }
             }
             return list;
         }*/
    }
}
