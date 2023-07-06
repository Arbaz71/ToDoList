using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using To_Do_List.Data;
using To_Do_List.Models;

namespace ToDoList.Controllers
{
    public class ToDoItemListController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ToDoItemListController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ToDoItemList
        public async Task<IActionResult> Index()
        {
              return _context.ToDoItemList != null ? 
                          View(await _context.ToDoItemList.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.ToDoItemList'  is null.");
        }

        // GET: ToDoItemList/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ToDoItemList == null)
            {
                return NotFound();
            }

            var toDoItem = await _context.ToDoItemList
                .FirstOrDefaultAsync(m => m.ToDoItemId == id);
            if (toDoItem == null)
            {
                return NotFound();
            }

            return View(toDoItem);
        }

        // GET: ToDoItemList/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ToDoItemList/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ToDoItemId,Title,Description,Priority,Date,IsComplete,AddNotes")] ToDoItem toDoItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(toDoItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(toDoItem);
        }

        // GET: ToDoItemList/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ToDoItemList == null)
            {
                return NotFound();
            }

            var toDoItem = await _context.ToDoItemList.FindAsync(id);
            if (toDoItem == null)
            {
                return NotFound();
            }
            return View(toDoItem);
        }

        // POST: ToDoItemList/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ToDoItemId,Title,Description,Priority,Date,IsComplete,AddNotes")] ToDoItem toDoItem)
        {
            if (id != toDoItem.ToDoItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(toDoItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ToDoItemExists(toDoItem.ToDoItemId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(toDoItem);
        }

        // GET: ToDoItemList/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ToDoItemList == null)
            {
                return NotFound();
            }

            var toDoItem = await _context.ToDoItemList
                .FirstOrDefaultAsync(m => m.ToDoItemId == id);
            if (toDoItem == null)
            {
                return NotFound();
            }

            return View(toDoItem);
        }

        // POST: ToDoItemList/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ToDoItemList == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ToDoItemList'  is null.");
            }
            var toDoItem = await _context.ToDoItemList.FindAsync(id);
            if (toDoItem != null)
            {
                _context.ToDoItemList.Remove(toDoItem);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ToDoItemExists(int id)
        {
          return (_context.ToDoItemList?.Any(e => e.ToDoItemId == id)).GetValueOrDefault();
        }
    }
}
