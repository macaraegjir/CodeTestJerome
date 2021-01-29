using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using NUnit.Framework;
using CodeTest.Model;
using CodeTest.DataModels;
//using CodeTest.Controllers;
using CodeTest.Business_Logic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CodeTest_Test
{
    public class AccountPaymentDetailsTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void checkInputFormat_expectedResult_correctFormat()
        {
            AccountPaymentDetails details = new AccountPaymentDetails();
            try
            {
                details.CheckInputFormat("12345678");
            }
            catch
            {
                NUnit.Framework.Assert.Fail();
            }
            NUnit.Framework.Assert.Pass();
        }

        [Test]
        public void checkInputFormat_expectedResult_notCorrectLength()
        {
            AccountPaymentDetails details = new AccountPaymentDetails();
            try
            {
                details.CheckInputFormat("1234567");
            }
            catch 
            {

                NUnit.Framework.Assert.Pass();

            }
            NUnit.Framework.Assert.Fail();
        }

        [Test]
        public void checkInputFormat_expectedResult_inputHasLetters()
        {
            AccountPaymentDetails details = new AccountPaymentDetails();
            try
            {
                details.CheckInputFormat("1234567a");
            }
            catch 
            {

                NUnit.Framework.Assert.Pass();

            }
            NUnit.Framework.Assert.Fail();
        }

        [Test]
        public void GetAccountPaymentDetails_expectedResult()
        {
            AccountPaymentDetails details = new AccountPaymentDetails();
            AccountDetailModel account = new AccountDetailModel();
            try
            {
                account = details.GetAccountPaymentDetails("10000001");
            }
            catch 
            {

                NUnit.Framework.Assert.Fail();

            }

            if (account.AccountNo != "10000001")
            {
                NUnit.Framework.Assert.Fail();
            }
            else if (account.Status != "Open")
            {
                NUnit.Framework.Assert.Fail();
            }
            else if (account.AccountBalance != 3000)
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
