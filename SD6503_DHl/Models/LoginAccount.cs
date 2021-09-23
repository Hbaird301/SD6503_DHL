using System;
using System.Collections.Generic;

#nullable disable

namespace SD6503_DHl.Models
{
    public partial class LoginAccount
    {
        public LoginAccount()
        {
            AccountDetails = new HashSet<AccountDetail>();
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public string Identifier { get; set; }

        public virtual ICollection<AccountDetail> AccountDetails { get; set; }
    }
}
