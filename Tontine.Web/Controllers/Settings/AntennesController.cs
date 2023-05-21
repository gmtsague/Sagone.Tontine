using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tontine.Entities.Models;

namespace Tontine.Web.Controllers.Settings
{
    public class AntennesController : Controller
    {
        private readonly LabosContext _context;

        public AntennesController(LabosContext context)
        {
            _context = context;
        }

        // GET: Antennes
        public async Task<IActionResult> Index()
        {
            return _context.Antennes != null ?
                        View(await _context.Antennes.ToListAsync()) :
                        Problem("Entity set 'LabosContext.Antennes'  is null.");
        }

        // GET: Antennes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Antennes == null)
            {
                return NotFound();
            }

            var antenne = await _context.Antennes
                .FirstOrDefaultAsync(m => m.Idantenne == id);
            if (antenne == null)
            {
                return NotFound();
            }

            return View(antenne);
        }

        // GET: Antennes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Antennes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idantenne,Libelle,Creationdate")] Antenne antenne)
        {
            if (ModelState.IsValid)
            {
                _context.Add(antenne);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(antenne);
        }

        // GET: Antennes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Antennes == null)
            {
                return NotFound();
            }

            var antenne = await _context.Antennes.FindAsync(id);
            if (antenne == null)
            {
                return NotFound();
            }
            return View(antenne);
        }

        // POST: Antennes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idantenne,Libelle,Creationdate")] Antenne antenne)
        {
            if (id != antenne.Idantenne)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(antenne);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AntenneExists(antenne.Idantenne))
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
            return View(antenne);
        }

        // GET: Antennes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Antennes == null)
            {
                return NotFound();
            }

            var antenne = await _context.Antennes
                .FirstOrDefaultAsync(m => m.Idantenne == id);
            if (antenne == null)
            {
                return NotFound();
            }

            return View(antenne);
        }

        // POST: Antennes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Antennes == null)
            {
                return Problem("Entity set 'LabosContext.Antennes'  is null.");
            }
            var antenne = await _context.Antennes.FindAsync(id);
            if (antenne != null)
            {
                _context.Antennes.Remove(antenne);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AntenneExists(int id)
        {
            return (_context.Antennes?.Any(e => e.Idantenne == id)).GetValueOrDefault();
        }
    }
}
