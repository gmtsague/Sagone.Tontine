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
    public class PersonsController : Controller
    {
        private readonly LabosContext _context;

        public PersonsController(LabosContext context)
        {
            _context = context;
        }

        // GET: Persons
        public async Task<IActionResult> Index()
        {
            var labosContext = _context.CorePeople.Include(c => c.Pays);
            return View(await labosContext.ToListAsync());
        }

        // GET: Persons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CorePeople == null)
            {
                return NotFound();
            }

            var corePerson = await _context.CorePeople
                .Include(c => c.Pays)
                .FirstOrDefaultAsync(m => m.Idperson == id);
            if (corePerson == null)
            {
                return NotFound();
            }

            // return View(corePerson);
            return PartialView("Details", corePerson);
        }

        // GET: Persons/Create
        public IActionResult Create()
        {
            ViewData["PaysId"] = new SelectList(_context.CorePays, "PaysId", "Libelle");
            // return View();
            return PartialView("Create");

        }

        // POST: Persons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idperson,PaysId,Nom,Prenom,Datenais,Lieunais,Sexe,Email,Adresse,Dateadhesion,Anneepromo,Nocni,Isvisible")] CorePerson corePerson)
        {
            if (ModelState.IsValid)
            {
                _context.Add(corePerson);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PaysId"] = new SelectList(_context.CorePays, "PaysId", "Libelle", corePerson.PaysId);
            return View(corePerson);
        }

        // GET: Persons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CorePeople == null)
            {
                return NotFound();
            }

            var corePerson = await _context.CorePeople.FindAsync(id);
            if (corePerson == null)
            {
                return NotFound();
            }
            ViewData["PaysId"] = new SelectList(_context.CorePays, "PaysId", "Libelle", corePerson.PaysId);
            //return View(corePerson);
            return PartialView("Edit", corePerson);
        }

        // POST: Persons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idperson,PaysId,Nom,Prenom,Datenais,Lieunais,Sexe,Email,Adresse,Dateadhesion,Anneepromo,Nocni,Isvisible")] CorePerson corePerson)
        {
            if (id != corePerson.Idperson)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(corePerson);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CorePersonExists(corePerson.Idperson))
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
            ViewData["PaysId"] = new SelectList(_context.CorePays, "PaysId", "Libelle", corePerson.PaysId);
            return View(corePerson);
        }

        // GET: Persons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CorePeople == null)
            {
                return NotFound();
            }

            var corePerson = await _context.CorePeople
                .Include(c => c.Pays)
                .FirstOrDefaultAsync(m => m.Idperson == id);
            if (corePerson == null)
            {
                return NotFound();
            }

            //return View(corePerson);
            return PartialView("Delete", corePerson);
        }

        // POST: Persons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CorePeople == null)
            {
                return Problem("Entity set 'LabosContext.CorePeople'  is null.");
            }
            var corePerson = await _context.CorePeople.FindAsync(id);
            if (corePerson != null)
            {
                _context.CorePeople.Remove(corePerson);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CorePersonExists(int id)
        {
          return (_context.CorePeople?.Any(e => e.Idperson == id)).GetValueOrDefault();
        }
    }
}
