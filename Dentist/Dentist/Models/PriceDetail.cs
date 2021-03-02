using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dentist.Models
{
    public class PriceDetail
    {
        public int Id { get; set; }
        [Required,StringLength(400)]
        public string PriceDetaillName { get; set; }
        [Required]
        public int PriceDetailCost { get; set; }
        [Required]
        public bool İsExactly { get; set; }
        public Price Price { get; set; }
        public int PriceId { get; set; }


    }
}
