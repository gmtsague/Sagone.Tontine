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
    public class BureauxController : Controller
    {
        private readonly LabosContext _context;

        public BureauxController(LabosContext context)
        {
            _context = context;
        }

        // GET: Bureaux
        public async Task<IActionResult> Index()
        {
            return _context.Bureaus != null ?
                        View(await _context.Bureaus.ToListAsync()) :
                        Problem("Entity set 'LabosContext.Bureaus'  is null.");
        }

        // GET: Bureaux/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Bureaus == null)
            {
                return NotFound();
            }

            var bureau = await _context.Bureaus
                .FirstOrDefaultAsync(m => m.Idbureau == id);
            if (bureau == null)
            {
                return NotFound();
            }

            // return View(bureau);
            return PartialView("Details", bureau);
        }

        // GET: Bureaux/Create
        public IActionResult Create()
        {
            //return View();
            return PartialView("Create");        
        }

        // POST: Bureaux/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idbureau,Libelle,Debut,Fin,Nbperson,Nbvotes,Nbabstention")] Bureau bureau)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bureau);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bureau);

        }

        // GET: Bureaux/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Bureaus == null)
            {
                return NotFound();
            }

            var bureau = await _context.Bureaus.FindAsync(id);
            if (bureau == null)
            {
                return NotFound();
            }
            //return View(bureau);
            return PartialView("Edit", bureau);
        }

        // POST: Bureaux/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idbureau,Libelle,Debut,Fin,Nbperson,Nbvotes,Nbabstention")] Bureau bureau)
        {
            if (id != bureau.Idbureau)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bureau);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BureauExists(bureau.Idbureau))
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
            return View(bureau);
        }

        // GET: Bureaux/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Bureaus == null)
            {
                return NotFound();
            }

            var bureau = await _context.Bureaus
                .FirstOrDefaultAsync(m => m.Idbureau == id);
            if (bureau == null)
            {
                return NotFound();
            }

            //return View(bureau);
            return PartialView("Delete", bureau);
        }

        // POST: Bureaux/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Bureaus == null)
            {
                return Problem("Entity set 'LabosContext.Bureaus'  is null.");
            }
            var bureau = await _context.Bureaus.FindAsync(id);
            if (bureau != null)
            {
                _context.Bureaus.Remove(bureau);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BureauExists(int id)
        {
            return (_context.Bureaus?.Any(e => e.Idbureau == id)).GetValueOrDefault();
        }
    }
}
