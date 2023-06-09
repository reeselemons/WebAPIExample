﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using WebAPIExample.Business.DataModels;

namespace WebAPIExample.Data
{
    public class DataContext : DbContext
    {
        private string connectionString;
        public DataContext(string connectionString)
        {
            this.connectionString = connectionString;   
        }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Product> BidCurrencies { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.ConfigureWarnings(w => w.Ignore(CoreEventId.LazyLoadOnDisposedContextWarning));

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Set a default name for any product that the name propeprty was null for.
            modelBuilder.Entity<Product>()
                .Property(b => b.Name)
            .HasDefaultValue("No Name");
            //Let's assume there will be a large array of products. Our users will search by their name, the index will help speed the query load time.
            modelBuilder.Entity<Product>().HasIndex(p => p.Name);
            //Sample seed data.
            modelBuilder.Entity<Product>().OwnsOne(p => p.Name).HasData(
                new { ProductId = Guid.NewGuid(), Name = "Shoelace", Description = "This is for your shoes", Price = 1.12 },
                new { ProductId = Guid.NewGuid(), Name = "Tie", Description = "Wear this on your interviews", Price = 15.45 });
        }
    }
}
