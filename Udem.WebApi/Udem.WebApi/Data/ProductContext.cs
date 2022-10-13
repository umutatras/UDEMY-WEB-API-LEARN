using Microsoft.EntityFrameworkCore;
using System;

namespace Udem.WebApi.Data
{
    public class ProductContext:DbContext
    {
        public ProductContext(DbContextOptions<ProductContext>options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(new Category[]
            {
                new()
                {
                    Name="Teknoloji",
                    Id=1
                },
                new()
                {
                    Id=2,
                    Name="Giyim"
                }
            });
            modelBuilder.Entity<Product>().Property(x => x.Price).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Product>().HasData(new Product[]
            {
                new()
                {
                    Id = 1,
                    Name ="Telefon",
                    CreatedDate=DateTime.Now.AddDays(-1),
                    Price=10000,
                    Stock=20,
                     CategoryId=1

                },
                 new()
                {
                    Id = 2,
                    Name ="Bilgisayar",
                    CreatedDate=DateTime.Now.AddDays(-3),
                    Price=20000,
                    Stock=20,
                    CategoryId=1
                    
                },
                 new()
                {
                    Id = 3,
                    Name ="Buzdolabı",
                    CreatedDate=DateTime.Now.AddDays(-2),
                    Price=25000,
                    Stock=20,
                     CategoryId=1

                }
            });

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
