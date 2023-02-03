using Avanade.BestPractices.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Avanade.BestPractices.Infrestructure.Data.Configurations.Core;

namespace Avanade.BestPractices.Infrestructure.Data.Configurations
{
    public class ChargeConfiguration : EntityTypeBaseConfiguration<Charge>
    {
        public override void Configure(EntityTypeBuilder<Charge> builder)
        {
            base.Configure(builder);

            builder.ToTable("Charges");

            builder.OwnsOne(x => x.GrossValue, grossValue =>
            {
                grossValue.Property(x => x.Value)
                    .HasColumnName("GrossValue");

                grossValue.Property(x => x.Currency)
                    .HasColumnName("Currency");
            });

            builder.OwnsOne(x => x.DiscountValue, discount =>
            {
                discount.Property(x => x.Value)
                    .HasColumnName("Discount");

                discount.Ignore(x => x.Currency);
            });

            builder.OwnsOne(x => x.NetValue, netValue =>
            {
                netValue.Property(x => x.Value)
                    .HasColumnName("NetValue");

                netValue.Ignore(x => x.Currency);
            });

            builder.Property(x => x.Description)
                .HasMaxLength(500);
        }
    }
}
