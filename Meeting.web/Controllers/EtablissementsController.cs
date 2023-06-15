using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MeetingEntities.Models;
using Meeting.web.Controllers;
using Meeting.Web.Dto;
using Mapster;
using FormHelper;

namespace Meeting.Web.Controllers
{
    public class EtablissementsController : Controller
    {
        private readonly LabosContext _context;

        private readonly ILogger<EtablissementsController> _logger;

        public EtablissementsController(ILogger<EtablissementsController> logger, LabosContext context)
        {
            _logger = logger;
            _context = context;
        }

        // GET: Etablissements
        public async Task<IActionResult> Index()
        {
            ViewData["TitleObj"] = new FormTitle("Association");

            var labosContext = _context.CoreEtablissements.Include(c => c.Country);
            return View( await labosContext.OrderBy(m => m.Libelle).AsNoTracking().ProjectToType<EtablissementDto>().ToListAsync());
        }

        // GET: Etablissements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CoreEtablissements == null)
            {
                return NotFound();
            }

            var coreEtablissement = await _context.CoreEtablissements
                .Include(c => c.Country)
                .FirstOrDefaultAsync(m => m.EtabId == id);
            if (coreEtablissement == null)
            {
                return NotFound();
            }

            return View(coreEtablissement.Adapt<EtablissementDto>());
        }

        // GET: Etablissements/RefreshTopLayout
        //public IActionResult RefreshTopLayout()
        //{
        //    //ViewData["CountryId"] = UtilityController.GetSelectListOfCountries(_context);
        //    TempData["GlobalSelectedEtab"] = UtilityController.SessionEntities.GlobalSelectedEtab;
        //    return PartialView("_ShowGlobalEntities");
        //}

        // GET: Etablissements/Create
        public IActionResult Create()
        {
            ViewData["CountryId"] = UtilityController.GetSelectListOfCountries(_context);
            return View();
        }

        // POST: Etablissements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [FormValidator]
        public async Task<IActionResult> Create([Bind("EtabId,CountryId,Libelle,Adresse,Creationdate,DeployedUrl,DatabaseName,ConnString,EnableMultiAntenne")] EtablissementDto valueDto)
        {
            if (ModelState.IsValid)
            {
                var coreEtablissement = valueDto.ToEntity();
                _context.Add(coreEtablissement);
                await _context.SaveChangesAsync();
                // return RedirectToAction(nameof(Index));
                return FormResult.CreateSuccessResult(UtilityController.SuccessOperation, Url.Action(nameof(Index)));
            }
            ViewData["CountryId"] = UtilityController.GetSelectListOfCountries(_context, valueDto.CountryId ?? 0); 
            return View(valueDto);
        }

        // GET: Etablissements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CoreEtablissements == null)
            {
                return NotFound();
            }

            var coreEtablissement = await _context.CoreEtablissements.FindAsync(id);
            if (coreEtablissement == null)
            {
                return NotFound();
            }
            ViewData["CountryId"] = UtilityController.GetSelectListOfCountries(_context, coreEtablissement.CountryId ?? 0);
            return View(coreEtablissement.Adapt<EtablissementDto>());
        }

        // POST: Etablissements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [FormValidator]
        public async Task<IActionResult> Edit(int id, [Bind("EtabId,CountryId,Libelle,Adresse,Creationdate,DeployedUrl,DatabaseName,ConnString,EnableMultiAntenne")] EtablissementDto valueDto)
        {
            if (id != valueDto.EtabId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var coreEtablissement = valueDto.ToEntity();
                try
                {
                    _context.Update(coreEtablissement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoreEtablissementExists(coreEtablissement.EtabId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                //return RedirectToAction(nameof(Index));
                return FormResult.CreateSuccessResult(UtilityController.SuccessOperation, Url.Action(nameof(Index)));
            }
            ViewData["CountryId"] = UtilityController.GetSelectListOfCountries(_context, valueDto.CountryId ?? 0);
            return View(valueDto);
        }

        // GET: Etablissements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CoreEtablissements == null)
            {
                return NotFound();
            }

            var coreEtablissement = await _context.CoreEtablissements
                .Include(c => c.Country)
                .FirstOrDefaultAsync(m => m.EtabId == id);
            if (coreEtablissement == null)
            {
                return NotFound();
            }

            return View(coreEtablissement.Adapt<EtablissementDto>());
        }

        // POST: Etablissements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [FormValidator]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CoreEtablissements == null)
            {
                //return Problem("Entity set 'LabosContext.CoreEtablissements'  is null.");
                return FormResult.CreateErrorResult(UtilityController.DeleteOperationFailed);
            }
            var coreEtablissement = await _context.CoreEtablissements.FindAsync(id);
            if (coreEtablissement != null)
            {
                _context.CoreEtablissements.Remove(coreEtablissement);
            }
            
            await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));
            return FormResult.CreateSuccessResult(UtilityController.SuccessOperation, Url.Action(nameof(Index)));
        }

        // POST: Etablissements/Delete/5
        [HttpPost, ActionName("Setcurrent")]
        [ValidateAntiForgeryToken]
        [FormValidator]
        public async Task<IActionResult> SetCurrent(int id)
        {
            if (_context.CoreEtablissements == null)
            {
                //return Problem("Entity set 'LabosContext.CoreEtablissements'  is null.");
                return FormResult.CreateErrorResult(UtilityController.RequestedEntityNotFound);
            }
            var coreEtablissement = await _context.CoreEtablissements.FindAsync(id);
            if (coreEtablissement != null)
            {
                //_context.CoreEtablissements.Remove(coreEtablissement);
                UtilityController.SessionEntities.GlobalSelectedEtab = coreEtablissement.Adapt<EtablissementDto>();
                // TempData["GlobalSelectedEtab"] = UtilityController.SessionEntities.GlobalSelectedEtab;
                TempData["SelectedEtab"] = UtilityController.SessionEntities.GlobalSelectedEtab.EtabId;
                // return PartialView("_ShowGlobalEntities");
                //AppPageViewModel<string>.WorkingEtab
                return FormResult.CreateSuccessResult(UtilityController.SuccessOperation/*, Url.Action(nameof(RefreshTopLayout))*/);
            }
            return FormResult.CreateErrorResult(UtilityController.RequestedEntityNotFound);
        }

        private bool CoreEtablissementExists(int id)
        {
          return (_context.CoreEtablissements?.Any(e => e.EtabId == id)).GetValueOrDefault();
        }
    }
}
