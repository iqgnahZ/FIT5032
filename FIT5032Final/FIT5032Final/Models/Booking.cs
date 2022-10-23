using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FIT5032Final.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }

        public int PatId { get; set; }
        public Patient Patient { get; set; }

        public int DocId { get; set; }
        public Doctor Doctor { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        [Required]
        public double Price { get; set; }

        [Required]
        public DateTime Time { get; set; }
        
    }
}