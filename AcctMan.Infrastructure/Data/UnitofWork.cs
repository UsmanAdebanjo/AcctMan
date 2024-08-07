using AcctMan.Domain.Abstract;

namespace AcctMan.Infrastructure.Data
{
    public class UnitofWork : IUnitofWork
    {
        private readonly AcctManDbContext _context;
        public IWalletRepo Wallet { get; }
        public UnitofWork(AcctManDbContext context)
        {
            _context = context;
        }
        public void Dispose()
        {
            _context.Dispose();
        }

        public int Save()
        {
           return _context.SaveChanges();
        }
    }
}
