using CoffeeShopApp.Models.DTO;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeeShopApp.Models
{
    public class Products : ModelBase
    {
        public string Name { get; set; } = string.Empty;
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; } = decimal.Zero;
        public string Description { get; set; } = string.Empty;
        public ProductType ProductType { get; set; } = ProductType.Coffee;

        public string? Image;
        public int Stock { get; set; } = 0;
        public int TotalSold { get; set; } = 0;
        public bool IsSoldOut {  get; set; } = false;

        public Products() {}
        public Products(ProductDTO product)
        {
            this.Id = product.Id;
            this.Name = product.Name;
            this.Price = product.Price;
            this.Description = product.Description;
            this.ProductType = product.ProductType;
            this.Image = product.Image;
            this.Stock = product.Stock;
            this.TotalSold = product.TotalSold;
            this.IsSoldOut = product.IsSoldOut;
        }
    }

    public enum ProductType
    {
        Coffee,
        NonCoffee,
        Pastry,
        Sandwich,
        Other,
    }
}
