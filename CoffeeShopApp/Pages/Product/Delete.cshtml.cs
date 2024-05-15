using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CoffeeShopApp.Data;
using CoffeeShopApp.Models;
using CoffeeShopApp.Identity;
using CoffeeShopApp.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace CoffeeShopApp.Pages.Product
{
    [Authorize(Roles = "admin")]
    public class DeleteModel : PageModel
    {
        private readonly IProductRepository _productRepo;
        private readonly UserManager<ApplicationUser> _userManager;
        private ApplicationUser? authUser;

        public DeleteModel(IProductRepository productRepo, UserManager<ApplicationUser> userManager)
        {
            _productRepo = productRepo;
            _userManager = userManager;
        }

        [BindProperty]
        public Models.Products Product { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
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
                Product = products;
                
                _productRepo.Remove(Product);

                try
                {
                    await _productRepo.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await ProductsExists(Product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return RedirectToPage("Index");
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

        //public async Task<IActionResult> OnPostAsync(string id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var products = await _context.Products.FindAsync(id);
        //    if (products != null)
        //    {
        //        Products = products;
        //        _context.Products.Remove(Products);
        //        await _context.SaveChangesAsync();
        //    }

        //    return RedirectToPage("./Index");
        //}
    }
}
