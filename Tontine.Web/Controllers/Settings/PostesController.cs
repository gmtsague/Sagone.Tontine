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
    public class PostesController : Controller
    {
        private readonly LabosContext _context;

        public PostesController(LabosContext context)
        {
            _context = context;
        }

        // GET: Postes
        public async Task<IActionResult> Index()
        {
            return _context.Postes != null ?
                        View(await _context.Postes.ToListAsync()) :
                        Problem("Entity set 'LabosContext.Postes'  is null.");
        }

        // GET: Postes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Postes == null)
            {
                return NotFound();
            }

            var poste = await _context.Postes
                .FirstOrDefaultAsync(m => m.Idposte == id);
            if (poste == null)
            {
                return NotFound();
            }

            //return View(poste);
            return PartialView("Details", poste);
        }

        // GET: Postes/Create
        public IActionResult Create()
        {
            //return View();
            return PartialView("Create");
        }

        // POST: Postes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idposte,Libelle,Ispresident,Istresorier,Issg,Issga,Iscc,Ismembre")] Poste poste)
        {
            if (ModelState.IsValid)
            {
                _context.Add(poste);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(poste);
        }

        // GET: Postes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Postes == null)
            {
                return NotFound();
            }

            var poste = await _context.Postes.FindAsync(id);
            if (poste == null)
            {
                return NotFound();
            }
            //return View(poste);
            return PartialView("Edit", poste);
        }

        // POST: Postes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idposte,Libelle,Ispresident,Istresorier,Issg,Issga,Iscc,Ismembre")] Poste poste)
        {
            if (id != poste.Idposte)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(poste);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PosteExists(poste.Idposte))
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
            return View(poste);
        }

        // GET: Postes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Postes == null)
            {
                return NotFound();
            }

            var poste = await _context.Postes
                .FirstOrDefaultAsync(m => m.Idposte == id);
            if (poste == null)
            {
                return NotFound();
            }

            //return View(poste);
            return PartialView("Delete", poste);
        }

        // POST: Postes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Postes == null)
            {
                return Problem("Entity set 'LabosContext.Postes'  is null.");
            }
            var poste = await _context.Postes.FindAsync(id);
            if (poste != null)
            {
                _context.Postes.Remove(poste);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PosteExists(int id)
        {
            return (_context.Postes?.Any(e => e.Idposte == id)).GetValueOrDefault();
        }
    }
}
