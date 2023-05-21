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
    public class ModepaiesController : Controller
    {
        private readonly LabosContext _context;

        public ModepaiesController(LabosContext context)
        {
            _context = context;
        }

        // GET: Modepaies
        public async Task<IActionResult> Index()
        {
            return _context.Modepaies != null ?
                        View(await _context.Modepaies.ToListAsync()) :
                        Problem("Entity set 'LabosContext.Modepaies'  is null.");
        }

        // GET: Modepaies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Modepaies == null)
            {
                return NotFound();
            }

            var modepaie = await _context.Modepaies
                .FirstOrDefaultAsync(m => m.Idmode == id);
            if (modepaie == null)
            {
                return NotFound();
            }

            return View(modepaie);
        }

        // GET: Modepaies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Modepaies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idmode,Libelle,Iscash")] Modepaie modepaie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(modepaie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(modepaie);
        }

        // GET: Modepaies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Modepaies == null)
            {
                return NotFound();
            }

            var modepaie = await _context.Modepaies.FindAsync(id);
            if (modepaie == null)
            {
                return NotFound();
            }
            return View(modepaie);
        }

        // POST: Modepaies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idmode,Libelle,Iscash")] Modepaie modepaie)
        {
            if (id != modepaie.Idmode)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(modepaie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModepaieExists(modepaie.Idmode))
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
            return View(modepaie);
        }

        // GET: Modepaies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Modepaies == null)
            {
                return NotFound();
            }

            var modepaie = await _context.Modepaies
                .FirstOrDefaultAsync(m => m.Idmode == id);
            if (modepaie == null)
            {
                return NotFound();
            }

            return View(modepaie);
        }

        // POST: Modepaies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Modepaies == null)
            {
                return Problem("Entity set 'LabosContext.Modepaies'  is null.");
            }
            var modepaie = await _context.Modepaies.FindAsync(id);
            if (modepaie != null)
            {
                _context.Modepaies.Remove(modepaie);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModepaieExists(int id)
        {
            return (_context.Modepaies?.Any(e => e.Idmode == id)).GetValueOrDefault();
        }
    }
}
