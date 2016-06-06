namespace MvcRefactorTest.Domain.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class GenerateBataBase : DbMigration
    {
        public override void Down()
        {
            this.DropTable("dbo.Users");
            this.DropTable("dbo.Logs");
            this.DropTable("dbo.Contacts");
        }

        public override void Up()
        {
            this.CreateTable(
                "dbo.Contacts", 
                c =>
                new
                    {
                        id = c.Int(false, true), 
                        mainPhone = c.String(false), 
                        afterHours = c.String(false), 
                        supportEmail = c.String(false), 
                        marketingEmail = c.String(false), 
                        generalEmail = c.String(false), 
                        address = c.String(false), 
                        date_created = c.DateTime(false), 
                        date_updated = c.DateTime(false), 
                        isDeleted = c.Boolean(false)
                    }).PrimaryKey(t => t.id);

            this.CreateTable(
                "dbo.Logs", 
                c =>
                new
                    {
                        Id = c.Int(false, true), 
                        Date = c.DateTime(false), 
                        Thread = c.String(false, 255), 
                        Level = c.String(false, 50), 
                        Logger = c.String(false, 255), 
                        Message = c.String(false, 4000), 
                        Exception = c.String(maxLength: 2000)
                    }).PrimaryKey(t => t.Id);

            this.CreateTable(
                "dbo.Users", 
                c =>
                new
                    {
                        id = c.Int(false, true), 
                        name = c.String(false), 
                        password = c.String(false), 
                        role = c.String(false), 
                        isEnabled = c.Boolean(false), 
                        date_created = c.DateTime(false), 
                        date_updated = c.DateTime(false), 
                        isDeleted = c.Boolean(false)
                    }).PrimaryKey(t => t.id);
        }
    }
}