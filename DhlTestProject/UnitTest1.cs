using Microsoft.VisualStudio.TestTools.UnitTesting;
using SD6503_DHl.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace DhlTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void LoginUnitTest()
        {
            LoginAccountUnitTestController controller = new LoginAccountUnitTestController();

            IActionResult result = controller.Index() as IActionResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void AccountDetailsUnitTest()
        {
            AccountDetailUnitTestController controller = new AccountDetailUnitTestController();

            IActionResult result = controller.Index() as IActionResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TransactionsUnitTest()
        {
            TransactionsUnitTestController controller = new TransactionsUnitTestController();

            IActionResult result = controller.Index() as IActionResult;

            Assert.IsNotNull(result);
        }
    }

}
