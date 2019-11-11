using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GroceryListManager.Models;

namespace GroceryListManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroceryListsController : ControllerBase
    {
        private readonly GroceryListManagerContext _context;

        public GroceryListsController(GroceryListManagerContext context)
        {
            _context = context;
        }

        // GET: api/GroceryLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroceryList>>> GetGroceryList()
        {
            return await _context.GroceryList.ToListAsync();
        }

        // GET: api/GroceryLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GroceryList>> GetGroceryList(int id)
        {
            var groceryList = await _context.GroceryList.FindAsync(id);

            if (groceryList == null)
            {
                return NotFound();
            }

            return groceryList;
        }

        // PUT: api/GroceryLists/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroceryList(int id, GroceryList groceryList)
        {
            if (id != groceryList.Id)
            {
                return BadRequest();
            }

            _context.Entry(groceryList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroceryListExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/GroceryLists
        [HttpPost]
        public async Task<ActionResult<GroceryList>> PostGroceryList(GroceryList groceryList)
        {
            _context.GroceryList.Add(groceryList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGroceryList", new { id = groceryList.Id }, groceryList);
        }

        // DELETE: api/GroceryLists/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GroceryList>> DeleteGroceryList(int id)
        {
            var groceryList = await _context.GroceryList.FindAsync(id);
            if (groceryList == null)
            {
                return NotFound();
            }

            _context.GroceryList.Remove(groceryList);
            await _context.SaveChangesAsync();

            return groceryList;
        }

        private bool GroceryListExists(int id)
        {
            return _context.GroceryList.Any(e => e.Id == id);
        }

        [HttpPut("loan/{id}")]
        public ActionResult<GroceryList> LoanBook([FromRoute]int id, [FromBody] GroceryList loan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var list = _context.GroceryList.Find(id);
            if (list == null)
            {
                return BadRequest();
            }
            list.PurchasedDate = DateTime.Now;
            
            _context.SaveChanges();
            return Ok(list);
        }
    }
}
