using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

#nullable disable

namespace SD6503_DHl.Models
{
    public partial class LoginAccount
    {
        public LoginAccount()
        {
            AccountDetails = new HashSet<AccountDetail>();
        }

        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        public int Identifier { get; set; }

        public virtual ICollection<AccountDetail> AccountDetails { get; set; }
    }
}
