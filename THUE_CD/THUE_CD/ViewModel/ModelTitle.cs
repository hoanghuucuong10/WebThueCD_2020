using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace THUE_CD.ViewModel
{
    public class ModelTitle
    {
        public int Id_Title { get; set; }
        public string TitleName { get; set; }
        public int Id_Type { get; set; }
        public string TypeName { get; set; }
        public int Count { get; set; }
        public int NumOnShelf { get; set; }
        public int CountOnShelf { get; set; }

    }
}