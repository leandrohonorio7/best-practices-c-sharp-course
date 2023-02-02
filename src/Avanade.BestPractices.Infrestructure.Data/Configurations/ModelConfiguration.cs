using Avanade.BestPractices.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Avanade.BestPractices.Infrestructure.Data.Configurations.Core;

namespace Avanade.BestPractices.Infrestructure.Data.Configurations
{
    public class ModelConfiguration : EntityTypeBaseConfiguration<Model>
    {
        public override void Configure(EntityTypeBuilder<Model> builder)
        {
            base.Configure(builder);

            builder.ToTable("Models");
        }
    }
}
