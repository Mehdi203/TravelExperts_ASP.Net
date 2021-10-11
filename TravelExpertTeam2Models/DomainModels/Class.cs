using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TravelExpertTeam2.Models
{
    public partial class Class
    {
        public Class()
        {
            BookingDetails = new HashSet<BookingDetail>();
        }

        [Key]
        [StringLength(5)]
        public string ClassId { get; set; }
        [Required]
        [StringLength(20)]
        public string ClassName { get; set; }
        [StringLength(50)]
        public string ClassDesc { get; set; }

        [InverseProperty(nameof(BookingDetail.Class))]
        public virtual ICollection<BookingDetail> BookingDetails { get; set; }
    }
}
