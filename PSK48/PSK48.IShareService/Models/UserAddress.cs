using PSK48.Util.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PSK48.IShareService.Models
{
    [Table("s_userAddress")]
    public class UserAddress : BaseObject
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }

        [StringLength(50)]
        public string username { get; set; }

        public bool isMain { get; set; }

        [StringLength(250)]
        public string address1 { get; set; }

        [StringLength(250)]
        public string address2 { get; set; }

        [StringLength(150)]
        public string subDistrict { get; set; }

        [StringLength(150)]
        public string district { get; set; }

        [StringLength(150)]
        public string province { get; set; }

        [StringLength(150)]
        public string postcode { get; set; }

        [StringLength(150)]
        public string phone { get; set; }


        [ForeignKey("username")]
        public virtual User user { get; set; }

    }
}
