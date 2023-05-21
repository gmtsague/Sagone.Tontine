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
    public class AidesController : Controller
    {
        private readonly LabosContext _context;

        public AidesController(LabosContext context)
        {
            _context = context;
        }

        // GET: Aides
        public async Task<IActionResult> Index()
        {
            var labosContext = _context.Aides.Include(a => a.IdevtsNavigation);
            return View(await labosContext.ToListAsync());
        }

        // GET: Aides/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Aides == null)
            {
                return NotFound();
            }

            var aide = await _context.Aides
                .Include(a => a.IdevtsNavigation)
                .FirstOrDefaultAsync(m => m.Idevts == id);
            if (aide == null)
            {
                return NotFound();
            }

            return View(aide);
        }

        // GET: Aides/Create
        public IActionResult Create()
        {
            ViewData["Idevts"] = new SelectList(_context.Sortiecaisses, "Idevts", "Idevts");
            return View();
        }

        // POST: Aides/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idevts,Libelle,Lieu,Montanttotalevt,Montantroute,Listemandataires")] Aide aide)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aide);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idevts"] = new SelectList(_context.Sortiecaisses, "Idevts", "Idevts", aide.Idevts);
            return View(aide);
        }

        // GET: Aides/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Aides == null)
            {
                return NotFound();
            }

            var aide = await _context.Aides.FindAsync(id);
            if (aide == null)
            {
                return NotFound();
            }
            ViewData["Idevts"] = new SelectList(_context.Sortiecaisses, "Idevts", "Idevts", aide.Idevts);
            return View(aide);
        }

        // POST: Aides/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idevts,Libelle,Lieu,Montanttotalevt,Montantroute,Listemandataires")] Aide aide)
        {
            if (id != aide.Idevts)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aide);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AideExists(aide.Idevts))
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
            ViewData["Idevts"] = new SelectList(_context.Sortiecaisses, "Idevts", "Idevts", aide.Idevts);
            return View(aide);
        }

        // GET: Aides/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Aides == null)
            {
                return NotFound();
            }

            var aide = await _context.Aides
                .Include(a => a.IdevtsNavigation)
                .FirstOrDefaultAsync(m => m.Idevts == id);
            if (aide == null)
            {
                return NotFound();
            }

            return View(aide);
        }

        // POST: Aides/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Aides == null)
            {
                return Problem("Entity set 'LabosContext.Aides'  is null.");
            }
            var aide = await _context.Aides.FindAsync(id);
            if (aide != null)
            {
                _context.Aides.Remove(aide);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AideExists(int id)
        {
            return (_context.Aides?.Any(e => e.Idevts == id)).GetValueOrDefault();
        }
    }
}
