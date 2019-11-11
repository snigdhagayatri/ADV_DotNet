using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GroceryListManager.Models;

namespace GroceryListManager.Pages.GroceryList_
{
    public class EditModel : PageModel
    {
        private readonly GroceryListManager.Models.GroceryListManagerContext _context;

        public EditModel(GroceryListManager.Models.GroceryListManagerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public GroceryList GroceryList { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            GroceryList = await _context.GroceryList.FirstOrDefaultAsync(m => m.Id == id);

            if (GroceryList == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(GroceryList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroceryListExists(GroceryList.Id))
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

        private bool GroceryListExists(int id)
        {
            return _context.GroceryList.Any(e => e.Id == id);
        }
    }
}
