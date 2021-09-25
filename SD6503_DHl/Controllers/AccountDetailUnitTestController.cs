using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SD6503_DHl.Models;

namespace SD6503_DHl.Controllers
{
    public class AccountDetailUnitTestController : Controller
    {
        public List<AccountDetail> GetAccountDetailList()
        {
            return new List<AccountDetail>
            {
                new AccountDetail
                {
                    Identifier = 1233453245,
                    AccountNumber = 456,
                    Name = "Bob Smith",
                    Balance = 555,
                },
                new AccountDetail
                {
                    Identifier = 654424253,
                    AccountNumber = 888,
                    Name = "Sue Grey",
                    Balance = 666,
                },
            };
        }

        public IActionResult Index()
        {
            var accountDetails = from a in GetAccountDetailList() select a;
            return View(accountDetails);
        }

        public IActionResult Account()
        {
            var accountDetails = from a in GetAccountDetailList()
                                 orderby a.Name
                                 select a;
            return View(accountDetails);
        }

        public ActionResult Details(int Id)
        {
            return View("Details");
        }
    }
}
