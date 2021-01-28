using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CodeTest.DataAccess;
using CodeTest.DataModels;
using CodeTest.Model;
using System.Data;
using CodeTest.Error;
using System.Net;
using System.Net.Http;
namespace CodeTest.Business_Logic
{
    public class AccountPaymentDetails
    {

        private ErrorHandling error;

        public AccountPaymentDetails()
        {
            error = new ErrorHandling();
        }

        public void fillData()
        {
            int rowCtr = 0;
            using (var data = new CodeTestContext())
            {
                rowCtr = data.Database.SqlQuery<int>("Select count(*) from AccountDetails")
                            .FirstOrDefault();

                if (rowCtr == 0)
                {
                    data.AccountDetails.AddRange(new List<AccountDetails>
                    {
                        new AccountDetails(){ AccountNo = "10000001", Status = "Open", ReasonForClosed = "" },
                        new AccountDetails(){ AccountNo = "10000002", Status = "Open", ReasonForClosed = "" },
                        new AccountDetails(){ AccountNo = "10000003", Status = "Closed", ReasonForClosed = "Bankrupt" }

                    });

                    _ = data.PaymentDetails.AddRange(new List<PaymentDetails>
                    {
                        new PaymentDetails(){ AccountNo = "10000001", Amount = Convert.ToDecimal( 1000.00 ), Date = Convert.ToDateTime( "12-25-2020 12:00:00 AM" )},
                        new PaymentDetails(){ AccountNo = "10000001", Amount = Convert.ToDecimal( 2000.00 ), Date = Convert.ToDateTime( "12/31/2020 12:00:00 AM" )},
                        new PaymentDetails(){ AccountNo = "10000002", Amount = Convert.ToDecimal( 5000.00 ), Date = Convert.ToDateTime( "1/1/2021 12:00:00 AM" )},
                        new PaymentDetails(){ AccountNo = "10000002", Amount = Convert.ToDecimal( 10000.00 ), Date = Convert.ToDateTime( "1/21/2021 12:00:00 AM" )},
                        new PaymentDetails(){ AccountNo = "10000003", Amount = Convert.ToDecimal( 50.50 ), Date = Convert.ToDateTime( "9/14/2020 12:00:00 AM" )},
                        new PaymentDetails(){ AccountNo = "10000003", Amount = Convert.ToDecimal( 100.00 ), Date = Convert.ToDateTime( "8/30/2020 12:00:00 AM" )},
                        new PaymentDetails(){ AccountNo = "10000003", Amount = Convert.ToDecimal( 564.67 ), Date = Convert.ToDateTime( "7/14/2019 12:00:00 AM" )},
                    });
                }
                 data.SaveChanges();
             }
        }

        public AccountDetailModel GetAccountPaymentDetails(string AccountNo)
        {
            da_AccountDetails da_AccountDetails = new da_AccountDetails();



            
            //call dataaccess to get Account data from DB
            AccountDetailModel details = da_AccountDetails.GetAccountDetailsEntity(AccountNo);

            
            da_PaymentDetails da_PaymentDetails = new da_PaymentDetails();

            //get Payment details
            List<PaymentDetailModel> PayDetails = da_PaymentDetails.GetPaymentDetailsEntity(AccountNo);

            //apply payment details to AccountDetailModel
            details.PaymentDetails = PayDetails;

            //Compute total balance
            details.AccountBalance = CalculateTotalBalance(PayDetails);

            return details;

        }

        private decimal CalculateTotalBalance(List<PaymentDetailModel> PayDetails)
        {
            decimal Total = 0;
            foreach (PaymentDetailModel detail in PayDetails)
            {
                Total += detail.Amount;
            }

            return Total;
        }

        public void checkInputFormat(string AccountNo)
        {
            //assuming that the account number has a set length
            if (AccountNo.Trim().Length != 8)
            {
                error.throwError("AcccountNo must be 8 digits", "AcccountNo must be 8 digits", HttpStatusCode.BadRequest);
            }

            //Account number should only have numbers
            if (!int.TryParse(AccountNo, out int result))
            {
                error.throwError("AcccountNo not in correct format", "AccountNo not in correct format", HttpStatusCode.BadRequest);
            }
        }

    }
}