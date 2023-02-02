using Avanade.BestPractices.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Avanade.BestPractices.Infrestructure.Data.Configurations.Core;

namespace Avanade.BestPractices.Infrestructure.Data.Configurations
{
    public class RideConfiguration : EntityTypeBaseConfiguration<Ride>
    {
        public override void Configure(EntityTypeBuilder<Ride> builder)
        {
            base.Configure(builder);

            builder.ToTable("Rides");
        }
    }
}
