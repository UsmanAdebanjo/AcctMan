using AcctMan.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcctMan.Infrastructure.Configs
{
    public class UserConfig:IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        { 
            builder.Property(t=>t.FirstName).IsRequired().HasMaxLength(15);
            builder.Property(t=>t.LastName).IsRequired().HasMaxLength(15);
            builder.HasKey(u => u.Id);

        }

    }
}