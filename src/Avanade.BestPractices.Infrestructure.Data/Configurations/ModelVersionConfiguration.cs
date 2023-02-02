using Avanade.BestPractices.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Avanade.BestPractices.Infrestructure.Data.Configurations.Core;

namespace Avanade.BestPractices.Infrestructure.Data.Configurations
{
    public class ModelVersionConfiguration : EntityTypeBaseConfiguration<ModelVersion>
    {
        public override void Configure(EntityTypeBuilder<ModelVersion> builder)
        {
            base.Configure(builder);

            builder.ToTable("ModelVersions");
        }
    }
}
