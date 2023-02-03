using Avanade.BestPractices.Domain.Entities;
using Avanade.BestPractices.Infrestructure.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Avanade.BestPractices.Infrestructure.Core.Entities.Constants;

namespace Avanade.BestPractices.Infrestructure.Data.Contexts
{
    public class EntityContext : DbContext
    {
        private readonly string _userId;

        public EntityContext(DbContextOptions<EntityContext> optionsBuilder) : base(optionsBuilder) { }
        public EntityContext(DbContextOptions<EntityContext> optionsBuilder, string userId) :
            base(optionsBuilder)
        {
            _userId = userId;
        }

#if DEBUG
        public EntityContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=BestPractices;Integrated Security=SSPI;");
        }
#endif

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Charge> Charges { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<DocumentParameter> DocumentParameters { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<ModelVersion> ModelVersions { get; set; }
        public DbSet<Ride> Rides { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ConfigureMaxStringLength(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EntityContext).Assembly);

            modelBuilder.HasDefaultSchema("domain");
        }

        private static void ConfigureMaxStringLength(ModelBuilder modelBuilder)
        {
            var stringProperties = modelBuilder.Model
                .GetEntityTypes()
                .SelectMany(x => x.GetProperties()
                    .Where(p => p.ClrType == typeof(string)));

            foreach (var property in stringProperties)
                property.SetMaxLength(EntityConfigutarationValueConstant.StringMaxLength);
        }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            SetEntityBaseData();
            return base.SaveChangesAsync(true, cancellationToken);
        }

        public override int SaveChanges()
        {
            SetEntityBaseData();
            return base.SaveChanges();
        }

        private void SetEntityBaseData()
        {
            if (string.IsNullOrEmpty(_userId))
                throw new InvalidOperationException("The userId is required to create and update operations");

            var entities = ChangeTracker
                .Entries()
                .Where(x => x.Entity is EntityBase &&
                            x.State is EntityState.Added or EntityState.Modified);

            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    ((EntityBase)entity.Entity).CreatedAt = DateTime.UtcNow;
                    ((EntityBase)entity.Entity).CreatedBy = _userId;
                }
                else
                {
                    ((EntityBase)entity.Entity).ModifiedAt = DateTime.UtcNow;
                    ((EntityBase)entity.Entity).ModifiedBy = _userId;
                }
            }
        }
    }
}
