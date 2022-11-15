using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BD_First.Models;

namespace BD_First.Data
{
    public class BD_FirstContext : DbContext
    {
        public BD_FirstContext (DbContextOptions<BD_FirstContext> options)
            : base(options)
        {
        }

        public DbSet<IngestModel> IngestModel { get; set; } = default!;
        public DbSet<WeatherModel> WeatherModel { get; set; } = default!;
    }
}
