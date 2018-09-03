using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PSK48.IShareService.Models
{
    [Table("s_userVerify")]
    public class UserVerify
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }
        public long userId { get; set; }
        [StringLength(20)]
        public string identNo { get; set; }
        public int expireMonth { get; set; }
        public int expireYear { get; set; }
        [StringLength(150)]
        public string country { get; set; }
        public DateTime lastUpdate { get; set; }
        public long updateBy { get; set; }
    }
}
