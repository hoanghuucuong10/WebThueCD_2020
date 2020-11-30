using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace THUE_CD.ViewModel
{
    public class ModelDiskReturn
    {
        public int ID { get; set; }
        public string Title_Name { get; set; }
        public DateTime DateRent { get; set; }
        public DateTime DateDue { get; set; }

        public int MyProperty { get; set; }
    }
}