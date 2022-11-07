using Microsoft.EntityFrameworkCore;
using SibTestProjectDB.TypesCore;
using SibTestProjectDB.Interfaces;
using SibTestProjectDB.TypeConfiguration;

namespace SibTestProjectDB
{
    public class Context : DbContext, IUserContext, IMyObjectContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<MyObject> MyObjects { get; set; }

        public Context(DbContextOptions<Context> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new MyObjectConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
