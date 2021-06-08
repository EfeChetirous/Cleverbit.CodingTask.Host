using Cleverbit.CodingTask.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cleverbit.CodingTask.Data.DBProvider
{
    public class CleverbitDBContext : DbContext
    {
        public CleverbitDBContext(DbContextOptions<CleverbitDBContext> options) : base(options)
        { }

        public DbSet<User> User { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().HasKey(m => m.Id);
            builder.Entity<User>().HasData(new User { Id= 1, Username = "User1", Password= "123456" });
            builder.Entity<User>().HasData(new User { Id= 2, Username = "User2", Password= "123456" });
            builder.Entity<User>().HasData(new User { Id= 3, Username = "User3", Password= "123456" });
            builder.Entity<User>().HasData(new User { Id= 4, Username = "User4", Password= "123456" });

            base.OnModelCreating(builder);
        }
        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }
    }
}
