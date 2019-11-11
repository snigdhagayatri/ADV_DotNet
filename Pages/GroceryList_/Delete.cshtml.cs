using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GroceryListManager.Models;

namespace GroceryListManager.Pages.GroceryList_
{
    public class DeleteModel : PageModel
    {
        private readonly GroceryListManager.Models.GroceryListManagerContext _context;

        public DeleteModel(GroceryListManager.Models.GroceryListManagerContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            GroceryList = await _context.GroceryList.FindAsync(id);

            if (GroceryList != null)
            {
                _context.GroceryList.Remove(GroceryList);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
