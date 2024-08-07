using AcctMan.Domain.Entities;
using Microsoft.EntityFrameworkCore;



namespace AcctMan.Infrastructure.Data
{
    public class AcctManDbContext:DbContext
    {
        public AcctManDbContext(DbContextOptions<AcctManDbContext> options):base(options)
        {

        }

        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Ledger> Ledgers { get; set; }
        public DbSet<User>  Users { get; set; }
    }
}
