namespace MvcRefactorTest.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GenerateBataBase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        mainPhone = c.String(nullable: false),
                        afterHours = c.String(nullable: false),
                        supportEmail = c.String(nullable: false),
                        marketingEmail = c.String(nullable: false),
                        generalEmail = c.String(nullable: false),
                        address = c.String(nullable: false),
                        date_created = c.DateTime(nullable: false),
                        date_updated = c.DateTime(nullable: false),
                        isDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Logs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Thread = c.String(nullable: false, maxLength: 255),
                        Level = c.String(nullable: false, maxLength: 50),
                        Logger = c.String(nullable: false, maxLength: 255),
                        Message = c.String(nullable: false, maxLength: 4000),
                        Exception = c.String(maxLength: 2000),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false),
                        password = c.String(nullable: false),
                        role = c.String(nullable: false),
                        isEnabled = c.Boolean(nullable: false),
                        date_created = c.DateTime(nullable: false),
                        date_updated = c.DateTime(nullable: false),
                        isDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Logs");
            DropTable("dbo.Contacts");
        }
    }
}
