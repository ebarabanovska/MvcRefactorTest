namespace MvcRefactorTest.Domain.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MvcRefactorTest.Domain.db.dbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MvcRefactorTest.Domain.db.dbContext context)
        {
            context.User.AddOrUpdate(a => a.id, new User { name = "Chris Smith", password = "pass", role = "Developer", isEnabled = true });
            context.User.AddOrUpdate(a => a.id, new User { name = "Awin George", password = "pass", role = "Developer", isEnabled = false });
            context.User.AddOrUpdate(a => a.id, new User { name = "Richard Child", password = "pass", role = "Developer", isEnabled = true });

            context.Contact.AddOrUpdate(a => a.id, new Contact
            {
                mainPhone = "425 555 0100",
                afterHours = "425 555 0199",
                supportEmail = "Support@example.com",
                marketingEmail = "Marketing@example.com",
                generalEmail = "General@example.com",
                address = "One Microsoft Way Redmond, WA 98052-6399"
            });

            context.SaveChanges();
        }
    }
}
