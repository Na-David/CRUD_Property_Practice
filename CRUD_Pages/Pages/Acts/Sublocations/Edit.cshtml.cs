﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUD_Pages.Data;
using CRUD_Pages.Models;

namespace CRUD_Pages.Pages.Acts.Sublocations
{
    public class EditModel : PageModel
    {
        private readonly CRUD_Pages.Data.ApplicationDbContext _context;

        public EditModel(CRUD_Pages.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Sublocation Sublocation { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Sublocations == null)
            {
                return NotFound();
            }

            var sublocation =  await _context.Sublocations.FirstOrDefaultAsync(m => m.Id == id);
            if (sublocation == null)
            {
                return NotFound();
            }
            Sublocation = sublocation;
           ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Id");
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

            _context.Attach(Sublocation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SublocationExists(Sublocation.Id))
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

        private bool SublocationExists(int id)
        {
          return (_context.Sublocations?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
