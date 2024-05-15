using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CoffeeShopApp.Data;
using CoffeeShopApp.Models;
using Microsoft.AspNetCore.Identity;
using CoffeeShopApp.Identity;
using CoffeeShopApp.Repository.IRepository;
using CoffeeShopApp.Models.DTO;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace CoffeeShopApp.Pages.Products
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly IProductRepository _productRepo;
        private readonly UserManager<ApplicationUser> _userManager;
        private ApplicationUser? authUser;

        public IndexModel(IProductRepository productRepo, UserManager<ApplicationUser> userManager)
        {
            _productRepo = productRepo;
            _userManager = userManager;
        }

        public IEnumerable<ProductDTO> ProductsDTO { get;set; } = default!;
        public async Task OnGetAsync()
        {
            authUser = await _userManager.GetUserAsync(User);
            IEnumerable<Models.Products> products = await _productRepo.GetAllAsync();
            
            ProductsDTO = products.Select(product =>
            {
                return new ProductDTO(product);
            }).ToList();
        }
    }
}
