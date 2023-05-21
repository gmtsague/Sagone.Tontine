using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FormHelper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tontine.Entities.Models;
using Tontine.Web.Dto;

namespace Tontine.Web.Controllers.Traitements
{
    public class MonthlyseancesController : Controller
    {
        private readonly LabosContext _context;

        public MonthlyseancesController(LabosContext context)
        {
            _context = context;
        }

        // GET: Monthlyseances
        public async Task<IActionResult> Index()
        {
            var labosContext = _context.Monthlyseances.Include(m => m.IdanneeNavigation).Include(m => m.IdinscritNavigation).ThenInclude(m=>m.IdpersonNavigation);
            return View(await labosContext.OrderBy(t=>t.Idannee).ThenBy(t=>t.Numordre).ToListAsync());
        }

        // GET: Monthlyseances/Details/5
        public async Task<IActionResult> Details(int? year_id, int? month_id)
        {
            if (year_id == null || _context.Monthlyseances == null)
            {
                return NotFound();
            }

            var monthlyseance = await _context.Monthlyseances
                .Include(m => m.IdanneeNavigation)
                .Include(m => m.IdinscritNavigation)
                .FirstOrDefaultAsync(m => m.Idannee == year_id && m.Iddivision == month_id);
            if (monthlyseance == null)
            {
                return NotFound();
            }

            //return View(monthlyseance);
            return PartialView("Details", monthlyseance);

        }

        // GET: Monthlyseances/Create
        public IActionResult Create()
        {
            ViewData["Idannee"] = new SelectList(_context.CoreAnnees, "Idannee", "Libelle");
            ViewData["Idinscrit"] = new SelectList(_context.Inscriptions.Include(m => m.IdpersonNavigation), "Idinscrit", /*"Idinscrit"*/"IdpersonNavigation.Nom");
            //return View();
            return PartialView("Create");
        }

        // POST: Monthlyseances/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idannee,Iddivision,Idinscrit,Dateseance,Heuredebut,Libelle,Numordre,Totalcotise,Totalsortie,Montantpercu,Visarestants")] MonthlyseanceDto valueDto)
        {
            var monthlyseance = valueDto.ToEntity();
            if (ModelState.IsValid)
            {
                _context.Add(monthlyseance);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                return FormResult.CreateSuccessResult("Opération réalisée avec succès.", Url.Action(nameof(Index)/*"Home", "Index"*/));

            }
            ViewData["Idannee"] = new SelectList(_context.CoreAnnees, "Idannee", "Libelle", monthlyseance.Idannee);
            ViewData["Idinscrit"] = new SelectList(_context.Inscriptions.Include(m => m.IdpersonNavigation), "Idinscrit", /*"Idinscrit"*/"IdpersonNavigation.Nom", monthlyseance.Idinscrit);
            return View(monthlyseance);
        }

        // GET: Monthlyseances/Edit/5
        public async Task<IActionResult> Edit(int? year_id, int? month_id)
        {
            if (year_id == null || _context.Monthlyseances == null)
            {
                return NotFound();
            }

            var monthlyseance = await _context.Monthlyseances.FindAsync( year_id, month_id);
            if (monthlyseance == null)
            {
                return NotFound();
            }
            ViewData["Idannee"] = new SelectList(_context.CoreAnnees, "Idannee", "Libelle", monthlyseance.Idannee);
            ViewData["Idinscrit"] = new SelectList(_context.Inscriptions.Include(m => m.IdpersonNavigation), "Idinscrit", /*"Idinscrit"*/"IdpersonNavigation.Nom", monthlyseance.Idinscrit);
            //return View(monthlyseance);
            return PartialView("Edit", monthlyseance);
        }

        // POST: Monthlyseances/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? year_id, int? month_id, [Bind("Idannee,Iddivision,Idinscrit,Dateseance,Heuredebut,Libelle,Numordre,Totalcotise,Totalsortie,Montantpercu,Visarestants")] MonthlyseanceDto valueDto)
        {
            if (year_id != valueDto.Idannee)
            {
                return NotFound();
            }

            var monthlyseance = valueDto.ToEntity();
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(monthlyseance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MonthlyseanceExists(monthlyseance.Idannee, monthlyseance.Iddivision))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                // return RedirectToAction(nameof(Index));
                return FormResult.CreateSuccessResult("Opération réalisée avec succès.", Url.Action(nameof(Index)/*"Home", "Index"*/));
            }
            ViewData["Idannee"] = new SelectList(_context.CoreAnnees, "Idannee", "Libelle", monthlyseance.Idannee);
            ViewData["Idinscrit"] = new SelectList(_context.Inscriptions.Include(m => m.IdpersonNavigation), "Idinscrit", /*"Idinscrit"*/"IdpersonNavigation.Nom", monthlyseance.Idinscrit);

            return View(monthlyseance);
        }

        // GET: Monthlyseances/Delete/5
        public async Task<IActionResult> Delete(int? year_id, int? month_id)
        {
            if (year_id == null || _context.Monthlyseances == null)
            {
                return NotFound();
            }

            var monthlyseance = await _context.Monthlyseances
                .Include(m => m.IdanneeNavigation)
                .Include(m => m.IdinscritNavigation)
                .FirstOrDefaultAsync(m => m.Idannee == year_id && m.Iddivision == month_id);
            if (monthlyseance == null)
            {
                return NotFound();
            }

            // return View(monthlyseance);
            return PartialView("Delete", monthlyseance);
        }

        // POST: Monthlyseances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int Idannee, int Iddivision)
        {
            if (_context.Monthlyseances == null)
            {
                return Problem("Entity set 'LabosContext.Monthlyseances'  is null.");
            }
            var monthlyseance = await _context.Monthlyseances.FindAsync(Idannee, Iddivision);
            if (monthlyseance != null)
            {
                _context.Monthlyseances.Remove(monthlyseance);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MonthlyseanceExists(int year_id, int month_id)
        {
            return (_context.Monthlyseances?.Any(e => e.Idannee == year_id && e.Iddivision == month_id)).GetValueOrDefault();
        }
    }
}
