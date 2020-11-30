using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using System.Web;

namespace THUE_CD.Models
{
    public class ThueDiaDB:DbContext
    {
        public ThueDiaDB():base("name=ThueDiaDB")
        {
        
        }
        public System.Data.Entity.DbSet<THUE_CD.Models.Title> Titles { get; set; }
        public System.Data.Entity.DbSet<THUE_CD.Models.TypeDisk> Types { get; set; }
        public System.Data.Entity.DbSet<THUE_CD.Models.Item> Items { get; set; }
        public System.Data.Entity.DbSet<THUE_CD.Models.Order> Orders { get; set; }
        public System.Data.Entity.DbSet<THUE_CD.Models.OrderDetail> OrderDetails { get; set; }
        public System.Data.Entity.DbSet<THUE_CD.Models.Customer> Customers { get; set; }
        public System.Data.Entity.DbSet<THUE_CD.Models.Reservation> Reservations { get; set; }
        public System.Data.Entity.DbSet<THUE_CD.Models.Accounts> Accounts { get; set; }
        public System.Data.Entity.DbSet<THUE_CD.Models.ReserDetails> ReserDetails { get; set; }
        public System.Data.Entity.DbSet<THUE_CD.Models.LateFee> LateFees { get; set; }
    }
}