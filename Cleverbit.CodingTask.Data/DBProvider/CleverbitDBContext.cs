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
        public DbSet<UserMatch> UserMatch { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().HasKey(m => m.Id);
            
            builder.Entity<User>().HasData(new User { Id= 1, Username = "User1", Password= "123456" });
            builder.Entity<User>().HasData(new User { Id= 2, Username = "User2", Password= "123456" });
            builder.Entity<User>().HasData(new User { Id= 3, Username = "User3", Password= "123456" });
            builder.Entity<User>().HasData(new User { Id= 4, Username = "User4", Password= "123456" });

            builder.Entity<UserMatch>().HasKey(m => new { m.Id});
            builder.Entity<UserMatch>().HasData(new UserMatch { Id = 1, FirstUserId = 1, SecondUserId = 2, FirstUserAccepted = false, SecondUserAccepted = false, MatchExpireSecond=30, FirstUserPoint =0, SecondUserPoint = 0 ,MatchEndDate= DateTime.Now.AddDays(1) });
            builder.Entity<UserMatch>().HasData(new UserMatch { Id = 2, FirstUserId = 3, SecondUserId = 4, FirstUserAccepted = false, SecondUserAccepted = false, MatchExpireSecond = 30, FirstUserPoint = 0, SecondUserPoint = 0, MatchEndDate = DateTime.Now.AddDays(1) });

            base.OnModelCreating(builder);
        }
        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }
    }
}
