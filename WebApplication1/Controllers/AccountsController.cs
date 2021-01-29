using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CodeTest.Model;
using CodeTest.Business_Logic;

namespace CodeTest.Controllers
{
    public class AccountsController : ApiController
    {
        private AccountPaymentDetails _details;
        public AccountsController()
        {
            _details = new AccountPaymentDetails();
        }
        
        [Route("api/accounts/GetAccountPaymentDetails/{id}")]
        public AccountDetailModel GetAccountPaymentDetails(string id)
        {
            
                //will populate database on first run
                _details.FillData();
                //check input format
                _details.CheckInputFormat(id);

                AccountDetailModel acctModel = _details.GetAccountPaymentDetails(id);

                return acctModel;
            
            
        }

        
    }
}
