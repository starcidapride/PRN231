using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BussinessObjects
{
    public class CiAuctionContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseMySql("Server=localhost;Port=3307;Database=ciauction;Uid=root;Pwd=12345;", ServerVersion.AutoDetect("Server=localhost;Port=3307;Database=ciauction;Uid=root;Pwd=12345;"));
            optionsBuilder.UseMySql(GetConnectionString(), ServerVersion.AutoDetect(GetConnectionString()));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Orchid>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orchids)
                .HasForeignKey(o => o.UserId);

            modelBuilder.Entity<DepositRequest>()
                .HasOne(o => o.User)
                .WithMany(u => u.DepositRequests)
                .HasForeignKey(o => o.UserId);

            modelBuilder.Entity<DepositRequest>()
               .HasOne(o => o.Orchid)
               .WithMany(u => u.DepositRequests)
               .HasForeignKey(o => o.OrchidId);
        }

        private string GetConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();
            var strConn = config.GetConnectionString("CiAuctionDb");
            return strConn;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Orchid> Orchids { get; set; }
        public DbSet<DepositRequest> DepositRequests { get; set; }  
    }
}
