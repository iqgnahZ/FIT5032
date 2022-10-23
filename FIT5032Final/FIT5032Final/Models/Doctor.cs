using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FIT5032Final.Models
{
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }

        [Required]
        [MaxLength(30)]
        public String FirstName { get; set; }

        [Required]
        [MaxLength(30)]
        public string LastName { get; set; }

        [NotMapped]
        [Display(Name = "Rating")]
        public decimal AvgRating { get; set; }

        public List<Rating> Ratings { get; set; }
    }
}