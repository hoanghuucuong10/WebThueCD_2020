using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace THUE_CD.ViewModel
{
    public class ModelLateFee
    {
        public int Id_LateFee { get; set; }
        public int Id_Item { get; set; }
        public string Title_Name { get; set; }
        public string Cus_Name { get; set; }
        public double Fine { get; set; }
    }
}