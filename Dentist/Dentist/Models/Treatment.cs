using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Dentist.Models
{
    public class Treatment
    {
        public int Id { get; set; }
        [Required]
        public string Image { get; set; }
        [Required,StringLength(50)]
        public string TreatmentName { get; set; }
        [Required]
        public string About { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
        public List<Portfolio> Portfolios { get; set; }
        [Required]
        public string Slug { get; set; }


    }
}
