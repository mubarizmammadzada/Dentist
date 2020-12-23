using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Dentist.Models
{
    public class WellComing
    {
        public int Id { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public string WelcomeTitle { get; set; }
        [Required]
        public string Description { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }

    }
}
