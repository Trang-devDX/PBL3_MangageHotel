using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class ReceptionistBLL
    {
        private static ReceptionistBLL _Instance;
        public static ReceptionistBLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new ReceptionistBLL();
                }
                return _Instance;
            }
        }
        public List<ReceptionistDTO> GetAllReceptionist()
        {
            return ReceptionistDAL.Instance.GetAllReceptionist();
        }
        public List<ReceptionistDTO> GetReceptionistByKeyWord(string find)
        {
            return ReceptionistDAL.Instance.GetReceptionistsByKeyWord(find);

        }
        public ReceptionistDTO GetReceptionistById(int id)
        {
            foreach (var i in GetAllReceptionist())
            {
                if (i.IdReceptionist == id)
                {
                    return i;
                }
            }
            return null;
        }



        public void Add(ReceptionistDTO rec)
        {
            ReceptionistDAL.Instance.Add(rec);
        }
        public void Update(ReceptionistDTO rec)
        {
            ReceptionistDAL.Instance.Update(rec);
        }
        public void Delete(int id)
        {
            ReceptionistDAL.Instance.Delete(id);
        }


       /* public bool CheckReceptionist(string CCCD)
        {
            if (ReceptionistDAL.Instance.GetReceptionist(CCCD) != null)
            {
                return true;
            }
            return false;
        }
        public string GetCCCD(int id)
        {
            return ReceptionistDAL.Instance.GetCCCD(id);
        }
        public bool CheckCCCD(string CCCD)
        {
            if (ReceptionistDAL.Instance.CheckCCCD(CCCD) != null)
            {
                return true;
            }
            return false;
        }*/
       
        
    }
}
