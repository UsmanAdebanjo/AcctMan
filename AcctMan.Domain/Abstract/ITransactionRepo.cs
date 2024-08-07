using AcctMan.Domain.Entities;

namespace AcctMan.Domain.Abstract
{
    public interface ITransactionRepo: IGenericRepository<Transaction, Guid>
    {

    }

}
