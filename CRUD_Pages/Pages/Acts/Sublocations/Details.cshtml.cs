using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CRUD_Pages.Data;
using CRUD_Pages.Models;

namespace CRUD_Pages.Pages.Acts.Sublocations
{
    public class DetailsModel : PageModel
    {
        private readonly CRUD_Pages.Data.ApplicationDbContext _context;

        public DetailsModel(CRUD_Pages.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Sublocation Sublocation { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Sublocations == null)
            {
                return NotFound();
            }

            var sublocation = await _context.Sublocations.FirstOrDefaultAsync(m => m.Id == id);
            if (sublocation == null)
            {
                return NotFound();
            }
            else 
            {
                Sublocation = sublocation;
            }
            return Page();
        }
    }
}
