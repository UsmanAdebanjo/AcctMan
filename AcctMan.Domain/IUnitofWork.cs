using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcctMan.Domain
{
    public interface IUnitofWork:IDisposable
    {
        public IWalletRepo Wallet { get; }
        
        public int Save();
    }
}
