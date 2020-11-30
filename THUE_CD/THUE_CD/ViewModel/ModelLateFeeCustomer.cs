using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace THUE_CD.ViewModel
{
    public class ModelLateFeeCustomer
    {
        public int Id_LateFee { get; set; }
        public int Id_Item { get; set; }
        public string Title_Name { get; set; }
        public string Cus_Name { get; set; }
        public DateTime DateRent { get; set; }
        public DateTime DateReturn { get; set; }
        public DateTime DateDue { get; set; }
        public int DateLate { get; set; }
        public double Fine { get; set; }
        public int Id_Customer { get; set; }

    }
}