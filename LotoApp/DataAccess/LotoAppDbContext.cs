using DataModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace DataAccess
{
    public class LotoAppDbContext : DbContext
    {
        public LotoAppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Test> Tests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(x => x.Tickets)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);
            modelBuilder.Entity<Ticket>()
                .HasOne(x => x.Session)
                .WithMany(x => x.Tickets)
                .HasForeignKey(x => x.SessionId);
            modelBuilder.Entity<Admin>()
                .HasMany(x => x.Sessions)
                .WithOne(x => x.Admin)
                .HasForeignKey(x => x.AdminId);
            modelBuilder.Entity<Test>();

            var md5 = new MD5CryptoServiceProvider();
            var md5data = md5.ComputeHash(Encoding.ASCII.GetBytes("123Filip"));
            var hashedPassword = Encoding.ASCII.GetString(md5data);
            

            modelBuilder.Entity<Admin>().HasData(
                    new Admin()
                    {
                        Id = 1,
                        FirstName = "Filip",
                        LastName = "Kostadinov",
                        Username = "Fico",
                        Password = hashedPassword
                    }
                );
        }
    }
}
