using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CoffeeShopApp.Data;
using CoffeeShopApp.Models;
using CoffeeShopApp.Models.DTO;
using CoffeeShopApp.Repository.IRepository;
using CoffeeShopApp.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace CoffeeShopApp.Pages.Product
{
    [Authorize(Roles = "admin")]
    public class CreateModel : PageModel
    {
        private readonly IProductRepository _productRepo;
        private readonly UserManager<ApplicationUser> _userManager;
        private ApplicationUser? authUser;

        public CreateModel(IProductRepository productRepo, UserManager<ApplicationUser> userManager)
        {
            _productRepo = productRepo;
            _userManager = userManager;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            authUser = await _userManager.GetUserAsync(User);
            return Page();
        }

        [BindProperty]
        public ProductDTO NewProduct { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _productRepo.Add(new Models.Products(NewProduct));
            try
            {
                await _productRepo.Save();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while saving: {ex.Message}");

                ModelState.AddModelError("", "An error occurred while saving the product.");

                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}
