using CoffeeShopApp.Models;
using CoffeeShopApp.Models.DTO;

namespace CoffeeShopApp.Repository.IRepository
{
    public interface IProductRepository : IRepository<Products>
    {
        void Update(Products product);

    }
}
