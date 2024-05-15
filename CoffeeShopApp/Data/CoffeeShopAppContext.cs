using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CoffeeShopApp.Models;
using CoffeeShopApp.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace CoffeeShopApp.Data
{
    public class CoffeeShopAppContext : IdentityDbContext<ApplicationUser>
    {
        public CoffeeShopAppContext (DbContextOptions<CoffeeShopAppContext> options)
            : base(options) 
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            Products[] products =
                [
                    new Products
                    {
                        Name = "Espresso",
                        Price = 2.99m,
                        Description = "Strong and flavorful espresso shot",
                        ProductType = ProductType.Coffee,
                        Stock = 50,
                        TotalSold = 100,
                        IsSoldOut = false
                    },
                    new Products
                    {
                        Name = "Latte",
                        Price = 3.99m,
                        Description = "Smooth and creamy latte with steamed milk",
                        ProductType = ProductType.Coffee,
                        Stock = 40,
                        TotalSold = 90,
                        IsSoldOut = false
                    },
                    new Products
                    {
                        Name = "Cappuccino",
                        Price = 3.49m,
                        Description = "Traditional Italian espresso drink with frothy milk",
                        ProductType = ProductType.Coffee,
                        Stock = 30,
                        TotalSold = 80,
                        IsSoldOut = false
                    },
                    new Products
                    {
                        Name = "Mocha",
                        Price = 4.49m,
                        Description = "Rich and indulgent chocolate-flavored espresso drink",
                        ProductType = ProductType.Coffee,
                        Stock = 35,
                        TotalSold = 70,
                        IsSoldOut = false
                    },
                    new Products
                    {
                        Name = "Americano",
                        Price = 3.29m,
                        Description = "A shot of espresso with hot water",
                        ProductType = ProductType.Coffee,
                        Stock = 45,
                        TotalSold = 110,
                        IsSoldOut = false
                    },
                    new Products
                    {
                        Name = "Macchiato",
                        Price = 3.79m,
                        Description = "Espresso with a dollop of frothy milk",
                        ProductType = ProductType.Coffee,
                        Stock = 25,
                        TotalSold = 60,
                        IsSoldOut = false
                    },
                    new Products
                    {
                        Name = "Caramel Macchiato",
                        Price = 4.99m,
                        Description = "Espresso with vanilla syrup, steamed milk, and caramel drizzle",
                        ProductType = ProductType.Coffee,
                        Stock = 20,
                        TotalSold = 50,
                        IsSoldOut = false
                    },
                    new Products
                    {
                        Name = "Iced Coffee",
                        Price = 3.49m,
                        Description = "Chilled coffee served over ice",
                        ProductType = ProductType.Coffee,
                        Stock = 60,
                        TotalSold = 120,
                        IsSoldOut = false
                    },
                    new Products
                    {
                        Name = "Green Tea",
                        Price = 2.49m,
                        Description = "Refreshing green tea",
                        ProductType = ProductType.NonCoffee,
                        Stock = 30,
                        TotalSold = 70,
                        IsSoldOut = false
                    },
                    new Products
                    {
                        Name = "Hot Chocolate",
                        Price = 3.99m,
                        Description = "Rich and creamy hot chocolate",
                        ProductType = ProductType.NonCoffee,
                        Stock = 25,
                        TotalSold = 60,
                        IsSoldOut = false
                    }
                ];

            base.OnModelCreating(builder);
            builder.Entity<Products>().HasData(products);
            InitializeAppRoles(builder);
        }

        private static void InitializeAppRoles(ModelBuilder builder)
        {
            foreach (ApplicationUserRole role in Enum.GetValues(typeof(ApplicationUserRole)))
            {
                string rolename = role.ToString();
                builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = rolename, NormalizedName = rolename.ToUpper() });
            }
        }

        public DbSet<Products> Products { get; set; } = default!;
    }
}
