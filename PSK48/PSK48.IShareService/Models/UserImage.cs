using PSK48.Util.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PSK48.IShareService.Models
{
    [Table("s_userImage")]
    public class UserImage : BaseObject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }

        [StringLength(50)]
        public string username { get; set; }

        [StringLength(500)]
        public string smallPath { get; set; }

        [StringLength(500)]
        public string path { get; set; }

        public bool isProfile { get; set; }

        [ForeignKey("username")]
        public virtual User user { get; set; }
    }
}
