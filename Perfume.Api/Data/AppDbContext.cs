using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using Perfume.Api.Models;

namespace Perfume.Api.Data
{
    public class AppDbContext:DbContext
    {
       public AppDbContext(DbContextOptions <AppDbContext> options) : base(options)
        {
            
           
            
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasData(new Product { Id = 1,NameEn="Sauvage",NameAr="سوفاج",Description="Fresh spicy",Price = 64.00m,ImageUrl="~/images/sau.jpg"},
                 new Product { Id = 2 , NameEn = "Stronger With You",NameAr = "سترونجر ويذ يو",Description = "Warm sweet",Price = 95.00m,ImageUrl = "~/images/swy.jpg" },
                 new Product {Id = 3 , NameEn = "Blue De Cannel",NameAr = "بلو دي شانيل",Description = "Woody aromatic",Price = 45.00m,ImageUrl = "~/images/channel.jpg" },
                 new Product { Id =4 , NameEn = "Silver Scent", Description = "Citrus fresh",NameAr = "سيلفر سينت",Price = 78.00m,ImageUrl = "~/images/silver.jpg" },
                 new Product { Id = 5, NameEn = "Boss Bottled",NameAr = "بوس",Description = "Nice smell",Price = 33.00m,ImageUrl = "~/images/boss.jpg" }
                );
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }


    }
}
