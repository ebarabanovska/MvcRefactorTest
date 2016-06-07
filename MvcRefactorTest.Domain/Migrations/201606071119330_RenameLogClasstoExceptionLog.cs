 namespace MvcRefactorTest.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameLogClasstoExceptionLog : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Logs", newName: "ExceptionLogs");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.ExceptionLogs", newName: "Logs");
        }
    }
}
