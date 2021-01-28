using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Data;
using System.Net;
using System.Net.Http;
using CodeTest.Error;
using CodeTest.DataModels;
using CodeTest.Model;


namespace CodeTest.DataAccess
{
    public class da_AccountDetails
    {
        private ErrorHandling error;

        public da_AccountDetails()
        {
            error = new ErrorHandling();
        }
        //public DataTable GetAccountDetails(string AccountNo)
        //{
        //    string sqlQuery = "select * from AccountDetails where AccountNo = '" + AccountNo + "'";

        //    DataTable result = new DataTable();

        //    result = SQLDataAccess.QueryData(sqlQuery);

        //    if (result.Rows.Count == 0)
        //    {
        //        error.throwError("AccountNo does not exist", "AccountNo not found", HttpStatusCode.NotFound);
        //    }

        //    return result;
        //}

        public AccountDetailModel GetAccountDetailsEntity(string AccountNo)
        {

            AccountDetailModel acctModel = new AccountDetailModel();

            using (var db = new CodeTestContext())
            {

                var query = from b in db.AccountDetails.AsEnumerable()
                                                    where b.AccountNo == AccountNo
                                                    select b;

                //put data into AccountDetailModel
                if (query == null)
                {
                    error.throwError("AccountNo does not exist", "AccountNo not found", HttpStatusCode.NotFound);
                }
                var account = query.FirstOrDefault<AccountDetails>();

                if (account != null && account.AccountNo != string.Empty)
                {
                    acctModel.AccountNo = account.AccountNo;
                    acctModel.Status = account.Status;
                    acctModel.ReasonForClosed = account.ReasonForClosed;
                }
                else
                {
                    error.throwError("AccountNo does not exist", "AccountNo not found", HttpStatusCode.NotFound);
                }
                

            }

            return acctModel;
        }


    }
}