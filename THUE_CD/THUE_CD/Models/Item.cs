using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace THUE_CD.Models
{
    public class Item
    {
        [Key]
        public int Id_Item { get; set; }
        public int Id_Title { get; set; }
        public string Status { get; set; }

        public virtual Title Titles { get; set; }

        public virtual ICollection<OrderDetail> orderDetailList { get; set; }
        public virtual ICollection<ReserDetails> reserDetailList { get; set; }
        public Item()
        {
            this.orderDetailList = new List<OrderDetail>();
            this.reserDetailList = new List<ReserDetails>();
        }
    }
}