using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace THUE_CD.Models
{
    public class Accounts
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Account { get; set; }
        public string AccountName { get; set; }
        public string PassWord { get; set; }
        public string Role { get; set; }

    }
}