using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Core;
using Data;
using Data.Interface;

namespace WorldUjp
{
    public class BuyModel : PageModel
    {
        private readonly Data.UjpDbContext _context;
        
        public BuyModel(Data.UjpDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Product Product { get; set; }
        public TaxPayer TaxPayer { get; set; }

        public async Task<IActionResult> OnGetAsync(int id,int taxpay)
        {
            if (id == null)
            {
                return NotFound();
            }

            TaxPayer = await _context.TaxPayers.FirstOrDefaultAsync(m => m.Id == taxpay);
            Product = await _context.Products.FirstOrDefaultAsync(m => m.Id == id);
            TaxPayer.Products.Add(Product);
            return Redirect("/TaxPayer/Index");
            /* 

             if (Product == null)
             {
                 return NotFound();

             return Page();*/
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(Product.Id))
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

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
