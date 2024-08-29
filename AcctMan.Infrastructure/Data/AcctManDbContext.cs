using AcctMan.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;



namespace AcctMan.Infrastructure.Data
{
    public class AcctManDbContext:IdentityDbContext<User>
    {
        public AcctManDbContext(DbContextOptions<AcctManDbContext> options):base(options)
        {

        }

        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Ledger> Ledgers { get; set; }

    }
}
