using Avanade.BestPractices.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Avanade.BestPractices.Infrestructure.Data.Contexts
{
    public class EntityContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Charge> Charges { get; set; }
        public DbSet<Document> Documents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EntityContext).Assembly);
        }
    }
}
