using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Gibjohn_Tutoring.Models;

namespace Gibjohn_Tutoring.Data
{
    public class Gibjohn_TutoringContext : DbContext
    {
        public Gibjohn_TutoringContext (DbContextOptions<Gibjohn_TutoringContext> options)
            : base(options)
        {
        }

        public DbSet<Gibjohn_Tutoring.Models.StudentsDB> StudentsDB { get; set; } = default!;
    }
}
