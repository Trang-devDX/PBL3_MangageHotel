using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Util;

namespace DAL
{
    public class RoomDAL
    {
        private static RoomDAL _Instance;
        public static RoomDAL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new RoomDAL();
                }
                return _Instance;
            }
        }
        public RoomDTO GetIdRoomPay(int id)
        {
            MangeHotelEntities db = new MangeHotelEntities();
            var result = from room in db.Rooms
                         join type in db.TypeRooms on room.IdType equals type.IdType   
                         select new
                         {
                             room.IdRoom,
                             room.NameRoom,
                             type.NameType,
                             type.GuestsMax,
                             type.HourlyRate,
                             room.IdBooking
                         };
            RoomDTO temp = new RoomDTO();
            foreach(var i in result)
            {
                if(i.IdRoom == id)
                {
                    temp.ID = i.IdRoom;
                    temp.Name = i.NameRoom;
                    temp.Type = i.NameType;
                    temp.People = (int)i.GuestsMax;
                    temp.HourlyRate = (double) i.HourlyRate;
                    temp.IdBooking = (int) i.IdBooking;
                }    
            }    
            return temp;
        }
        public List<RoomDTO> GetAllRoom()
        {
            List<RoomDTO> list = new List<RoomDTO>();
            using (MangeHotelEntities db = new MangeHotelEntities())
            {
                var result = from room in db.Rooms
                             join type in db.TypeRooms on room.IdType equals type.IdType
                             where room.IdBooking >= 0
                             select new
                             {
                                 room.IdRoom,
                                 room.NameRoom,
                                 type.NameType,
                                 type.GuestsMax,
                                 type.HourlyRate,
                                 room.IdBooking
                             };
                foreach (var i in result)
                {
                    list.Add(new RoomDTO
                    {
                        ID = i.IdRoom,
                        Name = i.NameRoom,
                        Type = i.NameType,
                        People = (int)i.GuestsMax,
                        HourlyRate = (double)i.HourlyRate,
                        IdBooking = (int)i.IdBooking,
                    });
                }
            }
            return list;
        }
        public void Add(Room r)
        {
            MangeHotelEntities db = new MangeHotelEntities();
            db.Rooms.Add(r);
            db.SaveChanges();
        }
        public void Update(Room r)
        {
            MangeHotelEntities db = new MangeHotelEntities();
            Room room = db.Rooms.Where(p => p.IdRoom == r.IdRoom).FirstOrDefault();
            room.NameRoom = r.NameRoom;
            room.IdType = r.IdType;
            db.SaveChanges();
        }
        public void Delete(int r)
        {
            MangeHotelEntities db = new MangeHotelEntities();
            Room room = db.Rooms.Where(p => p.IdRoom == r).FirstOrDefault();
            room.IdBooking = -1;
            db.SaveChanges();
        }
        public List<RoomDTO> FindRoom(string find)
        {
            List<RoomDTO> list = new List<RoomDTO>();
            using (MangeHotelEntities db = new MangeHotelEntities())
            {
                int findint = -1;
                if (IsNumeric.Check(find) == true)
                    findint = Convert.ToInt32(find);
                var result = from room in db.Rooms
                             join e in db.TypeRooms on room.IdType equals e.IdType
                             where (room.NameRoom.Equals(find.ToLower())
                             || e.GuestsMax == findint
                             || e.HourlyRate == findint 
                             || room.IdRoom == findint
                             || ((find.ToLower() == "trống") && (room.IdBooking == 0)) 
                             || ((find.ToLower() == "bận") && (room.IdBooking > 0))
                             || e.NameType.Equals(find.ToLower())) && room.IdBooking >= 0
                             select new
                             {
                                 room.IdRoom,
                                 room.NameRoom,
                                 e.NameType,
                                 e.GuestsMax,
                                 e.HourlyRate,
                                 room.IdBooking
                             };
                foreach (var i in result)
                {
                    list.Add(new RoomDTO
                    {
                        ID = i.IdRoom,
                        Name = i.NameRoom,
                        Type = i.NameType,
                        People = (int)i.GuestsMax,
                        HourlyRate = (double)i.HourlyRate,
                        IdBooking = (int)i.IdBooking
                    });
                }
            }
            return list;
        }
        public void ChangStatus(int IdBooking, int IdRoom)
        {
            MangeHotelEntities db = new MangeHotelEntities();
            Room room = db.Rooms.Where(p => p.IdRoom == IdRoom).FirstOrDefault();
            room.IdBooking = IdBooking;
            db.SaveChanges();
        }
        /*public List<RoomDTO> FindDetail(string find)
        {

            int findint = -1;
            if (IsNumeric.Check(find) == true)
                findint = Convert.ToInt32(find);
            MangeHotelEntities db = new MangeHotelEntities();
            var result = from room in db.Rooms
                         join e in db.TypeRooms on room.IdType equals e.IdType
                         where room.NameRoom.Equals(find.ToLower())
                         || e.NameType == find || room.IdRoom == findint
                         select new
                         {
                             room.IdRoom,
                             room.NameRoom,
                             e.NameType,
                         };
            List<RoomDTO> list = new List<RoomDTO>();
            foreach (var i in result)
            {
                list.Add(new RoomDTO
                {
                    ID = i.IdRoom,
                    Name = i.NameRoom,
                    Type = i.NameType,
                });
            }
            return list;
        }*/
        /*public List<RoomDTO> FindPeople(int x, int y)
        {
            List<RoomDTO> list = new List<RoomDTO>();
            using (MangeHotelEntities db = new MangeHotelEntities())
            {
                if (y == -1)
                {
                    var result = from room in db.Rooms
                                 join e in db.TypeRooms on room.IdType equals e.IdType
                                 where room.IdBooking >= 0 && e.GuestsMax >= x
                                 orderby e.GuestsMax ascending
                                 select new
                                 {
                                     room.IdRoom,
                                     room.NameRoom,
                                     e.NameType,
                                     e.GuestsMax,
                                     e.HourlyRate,
                                     room.IdBooking
                                 };
                    string status = "";
                    foreach (var i in result)
                    {
                        if (i.IdBooking == 0)
                            status = "Trống";
                        else
                            status = "Bận";

                        list.Add(new RoomDTO
                        {
                            ID = i.IdRoom,
                            Name = i.NameRoom,
                            Type = i.NameType,
                            People = (int)i.GuestsMax,
                            HourlyRate = (double)i.HourlyRate,
                            Status = status
                        });
                    }
                }
                else
                {
                    if(x == -1)
                    {
                        var result = from room in db.Rooms
                                     join e in db.TypeRooms on room.IdType equals e.IdType
                                     where room.IdBooking >= 0 && e.GuestsMax <= y
                                     orderby e.GuestsMax ascending
                                     select new
                                     {
                                         room.IdRoom,
                                         room.NameRoom,
                                         e.NameType,
                                         e.GuestsMax,
                                         e.HourlyRate,
                                         room.IdBooking
                                     };
                        string status = "";
                        foreach (var i in result)
                        {
                            if (i.IdBooking == 0)
                                status = "Trống";
                            else
                                status = "Bận";

                            list.Add(new RoomDTO
                            {
                                ID = i.IdRoom,
                                Name = i.NameRoom,
                                Type = i.NameType,
                                People = (int)i.GuestsMax,
                                HourlyRate = (double)i.HourlyRate,
                                Status = status
                            });
                        }
                    }
                    else
                    {
                        var result = from room in db.Rooms
                                     join e in db.TypeRooms on room.IdType equals e.IdType
                                     where room.IdBooking >= 0 && e.GuestsMax >= x && e.GuestsMax <= y
                                     orderby e.GuestsMax ascending
                                     select new
                                     {
                                         room.IdRoom,
                                         room.NameRoom,
                                         e.NameType,
                                         e.GuestsMax,
                                         e.HourlyRate,
                                         room.IdBooking
                                     };
                        string status = "";
                        foreach (var i in result)
                        {
                            if (i.IdBooking == 0)
                                status = "Trống";
                            else
                                status = "Bận";

                            list.Add(new RoomDTO
                            {
                                ID = i.IdRoom,
                                Name = i.NameRoom,
                                Type = i.NameType,
                                People = (int)i.GuestsMax,
                                HourlyRate = (double)i.HourlyRate,
                                Status = status
                            });
                        }
                    }    
                }    
            }
            return list;
        }*/
        /*  public List<RoomDTO> FindCost(int x, int y)
        {
            List<RoomDTO> list = new List<RoomDTO>();
            using (MangeHotelEntities db = new MangeHotelEntities())
            {
                if (y == -1)
                {
                    var result = from room in db.Rooms
                                 join e in db.TypeRooms on room.IdType equals e.IdType
                                 where room.IdBooking >= 0 && e.HourlyRate >= x
                                 orderby e.HourlyRate ascending
                                 select new
                                 {
                                     room.IdRoom,
                                     room.NameRoom,
                                     e.NameType,
                                     e.GuestsMax,
                                     e.HourlyRate,
                                     room.IdBooking
                                 };
                    string status = "";
                    foreach (var i in result)
                    {
                        if (i.IdBooking == 0)
                            status = "Trống";
                        else
                            status = "Bận";

                        list.Add(new RoomDTO
                        {
                            ID = i.IdRoom,
                            Name = i.NameRoom,
                            Type = i.NameType,
                            People = (int)i.GuestsMax,
                            HourlyRate = (double)i.HourlyRate,
                            Status = status
                        });
                    }
                }
                else
                {
                    if (x == -1)
                    {
                        var result = from room in db.Rooms
                                     join e in db.TypeRooms on room.IdType equals e.IdType
                                     where room.IdBooking >= 0 && e.HourlyRate <= y
                                     orderby e.HourlyRate ascending
                                     select new
                                     {
                                         room.IdRoom,
                                         room.NameRoom,
                                         e.NameType,
                                         e.GuestsMax,
                                         e.HourlyRate,
                                         room.IdBooking
                                     };
                        string status = "";
                        foreach (var i in result)
                        {
                            if (i.IdBooking == 0)
                                status = "Trống";
                            else
                                status = "Bận";

                            list.Add(new RoomDTO
                            {
                                ID = i.IdRoom,
                                Name = i.NameRoom,
                                Type = i.NameType,
                                People = (int)i.GuestsMax,
                                HourlyRate = (double)i.HourlyRate,
                                Status = status
                            });
                        }
                    }
                    else
                    {
                        var result = from room in db.Rooms
                                     join e in db.TypeRooms on room.IdType equals e.IdType
                                     where room.IdBooking >= 0 && e.HourlyRate >= x && e.HourlyRate <= y
                                     orderby e.HourlyRate ascending
                                     select new
                                     {
                                         room.IdRoom,
                                         room.NameRoom,
                                         e.NameType,
                                         e.GuestsMax,
                                         e.HourlyRate,
                                         room.IdBooking
                                     };
                        string status = "";
                        foreach (var i in result)
                        {
                            if (i.IdBooking == 0)
                                status = "Trống";
                            else
                                status = "Bận";

                            list.Add(new RoomDTO
                            {
                                ID = i.IdRoom,
                                Name = i.NameRoom,
                                Type = i.NameType,
                                People = (int)i.GuestsMax,
                                HourlyRate = (double)i.HourlyRate,
                                Status = status
                            });
                        }
                    }
                }
            }
            return list;
        }*/
        /*public void ChangeStatus(int idroom, int idboooking)
        {
            MangeHotelEntities db = new MangeHotelEntities();
            Room r = db.Rooms.Where(p => p.IdRoom == idroom).FirstOrDefault();  
            r.IdBooking= idboooking;
            db.SaveChanges();
        }*/
        /*public bool CheckNameRoom(string name)
        {
            MangeHotelEntities db = new MangeHotelEntities();
            Room r = db.Rooms.Where(p => p.NameRoom == name).FirstOrDefault();
            if(r != null) { return true; }
            return false;
        }*/
        /*public int GetIdBookng(int id)
        {
            MangeHotelEntities db = new MangeHotelEntities();
            Room r = db.Rooms.Where(p => p.IdRoom == id).FirstOrDefault();
            int idbbooking = (int)r.IdBooking;
            return idbbooking;
        }*/
        /* public List<RoomDTO> GetRoomCCCD(string CCCD)
        {
            List<RoomDTO> list = new List<RoomDTO>();
            using (MangeHotelEntities db = new MangeHotelEntities())
            {
                var result = from e in db.TypeRooms
                             join room in db.Rooms on e.IdType equals room.IdType
                             join book in db.Bookings on room.IdBooking equals book.IdBooking
                             join cus in db.Customers on book.IdCustomer equals cus.IdCustomer
                             where room.IdBooking >= 0 && cus.CCCD.Equals(CCCD)
                             select new
                             {
                                 room.IdRoom,
                                 room.NameRoom,
                                 e.NameType,
                                 e.GuestsMax,
                                 e.HourlyRate,
                                 room.IdBooking
                             };
                string status = "";
                foreach (var i in result)
                {
                    if (i.IdBooking == 0)
                        status = "Trống";
                    else
                        status = "Bận";

                    list.Add(new RoomDTO
                    {
                        ID = i.IdRoom,
                        Name = i.NameRoom,
                        Type = i.NameType,
                        People = (int)i.GuestsMax,
                        HourlyRate = (double)i.HourlyRate,
                        Status = status
                    });
                }
            }
            return list;
        }*/
        public List<RoomDTO> GetRoomByName(string name)
        {
            List<RoomDTO> list = new List<RoomDTO>();
            using (MangeHotelEntities db = new MangeHotelEntities())
            {
                var result = from e in db.TypeRooms
                             join room in db.Rooms on e.IdType equals room.IdType
                             where room.IdBooking >= 0 && room.NameRoom.Equals(name)
                             select new
                             {
                                 room.IdRoom,
                                 room.NameRoom,
                                 e.NameType,
                                 e.GuestsMax,
                                 e.HourlyRate,
                                 room.IdBooking
                             };
                foreach (var i in result)
                {
                    list.Add(new RoomDTO
                    {
                        ID = i.IdRoom,
                        Name = i.NameRoom,
                        Type = i.NameType,
                        People = (int)i.GuestsMax,
                        HourlyRate = (double)i.HourlyRate,
                        IdBooking = (int)i.IdBooking,
                    });
                }
            }
            return list;
        }
    }
}
