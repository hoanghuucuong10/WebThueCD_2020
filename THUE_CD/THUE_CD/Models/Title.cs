using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace THUE_CD.Models
{
    public class Title
    {
        [Key]
        public int Id_Title { get; set; }
        public string Name { get; set; }
        public int CountOfItem { get; set; }
        public int Id_TypeDisk { get; set; }

        public virtual TypeDisk TypeDisk { get; set; }
        public virtual ICollection<Item> ItemList { get; set; }
        public virtual ICollection<Reservation> ReservationList { get; set; }
        public Title()
        {
            this.ItemList = new List<Item>();
            this.ReservationList = new List<Reservation>();
        }
    }
}