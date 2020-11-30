using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace THUE_CD.Models
{
    public class TypeDisk
    {
        [Key]
        public int Id_TypeDisk { get; set; }
        public string NameType { get; set; }
        public double RentPrice { get; set; }
        public double LateFee { get; set; }
        public int MaxDate { get; set; }

        public virtual ICollection<Title> TitleList { get; set; }
        public TypeDisk()
        {
            this.TitleList = new List<Title>();
        }
    }
}