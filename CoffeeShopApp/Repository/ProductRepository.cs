using CoffeeShopApp.Data;
using CoffeeShopApp.Models;
using CoffeeShopApp.Models.DTO;
using CoffeeShopApp.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShopApp.Repository
{
    public class ProductRepository : Repository<Products>, IProductRepository
    {
        private readonly CoffeeShopAppContext _context;
        public ProductRepository(CoffeeShopAppContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Products product)
        {
            _context.Products.Update(product);
        }
    }
}
