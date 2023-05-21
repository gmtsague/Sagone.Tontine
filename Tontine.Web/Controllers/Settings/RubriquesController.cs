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
    public class RubriquesController : Controller
    {
        private readonly LabosContext _context;

        public RubriquesController(LabosContext context)
        {
            _context = context;
        }

        // GET: Rubriques
        public async Task<IActionResult> Index()
        {
              return _context.Rubriques != null ? 
                          View(await _context.Rubriques.ToListAsync()) :
                          Problem("Entity set 'LabosContext.Rubriques'  is null.");
        }

        // GET: Rubriques/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Rubriques == null)
            {
                return NotFound();
            }

            var rubrique = await _context.Rubriques
                .FirstOrDefaultAsync(m => m.Idtype == id);
            if (rubrique == null)
            {
                return NotFound();
            }

            //return View(rubrique);
            return PartialView("Details", rubrique);
        }

        // GET: Rubriques/Create
        public IActionResult Create()
        {
            //return View();
            return PartialView("Create");
        }

        // POST: Rubriques/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idtype,Libelle,Iscotisation,Ispret,Isaide,Isfondentraide,Isdepense,Candelete,Maxsignature")] Rubrique rubrique)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rubrique);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rubrique);
        }

        // GET: Rubriques/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Rubriques == null)
            {
                return NotFound();
            }

            var rubrique = await _context.Rubriques.FindAsync(id);
            if (rubrique == null)
            {
                return NotFound();
            }
            // return View(rubrique);
            return PartialView("Edit", rubrique);
        }

        // POST: Rubriques/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idtype,Libelle,Iscotisation,Ispret,Isaide,Isfondentraide,Isdepense,Candelete,Maxsignature")] Rubrique rubrique)
        {
            if (id != rubrique.Idtype)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rubrique);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RubriqueExists(rubrique.Idtype))
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
            return View(rubrique);
        }

        // GET: Rubriques/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Rubriques == null)
            {
                return NotFound();
            }

            var rubrique = await _context.Rubriques
                .FirstOrDefaultAsync(m => m.Idtype == id);
            if (rubrique == null)
            {
                return NotFound();
            }

            // return View(rubrique);
            return PartialView("Delete", rubrique);
        }

        // POST: Rubriques/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Rubriques == null)
            {
                return Problem("Entity set 'LabosContext.Rubriques'  is null.");
            }
            var rubrique = await _context.Rubriques.FindAsync(id);
            if (rubrique != null)
            {
                _context.Rubriques.Remove(rubrique);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RubriqueExists(int id)
        {
          return (_context.Rubriques?.Any(e => e.Idtype == id)).GetValueOrDefault();
        }
    }
}
