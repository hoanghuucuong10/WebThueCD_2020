using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace THUE_CD.Models
{
    public class LateFee
    {
        [Key]
        public int Id_LateFee { get; set; }
        public int Id_OrderDetail { get; set; }
        public double Late_Fee { get; set; }
        public int NumOfLateDate { get; set; }
        public double Total { get; set; }
        public string Status { get; set; }

        public virtual OrderDetail OrderDetails { get; set; }
       

    }
}