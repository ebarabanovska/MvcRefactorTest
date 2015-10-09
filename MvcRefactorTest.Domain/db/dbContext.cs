using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcRefactorTest.Domain.db
{
    public class dbContext : DbContext
    {
        public dbContext()
            : base("MvcRefactorTest")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<User> User { get; set; }

        public DbSet<Contact> Contact { get; set; }

        public DbSet<Log> Log { get; set; }
    }
}
