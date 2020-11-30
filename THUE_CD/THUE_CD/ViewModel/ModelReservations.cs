using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using THUE_CD.Models;

namespace THUE_CD.ViewModel
{
    public class ModelReservations
    {
        public int Id { get; set; }
        public int Id_Title { get; set; }
        public int Id_Customer { get; set; }
        public DateTime DateCreate { get; set; }
        public string Status { get; set; }

        public virtual Title Titles { get; set; }
        public virtual Customer Customers { get; set; }
    }
}