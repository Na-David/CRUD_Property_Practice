﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CRUD_Pages.Data;
using CRUD_Pages.Models;

namespace CRUD_Pages.Pages.Acts.Locations
{
    public class IndexModel : PageModel
    {
        private readonly CRUD_Pages.Data.ApplicationDbContext _context;

        public IndexModel(CRUD_Pages.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Location> Location { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Locations != null)
            {
                Location = await _context.Locations
                .Include(l => l.PropertyRef).ToListAsync();
            }
        }
    }
}
