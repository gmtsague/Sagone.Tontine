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

namespace Meeting.web.Controllers.Settings
{
    public class RubriquesController : Controller
    {
        private readonly LabosContext _context;

        private readonly ILogger<RubriquesController> _logger;

        public RubriquesController(ILogger<RubriquesController> logger, LabosContext context)
        {
            _logger = logger;
            _context = context;
        }

        // GET: Rubriques
        public async Task<IActionResult> Index()
        {
            ViewData["TitleObj"] = new FormTitle("Rubrique");

            TypeAdapterConfig<MeetRubrique, RubriqueDto>.NewConfig().MaxDepth(3);

            var labosContext = _context.MeetRubriques.Include(m => m.Annee).Include(m => m.Typerub);
            return View(await labosContext.AsQueryable().ProjectToType<RubriqueDto>().ToListAsync());
        }

        // GET: Rubriques/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MeetRubriques == null)
            {
                return NotFound();
            }

            var meetRubrique = await _context.MeetRubriques
                .Include(m => m.Annee)
                .Include(m => m.Typerub)
                .FirstOrDefaultAsync(m => m.RubriqueId == id);
            if (meetRubrique == null)
            {
                return NotFound();
            }

            return PartialView("Details", meetRubrique.Adapt<RubriqueDto>());
        }

        // GET: Rubriques/Create
        public IActionResult Create()
        {
            ViewData["AnneeId"] = UtilityController.GetSelectListOfAnnees(_context);
            ViewData["TyperubId"] = UtilityController.GetSelectListOfTypeRubriques(_context);
            return PartialView("Create");
        }

        // POST: Rubriques/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [FormValidator]
        public async Task<IActionResult> Create([Bind("RubriqueId,AnneeId,TyperubId,Libelle,Nbmandataire,Montantroute,MontantPerson,IsOutcome,Commentaire")] RubriqueDto valueDto)
        {
            if (ModelState.IsValid)
            {
                var meetRubrique = valueDto.ToEntity();
                _context.Add(meetRubrique);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                return FormResult.CreateSuccessResult(UtilityController.SuccessOperation, Url.Action(nameof(Index)));
            }
            ViewData["AnneeId"] = UtilityController.GetSelectListOfAnnees(_context, valueDto.AnneeId);
            ViewData["TyperubId"] = UtilityController.GetSelectListOfTypeRubriques(_context, valueDto.TyperubId);
            return PartialView("Create", valueDto);
        }

        // GET: Rubriques/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MeetRubriques == null)
            {
                return NotFound();
            }

            var meetRubrique = await _context.MeetRubriques.FindAsync(id);
            if (meetRubrique == null)
            {
                return NotFound();
            }
            ViewData["AnneeId"] = UtilityController.GetSelectListOfAnnees(_context, meetRubrique.AnneeId);
            ViewData["TyperubId"] = UtilityController.GetSelectListOfTypeRubriques(_context, meetRubrique.TyperubId);
            return PartialView("Edit", meetRubrique.Adapt<RubriqueDto>());
        }

        // POST: Rubriques/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [FormValidator]
        public async Task<IActionResult> Edit(int id, [Bind("RubriqueId,AnneeId,TyperubId,Libelle,Nbmandataire,Montantroute,MontantPerson,IsOutcome,Commentaire")] RubriqueDto valueDto)
        {
            if (id != valueDto.RubriqueId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                    var meetRubrique = valueDto.ToEntity();
                try
                {
                    _context.Update(meetRubrique);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MeetRubriqueExists(meetRubrique.RubriqueId))
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
            ViewData["AnneeId"] = UtilityController.GetSelectListOfAnnees(_context, valueDto.AnneeId);
            ViewData["TyperubId"] = UtilityController.GetSelectListOfTypeRubriques(_context, valueDto.TyperubId);
            return PartialView("Edit", valueDto);
        }

        // GET: Rubriques/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MeetRubriques == null)
            {
                return NotFound();
            }

            var meetRubrique = await _context.MeetRubriques
                .Include(m => m.Annee)
                .Include(m => m.Typerub)
                .FirstOrDefaultAsync(m => m.RubriqueId == id);
            if (meetRubrique == null)
            {
                return NotFound();
            }

            return PartialView("Delete", meetRubrique.Adapt<RubriqueDto>());
        }

        // POST: Rubriques/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [FormValidator]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MeetRubriques == null)
            {
                //return Problem("Entity set 'LabosContext.MeetRubriques'  is null.");
                return FormResult.CreateErrorResult(UtilityController.DeleteOperationFailed);
            }
            var meetRubrique = await _context.MeetRubriques.FindAsync(id);
            if (meetRubrique != null)
            {
                _context.MeetRubriques.Remove(meetRubrique);
            }
            
            await _context.SaveChangesAsync();
            // return RedirectToAction(nameof(Index));
            return FormResult.CreateSuccessResult(UtilityController.SuccessOperation, Url.Action(nameof(Index)));
        }

        private bool MeetRubriqueExists(int id)
        {
          return (_context.MeetRubriques?.Any(e => e.RubriqueId == id)).GetValueOrDefault();
        }
    }
}
