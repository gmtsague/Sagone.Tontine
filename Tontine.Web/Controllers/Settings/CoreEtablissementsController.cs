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
    public class CoreEtablissementsController : Controller
    {
        private readonly LabosContext _context;

        public CoreEtablissementsController(LabosContext context)
        {
            _context = context;
        }

        // GET: CoreEtablissements
        public async Task<IActionResult> Index()
        {
            var labosContext = _context.CoreEtablissements.Include(c => c.Pays);
            return View(await labosContext.ToListAsync());
        }

        // GET: CoreEtablissements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CoreEtablissements == null)
            {
                return NotFound();
            }

            var coreEtablissement = await _context.CoreEtablissements
                .Include(c => c.Pays)
                .FirstOrDefaultAsync(m => m.Idetab == id);
            if (coreEtablissement == null)
            {
                return NotFound();
            }

            return View(coreEtablissement);
        }

        // GET: CoreEtablissements/Create
        public IActionResult Create()
        {
            ViewData["PaysId"] = new SelectList(_context.CorePays, "PaysId", "PaysId");
            return View();
        }

        // POST: CoreEtablissements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idetab,PaysId,Libelle,Agrement,Dossierfiscale")] CoreEtablissement coreEtablissement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(coreEtablissement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PaysId"] = new SelectList(_context.CorePays, "PaysId", "PaysId", coreEtablissement.PaysId);
            return View(coreEtablissement);
        }

        // GET: CoreEtablissements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CoreEtablissements == null)
            {
                return NotFound();
            }

            var coreEtablissement = await _context.CoreEtablissements.FindAsync(id);
            if (coreEtablissement == null)
            {
                return NotFound();
            }
            ViewData["PaysId"] = new SelectList(_context.CorePays, "PaysId", "PaysId", coreEtablissement.PaysId);
            return View(coreEtablissement);
        }

        // POST: CoreEtablissements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idetab,PaysId,Libelle,Agrement,Dossierfiscale")] CoreEtablissement coreEtablissement)
        {
            if (id != coreEtablissement.Idetab)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(coreEtablissement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoreEtablissementExists(coreEtablissement.Idetab))
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
            ViewData["PaysId"] = new SelectList(_context.CorePays, "PaysId", "PaysId", coreEtablissement.PaysId);
            return View(coreEtablissement);
        }

        // GET: CoreEtablissements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CoreEtablissements == null)
            {
                return NotFound();
            }

            var coreEtablissement = await _context.CoreEtablissements
                .Include(c => c.Pays)
                .FirstOrDefaultAsync(m => m.Idetab == id);
            if (coreEtablissement == null)
            {
                return NotFound();
            }

            return View(coreEtablissement);
        }

        // POST: CoreEtablissements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CoreEtablissements == null)
            {
                return Problem("Entity set 'LabosContext.CoreEtablissements'  is null.");
            }
            var coreEtablissement = await _context.CoreEtablissements.FindAsync(id);
            if (coreEtablissement != null)
            {
                _context.CoreEtablissements.Remove(coreEtablissement);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CoreEtablissementExists(int id)
        {
            return (_context.CoreEtablissements?.Any(e => e.Idetab == id)).GetValueOrDefault();
        }
    }
}
