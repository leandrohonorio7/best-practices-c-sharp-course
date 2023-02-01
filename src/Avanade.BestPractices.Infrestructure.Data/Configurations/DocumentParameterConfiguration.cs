using Avanade.BestPractices.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Avanade.BestPractices.Infrestructure.Data.Configurations
{
    public class DocumentParameterConfiguration : IEntityTypeConfiguration<DocumentParameter>
    {
        public void Configure(EntityTypeBuilder<DocumentParameter> builder)
        {
            builder.ToTable("DocumentParameters");
        }
    }
}
