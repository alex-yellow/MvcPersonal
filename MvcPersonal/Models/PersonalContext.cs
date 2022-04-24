using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcPersonal.Models
{
    public class PersonalContext:DbContext
    {
        public DbSet<Personal> Personals { get; set; }
    }
}