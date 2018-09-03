using PSK48.Util.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PSK48.IShareService.Models
{
    [Table("m_member")]
    public class Member : BaseObject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [StringLength(150)]
        public string firstName { get; set; }

        [StringLength(150)]
        public string lastName { get; set; }

        [StringLength(150)]
        public string nickName { get; set; }

        [StringLength(150)]
        public string firstNameTH { get; set; }

        [StringLength(150)]
        public string lastNameTH { get; set; }

        [StringLength(150)]
        public string nickNameTH { get; set; }

        public int generation { get; set; }

        public DateTime debut { get; set; }

        public bool isGrade { get; set; }

        public DateTime gradeDate { get; set; }
    }
}
