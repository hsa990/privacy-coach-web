using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Privacy_Coach.Data;
using Privacy_Coach.Models;

namespace Privacy_Coach.Controllers
{
    public class PrivacyCoachesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PrivacyCoachesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PrivacyCoaches
        public async Task<IActionResult> Index()
        {
            return View(await _context.PrivacyCoach.ToListAsync());
        }

        // GET: PrivacyCoaches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var privacyCoach = await _context.PrivacyCoach
                .FirstOrDefaultAsync(m => m.Id == id);
            if (privacyCoach == null)
            {
                return NotFound();
            }

            return View(privacyCoach);
        }

        // GET: PrivacyCoaches/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PrivacyCoaches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description")] PrivacyCoach privacyCoach)
        {
            if (ModelState.IsValid)
            {
                _context.Add(privacyCoach);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(privacyCoach);
        }

        // GET: PrivacyCoaches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var privacyCoach = await _context.PrivacyCoach.FindAsync(id);
            if (privacyCoach == null)
            {
                return NotFound();
            }
            return View(privacyCoach);
        }

        // POST: PrivacyCoaches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description")] PrivacyCoach privacyCoach)
        {
            if (id != privacyCoach.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(privacyCoach);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrivacyCoachExists(privacyCoach.Id))
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
            return View(privacyCoach);
        }

        // GET: PrivacyCoaches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var privacyCoach = await _context.PrivacyCoach
                .FirstOrDefaultAsync(m => m.Id == id);
            if (privacyCoach == null)
            {
                return NotFound();
            }

            return View(privacyCoach);
        }

        // POST: PrivacyCoaches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var privacyCoach = await _context.PrivacyCoach.FindAsync(id);
            if (privacyCoach != null)
            {
                _context.PrivacyCoach.Remove(privacyCoach);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrivacyCoachExists(int id)
        {
            return _context.PrivacyCoach.Any(e => e.Id == id);
        }
    }
}
