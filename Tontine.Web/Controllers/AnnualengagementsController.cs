using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tontine.Entities.Models;

namespace Tontine.Web.Controllers
{
    public class AnnualengagementsController : Controller
    {
        private readonly LabosContext _context;

        public AnnualengagementsController(LabosContext context)
        {
            _context = context;
        }

        // GET: Annualengagements
        public async Task<IActionResult> Index()
        {
            var labosContext = _context.Annualengagements.Include(a => a.IdanneeNavigation).Include(a => a.IdtypeNavigation);
            return View(await labosContext.ToListAsync());
        }

        // GET: Annualengagements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Annualengagements == null)
            {
                return NotFound();
            }

            var annualengagement = await _context.Annualengagements
                .Include(a => a.IdanneeNavigation)
                .Include(a => a.IdtypeNavigation)
                .FirstOrDefaultAsync(m => m.Idconfig == id);
            if (annualengagement == null)
            {
                return NotFound();
            }

            return PartialView("Details", annualengagement);

            //return View(annualengagement);
        }

        // GET: Annualengagements/Create
        public IActionResult Create()
        {
            ViewData["Idannee"] = new SelectList(_context.CoreAnnees, "Idannee", "Libelle");
            ViewData["Idtype"] = new SelectList(_context.Rubriques, "Idtype", "Libelle");
            //return View();
            return PartialView("Create");
        }

        // POST: Annualengagements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idconfig,Idannee,Idtype,Montantevt,Isactive,Nbmandataire,Montantroute,Montanttotal,Montantpenalite,Interetmensuel,Tauxpenalite,Isaide,Iscotisation,Isdepense,Isfondentraide,Ispret,Commentaire,Categorie")] Annualengagement annualengagement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(annualengagement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idannee"] = new SelectList(_context.CoreAnnees, "Idannee", "Libelle", annualengagement.Idannee);
            ViewData["Idtype"] = new SelectList(_context.Rubriques, "Idtype", "Libelle", annualengagement.Idtype);
            return View(annualengagement);
        }

        // GET: Annualengagements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Annualengagements == null)
            {
                return NotFound();
            }

            var annualengagement = await _context.Annualengagements.FindAsync(id);
            if (annualengagement == null)
            {
                return NotFound();
            }
            ViewData["Idannee"] = new SelectList(_context.CoreAnnees, "Idannee", "Libelle", annualengagement.Idannee);
            ViewData["Idtype"] = new SelectList(_context.Rubriques, "Idtype", "Libelle", annualengagement.Idtype);
            // return View(annualengagement);
            return PartialView("Edit", annualengagement);

        }

        // POST: Annualengagements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idconfig,Idannee,Idtype,Montantevt,Isactive,Nbmandataire,Montantroute,Montanttotal,Montantpenalite,Interetmensuel,Tauxpenalite,Isaide,Iscotisation,Isdepense,Isfondentraide,Ispret,Commentaire,Categorie")] Annualengagement annualengagement)
        {
            if (id != annualengagement.Idconfig)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(annualengagement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnnualengagementExists(annualengagement.Idconfig))
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
            ViewData["Idannee"] = new SelectList(_context.CoreAnnees, "Idannee", "Libelle", annualengagement.Idannee);
            ViewData["Idtype"] = new SelectList(_context.Rubriques, "Idtype", "Libelle", annualengagement.Idtype);
            return View(annualengagement);
        }

        // GET: Annualengagements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Annualengagements == null)
            {
                return NotFound();
            }

            var annualengagement = await _context.Annualengagements
                .Include(a => a.IdanneeNavigation)
                .Include(a => a.IdtypeNavigation)
                .FirstOrDefaultAsync(m => m.Idconfig == id);
            if (annualengagement == null)
            {
                return NotFound();
            }

            //return View(annualengagement);
            return PartialView("Delete", annualengagement);

        }

        // POST: Annualengagements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Annualengagements == null)
            {
                return Problem("Entity set 'LabosContext.Annualengagements'  is null.");
            }
            var annualengagement = await _context.Annualengagements.FindAsync(id);
            if (annualengagement != null)
            {
                _context.Annualengagements.Remove(annualengagement);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnnualengagementExists(int id)
        {
          return (_context.Annualengagements?.Any(e => e.Idconfig == id)).GetValueOrDefault();
        }
    }
}
