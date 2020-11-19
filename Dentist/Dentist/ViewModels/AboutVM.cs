using Dentist.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dentist.ViewModels
{
    public class AboutVM
    {
        public List<Patient> Patients { get; set; }
        public WellComing WellComing { get; set; }
        public Doctor Doctor { get; set; }
    }
}
