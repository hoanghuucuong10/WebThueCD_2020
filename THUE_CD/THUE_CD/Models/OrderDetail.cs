using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace THUE_CD.Models
{
    public class OrderDetail
    {
        [Key]
        public int Id_OrderDetail { get; set; }
        public int Id_Order { get; set; }
        public int Id_Item { get; set; }
        public DateTime DateReturn { get; set; }
        public DateTime DateDue { get; set; }
        public double RentFee { get; set; }
        public string Status { get; set; }

        public virtual Order Orders { get; set; }
        public virtual Item Items { get; set; }
        public virtual ICollection<LateFee> lateFeeList { get; set; }

    }
}