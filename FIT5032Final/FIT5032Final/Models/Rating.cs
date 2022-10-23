using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FIT5032Final.Models
{
    public class Rating
    {
        public int Id { get; set; }

        [Required]
        public string PatientId { get; set; }
        public ApplicationUser User { get; set; }
        
        [Required]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        [Required]
        [Range(0, 5)]
        public int Rate { get; set; } = 0;
        public string Comment { get; set; }
    }
}
