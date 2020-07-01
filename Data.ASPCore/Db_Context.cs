using Entities.ASPCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.ASPCore
{
    public class Db_Context: DbContext
    {
        private string ConnectionString { get; set; }
        public Db_Context()
        {
            var config = new ConfigurationBuilder()
                        .AddJsonFile("appsettings.json")
                        .Build();
            ConnectionString = config["ConnectionStrings:WupziDB"];
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
        public DbSet<User> User { get; set; }
        public DbSet<ReferredInvite> ReferredInvite { get; set; }
        public DbSet<ReferredUser> ReferredUser { get; set; }
        public DbSet<UserAccountPayments> UserAccountPayments { get; set; }
        public DbSet<FriendRelashionship> FriendRelashionship { get; set; }
        public DbSet<InvitedFriendData> InvitedFriendData { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User_Stats>()
                .HasKey(c => new { c.UserId, c.StatsId });
        }
    } 
}
