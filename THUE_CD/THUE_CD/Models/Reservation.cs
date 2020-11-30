using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace THUE_CD.Models
{
    public class Reservation
    {
        [Key]
        public int Id_Reservation { get; set; }
        public int Id_Title { get; set; }
        public int Id_Customer { get; set; }
        public DateTime DateCreate { get; set; }
        public string Status { get; set; }

        public virtual Title Titles { get; set; }
        public virtual Customer Customers { get; set; }


    }
}