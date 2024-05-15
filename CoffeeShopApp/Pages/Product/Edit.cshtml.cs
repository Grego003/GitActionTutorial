using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoffeeShopApp.Data;
using CoffeeShopApp.Models;
using CoffeeShopApp.Identity;
using CoffeeShopApp.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using CoffeeShopApp.Models.DTO;
using Microsoft.AspNetCore.Authorization;

namespace CoffeeShopApp.Pages.Product
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly IProductRepository _productRepo;
        private readonly UserManager<ApplicationUser> _userManager;
        private ApplicationUser? authUser;

        public EditModel(IProductRepository productRepository, UserManager<ApplicationUser> userManager)
        {
            _productRepo = productRepository;
            _userManager = userManager;
        }

        [BindProperty]
        public ProductDTO CurrentProductDTO { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            authUser = await _userManager.GetUserAsync(User);

            if (id == null)
            {
                return NotFound();
            }

            var product = await _productRepo.GetAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            CurrentProductDTO = new ProductDTO(product);
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _productRepo.Update(new Models.Products(CurrentProductDTO));

            try
            {
                await _productRepo.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ProductsExists(CurrentProductDTO.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private async Task<bool> ProductsExists(string id)
        {
            var getProduct = await _productRepo.GetAsync(m => m.Id == id);
            if (getProduct == null)
            {
                return false;
            }
            return true;
        }
    }
}
