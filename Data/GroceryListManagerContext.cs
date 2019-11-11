using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GroceryListManager.Models
{
    public class GroceryListManagerContext : DbContext
    {
        public GroceryListManagerContext(DbContextOptions<GroceryListManagerContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GroceryList>().HasData(
                          new GroceryList
                          {
                              Id = 1,
                              Name = "Cereal",
                              Price = "10$",
                              PurchasedDate = DateTime.Today,
                          });
            modelBuilder.Entity<GroceryList>().HasData(
                           new GroceryList
                           {
                               Id = 2,
                               Name = "Eggs",
                               Price = "6$",
                               PurchasedDate = DateTime.Today,
                           });
            modelBuilder.Entity<GroceryList>().HasData(
                           new GroceryList
                           {
                               Id = 3,
                               Name = "Apples",
                               Price = "9$",
                               PurchasedDate = DateTime.Today,
                           });
            modelBuilder.Entity<GroceryList>().HasData(
                           new GroceryList
                           {
                               Id = 4,
                               Name = "Milk",
                               Price = "9$",
                               PurchasedDate = DateTime.Today,
                           });
            modelBuilder.Entity<GroceryList>().HasData(
                           new GroceryList
                           {
                               Id = 5,
                               Name = "Yogurt",
                               Price = "8$",
                               PurchasedDate = DateTime.Today,
                           });

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<GroceryListManager.Models.GroceryList> GroceryList { get; set; }
    }
}
