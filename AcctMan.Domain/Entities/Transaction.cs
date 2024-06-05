﻿using AcctMan.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcctMan.Domain.Entities
{
    public class Transaction:IEntity<Guid>
    {
        public TransactionType EntryType { get; set; }
        public decimal TransactionAmount
        {
            get =>_transactionAmount;
            set => _transactionAmount = (value >= 0) ? value : 0;
        }
        public Guid Id { get; set; }
        public Guid WalletId { get; set; }

        public Wallet Wallet { get; set; }

        public DateTime LastModifiedDate { get; set; }
        public DateTime CreateDate { get; set; }

        private decimal _transactionAmount;
    }
}
