using AcctMan.Domain.Abstract;
using AcctMan.Domain.Entities;
using AcctMan.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AcctMan.Infrastructure.Repositories
{
    public class WalletRepo : GenericRepository<Wallet, Guid>, IWalletRepo
    {
        public WalletRepo(AcctManDbContext context, DbSet<Wallet> dbset) : base(context, dbset)
        {
        }
    }

}
