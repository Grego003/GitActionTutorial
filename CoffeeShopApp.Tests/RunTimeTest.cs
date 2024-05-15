using CoffeeShopApp.Data;
using CoffeeShopApp.Models;
using CoffeeShopApp.Repository;
using CoffeeShopApp.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xunit;

namespace CoffeeShopApp.Tests
{
    public class RunTimeTest
    {
        [Fact]
        public async Task MinimumRunTime_OfProducts_GetAsync()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<CoffeeShopAppContext>()
                  .UseInMemoryDatabase(databaseName: "TestDatabase")
                  .Options;

            using var context = new CoffeeShopAppContext(options);
            var product = new Products { Id = Guid.NewGuid().ToString(), Name = "Coffee", Price = 3.99m };

            context.Products.Add(product);
            await context.SaveChangesAsync();

            var repository = new ProductRepository(context);

            var stopwatch = Stopwatch.StartNew();

            // Act
            var result = await repository.GetAsync(p => p.Id == product.Id);

            stopwatch.Stop();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(product.Id, result.Id);
            Assert.True(stopwatch.Elapsed < TimeSpan.FromSeconds(1.5), $"Execution took longer than 1.5 second. \n Execution Time {stopwatch.Elapsed} s");
        }
    }
}