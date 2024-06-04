using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcctMan.Domain.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public DateTime CreateDate {get; set; }

        public Guid WalletId { get; set; }
        
        public Wallet Wallet{ get; set; }
    }
}
