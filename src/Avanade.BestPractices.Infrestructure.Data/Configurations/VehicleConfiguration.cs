using Avanade.BestPractices.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Avanade.BestPractices.Infrestructure.Data.Configurations.Core;

namespace Avanade.BestPractices.Infrestructure.Data.Configurations
{
    public class VehicleConfiguration : EntityTypeBaseConfiguration<Vehicle>
    {
        public override void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            base.Configure(builder);

            builder.ToTable("Vehicles");

            builder.Property(x => x.Plate)
                .HasMaxLength(15);

            builder.Property(x => x.Color)
                .HasMaxLength(50);
        }
    }
}
