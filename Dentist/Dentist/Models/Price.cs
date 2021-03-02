using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dentist.Models
{
    public class Price
    {
        public int Id { get; set; }
        [Required,StringLength(200)]
        public string PriceTitle { get; set; }
        public List<PriceDetail> PriceDetails { get; set; }

    }
}
