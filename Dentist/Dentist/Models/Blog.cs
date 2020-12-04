using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dentist.Models
{
    public class Blog
    {
        public int Id { get; set; }
        [Required]
        public string BlogName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public DateTime  Date { get; set; }
        [Required]
        public string Slug { get; set; }

    }
}
