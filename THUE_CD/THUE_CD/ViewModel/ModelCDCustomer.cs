using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace THUE_CD.ViewModel
{
    public class ModelCDCustomer
    {
        public int Id_Item { get; set; }
        public int Id_Title { get; set; }
        public string TitleName { get; set; }
        public DateTime DateRent { get; set; }
        public DateTime DateDue { get; set; }
        public string Status { get; set; }

    }
}