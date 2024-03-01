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
              optionsBuilder.UseMySql("Server=localhost;Port=3307;Database=ciauction;Uid=root;Pwd=12345;", ServerVersion.AutoDetect("Server=localhost;Port=3307;Database=ciauction;Uid=root;Pwd=12345;"));
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
    }
}
