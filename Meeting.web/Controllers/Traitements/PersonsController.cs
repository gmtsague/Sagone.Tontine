using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MeetingEntities.Models;
using Mapster;
using Meeting.Web.Dto;
using FormHelper;

namespace Meeting.web.Controllers.Traitements
{
    public class PersonsController : Controller
    {
        private readonly LabosContext _context;

        private readonly ILogger<PersonsController> _logger;

        public PersonsController(ILogger<PersonsController> logger, LabosContext context)
        {
            _logger = logger;
            _context = context;
        }

        // GET: Persons
        public async Task<IActionResult> Index()
        {
            ViewData["TitleObj"] = new FormTitle("Personne");

            var labosContext = _context.CorePeople.Include(c => c.Country).Include(c => c.Etab);
            return View(await labosContext.AsQueryable().ProjectToType<PersonDto>().ToListAsync());
        }

        // GET: Persons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CorePeople == null)
            {
                return NotFound();
            }

            var corePerson = await _context.CorePeople
                .Include(c => c.Country)
                .Include(c => c.Etab)
                .FirstOrDefaultAsync(m => m.PersonId == id);
            if (corePerson == null)
            {
                return NotFound();
            }

            return PartialView("Details", corePerson.Adapt<PersonDto>());
        }

        // GET: Persons/Create
        public IActionResult Create()
        {
            ViewData["CountryId"] = UtilityController.GetSelectListOfCountries(_context);
            ViewData["EtabId"] = UtilityController.GetSelectListOfEtablissements(_context);
            return PartialView("Create");
        }

        // POST: Persons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [FormValidator]
        public async Task<IActionResult> Create([Bind("PersonId,CountryId,EtabId,Nom,Prenom,Datenais,Lieunais,Sexe,Email,Adresse,AdhesionDate,Nocni,CniExpireDate,IsActive,IsVisible,AnneePromo")] PersonDto valueDto)
        {
            if (ModelState.IsValid)
            {
                var corePerson = valueDto.ToEntity();
                _context.Add(corePerson);
                await _context.SaveChangesAsync();
                // return RedirectToAction(nameof(Index));
                return FormResult.CreateSuccessResult(UtilityController.SuccessOperation, Url.Action(nameof(Index)));
            }
            ViewData["CountryId"] = UtilityController.GetSelectListOfCountries(_context, valueDto.CountryId ?? 0);
            ViewData["EtabId"] = UtilityController.GetSelectListOfEtablissements(_context, valueDto.EtabId ?? 0);
            return PartialView("Create", valueDto);
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
            ViewData["CountryId"] = UtilityController.GetSelectListOfCountries(_context, corePerson.CountryId ?? 0);
            ViewData["EtabId"] = UtilityController.GetSelectListOfEtablissements(_context, corePerson.EtabId ?? 0);
            return PartialView("Edit", corePerson.Adapt<PersonDto>());
        }

        // POST: Persons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [FormValidator]
        public async Task<IActionResult> Edit(int id, [Bind("PersonId,CountryId,EtabId,Nom,Prenom,Datenais,Lieunais,Sexe,Email,Adresse,AdhesionDate,Nocni,CniExpireDate,IsActive,IsVisible,AnneePromo")] PersonDto valueDto)
        {
            if (id != valueDto.PersonId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var corePerson = valueDto.ToEntity();
                try
                {
                    _context.Update(corePerson);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CorePersonExists(corePerson.PersonId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                // return RedirectToAction(nameof(Index));
                return FormResult.CreateSuccessResult(UtilityController.SuccessOperation, Url.Action(nameof(Index)));
            }
            ViewData["CountryId"] = UtilityController.GetSelectListOfCountries(_context, valueDto.CountryId ?? 0);
            ViewData["EtabId"] = UtilityController.GetSelectListOfEtablissements(_context, valueDto.EtabId ?? 0);
            return PartialView("Edit", valueDto);
        }

        // GET: Persons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CorePeople == null)
            {
                return NotFound();
            }

            var corePerson = await _context.CorePeople
                .Include(c => c.Country)
                .Include(c => c.Etab)
                .FirstOrDefaultAsync(m => m.PersonId == id);
            if (corePerson == null)
            {
                return NotFound();
            }

            return PartialView("Delete", corePerson.Adapt<PersonDto>());
        }

        // POST: Persons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [FormValidator]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CorePeople == null)
            {
                //return Problem("Entity set 'LabosContext.CorePeople'  is null.");
                return FormResult.CreateErrorResult(UtilityController.DeleteOperationFailed);
            }
            var corePerson = await _context.CorePeople.FindAsync(id);
            if (corePerson != null)
            {
                _context.CorePeople.Remove(corePerson);
            }
            
            await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));
            return FormResult.CreateSuccessResult(UtilityController.SuccessOperation, Url.Action(nameof(Index)));
        }

        private bool CorePersonExists(int id)
        {
          return (_context.CorePeople?.Any(e => e.PersonId == id)).GetValueOrDefault();
        }
    }
}
