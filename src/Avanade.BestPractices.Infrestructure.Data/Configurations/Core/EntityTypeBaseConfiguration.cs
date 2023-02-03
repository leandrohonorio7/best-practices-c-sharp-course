using Avanade.BestPractices.Infrestructure.Core.Entities;
using Avanade.BestPractices.Infrestructure.Core.Entities.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Avanade.BestPractices.Infrestructure.Data.Configurations.Core
{
    public class EntityTypeBaseConfiguration<T> : IEntityTypeConfiguration<T> where T : EntityBase
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasQueryFilter(x => !x.IsDeleted);

            builder.Property(x => x.CreatedBy)
                .HasMaxLength(EntityConfigutarationValueConstant.StringMaxLength);

            builder.Property(x => x.ModifiedBy)
                .HasMaxLength(EntityConfigutarationValueConstant.StringMaxLength);
        }
    }
}
