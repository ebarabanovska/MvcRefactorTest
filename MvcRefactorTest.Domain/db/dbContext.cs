using System.Data.Entity;

namespace MvcRefactorTest.Domain.db
{
    using System;

    public class dbContext : DbContext, IDisposable
    {
        public dbContext()
            : base("MvcRefactorTest")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Contact> Contact { get; set; }

        public virtual DbSet<Log> Log { get; set; }

        public virtual DbSet<User> User { get; set; }
    }
}