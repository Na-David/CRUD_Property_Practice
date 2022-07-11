using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CRUD_Pages.Data;
using CRUD_Pages.Models;

namespace CRUD_Pages.Pages.Acts.Sublocations
{
    public class CreateModel : PageModel
    {
        private readonly CRUD_Pages.Data.ApplicationDbContext _context;

        public CreateModel(CRUD_Pages.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Sublocation Sublocation { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Sublocations == null || Sublocation == null)
            {
                return Page();
            }

            _context.Sublocations.Add(Sublocation);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
