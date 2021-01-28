namespace CodeTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountDetails",
                c => new
                    {
                        AccountNo = c.String(nullable: false, maxLength: 128),
                        Status = c.String(),
                        ReasonForClosed = c.String(),
                    })
                .PrimaryKey(t => t.AccountNo);
            
            CreateTable(
                "dbo.PaymentDetails",
                c => new
                    {
                        PaymentID = c.Int(nullable: false, identity: true),
                        AccountNo = c.String(maxLength: 128),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PaymentID)
                .ForeignKey("dbo.AccountDetails", t => t.AccountNo)
                .Index(t => t.AccountNo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PaymentDetails", "AccountNo", "dbo.AccountDetails");
            DropIndex("dbo.PaymentDetails", new[] { "AccountNo" });
            DropTable("dbo.PaymentDetails");
            DropTable("dbo.AccountDetails");
        }
    }
}
