﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Core;
using Data;

namespace WorldUjp
{
    public class ListModel : PageModel
    {
        private readonly Data.UjpDbContext _context;

        public int taxPayerId;
        public ListModel(Data.UjpDbContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; }

        public async Task OnGetAsync(int id)
        {
            taxPayerId = id;
            Product = await _context.Products.ToListAsync();
        }
    }
}
