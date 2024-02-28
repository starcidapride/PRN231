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
              optionsBuilder.UseSqlServer("Server=localhost,1435;Database=CiAuction;User Id=sa;Password=Cuong123_A;TrustServerCertificate=true");
        }

        public DbSet<User> Users { get; set; }
    }
}
