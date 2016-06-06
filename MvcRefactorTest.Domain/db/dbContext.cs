using System.Data.Entity;

namespace MvcRefactorTest.Domain.db
{
    public class dbContext : DbContext
    {
        public dbContext()
            : base("MvcRefactorTest")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<User> User { get; set; }

        public DbSet<Contact> Contact { get; set; }

        public DbSet<Log> Log { get; set; }
    }
}