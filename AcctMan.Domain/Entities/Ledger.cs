using AcctMan.Domain.Enums;

namespace AcctMan.Domain.Entities
{
    public class Ledger : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public decimal Balance
        {
            get => _balance;
            set => _balance = (_balance>=0) ? value : 0;
        }
        public DateTime LastModifiedDate { get; set; }
        public DateTime CreateDate { get; set; }

        public Guid TransactionId {get; set;}

        public Transaction Transaction { get; set; }


        private decimal _balance;
    }
}
