using System;
using System.Collections.Generic;

#nullable disable

namespace SD6503_DHl.Models
{
    public partial class Transaction
    {
        public string TransactionNumber { get; set; }
        public string ToAccount { get; set; }
        public string FromAccount { get; set; }
        public double PaymentAmount { get; set; }
        public double TransactionAmount { get; set; }
        public string PaymentPeriod { get; set; }

        public virtual AccountDetail FromAccountNavigation { get; set; }
    }
}
