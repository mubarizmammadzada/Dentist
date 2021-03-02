using Dentist.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dentist.Areas.Admin.ViewModels
{
    public class ServiceVM
    {
        public Portfolio Portfolio { get; set; }
        public List<Treatment> Treatments { get; set; }
    }
}
