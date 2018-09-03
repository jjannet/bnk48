using PSK48.Util.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PSK48.IShareService.Models
{
    [Table("a_roleMapping")]
    public class RoleMapping : BaseObject
    {
        [StringLength(20)]
        public string roleCode { get; set; }


        [StringLength(50)]
        public string username { get; set; }

        [StringLength(10)]
        public string companyCode { get; set; }


        [ForeignKey("companyCode")]
        public virtual Company company { get; set; }

        [ForeignKey("roleCode")]
        public virtual Role role { get; set; }

        [ForeignKey("username")]
        public virtual User user { get; set; }

    }
}
