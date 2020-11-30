using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using THUE_CD.Models;
namespace THUE_CD.ViewModel
{
    public class ModelItem
    {

        public int Id_Item { get; set; }
        public int Id_Title { get; set; }
        public int Id_TypeDisk { get; set; }
        public string Status { get; set; }
        public string TitleName { get; set; }
        public string TypeName { get; set; }

        public int MaxDate { get; set; }

        public double RentFee { get; set; }

        public double LateFee { get; set; }


    }
}