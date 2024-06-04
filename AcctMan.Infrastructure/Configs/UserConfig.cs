using AcctMan.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcctMan.Infrastructure.Configs
{
    public class UserConfig:IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        { 
            builder.HasOne(u => u.Wallet);
            builder.Property(t=>t.FirstName).IsRequired();
            builder.Property(t=>t.LastName).IsRequired();
        }

    }
}