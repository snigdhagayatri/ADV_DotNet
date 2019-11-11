using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GroceryListManager.Models;

namespace GroceryListManager.Pages.GroceryList_
{
    public class CreateModel : PageModel
    {
        private readonly GroceryListManager.Models.GroceryListManagerContext _context;

        public CreateModel(GroceryListManager.Models.GroceryListManagerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public GroceryList GroceryList { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.GroceryList.Add(GroceryList);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}