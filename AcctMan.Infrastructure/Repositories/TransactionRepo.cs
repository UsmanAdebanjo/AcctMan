using AcctMan.Domain.Abstract;
using AcctMan.Domain.Entities;
using AcctMan.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AcctMan.Infrastructure.Repositories
{
    public class TransactionRepo : GenericRepository<Transaction, Guid>, ITransactionRepo
    {
        public TransactionRepo(AcctManDbContext context, DbSet<Transaction> dbset) : base(context, dbset)
        {
        }
    }

}
