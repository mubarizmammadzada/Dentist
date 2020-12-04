using Dentist.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dentist.ViewModels
{
    public class HomeVM
    {
        public WellComing WellComing { get; set; }
        public Doctor Doctor { get; set; }
        public List<Doctor> Doctors { get; set; }
        public List<Treatment> Treatments { get; set; }
        public List<Patient> Patient { get; set; }
        public List<Blog> Blogs { get; set; }
        public List<Portfolio> Portfolios { get; set; }
        public List<Slider> Sliders { get; set; }

    }
}
