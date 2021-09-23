using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SD6503_DHl.Models;

namespace SD6503_DHl.Controllers
{
    public class TransactionsUnitTestController : Controller
    {
        public List<Transaction> GetTransactionList()
        {
            return new List<Transaction>
            {
                new Transaction
                {
                    TransactionNumber = "T002",
                    ToAccount = "BobAccount",
                    FromAccount = "SueAccount",
                    PaymentAmount = 7,
                    TransactionAmount = 35,
                    PaymentPeriod = "5 months",
                },
            };
        }

        public IActionResult Index()
        {
            var transactionDetails = from t in GetTransactionList() select t;
            return View(transactionDetails);
        }

        public IActionResult Transaction()
        {
            var transactionDetails = from t in GetTransactionList()
                                     orderby t.TransactionNumber
                                     select t;
            return View(transactionDetails);
        }

        public ActionResult Details(int Id)
        {
            return View("Details");
        }
    }
}
