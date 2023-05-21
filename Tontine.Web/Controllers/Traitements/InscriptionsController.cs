using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tontine.Entities.Models;
using Tontine.Web.Dto;

namespace Tontine.Web.Controllers.Traitements
{
    public class InscriptionsController : Controller
    {
        private readonly LabosContext _context;

        public InscriptionsController(LabosContext context)
        {
            _context = context;
        }

        // GET: Inscriptions
        public async Task<IActionResult> Index()
        {
            var labosContext = _context.Inscriptions.Include(i => i.IdanneeNavigation).Include(i => i.IdantenneNavigation).Include(i => i.IdpersonNavigation).Include(i => i.IdposteNavigation);
            return View(await labosContext.ToListAsync());
        }

        // GET: Inscriptions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Inscriptions == null)
            {
                return NotFound();
            }

            var inscription = await _context.Inscriptions
                .Include(i => i.IdanneeNavigation)
                .Include(i => i.IdantenneNavigation)
                .Include(i => i.IdpersonNavigation)
                .Include(i => i.IdposteNavigation)
                .FirstOrDefaultAsync(m => m.Idinscrit == id);
            if (inscription == null)
            {
                return NotFound();
            }

            //return View(inscription);
            return PartialView("Details", inscription);
        }

        // GET: Inscriptions/Create
        public IActionResult Create()
        {
            ViewData["Idannee"] = new SelectList(_context.CoreAnnees, "Idannee", "Libelle");
            ViewData["Idantenne"] = new SelectList(_context.Antennes, "Idantenne", "Libelle");
            ViewData["Idperson"] = new SelectList(_context.CorePeople, "Idperson", "Nom");
            ViewData["Idposte"] = new SelectList(_context.Postes, "Idposte", "Libelle");
            //return View();
            return PartialView("Create");
        }

        // POST: Inscriptions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idinscrit,Idantenne,Idposte,Idperson,Idannee,Dateinscrit,Datesuspension,Isactive,Nocni,Soldedebut,Soldefin,Tauxcotisation,Totalverse,Cumuldettes,Cumulpenalites,Endette")] InscriptionDto valueDto)
        {
            var modelStateValues = ModelState.Values; // For debugging/checking modelState errors before there are throw;
            var inscription = valueDto.ToEntity();
            if (ModelState.IsValid)
            {
                _context.Add(inscription);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idannee"] = new SelectList(_context.CoreAnnees, "Idannee", "Libelle", inscription.Idannee);
            ViewData["Idantenne"] = new SelectList(_context.Antennes, "Idantenne", "Libelle", inscription.Idantenne);
            ViewData["Idperson"] = new SelectList(_context.CorePeople, "Idperson", "Nom", inscription.Idperson);
            ViewData["Idposte"] = new SelectList(_context.Postes, "Idposte", "Libelle", inscription.Idposte);
            return View(inscription);
        }

        // GET: Inscriptions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Inscriptions == null)
            {
                return NotFound();
            }

            var inscription = await _context.Inscriptions.FindAsync(id);
            if (inscription == null)
            {
                return NotFound();
            }
            ViewData["Idannee"] = new SelectList(_context.CoreAnnees, "Idannee", "Libelle", inscription.Idannee);
            ViewData["Idantenne"] = new SelectList(_context.Antennes, "Idantenne", "Libelle", inscription.Idantenne);
            ViewData["Idperson"] = new SelectList(_context.CorePeople, "Idperson", "Nom", inscription.Idperson);
            ViewData["Idposte"] = new SelectList(_context.Postes, "Idposte", "Libelle", inscription.Idposte);
            //return View(inscription);
            return PartialView("Edit", inscription);
        }

        // POST: Inscriptions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idinscrit,Idantenne,Idposte,Idperson,Idannee,Dateinscrit,Datesuspension,Isactive,Nocni,Soldedebut,Soldefin,Tauxcotisation,Totalverse,Cumuldettes,Cumulpenalites,Endette")] InscriptionDto valueDto)
        {            
            if (id != valueDto.Idinscrit)
            {
                return NotFound();
            }

            var inscription = valueDto.ToEntity();
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inscription);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InscriptionExists(inscription.Idinscrit))
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
            ViewData["Idannee"] = new SelectList(_context.CoreAnnees, "Idannee", "Libelle", inscription.Idannee);
            ViewData["Idantenne"] = new SelectList(_context.Antennes, "Idantenne", "Libelle", inscription.Idantenne);
            ViewData["Idperson"] = new SelectList(_context.CorePeople, "Idperson", "Nom", inscription.Idperson);
            ViewData["Idposte"] = new SelectList(_context.Postes, "Idposte", "Libelle", inscription.Idposte);
            return View(inscription);
        }

        // GET: Inscriptions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Inscriptions == null)
            {
                return NotFound();
            }

            var inscription = await _context.Inscriptions
                .Include(i => i.IdanneeNavigation)
                .Include(i => i.IdantenneNavigation)
                .Include(i => i.IdpersonNavigation)
                .Include(i => i.IdposteNavigation)
                .FirstOrDefaultAsync(m => m.Idinscrit == id);
            if (inscription == null)
            {
                return NotFound();
            }

            //return View(inscription);
            return PartialView("Delete", inscription);
        }

        // POST: Inscriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Inscriptions == null)
            {
                return Problem("Entity set 'LabosContext.Inscriptions'  is null.");
            }
            var inscription = await _context.Inscriptions.FindAsync(id);
            if (inscription != null)
            {
                _context.Inscriptions.Remove(inscription);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InscriptionExists(int id)
        {
          return (_context.Inscriptions?.Any(e => e.Idinscrit == id)).GetValueOrDefault();
        }
    }
}
