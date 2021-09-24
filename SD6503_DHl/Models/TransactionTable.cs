using System;
using System.Collections.Generic;

#nullable disable

namespace SD6503_DHl.Models
{
    public partial class TransactionTable
    {
        public int TransactionNumber { get; set; }
        public int ToAccount { get; set; }
        public int FromAccount { get; set; }
        public double PaymentAmount { get; set; }
        public double TransactionAmount { get; set; }
        public string PaymentPeriod { get; set; }

        public virtual AccountDetail FromAccountNavigation { get; set; }
    }
}
