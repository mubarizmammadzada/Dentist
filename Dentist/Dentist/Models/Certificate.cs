using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Dentist.Models
{
    public class Certificate
    {
        public int Id { get; set; }
        [Required]
        public string Image { get; set; }
        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}
