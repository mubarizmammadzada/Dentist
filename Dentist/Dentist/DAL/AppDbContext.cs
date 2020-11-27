using Dentist.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dentist.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<WellComing> WellComings { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Bio> Bios { get; set; }

    }
}
