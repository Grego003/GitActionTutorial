using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CoffeeShopApp.Data;
using CoffeeShopApp.Models;

namespace CoffeeShopApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly CoffeeShopAppContext _context;

        public IndexModel(CoffeeShopAppContext context)
        {
            _context = context;
        }

        public IList<Models.Products> Products { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Products = await _context.Products.ToListAsync();
        }
    }
}
