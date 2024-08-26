using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class InvoiceBLL
    {
        private static InvoiceBLL _Instance;
        public static InvoiceBLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new InvoiceBLL();
                }
                return _Instance;
            }
        }
        public void Add(Invoice inv)
        {
            InvoiceDAL.Instance.Add(inv);
        }
        public List<KeyValuePair<string, double>> Statistical_Amount(DateTime start, DateTime finish)
        {
            return InvoiceDAL.Instance.Statistical_Amount(start, finish);
        }
        public double TotalMoney(DateTime start, DateTime finish)
        {
            return InvoiceDAL.Instance.TotalMoney(start, finish);
        }
    }
}
