using AcctMan.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AcctMan.Infrastructure.Data
{
    public class AcctManDbContext:DbContext
    {

        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Ledger> Ledgers { get; set; }
        public DbSet<User>  Users { get; set; }
    }
}
