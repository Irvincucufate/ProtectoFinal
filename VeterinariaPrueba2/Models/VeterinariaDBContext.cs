using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace VeterinariaPrueba2.Models
{
    public class VeterinariaDBContext : DbContext
    {
        public DbSet<RegistroPersonal> Personal { get; set; }
        public DbSet<RegistroDueño> Dueños { get; set; }
        public DbSet<RegistroAnimales> Animales { get; set; }

    }
}