using System.ComponentModel;

namespace AcctMan.Domain.Enums
{
    public enum TransactionStatus
    {
        [Description("Failed")]
        Failed = 0,
        [Description("Successful")]
        Successful=1,
        [Description("Pending")]
        Pending=2
    }
}
