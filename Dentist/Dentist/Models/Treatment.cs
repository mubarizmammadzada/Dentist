using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required,StringLength(200)]
        public string About { get; set; }

    }
}
