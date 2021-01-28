using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CodeTest.DataModels
{
    public class PaymentDetails
    {
        [Key]
        public int PaymentID { get; set; }
        public string AccountNo { get; set; }

        public decimal Amount { get; set; }

        public DateTime Date { get; set; }

    }
}