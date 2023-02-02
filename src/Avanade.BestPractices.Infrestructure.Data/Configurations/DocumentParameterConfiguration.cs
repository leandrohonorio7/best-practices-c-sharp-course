﻿using Avanade.BestPractices.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Avanade.BestPractices.Infrestructure.Data.Configurations.Core;

namespace Avanade.BestPractices.Infrestructure.Data.Configurations
{
    public class DocumentParameterConfiguration : EntityTypeBaseConfiguration<DocumentParameter>
    {
        public override void Configure(EntityTypeBuilder<DocumentParameter> builder)
        {
            base.Configure(builder);

            builder.ToTable("DocumentParameters");
        }
    }
}
