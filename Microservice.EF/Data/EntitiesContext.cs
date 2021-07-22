using Microservice.Domain;
using Microservice.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Microservice.EF.Data
{
    public class EntitiesContext: DbContext
    {
        public EntitiesContext(DbContextOptions<EntitiesContext> options) : base(options)
        {
        }

        public DbSet<Entity> Entities { get; set; }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entity>().ToTable(nameof(Entity));

            modelBuilder.Entity<Customer>().ToTable(nameof(Customer));
        }
    }
}
