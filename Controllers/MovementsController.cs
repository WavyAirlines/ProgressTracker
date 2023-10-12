using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProgressTracker.Data;
using ProgressTracker.Models;

namespace ProgressTracker.Controllers
{
    public class MovementsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MovementsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Movements
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Movements.Include(m => m.Category);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Movements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Movements == null)
            {
                return NotFound();
            }

            var movement = await _context.Movements
                .Include(m => m.Category)
                .FirstOrDefaultAsync(m => m.MovementId == id);
            if (movement == null)
            {
                return NotFound();
            }

            return View(movement);
        }

        // GET: Movements/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId");
            return View();
        }

        // POST: Movements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MovementId,Name,Reps,CategoryId")] Movement movement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", movement.CategoryId);
            return View(movement);
        }

        // GET: Movements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Movements == null)
            {
                return NotFound();
            }

            var movement = await _context.Movements.FindAsync(id);
            if (movement == null)
            {
                return NotFound();
            }
            ViewData["RPE"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", movement.CategoryId);
            return View(movement);
        }

        // POST: Movements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MovementId,Name,Reps,CategoryId")] Movement movement)
        {
            if (id != movement.MovementId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovementExists(movement.MovementId))
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", movement.CategoryId);
            return View(movement);
        }

        // GET: Movements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Movements == null)
            {
                return NotFound();
            }

            var movement = await _context.Movements
                .Include(m => m.Category)
                .FirstOrDefaultAsync(m => m.MovementId == id);
            if (movement == null)
            {
                return NotFound();
            }

            return View(movement);
        }

        // POST: Movements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Movements == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Movements'  is null.");
            }
            var movement = await _context.Movements.FindAsync(id);
            if (movement != null)
            {
                _context.Movements.Remove(movement);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovementExists(int id)
        {
          return (_context.Movements?.Any(e => e.MovementId == id)).GetValueOrDefault();
        }
    }
}
