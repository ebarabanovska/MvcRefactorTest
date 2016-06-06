using System.Data.Entity;

namespace MvcRefactorTest.Domain.db
{
    public class dbContext : DbContext
    {
        public dbContext()
            : base("MvcRefactorTest")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Contact> Contact { get; set; }

        public DbSet<Log> Log { get; set; }

        public DbSet<User> User { get; set; }
    }
}