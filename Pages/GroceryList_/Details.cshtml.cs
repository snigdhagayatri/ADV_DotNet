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
    public class DetailsModel : PageModel
    {
        private readonly GroceryListManager.Models.GroceryListManagerContext _context;

        public DetailsModel(GroceryListManager.Models.GroceryListManagerContext context)
        {
            _context = context;
        }

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
    }
}
