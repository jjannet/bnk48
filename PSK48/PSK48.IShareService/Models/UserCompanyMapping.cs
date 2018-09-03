using PSK48.Util.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PSK48.IShareService.Models
{
    [Table("s_userCompanyMapping")]
    public class UserCompanyMapping : BaseObject
    {
        [StringLength(50)]
        public string username { get; set; }

        [StringLength(10)]
        public int companyCode { get; set; }

        [ForeignKey("username")]
        public virtual User user { get; set; }

        [ForeignKey("companyCode")]
        public virtual Company company { get; set; }
    }
}
