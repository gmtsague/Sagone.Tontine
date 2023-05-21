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
    public class CoreBanksController : Controller
    {
        private readonly LabosContext _context;

        public CoreBanksController(LabosContext context)
        {
            _context = context;
        }

        // GET: CoreBanks
        public async Task<IActionResult> Index()
        {
            var labosContext = _context.CoreBanks.Include(c => c.Pays);
            return View(await labosContext.OrderBy(t=>t.Libelle).ToListAsync());
        }

        // GET: CoreBanks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CoreBanks == null)
            {
                return NotFound();
            }

            var coreBank = await _context.CoreBanks
                .Include(c => c.Pays)
                .FirstOrDefaultAsync(m => m.Idbank == id);
            if (coreBank == null)
            {
                return NotFound();
            }

            return PartialView("Details", coreBank);
            //return View(coreBank);
        }

        // GET: CoreBanks/Create
        public IActionResult Create()
        {
            ViewData["PaysId"] = new SelectList(_context.CorePays, "PaysId", "Libelle");
            return PartialView("create");
            //return View();
        }

        // POST: CoreBanks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idbank,PaysId,Libelle,Adresse,Email,Coderib")] CoreBank coreBank)
        {
            if (ModelState.IsValid)
            {
                _context.Add(coreBank);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PaysId"] = new SelectList(_context.CorePays, "PaysId", "Libelle", coreBank.PaysId);
            return View(coreBank);
        }

        // GET: CoreBanks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CoreBanks == null)
            {
                return NotFound();
            }

            var coreBank = await _context.CoreBanks.FindAsync(id);
            if (coreBank == null)
            {
                return NotFound();
            }
            ViewData["PaysId"] = new SelectList(_context.CorePays, "PaysId", "Libelle", coreBank.PaysId);
            return PartialView("Edit", coreBank);
            //return View(coreBank);
        }

        // POST: CoreBanks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idbank,PaysId,Libelle,Adresse,Email,Coderib")] CoreBank coreBank)
        {
            if (id != coreBank.Idbank)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(coreBank);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoreBankExists(coreBank.Idbank))
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
            ViewData["PaysId"] = new SelectList(_context.CorePays, "PaysId", "Libelle", coreBank.PaysId);
            return View(coreBank);
        }

        // GET: CoreBanks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CoreBanks == null)
            {
                return NotFound();
            }

            var coreBank = await _context.CoreBanks
                .Include(c => c.Pays)
                .FirstOrDefaultAsync(m => m.Idbank == id);
            if (coreBank == null)
            {
                return NotFound();
            }

            return PartialView("Delete", coreBank);
            //return View(coreBank);
        }

        // POST: CoreBanks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CoreBanks == null)
            {
                return Problem("Entity set 'LabosContext.CoreBanks'  is null.");
            }
            var coreBank = await _context.CoreBanks.FindAsync(id);
            if (coreBank != null)
            {
                _context.CoreBanks.Remove(coreBank);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CoreBankExists(int id)
        {
            return (_context.CoreBanks?.Any(e => e.Idbank == id)).GetValueOrDefault();
        }
    }
}
