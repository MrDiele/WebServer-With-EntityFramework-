using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebServer.Model;

namespace WebServer.DataAccessPostgreSqlProvider
{
    public class DomainModelPostgreSqlContext : DbContext
    {
        public DomainModelPostgreSqlContext(DbContextOptions<DomainModelPostgreSqlContext> options) : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }

        public DbSet<City> Cities { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Person>().HasKey(m => m.Idperson);
            builder.Entity<City>().HasKey(m => m.Idcity);

            // shadow properties
            //builder.Entity<Person>().Property<DateTime>("UpdatedTimestamp");
            //builder.Entity<City>().Property<DateTime>("UpdatedTimestamp");

            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();

            //updateUpdatedProperty<City>();
            //updateUpdatedProperty<Person>();

            return base.SaveChanges();
        }

        private void updateUpdatedProperty<T>() where T : class
        {
            var modifiedPersonInfo =
                ChangeTracker.Entries<T>()
                    .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            foreach (var entry in modifiedPersonInfo)
            {
                entry.Property("UpdatedTimestamp").CurrentValue = DateTime.UtcNow;
            }
        }
    }
}
