using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace THUE_CD.ViewModel
{
    public class ModelTypeDisk
    {
        public int Id_Type { get; set; }
        public string TypeName { get; set; }
        public double RentPrice { get; set; }
        public int MaxDate { get; set; }
    }
}