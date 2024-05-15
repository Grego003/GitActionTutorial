using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace CoffeeShopApp.Models.DTO
{
    public class ProductDTO
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; } = string.Empty;
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; } = decimal.Zero;
        public string Description { get; set; } = string.Empty;
        [Display(Name = "Product Type")]
        public ProductType ProductType { get; set; } = ProductType.Coffee;
        public string? Image {  get; set; }
        public int Stock { get; set; } = 0;
        public int TotalSold { get; set; } = 0;
        public bool IsSoldOut { get; set; } = false;

        public string FormattedPrice()
        {
            return Price.ToString("CO", new System.Globalization.CultureInfo("id-ID"));
        }

        public ProductDTO() { 
            this.Id = Guid.NewGuid().ToString();
        }
        public ProductDTO(Products product)
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
}
