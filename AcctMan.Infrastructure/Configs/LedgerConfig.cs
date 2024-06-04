using AcctMan.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcctMan.Infrastructure.Configs
{
    public class LedgerConfig : IEntityTypeConfiguration<Ledger>
    {
        public void Configure(EntityTypeBuilder<Ledger> builder)
        {
            builder.HasKey(l => l.Id);             
            builder.HasOne(l => l.Transaction);
        }
    }
}