using PSK48.Util.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PSK48.IShareService.Models
{
    [Table("s_company")]
    public class Company : BaseObject
    {
        [Key, StringLength(10)]
        public string code { get; set; }

        [StringLength(150)]
        public string name { get; set; }

        [StringLength(500)]
        public string note { get; set; }

        public bool isActive { get; set; }

        [StringLength(500)]
        public string connectionString { get; set; }
    }
}
