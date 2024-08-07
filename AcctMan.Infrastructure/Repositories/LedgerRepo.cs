using AcctMan.Domain.Abstract;
using AcctMan.Domain.Entities;
using AcctMan.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AcctMan.Infrastructure.Repositories
{
    public class LedgerRepo: GenericRepository<Ledger, Guid>, ILedgerRepo
    {
        public LedgerRepo(AcctManDbContext context, DbSet<Ledger> dbSet): base(context, dbSet)
        {

        }
    }
}
