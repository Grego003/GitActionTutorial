using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CoffeeShopApp.Data;
using CoffeeShopApp.Repository.IRepository;
using CoffeeShopApp.Identity;
using Microsoft.AspNetCore.Identity;

namespace CoffeeShopApp.Pages.Product
{
    public class DetailsModel : PageModel
    {
        private readonly IProductRepository _productRepo;
        private readonly UserManager<ApplicationUser> _userManager;
        private ApplicationUser? authUser;

        public DetailsModel(IProductRepository productRepo, UserManager<ApplicationUser> userManager)
        {
            _productRepo = productRepo;
            _userManager = userManager;
        }

        public Models.Products Products { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            authUser = await _userManager.GetUserAsync(User);
            if (id == null)
            {
                return NotFound();
            }

            var products = await _productRepo.GetAsync(m => m.Id == id);
            if (products == null)
            {
                return NotFound();
            }
            else
            {
                Products = products;
            }
            return Page();
        }
    }
}
