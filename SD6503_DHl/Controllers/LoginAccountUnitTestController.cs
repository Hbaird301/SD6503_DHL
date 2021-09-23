using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SD6503_DHl.Models;

namespace SD6503_DHl.Controllers
{
    public class LoginAccountUnitTestController : Controller
    {
        public List<LoginAccount> GetLoginAccountList()
        {
            return new List<LoginAccount>
            {
                new LoginAccount
                {
                    Username = "bob",
                    Password = "BobPassword",
                    Identifier = "bob123",
                },
                    new LoginAccount
                {
                    Username = "sue",
                    Password = "SuePassword",
                    Identifier = "sue123",
                },
            };
        }

        public IActionResult Index()
        {
            var loginAccounts = from l in GetLoginAccountList() select l;
            return View(loginAccounts);
        }

        public IActionResult Login()
        {
            var loginAccounts = from l in GetLoginAccountList()
                                orderby l.Username
                                select l;
            return View(loginAccounts);
        }

        public ActionResult Details(int Id)
        {
            return View("Details");
        }
    }
}
