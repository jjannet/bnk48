using PSK48.Util.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PSK48.IShareService.Models
{
    [Table("s_user")]
    public class User : BaseObject
    {
        [Key, StringLength(50)]
        public string username { get; set; }

        [StringLength(50)]
        public string password { get; set; }

        [StringLength(250)]
        public string displayName { get; set; }

        [StringLength(250)]
        public string email { get; set; }

        [StringLength(50)]
        public string phone { get; set; }

        public bool actived { get; set; }

        public virtual UserProfile profile { get; set; }

        public virtual IEnumerable<UserImage> images { get; set; }

        public virtual IEnumerable<UserAddress> addresses { get; set; }

        public virtual IEnumerable<UserCompanyMapping> companies { get; set; }

        public virtual IEnumerable<RoleMapping> roleMappings { get; set; }
    }
}
