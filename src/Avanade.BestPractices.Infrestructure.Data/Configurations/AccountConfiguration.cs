using Avanade.BestPractices.Domain.Entities;
using Avanade.BestPractices.Infrestructure.Data.Configurations.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Avanade.BestPractices.Infrestructure.Data.Configurations
{
    public class AccountConfiguration : EntityTypeBaseConfiguration<Account>
    {
        public override void Configure(EntityTypeBuilder<Account> builder)
        {
            base.Configure(builder);

            builder.ToTable("Accounts");
        }
    }
}
