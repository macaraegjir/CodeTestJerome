using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using CodeTest.Controllers;
using CodeTest.Model;

namespace CodeTest_Test
{
    class AccountsControllerTest
    {
        [Test]
        public void GetAccountPaymentDetails_expectedResult()
        {
            AccountsController AcctController = new AccountsController();

            AccountDetailModel AcctModel =  AcctController.GetAccountPaymentDetails("10000001");

            if(AcctModel.AccountNo != "10000001")
            {
                NUnit.Framework.Assert.Fail();
            }
            else if (AcctModel.Status != "Open")
            {
                NUnit.Framework.Assert.Fail();
            }
            else if (AcctModel.AccountBalance != 3000)
            {
                NUnit.Framework.Assert.Fail();
            }
            else
            {
                NUnit.Framework.Assert.Pass();
            }


        }
    }
}
