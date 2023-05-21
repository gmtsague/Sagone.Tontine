using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tontine.Entities.Models;
using Tontine.Web.Dto;

namespace Tontine.Web.Controllers.Settings
{
    public class ConfigvisasController : Controller
    {
        private readonly LabosContext _context;

        public ConfigvisasController(LabosContext context)
        {
            _context = context;
        }

        // GET: Configvisas
        public async Task<IActionResult> Index()
        {
            var labosContext = _context.Configvisas.Include(c => c.IdanneeNavigation).Include(c => c.IdposteNavigation).Include(c => c.IdtypeNavigation);
            return View(await labosContext.ToListAsync());
        }

        // GET: Configvisas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Configvisas == null)
            {
                return NotFound();
            }

            var configvisa = await _context.Configvisas
                .Include(c => c.IdanneeNavigation)
                .Include(c => c.IdposteNavigation)
                .Include(c => c.IdtypeNavigation)
                .FirstOrDefaultAsync(m => m.Idconfigvisa == id);
            if (configvisa == null)
            {
                return NotFound();
            }

            // return View(configvisa);
            return PartialView("Details", configvisa);
        }

        // GET: Configvisas/Create
        public IActionResult Create()
        {
            ViewData["Idannee"] = new SelectList(_context.CoreAnnees, "Idannee", "Libelle");
            ViewData["Idposte"] = new SelectList(_context.Postes, "Idposte", "Libelle");
            ViewData["Idtype"] = new SelectList(_context.Rubriques, "Idtype", "Libelle");
            //return View();
            return PartialView("Create");
        }

        // POST: Configvisas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idconfigvisa,Idposte,Idannee,Idtype,Numordre")] ConfigvisaDto valueDto)
        {
            //var modelStateValues = ModelState.Values; // For debugging/checking modelState errors before there are throw;
            var configvisa = valueDto.ToEntity();
            if (ModelState.IsValid)
            {
                _context.Add(configvisa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idannee"] = new SelectList(_context.CoreAnnees, "Idannee", "Libelle", configvisa.Idannee);
            ViewData["Idposte"] = new SelectList(_context.Postes, "Idposte", "Libelle", configvisa.Idposte);
            ViewData["Idtype"] = new SelectList(_context.Rubriques, "Idtype", "Libelle", configvisa.Idtype);
            return View(configvisa);
        }

        // GET: Configvisas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Configvisas == null)
            {
                return NotFound();
            }

            var configvisa = await _context.Configvisas.FindAsync(id);
            if (configvisa == null)
            {
                return NotFound();
            }
            ViewData["Idannee"] = new SelectList(_context.CoreAnnees, "Idannee", "Libelle", configvisa.Idannee);
            ViewData["Idposte"] = new SelectList(_context.Postes, "Idposte", "Libelle", configvisa.Idposte);
            ViewData["Idtype"] = new SelectList(_context.Rubriques, "Idtype", "Libelle", configvisa.Idtype);
            //return View(configvisa);
            return PartialView("Edit", configvisa);
        }

        // POST: Configvisas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idconfigvisa,Idposte,Idannee,Idtype,Numordre")] ConfigvisaDto valueDto)
        {
            if (id != valueDto.Idconfigvisa)
            {
                return NotFound();
            }

            var configvisa = valueDto.ToEntity();
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(configvisa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConfigvisaExists(configvisa.Idconfigvisa))
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
            ViewData["Idannee"] = new SelectList(_context.CoreAnnees, "Idannee", "Libelle", configvisa.Idannee);
            ViewData["Idposte"] = new SelectList(_context.Postes, "Idposte", "Libelle", configvisa.Idposte);
            ViewData["Idtype"] = new SelectList(_context.Rubriques, "Idtype", "Libelle", configvisa.Idtype);
            return View(configvisa);
        }

        // GET: Configvisas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Configvisas == null)
            {
                return NotFound();
            }

            var configvisa = await _context.Configvisas
                .Include(c => c.IdanneeNavigation)
                .Include(c => c.IdposteNavigation)
                .Include(c => c.IdtypeNavigation)
                .FirstOrDefaultAsync(m => m.Idconfigvisa == id);
            if (configvisa == null)
            {
                return NotFound();
            }

            //return View(configvisa);
            return PartialView("Delete", configvisa);
        }

        // POST: Configvisas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Configvisas == null)
            {
                return Problem("Entity set 'LabosContext.Configvisas'  is null.");
            }
            var configvisa = await _context.Configvisas.FindAsync(id);
            if (configvisa != null)
            {
                _context.Configvisas.Remove(configvisa);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConfigvisaExists(int id)
        {
            return (_context.Configvisas?.Any(e => e.Idconfigvisa == id)).GetValueOrDefault();
        }
    }
}
