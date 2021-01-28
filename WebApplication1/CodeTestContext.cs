using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using CodeTest.DataModels;

namespace CodeTest
{
    public partial class CodeTestContext : DbContext
    {
        public DbSet<AccountDetails> AccountDetails { get; set; }
        public DbSet<PaymentDetails> PaymentDetails { get; set; }
    }
}
