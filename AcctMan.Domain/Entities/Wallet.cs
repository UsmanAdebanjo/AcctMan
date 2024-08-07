using AcctMan.Domain.Abstract;
using AcctMan.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcctMan.Domain.Entities
{
    public class Wallet:IEntity<Guid>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string AccountNumber { get; set; }
        public decimal  Amount { get; set; }
        public TransactionType TransactionType { get; set; }
        public TransactionStatus Status { get; set; }

        public string Narration { get; set; }

        public User User { get; set; }

        public DateTime LastModifiedDate { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
