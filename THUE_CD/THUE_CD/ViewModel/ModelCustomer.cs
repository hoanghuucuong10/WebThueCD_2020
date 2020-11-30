using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using THUE_CD.Models;

namespace THUE_CD.ViewModel
{
    public class ModelCustomer
    {
        public int Id_Customer { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int NumDiskRenting { get; set; } 
        public int NumDiskLate { get; set; }// số đĩa quá hạn hiện tại
        public double Fine { get; set; }  // Tổng số tiền phạt hiện tại (chỉ tính đĩa đã trả)

        public int CountCDBorrow { get; set; } // số đĩa đang thuê
        public double TotalRent { get; set; }
      

    }
}