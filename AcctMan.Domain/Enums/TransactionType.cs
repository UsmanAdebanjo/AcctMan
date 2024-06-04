using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcctMan.Domain.Enums
{
    public enum TransactionType
    {
        [Description("Debit")]
        Dr=0,
        [Description("Credit")]
        Cr=1
    }
}
