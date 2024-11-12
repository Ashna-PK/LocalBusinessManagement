using Microsoft.EntityFrameworkCore;
using Seller.Api.Models;

namespace Seller.Api.Data
{
    public class SellerDbContext : DbContext
    {
        public SellerDbContext(DbContextOptions options) : base(options)
        {
        }
       public DbSet<SellerClass> sellers {  get; set; }
       public DbSet<Shop> shops { get; set; }   

    }
}
