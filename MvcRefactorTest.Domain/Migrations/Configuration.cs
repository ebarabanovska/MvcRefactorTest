using System.Data.Entity.Migrations;
using MvcRefactorTest.Domain.db;

namespace MvcRefactorTest.Domain.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<dbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(dbContext context)
        {
            context.User.AddOrUpdate(a => a.id,
                new User {Name = "Chris Smith", Password = "pass", Role = "Developer", IsEnabled = true});
            context.User.AddOrUpdate(a => a.id,
                new User {Name = "Awin George", Password = "pass", Role = "Developer", IsEnabled = false});
            context.User.AddOrUpdate(a => a.id,
                new User {Name = "Richard Child", Password = "pass", Role = "Developer", IsEnabled = true});

            context.Contact.AddOrUpdate(a => a.id, new Contact
            {
                MainPhone = "425 555 0100",
                AfterHours = "425 555 0199",
                SupportEmail = "Support@example.com",
                MarketingEmail = "Marketing@example.com",
                GeneralEmail = "General@example.com",
                Address = "One Microsoft Way Redmond, WA 98052-6399"
            });

            context.SaveChanges();
        }
    }
}