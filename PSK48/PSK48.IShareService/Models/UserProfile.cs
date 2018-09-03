using PSK48.Util.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PSK48.IShareService.Models
{
    [Table("s_userProfile")]
    public class UserProfile : BaseObject
    {
        [Key, StringLength(50)]
        public string username { get; set; }

        [StringLength(250)]
        public string firstName { get; set; }

        [StringLength(250)]
        public string lastName { get; set; }

        [StringLength(50)]
        public string nickName { get; set; }

        [StringLength(20)]
        public string identNo { get; set; }

        public DateTime birthDay { get; set; }

        [StringLength(250)]
        public string gender { get; set; }

        [StringLength(250)]
        public string career { get; set; }

        [ForeignKey("username")]
        public virtual User user { get; set; }
    }
}
