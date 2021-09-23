using System;
using System.Collections.Generic;

#nullable disable

namespace SD6503_DHl.Models
{
    public partial class AccountDetail
    {
        public AccountDetail()
        {
            Transactions = new HashSet<Transaction>();
        }

        public string Identifier { get; set; }
        public string AccountNumber { get; set; }
        public string Name { get; set; }
        public double Balance { get; set; }

        public virtual LoginAccount IdentifierNavigation { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
