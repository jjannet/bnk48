using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PSK48.Util.Models
{
    public abstract class BaseObject
    {
        // public Int64 Id { get; set; }

        public bool Disable { get; set; }

        /// <summary>
        /// Date and time of creation
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// User who created this entry
        /// </summary>
        [StringLength(20)]
        public string CreatedBy { get; set; }

        /// <summary>
        /// Date and time of last modification
        /// </summary>
        public DateTime LastModifiedDate { get; set; }

        /// <summary>
        /// Userid who made the last modification
        /// </summary>
        [StringLength(20)]
        public string LastModifiedBy { get; set; }
    }
}
