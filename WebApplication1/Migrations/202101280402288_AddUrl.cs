namespace CodeTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PaymentDetails", "AccountNo", "dbo.AccountDetails");
            DropIndex("dbo.PaymentDetails", new[] { "AccountNo" });
            AlterColumn("dbo.PaymentDetails", "AccountNo", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PaymentDetails", "AccountNo", c => c.String(maxLength: 128));
            CreateIndex("dbo.PaymentDetails", "AccountNo");
            AddForeignKey("dbo.PaymentDetails", "AccountNo", "dbo.AccountDetails", "AccountNo");
        }
    }
}
