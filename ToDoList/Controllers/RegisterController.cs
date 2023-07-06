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
    public class RegisterController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RegisterController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Register
        public async Task<IActionResult> Index()
        {
              return _context.RegisterUsers != null ? 
                          View(await _context.RegisterUsers.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.RegisterUsers'  is null.");
        }

        // GET: Register/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.RegisterUsers == null)
            {
                return NotFound();
            }

            var registerUser = await _context.RegisterUsers
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (registerUser == null)
            {
                return NotFound();
            }

            return View(registerUser);
        }

        // GET: Register/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Register/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,UserName,EmailAddress,Password,ConfirmPassword")] RegisterUser registerUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registerUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(registerUser);
        }

        // GET: Register/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.RegisterUsers == null)
            {
                return NotFound();
            }

            var registerUser = await _context.RegisterUsers.FindAsync(id);
            if (registerUser == null)
            {
                return NotFound();
            }
            return View(registerUser);
        }

        // POST: Register/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,UserName,EmailAddress,Password,ConfirmPassword")] RegisterUser registerUser)
        {
            if (id != registerUser.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registerUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegisterUserExists(registerUser.UserId))
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
            return View(registerUser);
        }

        // GET: Register/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.RegisterUsers == null)
            {
                return NotFound();
            }

            var registerUser = await _context.RegisterUsers
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (registerUser == null)
            {
                return NotFound();
            }

            return View(registerUser);
        }

        // POST: Register/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.RegisterUsers == null)
            {
                return Problem("Entity set 'ApplicationDbContext.RegisterUsers'  is null.");
            }
            var registerUser = await _context.RegisterUsers.FindAsync(id);
            if (registerUser != null)
            {
                _context.RegisterUsers.Remove(registerUser);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegisterUserExists(int id)
        {
          return (_context.RegisterUsers?.Any(e => e.UserId == id)).GetValueOrDefault();
        }
    }
}
