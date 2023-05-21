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
    public class PresencesController : Controller
    {
        private readonly LabosContext _context;

        public PresencesController(LabosContext context)
        {
            _context = context;
        }

        // GET: Presences
        public async Task<IActionResult> Index()
        {
            var labosContext = _context.Presences.Include(p => p.Id).Include(p => p.IdcompteNavigation).Include(p => p.IdinscritNavigation).ThenInclude(sb=>sb.IdpersonNavigation).Include(p => p.IdmodeNavigation);
            return View(await labosContext.ToListAsync());
        }

        // GET: Presences/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Presences == null)
            {
                return NotFound();
            }

            var presence = await _context.Presences
                .Include(p => p.Id)
                .Include(p => p.IdcompteNavigation)
                .Include(p => p.IdinscritNavigation)
                .Include(p => p.IdmodeNavigation)
                .FirstOrDefaultAsync(m => m.Idpresence == id);
            if (presence == null)
            {
                return NotFound();
            }

            return View(presence);
        }

        // GET: Presences/Create
        public IActionResult Create()
        {
            //ViewData["Idannee"] = new SelectList(_context.Monthlyseances, "Idannee", "Idannee"); // original code
            ViewData["Idannee"] = new SelectList(_context.Monthlyseances, "Iddivision", "Libelle");
            ViewData["Idcompte"] = new SelectList(_context.CoreBankaccounts, "Idcompte", "Libelle");
            ViewData["Idinscrit"] = new SelectList(_context.Inscriptions.Include(m=>m.IdpersonNavigation), "Idinscrit", /*"Idinscrit"*/ "IdpersonNavigation.Nom");
            ViewData["Idmode"] = new SelectList(_context.Modepaies, "Idmode", "libelle");
            return View();
        }

        // POST: Presences/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idpresence,Idannee,Iddivision,Idinscrit,Idcompte,Idmode,Dateop,Isabsent,Globalverse,Soldedebut,Soldefin,Cumuldetteapres,Codeop,Numbordero")] Presence presence)
        {
            if (ModelState.IsValid)
            {
                _context.Add(presence);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idannee"] = new SelectList(_context.Monthlyseances, "Idannee", "Idannee", presence.Idannee);
            ViewData["Idcompte"] = new SelectList(_context.CoreBankaccounts, "Idcompte", "Idcompte", presence.Idcompte);
            ViewData["Idinscrit"] = new SelectList(_context.Inscriptions, "Idinscrit", "Idinscrit", presence.Idinscrit);
            ViewData["Idmode"] = new SelectList(_context.Modepaies, "Idmode", "Idmode", presence.Idmode);
            return View(presence);
        }

        // GET: Presences/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Presences == null)
            {
                return NotFound();
            }

            var presence = await _context.Presences.FindAsync(id);
            if (presence == null)
            {
                return NotFound();
            }
            ViewData["Idannee"] = new SelectList(_context.Monthlyseances, "Idannee", "Idannee", presence.Idannee);
            ViewData["Idcompte"] = new SelectList(_context.CoreBankaccounts, "Idcompte", "Idcompte", presence.Idcompte);
            ViewData["Idinscrit"] = new SelectList(_context.Inscriptions, "Idinscrit", "Idinscrit", presence.Idinscrit);
            ViewData["Idmode"] = new SelectList(_context.Modepaies, "Idmode", "Idmode", presence.Idmode);
            return View(presence);
        }

        // POST: Presences/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idpresence,Idannee,Iddivision,Idinscrit,Idcompte,Idmode,Dateop,Isabsent,Globalverse,Soldedebut,Soldefin,Cumuldetteapres,Codeop,Numbordero")] Presence presence)
        {
            if (id != presence.Idpresence)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(presence);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PresenceExists(presence.Idpresence))
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
            ViewData["Idannee"] = new SelectList(_context.Monthlyseances, "Idannee", "Idannee", presence.Idannee);
            ViewData["Idcompte"] = new SelectList(_context.CoreBankaccounts, "Idcompte", "Idcompte", presence.Idcompte);
            ViewData["Idinscrit"] = new SelectList(_context.Inscriptions, "Idinscrit", "Idinscrit", presence.Idinscrit);
            ViewData["Idmode"] = new SelectList(_context.Modepaies, "Idmode", "Idmode", presence.Idmode);
            return View(presence);
        }

        // GET: Presences/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Presences == null)
            {
                return NotFound();
            }

            var presence = await _context.Presences
                .Include(p => p.Id)
                .Include(p => p.IdcompteNavigation)
                .Include(p => p.IdinscritNavigation)
                .Include(p => p.IdmodeNavigation)
                .FirstOrDefaultAsync(m => m.Idpresence == id);
            if (presence == null)
            {
                return NotFound();
            }

            return View(presence);
        }

        // POST: Presences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Presences == null)
            {
                return Problem("Entity set 'LabosContext.Presences'  is null.");
            }
            var presence = await _context.Presences.FindAsync(id);
            if (presence != null)
            {
                _context.Presences.Remove(presence);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PresenceExists(int id)
        {
          return (_context.Presences?.Any(e => e.Idpresence == id)).GetValueOrDefault();
        }
    }
}
