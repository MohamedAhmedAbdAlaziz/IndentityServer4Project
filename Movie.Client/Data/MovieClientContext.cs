using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Movie.Client.Data
{
    
      
        public class MovieClientContext : DbContext
        {
            public MovieClientContext(DbContextOptions<MovieClientContext> options) : base(options)
            {

            }
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
                modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            }
            public DbSet<Movies.Client.Models.Movie> Movies { get; set; } = default!;
    }
}
