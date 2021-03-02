using Dentist.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dentist.Areas.Admin.ViewModels
{
    public class PriceVM
    {
        public List<Price> Prices { get; set; }
        public PriceDetail PriceDetail { get; set; }
    }
}
