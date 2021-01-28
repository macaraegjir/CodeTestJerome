using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeTest.Model
{
    public class AccountDetailModel
    {

        public string AccountNo { get; set; }

        public string Status { get; set; }

        public string ReasonForClosed { get; set; }

        public virtual List<PaymentDetailModel> PaymentDetails { get; set; }

        public decimal AccountBalance { get; set; }

    }
}