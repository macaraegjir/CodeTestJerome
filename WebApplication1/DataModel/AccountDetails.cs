using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CodeTest.DataModels
{
    public class AccountDetails
    {
        [Key]
        public string AccountNo { get; set; }

        public string Status { get; set; }

        public string ReasonForClosed { get; set; }

        

    }
}