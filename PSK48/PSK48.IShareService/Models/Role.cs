using PSK48.Util.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PSK48.IShareService.Models
{
    [Table("a_role")]
    public class Role : BaseObject
    {
        [Key, StringLength(20)]
        public string code { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        public bool isActive { get; set; }
    }
}
