using Dentist.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dentist.Areas.Admin.ViewModels
{
    public class DoctorVM
    {
        public List<Doctor> Doctors { get; set; }
        public Certificate Certificate { get; set; }
        public Doctor Doctor { get; set; }

    }
}
