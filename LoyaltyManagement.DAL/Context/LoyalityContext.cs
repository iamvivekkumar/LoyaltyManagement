using LoyaltyManagement.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace LoyaltyManagement.DAL.Context
{
    public class LoyalityContext : DbContext
    {
        public LoyalityContext(DbContextOptions<LoyalityContext> options) : base(options)
        {
            
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["LoyaltyManagement"].ConnectionString);
        //}

        public DbSet<CardDetail> CardDetails { get; set; }
        public DbSet<OrderHistory> OrderHistories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<RedemptionOrderHistory> RedemptionOrderHistories { get; set; }
        public DbSet<RedemptionProduct> RedemptionProducts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserCardDetail> UserCardDetails { get; set; }
        public DbSet<UserPointsDetail> UserPointsDetails { get; set; }



        //add-migration InitialMigration
        //update-database migrationname
        

        //Install-Package Microsoft.EntityFrameworkCore.Tools in API

        //update-database seeddata
    }
}
