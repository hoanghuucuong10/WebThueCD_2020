using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace THUE_CD.Models
{
    public class ReserDetails
    {
        [Key]
        public int Id_ReserDetail { get; set; }
        public int Id_Item { get; set; }
        public int Id_Reservation { get; set; }


        public virtual Item Items { get; set; }
        public virtual Reservation Reservations { get; set; }
    }
}