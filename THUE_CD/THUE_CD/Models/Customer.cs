using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace THUE_CD.Models
{
    public class Customer
    {
        [Key]
        public int Id_Customer { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public double Fine { get; set; }

        public virtual ICollection<Order> orderList { get; set; }

      
        public virtual ICollection<Reservation> ReservationList { get; set; }
        public Customer()
        {
            this.ReservationList = new List<Reservation>();
            this.orderList = new List<Order>();
        }
    }
}