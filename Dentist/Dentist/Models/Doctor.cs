using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Dentist.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        [Required]
        public string Image { get; set; }
        public string Position { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Profession { get; set; }
        [Required]
        public string About { get; set; }
        public string Twitter { get; set; }
        [Required]
        public string Facebook { get; set; }
        [Required]
        public string Gmail { get; set; }
        [Required]
        public string Instagram { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}
