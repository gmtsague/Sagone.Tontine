using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tontine.Entities.Models;

namespace Tontine.Web.Controllers.Traitements
{
    public class PretsController : Controller
    {
        private readonly LabosContext _context;

        public PretsController(LabosContext context)
        {
            _context = context;
        }

        // GET: Prets
        public async Task<IActionResult> Index()
        {
            var labosContext = _context.Prets.Include(p => p.IdevtsNavigation);
            return View(await labosContext.ToListAsync());
        }

        // GET: Prets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Prets == null)
            {
                return NotFound();
            }

            var pret = await _context.Prets
                .Include(p => p.IdevtsNavigation)
                .FirstOrDefaultAsync(m => m.Idevts == id);
            if (pret == null)
            {
                return NotFound();
            }

            return View(pret);
        }

        // GET: Prets/Create
        public IActionResult Create()
        {
            ViewData["Idevts"] = new SelectList(_context.Sortiecaisses, "Idevts", "Idevts");
            return View();
        }

        // POST: Prets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idevts,Ispret,Dureepret,Montantinteret,Montantpenalite")] Pret pret)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pret);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idevts"] = new SelectList(_context.Sortiecaisses, "Idevts", "Idevts", pret.Idevts);
            return View(pret);
        }

        // GET: Prets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Prets == null)
            {
                return NotFound();
            }

            var pret = await _context.Prets.FindAsync(id);
            if (pret == null)
            {
                return NotFound();
            }
            ViewData["Idevts"] = new SelectList(_context.Sortiecaisses, "Idevts", "Idevts", pret.Idevts);
            return View(pret);
        }

        // POST: Prets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idevts,Ispret,Dureepret,Montantinteret,Montantpenalite")] Pret pret)
        {
            if (id != pret.Idevts)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pret);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PretExists(pret.Idevts))
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
            ViewData["Idevts"] = new SelectList(_context.Sortiecaisses, "Idevts", "Idevts", pret.Idevts);
            return View(pret);
        }

        // GET: Prets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Prets == null)
            {
                return NotFound();
            }

            var pret = await _context.Prets
                .Include(p => p.IdevtsNavigation)
                .FirstOrDefaultAsync(m => m.Idevts == id);
            if (pret == null)
            {
                return NotFound();
            }

            return View(pret);
        }

        // POST: Prets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Prets == null)
            {
                return Problem("Entity set 'LabosContext.Prets'  is null.");
            }
            var pret = await _context.Prets.FindAsync(id);
            if (pret != null)
            {
                _context.Prets.Remove(pret);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PretExists(int id)
        {
            return (_context.Prets?.Any(e => e.Idevts == id)).GetValueOrDefault();
        }
    }
}
