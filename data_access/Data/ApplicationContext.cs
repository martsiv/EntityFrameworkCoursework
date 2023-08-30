using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_access.Data
{
    public class ApplicationContext : DbContext
    {
        //public DbSet<Category> Categories { get; set; } = null!;
      
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
                       : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            //DbInitializer.SeedData(modelBuilder);
        }
    }
}
