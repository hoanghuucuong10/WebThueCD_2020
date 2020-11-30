using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace THUE_CD.Models
{
    public class Order
    {
        [Key]
        public int Id_Order { get; set; }
       
        public int Id_Customer { get; set; }
        public double TotalRent { get; set; }
        public DateTime DateRent { get; set; }


        public virtual ICollection<OrderDetail> orderDetailList { get; set; }
        public Order()
        {
            this.orderDetailList = new List<OrderDetail>();
        }
        public virtual Customer Customers { get; set; }

    }
}