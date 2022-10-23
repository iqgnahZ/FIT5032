using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FIT5032Final.Models
{
    public class Administrator
    {
        [Key]
        public int AdministratorId { get; set; }

        [Required]
        public string AdministratorName { get; set; }
    }
}