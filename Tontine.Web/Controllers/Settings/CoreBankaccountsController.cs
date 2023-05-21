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
    public class CoreBankaccountsController : Controller
    {
        private readonly LabosContext _context;

        public CoreBankaccountsController(LabosContext context)
        {
            _context = context;
        }

        // GET: CoreBankaccounts
        public async Task<IActionResult> Index()
        {
            var labosContext = _context.CoreBankaccounts.Include(c => c.IdbankNavigation).Include(c => c.IdetabNavigation).Include(c => c.IdpersonNavigation);
            return View(await labosContext.ToListAsync());
        }

        // GET: CoreBankaccounts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CoreBankaccounts == null)
            {
                return NotFound();
            }

            var coreBankaccount = await _context.CoreBankaccounts
                .Include(c => c.IdbankNavigation)
                .Include(c => c.IdetabNavigation)
                .Include(c => c.IdpersonNavigation)
                .FirstOrDefaultAsync(m => m.Idcompte == id);
            if (coreBankaccount == null)
            {
                return NotFound();
            }

            return View(coreBankaccount);
        }

        // GET: CoreBankaccounts/Create
        public IActionResult Create()
        {
            ViewData["Idbank"] = new SelectList(_context.CoreBanks, "Idbank", "Idbank");
            ViewData["Idetab"] = new SelectList(_context.CoreEtablissements, "Idetab", "Idetab");
            ViewData["Idperson"] = new SelectList(_context.CorePeople, "Idperson", "Idperson");
            return View();
        }

        // POST: CoreBankaccounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idcompte,Idetab,Idperson,Idbank,Numcompte,Isactive,Solde")] CoreBankaccount coreBankaccount)
        {
            if (ModelState.IsValid)
            {
                _context.Add(coreBankaccount);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idbank"] = new SelectList(_context.CoreBanks, "Idbank", "Idbank", coreBankaccount.Idbank);
            ViewData["Idetab"] = new SelectList(_context.CoreEtablissements, "Idetab", "Idetab", coreBankaccount.Idetab);
            ViewData["Idperson"] = new SelectList(_context.CorePeople, "Idperson", "Idperson", coreBankaccount.Idperson);
            return View(coreBankaccount);
        }

        // GET: CoreBankaccounts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CoreBankaccounts == null)
            {
                return NotFound();
            }

            var coreBankaccount = await _context.CoreBankaccounts.FindAsync(id);
            if (coreBankaccount == null)
            {
                return NotFound();
            }
            ViewData["Idbank"] = new SelectList(_context.CoreBanks, "Idbank", "Idbank", coreBankaccount.Idbank);
            ViewData["Idetab"] = new SelectList(_context.CoreEtablissements, "Idetab", "Idetab", coreBankaccount.Idetab);
            ViewData["Idperson"] = new SelectList(_context.CorePeople, "Idperson", "Idperson", coreBankaccount.Idperson);
            return View(coreBankaccount);
        }

        // POST: CoreBankaccounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idcompte,Idetab,Idperson,Idbank,Numcompte,Isactive,Solde")] CoreBankaccount coreBankaccount)
        {
            if (id != coreBankaccount.Idcompte)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(coreBankaccount);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoreBankaccountExists(coreBankaccount.Idcompte))
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
            ViewData["Idbank"] = new SelectList(_context.CoreBanks, "Idbank", "Idbank", coreBankaccount.Idbank);
            ViewData["Idetab"] = new SelectList(_context.CoreEtablissements, "Idetab", "Idetab", coreBankaccount.Idetab);
            ViewData["Idperson"] = new SelectList(_context.CorePeople, "Idperson", "Idperson", coreBankaccount.Idperson);
            return View(coreBankaccount);
        }

        // GET: CoreBankaccounts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CoreBankaccounts == null)
            {
                return NotFound();
            }

            var coreBankaccount = await _context.CoreBankaccounts
                .Include(c => c.IdbankNavigation)
                .Include(c => c.IdetabNavigation)
                .Include(c => c.IdpersonNavigation)
                .FirstOrDefaultAsync(m => m.Idcompte == id);
            if (coreBankaccount == null)
            {
                return NotFound();
            }

            return View(coreBankaccount);
        }

        // POST: CoreBankaccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CoreBankaccounts == null)
            {
                return Problem("Entity set 'LabosContext.CoreBankaccounts'  is null.");
            }
            var coreBankaccount = await _context.CoreBankaccounts.FindAsync(id);
            if (coreBankaccount != null)
            {
                _context.CoreBankaccounts.Remove(coreBankaccount);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CoreBankaccountExists(int id)
        {
            return (_context.CoreBankaccounts?.Any(e => e.Idcompte == id)).GetValueOrDefault();
        }
    }
}
